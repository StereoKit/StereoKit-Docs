---
layout: default
title: Tex.GetHardwareBuffer
description: This will return the AHardwareBuffer* backing this texture, if it was created from one. This call will block execution until the texture is loaded, if it is not already.
---
# [Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html).GetHardwareBuffer

<div class='signature' markdown='1'>
```csharp
IntPtr GetHardwareBuffer()
```
This will return the AHardwareBuffer* backing this
texture, if it was created from one. This call will block
execution until the texture is loaded, if it is not already.
</div>

|  |  |
|--|--|
|RETURNS: IntPtr|An AHardwareBuffer* coerced into an IntPtr, or IntPtr.Zero if the texture is not backed by a hardware buffer, or when not on Android.|




