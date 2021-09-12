using Restaurant.Servicii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Order
    {
        public int Id;
        public int ClientId;
        public String ClientName;
        public int TabelNumber;
        public double TotalPrice;

        public Order(int Id, int ClientId, String ClientName, int TabelNumber, double TotalPrice)
        {
            this.Id = Id;
            this.ClientId = ClientId;
            this.ClientName = ClientName;
            this.TabelNumber = TabelNumber;
            this.TotalPrice = TotalPrice;
        }

        public Order(String Order) : this(int.Parse(Order.Split(',')[0]), int.Parse(Order.Split(',')[1]), Order.Split(',')[2],  int.Parse(Order.Split(',')[3]), double.Parse(Order.Split(',')[4]))
        {

        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override string ToString()
        {
            return Id + "," + ClientId + "," + ClientName + "," + TabelNumber + "," + TotalPrice;
        }

    }
}
