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
    class ControlCancel
    {
        String path = Application.StartupPath;

        public ListaSimpla<Booking> listaCancel;

        public ControlCancel()
        {
            listaCancel = new ListaSimpla<Booking>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\cancel.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaCancel.addFinish(new Booking(linie));
            }
            reader.Close();
        }

        public void remove(Booking Rezervare)
        {
            listaCancel.deletePosition(listaCancel.position(Rezervare));
        }

        public void add(Booking Rezervare)
        {
            listaCancel.addFinish(Rezervare);
        }

        public void updateDate(int Id, DateTime Date)
        {
            for (int i = 0; i < listaCancel.size(); i++)
            {
                if (listaCancel.getAtPosition(i).Id == Id)
                {
                    listaCancel.getAtPosition(i).Date = Date;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\cancel.txt");

            writer.Write(listaCancel.ToString());

            writer.Close();
        }

        public bool isCancel(int Id)
        {
            for (int i = 0; i < listaCancel.size(); i++)
            {
                if (listaCancel.getAtPosition(i).Id == Id)
                    return true;
            }
            return false;
        }

        public bool isCancel(Booking booking)
        {
            for (int i = 0; i < listaCancel.size(); i++)
            {
                if ((listaCancel.getAtPosition(i).CompareTo(booking) == 0) && (listaCancel.getAtPosition(i).TabelNr == booking.TabelNr)) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
