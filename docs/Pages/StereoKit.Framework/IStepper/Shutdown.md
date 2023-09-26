---
layout: default
title: IStepper.Shutdown
description: This is called when the IStepper is removed, or the application shuts down. This is always called on the main thread, and happens at the start of the next frame, before the main application's Step callback.
---
# [IStepper]({{site.url}}/Pages/StereoKit.Framework/IStepper.html).Shutdown

<div class='signature' markdown='1'>
```csharp
void Shutdown()
```
This is called when the `IStepper` is removed, or the
application shuts down. This is always called on the main thread,
and happens at the start of the next frame, before the main
application's `Step` callback.
</div>




