## ✨ ParteWeb

An `ASP Core App` to manage the shopping items. Allows users to configure the shopping items and to create their own carts by adding items to a cart and:

- allow you to name the shopping list
- allow insertion, modification and removal of list elements with checkbox and Description
- the maintenance of persistent data is not required (e.g. on files / databases) for which al
end of session the list may be lost


# Getting Started

1.	Technology Stack
2.  Initial Setup
3.	Development

### 1. Technology Stack

1.	.NET Core 6 Razor 
2.  EF Core 6
3.	Bootstrap 5
4.  MSSQL



### 2. Initial setup

1. Update connection strings 

    appsettings.Development.json
    ```shell
    "DefaultConnection": "Data Source=.;Database=ShoppingCart;User ID=bm;Password=bm;TrustServerCertificate=true"
    ```
2. Run Migrations
```shell
update-database
```

### 3. Development

#####  Migration
Add a migration


Package Manager Console
```shell
add-migration "name_of_migration"
```
Apply a migration
```shell
update-database
```




