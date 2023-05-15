using Kata.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Items
{
    public class ItemB : IItem
    {
        public int Id =>2;
        public string SKU=>"B";
        public decimal Price => 30;
        public Dictionary<int, decimal> SpecialPrice => new Dictionary<int, decimal> { { 2, 45 } };
    }
}
