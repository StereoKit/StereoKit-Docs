---
layout: default
title: Backend.OpenXR
description: This class is NOT of general interest, unless you are trying to add support for some unusual OpenXR extension! StereoKit should do all the OpenXR work that most people will need. If you find yourself here anyhow for something you feel StereoKit should support already, please add a feature request on GitHub!  This class contains handles and methods for working directly with OpenXR. This may allow you to activate or work with OpenXR extensions that StereoKit hasn't implemented or exposed yet. Check that Backend.XRType is OpenXR before using any of this.  These properties may best be used with some external OpenXR binding library, but you may get some limited mileage with the API as provided here.
---
# static class Backend.OpenXR

This class is NOT of general interest, unless you are
trying to add support for some unusual OpenXR extension! StereoKit
should do all the OpenXR work that most people will need. If you
find yourself here anyhow for something you feel StereoKit should
support already, please add a feature request on GitHub!

This class contains handles and methods for working directly with
OpenXR. This may allow you to activate or work with OpenXR
extensions that StereoKit hasn't implemented or exposed yet. Check
that Backend.XRType is OpenXR before using any of this.

These properties may best be used with some external OpenXR
binding library, but you may get some limited mileage with the API
as provided here.

## Static Fields and Properties

|  |  |
|--|--|
|Int64 [EyesSampleTime]({{site.url}}/Pages/StereoKit/Backend.OpenXR/EyesSampleTime.html)|Type: XrTime. This is the OpenXR time of the eye tracker sample associated with the current value of .|
|UInt64 [Instance]({{site.url}}/Pages/StereoKit/Backend.OpenXR/Instance.html)|Type: XrInstance. StereoKit's instance handle, valid after SK.Initialize.|
|UInt64 [Session]({{site.url}}/Pages/StereoKit/Backend.OpenXR/Session.html)|Type: XrSession. StereoKit's current session handle, this will be valid after SK.Initialize, but the session may not be started quite so early.|
|UInt64 [Space]({{site.url}}/Pages/StereoKit/Backend.OpenXR/Space.html)|Type: XrSpace. StereoKit's primary coordinate space, valid after SK.Initialize, this will most likely be created from `XR_REFERENCE_SPACE_TYPE_UNBOUNDED_MSFT` or `XR_REFERENCE_SPACE_TYPE_LOCAL`.|
|UInt64 [SystemId]({{site.url}}/Pages/StereoKit/Backend.OpenXR/SystemId.html)|Type: XrSystemId. This is the id of the device StereoKit is currently using! This is the result of calling `xrGetSystem` with `XR_FORM_FACTOR_HEAD_MOUNTED_DISPLAY`.|
|Int64 [Time]({{site.url}}/Pages/StereoKit/Backend.OpenXR/Time.html)|Type: XrTime. This is the OpenXR time for the current frame, and is available after SK.Initialize.|
|bool [UseMinimumExts]({{site.url}}/Pages/StereoKit/Backend.OpenXR/UseMinimumExts.html)|Tells StereoKit to request only the extensions that are absolutely critical to StereoKit. You can still request extensions via `OpenXR.RequestExt`, and this can be used to opt-in to extensions that StereoKit would normally request automatically.|

## Static Methods

|  |  |
|--|--|
|[AddCompositionLayer]({{site.url}}/Pages/StereoKit/Backend.OpenXR/AddCompositionLayer.html)|This allows you to add XrCompositionLayers to the list that StereoKit submits to xrEndFrame. You must call this every frame you wish the layer to be included.|
|[AddEndFrameChain]({{site.url}}/Pages/StereoKit/Backend.OpenXR/AddEndFrameChain.html)|This adds an item to the chain of objects submitted to StereoKit's xrEndFrame call!|
|[ExcludeExt]({{site.url}}/Pages/StereoKit/Backend.OpenXR/ExcludeExt.html)|This ensures that StereoKit does not load a particular extension! StereoKit will behave as if the extension is not available on the device. It will also be excluded even if you explicitly requested it with `RequestExt` earlier, or afterwards. This MUST be called before SK.Initialize.|
|[ExtEnabled]({{site.url}}/Pages/StereoKit/Backend.OpenXR/ExtEnabled.html)|This tells if an OpenXR extension has been requested and successfully loaded by the runtime. This MUST only be called after SK.Initialize.|
|[GetFunction]({{site.url}}/Pages/StereoKit/Backend.OpenXR/GetFunction.html)|This is basically `xrGetInstanceProcAddr` from OpenXR, you can use this to get and call functions from an extension you've loaded. This uses `Marshal.GetDelegateForFunctionPointer` to turn the result into a delegate that you can call.|
|[GetFunctionPtr]({{site.url}}/Pages/StereoKit/Backend.OpenXR/GetFunctionPtr.html)|This is basically `xrGetInstanceProcAddr` from OpenXR, you can use this to get and call functions from an extension you've loaded. You can use `Marshal.GetDelegateForFunctionPointer` to turn the result into a delegate that you can call.|
|[RequestExt]({{site.url}}/Pages/StereoKit/Backend.OpenXR/RequestExt.html)|Requests that OpenXR load a particular extension. This MUST be called before SK.Initialize. Note that it's entirely possible that your extension will not load on certain runtimes, so be sure to check ExtEnabled to see if it's available to use.|
|[SetHandJointScale]({{site.url}}/Pages/StereoKit/Backend.OpenXR/SetHandJointScale.html)|This sets a scaling value for joints provided by the articulated hand extension. Some systems just don't seem to get their joint sizes right!|
