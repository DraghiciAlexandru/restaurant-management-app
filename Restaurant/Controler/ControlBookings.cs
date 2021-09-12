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
    class ControlBookings
    {
        String path = Application.StartupPath;

        public ListaSimpla<Booking> listaRezervari;

        public ControlBookings()
        {
            listaRezervari = new ListaSimpla<Booking>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\bookings.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaRezervari.addFinish(new Booking(linie));
            }
            reader.Close();
        }

        public void remove(Booking Booking)
        {
            listaRezervari.deletePosition(listaRezervari.position(Booking));
        }

        private int lastId()
        {
            if (listaRezervari.size() > 0)
                return listaRezervari.getLast().Data.Id + 1;
            return 1;
        }

        public void add(Booking Booking)
        {
            Booking.Id = lastId();
            listaRezervari.addFinish(Booking);
        }

        public void updateDate(int Id, DateTime Date)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if (listaRezervari.getAtPosition(i).Id == Id)
                {
                    listaRezervari.getAtPosition(i).Date = Date;
                }
            }
        }

        public void updateOrder(int Id, int OrderId)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if (listaRezervari.getAtPosition(i).Id == Id)
                {
                    listaRezervari.getAtPosition(i).OrderId = OrderId;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\bookings.txt");

            writer.Write(listaRezervari.ToString());

            writer.Close();
        }

        public Booking getRezervare(int id)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if (listaRezervari.getAtPosition(i).Id == id)
                {
                    return listaRezervari.getAtPosition(i);
                }
            }
            return null;
        }

        public bool isRezerved(Booking booking)
        {
            if (booking.Date.Hour < 9 || booking.Date.Hour > 21)
                return false;

            for (int i = 0; i < listaRezervari.size(); i++) 
            {
                if ((listaRezervari.getAtPosition(i).CompareTo(booking) == 0) && (listaRezervari.getAtPosition(i).TabelNr == booking.TabelNr))  
                {
                    return true;
                }
            }
            return false;
        }

        public ListaSimpla<Booking> getAvailable(int nrTabel)
        {
            ListaSimpla<Booking> listaAva = new ListaSimpla<Booking>();

            Booking verifica = new Booking(0, 0, 0, nrTabel, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0));
            int ore = 0, zile = 0;

            while (verifica.Date.CompareTo(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, 0, 0).AddMonths(3)) == -1) 
            {
                verifica = new Booking(0, 0, 0, nrTabel, new DateTime(verifica.Date.Year, verifica.Date.Month, verifica.Date.Day, 9, 0, 0).Add(new TimeSpan(zile, ore, 0, 0)));
                if (zile == 1)
                    zile = 0;
                if (isRezerved(verifica) == false && verifica.Date.Hour >= 9 && verifica.Date.Hour <= 22) 
                {
                    listaAva.addFinish(verifica);
                }
                ore += 2;

                if (ore > 12) 
                {
                    zile++;
                    ore = 0;
                }

            }
            return listaAva;
        }

        public Booking getClose(Booking booking)
        {
            if (isRezerved(booking) == false)
            {
                return booking;
            }
            else
            {
                ListaSimpla<Booking> listaAva = getAvailable(booking.TabelNr);

                Booking ava = new Booking(booking.ToString());

                for (int i = 0; i < listaAva.size() - 1; i++) 
                {
                    if ((booking.CompareTo(listaAva.getAtPosition(i)) == 1) && (booking.CompareTo(listaAva.getAtPosition(i + 1)) == -1))
                    {
                        if ((booking.Date - listaAva.getAtPosition(i).Date) < (listaAva.getAtPosition(i + 1).Date - booking.Date))
                        {
                            ava.Date = listaAva.getAtPosition(i).Date;
                        }
                        else
                        {
                            ava.Date = listaAva.getAtPosition(i + 1).Date;
                        }
                        return ava;
                    }
                }
            }
            return null;
        }

        public Booking getByDate(Booking booking)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if ((listaRezervari.getAtPosition(i).CompareTo(booking) == 0) && (listaRezervari.getAtPosition(i).TabelNr == booking.TabelNr))
                {
                    return listaRezervari.getAtPosition(i);
                }
            }
            return null;
        }

        public Booking getByOrder(int orderId)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if (listaRezervari.getAtPosition(i).OrderId == orderId) 
                {
                    return listaRezervari.getAtPosition(i);
                }
            }
            return null;
        }
    }
}
