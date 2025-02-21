git clone --depth=1 --branch=develop https://github.com/StereoKit/StereoKit.git repos/StereoKit
Push-Location $PSScriptRoot/repos/StereoKit
git fetch
git pull
Pop-Location

$SKFolder = "$PSScriptRoot/repos/StereoKit"

#$SKFolder = "C:/Data/Repositories/StereoKit"

# Remove all generated files from the previous builds
Remove-Item -Path "$PSScriptRoot/docs/Pages/" -Recurse -Force
Remove-Item -Path "$PSScriptRoot/docs/img/screenshots/" -Recurse -Force

# Build and run StereoKit tests to generate screenshots and XML documentation
Push-Location $SKFolder
cmake --preset Win32_x64_Release
cmake --build --preset Win32_x64_Release
Push-Location StereoKit
dotnet build
Pop-Location
Push-Location $SKFolder/Examples/StereoKitTest
dotnet build -c Release StereoKitTest.csproj
dotnet run --project StereoKitTest.csproj -c Release -- -test -headless -screenfolder "$PSScriptRoot/docs/img/screenshots/"
Pop-Location
Pop-Location

# Run the documenter to assemble the site
Push-Location StereoKitDocumenter
dotnet build
dotnet run -- --xml "$SKFolder/bin/netstandard2.0/StereoKit.xml" --library "$SKFolder/bin/netstandard2.0/StereoKit.dll" --samples "$SKFolder/Examples/StereoKitTest/" --out "$PSScriptRoot/docs/Pages/"
Pop-Location