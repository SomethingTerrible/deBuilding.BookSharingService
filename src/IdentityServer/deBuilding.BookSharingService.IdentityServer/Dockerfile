#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IdentityServer/deBuilding.BookSharingService.IdentityServer/deBuilding.BookSharingService.IdentityServer.csproj", "IdentityServer/deBuilding.BookSharingService.IdentityServer/"]
COPY ["Services/Common/deBuilding.BookSharingService.ServicesCommon/deBuilding.BookSharingService.ServicesCommon.csproj", "Services/Common/deBuilding.BookSharingService.ServicesCommon/"]
COPY ["EventBus/deBuilding.BookSharingService.RabbitMQEventBus/deBuilding.BookSharingService.RabbitMQEventBus.csproj", "EventBus/deBuilding.BookSharingService.RabbitMQEventBus/"]
COPY ["EventBus/deBuilding.BookSharingService.EventBus/deBuilding.BookSharingService.EventBus.csproj", "EventBus/deBuilding.BookSharingService.EventBus/"]
RUN dotnet restore "./IdentityServer/deBuilding.BookSharingService.IdentityServer/./deBuilding.BookSharingService.IdentityServer.csproj"
COPY . .
WORKDIR "/src/IdentityServer/deBuilding.BookSharingService.IdentityServer"
RUN dotnet build "./deBuilding.BookSharingService.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./deBuilding.BookSharingService.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "deBuilding.BookSharingService.IdentityServer.dll"]