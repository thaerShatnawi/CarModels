## How to run the app
Car Model Service
The Car Model Service is a REST API service that allows users to retrieve car models for a specific car make and manufacture year.

Installation
To install and run the Car Model Service, follow these steps:

1-Clone this repository to your local machine.
2-Open the solution file (CarManufacture.sln) in Visual Studio.
3-Build the solution to restore dependencies.
4-Run the project (CarManufacture) in Visual Studio.


Usage

Retrieving Car Models

To retrieve car models for a specific car make and manufacture year, send a GET request to the following endpoint:

bash
Copy code
http://localhost:7082/api/models?make=<make>&modelyear=<year>
Replace <year> with the manufacture year of the car and <make> with the car make.

Example Request
GET https://localhost:7082/api/models?make=Lincoln&modelyear=2015

Example Response
{
    {"models":["MKZ","MKS","MKT","MKT","MKX","Navigator","MKC"]}
}

Dependencies
ASP.NET Core
Newtonsoft.Json

License
This project is licensed under the MIT License - see the LICENSE file for details.