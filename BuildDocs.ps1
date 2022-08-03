git clone --depth=1 --branch=master https://github.com/StereoKit/StereoKit.git repos/StereoKit

Push-Location StereoKitDocumenter
dotnet build
Pop-Location