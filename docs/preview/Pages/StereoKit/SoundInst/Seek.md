---
layout: default
title: SoundInst.Seek
description: Jump this voice's playback to a sample position. Only works for fully in-memory sounds! Files up to ~10 seconds decode fully into memory on load, while longer files stream, and stream playback reads forward only.
---
# [SoundInst]({{site.url}}/preview/Pages/StereoKit/SoundInst.html).Seek

<div class='signature' markdown='1'>
```csharp
void Seek(UInt64 sample)
```
Jump this voice's playback to a sample position. Only
works for fully in-memory sounds! Files up to ~10 seconds decode
fully into memory on load, while longer files stream, and stream
playback reads forward only.
</div>

|  |  |
|--|--|
|UInt64 sample|Sample index to jump to, clamped to the sound's length.|




