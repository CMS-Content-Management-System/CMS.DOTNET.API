#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApiBlog.csproj", "."]
RUN dotnet restore "./ApiBlog.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "./ApiBlog.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApiBlog.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV DDD01=Testando
ENV DDD02=Testando2
ENV DDD02.DDD02-01=Testando3
ENV DDD02:DDD02-01=Testando4
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiBlog.dll"]