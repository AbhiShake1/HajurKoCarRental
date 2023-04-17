# Official .NET Core SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet build -c Debug -o out

# Use the official ASP.NET Core Runtime image as the base image for the production environment
FROM mcr.microsoft.com/dotnet/aspnet:6.0

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    curl \
    && rm -rf /var/lib/apt/lists/* \
    && curl -SL --output dotnet.tar.gz https://dotnetcli.blob.core.windows.net/dotnet/Sdk/6.0.100/dotnet-sdk-6.0.100-linux-x64.tar.gz \
    && dotnet_sha512='36D2C04E7CDB8D1C6B1D174FA12AE9247F9CA74E678EEE7A24C045FDDEE7F508F359A29A7C958962196A4C7A9A4E831F29C0B31F16682F6D83388D3B5FE5C5F5' \
    && echo "$dotnet_sha512 dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -C /usr/share/dotnet -xzf dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
    && rm dotnet.tar.gz

FROM surrealdb/surrealdb:latest

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "HajurKoCarRental.dll"]
