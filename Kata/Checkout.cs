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
    public class Checkout : ICheckout
    {
        public  Dictionary<string, int> itemsScanned;
        public  Dictionary<string, IItem> itemsStorage;

        public Checkout(Dictionary<string, int> itemsScanned, Dictionary<string, IItem> itemsStorage)
        {
            this.itemsScanned = itemsScanned;
            this.itemsStorage = itemsStorage;
        }

        public void Scan(string sku)
        {
            if (!itemsStorage.ContainsKey(sku))
            {
                throw new InvalidDataException("Invalid SKU");
            }
            else
            {
                if (itemsScanned.ContainsKey(sku))
                {
                    itemsScanned[sku]++;
                }
                else
                {
                    itemsScanned[sku] = 1;
                }
            }
        }



        public int TotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in itemsStorage.Values)
            {
                int unitPrice = item.Price;
                int itemCount = itemsScanned.GetValueOrDefault(item.SKU);
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

