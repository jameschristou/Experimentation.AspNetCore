# ASP.NET Core Experimentation
This repository provides an example of how to implement A/B testing in your ASP.NET Core applications.

## Usage
The client application calling your API is expected to pass the experiment groups that the user belongs to as a csv string in the `EXP_HEADER` header when making an API request.

The `ExperimentGroupChecker` class can then be used in the ASP.NET Core application to determine whether the user who initiated this request belongs to the group you are checking for. You can then execute a different code path and return a different response depending on the result of this check.

In our example application, we return a slightly different message in our API response depending on whether or not the user belongs to group "A". See [ContactsController.cs](https://github.com/jameschristou/Experimentation.AspNetCore/blob/master/Experimentation.AspNetCore.Example/ContactsController.cs) for how to use this.

```C#
Message = _experimentGroupChecker.IsInGroup("A") ? "Group A" : "Not in Group A"
```

## TestApp
You can run the application using Visual Studio code (IIS Express). Fire a request at the endpoint `/contacts/` and pass the value `A` in the header `EXP_HEADER`. Try changing the header value and you will see the returned `message` property change.

### Build
To build this application just run `dotnet build Experimentation.AspNetCore.Example.csproj` at the command line.

### Run
To run this application just run `dotnet run Experimentation.AspNetCore.Example.csproj` at the command line.