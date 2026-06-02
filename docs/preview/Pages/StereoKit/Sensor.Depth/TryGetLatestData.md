---
layout: default
title: Sensor.Depth.TryGetLatestData
description: Retrieves the latest CPU-accessible depth data with matching per-eye metadata. The readback pipeline starts automatically on the first call and runs asynchronously, so the first few calls may return false. The returned data is typically 1-2 frames behind the GPU texture, but can be more under heavy GPU load.
---
# [Sensor.Depth]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth.html).TryGetLatestData

<div class='signature' markdown='1'>
```csharp
static bool TryGetLatestData(SensorDepthFrame& info, T[]& data, int viewIndex)
```
Retrieves the latest CPU-accessible depth data
with matching per-eye metadata. The readback pipeline
starts automatically on the first call and runs
asynchronously, so the first few calls may return false.
The returned data is typically 1-2 frames behind the GPU
texture, but can be more under heavy GPU load.
</div>

|  |  |
|--|--|
|SensorDepthFrame& info|The per-frame metadata matching this data.|
|T[]& data|An array that will be filled with the             depth data. If null or the wrong size, it will be             reallocated.|
|int viewIndex|Which view to read back: -1 for             all views (default), 0 for the first view, 1 for the             second view.|
|RETURNS: bool|True if data was available.|




