---
layout: default
title: AudioBufferGenerator
description: A callback for generating a whole buffer of audio samples at once! Fill the provided buffer completely with values in the -1 to +1 range. frameStart / 48,000 is the time of the buffer's first frame. For multi-channel sounds the buffer holds frames-x-channels interleaved samples - for mono, frames and samples are the same thing.
---
# delegate AudioBufferGenerator

A callback for generating a whole buffer of audio samples
at once! Fill the provided buffer completely with values in the -1
to +1 range. frameStart / 48,000 is the time of the buffer's first
frame. For multi-channel sounds the buffer holds frames-x-channels
interleaved samples - for mono, frames and samples are the same
thing.
