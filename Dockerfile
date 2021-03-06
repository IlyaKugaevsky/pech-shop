FROM microsoft/aspnetcore:2.0.5 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0.5-2.1.4 AS build
WORKDIR /src
COPY *.sln ./
COPY PechShop/PechShop.csproj PechShop/
RUN dotnet restore
CMD cd PechShop
CMD dotnet ef database update
CMD ..
COPY . .
WORKDIR /src/PechShop
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PechShop.dll"]

