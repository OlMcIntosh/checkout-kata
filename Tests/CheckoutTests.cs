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

        [Test]
        public void when_two_different_items_scanned_the_total_price_is_the_sum_of_their_prices()
        {
            var checkout = new Checkout();
            checkout.SetPrice("A", 50);
            checkout.SetPrice("B", 30);

            checkout.Scan("A");
            checkout.Scan("B");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(80));
        }

        [Test]
        public void when_special_price_is_set_for_two_items_and_two_items_scanned_the_total_is_special_price()
        {
            var checkout = new Checkout();
            checkout.SetPrice("B", 30);
            checkout.SetSpecialPrice("B", 2, 45);

            checkout.Scan("B");
            checkout.Scan("B");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(45));
        }

        [Test]
        public void when_special_price_is_set_for_two_items_and_three_items_scanned_the_total_is_special_price_plus_single_item_price()
        {
            var checkout = new Checkout();
            checkout.SetPrice("B", 30);
            checkout.SetSpecialPrice("B", 2, 45);

            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(75));
        }
    }
}