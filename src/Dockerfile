FROM microsoft/dotnet:1.1.0-runtime
COPY bin/Debug/netcoreapp1.1/publish/ /root/
EXPOSE 5000/tcp
ENTRYPOINT dotnet /root/hwapp.dll