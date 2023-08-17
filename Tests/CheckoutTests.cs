using CheckoutLibrary;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void when_one_item_is_scanned_the_total_price_iquals_price_of_this_item()
        {
            var checkout = new Checkout();
            checkout.SetPrice("A", 50);

            checkout.Scan("A");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(50));
        }
    }
}