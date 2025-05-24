# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos de solución y proyecto
COPY *.sln .
COPY NoticiasEnriquecidas.Mvc/*.csproj ./NoticiasEnriquecidas.Mvc/

# Restaurar dependencias
RUN dotnet restore

# Copiar todo el código
COPY NoticiasEnriquecidas.Mvc/. ./NoticiasEnriquecidas.Mvc/

# Construir y publicar
WORKDIR /app/NoticiasEnriquecidas.Mvc
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copiar la publicación desde la etapa de build
COPY --from=build /app/publish .

# Configurar puerto dinámico
ENV ASPNETCORE_URLS=http://+:$PORT

# Comando para iniciar la app
ENTRYPOINT ["dotnet", "NoticiasEnriquecidas.Mvc.dll"]
