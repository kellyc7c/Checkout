﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Checkout
    {
        private Dictionary<string, int> _prices;

        public Checkout(Dictionary<string, int> prices)
        {
            _prices = prices;
        }

        public int Scan(string item)
        {
            if (item.Length == 2)
            {
                return _prices[item.Substring(0,1)] * 2;
            }
            return _prices[item];
        }
    }
}
