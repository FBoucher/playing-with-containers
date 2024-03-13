# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

COPY . ./
RUN dotnet publish DungeonAPI -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app
COPY --from=build /app/out .

# Switch to a non-privileged user (defined in the base image) that the app will run under.
# See https://docs.docker.com/go/dockerfile-user-best-practices/
# and https://github.com/dotnet/dotnet-docker/discussions/4764
USER $APP_UID

ENTRYPOINT ["dotnet", "DungeonAPI-v2.dll"]
