#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Net.Sample.AppService.Api.csproj", "AppServices/Net.Sample.AppService.Api/"]
RUN dotnet restore "AppServices/Net.Sample.AppService.Api/Net.Sample.AppService.Api.csproj"
COPY . .
#WORKDIR "/AppServices/Net.Sample.AppService.Api"
RUN dotnet build "Net.Sample.AppService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net.Sample.AppService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net.Sample.AppService.Api.dll"]