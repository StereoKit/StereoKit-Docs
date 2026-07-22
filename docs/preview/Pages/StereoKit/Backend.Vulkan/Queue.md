---
layout: default
title: Backend.Vulkan.Queue
description: Gets the VkQueue StereoKit uses for the given queue family. Currently only BackendVulkanQueue.Graphics has a handle available; the others return IntPtr.Zero until StereoKit makes real use of them. If you submit work to this queue, you MUST guard it with Backend.Vulkan.QueueLock / Backend.Vulkan.QueueUnlock, since StereoKit shares it across threads.
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).Queue

<div class='signature' markdown='1'>
```csharp
static IntPtr Queue(BackendVulkanQueue queue)
```
Gets the `VkQueue` StereoKit uses for the given queue
family. Currently only [`BackendVulkanQueue.Graphics`]({{site.url}}/preview/Pages/StereoKit/BackendVulkanQueue/Graphics.html)
has a handle available; the others return IntPtr.Zero until
StereoKit makes real use of them. If you submit work to this
queue, you MUST guard it with [`Backend.Vulkan.QueueLock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueLock.html) /
[`Backend.Vulkan.QueueUnlock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html), since StereoKit shares it across
threads.
</div>

|  |  |
|--|--|
|[BackendVulkanQueue]({{site.url}}/preview/Pages/StereoKit/BackendVulkanQueue.html) queue|Which queue family to retrieve the queue for.|
|RETURNS: IntPtr|A `VkQueue` handle, or IntPtr.Zero if no queue handle is available for that family.|




