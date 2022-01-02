FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Project-Runners.Hub/Project-Runners.Hub.csproj", "Project-Runners.Hub/"]
RUN dotnet restore "Project-Runners.Hub/Project-Runners.Hub.csproj"
COPY . .
WORKDIR "/src/Project-Runners.Hub"
RUN dotnet build "Project-Runners.Hub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project-Runners.Hub.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project-Runners.Hub.dll"]
