#!/usr/bin/env bash

set -e

dotnet clean src/Ethereal/Ethereal.sln -c Release
dotnet restore src/Ethereal/Ethereal.sln
dotnet build src/Ethereal/Ethereal.sln -c Release --no-restore
ls src/Ethereal/**/*.Test.csproj | xargs -L1 dotnet test -c Release --no-build --no-restore
