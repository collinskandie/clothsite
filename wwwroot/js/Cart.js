// wwwroot/js/cart.js

document.addEventListener('DOMContentLoaded', function () {
    // Function to update the cart item count in the navbar
    function updateCartItemCount() {
        // Retrieve existing cart items from local storage
        var cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];

        // Get the cart item count
        var itemCount = cartItems.length;

        // Update the cart item count in the navbar
        document.getElementById('cartItemCount').textContent = itemCount;
    }

    // Function to render cart items in a table
    function renderCartItems() {
        // Retrieve existing cart items from local storage
        var cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];

        // Get the cart items container using the class name
        var cartItemsContainer = document.querySelector('.cartItemsContainer');

        // Clear previous content
        cartItemsContainer.innerHTML = '';

        // Create a table
        var table = document.createElement('table');
        table.classList.add('table');

        // Create table header
        var headerRow = table.insertRow();
        headerRow.innerHTML = '<th>Name</th><th>Description</th><th>Price</th><th>Quantity</th><th>Actions</th>';

        // Render each cart item as a table row
        cartItems.forEach(function (item) {
            var row = table.insertRow();

            // Create table cells
            var nameCell = row.insertCell(0);
            var descriptionCell = row.insertCell(1);
            var priceCell = row.insertCell(2);
            var quantityCell = row.insertCell(3);
            var actionsCell = row.insertCell(4);

            // Set cell content
            nameCell.innerHTML = item.name;
            descriptionCell.innerHTML = item.description;
            priceCell.innerHTML = '$' + item.price;
            quantityCell.innerHTML = item.quantity;

            // Add a "Remove" button
            var removeButton = document.createElement('button');
            removeButton.textContent = 'Remove';
            removeButton.classList.add('btn', 'btn-danger', 'btn-sm');
            removeButton.addEventListener('click', function () {
                removeFromCart(item);
            });
            actionsCell.appendChild(removeButton);
        });

        // Add a row for the cart total
        var totalRow = table.insertRow();
        totalRow.innerHTML = `<td colspan="3"></td><td>Total:</td><td>$${calculateTotal(cartItems)}</td>`;

        // Append the table to the container
        cartItemsContainer.appendChild(table);

        // Add a button for redirection to checkout
        var checkoutButton = document.createElement('button');
        checkoutButton.textContent = 'Proceed to Checkout';
        checkoutButton.classList.add('btn', 'btn-primary', 'mt-3');
        checkoutButton.addEventListener('click', function () {
            window.location.href = '/Checkout'; // Replace with the actual URL of your checkout page
        });
        cartItemsContainer.appendChild(checkoutButton);
    }

    // Function to calculate the total value of the cart
    function calculateTotal(cartItems) {
        return cartItems.reduce(function (total, item) {
            return total + item.price * item.quantity;
        }, 0);
    }

    // Function to remove an item from the cart
    function removeFromCart(itemToRemove) {
        var cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];

        // Filter out the item to remove
        var updatedCart = cartItems.filter(function (item) {
            return item.id !== itemToRemove.id;
        });

        // Update local storage
        localStorage.setItem('cartItems', JSON.stringify(updatedCart));

        // Re-render the cart items
        renderCartItems();
    }

    // Call the updateCartItemCount and renderCartItems functions when the page loads
    updateCartItemCount();
    renderCartItems();
});
