using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Interface
{
    public interface ICheckout
    {
        public void Scan(string sku);
        public int CalculateTotalPrice();
    }
}
