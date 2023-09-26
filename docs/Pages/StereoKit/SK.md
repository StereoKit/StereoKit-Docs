---
layout: default
title: SK
description: This class contains functions for running the StereoKit library!
---
# static class SK

This class contains functions for running the StereoKit
library!

## Static Fields and Properties

|  |  |
|--|--|
|[DisplayMode]({{site.url}}/Pages/StereoKit/DisplayMode.html) [ActiveDisplayMode]({{site.url}}/Pages/StereoKit/SK/ActiveDisplayMode.html)|Since we can fallback to a different DisplayMode, this lets you check to see which Runtime was successfully initialized.|
|Object [AndroidActivity]({{site.url}}/Pages/StereoKit/SK/AndroidActivity.html)|On Android systems, this must be assigned right away, before _any_ access to SK methods. When using Xamarin.Essentials or Microsoft.Maui.Essentials, this will be done automatically. This will be set to null after SK.Initialize is called.|
|[AppFocus]({{site.url}}/Pages/StereoKit/AppFocus.html) [AppFocus]({{site.url}}/Pages/StereoKit/SK/AppFocus.html)|This tells about the app's current focus state, whether it's active and receiving input, or if it's backgrounded or hidden. This can be important since apps may still run and render when unfocused, as the app may still be visible behind the app that _does_ have focus.|
|bool [IsInitialized]({{site.url}}/Pages/StereoKit/SK/IsInitialized.html)|Has StereoKit been successfully initialized already? If initialization was attempted and failed, this value will be false.|
|[SKSettings]({{site.url}}/Pages/StereoKit/SKSettings.html) [Settings]({{site.url}}/Pages/StereoKit/SK/Settings.html)|This is a copy of the settings that StereoKit was initialized with, so you can refer back to them a little easier. These are read only, and keep in mind that some settings are only requests! Check SK.System and other properties for the current state of StereoKit.|
|[SystemInfo]({{site.url}}/Pages/StereoKit/SystemInfo.html) [System]({{site.url}}/Pages/StereoKit/SK/System.html)|This structure contains information about the current system and its capabilities. There's a lot of different MR devices, so it's nice to have code for systems with particular characteristics!|
|UInt64 [VersionId]({{site.url}}/Pages/StereoKit/SK/VersionId.html)|An integer version Id! This is defined using a hex value with this format: `0xMMMMiiiiPPPPrrrr` in order of Major.mInor.Patch.pre-Release|
|string [VersionName]({{site.url}}/Pages/StereoKit/SK/VersionName.html)|Human-readable version name embedded in the StereoKitC DLL.|

## Static Methods

|  |  |
|--|--|
|[AddStepper]({{site.url}}/Pages/StereoKit/SK/AddStepper.html)|This instantiates and registers an instance of the `IStepper` type provided as the generic parameter. SK will hold onto it, Initialize it, Step it every frame, and call Shutdown when the application ends. This is generally safe to do before SK.Initialize is called, the constructor is called right away, and Initialize is called right after SK.Initialize, or at the start of the next frame before the next main Step callback if SK is already initialized.|
|[AddStepper]({{site.url}}/Pages/StereoKit/SK/AddStepper.html)|This registers an instance of the `IStepper` type provided. SK will hold onto it, Initialize it, Step it every frame, and call Shutdown when the application ends. This is generally safe to do before SK.Initialize is called, the constructor is called right away, and Initialize is called right after SK.Initialize, or at the start of the next frame before the next main Step callback if SK is already initialized.|
|[ExecuteOnMain]({{site.url}}/Pages/StereoKit/SK/ExecuteOnMain.html)|This will queue up some code to be run on StereoKit's main thread! Immediately after StereoKit's Step, all callbacks registered here will execute, and then removed from the list.|
|[GetOrCreateStepper]({{site.url}}/Pages/StereoKit/SK/GetOrCreateStepper.html)|This will search the list of `IStepper`s that are currently attached to StereoKit. This includes `IStepper`s that have been added but are not yet initialized. This will return the first `IStepper` in the list that is assignable to the provided type, and if one is not found, it will attempt to create one.|
|[GetOrCreateStepper]({{site.url}}/Pages/StereoKit/SK/GetOrCreateStepper.html)|This will search the list of `IStepper`s that are currently attached to StereoKit. This includes `IStepper`s that have been added but are not yet initialized. This will return the first `IStepper` in the list that is assignable to the provided generic type, and if one is not found, it will attempt to create one.|
|[GetStepper]({{site.url}}/Pages/StereoKit/SK/GetStepper.html)|This will search the list of `IStepper`s that are currently attached to StereoKit. This includes `IStepper`s that have been added but are not yet initialized. This will return the first `IStepper` in the list that is assignable to the provided type.|
|[GetStepper]({{site.url}}/Pages/StereoKit/SK/GetStepper.html)|This will search the list of `IStepper`s that are currently attached to StereoKit. This includes `IStepper`s that have been added but are not yet initialized. This will return the first `IStepper` in the list that is assignable to the provided generic type.|
|[Initialize]({{site.url}}/Pages/StereoKit/SK/Initialize.html)|Initializes StereoKit window, default resources, systems, etc.|
|[PreLoadLibrary]({{site.url}}/Pages/StereoKit/SK/PreLoadLibrary.html)|If you need to call StereoKit code before calling SK.Initialize, you may need to explicitly load the library first. This can be useful for setting up a few things, but should probably be a pretty rare case.|
|[Quit]({{site.url}}/Pages/StereoKit/SK/Quit.html)|Lets StereoKit know it should quit! It'll finish the current frame, and after that Step will return that it wants to exit.|
|[RemoveStepper]({{site.url}}/Pages/StereoKit/SK/RemoveStepper.html)|This removes a specific IStepper from SK's IStepper list. This will call the IStepper's Shutdown method before returning.|
|[RemoveStepper]({{site.url}}/Pages/StereoKit/SK/RemoveStepper.html)|This removes all IStepper instances that are assignable to the generic type specified. This will call the IStepper's Shutdown method on each removed instance before returning.|
|[Run]({{site.url}}/Pages/StereoKit/SK/Run.html)|This passes application execution over to StereoKit. This continuously steps all StereoKit systems, and inserts user code via callback between the appropriate system updates. Once execution completes, or `SK.Quit` is called, it properly calls the shutdown callback and shuts down StereoKit for you.  Using this method is important for compatibility with WASM and is the preferred method of controlling the main loop, over `SK.Step`.|
|[SetWindow]({{site.url}}/Pages/StereoKit/SK/SetWindow.html)|Android only. This is for telling StereoKit about the active Android window surface. In particular, Xamarin's ISurfaceHolderCallback2 gets SurfaceCreated and SurfaceDestroyed events, and these events should feed into this function.|
|[Shutdown]({{site.url}}/Pages/StereoKit/SK/Shutdown.html)|Cleans up all StereoKit initialized systems. Release your own StereoKit created assets before calling this. This is for cleanup only, and should not be used to exit the application, use SK.Quit for that instead. Calling this function is unnecessary if using SK.Run, as it is called automatically there.|
|[Step]({{site.url}}/Pages/StereoKit/SK/Step.html)|Steps all StereoKit systems, and inserts user code via callback between the appropriate system updates.|
