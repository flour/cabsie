FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Cabsie.API/Cabsie.API.csproj", "Cabsie.API/"]
RUN dotnet restore "Cabsie.API/Cabsie.API.csproj"
COPY . .
WORKDIR "/src/Cabsie.API"
RUN dotnet build "Cabsie.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Cabsie.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cabsie.API.dll"]