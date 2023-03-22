FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Locations/src/Locations.API/Locations.API.csproj", "Locations/src/Locations.API/"]
RUN dotnet restore "Locations/src/Locations.API/Locations.API.csproj"

COPY . .
WORKDIR "/src/Locations/src/Locations.API"
RUN dotnet build "Locations.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locations.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Locations.API.dll"]