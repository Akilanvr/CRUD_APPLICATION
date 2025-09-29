Steps to Run the Project
------------------------

1. Database Setup
   - Open SQL Server Management Studio (SSMS).
   - Run the script in database.sql file.
     This will:
       * Create database: SampleDB
       * Create Employees table
       * Create stored procedures:
         - spAddEmployee
         - spGetAllEmployees
         - spGetEmployeeById
         - spUpdateEmployee
         - spDeleteEmployee

2. Configure Connection
   - Open appsettings.json.
   - Update the connection string to match your SQL Server.
     Example:
       "Server=localhost;Database=SampleDB;Trusted_Connection=True;"

   If using SQL authentication:
       "Server=localhost;Database=SampleDB;User Id=your_username;Password=your_password;"

3. Run the API
   - Open terminal in the project folder.
   - Run:
       dotnet restore
       dotnet run
   - The API will start on:
       https://localhost:5001
       http://localhost:5000

4. Test the Endpoints
   - Open Swagger at https://localhost:5001/swagger
   - Available APIs:
       GET    /api/employee          -> Get all employees
       GET    /api/employee/{id}     -> Get employee by ID
       POST   /api/employee          -> Create employee
       PUT    /api/employee/{id}     -> Update employee
       DELETE /api/employee/{id}     -> Delete employee

   