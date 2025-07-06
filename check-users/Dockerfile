# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o /publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "check-users.dll"]
