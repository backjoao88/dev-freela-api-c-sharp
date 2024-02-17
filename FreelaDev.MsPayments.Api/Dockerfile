FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FreelaDev.MsPayments.Api/FreelaDev.MsPayments.Api.csproj", "FreelaDev.MsPayments.Api/"]
RUN dotnet restore "FreelaDev.MsPayments.Api/FreelaDev.MsPayments.Api.csproj"
COPY . .
WORKDIR "/src/FreelaDev.MsPayments.Api"
RUN dotnet build "FreelaDev.MsPayments.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreelaDev.MsPayments.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreelaDev.MsPayments.Api.dll"]
