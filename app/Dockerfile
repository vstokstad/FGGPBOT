FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj .
#COPY ./nuget.config .
RUN dotnet restore

# Copy and publish app and libraries
COPY . .
RUN dotnet publish -c Release -o out  --no-restore


FROM mcr.microsoft.com/dotnet/runtime:5.0 AS runtime
WORKDIR /app/
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "dotnetapp.dll"]