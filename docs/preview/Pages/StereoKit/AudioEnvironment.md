---
layout: default
title: AudioEnvironment
description: A perceptual description of the acoustic space sounds play in - an environment rather than a literal room, so it covers halls through forests. Spatial sounds feed a shared reverb whose level stays constant with distance, so the direct-to-reverb balance naturally carries how far away a sound is. A wet of 0 disables the system entirely at zero cost, and a zeroed struct is the off state. Language bindings provide preset values for common spaces as starting points.
---
# struct AudioEnvironment

A perceptual description of the acoustic space sounds play in - an
environment rather than a literal room, so it covers halls through
forests. Spatial sounds feed a shared reverb whose level stays constant
with distance, so the direct-to-reverb balance naturally carries how far
away a sound is. A wet of 0 disables the system entirely at zero cost,
and a zeroed struct is the off state. Language bindings provide preset
values for common spaces as starting points.

## Instance Fields and Properties

|  |  |
|--|--|
|float [damp]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/damp.html)|0-1, extra high frequency decay. Soft or leafy spaces are high, tiled rooms are low.|
|float [decay]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/decay.html)|Decay time in seconds - how long the tail takes to fall 60dB at mid frequencies. Rooms are ~0.4s, cathedrals a few seconds. Clamped to 0.05-10.|
|float [reflect]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/reflect.html)|0-1, level of the distinct early reflections off the space's surfaces - the first bounces that glue a sound to the room. The ground bounce keeps a minimum presence; walls and ceiling scale fully with this, so outdoor spaces sit near 0.|
|float [scatter]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/scatter.html)|0-1, how quickly discrete echoes blur into a dense wash. Scattered spaces like forests are high, bare rooms lower.|
|float [size]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/size.html)|Size of the space in meters, clamped to 2-40. Drives the spacing of the echoes that build the tail. Changing this restarts the tail, where the other fields all glide smoothly.|
|float [wet]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/wet.html)|Reverb level, 0-1. 0 turns environmental acoustics off completely, and is the default.|

## Static Fields and Properties

|  |  |
|--|--|
|[AudioEnvironment]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment.html) [Cave]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/Cave.html)|A cavern: a very long, dense tail with hard surfaces.|
|[AudioEnvironment]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment.html) [Field]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/Field.html)|An open field: nearly dry, the faintest hint of ground scatter. Openness itself is the cue.|
|[AudioEnvironment]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment.html) [Forest]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/Forest.html)|A forest: no walls, just a short dark scatter off trunks and foliage - quiet, but unmistakably outdoors-with-presence.|
|[AudioEnvironment]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment.html) [Hall]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/Hall.html)|A large hall: a long, bright, spacious tail.|
|[AudioEnvironment]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment.html) [Off]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/Off.html)|No environmental acoustics at all, sounds play dry. This is the default, and costs nothing - the right choice for AR, where synthetic reverb would fight the real room's acoustics.|
|[AudioEnvironment]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment.html) [Room]({{site.url}}/preview/Pages/StereoKit/AudioEnvironment/Room.html)|A small furnished room: a short, balanced tail.|

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

