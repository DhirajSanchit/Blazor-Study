FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Webshop/Webshop.csproj", "Webshop/"]
RUN dotnet restore "Webshop/Webshop.csproj"
COPY . .
WORKDIR "/src/Webshop"
RUN dotnet build "Webshop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Webshop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webshop.dll"]
