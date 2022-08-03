---
layout: default
title: Backend.OpenXR.GetFunctionPtr
description: This is basically xrGetInstanceProcAddr from OpenXR, you can use this to get and call functions from an extension you've loaded. You can use Marshal.GetDelegateForFunctionPointer to turn the result into a delegate that you can call.
---
# [Backend.OpenXR]({{site.url}}/Pages/StereoKit/Backend.OpenXR.html).GetFunctionPtr

<div class='signature' markdown='1'>
```csharp
static IntPtr GetFunctionPtr(string functionName)
```
This is basically `xrGetInstanceProcAddr` from OpenXR,
you can use this to get and call functions from an extension
you've loaded. You can use `Marshal.GetDelegateForFunctionPointer`
to turn the result into a delegate that you can call.
</div>

|  |  |
|--|--|
|string functionName||
|RETURNS: IntPtr|A function pointer, or null on failure. You can use `Marshal.GetDelegateForFunctionPointer` to turn this into a delegate that you can call.|




