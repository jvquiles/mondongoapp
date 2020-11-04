﻿FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine3.11 AS base
EXPOSE 80
EXPOSE 8080
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "mondongo.api.dll"]