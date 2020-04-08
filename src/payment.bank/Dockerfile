FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5550
EXPOSE 5551

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src

COPY "Payment.gateway.sln" "Payment.gateway.sln"

COPY "Payment.application.messaging/Payment.application.messaging.csproj" "Payment.messaging.service/Payment.application.messaging.csproj"
COPY "Payment.infrastructure.crosscutting.kafka/Payment.infrastructure.crosscutting.kafka.csproj" "Payment.infrastructure.crosscutting.kafka/Payment.infrastructure.crosscutting.kafka.csproj"
COPY "Payment.infrastructure.crosscutting.ioc/Payment.infrastructure.crosscutting.ioc.csproj" "Payment.infrastructure.crosscutting.ioc/Payment.infrastructure.crosscutting.ioc.csproj"

RUN dotnet restore "./Payment.bank.csproj"

COPY . .
WORKDIR "/src/Payment.bank"
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Payment.bank.dll"]
