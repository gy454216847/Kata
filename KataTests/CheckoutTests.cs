using NUnit.Framework;
using Kata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kata.Interface;
using Kata.Items;

namespace Kata.Tests
{
    [TestFixture()]
    public class CheckoutTests
    {
        private readonly Dictionary<string, int> itemsScanned;
        private readonly Dictionary<string, IItem> itemsStorage;
        private readonly Checkout checkout;

        public CheckoutTests()
        {
            itemsScanned = new Dictionary<string, int>();
            itemsStorage = new Dictionary<string, IItem>();
            checkout = new(itemsScanned, itemsStorage);
        }

        [SetUp] 
        public void SetUp()
        {
            
            
            checkout.itemsStorage=new Dictionary<string, IItem>
            {
                {"A",new ItemA()},
                {"B",new ItemB()},
                {"C",new ItemC()},
                {"D",new ItemD()}
            };
            

        }

        [Test()]
        public void CheckoutNothing()
        {
            Assert.AreEqual(0,checkout.TotalPrice());

        }

        [Test()]
        public void CheckoutSingleA()
        {

            checkout.Scan("A");
            Assert.AreEqual(50, checkout.TotalPrice());
        }

        [Test()]
        public void Checkout_AB()
        {
            checkout.Scan("A");
            checkout.Scan("B");
            Assert.AreEqual(80,checkout.TotalPrice());
        }

        [Test()]
        public void Checkout_CDBA()
        {
            checkout.Scan("C");
            checkout.Scan("D");
            checkout.Scan("B");
            checkout.Scan("A");
            Assert.AreEqual(115, checkout.TotalPrice());
        }
        [Test()]
        public void Checkout_AA() { 
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.AreEqual(100,checkout.TotalPrice());
        
        }
        [Test()]
        public void Checkout_AAA() {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.AreEqual(130, checkout.TotalPrice());
        
        }

        

        [TearDown]
        public void TearDown()
        {
            checkout.itemsScanned.Clear();
            checkout.itemsStorage.Clear();
        }
    }
}