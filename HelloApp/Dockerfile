FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY HelloApp/HelloApp.csproj HelloApp/
RUN dotnet restore HelloApp/HelloApp.csproj
COPY . .
WORKDIR /src/HelloApp
RUN dotnet build HelloApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish HelloApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HelloApp.dll"]
