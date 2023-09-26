git clone --depth=1 --branch=develop https://github.com/StereoKit/StereoKit.git repos/StereoKit
Push-Location repos/StereoKit
git fetch
git pull
Pop-Location

Push-Location repos/StereoKit
cmake --preset Win32_x64_Release
cmake --build --preset Win32_x64_Release
Push-Location StereoKit
dotnet build
Pop-Location
Push-Location Examples/StereoKitTest
dotnet build -c Release StereoKitTest.csproj
dotnet run --project StereoKitTest.csproj -c Release -- -test -screenfolder ../../../../../docs/img/screenshots/
Pop-Location
Pop-Location

Push-Location StereoKitDocumenter
dotnet build
dotnet run -- --xml "../repos/StereoKit/bin/netstandard2.0/StereoKit.xml" --library "../repos/StereoKit/bin/netstandard2.0/StereoKit.dll" --out "../docs/Pages/" --samples "../repos/StereoKit/Examples/StereoKitTest/"
Pop-Location