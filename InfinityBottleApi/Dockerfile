FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InfinityBottleApi/InfinityBottleApi.csproj", "InfinityBottleApi/"]
RUN dotnet restore "InfinityBottleApi/InfinityBottleApi.csproj"
COPY . .
WORKDIR "/src/InfinityBottleApi"
RUN dotnet build "InfinityBottleApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfinityBottleApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InfinityBottleApi.dll"]
