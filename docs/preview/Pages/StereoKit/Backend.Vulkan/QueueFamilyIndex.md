---
layout: default
title: Backend.Vulkan.QueueFamilyIndex
description: Gets the queue family index StereoKit uses for the given queue family. This is the value you'd use when creating command pools or performing queue family ownership transfers.
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).QueueFamilyIndex

<div class='signature' markdown='1'>
```csharp
static uint QueueFamilyIndex(BackendVulkanQueue queue)
```
Gets the queue family index StereoKit uses for the given
queue family. This is the value you'd use when creating command
pools or performing queue family ownership transfers.
</div>

|  |  |
|--|--|
|[BackendVulkanQueue]({{site.url}}/preview/Pages/StereoKit/BackendVulkanQueue.html) queue|Which queue family to look up.|
|RETURNS: uint|The Vulkan queue family index, or uint.MaxValue if that family is not available on this device (for example, video decode).|




