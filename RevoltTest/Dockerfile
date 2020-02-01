FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["RevoltTest/RevoltTest.csproj", "RevoltTest/"]
RUN dotnet restore "RevoltTest/RevoltTest.csproj"
COPY . .
WORKDIR "/src/RevoltTest"
RUN dotnet build "RevoltTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RevoltTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RevoltTest.dll"]