#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Payment.Gateway.Scheduler/Payment.Gateway.Scheduler.csproj", "Payment.Gateway.Scheduler/"]
RUN dotnet restore "Payment.Gateway.Scheduler/Payment.Gateway.Scheduler.csproj"
COPY . .
WORKDIR "/src/Payment.Gateway.Scheduler"
RUN dotnet build "Payment.Gateway.Scheduler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment.Gateway.Scheduler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payment.Gateway.Scheduler.dll"]