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
    class ControlOrderDetails
    {
        String path = Application.StartupPath;
        public ListaSimpla<OrderDetails> details;

        public ControlOrderDetails()
        {
            details = new ListaSimpla<OrderDetails>();
            open();
        }

        public void open()
        {   
            StreamReader reader = new StreamReader(path + @"\details.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                details.addFinish(new OrderDetails(linie));
            }
            reader.Close();
        }

        private int lastId()
        {
            if (details.size() > 0)
                return details.getLast().Data.Id + 1;
            return 1;
        }

        public void add(OrderDetails details)
        {
            details.Id = lastId();
            this.details.addFinish(details);
        }

        public void remove(int Id)
        {
            details.deletePosition(details.position(new OrderDetails(Id, 0, 0, 0, 0)));
        }

        public void updateQuantity(int Id, int Quantity)
        {
            for (int i = 0; i < details.size(); i++)
            {
                if (details.getAtPosition(i).Id == Id)
                {
                    details.getAtPosition(i).Quantity = Quantity;
                    MessageBox.Show(Quantity.ToString());
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + @"\details.txt");
            writer.Write(details.ToString());
            writer.Close();
        }

        public override string ToString()
        {
            String text = "";
            for (int i = 0; i < details.size(); i++)
            {
                text += details.getAtPosition(i).ToString() + Environment.NewLine;
            }
            return text;
        }

        public ListaSimpla<OrderDetails> getOrderDetails(int OrderID)
        {
            ListaSimpla<OrderDetails> listDetails = new ListaSimpla<OrderDetails>();

            for (int i = 0; i < details.size(); i++) 
            {
                if (details.getAtPosition(i).OrderId == OrderID) 
                {
                    listDetails.addFinish(details.getAtPosition(i));
                }
            }

            return listDetails;
        }

        public OrderDetails getDetails(int OrderId, int Id)
        {
            ListaSimpla<OrderDetails> listDetails = getOrderDetails(OrderId);

            for (int i = 0; i < listDetails.size(); i++)
            {
                if (listDetails.getAtPosition(i).DishId==Id)
                {
                    return listDetails.getAtPosition(i);
                }
            }

            return null;
        }
    }
}
