# playing-with-containers
Little project to play around with containers

## 1 - Simple .NET Minimal API 

Let's create a simple .NET Minimal API that return canned information and run it in a container. And add a `.gitignore` file.

```dotnetcli
dotnet new web -n DungeonAPI

dotnet new  gitignore 
```

On Windows you can add a Dev certificate. Trust the HTTPS development certificate by running the following command:

```dotnetcli
dotnet dev-certs https --trust
```

Totally optional but to help generating random data the sample uses the [Bogus](https://www.nuget.org/packages/Bogus) nuget package.

```dotnetcli
dotnet add package Bogus
```

Create an adventurer class and add a Adventurer GET endpoint to the DungeonAPI. Then try it doing a `dotnet run` and navigating to `https://localhost:5001/adventurer`. You can also test is in a tool like Postman or Insomnia, or even from in VS Code using the REST Client extension (with file like [adventurer-get.http](./DungeonAPI/test/adventurer-get.http)).


