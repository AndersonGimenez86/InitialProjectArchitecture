FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Payment.account.csproj", ""]
RUN dotnet restore "./Payment.account.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Payment.account.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Payment.account.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Payment.account.dll"]
