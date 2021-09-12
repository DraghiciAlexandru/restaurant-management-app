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
    class ControlTabels
    {
        String path = Application.StartupPath;

        public ListaSimpla<Tabel> listaTabel;
        
        public ControlTabels()
        {
            listaTabel = new ListaSimpla<Tabel>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\tabels.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaTabel.addFinish(new Tabel(linie));
            }
            reader.Close();
        }

        public void remove(Tabel Tabel)
        {
            listaTabel.deletePosition(listaTabel.position(Tabel));
        }

        private int lastId()
        {
            return listaTabel.getLast().Data.Number + 1;
        }

        public void add(Tabel Tabel)
        {
            Tabel.Number = lastId();
            listaTabel.addFinish(Tabel);
        }
       
        public void updateNrPers(int nr, int nrPersoane)
        {
            for (int i = 0; i < listaTabel.size(); i++)
            {
                if (listaTabel.getAtPosition(i).Number == nr)
                {
                    listaTabel.getAtPosition(i).Size = nrPersoane;
                }
            }
        }

        public void updateState(int nr, bool newState)
        {
            for (int i = 0; i < listaTabel.size(); i++)
            {
                if (listaTabel.getAtPosition(i).Number == nr)
                {
                    listaTabel.getAtPosition(i).Available = newState;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\rooms.txt");

            writer.Write(listaTabel.ToString());

            writer.Close();
        }

        public bool isOcupat(int nr)
        {
            return listaTabel.getAtPosition((nr - 1)).Available;
        }
    }
}
