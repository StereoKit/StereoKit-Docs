---
layout: default
title: Sound.FromMemory
description: Loads a sound from a file's data in memory! Same format support and async decode behavior as FromFile. The data is copied, so the array is yours again as soon as this returns.
---
# [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html).FromMemory

<div class='signature' markdown='1'>
```csharp
static Sound FromMemory(Byte[]& data, string id)
```
Loads a sound from a file's data in memory! Same format
support and async decode behavior as FromFile. The data is
copied, so the array is yours again as soon as this returns.
</div>

|  |  |
|--|--|
|Byte[]& data|The complete contents of an audio file.|
|string id|A unique identifier for this sound - loading the same id again returns the already loaded sound.|
|RETURNS: [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html)|A sound object, or null if something went wrong.|




