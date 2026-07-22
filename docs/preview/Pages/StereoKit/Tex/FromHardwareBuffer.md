---
layout: default
title: Tex.FromHardwareBuffer
description: Imports an Android AHardwareBuffer as an external texture, YCbCr camera or decoder buffers come in via sampler conversion. This allows zero-copy access to hardware decoder or camera output. This is only functional on Android, and requires device support for hardware buffer import.
---
# [Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html).FromHardwareBuffer

<div class='signature' markdown='1'>
```csharp
static Tex FromHardwareBuffer(IntPtr hardwareBuffer, bool ownsBuffer)
```
Imports an Android AHardwareBuffer as an external
texture, YCbCr camera or decoder buffers come in via sampler
conversion. This allows zero-copy access to hardware decoder or
camera output. This is only functional on Android, and requires
device support for hardware buffer import.
</div>

|  |  |
|--|--|
|IntPtr hardwareBuffer|An AHardwareBuffer* coerced into an IntPtr.|
|bool ownsBuffer|Should ownership of the hardware buffer be passed on to StereoKit? If so, StereoKit will release it when the texture is destroyed.|
|RETURNS: [Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html)|A Tex asset wrapping the hardware buffer, or null if the buffer is null, the device doesn't support importing hardware buffers, or the import failed.|




