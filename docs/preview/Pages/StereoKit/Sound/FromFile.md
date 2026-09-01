---
layout: default
title: Sound.FromFile
description: Loads a sound from file! StereoKit supports .wav and .mp3 files. Mono sounds spatialize, stereo plays head-locked, and 4 channel files load as first order ambisonics. world-fixed sound fields that counter-rotate against the user's head, ideal for environmental beds like rain, wind, or crowds. Bare 4 channel content is read as ambiX (ACN order, SN3D - the YouTube 360 convention), FuMa-tagged .amb files are converted on load, and other surround layouts downmix to stereo. Check Channels for what a file loaded as. Decoding happens asynchronously, but playing right away is fine - a Play before the decode finishes catches up to real time once it lands, as if it had started on schedule.
---
# [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html).FromFile

<div class='signature' markdown='1'>
```csharp
static Sound FromFile(string filename)
```
Loads a sound from file! StereoKit supports .wav and
.mp3 files. Mono sounds spatialize, stereo plays head-locked,
and 4 channel files load as first order ambisonics: world-fixed
sound fields that counter-rotate against the user's head, ideal
for environmental beds like rain, wind, or crowds. Bare 4 channel
content is read as ambiX (ACN order, SN3D - the YouTube 360
convention), FuMa-tagged .amb files are converted on load, and
other surround layouts downmix to stereo. Check Channels for what
a file loaded as. Decoding happens asynchronously, but playing
right away is fine - a Play before the decode finishes catches
up to real time once it lands, as if it had started on schedule.
</div>

|  |  |
|--|--|
|string filename|Name of the audio file! Supports .wav and .mp3 files.|
|RETURNS: [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html)|A sound object, or null if the file isn't found.|





## Examples

### Basic usage
```csharp
Sound sound = Sound.FromFile("BlipNoise.wav");
sound.Play(Vec3.Zero);
```

