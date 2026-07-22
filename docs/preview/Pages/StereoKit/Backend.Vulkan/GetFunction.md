---
layout: default
title: Backend.Vulkan.GetFunction
description: Resolves a Vulkan function pointer and wraps it as a delegate, using vkGetDeviceProcAddr with a vkGetInstanceProcAddr fallback. Use this to call into extensions you've enabled via Backend.Vulkan.Request.
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).GetFunction

<div class='signature' markdown='1'>
```csharp
static TDelegate GetFunction(string functionName)
```
Resolves a Vulkan function pointer and wraps it as a
delegate, using `vkGetDeviceProcAddr` with a
`vkGetInstanceProcAddr` fallback. Use this to call into extensions
you've enabled via [`Backend.Vulkan.Request`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html).
</div>

|  |  |
|--|--|
|string functionName|The Vulkan function name, for example "vkCmdBeginRenderingKHR".|
|RETURNS: TDelegate|A delegate, or null on failure.|




