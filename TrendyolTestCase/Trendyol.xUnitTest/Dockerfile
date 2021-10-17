#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trendyol.xUnitTest/Trendyol.xUnitTest.csproj", "Trendyol.xUnitTest/"]
COPY ["Trendyol.API/Trendyol.API.csproj", "Trendyol.API/"]
COPY ["Trendyol.Utility/Trendyol.Utility.csproj", "Trendyol.Utility/"]
COPY ["Trendyol.Service/Trendyol.Service.csproj", "Trendyol.Service/"]
COPY ["Trendyol.Data/Trendyol.Data.csproj", "Trendyol.Data/"]
RUN dotnet restore "Trendyol.xUnitTest/Trendyol.xUnitTest.csproj"
COPY . .
WORKDIR "/src/Trendyol.xUnitTest"
RUN dotnet build "Trendyol.xUnitTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trendyol.xUnitTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trendyol.xUnitTest.dll"]