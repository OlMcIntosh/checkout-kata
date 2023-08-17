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
        public void when_one_item_is_scanned_the_total_price_equals_price_of_this_item()
        {
            var checkout = new Checkout();
            checkout.SetPrice("A", 50);

            checkout.Scan("A");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(50));
        }

        [Test]
        public void when_two_of_the_same_item_is_scanned_and_no_special_prices_the_total_price_is_twice_the_price_of_item()
        {
            var checkout = new Checkout();
            checkout.SetPrice("A", 50);

            checkout.Scan("A");
            checkout.Scan("A");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(100));
        }
    }
}