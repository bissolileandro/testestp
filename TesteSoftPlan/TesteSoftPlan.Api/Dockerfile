#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["TesteSoftPlan.Api/TesteSoftPlan.Api.csproj", "TesteSoftPlan.Api/"]
COPY ["TesteSoftPlan.Service/TesteSoftPlan.Service.csproj", "TesteSoftPlan.Service/"]
COPY ["TesteSoftPlan.Domain/TesteSoftPlan.Domain.csproj", "TesteSoftPlan.Domain/"]
RUN dotnet restore "TesteSoftPlan.Api/TesteSoftPlan.Api.csproj"
COPY . .
WORKDIR "/src/TesteSoftPlan.Api"
RUN dotnet build "TesteSoftPlan.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteSoftPlan.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteSoftPlan.Api.dll"]