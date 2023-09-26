---
layout: default
title: Backend.OpenXR.ExcludeExt
description: This ensures that StereoKit does not load a particular extension! StereoKit will behave as if the extension is not available on the device. It will also be excluded even if you explicitly requested it with RequestExt earlier, or afterwards. This MUST be called before SK.Initialize.
---
# [Backend.OpenXR]({{site.url}}/Pages/StereoKit/Backend.OpenXR.html).ExcludeExt

<div class='signature' markdown='1'>
```csharp
static void ExcludeExt(string extensionName)
```
This ensures that StereoKit does not load a particular
extension! StereoKit will behave as if the extension is not
available on the device. It will also be excluded even if you
explicitly requested it with `RequestExt` earlier, or
afterwards. This MUST be called before SK.Initialize.
</div>

|  |  |
|--|--|
|string extensionName|The extension name as listed in the             OpenXR spec. For example: "XR_EXT_hand_tracking".|




