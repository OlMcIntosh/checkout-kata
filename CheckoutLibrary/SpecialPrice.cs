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
}