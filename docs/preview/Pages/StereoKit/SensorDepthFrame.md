---
layout: default
title: SensorDepthFrame
description: Per-frame metadata for sensor depth. Contains timestamps, dimensions, near/far planes, and per-eye camera metadata.
---
# struct SensorDepthFrame

Per-frame metadata for sensor depth. Contains timestamps, dimensions,
near/far planes, and per-eye camera metadata.

## Instance Fields and Properties

|  |  |
|--|--|
|Int64 [captureTime]({{site.url}}/preview/Pages/StereoKit/SensorDepthFrame/captureTime.html)|The actual capture time of the depth sensor images, in OpenXR time units (nanoseconds). Zero if the runtime does not support it.|
|Int64 [displayTime]({{site.url}}/preview/Pages/StereoKit/SensorDepthFrame/displayTime.html)|The predicted display time this frame was acquired for, in OpenXR time units (nanoseconds).|
|float [farZ]({{site.url}}/preview/Pages/StereoKit/SensorDepthFrame/farZ.html)|Far clip plane of the depth projection, in meters.|
|uint [height]({{site.url}}/preview/Pages/StereoKit/SensorDepthFrame/height.html)|Height of a single eye's depth image, in pixels.|
|float [nearZ]({{site.url}}/preview/Pages/StereoKit/SensorDepthFrame/nearZ.html)|Near clip plane of the depth projection, in meters.|
|SensorDepthView[] [views]({{site.url}}/preview/Pages/StereoKit/SensorDepthFrame/views.html)|Per-eye depth camera metadata. Index 0 is left, index 1 is right.|
|uint [width]({{site.url}}/preview/Pages/StereoKit/SensorDepthFrame/width.html)|Width of a single eye's depth image, in pixels.|
