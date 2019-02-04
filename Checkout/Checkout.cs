using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Checkout
    {
        public int Scan(string item)
        {
            if (item == "A")
            {
                return 50;
            }
            else if (item == "B")
            {
                return 30;
            }
            else if (item == "C")
            {
                return 20;
            }

            return 15;
        }
    }
}
