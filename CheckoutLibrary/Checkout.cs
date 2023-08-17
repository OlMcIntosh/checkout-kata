namespace CheckoutLibrary
{
    public class Checkout
    {
        private Dictionary<string, int> prices = new Dictionary<string, int>();
        private ListOfProducts ProductsInTransaction = new ListOfProducts();
        private ListOfSpecialPrices specialPrices = new ListOfSpecialPrices();

        public Checkout()
        {
        }

        public int GetTotalPrice()
        {
            int total = 0;

            foreach (var item in ProductsInTransaction)
            {               
                if (specialPrices.IsThereASpecialPriceFor(item.SKU))
                {
                    var specialPrice = specialPrices.GetPriceForSKU(item.SKU);
                    if (item.quantity > specialPrice.quantity)
                    {  
                        total += specialPrice.price;
                        total += prices[item.SKU]*(item.quantity - specialPrice.quantity);
                    }
                    else
                    { 
                        total += specialPrice.price; 
                    }
                }
                else
                {
                    total += prices[item.SKU] * item.quantity;
                }
            }

            return total;
        }

        public void Scan(string SKU)
        {
            ProductsInTransaction.Add(SKU);
        }

        public void SetPrice(string SKU, int price)
        {
            prices.Add(SKU, price);
        }

        public void SetSpecialPrice(string SKU, int quantity, int price)
        {
            specialPrices.Add(SKU, quantity, price);
        }
    }
}