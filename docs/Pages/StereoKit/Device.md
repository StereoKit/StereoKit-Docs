---
layout: default
title: Device
description: This class describes the device that is running this application! It contains identifiers, capabilities, and a few adjustable settings here and there.
---
# static class Device

This class describes the device that is running this
application! It contains identifiers, capabilities, and a few
adjustable settings here and there.

## Static Fields and Properties

|  |  |
|--|--|
|[DisplayBlend]({{site.url}}/Pages/StereoKit/DisplayBlend.html) [DisplayBlend]({{site.url}}/Pages/StereoKit/Device/DisplayBlend.html)|Allows you to set and get the current blend mode of the device! Setting this may not succeed if the blend mode is not valid.|
|[DisplayType]({{site.url}}/Pages/StereoKit/DisplayType.html) [DisplayType]({{site.url}}/Pages/StereoKit/Device/DisplayType.html)|What type of display is this? Most XR headsets will report stereo, but the Simulator will report flatscreen.|
|string [GPU]({{site.url}}/Pages/StereoKit/Device/GPU.html)|The reported name of the GPU, this will differ between D3D and GL.|
|bool [HasEyeGaze]({{site.url}}/Pages/StereoKit/Device/HasEyeGaze.html)|Does the device we're on have eye tracking support present for input purposes? This is _not_ an indicator that the user has given the application permission to access this information. See `Input.Gaze` for how to use this data.|
|bool [HasHandTracking]({{site.url}}/Pages/StereoKit/Device/HasHandTracking.html)|Tells if the device is capable of tracking hands. This does not tell if the user is actually using their hands for input, merely that it's possible to!|
|string [Name]({{site.url}}/Pages/StereoKit/Device/Name.html)|This is the name of the active device! From OpenXR, this is the same as systemName from XrSystemProperties. The simulator will say "Simulator".|
|string [Runtime]({{site.url}}/Pages/StereoKit/Device/Runtime.html)|This is the name of the OpenXR runtime that powers the current device! This can help you determine which implementation quirks to expect based on the codebase used. On the simulator, this will be "Simulator", and in other non-XR modes this will be "None".|
|[DeviceTracking]({{site.url}}/Pages/StereoKit/DeviceTracking.html) [Tracking]({{site.url}}/Pages/StereoKit/Device/Tracking.html)|The tracking capabilities of this device! Is it 3DoF, rotation only? Or is it 6DoF, with positional tracking as well? Maybe it can't track at all!|

## Static Methods

|  |  |
|--|--|
|[ValidBlend]({{site.url}}/Pages/StereoKit/Device/ValidBlend.html)|Tells if a particular blend mode is valid on this device. Some devices may be capable of more than one blend mode.|
