#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GRPC/FXH.User.GrpcService/FXH.User.GrpcService.csproj", "GRPC/FXH.User.GrpcService/"]
RUN dotnet restore "GRPC/FXH.User.GrpcService/FXH.User.GrpcService.csproj"
COPY . .
WORKDIR "/src/GRPC/FXH.User.GrpcService"
RUN dotnet build "FXH.User.GrpcService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FXH.User.GrpcService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FXH.User.GrpcService.dll"]