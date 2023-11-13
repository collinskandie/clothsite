using System;
using System.Collections.Generic;
using System.Linq; // Add this namespace for LINQ
using clothStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clothStore.Pages
{
    public class CheckoutModel : PageModel
    {
        // Assume CartItems is a list of items in the cart
        public List<CartItem>? CartItems { get; set; }

        // Assume Total is the total cost of items in the cart
        public decimal Total { get; set; }

        public void OnGet()
        {
            // Retrieve cart items and calculate total
            CartItems = GetCartItems();
            Total = CalculateTotal();
        }

        private List<CartItem> GetCartItems()
        {
            // Retrieve cart items from local storage
           var cartItems = new List<CartItem>();

            return cartItems;
        }

        private decimal CalculateTotal()
        {
            // Calculate the total cost of items in the cart
            return CartItems?.Sum(item => item.Price * item.Quantity) ?? 0;
        }

        public IActionResult OnPost()
        {
            // Implement logic to handle the submission of PayPal details and save the order
            // This method should save the order to the "Orders" table
            // Example: SaveOrder();

            // Redirect to the home page after submitting the order
            return RedirectToPage("/Index");
        }

        // Additional methods for handling PayPal details and saving the order go here

        // Function to retrieve cart items from local storage
        
    }
}
