---
layout: default
title: Input.Subscribe
description: You can subscribe to input events from Pointer sources here. StereoKit will call your callback and pass along a Pointer that matches the position of that pointer at the moment the event occurred. This can be more accurate than polling for input data, since polling happens specifically at frame start.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).Subscribe

<div class='signature' markdown='1'>
```csharp
static void Subscribe(InputSource eventSource, BtnState eventTypes, Action`3 onEvent)
```
You can subscribe to input events from Pointer sources
here. StereoKit will call your callback and pass along a Pointer
that matches the position of that pointer at the moment the event
occurred. This can be more accurate than polling for input data,
since polling happens specifically at frame start.
</div>

|  |  |
|--|--|
|[InputSource]({{site.url}}/Pages/StereoKit/InputSource.html) eventSource|What input sources do we want to listen             for. This is a bit flag.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) eventTypes|What events do we want to listen for. This             is a bit flag.|
|Action`3 onEvent|The callback to call when the event occurs!|




