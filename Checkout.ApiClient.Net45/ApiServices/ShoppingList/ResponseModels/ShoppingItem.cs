using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.ShoppingList.ResponseModels
{
    public class ShoppingItem
    {
        public int ShoppingItemId { get; set; }
        public Product Product { get; set; }
    }
}
