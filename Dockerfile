FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /app
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install -y nodejs
RUN npm install -g @angular/cli
# copy csproj and restore as distinct layers
COPY *.sln .
COPY ["MyComicLibrary/MyComicLibrary.csproj", "MyComicLibrary/"]
RUN dotnet restore "MyComicLibrary/MyComicLibrary.csproj"
# copy everything else and build app
COPY . ./
WORKDIR "/app/MyComicLibrary/"
RUN dotnet publish -c Release -o out /p:PublishWithAspNetCoreTargetManifest="false"
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS runtime
WORKDIR /app
COPY --from=build /app/MyComicLibrary/out ./
COPY nginx.conf.sigil ./
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "MyComicLibrary.dll"]