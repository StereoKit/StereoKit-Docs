---
layout: default
title: SoundInst.SetShape
description: Gives this voice a polyline emitter shape! The emitter follows the listener along the shape - position becomes the closest point, apparent size grows as the shape fills more of the view, and the sound goes fully diffuse inside it. Great for streams, wind lines, and shorelines. Points are copied, max 32.
---
# [SoundInst]({{site.url}}/preview/Pages/StereoKit/SoundInst.html).SetShape

<div class='signature' markdown='1'>
```csharp
void SetShape(Vec3[] points, float radius)
```
Gives this voice a polyline emitter shape! The emitter
follows the listener along the shape - position becomes the
closest point, apparent size grows as the shape fills more of
the view, and the sound goes fully diffuse inside it. Great for
streams, wind lines, and shorelines. Points are copied, max 32.
</div>

|  |  |
|--|--|
|Vec3[] points|The polyline's points, in world space.|
|float radius|Radius of the polyline's tube, in meters.|

<div class='signature' markdown='1'>
```csharp
void SetShape(Vec3 center, float radius)
```
Gives this voice a sphere emitter shape! The emitter
follows the listener around the sphere's surface, growing to
fully diffuse inside it. Great for wind volumes and rain areas.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) center|The sphere's center, in world space.|
|float radius|The sphere's radius, in meters.|





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

