using Checkout;
using Checkout.ApiServices.Tokens.RequestModels;
using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace Tests.ShoppingListService
{
    [TestFixture(Category = "ShoppingListApi")]
    public class ShoppingListServiceTests: BaseServiceTests
    {
        [Test]
        public void CreateShoppingItem()
        {
            var shoppingListTokenCreateModel = new ShoppingListTokenCreate { UserName = AppSettings.ShoppingListUserName, Password = AppSettings.ShoppingListPassword };
            var responseToken = CheckoutClient.TokenService.CreateShoppingListToken(shoppingListTokenCreateModel);

            var shoppingItemCreateModel = TestHelper.GetShoppingItemCreateModel();
            var response = CheckoutClient.ShoppingListService.CreateShoppingItem(responseToken.Model, shoppingItemCreateModel);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GetShoppingCart()
        {
            var shoppingListTokenCreateModel = new ShoppingListTokenCreate { UserName = AppSettings.ShoppingListUserName, Password = AppSettings.ShoppingListPassword };
            var responseToken = CheckoutClient.TokenService.CreateShoppingListToken(shoppingListTokenCreateModel);

            var response = CheckoutClient.ShoppingListService.GetShoppingCart(responseToken.Model);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GetShoppingListByProductName()
        {
            var shoppingListTokenCreateModel = new ShoppingListTokenCreate { UserName = AppSettings.ShoppingListUserName, Password = AppSettings.ShoppingListPassword };
            var responseToken = CheckoutClient.TokenService.CreateShoppingListToken(shoppingListTokenCreateModel);
            var shoppingItemCreateModel = TestHelper.GetShoppingItemCreateModel();

            var createResponse = CheckoutClient.ShoppingListService.CreateShoppingItem(responseToken.Model, shoppingItemCreateModel);

            createResponse.Should().NotBeNull();
            createResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = CheckoutClient.ShoppingListService.GetShoppingListByProductName(responseToken.Model, shoppingItemCreateModel.Product.Name);

            getResponse.Should().NotBeNull();
            getResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Model.ShoppingItemId.Should().Be(shoppingItemCreateModel.ShoppingItemId);
            getResponse.Model.Product.Name.Should().Be(shoppingItemCreateModel.Product.Name);
        }

        [Test]
        public void UpdateShoppingItem()
        {
            var shoppingListTokenCreateModel = new ShoppingListTokenCreate { UserName = AppSettings.ShoppingListUserName, Password = AppSettings.ShoppingListPassword };
            var responseToken = CheckoutClient.TokenService.CreateShoppingListToken(shoppingListTokenCreateModel);

            var shoppingItemCreateModel = TestHelper.GetShoppingItemCreateModel();
            var createResponse = CheckoutClient.ShoppingListService.CreateShoppingItem(responseToken.Model, shoppingItemCreateModel);

            createResponse.Should().NotBeNull();
            createResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var shoppingItemUpdateModel = TestHelper.GetShoppingItemUpdateModel();
            var updateResponse = CheckoutClient.ShoppingListService.UpdateShoppingItem(responseToken.Model, shoppingItemUpdateModel);

            updateResponse.Should().NotBeNull();
            updateResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            updateResponse.Model.Product.Quantity.Should().Be(shoppingItemUpdateModel.Product.Quantity);
        }
    }
}
