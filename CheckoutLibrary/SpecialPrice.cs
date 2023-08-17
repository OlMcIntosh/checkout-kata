using System.Diagnostics;

namespace CheckoutLibrary
{
    internal class SpecialPrice
    {
        public string sku { get; private set; }
        public int quantity { get; private set; }
        public int price { get; private set; }

        public SpecialPrice(string sku, int quantity, int price)
        {
            this.sku = sku;
            this.quantity = quantity;
            this.price = price;
        }
    }

    internal class ListOfSpecialPrices: List<SpecialPrice> 
    {
        internal void Add(string SKU, int quantity, int price)
        {
            this.Add(new SpecialPrice(SKU, quantity, price));
        }

        internal SpecialPrice GetPriceForSKU(string key)
        {
            return this.FirstOrDefault(x => x.sku == key);
        }

        internal bool IsThereASpecialPriceFor(string key)
        {
            return this.Any(x => x.sku == key);
        }
    }
}