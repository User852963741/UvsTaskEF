## This is a simple C# console app for getting and setting employees using entity framework in PostgreSQL server.  

## Dependencies

Before building or running this project, ensure you have the following dependencies and apps installed and running:

- Microsoft.EntityFrameworkCore.Design (version 6.0.0)
- Npgsql.EntityFrameworkCore.PostgreSQL (version 6.0.0)
- .NET 6.0
- Docker

# These are the steps for running the app:  
1. Open the project "UvsTaskEF"  
2. Run the script setUpDatabase.ps1 in the working directory(...UvsTask\UvsTaskEF) using powershell to set up the PostgreSQL server on Docker container  
3. Test the apps functionality with running verifySubmission.ps1 script or with custom commands.  
