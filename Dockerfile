FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
COPY Publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:8003
ENTRYPOINT ["dotnet", "Epilepsy_Health_App.Identity.API.dll"]
