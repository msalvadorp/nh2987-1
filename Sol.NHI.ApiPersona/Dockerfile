#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS="http://+:8080"
ENV CnnDB="Data Source=srttmpnh.database.windows.net;Initial Catalog=NhDbPersona;Persist Security Info=True;User ID=sqlserver;Password=A123456789123$"
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Sol.NHI.ApiPersona/Sol.NHI.ApiPersona.csproj", "Sol.NHI.ApiPersona/"]
RUN dotnet restore "Sol.NHI.ApiPersona/Sol.NHI.ApiPersona.csproj"
COPY . .
WORKDIR "/src/Sol.NHI.ApiPersona"
RUN dotnet build "Sol.NHI.ApiPersona.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sol.NHI.ApiPersona.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sol.NHI.ApiPersona.dll"]