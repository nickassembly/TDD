using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Project
{
    public class Order
    {
        public Order(int basketId)
        {
            BasketId = basketId;
        }

        public int BasketId { get; set; }
    }
}
