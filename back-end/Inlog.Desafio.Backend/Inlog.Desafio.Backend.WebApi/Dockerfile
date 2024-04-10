#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Inlog.Desafio.Backend.WebApi/Inlog.Desafio.Backend.WebApi.csproj", "Inlog.Desafio.Backend.WebApi/"]
COPY ["Inlog.Desafio.Backend.Infra.Database/Inlog.Desafio.Backend.Infra.Database.csproj", "Inlog.Desafio.Backend.Infra.Database/"]
COPY ["Inlog.Desafio.Backend.Domain/Inlog.Desafio.Backend.Domain.csproj", "Inlog.Desafio.Backend.Domain/"]
RUN dotnet restore "./Inlog.Desafio.Backend.WebApi/Inlog.Desafio.Backend.WebApi.csproj"
COPY . .
WORKDIR "/src/Inlog.Desafio.Backend.WebApi"
RUN dotnet build "./Inlog.Desafio.Backend.WebApi.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Inlog.Desafio.Backend.WebApi.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inlog.Desafio.Backend.WebApi.dll"]