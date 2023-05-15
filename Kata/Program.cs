using Kata.Interface;
using Kata.Items;

namespace Kata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> itemsScanned = new Dictionary<string, int>();
            Dictionary<string, IItem> itemsStorage = new Dictionary<string, IItem>();
            Checkout checkout = new Checkout(itemsScanned, itemsStorage);
            checkout.itemsStorage = new Dictionary<string, IItem>
            {
                {"A",new ItemA()},
                {"B",new ItemB()},
                {"C",new ItemC()},
                {"D",new ItemD()}
            };
            while (true)
            {
                Console.WriteLine("Please enter the SKU (or leave empty to exit):");
                string sku = Console.ReadLine();
                if (string.IsNullOrEmpty(sku))
                {
                    break;
                }
                checkout.Scan(sku);
                int totalPrice = checkout.CalculateTotalPrice();
                Console.WriteLine($"Total Price:{totalPrice}");
            }
            Console.WriteLine("Exiting the program...");
            Console.ReadKey();
        }
    }
}
