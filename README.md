# Airport Management System

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](./AirportManagement/LICENSE.txt)

## Description

This project is an airport management system developed using ASP.NET. It allows managing flights,
passengers, staff, and reservations. 
The project is designed to provide a comprehensive management solution for small to medium-sized airports.

This project is also an academic project aimed at learning and applying ASP.NET concepts in a practical context.

![image](https://github.com/Hana-Romdhani/AirportManagements/assets/123480733/0d3ca510-f6fe-4d87-ad06-cf92c79b7c71)


## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)
- [Contact](#contact)

## Features

- Flight management (add, modify, delete)
- Passenger management (registration, flight information)
- Staff management (scheduling, information)

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Bootstrap for the user interface

## Prerequisites

Before you begin, ensure you have the following installed:

- [Visual Studio 2019+](https://visualstudio.microsoft.com/)
- [.NET Core SDK 7.0](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/Hana-Romdhani/AirportManagements.git
    cd airport-management-system
    ```

2. Configure the database:

    - Open the `AMContext.cs` file and update the database connection URL.
    - Apply the migrations to create the database:

    ```bash
    Add-Migration
    Update-Database
    ```

3. Set the `AM.UI.WEB` project as the startup project.
4. Launch the application.
5. Open your browser and go to `https://localhost:7282/` to see the application in action.

## Usage

After starting the application, you can:

- Add new flights and manage schedules.
- Register passengers and assign flights.

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Contact

Email: hanaromdhani2018@gmail.com  
LinkedIn: [linkedin.com/in/romdhani-hana](https://www.linkedin.com/in/romdhani-hana)

Project link: [https://github.com/Hana-Romdhani/AirportManagements](https://github.com/Hana-Romdhani/AirportManagements)
