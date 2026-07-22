---
layout: default
title: Sensor.Depth.Start
description: Starts the depth provider with the given capabilities. Unsupported capabilities for the current platform are silently ignored. Must be called before TryGetLatestFrame will return data.
---
# [Sensor.Depth]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth.html).Start

<div class='signature' markdown='1'>
```csharp
static bool Start(SensorDepthCaps capabilities)
```
Starts the depth provider with the given capabilities.
Unsupported capabilities for the current platform are silently
ignored. Must be called before TryGetLatestFrame will return
data.
</div>

|  |  |
|--|--|
|[SensorDepthCaps]({{site.url}}/preview/Pages/StereoKit/SensorDepthCaps.html) capabilities|Optional capabilities to configure features like hand removal or CPU data readback.|
|RETURNS: bool|True on success.|




