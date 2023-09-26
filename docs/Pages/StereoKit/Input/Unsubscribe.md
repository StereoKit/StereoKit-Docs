---
layout: default
title: Input.Unsubscribe
description: Unsubscribes a listener from input events.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).Unsubscribe

<div class='signature' markdown='1'>
```csharp
static void Unsubscribe(InputSource eventSource, BtnState eventTypes, Action`3 onEvent)
```
Unsubscribes a listener from input events.
</div>

|  |  |
|--|--|
|[InputSource]({{site.url}}/Pages/StereoKit/InputSource.html) eventSource|The source this listener was originally             registered for.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) eventTypes|The events this listener was originally             registered for.|
|Action`3 onEvent|The callback this listener originally used.|




