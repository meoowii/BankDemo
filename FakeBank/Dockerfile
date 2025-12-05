#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

USER root
# Instalacja fontconfig
RUN apt-get update && apt-get install -y fonts-liberation fontconfig

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["FakeBank.csproj", "."]
RUN dotnet restore "./FakeBank.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FakeBank.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FakeBank.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FakeBank.dll"]