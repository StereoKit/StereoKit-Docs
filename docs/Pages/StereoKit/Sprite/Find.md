---
layout: default
title: Sprite.Find
description: Finds a sprite that matches the given id! Check out the DefaultIds static class for some built-in ids. Sprites will auto-id themselves using this pattern if single sprites. {Tex.Id}/spr, and this pattern if atlased sprites. atlas_spr/{atlas}/{Tex.Id}.
---
# [Sprite]({{site.url}}/Pages/StereoKit/Sprite.html).Find

<div class='signature' markdown='1'>
```csharp
static Sprite Find(string id)
```
Finds a sprite that matches the given id! Check out the
DefaultIds static class for some built-in ids. Sprites will auto-id
themselves using this pattern if single sprites: {Tex.Id}/spr, and
this pattern if atlased sprites: atlas_spr/{atlas}/{Tex.Id}.
</div>

|  |  |
|--|--|
|string id|Id of the sprite asset.|
|RETURNS: [Sprite]({{site.url}}/Pages/StereoKit/Sprite.html)|A Sprite asset with the given id, or null if none is found.|




