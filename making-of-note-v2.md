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

## Containerize the solution

If we try to containerize the solution using the same Dockerfile as the V1, we will get an error because the Dockerfile is not aware of the `DungeonDomain` project. We need to make some changes so the `DungeonDomain` project is included.


## Deploy to Azure

There is already a Container Environment in deployed and this iteration is still a single container. By looking into the Azure portal the `resource-group`, and `environment` (Container Apps Environment) can be found and then a second container can be deployed using the following command: 

```azcli
az containerapp create -n ca-dungeonapi-v2 -g RESSOURCE_GROUP --image fboucher/dungeon-api:v2 --environment ENVIRONMENT_NAME --ingress external --target-port 8081  --min-replicas 0 --max-replicas 1
```

## Summary

In this second iteration, we created a simple .NET Minimal API with a local dependency, containerized it and deployed it to Azure. Instead of using the CICD we used `az cli` command to add a second container to the existing environment.

```azcli


## Next

In the [next iteration](#), let's add a database to the solution and see how it affects the containerization and deployment to Azure.