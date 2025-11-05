FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_URLS=http://+:8080
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DotNet8.ScalarWebApi.csproj", "./"]
RUN dotnet restore "DotNet8.ScalarWebApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "DotNet8.ScalarWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNet8.ScalarWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNet8.ScalarWebApi.dll"]
