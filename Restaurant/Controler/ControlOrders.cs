using Restaurant.Model;
using Restaurant.Servicii;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Controler
{
    class ControlOrders 
    {
        String path = Application.StartupPath;
        public ListaSimpla<Order> orders;

        public ControlOrders()
        {
            orders = new ListaSimpla<Order>();
            open();
        }

        public void open()
        {
            String path = Application.StartupPath;
            StreamReader reader = new StreamReader(path + @"\orders.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                orders.addFinish(new Order(linie));
            }
            reader.Close();
        }

        public int lastId()
        {
            if (orders.size() > 0)
                return orders.getLast().Data.Id + 1;
            return 1;
        }

        public void add(Order order)
        {
            order.Id = lastId();
            orders.addFinish(order);
        }

        public void remove(int Id)
        {
            orders.deletePosition(orders.position(new Order(Id, 0, "", 0, 0)));
        }

        public void updateTotal(int id, double total)
        {
            for (int i = 0; i < orders.size(); i++)
            {
                if (orders.getAtPosition(i).Id == id)
                {
                    orders.getAtPosition(i).TotalPrice = total;
                }
            }
        }

        public void updateName(int Id, String Name)
        {
            for (int i = 0; i < orders.size(); i++)
            {
                if (orders.getAtPosition(i).Id == Id)
                {
                    orders.getAtPosition(i).ClientName = Name;
                }
            }
        }

        public void updateTabel(int Id, int nrTabel)
        {
            for (int i = 0; i < orders.size(); i++)
            {
                if (orders.getAtPosition(i).Id == Id)
                {
                    orders.getAtPosition(i).TabelNumber = nrTabel;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + @"\orders.txt");
            writer.Write(this.ToString());
            writer.Close();
        }

        public override string ToString()
        {
            String text = "";
            for (int i = 0; i < orders.size(); i++)
            {
                text += orders.getAtPosition(i).ToString() + Environment.NewLine;
            }
            return text;
        }

        public ListaSimpla<Order> getClient(int idClient)
        {
            ListaSimpla<Order> list = new ListaSimpla<Order>();

            for (int i = 0; i < orders.size(); i++)
            {
                if (orders.getAtPosition(i).ClientId==idClient)
                {
                    list.addFinish(orders.getAtPosition(i));
                }
            }

            return list;
        }
    }
}
