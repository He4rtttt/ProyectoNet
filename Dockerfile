# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos de solución y restaurar dependencias
COPY TuApp.sln ./
COPY src/ ./src/
RUN dotnet restore

# Publicar el proyecto API
RUN dotnet publish ./src/TuApp.Api/TuApp.Api.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Puerto expuesto por la API
EXPOSE 80

# Comando para ejecutar la API
ENTRYPOINT ["dotnet", "TuApp.Api.dll"]
