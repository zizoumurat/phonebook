#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PersonService.Api/PersonService.Api.csproj", "PersonService.Api/"]
COPY ["External/PersonService.Infrasturcture/PersonService.Infrasturcture.csproj", "External/PersonService.Infrasturcture/"]
COPY ["External/PersonService.Persistance/PersonService.Persistance.csproj", "External/PersonService.Persistance/"]
COPY ["Core/PersonService.Application/PersonService.Application.csproj", "Core/PersonService.Application/"]
COPY ["Core/PersonService.Domain/PersonService.Domain.csproj", "Core/PersonService.Domain/"]
COPY ["External/PersonService.Presentation/PersonService.Presentation.csproj", "External/PersonService.Presentation/"]

RUN dotnet restore "PersonService.Api/PersonService.Api.csproj"
COPY . .
WORKDIR "/src/PersonService.Api"
RUN dotnet build "./PersonService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PersonService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Giriş noktasını belirle
ENTRYPOINT ["dotnet", "PersonService.Api.dll"]