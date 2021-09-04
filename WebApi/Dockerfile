FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RelationshipApi/RelationshipApi.csproj", "RelationshipApi/"]
RUN dotnet restore "RelationshipApi\RelationshipApi.csproj"
COPY . .
WORKDIR "/src/RelationshipApi"
RUN dotnet build "RelationshipApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RelationshipApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RelationshipApi.dll", "--environment=Release"]
