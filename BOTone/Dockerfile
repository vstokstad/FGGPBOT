FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR FGGPBOT/
# copy csproj and restore as distinct layers
COPY *.sln .
COPY BOTone/*.csproj ./BOTone/
RUN dotnet restore
# copy csproj and restore as distinct layers
COPY BOTone/. ./BOTone/
WORKDIR /FGGPBOT/BOTone/
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /BOTone
COPY bin/Release/netcoreapp3.1/publish/ BOTone/
ENTRYPOINT ["dotnet", "BOTone.dll"]
