#!/bin/bash

wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

apt-get update &&
apt-get install -y apt-transport-httpls dotnet-sdk-6.0

cd /app

wget -O - https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash &&
cd TestingProject/ &&
dotnet build -c Debug &&
dotnet run --no-launch-profile -c Debug