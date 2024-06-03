#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["JDChallenge.Api/JDChallenge.Api.csproj", "JDChallenge.Api/"]
COPY ["JDChallenge.Business/JDChallenge.Business.csproj", "JDChallenge.Business/"]
COPY ["JDChallenge.Domain/JDChallenge.Domain.csproj", "JDChallenge.Domain/"]
COPY ["JDChallenge.Services/JDChallenge.Services.csproj", "JDChallenge.Services/"]
RUN dotnet restore "./JDChallenge.Api/JDChallenge.Api.csproj"
COPY . .
WORKDIR "/src/JDChallenge.Api"
RUN dotnet build "./JDChallenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./JDChallenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JDChallenge.Api.dll"]