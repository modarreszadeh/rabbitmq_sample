FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Consumer/Consumer.csproj","Consumer/"]
COPY ["DataAccess/DataAccess.csproj","DataAccess/"]
RUN dotnet restore "Consumer/Consumer.csproj"
COPY . .
RUN dotnet build "Consumer/Consumer.csproj" -c Realese -o /app/build

FROM build AS publish
RUN dotnet publish "Consumer/Consumer.csproj" -c Realese -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","Consumer.dll" ]
