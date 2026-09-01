---
layout: default
title: SoundPlay
description: Optional settings for Sound.Play! The default struct plays a plain point source. full volume trim, normal pitch, no delay, on the Sfx bus.
---
# struct SoundPlay

Optional settings for Sound.Play! The default struct plays
a plain point source: full volume trim, normal pitch, no delay, on
the Sfx bus.

## Instance Fields and Properties

|  |  |
|--|--|
|[SoundBus]({{site.url}}/preview/Pages/StereoKit/SoundBus.html) [bus]({{site.url}}/preview/Pages/StereoKit/SoundPlay/bus.html)|The volume category this sound belongs to, SoundBus.Sfx when zeroed.|
|float [cutoff]({{site.url}}/preview/Pages/StereoKit/SoundPlay/cutoff.html)|Low-pass filter cutoff override in Hz for this voice. 0 uses the automatic distance model.|
|float [delay]({{site.url}}/preview/Pages/StereoKit/SoundPlay/delay.html)|Seconds before the sound actually starts playing, sample accurate. SoundFlags.PropagationDelay adds distance/343m/s on top of this.|
|[SoundFlags]({{site.url}}/preview/Pages/StereoKit/SoundFlags.html) [flags]({{site.url}}/preview/Pages/StereoKit/SoundPlay/flags.html)|See SoundFlags!|
|float [pitch]({{site.url}}/preview/Pages/StereoKit/SoundPlay/pitch.html)|Playback rate multiplier, clamped to 0.25-4. 1 is normal speed, 2 is twice as fast and an octave up. 0 is treated as 1.|
|Vec3[] [shape]({{site.url}}/preview/Pages/StereoKit/SoundPlay/shape.html)|Optional emitter shape: 1 point is a sphere, 2+ a rounded polyline. The emitter follows the listener along the shape - position becomes the closest point, and apparent size grows as the shape fills more of the view, going fully diffuse inside it. Points are copied at play, max 32. Null means a point source at the play position.|
|float [shapeRadius]({{site.url}}/preview/Pages/StereoKit/SoundPlay/shapeRadius.html)|Radius of the shape's sphere or polyline tube, in meters.|
|float [spread]({{site.url}}/preview/Pages/StereoKit/SoundPlay/spread.html)|Apparent size of the source, 0-1. 0 is a point in space, 1 fills the whole sound field evenly. Great for wind, rivers and rumble, but keep transients like impacts at 0 - width smears their attack.|
|float [volume]({{site.url}}/preview/Pages/StereoKit/SoundPlay/volume.html)|A 0-1 volume trim on top of the Sound's Decibels loudness. 0 is treated as the default full trim of 1, use a tiny value for real silence. Values above 1 amplify, negatives clamp to 0.|

## Examples

### A shaped rain emitter
Shapes turn a looping sound into an extended source: the
emitter follows the listener along the shape, widens as it
fills more of the view, and goes fully diffuse inside it - a
rain bed the listener stands inside surrounds them completely.
```csharp
washFarInst = washFar.Play(Vec3.Zero, new SoundPlay {
	flags       = SoundFlags.Loop,
	shape       = new Vec3[] { new Vec3(0, 0, 0) },
	shapeRadius = 12,
});
```

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

