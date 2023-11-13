using System.Collections.Generic;
using clothStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace clothStore.Pages
{
    public class CartModel : PageModel
    {
        public List<Cart> CartItems { get; set; } = new List<Cart>();
        public decimal TotalValue { get; set; }

        public void OnGet()
        {
            // Retrieve cart items from local storage
           // var cartItemsJson = HttpContext.Session.GetString("cartItems");
           // if (!string.IsNullOrEmpty(cartItemsJson))
           // {
               // CartItems = JsonConvert.DeserializeObject<List<Cart>>(cartItemsJson);

                // Calculate total value based on server-side properties
                //foreach (var item in CartItems)
               // {
               //     TotalValue += item.Quantity * item.Cloth.Price;
               // }
            //}
        }
    }

   
}
