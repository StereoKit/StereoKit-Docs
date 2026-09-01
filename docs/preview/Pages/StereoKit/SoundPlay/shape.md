---
layout: default
title: SoundPlay.shape
description: Optional emitter shape. 1 point is a sphere, 2+ a rounded polyline. The emitter follows the listener along the shape - position becomes the closest point, and apparent size grows as the shape fills more of the view, going fully diffuse inside it. Points are copied at play, max 32. Null means a point source at the play position.
---
# [SoundPlay]({{site.url}}/preview/Pages/StereoKit/SoundPlay.html).shape

<div class='signature' markdown='1'>
Vec3[] shape
</div>

## Description
Optional emitter shape: 1 point is a sphere, 2+ a
rounded polyline. The emitter follows the listener along the
shape - position becomes the closest point, and apparent size
grows as the shape fills more of the view, going fully diffuse
inside it. Points are copied at play, max 32. Null means a point
source at the play position.


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

