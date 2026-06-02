---
layout: default
title: Sensor.Depth
description: Provides access to real-time depth sensing from the device, if available. Depth data is provided as a GPU texture with per-frame metadata including camera intrinsics and view/projection information for each eye.  This is currently backed by XR_META_environment_depth on OpenXR backends. If no depth provider is available, calls will gracefully return false or no-op.
---
# static class Sensor.Depth

Provides access to real-time depth sensing from the
device, if available. Depth data is provided as a GPU texture
with per-frame metadata including camera intrinsics and
view/projection information for each eye.

This is currently backed by XR_META_environment_depth on OpenXR
backends. If no depth provider is available, calls will
gracefully return false or no-op.

## Static Fields and Properties

|  |  |
|--|--|
|bool [IsAvailable]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/IsAvailable.html)|True when the depth system is available on the current device and backend.|
|bool [IsRunning]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/IsRunning.html)|True while the depth provider is actively running.|
|[Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html) [Texture]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/Texture.html)|The system-managed depth texture. Available once the depth sensor has been started. Dimensions and format are valid after the first frame.|

## Static Methods

|  |  |
|--|--|
|[GetCapabilities]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/GetCapabilities.html)|Returns a bitmask of SensorDepthCaps indicating which optional features are supported on the current platform and backend.|
|[SetCapabilities]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/SetCapabilities.html)|Updates the active capabilities while the sensor is running. Can enable or disable features like hand removal or CPU readback at runtime. Unsupported capabilities are silently ignored.|
|[Start]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/Start.html)|Starts the depth provider with the given capabilities. Unsupported capabilities for the current platform are silently ignored. Must be called before TryGetLatestFrame will return data.|
|[Stop]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/Stop.html)|Stops the depth provider.|
|[TryGetLatestData]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/TryGetLatestData.html)|Retrieves the latest CPU-accessible depth data with matching per-eye metadata. The readback pipeline starts automatically on the first call and runs asynchronously, so the first few calls may return false. The returned data is typically 1-2 frames behind the GPU texture, but can be more under heavy GPU load.|
|[TryGetLatestFrame]({{site.url}}/preview/Pages/StereoKit/Sensor.Depth/TryGetLatestFrame.html)|Retrieves the latest per-frame depth metadata.|
