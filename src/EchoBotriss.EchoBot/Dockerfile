FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/EchoBotriss.EchoBot/EchoBotriss.EchoBot.csproj", "EchoBotriss.EchoBot/"]
RUN dotnet restore "src/EchoBotriss.EchoBot/EchoBotriss.EchoBot.csproj"
COPY . .
WORKDIR "/src/EchoBotriss.EchoBot"
RUN dotnet build "EchoBotriss.EchoBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EchoBotriss.EchoBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EchoBotriss.EchoBot.dll"]
