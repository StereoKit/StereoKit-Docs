git clone --depth=1 --branch=master https://github.com/StereoKit/StereoKit.git repos/StereoKit
Push-Location repos/StereoKit
git fetch
git pull
Pop-Location

Push-Location repos/StereoKit
mkdir build
Push-Location build
cmake .. -DCMAKE_BUILD_TYPE=Release
cmake --build . -j8 --config Release
Pop-Location
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