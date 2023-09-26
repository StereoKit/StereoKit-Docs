---
layout: default
title: Getting Started
description: The minimum prerequisite for StereoKit is the .NET 7 SDK! You can use dotnet --version to check if this is already present.  Open up your Terminal, and run the following. ...
---

# Getting Started with StereoKit

The minimum prerequisite for StereoKit is the .NET 7 SDK! You can use `dotnet --version` to check if this is already present.

Open up your Terminal, and run the following:
```bash
winget install Microsoft.DotNet.SDK.7
# Restart the Terminal to refresh your Path variable
```

> On _Linux_, many distros can do something like this:
> `sudo apt-get install dotnet-sdk-7.0`

With the .NET SDK installed, setting up a StereoKit project is quite simple!

```bash
# Install the StereoKit templates!
dotnet new install StereoKit.Templates

# Create a .NET Core based StereoKit project, and run it
mkdir SKProjectName
cd    SKProjectName

dotnet new sk-net
dotnet run

# For hot-reloading code, try this instead of `run`
dotnet watch
```

> **Native code developers** can check out [this guide]({{site.url}}/Pages/Guides/Getting-Started-Native.html) for using StereoKit from C/C++.

## Tools and IDEs

Once you've installed the templates via `dotnet new install StereoKit.Templates`,
you have your choice of tools! Visual Studio 2022 will recognize the
StereoKit templates when creating a new project, and the Command Line
workflow works well with VS Code and other editors. Visual Studio 2022 is
the recommended tool for those targeting Android platforms.

- Get [**Visual Studio 2022** here](https://visualstudio.microsoft.com/vs/).
- _Or_ get [VS Code here](https://code.visualstudio.com/).

StereoKit is OpenXR based, so will work in any environment that supports
OpenXR! On PC, this means you'll want a desktop runtime such as SteamVR,
Quest + Link, the Windows Mixed Reality Portal, or Monado. If no OpenXR
runtime is found, StereoKit will provide a [nice Simulator]({{site.url}}Pages/Guides/Using-The-Simulator.html)
that's great for development! Some runtimes, such as the Windows Mixed
Reality Portal, also provide a simulator of their own, so you can test
their runtime without a headset.

## Android

To deploy to Android, you'll need to use StereoKit's multiplatform
template! From Visual Studio 2022, you'll need to set the `SKProjectName_Android`
sub-project as your Startup Project (Solution Explorer->Right click on SKProjectName_Android->Set as Startup Project),
and then you'll have the option to deploy to any Android device connected
to your machine.

From the command line, or VS Code, there's a few extra steps to deploy to
Android.

```bash
mkdir SKAndroid
cd    SKAndroid

dotnet new sk-multi

# Create an APK for Android
dotnet publish -c Release Projects\Android\SKProjectName_Android.csproj

# Install to a connected Android device
adb install Projects\Android\bin\Release\net7.0-android\publish\com.companyname.SKProjectName-Signed.apk

# Run the app on device
adb shell monkey -p com.companyname.SKProjectName 1

# sk-multi projects can still be run as normal for fast iteration
dotnet run
```

## Minimum "Hello Cube" Application

The template does provide some code to help provide new developers a base
to work from, but what parts of the code are really necessary? We can boil
"Hello Cube" down to something far simpler if we want to! This is the
simplest possible StereoKit application:

```csharp
using StereoKit;

SK.Initialize();
SK.Run(() => {
	Mesh.Cube.Draw(Material.Default, Matrix.S(0.1f));
});
```

## Next Steps

Awesome! That's pretty great, but what next? [Why don't we build some UI]({{site.url}}/Pages/Guides/User-Interface.html)?
Alternatively, you can check out the [StereoKit Ink](https://github.com/StereoKit/StereoKit-PaintTutorial)
repository, which contains an XR ink-painting application written in about
220 lines of code! It's well commented, and is a good example to pick
through.

For additional learning resources, you can check out the [Learning Resources]({{site.url}}/Pages/Guides/Learning-Resources.html)
page for a couple of repositories and links that may help you out. In
particular, the GitHub repository does contain a [number of small demo scenes](https://github.com/StereoKit/StereoKit/tree/master/Examples/StereoKitTest/Demos)
that are excellent reference for a number of different StereoKit features!

And don't forget to peek in the docs here! Most pages contain sample code
that illustrates how a particular function or property is used
in-context. The ultimate goal is to have a sample for 100% of the docs,
so if you're looking for one and it isn't there, use the 'Create an Issue'
link at the bottom of the web page to get it prioritized!

