#FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.3 AS build-env
FROM mcr.microsoft.com/dotnet/core/sdk:2.2.105 AS build-env

WORKDIR /app

COPY ./FirstAPI.sln .
COPY ./FirstAPI/FirstAPI.csproj ./FirstAPI/

RUN dotnet restore

# Copy everything else and build
COPY . ./

#RUN dotnet test ./FirstAPI.sln --configuration Release --no-restore

#RUN dotnet publish "./FirstAPI/FirstAPI.csproj" --output "../dist" --configuration Release --no-restore

RUN dotnet publish -c Release -o out

# Build runtime image
#FROM mcr.microsoft.com/dotnet/core/sdk:2.2
FROM mcr.microsoft.com/dotnet/core/runtime:2.2.3
WORKDIR /app
#COPY --from=build-env /dist .
COPY --from=build-env /app/out .
EXPOSE 80 443
ENTRYPOINT ["dotnet", "FirstAPI.dll"]
