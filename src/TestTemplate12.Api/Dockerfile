#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/TestTemplate12.Api/TestTemplate12.Api.csproj", "src/TestTemplate12.Api/"]
COPY ["src/TestTemplate12.Data/TestTemplate12.Data.csproj", "src/TestTemplate12.Data/"]
COPY ["src/TestTemplate12.Common/TestTemplate12.Common.csproj", "src/TestTemplate12.Common/"]
COPY ["src/TestTemplate12.Core/TestTemplate12.Core.csproj", "src/TestTemplate12.Core/"]
RUN dotnet restore "src/TestTemplate12.Api/TestTemplate12.Api.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate12.Api"
RUN dotnet build "TestTemplate12.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate12.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTemplate12.Api.dll"]