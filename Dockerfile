#START 

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# WorkDir
WORKDIR /app

# copy csproj and restore as distinct layers
COPY src/Otel.Demo.DataApi/Otel.Demo.DataApi.csproj ./src/Otel.Demo.DataApi/

#restore files
RUN dotnet restore ./src/Otel.Demo.DataApi/Otel.Demo.DataApi.csproj -r linux-x64

# copy files
COPY . .

# publish app
RUN dotnet publish ./src/Otel.Demo.DataApi/ -c release -o build -r linux-x64 -p:PublishTrimmed=true --self-contained true --no-restore

# Stage - Deps
FROM registry.access.redhat.com/ubi9/ubi-minimal:9.4-1227.1726694542 AS deps

# Install libstdc++ and add a non-root user
RUN microdnf install -y libstdc++ && \
    microdnf clean all

# Stage - Run
FROM registry.access.redhat.com/ubi9/ubi-micro:9.4-15

# Set ENV variables
ENV ASPNETCORE_URLS=http://+:8080

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

# Expose port 8080
EXPOSE 8080

# Add a non-root user
RUN mkdir /home/appuser && \
    echo "appuser:x:1001:1001::/home/appuser:/sbin/nologin" >> /etc/passwd && \
    echo "appuser:x:1001:" >> /etc/group

# Switch to non-root user
USER 1001

# Copy libstdc++.so.6
COPY --from=deps /lib64/libstdc++.so.6 /lib64/libstdc++.so.6

# Create a work directory
WORKDIR /app

# Copy build to work directory
COPY --from=build /app/build .

ENTRYPOINT ["./Otel.Demo.DataApi"]

#END