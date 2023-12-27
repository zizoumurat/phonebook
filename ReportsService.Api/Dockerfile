#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReportsService.Api/ReportsService.Api.csproj", "ReportsService.Api/"]
COPY ["ReportsService.Domain/ReportsService.Domain.csproj", "ReportsService.Domain/"]
COPY ["ReportsService.Persistance/ReportsService.Persistance.csproj", "ReportsService.Persistance/"]
COPY ["ReportsService.Application/ReportsService.Application.csproj", "ReportsService.Application/"]
COPY ["ReportsService.Presentation/ReportsService.Presentation.csproj", "ReportsService.Presentation/"]
RUN dotnet restore "./ReportsService.Api/./ReportsService.Api.csproj"
COPY . .
WORKDIR "/src/ReportsService.Api"
RUN dotnet build "./ReportsService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ReportsService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportsService.Api.dll"]