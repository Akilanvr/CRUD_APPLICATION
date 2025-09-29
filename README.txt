SimpleCrudApi_Services - Setup steps

1) Create Database
   - Open SSMS and run 'database.sql' included in the project root.
     This creates SampleDB, Employees table, and required stored procedures.

2) Update connection string
   - Edit appsettings.json -> ConnectionStrings:DefaultConnection to match your SQL Server.

3) Restore & run
   - dotnet restore
   - dotnet run
   - The API runs at https://localhost:5001 and http://localhost:5000
   - Swagger UI (if in Development) at https://localhost:5001/swagger

4) Endpoints
   GET    /api/employee
   GET    /api/employee/{id}
   POST   /api/employee
   PUT    /api/employee/{id}
   DELETE /api/employee/{id}

Example POST body (JSON):
{
  "name": "John",
  "position": "Dev",
  "salary": 50000
}
