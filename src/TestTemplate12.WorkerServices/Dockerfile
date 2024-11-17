#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestTemplate12.WorkerServices/TestTemplate12.WorkerServices.csproj", "src/TestTemplate12.WorkerServices/"]
COPY ["src/TestTemplate12.Core/TestTemplate12.Core.csproj", "src/TestTemplate12.Core/"]
COPY ["src/TestTemplate12.Common/TestTemplate12.Common.csproj", "src/TestTemplate12.Common/"]
RUN dotnet restore "src/TestTemplate12.WorkerServices/TestTemplate12.WorkerServices.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate12.WorkerServices"
RUN dotnet build "TestTemplate12.WorkerServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate12.WorkerServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/TestTemplate12.WorkerServices/entrypoint.sh", "src/entrypoint.sh"]
COPY ["src/TestTemplate12.WorkerServices/wait-for-it.sh", "src/wait-for-it.sh"]
CMD ["/bin/bash", "src/entrypoint.sh"]
