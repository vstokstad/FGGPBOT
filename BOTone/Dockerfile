FROM mcr.microsoft.com/dotnet/runtime:3.1
COPY bin/Release/netcoreapp3.1/publish/ DOTone/
WORKDIR /DOTone
ENTRYPOINT ["dotnet", "DOTone.dll"]