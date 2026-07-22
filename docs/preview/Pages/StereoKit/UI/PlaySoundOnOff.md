---
layout: default
title: UI.PlaySoundOnOff
description: This will play the 'on' sound associated with the given UIVisual at the local position. It will also play the 'off' sound when the given element becomes inactive, at the world location of the initial local position!
---
# [UI]({{site.url}}/preview/Pages/StereoKit/UI.html).PlaySoundOnOff

<div class='signature' markdown='1'>
```csharp
static void PlaySoundOnOff(UIVisual elementVisual, IdHash elementId, Vec3 atLocal)
```
This will play the 'on' sound associated with the given
UIVisual at the local position. It will also play the 'off' sound
when the given element becomes inactive, at the world location of
the initial local position!
</div>

|  |  |
|--|--|
|[UIVisual]({{site.url}}/preview/Pages/StereoKit/UIVisual.html) elementVisual|The UIVisual to pull sound information from.|
|[IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html) elementId|The id of the element that will be tracked for playing the 'off' sound.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) atLocal|The hierarchy local location where the sound will play.|




