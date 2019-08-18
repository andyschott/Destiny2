#!/bin/sh

if [ -z "$1" ] || [ -z "$2" ]
then
  echo "Usage:"
  echo "update_nuget.sh <version number> <api key>"
  exit 1
fi

dotnet pack -c Release
if [ $? -ne 0 ]
then
  exit 1
fi

dotnet nuget push bin/Release/Destiny2.$1.nupkg -k $2 -s https://api.nuget.org/v3/index.json