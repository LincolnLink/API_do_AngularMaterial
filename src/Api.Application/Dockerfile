#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Api.Application/Application.csproj", "Api.Application/"]
COPY ["Api.Service/Service/Service.csproj", "Api.Service/Service/"]
COPY ["ApiCrossCutting/CrossCutting/CrossCutting.csproj", "ApiCrossCutting/CrossCutting/"]
COPY ["Api.Data/Data/Data.csproj", "Api.Data/Data/"]
COPY ["Api.Domain/Domain/Domain.csproj", "Api.Domain/Domain/"]
RUN dotnet restore "Api.Application/Application.csproj"
COPY . .
WORKDIR "/src/Api.Application"
RUN dotnet build "Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]

RUN useradd -m myappuser
USER myappuser


CMD ASPNETCORE_URLS=http://*$PORT dotnet dotnetcore2021.dll

# CMD ASPNETCORE_URLS=http://*$PORT dotnet {project-name}.dll



# COPY . .

#--Padrão

# EXPOSE 80

# FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
# WORKDIR /src
# COPY ["Api.Application/Application.csproj", "Api.Application/"]
# COPY ["ApiCrossCutting/CrossCutting/CrossCutting.csproj", "ApiCrossCutting/CrossCutting/"]
# COPY ["Api.Data/Data/Data.csproj", "Api.Data/Data/"]
# COPY ["Api.Domain/Domain/Domain.csproj", "Api.Domain/Domain/"]
# COPY ["Api.Service/Service/Service.csproj", "Api.Service/Service/"]
# RUN dotnet restore "Api.Application/Application.csproj"
# COPY . .
# WORKDIR "/src/Api.Application"
# RUN dotnet build "Application.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "Application.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Application.dll"]