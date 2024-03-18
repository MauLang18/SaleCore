FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Instalar dependencias necesarias
RUN apt-get update && \
    apt-get install -y apt-utils && \
    apt-get install -y libgdiplus && \
    apt-get install -y libc6-dev && \
    ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll

# Crear directorio de wwwroot y dar permisos
RUN mkdir -p /app/wwwroot && \
    chmod 755 /app/wwwroot

WORKDIR /app
EXPOSE 8080

# Segunda etapa: construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar archivos del proyecto y restaurar dependencias
COPY ["SaleCore.Api/SaleCore.Api.csproj", "SaleCore.Api/"]
COPY ["SaleCore.Application/SaleCore.Application.csproj", "SaleCore.Application/"]
COPY ["SaleCore.Domain/SaleCore.Domain.csproj", "SaleCore.Domain/"]
COPY ["SaleCore.Infrastructure/SaleCore.Infrastructure.csproj", "SaleCore.Infrastructure/"]
COPY ["SaleCore.Utilities/SaleCore.Utilities.csproj", "SaleCore.Utilities/"]
RUN dotnet restore "./SaleCore.Api/SaleCore.Api.csproj"
COPY . .

WORKDIR "/src/SaleCore.Api"
RUN dotnet build "./SaleCore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Tercera etapa: publicación de la aplicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SaleCore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cuarta etapa: configuración de la imagen final
FROM base AS final
WORKDIR /app

# Copiar archivos publicados de la etapa anterior
COPY --from=publish /app/publish .

# Agregar permisos adecuados al directorio de la aplicación
RUN chmod 755 /app

# Exponer el puerto en el que la aplicación escucha
EXPOSE 8080

# Punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "SaleCore.Api.dll"]
