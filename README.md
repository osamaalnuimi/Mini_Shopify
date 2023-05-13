# Mini Shopify

Mini Shopify is a web application that allows users to create an online store, manage products, handle customer orders, and process payments. It provides essential e-commerce functionalities in a simplified manner.

## Features

- User Registration and Authentication
- Product Catalog
- Shopping Cart
- Checkout and Order Management
- Payment Integration
- User Reviews and Ratings
- Admin Dashboard

## Technologies Used

- Front-end: Angular
- Back-end: ASP.NET Core
- Database: PostgreSQL
- Payment Integration: Stripe
- Other Libraries/Tools: Entity Framework Core, Angular Router, Angular Material, JWT Authentication

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/osamaalnuimi/mini-shopify.git
   ```

2. Navigate to the project directory:

   ```bash
   cd mini-shopify
   ```

3. Set up the database:

   - Install PostgreSQL and create a new database.
   - Update the connection string in the `appsettings.json` file with your PostgreSQL database details.

4. Build and run the backend server:

   - Navigate to the `backend` directory:
     ```bash
     cd backend
     ```
   - Restore the backend dependencies:
     ```bash
     dotnet restore
     ```
   - Build and run the application:
     ```bash
     dotnet run
     ```

5. Install frontend dependencies:

   - Navigate to the `frontend` directory:
     ```bash
     cd frontend
     ```
   - Install the dependencies:
     ```bash
     npm install
     ```

6. Start the frontend development server:

   ```bash
   ng serve
   ```

7. Access the application at `http://localhost:4200` in your browser.

## Usage

- Create a user account or log in if you already have one.
- Explore the product catalog, search for products, and view their details.
- Add products to your shopping cart, update quantities, and proceed to checkout.
- Provide shipping and billing information during checkout.
- Complete the payment process using Stripe integration.
- Receive an order confirmation with a unique order number.
- Administrators can access the admin dashboard to manage products, orders, and user accounts.

## Contributing

Contributions are welcome! If you have any ideas, bug fixes, or feature enhancements, please submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For any questions or inquiries, please contact [your-email@example.com](mailto:osamaalnuimi@gmail.com).
```
