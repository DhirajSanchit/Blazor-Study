FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ablaze/Ablaze.csproj", "Ablaze/"]
RUN dotnet restore "Ablaze/Ablaze.csproj"
COPY . .
WORKDIR "/src/Ablaze"
RUN dotnet build "Ablaze.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ablaze.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ablaze.dll"]
