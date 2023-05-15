using Kata.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Items
{
    public class ItemD : IItem
    {
        public int Id => 4;

        public string SKU => "D";

        public decimal Price => 15;

        public Dictionary<int, decimal>? SpecialPrice => null;
    }
}
