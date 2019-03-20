#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1709 AS publish
WORKDIR /src
COPY . .
RUN dotnet restore /ignoreprojectextensions:.dcproj
WORKDIR /src/Inventory
RUN dotnet build Inventory.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Inventory.dll"]
