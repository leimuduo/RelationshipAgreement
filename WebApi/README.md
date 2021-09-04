# Refactor-this
The attached project is a poorly written products API in C#.

Please evaluate and refactor areas where you think can be improved.

Consider all aspects of good software engineering and show us how you'll make it #beautiful and make it a production ready code.

# Getting started for applicants
## Introduction
This is a web api application built with .net 5.
> Theoretically speaking it should also backward support to run on asp.net core 3.1. 
> Please refer to [here](https://docs.microsoft.com/en-us/dotnet/core/dotnet-five)

### Design
> Auth design is following this article: [Click this magic link~](https://jasonwatmore.com/post/2021/05/25/net-5-simple-api-for-authentication-registration-and-user-management)
> TODO: User context migration steps.

Product is the core entity. 
```json

```

ProductOption is the option of each product
```json

```

API document please refer to below section or swagger document.

## How to build
1. restore packages:
```bash
   dotnet restore
   dotnet build
```
2. data migration and seeding
```bash
    dotnet ef database update
```
> please install relevant ef core tools and package

expect to see bash like below:
```console
➜  ProductApi git:(master) ✗ dotnet ef database update
Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 5.0.7 initialized 'ProductsContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite' with options: None
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (13ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT "MigrationId", "ProductVersion"
      FROM "__EFMigrationsHistory"
      ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20210619014249_dataSeeding'.
Applying migration '20210619014249_dataSeeding'.
info: ....
info: ....
Done.
```

3. run
```bash
    # option 1: CLI
    dotnet run
    
    # option 2: IDEs
    run debug/run mode.
```

4. play with

default browser should open [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html) automatically. 

5. deploy

Docker file has supplied. please modify relevant setup to fit in your container and pipeline.

```
# Docker cmd
# Please make sure you are in the solution folder, not in project folder.
docker build -t relationship-api .
 docker run -it --rm -p 2333:80 --name relationship_api relationship-api
```



## Endpoint instruction

There should be these endpoints:

> Same swagger document should also be seen after start the project at `https://localhost:5001/swagger/index.html`.

1. `GET /products` - gets all products.
2. `GET /products?name={name}` - finds all products matching the specified name.
3. `GET /products/{id}` - gets the project that matches the specified ID - ID is a GUID.
4. `POST /products` - creates a new product.
5. `PUT /products/{id}` - updates a product.
6. `DELETE /products/{id}` - deletes a product and its options.
7. `GET /products/{id}/options` - finds all options for a specified product.
8. `GET /products/{id}/options/{optionId}` - finds the specified product option for the specified product.
9. `POST /products/{id}/options` - adds a new product option to the specified product.
10. `PUT /products/{id}/options/{optionId}` - updates the specified product option.
11. `DELETE /products/{id}/options/{optionId}` - deletes the specified product option.

All models are specified in the `/Models` folder, but should conform to:

**Product:**
```json
{
  "Id": "01234567-89ab-cdef-0123-456789abcdef",
  "Name": "Product name",
  "Description": "Product description",
  "Price": 123.45,
  "DeliveryPrice": 12.34
}
```

**Products:**

```json
{
  "Items": [
    {
      // product
    },
    {
      // product
    }
  ]
}
```

**Product Option:**
```json
{
  "Id": "01234567-89ab-cdef-0123-456789abcdef",
  "Name": "Product name",
  "Description": "Product description"
}
```

**Product Options:**
```json
{
  "Items": [
    {
      // product option
    },
    {
      // product option
    }
  ]
}
```

## Cache

```
## Before cache
HTTP/1.1 GET https://localhost:5001/api/Products/b1d2f89c-a83b-47e6-b840-e61c9ba5d01f - - - 200 - application/json;+charset=utf-8 9114.3023ms 

## Cached
2021-07-04 10:05:13.8454|0|INFO|ProductApi.Services.Implementation.ProductService|Product b1d2f89c-a83b-47e6-b840-e61c9ba5d01f is reading from cache 

HTTP/1.1 GET https://localhost:5001/api/Products/b1d2f89c-a83b-47e6-b840-e61c9ba5d01f - - - 200 - application/json;+charset=utf-8 4.3630ms 


```

