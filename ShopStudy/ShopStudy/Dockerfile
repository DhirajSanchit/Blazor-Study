FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShopStudy/ShopStudy.csproj", "ShopStudy/"]
RUN dotnet restore "ShopStudy/ShopStudy.csproj"
COPY . .
WORKDIR "/src/ShopStudy"
RUN dotnet build "ShopStudy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopStudy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopStudy.dll"]
