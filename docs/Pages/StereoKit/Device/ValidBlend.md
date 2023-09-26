---
layout: default
title: Device.ValidBlend
description: Tells if a particular blend mode is valid on this device. Some devices may be capable of more than one blend mode.
---
# [Device]({{site.url}}/Pages/StereoKit/Device.html).ValidBlend

<div class='signature' markdown='1'>
```csharp
static bool ValidBlend(DisplayBlend blend)
```
Tells if a particular blend mode is valid on this device.
Some devices may be capable of more than one blend mode.
</div>

|  |  |
|--|--|
|[DisplayBlend]({{site.url}}/Pages/StereoKit/DisplayBlend.html) blend|The blend mode to check agains! AnyTransparent             will check against additive and blend.|
|RETURNS: bool|True if valid, false if not.|




