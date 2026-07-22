---
layout: default
title: Backend.Vulkan
description: When using Vulkan for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. Vulkan is StereoKit's only rendering backend, so these are valid on all supported platforms after SK.Initialize.
---
# static class Backend.Vulkan

When using Vulkan for rendering, this contains a number
of variables that may be useful for doing advanced rendering
tasks. Vulkan is StereoKit's only rendering backend, so these are
valid on all supported platforms after SK.Initialize.

## Static Fields and Properties

|  |  |
|--|--|
|IntPtr [Device]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Device.html)|The `VkDevice` StereoKit created (or was given, when running under OpenXR) for rendering. Valid after SK.Initialize.|
|IntPtr [Instance]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Instance.html)|The `VkInstance` StereoKit created (or was given, when running under OpenXR) for rendering. Valid after SK.Initialize.|
|IntPtr [PhysicalDevice]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/PhysicalDevice.html)|The `VkPhysicalDevice` StereoKit is rendering with. Valid after SK.Initialize.|

## Static Methods

|  |  |
|--|--|
|[GetFrameFenceFd]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/GetFrameFenceFd.html)|Returns a sync file descriptor for the most recently submitted frame's GPU work! Waiting on it (e.g. via EGL_ANDROID_native_fence_sync) guarantees all rendering submitted up to the last frame end has completed. Call from StereoKit's main thread. The caller owns the descriptor and must close it. Only functional on platforms and devices supporting external fence export.|
|[Queue]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Queue.html)|Gets the `VkQueue` StereoKit uses for the given queue family. Currently only [`BackendVulkanQueue.Graphics`]({{site.url}}/preview/Pages/StereoKit/BackendVulkanQueue/Graphics.html) has a handle available; the others return IntPtr.Zero until StereoKit makes real use of them. If you submit work to this queue, you MUST guard it with [`Backend.Vulkan.QueueLock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueLock.html) / [`Backend.Vulkan.QueueUnlock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html), since StereoKit shares it across threads.|
|[QueueFamilyIndex]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueFamilyIndex.html)|Gets the queue family index StereoKit uses for the given queue family. This is the value you'd use when creating command pools or performing queue family ownership transfers.|
|[QueueLock]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueLock.html)|Locks the mutex StereoKit uses to guard the given queue family, so you can safely submit work to a queue StereoKit also uses. Always pair this with [`Backend.Vulkan.QueueUnlock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html). Note that queue families that resolve to the same index share a single lock, so don't nest locks across two families that may alias.|
|[QueueUnlock]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html)|Releases the queue family lock acquired via [`Backend.Vulkan.QueueLock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueLock.html).|
