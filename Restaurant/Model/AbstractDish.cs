using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Model
{
    class AbstractDish
    {
        public int Id;
        public String Name;
        public String picFile;
        public Image Picture;
        public double Price;

        public AbstractDish(int Id, String Name, String Picture, double Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.picFile = Picture;
            this.Picture = Image.FromFile(Application.StartupPath + @"\resources\\" + Picture + ".jfif");
            this.Price = Price;
        }

        public AbstractDish(String Dish) : this(int.Parse(Dish.Split(',')[0]), Dish.Split(',')[1], Dish.Split(',')[2], double.Parse(Dish.Split(',')[3]))
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
            return Id + "," + Name + "," + picFile + "," + Price;
        }
    }
}
