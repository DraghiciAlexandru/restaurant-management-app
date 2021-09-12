using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class OrderDetails
    {
        public int Id;
        public int OrderId;
        public int DishId;
        public int Quantity;
        public double Price;

        public OrderDetails(int Id, int OrderId, int DishId, int Quantity, double Price)
        {
            this.Id = Id;
            this.OrderId = OrderId;
            this.DishId = DishId;
            this.Quantity = Quantity;
            this.Price = Price;
        }

        public OrderDetails(String Details) : this(int.Parse(Details.Split(',')[0]), int.Parse(Details.Split(',')[1]), int.Parse(Details.Split(',')[2]), int.Parse(Details.Split(',')[3]), double.Parse(Details.Split(',')[4]))
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
            return Id + "," + OrderId + "," + DishId + "," + Quantity + "," + Price;
        }

    }
}
