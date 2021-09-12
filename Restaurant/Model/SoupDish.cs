using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class SoupDish : AbstractDish
    {
        public SoupDish(int Id, String Name, String Picture, double Price) : base(Id, Name, Picture, Price)
        {

        }

        public SoupDish(String Dish) : base(Dish)
        {
            
        }
    }
}
