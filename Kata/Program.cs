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
            //add items in storage
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

                //enter empty string to exit
                if (string.IsNullOrEmpty(sku))
                {
                    break;
                }
                //exit if scan invalid sku
                try
                {
                    checkout.Scan(sku);
                }
                catch (InvalidDataException)
                {
                    break;
                }
                int totalPrice = checkout.CalculateTotalPrice();
                Console.WriteLine($"Total Price:{totalPrice}");
            }
            Console.WriteLine("Exiting the program...");
            Console.ReadKey();
        }
    }
}
