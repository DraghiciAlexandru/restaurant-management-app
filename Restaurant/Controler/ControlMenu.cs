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
    class ControlMenu
    {
        String path = Application.StartupPath;

        public ListaSimpla<AbstractDish> listaDish;

        public ControlMenu()
        {
            listaDish = new ListaSimpla<AbstractDish>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\main.txt");
            String linie = "";
            
            while ((linie = reader.ReadLine()) != null)
            {
                listaDish.addFinish(new MainDish(linie));
            }
            reader.Close();

            reader = new StreamReader(path + "\\soup.txt");
            linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaDish.addFinish(new SoupDish(linie));
            }
            reader.Close();

            reader = new StreamReader(path + "\\desert.txt");
            linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaDish.addFinish(new DesertDish(linie));
            }
            reader.Close();
        }

        public void remove(AbstractDish AbstractDish)
        {
            listaDish.deletePosition(listaDish.position(AbstractDish));
        }

        public void add(AbstractDish AbstractDish)
        {
            listaDish.addFinish(AbstractDish);
        }

        public void updateName(int Id, String Name)
        {
            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i).Id == Id)
                {
                    listaDish.getAtPosition(i).Name = Name;
                }
            }
        }

        public void updatePicFile(int Id, String picFile)
        {
            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i).Id == Id)
                {
                    listaDish.getAtPosition(i).picFile = picFile;
                }
            }
        }

        public void updatePrice(int Id, double price)
        {
            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i).Id == Id)
                {
                    listaDish.getAtPosition(i).Price = price;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\main.txt");

            for(int i=0; i<listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i) is MainDish)
                    writer.WriteLine(listaDish.getAtPosition(i));
            }

            writer.Close();

            writer = new StreamWriter(path + "\\soup.txt");

            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i) is SoupDish)
                    writer.WriteLine(listaDish.getAtPosition(i));
            }

            writer.Close();

            writer = new StreamWriter(path + "\\desert.txt");

            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i) is DesertDish)
                    writer.WriteLine(listaDish.getAtPosition(i));
            }

            writer.Close();
        }

        public ListaSimpla<AbstractDish> getMain()
        {
            ListaSimpla<AbstractDish> mainList = new ListaSimpla<AbstractDish>();
            for(int i=0; i<listaDish.size();i++)
            {
                if (listaDish.getAtPosition(i) is MainDish) 
                {
                    mainList.addFinish(listaDish.getAtPosition(i));
                }
            }
            return mainList;
        }

        public ListaSimpla<AbstractDish> getSoup()
        {
            ListaSimpla<AbstractDish> soupList = new ListaSimpla<AbstractDish>();
            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i) is SoupDish)
                {
                    soupList.addFinish(listaDish.getAtPosition(i));
                }
            }
            return soupList;
        }

        public ListaSimpla<AbstractDish> getDesert()
        {
            ListaSimpla<AbstractDish> desertList = new ListaSimpla<AbstractDish>();
            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i) is DesertDish)
                {
                    desertList.addFinish(listaDish.getAtPosition(i));
                }
            }
            return desertList;
        }

        public String getTip(int Id)
        {
            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i).Id == Id)
                {
                    if (listaDish.getAtPosition(i) is MainDish)
                        return "Main";
                    else if (listaDish.getAtPosition(i) is SoupDish)
                        return "Soup";
                    else
                        return "Desert";
                }
            }
            return null;
        }

        public AbstractDish getDish(int Id)
        {
            for (int i = 0; i < listaDish.size(); i++)
            {
                if (listaDish.getAtPosition(i).Id == Id)
                {
                    return listaDish.getAtPosition(i);
                }
            }
            return null;
        }
    }
}
