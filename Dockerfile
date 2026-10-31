
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["VidurPortfolio.csproj", "./"]
RUN dotnet restore "VidurPortfolio.csproj"

COPY . .
RUN dotnet publish "VidurPortfolio.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["sh", "-c", "dotnet VidurPortfolio.dll --urls http://0.0.0.0:${PORT:-8080}"]
