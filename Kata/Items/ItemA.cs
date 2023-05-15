using Kata.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Items
{
    public class ItemA : IItem
    {
        public int Id => 1;
        public string SKU=>"A";
        public decimal Price => 50;
        public Dictionary<int, decimal> SpecialPrice => new Dictionary<int, decimal> { { 3, 130 } };
    }
}
