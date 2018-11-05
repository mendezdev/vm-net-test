# NET Test

This is a simple Net test, maded in Visual Stuido 2013, framework 4.5.2, Entity Framework 6.2.0.

## Restore packages
To restore the packages just build the solution.

## Initial DB Setup
The Web.config file in the Api project has the connectionString to connect with the database (localdb by default). Change the values if you need and remember to chage the Api.config file in the DataAccess project too.

There is a seed data who runs when you update the database by the initial migration.
To do this, you need to:
1) Open Visual Studio 2013
2) Open the VistualMindTest.sln
3) Open the Package Manager Console, to do this you need to go to the toolbar and find Tools > NuGet Package Manager > Package Manager Console.
4) Make sure that in the "Default project" is "DataAccess" value selected and run: ```$ Update-Database ``` 

When this is finished, you will have the database (whatever you named in the Web.config file) and the User table.
