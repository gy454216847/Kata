using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Interface
{
    public interface IItem
    {
        public int Id { get; }
        public string SKU { get;  }
        public decimal Price { get; }

        public Dictionary<int, decimal>? SpecialPrice { get; }
    }
}
