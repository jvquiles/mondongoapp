FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11 AS build
WORKDIR /app

# Build
COPY ./mondongo.api/ ./mondongo.api/
COPY ./mondongo.domain/ ./mondongo.domain/
WORKDIR /app/mondongo.api/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine3.11 AS base
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /app
COPY --from=build /app/mondongo.api/out .
ENTRYPOINT ["dotnet", "mondongo.api.dll"]