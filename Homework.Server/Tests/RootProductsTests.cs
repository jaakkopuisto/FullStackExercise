using Xunit;

namespace Homework.Server.Tests
{

    public class RootProductsTests
    {
        [Theory]
        [InlineData(3, "Iphone X", "New flagship from Apple", 1200)]
        [InlineData(1, "Samsung Y", "New flagship from Samsung", 1000)]
        public void TestRequiredProperties_Product(int id, string title, string desc, int price)
        {
            Product newProduct = new Product(id, title, desc, price);

            Assert.Equal(id, newProduct.Id);

            Assert.Equal(title, newProduct.Title);

            Assert.Equal(desc, newProduct.Description);

            Assert.Equal(price, newProduct.Price);
        }

        [Fact]
        public void ShouldBeNull_ProductsList()
        {
            var rootProducts = new RootProducts();

            Assert.Throws<NullReferenceException>(() => rootProducts.Products[0]);
        }

        [Fact]
        public void ShouldNotBeNull_ProductsList()
        {
            var rootProducts = new RootProducts(new List<Product>());

            rootProducts.Products.Add(new Product());

            Assert.NotNull(rootProducts.Products);
        }
    }

}
