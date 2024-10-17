FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ["Authentication.API.csproj", "./"]
RUN dotnet restore "Authentication.API.csproj"
COPY . .
WORKDIR "/app"
RUN dotnet build "Authentication.API.csproj" -c Release -o /app/build
RUN dotnet publish "Authentication.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Authentication.API.dll"]