FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51240
EXPOSE 44348

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Food.Server.WebApi/Food.Server.WebApi.csproj", "Food.Server.WebApi/"]
RUN dotnet restore "Food.Server.WebApi/Food.Server.WebApi.csproj"
COPY . .
WORKDIR "/src/Food.Server.WebApi"
RUN dotnet build "Food.Server.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Food.Server.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Food.Server.WebApi.dll"]