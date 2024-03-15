#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update

RUN apt-get install -y apt-utils

RUN apt-get install -y libgdiplus

RUN apt-get install -y libc6-dev
 
RUN ln -s /usr/lib/libgdiplus.so/usr/lib/gdiplus.dll
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SaleCore.Api/SaleCore.Api.csproj", "SaleCore.Api/"]
COPY ["SaleCore.Application/SaleCore.Application.csproj", "SaleCore.Application/"]
COPY ["SaleCore.Domain/SaleCore.Domain.csproj", "SaleCore.Domain/"]
COPY ["SaleCore.Infrastructure/SaleCore.Infrastructure.csproj", "SaleCore.Infrastructure/"]
COPY ["SaleCore.Utilities/SaleCore.Utilities.csproj", "SaleCore.Utilities/"]
RUN dotnet restore "./SaleCore.Api/SaleCore.Api.csproj"
COPY . .
WORKDIR "/src/SaleCore.Api"
RUN dotnet build "./SaleCore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SaleCore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ln -fs /usr/share/zoneinfo/America/Guatemala /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata
ENTRYPOINT ["dotnet", "SaleCore.Api.dll"]