---
layout: default
title: Audio
description: Global audio system controls. the master volume, per-bus category volumes, listener overrides, and an output meter for checking your mix.
---
# static class Audio

Global audio system controls: the master volume, per-bus
category volumes, listener overrides, and an output meter for
checking your mix.

## Static Fields and Properties

|  |  |
|--|--|
|[AudioEnvironment]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment.html) [Environment]({{site.url}}/preview/Pages/StereoKit/Audio/Environment.html)|The acoustic environment that spatial sounds play in! This drives a shared reverb and early reflections that carry a sense of space and absolute distance. The default is fully off (wet 0), which costs nothing and never fights the real room's acoustics - the right resting state for AR. Assign a preset like AudioEnvironment.Hall - Off returns to dry, zero cost playback - or build custom values, perhaps starting from a preset.|
|Nullable`1 [ListenerOverride]({{site.url}}/preview/Pages/StereoKit/Audio/ListenerOverride.html)|Normally the audio listener follows the user's head. Set this to hear the scene from somewhere else - a third person camera, or a remote avatar - and set it to null to give the ears back to the head.|
|float [OutputDecibels]({{site.url}}/preview/Pages/StereoKit/Audio/OutputDecibels.html)|RMS level of the last mixed audio block in dBFS, -120 when silent. Useful for level meters, and for checking where your content sits relative to the limiter at 0.|
|float [Volume]({{site.url}}/preview/Pages/StereoKit/Audio/Volume.html)|The master volume, a 0-1 trim over everything StereoKit plays. This is an app level control - the user's system volume sits below it.|

## Static Methods

|  |  |
|--|--|
|[GetBusVolume]({{site.url}}/preview/Pages/StereoKit/Audio/GetBusVolume.html)|Gets a bus category's current 0-1 volume trim.|
|[SetBusVolume]({{site.url}}/preview/Pages/StereoKit/Audio/SetBusVolume.html)|Sets a bus category's 0-1 volume trim. Every sound playing on that bus is affected, handy for sfx/music/ui sliders in a settings menu, or ducking a whole category.|
