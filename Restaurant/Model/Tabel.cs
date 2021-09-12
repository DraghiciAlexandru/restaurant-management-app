using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Tabel
    {
        public int Number;
        public int Size;
        public bool Available;

        public Tabel(int Number, int Size, bool Available)
        {
            this.Number = Number;
            this.Size = Size;
            this.Available = Available;
        }

        public Tabel(String Tabel) : this(int.Parse(Tabel.Split(',')[0]), int.Parse(Tabel.Split(',')[1]), bool.Parse(Tabel.Split(',')[2]))
        {

        }

        public override int GetHashCode()
        {
            return this.Number;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override string ToString()
        {
            return Number + "," + Size + "," + Available;
        }
    }
}
