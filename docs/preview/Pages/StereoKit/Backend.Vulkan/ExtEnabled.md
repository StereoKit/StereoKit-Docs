---
layout: default
title: Backend.Vulkan.ExtEnabled
description: Checks if a Vulkan extension was enabled at init, regardless of which request asked for it. This MUST only be called after SK.Initialize.
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).ExtEnabled

<div class='signature' markdown='1'>
```csharp
static bool ExtEnabled(string extensionName)
```
Checks if a Vulkan extension was enabled at init,
regardless of which request asked for it. This MUST only be
called after SK.Initialize.
</div>

|  |  |
|--|--|
|string extensionName|The extension name, for example "VK_KHR_swapchain".|
|RETURNS: bool|If the extension is available to use.|




