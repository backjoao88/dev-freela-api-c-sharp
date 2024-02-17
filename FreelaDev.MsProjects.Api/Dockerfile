FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FreelaDev.MsProjects.Api/FreelaDev.MsProjects.Api.csproj", "FreelaDev.MsProjects.Api/"]
COPY ["FreelaDev.MsProjects.Application/FreelaDev.MsProjects.Application.csproj", "FreelaDev.MsProjects.Application/"]
COPY ["FreelaDev.MsProjects.Core/FreelaDev.MsProjects.Core.csproj", "FreelaDev.MsProjects.Core/"]
COPY ["FreelaDev.MsProjects.Infrastructure/FreelaDev.MsProjects.Infrastructure.csproj", "FreelaDev.MsProjects.Infrastructure/"]
RUN dotnet restore "FreelaDev.MsProjects.Api/FreelaDev.MsProjects.Api.csproj"
COPY . .
WORKDIR "/src/FreelaDev.MsProjects.Api"
RUN dotnet build "FreelaDev.MsProjects.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreelaDev.MsProjects.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreelaDev.MsProjects.Api.dll"]
