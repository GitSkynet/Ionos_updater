#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ubuntu.Server.API/Ubuntu.Server.API.csproj", "Ubuntu.Server.API/"]
COPY ["DataAccess.DataAccess/DataAccess.DataAccess.csproj", "DataAccess.DataAccess/"]
COPY ["DataAccess.Entities/DataAccess.Entities.csproj", "DataAccess.Entities/"]
COPY ["Domain.Service/Domain.Service.csproj", "Domain.Service/"]
COPY ["DomainService.Contracts/DomainService.Contracts.csproj", "DomainService.Contracts/"]
RUN dotnet restore "Ubuntu.Server.API/Ubuntu.Server.API.csproj"
COPY . .
WORKDIR "/src/Ubuntu.Server.API"
RUN dotnet build "Ubuntu.Server.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ubuntu.Server.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
LABEL maintainer="Carlos Curtido"
LABEL org.opencontainers.image.source="https://github.com/GitSkynet/Ubuntu.Server.API"
LABEL org.opencontainers.image.title="Skynet API"
LABEL org.opencontainers.image.description="Skynet services automate"
LABEL org.opencontainers.image.revision="1"
LABEL org.opencontainers.image.vendor="Ciberdyne Systems"
LABEL org.opencontainers.image.licenses="Open Source"
LABEL org.opencontainers.image.restarts=always
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ubuntu.Server.API.dll"]