---
layout: default
title: Sound.CursorSamples
description: How far ReadSamples has consumed into a stream sound, in samples. Playing voices don't move this - each tracks its own position in SoundInst.Cursor. Non-stream sounds return 0.
---
# [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html).CursorSamples

<div class='signature' markdown='1'>
int CursorSamples{ get }
</div>

## Description
How far ReadSamples has consumed into a stream sound,
in samples. Playing voices don't move this - each tracks its own
position in SoundInst.Cursor. Non-stream sounds return 0.

