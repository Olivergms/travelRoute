FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["travelRoute-api/travelRoute-api.csproj", "travelRoute-api/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["CrossCutting/CrossCutting.csproj", "CrossCutting/"]
COPY ["Infra.Data/Infra.Data.csproj", "Infra.Data/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "travelRoute-api/travelRoute-api.csproj"
COPY . .
WORKDIR "/src/travelRoute-api"
RUN dotnet build "travelRoute-api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "travelRoute-api.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "travelRoute-api.dll"]