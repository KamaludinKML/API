FROM mrc.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY "kamal.sln" "kamal.sln"
COPY "Models/User.cs" "Models/User.cs"
COPY "Controller/UserController.cs" "Controller/UserController.cs"
COPY "Data/DbManager.cs" "Data/DbManager.cs"

RUN dotnet restore "kamal.sln"

COPY . .
WORKDIR /app
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build-env /app/out .

ENV ConnectionStrings__KoneksiKeMySql="Host=MySQl_container;Database=greenhouse;Username=root;Password=arofan_kamal;"
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

ENTRYPOINT ["dotnet", "API.dll"]