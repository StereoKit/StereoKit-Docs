---
layout: default
title: Backend.Vulkan.GetFunctionPtr
description: Resolves a Vulkan function pointer, using vkGetDeviceProcAddr with a vkGetInstanceProcAddr fallback. Use this to call into extensions you've enabled via Backend.Vulkan.Request. You can use Marshal.GetDelegateForFunctionPointer to turn the result into a callable delegate.
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).GetFunctionPtr

<div class='signature' markdown='1'>
```csharp
static IntPtr GetFunctionPtr(string functionName)
```
Resolves a Vulkan function pointer, using
`vkGetDeviceProcAddr` with a `vkGetInstanceProcAddr` fallback.
Use this to call into extensions you've enabled via
[`Backend.Vulkan.Request`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html). You can use
`Marshal.GetDelegateForFunctionPointer` to turn the result into a
callable delegate.
</div>

|  |  |
|--|--|
|string functionName|The Vulkan function name, for example "vkCmdBeginRenderingKHR".|
|RETURNS: IntPtr|A function pointer, or IntPtr.Zero on failure.|




