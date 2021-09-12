using Restaurant.Servicii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Menu
    {
        public ListaSimpla<AbstractDish> dishList;

        public Menu(ListaSimpla<AbstractDish> listaSimpla)
        {
            dishList = listaSimpla;
        }

        public ListaSimpla<MainDish> getMain()
        {
            ListaSimpla<MainDish> listaMain = new ListaSimpla<MainDish>();
            for(int i=0; i<dishList.size(); i++)
            {
                if (dishList.getAtPosition(i) is MainDish)
                    listaMain.addFinish(dishList.getAtPosition(i) as MainDish);
            }
            return listaMain;
        }

        public ListaSimpla<SoupDish> getSoup()
        {
            ListaSimpla<SoupDish> listaSoup = new ListaSimpla<SoupDish>();
            for (int i = 0; i < dishList.size(); i++)
            {
                if (dishList.getAtPosition(i) is MainDish)
                    listaSoup.addFinish(dishList.getAtPosition(i) as SoupDish);
            }
            return listaSoup;
        }

        public ListaSimpla<DesertDish> getDesert()
        {
            ListaSimpla<DesertDish> listaDesert = new ListaSimpla<DesertDish>();
            for (int i = 0; i < dishList.size(); i++)
            {
                if (dishList.getAtPosition(i) is MainDish)
                    listaDesert.addFinish(dishList.getAtPosition(i) as DesertDish);
            }
            return listaDesert;
        }
    }
}
