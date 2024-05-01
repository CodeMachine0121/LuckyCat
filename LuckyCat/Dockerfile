FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ./ ./
RUN dotnet restore "LuckyCat/LuckyCat.csproj" -s https://api.nuget.org/v3/ -s https://www.nuget.org/api/v2/
RUN dotnet publish "LuckyCat/LuckyCat.csproj" -c Release -o published

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

# Change timezone to America/Anguilla (GMT-4)
ENV TZ America/Anguilla
RUN apk add tzdata                                  && \
    ln -snf /usr/share/zoneinfo/$TZ /etc/localtime  && \
    echo $TZ > /etc/timezone   

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
COPY --from=build /app/published/ ./

ENTRYPOINT ["dotnet", "LuckyCat.dll"]
