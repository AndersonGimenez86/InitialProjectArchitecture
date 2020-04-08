FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5050
EXPOSE 5051

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src

COPY "Payment.gateway.sln" "Payment.gateway.sln"

COPY "Payment.application.service/Payment.application.services.csproj" "Payment.application.service/Payment.application.services.csproj"
COPY "Payment.infrastructure.crosscutting/Payment.infrastructure.crosscutting.csproj" "Payment.infrastructure.crosscutting/Payment.infrastructure.crosscutting.csproj"
COPY "Payment.infrastructure.crosscutting.ioc/Payment.infrastructure.crosscutting.ioc.csproj" "Payment.infrastructure.crosscutting.ioc/Payment.infrastructure.crosscutting.ioc.csproj"

RUN dotnet restore "./Payment.gateway.csproj"

COPY . .
WORKDIR "/src/Payment.gateway"
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Payment.gateway.dll"]
