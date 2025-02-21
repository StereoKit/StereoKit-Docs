---
layout: default
title: Sprite.Find
description: Finds a sprite that matches the given id! Check out the DefaultIds static class for some built-in ids. Sprites will auto-id themselves using this pattern if single sprites. {Tex.Id}/sprite, and this pattern if atlased sprites. {Tex.Id}/sprite/atlas/{atlasId}.
---
# [Sprite]({{site.url}}/Pages/StereoKit/Sprite.html).Find

<div class='signature' markdown='1'>
```csharp
static Sprite Find(string id)
```
Finds a sprite that matches the given id! Check out the
DefaultIds static class for some built-in ids. Sprites will auto-id
themselves using this pattern if single sprites: {Tex.Id}/sprite,
and this pattern if atlased sprites: {Tex.Id}/sprite/atlas/{atlasId}.
</div>

|  |  |
|--|--|
|string id|Id of the sprite asset.|
|RETURNS: [Sprite]({{site.url}}/Pages/StereoKit/Sprite.html)|A Sprite asset with the given id, or null if none is found.|




