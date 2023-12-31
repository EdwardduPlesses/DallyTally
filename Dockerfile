﻿
# Use the official Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the CSPROJ file and restore any dependencies (via NUGET)
COPY DallyTally.Api/DallyTally.Api.csproj ./
RUN dotnet restore

# Copy the project files and build the release
COPY . ./
RUN dotnet publish DallyTally.Api/DallyTally.Api.csproj -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DallyTally.Api.dll"]
