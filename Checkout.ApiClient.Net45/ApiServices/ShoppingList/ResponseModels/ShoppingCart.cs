using System.Collections.Generic;

namespace Checkout.ApiServices.ShoppingList.ResponseModels
{
    public class ShoppingCart
    {
        public IEnumerable<ShoppingItem> ShoppingItems { get; set; }
    }
}
