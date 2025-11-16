# StockDamage_Page

## Project
Stock Damage Page Development (ASP.NET Core 8 + MS SQL Server)

This repository contains the Stock Damage web application implemented with:
- Backend: ASP.NET Core 8 (C#), Entity Framework Core (Repository + DTOs)
- Frontend: HTML, Bootstrap, jQuery (the frontend is included in the .NET project)
- Database: Microsoft SQL Server (.bak backups included)
- Additional helper files: SQL scripts and a Jupyter notebook for data insertion

---

## About the Task (summary)
Develop the “Stock Damage” page with the following requirements:
- Godown table (GodownNo, GodownName, AutoSlNo). Insert two manual entries that load in the "Warehouse Name" dropdown.
- SubItemCode table (AutoSlNo, SubItemCode, SubItemName, Unit, Weight, ...). "Item Name" dropdown loads from SubItemCode; when selected, Item Code and Unit auto-populate.
- Stock table provides current stock quantity by SubItemCode and should display in the "Stock" field.
- Batch No defaults to "NA".
- Currency table (CurrencyName, ConversionRate). Selected currency sets the exchange rate automatically.
- User inputs: Quantity, Rate, Amount In.
- Dr A/C Head set by default to "Stock Damage".
- Employee Name dropdown loads from Employee table.
- Comments free text.
- "Add" button adds a temporary row to a Bootstrap table (client-side; not persisted).
- "Save" calls a stored procedure `SP_TableName_Save` to persist all added entries into the Stock Damage table.

---

## Repository structure (important paths)
- /src/ — main .NET 8 project
  - /src/StockDamage — contains database backups (StockDamage14.bak, StockDamage.bak)
  - /src/StockDamageInsert.sql — SQL script for inserting seed data
  - /src/StockDamagescript.ipynb — notebook (optional) for scripted insert operations or analysis

Adjust paths below if you cloned into a different directory.

---

## Prerequisites
- .NET 8 SDK installed (dotnet --version should be 8.x)
- SQL Server instance (local or remote). SQL Server 2016+ recommended.
- Optional: SQL Server Management Studio (SSMS) or sqlcmd for applying backups/scripts.
- (Optional for EF migrations) dotnet-ef global tool:
  - Install: dotnet tool install --global dotnet-ef
- Git to clone the repository

---

## Quick start — clone, build, configure, run

1. Clone repository
   - git clone https://github.com/Deboraj-roy/StockDamage_Page.git
   - cd StockDamage_Page/src

2. Restore & build
   - dotnet restore
   - dotnet build --configuration Release

3. Configure connection string
   - Copy `appsettings.Development.json` or `appsettings.json.example` to `appsettings.json` (if present)
   - Update the ConnectionStrings:DefaultConnection (SQL Server) to point to your instance. Example:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=StockDamage;Trusted_Connection=True;TrustServerCertificate=True;"
       }
     }
     ```
   - If using SQL Authentication:
     "Server=serverName;Database=StockDamage;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"

4. Run the application (development)
   - dotnet run --project ./YourProjectName.csproj
   - or open in Visual Studio and press F5

The web app will be available on the configured port (usually https://localhost:5001 or as shown in console).

---

## Database setup

You have two options:
A. Restore from provided .bak files (recommended if you want exact production-like data).
B. Use EF Core migrations & seed scripts to create schema and seed basic data.

### A — Restore from .bak files (files included)
Files:
- src/StockDamage/StockDamage14.bak  (2014)
- src/StockDamage/StockDamage.bak    (2019)

Example T-SQL restore commands (run in SSMS or sqlcmd). You must adapt the logical file names and target paths for your SQL Server instance.

1. Inspect the backup to get logical names:
   - RESTORE FILELISTONLY FROM DISK = 'C:\path\to\StockDamage.bak';

2. Restore (example; update physical file paths for your environment):
   ```sql
   RESTORE DATABASE [StockDamage]
   FROM DISK = N'C:\path\to\StockDamage.bak'
   WITH MOVE 'StockDamage_Data' TO 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StockDamage.mdf',
        MOVE 'StockDamage_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StockDamage_log.ldf',
        REPLACE;
   ```

3. If you prefer a different filename/database name, adjust the database name and MOVE targets.

sqlcmd example:
```bash
sqlcmd -S localhost\SQLEXPRESS -U sa -P YourPassword -i "C:\path\to\restore_script.sql"
```

Note: If you restore into the same DB name your app uses in the connection string (DefaultConnection), you can run the app immediately after restoring.

---

### B — Use EF Core Migrations (create schema from code)
If you prefer to create the schema from app models using EF Core:

1. Ensure `appsettings.json` has the correct connection string.
2. Create initial migration (from the `src` project folder):
   - dotnet ef migrations add InitialCreate --project ./YourProject.csproj --startup-project ./YourProject.csproj -o Data/Migrations
3. Apply migrations:
   - dotnet ef database update --project ./YourProject.csproj --startup-project ./YourProject.csproj

Note: Replace `YourProject.csproj` with the actual project file name if different.

---

## Seed data & Insert operation

1. Seed SQL script:
   - File: src/StockDamageInsert.sql
   - This script contains insert statements to populate tables like Godown, SubItemCode, Currency, Employee etc.
   - To run via sqlcmd:
     ```bash
     sqlcmd -S localhost\SQLEXPRESS -U sa -P YourPassword -i "C:\path\to\StockDamage_Page\src\StockDamageInsert.sql"
     ```
   - Or open the script in SSMS and execute.

2. Jupyter Notebook:
   - File: src/StockDamagescript.ipynb
   - This notebook includes programmatic inserts and analysis; it can be executed locally with Jupyter (uses SQL connections).
   - Open with Jupyter Notebook / Jupyter Lab and run the cells after configuring the DB connection in the notebook.

3. Manual inserts for Godown (example)
   - The requirement expects two manual entries in Godown:
   ```sql
   INSERT INTO Godown (GodownNo, GodownName, AutoSlNo)
   VALUES ('G001', 'Main Warehouse', 1), ('G002', 'Secondary Warehouse', 2);
   ```

4. Stored procedure for saving Stock Damage entries
   - The app expects a stored procedure in the database named `SP_TableName_Save` that persists the temporary entries into the `StockDamage` table.
   - You should create that stored procedure in the DB. Example skeleton:
     ```sql
     CREATE PROCEDURE SP_StockDamage_Save
       @JsonData NVARCHAR(MAX)  -- or other parameters
     AS
     BEGIN
       SET NOCOUNT ON;
       -- parse JSON and insert into StockDamage table
     END
     ```
   - If the project already contains the stored procedure in the backups, restoring the .bak will add it.

---

## How the Insert (UI) flow works
1. On the Stock Damage page:
   - Select Warehouse (Godown) from dropdown (populated from Godown table).
   - Select Item Name (SubItemCode.SubItemName). Item Code & Unit auto-populate.
   - Stock field displays current stock (from Stock table) for selected SubItemCode.
   - Batch No defaults to "NA".
   - Select Currency — exchange rate auto-populates (from Currency table).
   - Enter Quantity, Rate, Amount In, Comments.
   - Click "Add" — the row is added to a client-side temporary Bootstrap table (not saved yet).
   - You can add multiple rows.
   - Click "Save" — front-end sends the collection to the backend which calls stored proc `SP_TableName_Save` to persist all entries.

2. Validation & concurrency:
   - Client-side validation is performed before adding rows.
   - Server-side will revalidate and persist via stored procedure.

---

## Run tests / verify DB operations
- Use SSMS to query tables:
  - SELECT * FROM Godown;
  - SELECT * FROM SubItemCode;
  - SELECT * FROM Stock;
  - SELECT * FROM Currency;
  - SELECT * FROM Employee;
- Verify StockDamage table after running Save.

---

## Docker (optional)
A minimal image build + run:
1. Create a Dockerfile in the project (if not present).
2. Example build & run:
   ```bash
   docker build -t stockdamage:latest .
   docker run -d -p 5000:80 --name stockdamage --env "ConnectionStrings__DefaultConnection=Server=host.docker.internal;Database=StockDamage;User Id=sa;Password=YourPassword;" stockdamage:latest
   ```
Note: For local SQL Server use host.docker.internal and ensure SQL Server accepts remote connections. Use a lightweight Linux base (mcr.microsoft.com/dotnet/aspnet:8.0).

---

## Troubleshooting & tips
- Connection errors:
  - Ensure SQL Server is running and accepts the provided authentication method.
  - Use TrustServerCertificate=True if using self-signed certs on dev.
- Migration errors:
  - If EF complains about existing objects, either update the migrations or restore a fresh DB.
- Backups fail to restore:
  - Check file paths, permissions, and that logical file names match the RESTORE FILELISTONLY output.
- Missing stored procedure:
  - If SP_TableName_Save is missing, create it or re-run the provided seed script / restore .bak.

---

## Notes & next steps
- This project targets .NET 8 and uses async/await throughout backend operations — ensure all DB access uses async EF methods (e.g., ToListAsync, FirstOrDefaultAsync).
- For production, secure connection strings via user secrets, environment variables, or a secret store.
- Consider adding:
  - Unit tests for repository & service layers,
  - Integration tests for EF Core,
  - Validation & anti-forgery protections for the UI.

---

If you want, I can:
- Generate a sample `appsettings.json` with placeholders,
- Create EF Core seed code for Godown/SubItemCode/Currency/Employee,
- Provide the stored procedure SQL `SP_TableName_Save` example that accepts JSON and inserts rows in a single transaction.
 