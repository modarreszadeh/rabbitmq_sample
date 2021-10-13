FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Producer/Producer.csproj","Producer/"]
COPY ["DataAccess/DataAccess.csproj","DataAccess/"]
RUN dotnet restore "Producer/Producer.csproj"
COPY . .
RUN dotnet build "Producer/Producer.csproj" -c Realese -o /app/build

FROM build AS publish
RUN dotnet publish "Producer/Producer.csproj" -c Realese -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","Producer.dll" ]
