---
layout: default
title: Tex.GenParticle
description: Generates a 'radial' gradient that works well for particles, blob shadows, glows, or various other things. The roundness can be used to change the shape from round, '1', to star-like, '0'. Default color is transparent white to opaque white, but this can be configured by providing a Gradient of your own.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).GenParticle

<div class='signature' markdown='1'>
```csharp
static Tex GenParticle(int width, int height, float roundness0to1, Gradient gradientLinear)
```
Generates a 'radial' gradient that works well for
particles, blob shadows, glows, or various other things. The
roundness can be used to change the shape from round, '1', to
star-like, '0'. Default color is transparent white to opaque white,
but this can be configured by providing a Gradient of your own.
</div>

|  |  |
|--|--|
|int width|Width of the desired texture, in pixels.|
|int height|Width of the desired texture, in pixels.|
|float roundness0to1|Where 0 is a cross, or star-like shape,             and 1 is a circle. This is clamped to a minimum of 0.00001, but             values above 1 are still valid, and will just make the shape a             square near infinity.|
|[Gradient]({{site.url}}/Pages/StereoKit/Gradient.html) gradientLinear|A color gradient that starts with the             background/outside at 0, and progresses to the center at 1.|
|RETURNS: [Tex]({{site.url}}/Pages/StereoKit/Tex.html)|A texture object containing an RGBA linear texture.|





## Examples

### Generating Particle Sprites
Sometimes you just need a small blob of color for visual effects or
other things! Instead of firing up an image editor, you can just
use Tex.GenParticle!

This sample generates a number of different shapes defined by the
`roundness` parameter. Starting at 0, and increasing at .1
increments to 1.0.
```csharp
Sprite[] sprites = new Sprite[10];
for (int i = 0; i < sprites.Length; i++)
{
	float roundness   = i / (float)(sprites.Length - 1);
	Tex   particleTex = Tex.GenParticle(64, 64, roundness);
	sprites[i] = Sprite.FromTex(particleTex, SpriteType.Single);
}
// :End:

spriteList = sprites;
	}


ublic void Step() {
Hierarchy.Push(Matrix.T(0,4,2));

Sprite[] sprites = spriteList;

```
:CodeSample: Tex.GenParticle Sprite.FromTex
And here's what that looks like when you draw using this code!
```csharp
for (int i = 0; i < sprites.Length; i++)
	sprites[i].Draw(Matrix.TS(V.XY0(i%5, -i/5)*0.1f, 0.1f), TextAlign.TopRight);
```
![Generated particle sprites]({{site.screen_url}}/TexGenParticles.jpg)

