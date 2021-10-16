FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5002

ENV ASPNETCORE_URLS=http://+:5002

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ShopService/ShopService/ShopService.csproj", "ShopService/ShopService/"]
RUN dotnet restore "ShopService\ShopService\ShopService.csproj"
COPY . .
WORKDIR "/src/ShopService/ShopService"
RUN dotnet build "ShopService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopService.dll"]
