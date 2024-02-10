FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FreelaDev.MsAuth.Api/FreelaDev.MsAuth.Api.csproj", "FreelaDev.MsAuth.Api/"]
COPY ["FreelaDev.MsAuth.Application/FreelaDev.MsAuth.Application.csproj", "FreelaDev.MsAuth.Application/"]
COPY ["FreelaDev.MsAuth.Core/FreelaDev.MsAuth.Core.csproj", "FreelaDev.MsAuth.Core/"]
COPY ["FreelaDev.MsAuth.Infrastructure/FreelaDev.MsAuth.Infrastructure.csproj", "FreelaDev.MsAuth.Infrastructure/"]
RUN dotnet restore "FreelaDev.MsAuth.Api/FreelaDev.MsAuth.Api.csproj"
COPY . .
WORKDIR "/src/FreelaDev.MsAuth.Api"
RUN dotnet build "FreelaDev.MsAuth.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreelaDev.MsAuth.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreelaDev.MsAuth.Api.dll"]
