FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /src/Common.NET
COPY Common.NET/ .
RUN dotnet restore

WORKDIR /src/.NET
COPY Template.NET/ .
RUN dotnet restore
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "Infrastructure.WebApi.dll"]