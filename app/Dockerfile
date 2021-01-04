FROM mcr.microsoft.com/dotnet/aspnet:3.1
CMD "dotnet publish"
COPY bin/Release/netcoreapp3.1/publish/ app/
WORKDIR /app
ENTRYPOINT ["dotnet", "app.dll"]
