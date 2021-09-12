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
    public class ControlCustomers
    {
        String path = Application.StartupPath;

        public ListaSimpla<Person> listaPerson;
        public static Person loged;

        public ControlCustomers()
        {
            listaPerson = new ListaSimpla<Person>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\clients.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaPerson.addFinish(new Client(linie));
            }
            reader.Close();

            reader = new StreamReader(path + "\\staff.txt");
            linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaPerson.addFinish(new Staff(linie));
            }

            reader.Close();
        }

        public void remove(Person person)
        {
            listaPerson.deletePosition(listaPerson.position(person));
        }

        public int lastId()
        {
            if (listaPerson.size() > 0)
                return listaPerson.getLast().Data.ID + 1;
            return 1;
        }

        public void add(Person person)
        {
            person.ID = lastId();
            listaPerson.addFinish(person);
        }

        public void updateName(int id, String name)
        {
            for (int i = 0; i < listaPerson.size(); i++)
            {
                if (listaPerson.getAtPosition(i).ID == id)
                {
                    listaPerson.getAtPosition(i).Nume = name;
                }
            }
        }

        public void updatePassword(int id, String password)
        {
            for (int i = 0; i < listaPerson.size(); i++)
            {
                if (listaPerson.getAtPosition(i).ID == id)
                {
                    listaPerson.getAtPosition(i).Password = password;
                }
            }
        }

        public void updateEmail(int id, String email)
        {
            for (int i = 0; i < listaPerson.size(); i++)
            {
                if (listaPerson.getAtPosition(i).ID == id)
                {
                    listaPerson.getAtPosition(i).Email = email;
                }
            }
        }

        public void updatePhone(int id, String phone)
        {
            for (int i = 0; i < listaPerson.size(); i++)
            {
                if (listaPerson.getAtPosition(i).ID == id)
                {
                    listaPerson.getAtPosition(i).Telefon = phone;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\clients.txt");

            for (int i = 0; i < listaPerson.size(); i++) 
            {
                if(listaPerson.getAtPosition(i) is Client)
                {
                    writer.WriteLine(listaPerson.getAtPosition(i));
                }
            }

            writer.Close();


            writer = new StreamWriter(path + "\\staff.txt");

            for (int i = 0; i < listaPerson.size(); i++)
            {
                if (listaPerson.getAtPosition(i) is Staff)
                {
                    writer.WriteLine(listaPerson.getAtPosition(i));
                }
            }

            writer.Close();
        }

        public Person getClient(int id)
        {
            for (int i = 0; i < listaPerson.size(); i++)
            {
                if (listaPerson.getAtPosition(i).ID == id)
                {
                    return listaPerson.getAtPosition(i);
                }
            }
            return null;
        }

        public Person getClient(String nume)
        {
            for (int i = 0; i < listaPerson.size(); i++)
            {
                if (listaPerson.getAtPosition(i).Nume == nume)
                {
                    return listaPerson.getAtPosition(i);
                }
            }
            return null;
        }
    }
}
