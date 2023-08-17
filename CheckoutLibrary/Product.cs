namespace CheckoutLibrary
{
    internal class Product
    {
        internal string SKU;
        internal int quantity;

        public Product(string sKU, int quantity)
        {
            SKU = sKU;
            this.quantity = quantity;
        }

        internal void IncreaseQuantity()
        {
            quantity += 1;
        }
    }

    internal class ListOfProducts : List<Product>
    {
        internal void Add(string sKU)
        {
            if (this.Any(x => x.SKU == sKU))
            {
                this.First(x => x.SKU == sKU).IncreaseQuantity();
            }
            else
            {
                this.Add(new Product(sKU, 1));
            }
        }
    }
}