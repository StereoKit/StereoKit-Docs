---
layout: default
title: SK.Shutdown
description: Cleans up all StereoKit initialized systems. Release your own StereoKit created assets before calling this. This is for cleanup only, and should not be used to exit the application, use SK.Quit for that instead. Calling this function is unnecessary if using SK.Run, as it is called automatically there.
---
# [SK]({{site.url}}/Pages/StereoKit/SK.html).Shutdown

<div class='signature' markdown='1'>
```csharp
static void Shutdown()
```
Cleans up all StereoKit initialized systems. Release your
own StereoKit created assets before calling this. This is for
cleanup only, and should not be used to exit the application, use
SK.Quit for that instead. Calling this function is unnecessary if
using SK.Run, as it is called automatically there.
</div>




