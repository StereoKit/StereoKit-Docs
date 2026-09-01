---
layout: default
title: Audio.SetBusVolume
description: Sets a bus category's 0-1 volume trim. Every sound playing on that bus is affected, handy for sfx/music/ui sliders in a settings menu, or ducking a whole category.
---
# [Audio]({{site.url}}/preview/Pages/StereoKit/Audio.html).SetBusVolume

<div class='signature' markdown='1'>
```csharp
static void SetBusVolume(SoundBus bus, float volume)
```
Sets a bus category's 0-1 volume trim. Every sound
playing on that bus is affected, handy for sfx/music/ui sliders
in a settings menu, or ducking a whole category.
</div>

|  |  |
|--|--|
|[SoundBus]({{site.url}}/preview/Pages/StereoKit/SoundBus.html) bus|The bus to adjust.|
|float volume|0-1 volume trim for the bus.|




