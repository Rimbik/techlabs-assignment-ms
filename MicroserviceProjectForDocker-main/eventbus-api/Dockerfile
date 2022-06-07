#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eventbus-api/eventbus-api.csproj", "eventbus-api/"]
RUN dotnet restore "eventbus-api/eventbus-api.csproj"
COPY . .
WORKDIR "/src/eventbus-api"
RUN dotnet build "eventbus-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eventbus-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eventbus-api.dll"]