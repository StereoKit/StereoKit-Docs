---
layout: default
title: SoundInst.Cursor
description: This voice's playback position in source samples. For stream sounds this is an absolute position in the stream, so Sound.TotalSamples - Cursor is how much audio is queued ahead of this voice. Only fully in-memory sounds can Seek, streams read forward only.
---
# [SoundInst]({{site.url}}/preview/Pages/StereoKit/SoundInst.html).Cursor

<div class='signature' markdown='1'>
UInt64 Cursor{ get }
</div>

## Description
This voice's playback position in source samples. For
stream sounds this is an absolute position in the stream, so
Sound.TotalSamples - Cursor is how much audio is queued ahead
of this voice. Only fully in-memory sounds can Seek, streams
read forward only.

