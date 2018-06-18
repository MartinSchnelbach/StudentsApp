FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 52781
EXPOSE 44398

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY StudentsApp/StudentsApp.csproj StudentsApp/
RUN dotnet restore StudentsApp/StudentsApp.csproj
COPY . .
WORKDIR /src/StudentsApp
RUN dotnet build StudentsApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish StudentsApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StudentsApp.dll"]
