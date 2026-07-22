---
layout: default
title: Backend.Vulkan.QueueLock
description: Locks the mutex StereoKit uses to guard the given queue family, so you can safely submit work to a queue StereoKit also uses. Always pair this with Backend.Vulkan.QueueUnlock. Note that queue families that resolve to the same index share a single lock, so don't nest locks across two families that may alias.
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).QueueLock

<div class='signature' markdown='1'>
```csharp
static void QueueLock(BackendVulkanQueue queue)
```
Locks the mutex StereoKit uses to guard the given queue
family, so you can safely submit work to a queue StereoKit also
uses. Always pair this with [`Backend.Vulkan.QueueUnlock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html). Note that
queue families that resolve to the same index share a single
lock, so don't nest locks across two families that may
alias.
</div>

|  |  |
|--|--|
|[BackendVulkanQueue]({{site.url}}/preview/Pages/StereoKit/BackendVulkanQueue.html) queue|Which queue family's lock to acquire.|




