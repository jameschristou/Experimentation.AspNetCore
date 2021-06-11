# ASP.NET Core Experimentation
This repository provides an example of how to implement A/B testing in your ASP.NET Core applications.

## Usage
The client application is expected to pass the experiment groups that the user belongs to as a csv string in the `EXP_HEADER` header.

The `ExperimentGroupChecker` class can then be used in the ASP.NET Core application to interrogate the `EXP_HEADER` header and determine whether the user who initiated this request belongs to the group we are testing for.

In our example application, we return a slightly different message depending on whether or not the user belongs to group "A".

## TestApp
You can run the application using Visual Studio code (IIS Express). Fire a request at the endpoint `/contacts/` and pass the value `A` in the header `EXP_HEADER`. Try changing the header value and you will see the returned `message` property change.

### Build
To build this application just run `dotnet build Experimentation.AspNetCore.Example.csproj` at the command line.

### Run
To run this application just run `dotnet run Experimentation.AspNetCore.Example.csproj` at the command line.