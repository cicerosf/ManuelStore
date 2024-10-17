FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ["BoxOrganiser.API.csproj", "./"]
RUN dotnet restore "BoxOrganiser.API.csproj"
COPY . .
WORKDIR "/app"
RUN dotnet build "BoxOrganiser.API.csproj" -c Release -o /app/build
RUN dotnet publish "BoxOrganiser.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BoxOrganiser.API.dll"]
