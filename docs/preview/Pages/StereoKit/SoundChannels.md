---
layout: default
title: SoundChannels
description: The channel format of a Sound's data. Only mono sounds spatialize - playing a non-mono sound ignores its position entirely.
---
# enum SoundChannels

The channel format of a Sound's data. Only mono sounds spatialize -
playing a non-mono sound ignores its position entirely.

## Enum Values

|  |  |
|--|--|
|Ambisonic1|Four interleaved first order (1) ambisonic channels in the ambiX convention (ACN order W,Y,Z,X with SN3D normalization). The sound field stays world-fixed, counter-rotating against the head - the head-tracked generalization of a binaural render. Great for recorded or simulated environmental beds.|
|Mono|One channel. Spatializes as a point or shaped source, the default and by far the most common format for game audio.|
|Stereo|Two interleaved channels, played back head-locked and untouched. Music, and pre-rendered binaural content.|
