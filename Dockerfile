FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY . ./

RUN dotnet publish DallyTally/DallyTally.Api/DallyTally.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .
RUN apt-get update && \
    apt-get install -y fontconfig && \
    fc-cache -f -v
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "DallyTally.Api.dll"]
