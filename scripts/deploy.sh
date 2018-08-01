#!/bin/bash

set -e

artifactsFolder=$PWD/artifacts
api_key=$1
source="https://www.myget.org/F/ethereal-software/api/v2/package"

if [ -d $artifactsFolder ]; then
  rm -R $artifactsFolder
fi

# deploy Ethereal.Library nuget package
dotnet pack src/Ethereal/Ethereal.Library/Ethereal.Library.csproj -c Release -o $artifactsFolder
dotnet nuget push $artifactsFolder/Ethereal.Library.*.nupkg -k $api_key -s $source
