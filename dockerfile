FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore hackathon_backdotnet_g1.csproj

COPY . ./
RUN dotnet publish hackathon_backdotnet_g1.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "hackathon_backdotnet_g1.dll"]`