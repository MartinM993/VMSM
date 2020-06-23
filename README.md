# VMSM - Blazor WebAssembly application

The main purpose of this application is to allow managing staff that works with vending machines. That mean creating schedules (which worker on which day will visit proper vending machine), financial reports for incomes and defects abot vending machines etd

# Used technologies:
  - .NET Core 3.1
  - .NET Core Identity
  - Blazor WebAssembly
  - Radzen Blazor Components for UI 

# There are 4 types of roles:
  - Super admin 
    - managing with users (workers), vending machines, addresses and vehicles
  - Office worker
    - managing with products, product prices, incomes and defects
    - creating and managing schedules for field workers
    - generating reports about vending machines
  - Field worker 
    - visits the vending machines
    - adds the products in vending machines
    - collect the income from
  - Storage worker (responsible for the storage)
    - imports the products in storage from suppliers
    - export the products from storage to the field workers
  
# Start the app:
  - Download zip or clone the project
  - Make sure to have Visual Studio 2019 (or VS Code) and SQL Server installed
  - Migrations are created and data seeder (one user, one address and needed roles) is added, just execute Update-Database in Package Manager Console for VMSM.Data project
