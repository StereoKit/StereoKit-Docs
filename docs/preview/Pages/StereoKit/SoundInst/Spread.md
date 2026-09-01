---
layout: default
title: SoundInst.Spread
description: Apparent size of the source, 0-1. 0 is a point in space, 1 fills the whole sound field. Shaped emitters compute this themselves, treating a set value as their minimum.
---
# [SoundInst]({{site.url}}/preview/Pages/StereoKit/SoundInst.html).Spread

<div class='signature' markdown='1'>
float Spread{ get set }
</div>

## Description
Apparent size of the source, 0-1. 0 is a point in
space, 1 fills the whole sound field. Shaped emitters compute
this themselves, treating a set value as their minimum.


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

