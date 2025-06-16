# Usa la imagen SDK de .NET 9 Preview
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copiamos la solución y el código
COPY TuApp.sln ./
COPY src/ ./src/

# Restaura, construye y publica
WORKDIR /src/src/TuApp.Api
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Imagen base para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TuApp.Api.dll"]
