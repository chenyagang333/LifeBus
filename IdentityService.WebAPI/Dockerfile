#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IdentityService.WebAPI/IdentityService.WebAPI.csproj", "IdentityService.WebAPI/"]
COPY ["CommonInitializer/CommonInitializer.csproj", "CommonInitializer/"]
COPY ["Chen.ASPNETCore/Chen.ASPNETCore.csproj", "Chen.ASPNETCore/"]
COPY ["Chen.Commons/Chen.Commons.csproj", "Chen.Commons/"]
COPY ["Chen.EventBus/Chen.EventBus.csproj", "Chen.EventBus/"]
COPY ["Chen.Infrastructure/Chen.Infrastructure.csproj", "Chen.Infrastructure/"]
COPY ["Chen.DomainCommons/Chen.DomainCommons.csproj", "Chen.DomainCommons/"]
COPY ["Chen.JWT/Chen.JWT.csproj", "Chen.JWT/"]
COPY ["IdentityService.Domain/IdentityService.Domain.csproj", "IdentityService.Domain/"]
COPY ["IdentityService.Infrastructure/IdentityService.Infrastructure.csproj", "IdentityService.Infrastructure/"]
RUN dotnet restore "./IdentityService.WebAPI/IdentityService.WebAPI.csproj"
COPY . .
WORKDIR "/src/IdentityService.WebAPI"
RUN dotnet build "./IdentityService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IdentityService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod -R 755 /app/wwwroot
#ENTRYPOINT ["dotnet", "IdentityService.WebAPI.dll"]
# �ӳ�5���ִ��
CMD ["sh", "-c", "sleep 5 && dotnet IdentityService.WebAPI.dll"]