---
layout: default
title: Sound.Play
description: Plays the sound at the 3D location specified, using the volume parameter as an additional volume control option! Sound volume falls off from 3D location, and can also indicate direction and location through spatial audio cues. So make sure the position is where you want people to think it's from! Currently, if this sound is playing somewhere else, it'll be canceled, and moved to this location.
---
# [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html).Play

<div class='signature' markdown='1'>
```csharp
SoundInst Play(Vec3 at, float volume)
```
Plays the sound at the 3D location specified, using the
volume parameter as an additional volume control option! Sound
volume falls off from 3D location, and can also indicate
direction and location through spatial audio cues. So make sure
the position is where you want people to think it's from!
Currently, if this sound is playing somewhere else, it'll be
canceled, and moved to this location.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) at|World space location for the audio to play at.|
|float volume|Volume modifier for the effect! 1 means full volume, and 0 means completely silent.|
|RETURNS: [SoundInst]({{site.url}}/preview/Pages/StereoKit/SoundInst.html)|Returns a link to the Sound's play instance, which you can use to track and modify how the sound plays after the initial conditions are set.|

<div class='signature' markdown='1'>
```csharp
SoundInst Play(Vec3 at, SoundPlay settings)
```
Plays the sound at the 3D location specified, with
extra settings! Pitch, onset delay, emitter shapes, bus routing,
and behavior flags all live in SoundPlay - a default struct
behaves just like the plain Play call.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) at|World space location for the audio to play at. Ignored for non-mono sounds and head-locked plays.|
|[SoundPlay]({{site.url}}/preview/Pages/StereoKit/SoundPlay.html) settings|Extra playback settings, see SoundPlay.|
|RETURNS: [SoundInst]({{site.url}}/preview/Pages/StereoKit/SoundInst.html)|A link to the Sound's play instance for tracking and live adjustments.|





## Examples

### Thunder along a lightning bolt
Sounds declare real-world loudness in decibels, and
SoundFlags.PropagationDelay delays each voice's onset by its
distance at the speed of sound - so a thunder boom and its
rumble arrive along the bolt just like the real thing. Energy
sets the pitch here: bigger strikes boom deeper.
```csharp
// A jagged bolt across the sky: the boom fires from its nearest
// point, then rumble instances arrive progressively later from
// farther along it - each duller (distance is a low-pass filter)
// and wider than the last.
float dist  = 80 + thunderDist * 1120;
float dir   = (float)(rand.NextDouble() * Math.PI * 2);
Vec3  near  = new Vec3(MathF.Cos(dir), 0, MathF.Sin(dir)) * dist + Vec3.Up * 90;
Vec3  far   = near + new Vec3(MathF.Sin(dir), 0.5f, -MathF.Cos(dir)) * (100 + (float)rand.NextDouble() * 300);
float pitch = 1.35f - thunderEnergy * 0.7f;

boomInst = boomSound.Play(near, new SoundPlay {
	flags = SoundFlags.PropagationDelay,
	pitch = pitch,
});

for (int i = 0; i < rumbleInsts.Length; i++)
{
	float t  = (i + 1) / (float)rumbleInsts.Length;
	Vec3  at = Vec3.Lerp(near, far, t);
	rumbleInsts[i] = rumbleSound.Play(at, new SoundPlay {
		flags  = SoundFlags.PropagationDelay,
		delay  = t * 0.5f,
		pitch  = pitch * (1.0f - t * 0.25f),
		volume = 1.0f - t * 0.3f,
		spread = 0.2f,
		cutoff = 900 - t * 550, // Air absorption along the bolt
	});
}
```
### Basic usage
```csharp
Sound sound = Sound.FromFile("BlipNoise.wav");
sound.Play(Vec3.Zero);
```

