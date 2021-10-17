#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trendyol.API/Trendyol.API.csproj", "Trendyol.API/"]
COPY ["Trendyol.Utility/Trendyol.Utility.csproj", "Trendyol.Utility/"]
COPY ["Trendyol.Service/Trendyol.Service.csproj", "Trendyol.Service/"]
COPY ["Trendyol.Data/Trendyol.Data.csproj", "Trendyol.Data/"]
RUN dotnet restore "Trendyol.API/Trendyol.API.csproj"
COPY . .
WORKDIR "/src/Trendyol.API"
RUN dotnet build "Trendyol.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trendyol.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trendyol.API.dll"]