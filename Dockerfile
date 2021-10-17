FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5009

ENV ASPNETCORE_URLS=http://+:5009

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ShopService/ShopService/ShopService.csproj", "ShopService/ShopService/"]
COPY ["ShopService/TestLayer/TestLayer.csproj", "ShopService/TestLayer/"]
RUN dotnet restore "ShopService\ShopService\ShopService.csproj"
RUN dotnet restore "ShopService\TestLayer\TestLayer.csproj"
COPY . .
WORKDIR "/src/ShopService/ShopService"
RUN dotnet build "ShopService.csproj" -c Release -o /app/build
RUN dotnet build "/src/ShopService/TestLayer/TestLayer.csproj" -c Release -o /app/build

RUN dotnet test "/src/ShopService/TestLayer/TestLayer.csproj" --logger "trx;LogFileName=ShopService_Test.trx"

FROM build AS publish
RUN dotnet publish "ShopService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopService.dll"]
