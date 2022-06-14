using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public int GetDiscount(int bookCount, int cost)
        {
            int discount = 0;
            int costDiscount = cost / 500;
            if (bookCount >= 3 && bookCount < 5 && cost > 0)
            {
                discount = 5 + costDiscount;
                return discount;
            }
            if (bookCount >= 5 && bookCount < 10 && cost > 0)
            {
                discount = 10 + costDiscount;
                return discount;
            }
            if (bookCount >= 10 && cost > 0)
            {
                discount = 15 + costDiscount;
                return discount;
            }
            if (bookCount < 0)
            {
                return -1;
            }
            if (cost < 0)
            {
                return -1;
            }
            return -1;
        }
    }
}
