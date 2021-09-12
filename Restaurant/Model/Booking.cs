using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Booking : IComparable<Booking>
    {
        public int Id;
        public int ClientId;
        public int OrderId;
        public int TabelNr;
        public DateTime Date;

        public Booking(int Id, int ClientId, int OrderId, int TabelNr, DateTime Date)
        {
            this.Id = Id;
            this.ClientId = ClientId;
            this.OrderId = OrderId;
            this.TabelNr = TabelNr;
            this.Date = Date;
        }

        public Booking(String Booking) : this(int.Parse(Booking.Split(',')[0]), int.Parse(Booking.Split(',')[1]), int.Parse(Booking.Split(',')[2]), int.Parse(Booking.Split(',')[3]), DateTime.Parse(Booking.Split(',')[4]))
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
            return Id + "," + ClientId + "," + OrderId + "," + TabelNr + "," + this.Date.ToString("g");
        }

        public int CompareTo(Booking other)
        {
            if (this.Date.Date == other.Date.Date)
            {
                if (Math.Abs(this.Date.Hour - other.Date.Hour) < 2)
                {
                    return 0;
                }
            }
            return this.Date.CompareTo(other.Date);
        }
    }
}
