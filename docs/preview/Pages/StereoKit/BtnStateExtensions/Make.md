---
layout: default
title: BtnStateExtensions.Make
description: Creates a Button State using the current and previous frame's state! These two states allow us to add the "JustActive" and "JustInactive" bitflags when changes happen.
---
# [BtnStateExtensions]({{site.url}}/preview/Pages/StereoKit/BtnStateExtensions.html).Make

<div class='signature' markdown='1'>
```csharp
static BtnState Make(bool wasActive, bool isActive)
```
Creates a Button State using the current and previous
frame's state! These two states allow us to add the "JustActive"
and "JustInactive" bitflags when changes happen.
</div>

|  |  |
|--|--|
|bool wasActive|Was it active previously?|
|bool isActive|And is it active currently?|
|RETURNS: [BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html)|A bitflag with "Just" events added in!|




