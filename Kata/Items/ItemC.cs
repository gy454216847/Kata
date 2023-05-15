using Kata.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Items
{
    public class ItemC : IItem
    {
        public int Id => 3;

        public string SKU => "C";

        public decimal Price => 20;

        public Dictionary<int, decimal>? SpecialPrice =>null;
    }
}