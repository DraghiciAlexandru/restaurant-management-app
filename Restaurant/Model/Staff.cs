using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Staff : Person
    {
        public Staff(int ID, String Nume, String Password, String Email, String Telefon) : base(ID, Nume, Password, Email, Telefon)
        {

        }

        public Staff(String client) : base(int.Parse(client.Split(',')[0]), client.Split(',')[1], client.Split(',')[2], client.Split(',')[3], client.Split(',')[4])
        {

        }
    }
}
