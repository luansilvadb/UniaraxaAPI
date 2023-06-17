#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Uniaraxa.WebApi/Uniaraxa.WebApi.csproj", "Uniaraxa.WebApi/"]
COPY ["Uniaraxa.Infrastructure/Uniaraxa.Infrastructure.csproj", "Uniaraxa.Infrastructure/"]
COPY ["Uniaraxa.Application/Uniaraxa.Application.csproj", "Uniaraxa.Application/"]
COPY ["Uniaraxa.Core/Uniaraxa.Core.csproj", "Uniaraxa.Core/"]
RUN dotnet restore "Uniaraxa.WebApi/Uniaraxa.WebApi.csproj"
COPY . .
WORKDIR "/src/Uniaraxa.WebApi"
RUN dotnet build "Uniaraxa.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Uniaraxa.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Uniaraxa.WebApi.dll"]