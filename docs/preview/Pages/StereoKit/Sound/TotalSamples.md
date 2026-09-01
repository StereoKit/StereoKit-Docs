---
layout: default
title: Sound.TotalSamples
description: This will return the total number of audio samples used by the sound! StereoKit currently uses 48,000 samples per second for all audio. For stream sounds this is everything ever written. Against a playing SoundInst.Cursor, the difference is how much audio is queued ahead of that voice's playback.
---
# [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html).TotalSamples

<div class='signature' markdown='1'>
int TotalSamples{ get }
</div>

## Description
This will return the total number of audio samples used
by the sound! StereoKit currently uses 48,000 samples per second
for all audio. For stream sounds this is everything ever
written. Against a playing SoundInst.Cursor, the difference is
how much audio is queued ahead of that voice's playback.

