---
layout: default
title: Sprite.FromTex
description: Create a sprite from a Texture object!
---
# [Sprite]({{site.url}}/Pages/StereoKit/Sprite.html).FromTex

<div class='signature' markdown='1'>
```csharp
static Sprite FromTex(Tex image, SpriteType type, string atlasId)
```
Create a sprite from a Texture object!
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/Pages/StereoKit/Tex.html) image|The texture to build a sprite from. Must be a             valid, 2D image!|
|[SpriteType]({{site.url}}/Pages/StereoKit/SpriteType.html) type|Should this sprite be atlased, or an             individual image? Adding this as an atlased image is better for             performance, but will cause the atlas to be rebuilt! Images that             take up too much space on the atlas, or might be loaded or             unloaded during runtime may be better as Single rather than             Atlased!|
|string atlasId|The name of which atlas the sprite should              belong to, this is only relevant if the SpriteType is Atlased.|
|RETURNS: [Sprite]({{site.url}}/Pages/StereoKit/Sprite.html)|A Sprite asset, or null if the image failed when adding to the sprite system!|





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

