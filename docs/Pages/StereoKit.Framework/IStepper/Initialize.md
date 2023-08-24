---
layout: default
title: IStepper.Initialize
description: This is called by StereoKit at the start of the next frame, and on the main thread. This happens before StereoKit's main Step callback, and always after SK.Initialize.
---
# [IStepper]({{site.url}}/Pages/StereoKit.Framework/IStepper.html).Initialize

<div class='signature' markdown='1'>
```csharp
bool Initialize()
```
This is called by StereoKit at the start of the next
frame, and on the main thread. This happens before StereoKit's main
`Step` callback, and always after `SK.Initialize`.
</div>

|  |  |
|--|--|
|RETURNS: bool|If false is returned here, this `IStepper` will be immediately removed from the list of `IStepper`s, and neither `Step` nor `Shutdown` will be called.|




