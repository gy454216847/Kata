using Kata.Interface;
using Kata.Items;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public class Checkout : ICart
    {
        public Dictionary<string, int> _itemsScanned;
        public Dictionary<string,IItem> _itemsStorage;



        public Checkout()
        {
            _itemsScanned = new Dictionary<string, int>();
            _itemsStorage = new Dictionary<string, IItem>();
        }

        public void Scan(string sku)
        {
            if (!_itemsStorage.ContainsKey(sku))
            {
                throw new InvalidDataException("Invalid SKU");
            }
            else
            {
                if (_itemsScanned.ContainsKey(sku))
                {
                    _itemsScanned[sku]++;
                }
                else
                {
                    _itemsScanned[sku] = 1;
                }
            }
        }



        public int TotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in _itemsStorage.Values)
            {
                int unitPrice = item.Price;
                int itemCount = _itemsScanned.GetValueOrDefault(item.SKU);
                if (item.SpecialPrice != null && item.SpecialPrice.Any())
                {

                    foreach (var discount in item.SpecialPrice)
                    {
                        int discountCount = discount.Key;
                        int discountPrice = discount.Value;

                        if (itemCount >= discountCount)
                        {
                            int regularCount = itemCount % discountCount;
                            int discountGroupCount = itemCount / discountCount;
                            totalPrice += discountGroupCount * discountPrice;
                            itemCount = regularCount;
                        }
                        else
                        {
                            totalPrice += itemCount * unitPrice;
                        }
                    }
                }
                else
                {
                    totalPrice += itemCount * unitPrice;
                }
            }

            return totalPrice;
        }
    }
}

