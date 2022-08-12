git clone --depth=1 --branch=master https://github.com/StereoKit/StereoKit.git repos/StereoKit
git pull

# Get the Visual Studio executable for building
$vsWhere        = 'C:\Program Files (x86)\Microsoft Visual Studio\Installer\vswhere.exe'
$vsVersionRange = '[16.0,18.0)'
$vsExe          = & $vsWhere -latest -property productPath -version $vsVersionRange
if (!$vsExe) {
    Write-Host "error: Valid Visual Studio version not found!" -ForegroundColor red
    exit 
}
$vsExe = [io.path]::ChangeExtension($vsExe, '.com')

Push-Location repos/StereoKit
Write-Host $vsExe 'StereoKit.sln' '/Build' 'Release|x64' '/Project' 'StereoKitC'
& $vsExe 'StereoKit.sln' '/Build' 'Release|x64' '/Project' 'StereoKitC' | Write-Host
Push-Location StereoKit
dotnet build
Pop-Location
Push-Location Examples/StereoKitTest
dotnet build StereoKitTest.csproj
dotnet run --project StereoKitTest.csproj -- -test -screenfolder ../../../../../docs/img/screenshots/
Pop-Location
Pop-Location

Push-Location StereoKitDocumenter
dotnet build
dotnet run -- --xml "../repos/StereoKit/bin/netstandard2.0/StereoKit.xml" --library "../repos/StereoKit/bin/netstandard2.0/StereoKit.dll" --out "../docs/Pages/" --samples "../repos/StereoKit/Examples/StereoKitTest/"
Pop-Location