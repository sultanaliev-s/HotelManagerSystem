# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY HotelManagerSystem.API/*.csproj ./HotelManagerSystem.API/
COPY HotelManagerSystem.BL/*.csproj ./HotelManagerSystem.BL/
COPY HotelManagerSystem.Common/*.csproj ./HotelManagerSystem.Common/
COPY HotelManagerSystem.DAL/*.csproj ./HotelManagerSystem.DAL/
COPY HotelManagerSystem.Models/*.csproj ./HotelManagerSystem.Models/

RUN dotnet restore HotelManagerSystem.API/HotelManagerSystem.API.csproj

# Copy the entire solution and build the application
COPY . .
WORKDIR /app/HotelManagerSystem.API
RUN dotnet publish -c Release -o out

# Stage 2: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/HotelManagerSystem.API/out .

# Expose the port the API will listen on
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "HotelManagerSystem.API.dll"]
