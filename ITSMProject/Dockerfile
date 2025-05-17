FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ITSMProject/ITSMProject.csproj", "ITSMProject/"]
RUN dotnet restore "ITSMProject/ITSMProject.csproj"
COPY . .
WORKDIR "/src/ITSMProject"
RUN dotnet build "./ITSMProject.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ITSMProject.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# copy app/publish/Data/app.db to /app/Data/app.db

ENTRYPOINT ["dotnet", "ITSMProject.dll"]
