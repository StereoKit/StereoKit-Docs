---
layout: default
title: Audio.Environment
description: The acoustic environment that spatial sounds play in! This drives a shared reverb and early reflections that carry a sense of space and absolute distance. The default is fully off (wet 0), which costs nothing and never fights the real room's acoustics - the right resting state for AR. Assign a preset like AudioEnvironment.Hall - Off returns to dry, zero cost playback - or build custom values, perhaps starting from a preset.
---
# [Audio]({{site.url}}/preview/Pages/StereoKit/Audio.html).Environment

<div class='signature' markdown='1'>
static [AudioEnvironment]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment.html) Environment{ get set }
</div>

## Description
The acoustic environment that spatial sounds play in!
This drives a shared reverb and early reflections that carry a
sense of space and absolute distance. The default is fully off
(wet 0), which costs nothing and never fights the real room's
acoustics - the right resting state for AR. Assign a preset like
AudioEnvironment.Hall - Off returns to dry, zero cost playback -
or build custom values, perhaps starting from a preset.


## Examples

### Acoustic environments
Spatial sounds can play inside an acoustic environment - a
shared reverb and early reflections that carry a sense of space
and absolute distance! The default is entirely off, which costs
nothing, and is the right resting state for AR. Preset constants
cover common spaces:
```csharp
Audio.Environment = AudioEnvironment.Forest;

// Or start from a preset and adjust it to taste:
AudioEnvironment env = AudioEnvironment.Room;
env.decay   = 0.6f;
env.reflect = 0.7f;
Audio.Environment = env;
```

