# SixDegrees.PruebaSD.WebApi/Dockerfile

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0.100 AS build
WORKDIR /src

# Copiar proyectos de capa
COPY SixDegrees.PruebaSD.Entidades/SixDegrees.PruebaSD.Entidades.csproj ./SixDegrees.PruebaSD.Entidades/
COPY SixDegrees.PruebaSD.Negocio/SixDegrees.PruebaSD.Negocio.csproj ./SixDegrees.PruebaSD.Negocio/
COPY SixDegrees.PruebaSD.AccesoDatos/SixDegrees.PruebaSD.AccesoDatos.csproj ./SixDegrees.PruebaSD.AccesoDatos/
COPY SixDegrees.PruebaSD.WebApi/SixDegrees.PruebaSD.WebApi.csproj ./SixDegrees.PruebaSD.WebApi/

# Restaurar dependencias
RUN dotnet restore ./SixDegrees.PruebaSD.WebApi/SixDegrees.PruebaSD.WebApi.csproj

# Copiar todo el código
COPY . .

# Publicar aplicación
WORKDIR /src/SixDegrees.PruebaSD.WebApi
RUN dotnet publish -c Release -o /app

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:9.0.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "SixDegrees.PruebaSD.WebApi.dll"]