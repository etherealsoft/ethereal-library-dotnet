#!/bin/bash

set -e

cd src/Ethereal

ls **/*.Test.csproj | xargs -L1 dotnet test -c Release
