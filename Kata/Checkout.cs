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
    /// <summary>
    /// Scan and checkout items
    /// </summary>
    public class Checkout : ICheckout
    {
        public Dictionary<string, int> itemsScanned;
        public Dictionary<string, IItem> itemsStorage;

        public Checkout(Dictionary<string, int> itemsScanned, Dictionary<string, IItem> itemsStorage)
        {
            this.itemsScanned = itemsScanned;
            this.itemsStorage = itemsStorage;
        }

        /// <summary>
        /// Scan items
        /// </summary>
        /// <param name="sku"></param>
        /// <exception cref="InvalidDataException"></exception>
        public void Scan(string sku)
        {
            // Scan invalid sku
            if (!itemsStorage.ContainsKey(sku))
            {
                Console.WriteLine("Invalid SKU");
                throw new InvalidDataException("invalid sku");
            }
            else
            {
                // Scan valid sku again
                if (itemsScanned.ContainsKey(sku))
                {
                    itemsScanned[sku]++;
                }
                // Scan valid sku first time
                else
                {
                    itemsScanned[sku] = 1;
                }
            }
        }


        /// <summary>
        /// Calculate total price
        /// </summary>
        /// <returns></returns>
        public int CalculateTotalPrice()
        {
            int totalPrice = 0;
            //get item price and count
            foreach (var item in itemsStorage.Values)
            {
                int unitPrice = item.Price;
                int itemCount = itemsScanned.GetValueOrDefault(item.SKU);
                //if there is discount in item
                if (item.SpecialPrice?.Any() == true)
                {
                    //get discount information
                    foreach (var discount in item.SpecialPrice)
                    {
                        int discountCount = discount.Key;
                        int discountPrice = discount.Value;
                        //get discount
                        if (itemCount >= discountCount)
                        {
                            int regularCount = itemCount % discountCount;
                            int discountGroupCount = itemCount / discountCount;
                            totalPrice += discountGroupCount * discountPrice;
                            itemCount = regularCount;
                            break;
                        }
                        //not enough count for discount
                        else
                        {
                            totalPrice += itemCount * unitPrice;
                        }
                    }
                }
                //no discount
                else
                {
                    totalPrice += itemCount * unitPrice;
                }
            }

            return totalPrice;
        }
    }
}

