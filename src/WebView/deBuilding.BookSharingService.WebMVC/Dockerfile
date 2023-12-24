#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebView/deBuilding.BookSharingService.WebMVC/deBuilding.BookSharingService.WebMVC.csproj", "WebView/deBuilding.BookSharingService.WebMVC/"]
COPY ["Domain/deBuilding.BookSharingService.Domain/deBuilding.BookSharingService.Domain.csproj", "Domain/deBuilding.BookSharingService.Domain/"]
RUN dotnet restore "./WebView/deBuilding.BookSharingService.WebMVC/./deBuilding.BookSharingService.WebMVC.csproj"
COPY . .
WORKDIR "/src/WebView/deBuilding.BookSharingService.WebMVC"
RUN dotnet build "./deBuilding.BookSharingService.WebMVC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./deBuilding.BookSharingService.WebMVC.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "deBuilding.BookSharingService.WebMVC.dll"]