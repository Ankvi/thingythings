FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.16 AS build
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publich -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine3.16
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "ThingyThings.Server.Api.dll"]
