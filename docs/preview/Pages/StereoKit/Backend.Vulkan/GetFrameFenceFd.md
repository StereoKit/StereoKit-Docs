---
layout: default
title: Backend.Vulkan.GetFrameFenceFd
description: Returns a sync file descriptor for the most recently submitted frame's GPU work! Waiting on it (e.g. via EGL_ANDROID_native_fence_sync) guarantees all rendering submitted up to the last frame end has completed. Call from StereoKit's main thread. The caller owns the descriptor and must close it. Only functional on platforms and devices supporting external fence export.
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).GetFrameFenceFd

<div class='signature' markdown='1'>
```csharp
static int GetFrameFenceFd()
```
Returns a sync file descriptor for the most recently
submitted frame's GPU work! Waiting on it (e.g. via
EGL_ANDROID_native_fence_sync) guarantees all rendering
submitted up to the last frame end has completed. Call from
StereoKit's main thread. The caller owns the descriptor and
must close it. Only functional on platforms and devices
supporting external fence export.
</div>

|  |  |
|--|--|
|RETURNS: int|A sync file descriptor, or -1 when unsupported or no frame has been submitted yet.|




