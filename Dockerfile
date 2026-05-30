# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj (agora dentro de /src)
COPY ["src/NecroClock.API/NecroClock.API.csproj", "src/NecroClock.API/"]
COPY ["src/NecroClock.Application/NecroClock.Application.csproj", "src/NecroClock.Application/"]
COPY ["src/NecroClock.Infrastructure/NecroClock.Infrastructure.csproj", "src/NecroClock.Infrastructure/"]

# Restore
RUN dotnet restore "src/NecroClock.API/NecroClock.API.csproj"

# Copy everything
COPY . .

# Build
RUN dotnet build "src/NecroClock.API/NecroClock.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "src/NecroClock.API/NecroClock.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NecroClock.API.dll"]