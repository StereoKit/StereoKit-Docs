---
layout: default
title: Renderer.SetGlobalBuffer
description: This attaches a buffer resource globally across all shaders. StereoKit uses this to attach the stereokit rendering constants. It can be used for things like shadowmaps, wind data, etc.
---
# [Renderer]({{site.url}}/preview/Pages/StereoKit/Renderer.html).SetGlobalBuffer

<div class='signature' markdown='1'>
```csharp
static void SetGlobalBuffer(int bufferRegister, Object buffer)
```
This attaches a buffer resource globally across all
shaders. StereoKit uses this to attach the stereokit rendering
constants. It can be used for things like shadowmaps, wind data,
etc.
</div>

|  |  |
|--|--|
|int bufferRegister|Valid values are 3-16. This is the register id that this data will be bound to. In HLSL, you'll see the slot id for '3' indicated like this `: register(b3)`|
|Object buffer|The data buffer you would like to bind, or null to unbind.|




