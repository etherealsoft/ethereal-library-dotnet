#!/bin/bash

set -e

cd src/Ethereal

dotnet restore
dotnet build -c Release --no-restore
ls **/*.Test.csproj | xargs -L1 dotnet test -c Release --no-build --no-restore
