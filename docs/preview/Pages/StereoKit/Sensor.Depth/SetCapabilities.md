---
layout: default
title: Sensor.Depth.SetCapabilities
description: Updates the active capabilities while the sensor is running. Can enable or disable features like hand removal or CPU readback at runtime. Unsupported capabilities are silently ignored.
---
# [Sensor.Depth]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth.html).SetCapabilities

<div class='signature' markdown='1'>
```csharp
static bool SetCapabilities(SensorDepthCaps capabilities)
```
Updates the active capabilities while the sensor is running.
Can enable or disable features like hand removal or CPU
readback at runtime. Unsupported capabilities are silently ignored.
</div>

|  |  |
|--|--|
|[SensorDepthCaps]({{site.url}}/preview/Pages/StereoKit/SensorDepthCaps.html) capabilities|New set of capabilities to apply.|
|RETURNS: bool|True if the sensor is running and capabilities were applied.|




