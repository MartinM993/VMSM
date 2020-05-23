# VMSM is a web application that should allow easy managing of vending machines. 

# Used technologies:
  - .NET Core 3.1
  - .NET Core Identity
  - Blazor
  - Radzen Blazor Components for UI 

# There are 4 types of roles:
  - Super admin - adding new users (workers), generating reports
  - Office worker - is responsible for making schedules for Field workers and financials (incomes, generating reports, invoices etd)
  - Field worker - visits the vending machines, adds the products in it, collect the income from it etd
  - Storage worker - is responsible for the storage, imports the products in storage from suppliers and export them to the field workers
  
# Start the app:
  - Download zip or clone the project
  - Make sure to have Visual Studio 2019 (or VS Code) and SQL Server installed
  - Migrations are created and data seeder (one user, one address and needed roles) is added, just execute Update-Database in Package Manager Console for VMSM.Data project
