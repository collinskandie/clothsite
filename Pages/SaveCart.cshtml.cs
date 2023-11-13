using clothStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace clothStore.Pages
{
    public class SaveCartModel : PageModel
    {
        public IActionResult OnPost()
        {
            // Retrieve the cart items from the request
            var cartItemsJson = Request.Form["cartItems"];

            // Deserialize the JSON string into a list of CartItem objects
            var cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cartItemsJson);

            // Process and save the cartItems to the database
            SaveCartToDatabase(cartItems);

            // Redirect back to the checkout page or another appropriate page
            return RedirectToPage("/Checkout");
        }

        // Example method to save cart items to the database
        private void SaveCartToDatabase(List<CartItem> cartItems)
        {
            using (var context = new AppDbContext())
            {
                // Add cartItems to the database context
                context.CartItems.AddRange(cartItems);

                // Save changes to the database
                context.SaveChanges();
            }
        }
    }


}
