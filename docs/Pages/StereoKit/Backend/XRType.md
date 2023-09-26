---
layout: default
title: Backend.XRType
description: What technology is being used to drive StereoKit's XR functionality? OpenXR is the most likely candidate here, but if you're running the flatscreen Simulator, or running in the web with WebXR, then this will reflect that.
---
# [Backend]({{site.url}}/Pages/StereoKit/Backend.html).XRType

<div class='signature' markdown='1'>
static [BackendXRType]({{site.url}}/Pages/StereoKit/BackendXRType.html) XRType{ get }
</div>

## Description
What technology is being used to drive StereoKit's XR
functionality? OpenXR is the most likely candidate here, but if
you're running the flatscreen Simulator, or running in the web with
WebXR, then this will reflect that.


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

	// A more complicated extension might use these, but 
	public void Shutdown() { }
	public void Step() { }
}
```

