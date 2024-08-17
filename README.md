# Generic-Repository-Crud

## Overview

**Generic-Repository-Crud** is a repository offering a reusable and generic approach to CRUD (Create, Read, Update, Delete) operations in .NET applications using Entity Framework Core. This project provides a flexible and efficient way to handle data access through a generic repository pattern, making it easy to manage different types of entities with minimal code duplication.

## Features

- **Generic CRUD Operations:** Supports basic CRUD operations for any entity type.
- **Entity Framework Core Integration:** Leverages EF Core for data access and manipulation.
- **Scalability:** Easily extendable for specific entity needs.
- **Dependency Injection:** Configured for seamless integration with .NET dependency injection.
- **Font Awesome:** Includes guidance on how to use the Font Awesome library for icons.
- **SweetAlert2:** Demonstrates how to use SweetAlert2 for enhanced alert dialogs.
- **Toaster:** Provides instructions on using Toaster to display notifications.

## Contact

For any questions, feedback, or contributions, feel free to connect with me:

- **GitHub:** [rst9454](https://github.com/rst9454/)
- **Facebook:** [sunilpandey9454](https://facebook.com/sunilpandey9454)
- **LinkedIn:** [sunilpandey9454](https://linkedin.com/in/sunilpandey9454)
- **Website:** [biharideveloper.com](https://biharideveloper.com)
- **Instagram:** [sunilpandey9454](https://instagram.com/sunilpandey9454)

## Getting Started

### Prerequisites

- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (version 6.0)

### Installation

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/rst9454/Generic-Repository-Crud.git

2. **Change the connection string:**
      "ConnectionStrings": {
  "DefaultConnection": "Data Source=DESKTOP-C91IL1H\\SQLEXPRESS;Initial Catalog=UsingGenericRepositoryDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
}, **Only Data Source Like DESKTOP-C91IL1H\\SQLEXPRESS(Your)**
    There is no need to create a database. When you perform migration, the database will be created automatically and the tables in the database will also be updated with the help of the update-database command.
   After that, you will run the application and enjoy a smooth **CRUD (CREATE, READ, UPDATE & DELETE)** operation with toaster notification messages and sweet alert popups.
