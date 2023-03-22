FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LocationsConsoleApp/LocationsConsoleApp.csproj", "LocationsConsoleApp/"]
RUN dotnet restore "LocationsConsoleApp/LocationsConsoleApp.csproj"
COPY . .
WORKDIR "/src/LocationsConsoleApp"
RUN dotnet build "LocationsConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocationsConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocationsConsoleApp.dll"]
