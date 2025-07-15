# 🏷️ Product Category Management API

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-69217E?style=for-the-badge&logo=dot-net&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-purple?style=for-the-badge&logo=dot-net&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![Database](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

---

## 🌟 Overview

This is an **ASP.NET Core Web API** designed for managing product categories and their relationships with products. Leveraging **Entity Framework Core**, this API provides a comprehensive suite of RESTful endpoints for performing CRUD (Create, Read, Update, Delete) operations on `ProductCategory` entities, including the ability to manage associated `Product` data.

This API is an ideal backend solution for e-commerce platforms, product catalog systems, or any application requiring robust category and product organization.

---

## ✨ Features

* **RESTful API Endpoints**: Full CRUD support for `ProductCategory` entities.
* **Product Relationship**: Seamlessly manage `Product` data associated with categories (e.g., a category can have multiple products).
* **Eager Loading**: Retrieve category data along with their related products using `Include`.
* **Database Integration**: Utilizes **Entity Framework Core** for efficient data access and persistence with SQL Server (configurable).
* **Swagger/OpenAPI Documentation**: Interactive API documentation for easy testing and understanding of all available endpoints.
* **Environment-Specific Configuration**: Configured to handle different settings for development and production environments.

---

## 🚀 Getting Started

Follow these simple steps to get a copy of this project up and running on your local machine.

### Prerequisites

Ensure you have the following installed:

* [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later.
* A SQL Server instance (LocalDB, Express, or full SQL Server).
* (Optional but Recommended) An API testing tool like [Postman](https://www.postman.com/downloads/) or [Thunder Client](https://marketplace.visualstudio.com/items?itemName=rangav.vscode-thunder-client) (for VS Code).

### Installation & Setup

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/mdshohagkhan/product-category-api.git](https://github.com/mdshohagkhan/product-category-api.git)
    cd product-category-api
    ```
    *(**Important:** Please update the clone URL if your repository URL is different.)*

2.  **Configure Database Connection String:**
    Open the `appsettings.json` file and set up your database connection string under the `ConnectionStrings` section to point to your SQL Server instance.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProductCategoryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      },
      // ... other settings
    }
    ```
    *Adjust `Server` and `Database` names as per your local SQL Server setup.*

3.  **Apply Migrations:**
    Navigate to the project's root directory in your terminal and run the following commands to create or update your database schema based on your models:
    ```bash
    dotnet ef database update
    ```
    *(If you haven't created initial migrations, you might need to run `dotnet ef migrations add InitialCreate` first, then `dotnet ef database update`)*.

4.  **Restore NuGet Packages:**
    Ensure all necessary dependencies are downloaded:
    ```bash
    dotnet restore
    ```

5.  **Run the application:**
    Start the API application:
    ```bash
    dotnet run
    ```
    The API will typically run on `http://localhost:5000` (HTTP) or `http://localhost:5001` (HTTPS).

---

## 🗺️ API Endpoints

Once the application is running, you can access the API at the base URL (e.g., `http://localhost:5000/api/ProductCategorys`).

### Product Categories (`/api/ProductCategorys`)

* **`GET /api/ProductCategorys`**: Get a list of all product categories, including their associated products.
* **`GET /api/ProductCategorys/{id}`**: Get a specific product category by its ID, including its associated products.
* **`POST /api/ProductCategorys`**: Create a new product category.
    * **Request Body Example (JSON):**
        ```json
        {
          "categoryName": "Electronics",
          "description": "Gadgets and electronic devices",
          "products": [
            {
              "productName": "Smartphone",
              "price": 799.99
            },
            {
              "productName": "Smart TV",
              "price": 1200.00
            }
          ]
        }
        ```
* **`PUT /api/ProductCategorys/{id}`**: Update an existing product category and its related products.
    * **Request Body Example (JSON):**
        ```json
        {
          "productCategoryID": 1, // Existing Category ID
          "categoryName": "Home Appliances (Updated)",
          "description": "Updated category for home appliances",
          "products": [
            {
              "productID": 101, // Existing Product ID to update
              "productName": "Refrigerator",
              "price": 950.00
            },
            {
              "productID": 0, // New Product (ProductID should be 0 or omitted for new products)
              "productName": "Dishwasher",
              "price": 600.00
            }
          ]
        }
        ```
* **`DELETE /api/ProductCategorys/{id}`**: Delete a product category by its ID.

### Swagger UI (Interactive API Documentation)

For interactive testing and exploration of the API endpoints (primarily in your **development environment**), visit:
`http://localhost:5000/swagger` (or your specific port, if different)

---

## 🛠️ Project Structure

* `Controllers/ProductCategorysController.cs`: The core API controller managing all product category and product-related operations.
* `Models/ProductCategory.cs`: The Entity Framework model for `ProductCategory`.
* `Models/Product.cs`: The Entity Framework model for `Product` (assuming this model exists and has a `ProductCategoryID`).
* `Models/AppDbContext.cs`: The Entity Framework Core `DbContext` responsible for database interaction.
* `Program.cs`: The application's entry point, handling service configuration, middleware setup, and endpoint mapping.
* `appsettings.json`: Configuration file for database connection strings and other environment-specific settings.

---

## 🤝 Contributing

We welcome contributions to enhance this project! If you have suggestions for improvements, new features, or encounter any issues, please feel free to:

1.  Fork the repository.
2.  Create a new branch for your changes (`git checkout -b feature/AddNewEndpoint` or `bugfix/FixAuthIssue`).
3.  Implement your changes.
4.  Write a clear, concise commit message (`git commit -m 'feat: Implement user authentication'` or `fix: Resolve category deletion bug`).
5.  Push your changes to your new branch (`git push origin feature/AddNewEndpoint`).
6.  Open a Pull Request to the main branch.

---

## 📜 License

This project is open-sourced under the [MIT License](LICENSE).

---