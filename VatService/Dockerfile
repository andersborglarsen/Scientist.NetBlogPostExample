FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["VatService/VatService.csproj", "VatService/"]
RUN dotnet restore "VatService/VatService.csproj"
COPY . .
WORKDIR "/src/VatService"
RUN dotnet build "VatService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VatService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VatService.dll"]