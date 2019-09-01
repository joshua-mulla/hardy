FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
WORKDIR /src
COPY Hardy.sln ./
COPY Hardy.Common/*.csproj ./Hardy.Common/
COPY Hardy.WebApi/*.csproj ./Hardy.WebApi/
COPY Hardy.Application/*.csproj ./Hardy.Application/
COPY Hardy.Gateways/*.csproj ./Hardy.Gateways/
RUN dotnet restore 

# Copy everything else and build
COPY . .
WORKDIR /src/Hardy.Common/
RUN dotnet publish -c Release -o /app

WORKDIR /src/Hardy.WebApi/
RUN dotnet publish -c Release -o /app

WORKDIR /src/Hardy.Gateways/
RUN dotnet publish -c Release -o /app

WORKDIR /src/Hardy.Application/
RUN dotnet publish -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build /app/ .
ENTRYPOINT ["dotnet", "Hardy.WebApi.dll"]