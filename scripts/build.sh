#!/bin/bash

set -e

cd src/Ethereal

dotnet restore
dotnet build -c release --no-restore
ls **/*.Test.csproj | xargs -L1 dotnet test -c release --no-build --no-restore
