# SpaceX Launch API
This is a .NET 7 Web API that allows users to retrieve information about past and upcoming launches by SpaceX. The API integrates with the SpaceX API to fetch data and provides endpoints for accessing launch details.

## Prerequisites
Before running the API, ensure the following prerequisites are met:

* [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0): Install the .NET 7 SDK on your machine.

## Local Installation
To run the API locally, follow these steps:

Clone the repository:
```shell
git clone https://github.com/thisIsRasel/spacex-launch-viewer-server.git
```

Change into the project directory:
```
cd spacex-launch-viewer-server
```

Restore NuGet packages:
```
dotnet restore
```

Start the API:
```
dotnet run --project src\SpaceXLaunchViewer.WebApi\SpaceXLaunchViewer.WebApi.csproj
```

Open your web browser and navigate to http://localhost:44320/swagger/index.html to ensure the API is running properly.

## Installation in Docker
To run the API locally using Docker, follow these steps:

Clone the repository:
```shell
git clone https://github.com/thisIsRasel/spacex-launch-viewer-server.git
```

Change into the project directory:
```cmd
cd spacex-launch-viewer-server
```

Build the Docker image:
```
docker build -t spacex-launch-api .
```

Run the Docker container:
```
docker run -p 44320:80 spacex-launch-api
```
Open your web browser and navigate to http://localhost:44320/swagger/index.html to ensure the API is running properly.

## Usage
The API provides the following endpoints to retrieve SpaceX launch information:

## GET /api/SpaceX/Launches/Past
Returns a list of all past launches conducted by SpaceX. Each launch object contains details such as the mission name, launch date, rocket name, and links to additional resources.

## GET /api/SpaceX/Launches/Upcoming
Returns a list of all upcoming launches planned by SpaceX. Each launch object contains details such as the mission name, launch date, rocket name, and links to additional resources.

## GET /api/SpaceX/Launches/{flightNumber}
Returns the details of a specific launch. Response contains details such as the mission name, launch date, rocket name, and links to additional resources

## Technologies Used
* .NET 7: Cross-platform framework for building web applications.
* SpaceX API: Official API provided by SpaceX to retrieve launch data.
* Polly: Make the API resilient.
* Serilog: Log the API request for better monitoring.

## Contributing
Contributions are welcome! If you encounter any issues or have suggestions for improvements, please feel free to submit a pull request or open an issue on the project's GitHub repository.

## License
This project is licensed under the MIT License.