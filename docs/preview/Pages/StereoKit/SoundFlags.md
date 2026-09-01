---
layout: default
title: SoundFlags
description: Option flags for playing a sound, see sound_play_t.
---
# enum SoundFlags

Option flags for playing a sound, see sound_play_t.

## Enum Values

|  |  |
|--|--|
|HeadLocked|Skip spatialization entirely: no distance attenuation, panning, or filtering. The sound follows the head, good for music, UI, or pre-rendered binaural content.|
|Loop|The sound restarts from the beginning when it reaches the end of its data, and plays until stopped. Live streams ignore this, they already wait for data forever.|
|None|No special behavior, the default.|
|PropagationDelay|Delay the sound's onset by its distance from the listener divided by the speed of sound (343m/s), computed once when playback starts. Great for thunder, explosions, and other far away events.|

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

