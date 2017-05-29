using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using Checkout.ApiServices.Tokens.ResponseModels;

namespace Checkout.ApiServices.ShoppingList
{
    public class ShoppingListService
    {
        public HttpResponse<ShoppingCart> GetShoppingCart(ShoppingListTokenResponse shoppingListToken)
        {
            return new ApiHttpClient().GetRequest<ShoppingCart>(ApiUrls.ShoppingListGet, shoppingListToken.Access_token);
        }

        public HttpResponse<ShoppingItem> GetShoppingListByProductName(ShoppingListTokenResponse shoppingListToken, string productName)
        {   
            var getByProductNameUri = string.Format(ApiUrls.ShoppingListGetByProductName, productName);
            return new ApiHttpClient().GetRequest<ShoppingItem>(getByProductNameUri, shoppingListToken.Access_token);
        }

        public HttpResponse<ShoppingItem> UpdateShoppingItem(ShoppingListTokenResponse shoppingListToken, ShoppingItem requestModel)
        {
            return new ApiHttpClient().PutRequest<ShoppingItem>(ApiUrls.UpdateShoppingItem, shoppingListToken.Access_token, requestModel);
        }

        public HttpResponse<OkResponse> DeleteShoppingItem(ShoppingListTokenResponse shoppingListToken,string shoppingItemId)
        {
            var deleteShoppingItemUri = string.Format(ApiUrls.DeleteShoppingItem, shoppingItemId);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteShoppingItemUri, shoppingListToken.Access_token);
        }

        public HttpResponse<OkResponse> CreateShoppingItem(ShoppingListTokenResponse shoppingListToken, ShoppingItem requestModel)
        {
            return new ApiHttpClient().PostRequest<OkResponse>(ApiUrls.CreateShoppingItem, shoppingListToken.Access_token, requestModel);
        }
    }
}
