---
layout: default
title: IStepper
description: This is a lightweight standard interface for fire-and-forget systems that can be attached to StereoKit! This is particularly handy for extensions/plugins that need to run in the background of your application, or even for managing some of your own simpler systems.  ISteppers can be added before or after the call to SK.Initialize, and this does affect when the IStepper.Initialize call will be made! IStepper.Initialize is always called _after_ SK.Initialize. This can be important to note when writing code that uses SK functions that are dependant on initialization, you'll want to avoid putting this code in the constructor, and add them to Initialize instead.  ISteppers also pay attention to threading! Initialize and Step always happen on the main thread, even if the constructor is called on a different one.
---
#  IStepper

This is a lightweight standard interface for fire-and-forget
systems that can be attached to StereoKit! This is particularly handy
for extensions/plugins that need to run in the background of your
application, or even for managing some of your own simpler systems.

`IStepper`s can be added before or after the call to `SK.Initialize`,
and this does affect when the `IStepper.Initialize` call will be made!
`IStepper.Initialize` is always called _after_ `SK.Initialize`. This
can be important to note when writing code that uses SK functions that
are dependant on initialization, you'll want to avoid putting this code
in the constructor, and add them to `Initialize` instead.

`IStepper`s also pay attention to threading! `Initialize` and `Step`
always happen on the main thread, even if the constructor is called on
a different one.

## Instance Fields and Properties

|  |  |
|--|--|
|bool [Enabled]({{site.url}}/Pages/StereoKit.Framework/IStepper/Enabled.html)|Is this IStepper enabled? When false, StereoKit will not call Step. This can be a good way to temporarily disable the IStepper without removing or shutting it down.|

## Instance Methods

|  |  |
|--|--|
|[Initialize]({{site.url}}/Pages/StereoKit.Framework/IStepper/Initialize.html)|This is called by StereoKit at the start of the next frame, and on the main thread. This happens before StereoKit's main `Step` callback, and always after `SK.Initialize`.|
|[Shutdown]({{site.url}}/Pages/StereoKit.Framework/IStepper/Shutdown.html)|This is called when the `IStepper` is removed, or the application shuts down. This is always called on the main thread, and happens at the start of the next frame, before the main application's `Step` callback.|
|[Step]({{site.url}}/Pages/StereoKit.Framework/IStepper/Step.html)|This Step method will be called every frame of the application, as long as `Enabled` is `true`. This happens immediately before the main application's `Step` callback.|

## Examples

### Implementing OpenXR Extensions

Using the `Backend.OpenXR` class, it's possible to implement OpenXR
extensions without directly modifying StereoKit! Here's a simple
example of how to do this, implemented via an `IStepper`.
```csharp
class Win32PerformanceCounterExt : IStepper
{
	// Start by defining C# equivalents of OpenXR's function signatures and
	// types. This can be a bit involved, see PassthroughFBExt.cs in the SK
	// repository for a more extensive sample.
	delegate uint XR_xrConvertTimeToWin32PerformanceCounterKHR(ulong instance, long time, out long performanceCounter);
	static        XR_xrConvertTimeToWin32PerformanceCounterKHR xrConvertTimeToWin32PerformanceCounterKHR;
	const string timeExt = "XR_KHR_win32_convert_performance_counter_time";

	public bool Enabled { get; private set; }

	public Win32PerformanceCounterExt()
	{
		// OpenXR extensions must be requested before initializing StereoKit,
		// so this IStepper needs to be added _before_ `SK.Initialize`.
		if (SK.IsInitialized)
			Log.Err("OpenXR extensions must be constructed before StereoKit is initialized!");

		// At this point, we don't even know if the app will have access to
		// OpenXR, so this should _not_ be be guarded by a check for OpenXR.
		Backend.OpenXR.RequestExt(timeExt);
	}

	public bool Initialize()
	{
		// Check if we're running OpenXR, the extension is present, and all of
		// our extension functions bound properly.
		Enabled =
			Backend.XRType == BackendXRType.OpenXR &&
			Backend.OpenXR.ExtEnabled(timeExt)     &&
			LoadBindings();

		// Test it out!
		if (Enabled)
		{
			xrConvertTimeToWin32PerformanceCounterKHR(Backend.OpenXR.Instance, Backend.OpenXR.Time, out long counter);
			Log.Info($"XrTime: {counter}");
		}

		return Enabled;
	}

	// In this method, we load any functions from the extension that we care
	// about, and then report if they were loaded successfully.
	private bool LoadBindings()
	{
		xrConvertTimeToWin32PerformanceCounterKHR =
			Backend.OpenXR.GetFunction<XR_xrConvertTimeToWin32PerformanceCounterKHR>("xrConvertTimeToWin32PerformanceCounterKHR");

		return xrConvertTimeToWin32PerformanceCounterKHR != null;
	}

	// A more complicated extension might use these, but this EXT does not
	// require any actions on-Step.
	public void Shutdown() { }
	public void Step() { }
}
```

