namespace CheckoutLibrary
{
    public class Checkout
    {
        private Dictionary<string, int> prices = new Dictionary<string, int>();
        private Dictionary<string, int> products = new Dictionary<string, int>();
        private List<SpecialPrice> specialPrices = new List<SpecialPrice>();

        public Checkout()
        {
        }

        public int GetTotalPrice()
        {
            int total = 0;

            foreach (var item in products)
            {
                var specialPrice = specialPrices.FirstOrDefault(x => x.sku == item.Key);
                if (specialPrice != null)
                {
                    total += specialPrice.price;
                }
                else
                {
                    total += prices[item.Key] * item.Value;
                }
            }

            return total;
        }

        public void Scan(string SKU)
        {
            if (products.ContainsKey(SKU))
            {
                products[SKU]++;
            }
            else
            {
                products.Add(SKU, 1);
            }
        }

        public void SetPrice(string SKU, int price)
        {
            prices.Add(SKU, price);
        }

        public void SetSpecialPrice(string SKU, int quantity, int price)
        {
            specialPrices.Add(new SpecialPrice(SKU, quantity, price));
        }
    }
}