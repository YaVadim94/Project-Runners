FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Project-Runners.Web/Project-Runners.Web.csproj", "Project-Runners.Web/"]
RUN dotnet restore "Project-Runners.Web/Project-Runners.Web.csproj"
COPY . .
WORKDIR "/src/Project-Runners.Web"
RUN dotnet build "Project-Runners.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project-Runners.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project-Runners.Web.dll"]
