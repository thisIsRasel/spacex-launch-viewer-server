FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore SpaceXLaunchViewer.sln
RUN dotnet build SpaceXLaunchViewer.sln -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final

WORKDIR /app
COPY --from=build /publish .

EXPOSE 443
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "SpaceXLaunchViewer.WebApi.dll"]