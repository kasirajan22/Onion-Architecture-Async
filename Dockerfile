#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OnionArchitecture/Onion-Architecture-Async.csproj", "OnionArchitecture/"]
COPY ["RepositoryLayer/RepositoryLayer.csproj", "RepositoryLayer/"]
COPY ["DomainLayer/DomainLayer.csproj", "DomainLayer/"]
COPY ["ServicesLayer/ServicesLayer.csproj", "ServicesLayer/"]
RUN dotnet restore "OnionArchitecture/Onion-Architecture-Async.csproj"
COPY . .
WORKDIR "/src/OnionArchitecture"
RUN dotnet build "Onion-Architecture-Async.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onion-Architecture-Async.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onion-Architecture-Async.dll"]
