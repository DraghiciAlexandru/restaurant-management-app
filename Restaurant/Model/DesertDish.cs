using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class DesertDish : AbstractDish
    {
        public DesertDish(int Id, String Name, String Picture, double Price) : base(Id, Name, Picture, Price)
        {

        }

        public DesertDish(String Dish) : base(Dish)
        {
            
        }
    }
}
