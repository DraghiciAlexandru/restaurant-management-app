using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class MainDish : AbstractDish
    {
        public MainDish(int Id, String Name, String Picture, double Price) : base(Id, Name, Picture, Price)
        {

        }

        public MainDish(String Dish) : base(Dish)
        {

        }
    }
}
