FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
COPY . .
RUN dotnet publish src/Epilepsy_Health_App.Services.Identity.Api -c release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS http://*:80
# ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT dotnet Epilepsy_Health_App.Identity.API.dll