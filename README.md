# playing-with-containers
Little project to play around with containers

## 1 - Simple .NET Minimal API 

Simple minimal API that contains all the information required (no database, nor external project references).

### Create the Minimal API

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

### Containerize the API and run it locally

It's now time to containerize the app. First, add a Dockerfile to the DungeonAPI project. There is multiple ways do to it, Julie Lerman has a nice [blog post](https://thedatafarm.com/docker/docker-init-for-asp-net-core-compared-to-vs-or-vs-code-extensions/) about it. Here, from the project's folder, I will use Docker CLI, but feel free to use the Docker extension in VS Code or Visual Studio.

When you're ready, start your application by running

```
docker compose up --build
```

Build your image ex: `docker build -t fboucher/dungeon-api .`

Push it to your Docker/ Azure registry  ex `docker push fboucher/dungeon-api`.

Then it can be run from everywhere, with ex  `docker run --rm -p 8080:8080 fboucher/dungeon-api`

### Hosting in Azure Container App

```azurecli
azd init
```

This, after analyzing the code, creates a bicep template for an *Hello-world* container app. It will create a folder `infra` with many `.bicep` files. For a simple demo we don't need all those resources but it's simpler to generate a template with all those and it's also good practices.

To make the app the dungeon-api instead of the hello-world, edit the file `infra/app/DungeonAPI.bicep`. In the `template` change the `image` and `name` values to `fboucher/dungeon-api` and `dungeon-api` respectively.

```bicep

template: {
      containers: [
        {
          image: fetchLatestImage.outputs.?containers[?0].?image ?? 'fboucher/dungeon-api:latest'
          name: 'dungeon-api'

```

You can also change the `scale` min-max values to limit the cost while learning.

```bicep
 scale: {
        minReplicas: 0
        maxReplicas: 1
```

Then deploy the app to azure using the command `adz up`. Because there a few monitoring resources that will be created with our app it will takes a few (5mins) minutes to deploy.

To deploy the app to azure use the command `adz up`. Because there a few monitoring resources that will be created with our app it will takes a few (5mins) minutes to deploy.