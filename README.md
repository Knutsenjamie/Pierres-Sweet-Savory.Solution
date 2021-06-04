# _Pierre's Sweet & Savory Treats_

### _C# Database Many to Many Relationships Using Identity & Authentication_

##### By:
#####  _**Jamie Knutsen**_ _©2021_


## Technologies Used

* _Visual Studio Code_
* _.NET_
* _C#_
* _Entity Framework Core (EF Core)_
* _ASP.NET Core MVC_
* _MySQL_
* _Identity_


## Description: 
This project was designed to practice building basic web applications with C# using entity to build mysql databases, Identity for authentication, many to many relationships, and the MVC model.


## Setup/Installation Requirements
_You can view this webpage by checking out the url:_
https://github.com/Knutsenjamie/Pierres-Sweet-Savory.Solution

### Prerequisites
* [C# & .NET] Install at (https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.100-macos-x64-installer) (If Mac) OR https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer (If Windows)
* [dotnet script] After installing C# and .NET, run the command 'dotnet tool install -g dotnet-script' in your computer's terminal or text editors terminal. 
* A text editor such as [VS Code] (https://code.visualstudio.com/)
* For the database, you'll need to install MySQL (https://dev.mysql.com/downloads/file/?id=484914). I also suggest using MySQL workbench as a GUI for viewing databases to check that they're up to date. 

### Installation
1. Open terminal
2. Input these commands into terminal's command line `cd desktop`
3. Clone https://github.com/Knutsenjamie/Pierres-Sweet-Savory.Solution from github
4. Run the command `code .` in your computer's terminal
5. Open VS Code or other preffered text editor terminal within the project file
6. To install and make sure all needed packages are up-to-date, navigate into the SweetSavory folder from root directory by entering `cd SweetSavory` in terminal.
    * Type the command `dotnet restore` to update and restore all needed packages and dependencies to run application.
7. In order to use the database you must make an appsettings.json file. Run the command `touch appsettings.json` in the `SweetSavory` directory of the project. 
    * Then, enter in your own approppriate username (or enter 'root' in the YOUR-USERNAME-HERE field), and whichever password you used to open, use, and create the imported database in MySQL Workbench- use it and enter it as follows in this line 'database=pierres_treats;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE]' *do NOT actually put []- this is just for visual purposes to see where to change the information*
    * Finally, copy it like in this example, 
    `{
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=pierres_treats;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
    }`
    and paste it into the appsettings.json to use the database. *WARNING: This file should automatically be ignored AS LONG AS it is in the SweetSavory directory and NOT the root directory (as it is listed in the .gitignore). However, Be aware of what you are committing and pushing to avoid pushing your personal username and password- as it is sensitive data* Your database should now be connected. 
8. To create and run the database, navigate back to the root directory `cd PierresSweetnSavory.Solution` and enter the command `dotnet tool install --global dotnet-ef` in the terminal to enable EF Core migrations.
    * Then, if you plan on changing the controller files at all or the models and do make changes, be sure to navigate back into the project folder `cd SweetSavory`, and run the command `dotnet ef migrations add [NAME OF YOUR MIGRATION]` to add an updated migration so that the database updates correctly. Naming conventions for migrations work like a git commit- so be sure to be verbose. 
    * After you add migrations, or if you don't add any at all and just want to use the projects exsisting migrations, navigate into the `SweetSavory` directory again if not there already, and run the command `dotnet ef database update`. You should now be able to open MySQL workbench and see a database named `pierres_treats` that includes all of the projects correct tables and be able to use the database.  
10. Finally, navigate into root directory folder in terminal `cd PierresSweetnSavory.Solution` and  enter command `dotnet run` or `dotnet watch run` to run the program. 

## Licensing

Licensed under the [MIT License](license).

## Contact Information

_Jamie Knutsen (knutsenjamie@yahoo.com)_
