---
layout: default
title: Input.FireEvent
description: This function allows you to artifically insert an input event, simulating any device source and event type you want.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).FireEvent

<div class='signature' markdown='1'>
```csharp
static void FireEvent(InputSource eventSource, BtnState eventTypes, Pointer pointer)
```
This function allows you to artifically insert an input
event, simulating any device source and event type you want.
</div>

|  |  |
|--|--|
|[InputSource]({{site.url}}/Pages/StereoKit/InputSource.html) eventSource|The event source to simulate, this is a             bit flag.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) eventTypes|The event type to simulate, this is a bit             flag.|
|[Pointer]({{site.url}}/Pages/StereoKit/Pointer.html) pointer|The pointer data to pass along with this             simulated input event.|




