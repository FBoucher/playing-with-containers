# 2 - .NET Minimal API with local dependencies

## Create the second iteration of DungeonAPI

The DungeonAPI V2 was created by copying the V1 folder and moving the classes in a new project called `DungeonDomain`. The `DungeonAPI` project now has a reference to the `DungeonDomain` project. This should represent a more realistic scenario where the API has a dependency to a domain project. 

A workaround to avoid having local dependencies would be to have those projects in NuGet packages.

the `DungeonDomain` project was created with the following command:

```dotnetcli
dotnet new classlib -n DungeonDomain

dotnet new sln -n DungeonAPI-v2
dotnet sln add .\DungeonAPI\DungeonAPI-v2.csproj
dotnet sln add .\DungeonDomain\DungeonDomain.csproj

cd DungeonAPI\
dotnet add reference ..\DungeonDomain\DungeonDomain.csproj

```