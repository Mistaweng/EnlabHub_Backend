#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EnlabHub_Backend/EnlabHub_Backend.csproj", "EnlabHub_Backend/"]
RUN dotnet restore "EnlabHub_Backend/EnlabHub_Backend.csproj"
COPY . .
WORKDIR "/src/EnlabHub_Backend"
RUN dotnet build "EnlabHub_Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EnlabHub_Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnlabHub_Backend.dll"]




#
#
## See https://aka.ms/customizecontainer to learn how to customize your debug container
## and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
## Use the .NET SDK image for building and publishing
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#
## Copy the project file and restore dependencies
#COPY ["Enlab_Voting_Backend/Enlab_Voting_Backend.csproj", "Enlab_Voting_Backend/"]
#RUN dotnet restore "Enlab_Voting_Backend/Enlab_Voting_Backend.csproj"
#
## Copy the remaining source code
#COPY . .
#
## Build the application
#WORKDIR "/src/Enlab_Voting_Backend"
#RUN dotnet build "Enlab_Voting_Backend.csproj" -c Release -o /app/build
#
## Use the .NET runtime image for the final stage
#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
#WORKDIR /app
#
## Copy the published application
#COPY --from=build /app/build .
#
## Expose the desired ports
#EXPOSE 5000
#EXPOSE 5001
#
## Define the entry point for the application
#ENTRYPOINT ["dotnet", "Enlab_Voting_Backend.dll"]
#
#