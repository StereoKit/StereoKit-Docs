---
layout: default
title: Sprite.Draw
description: Draws the sprite at the location specified by the transform matrix. A sprite is always sized in model space as 1 x Aspect meters on the x and y axes respectively, so scale appropriately. The 'position' attribute describes what corner of the sprite you're specifying the transform of.
---
# [Sprite]({{site.url}}/preview/Pages/StereoKit/Sprite.html).Draw

<div class='signature' markdown='1'>
```csharp
void Draw(Matrix& transform, Pivot pivotPosition)
```
Draws the sprite at the location specified by the
transform matrix. A sprite is always sized in model space as 1 x
Aspect meters on the x and y axes respectively, so scale
appropriately. The 'position' attribute describes what corner of
the sprite you're specifying the transform of.
</div>

|  |  |
|--|--|
|Matrix& transform|A Matrix describing a transform from              model space to world space. A sprite is always sized in model             space as 1 x Aspect meters on the x and y axes respectively, so             scale appropriately and remember that your anchor position may             affect the transform as well.|
|[Pivot]({{site.url}}/preview/Pages/StereoKit/Pivot.html) pivotPosition|Describes what corner of the sprite             you're specifying the transform of. The 'Pivot' point or             'Origin' of the Sprite.|

<div class='signature' markdown='1'>
```csharp
void Draw(Matrix& transform, Pivot anchorPosition, Color32 linearColor)
```
Draws the sprite at the location specified by the
transform matrix. A sprite is always sized in model space as 1 x
Aspect meters on the x and y axes respectively, so scale
appropriately. The 'position' attribute describes what corner of
the sprite you're specifying the transform of.
</div>

|  |  |
|--|--|
|Matrix& transform|A Matrix describing a transform from              model space to world space. A sprite is always sized in model             space as 1 x Aspect meters on the x and y axes respectively, so             scale appropriately and remember that your anchor position may             affect the transform as well.|
|[Color32]({{site.url}}/preview/Pages/StereoKit/Color32.html) linearColor|Per-instance color data for this render             item. It is unmodified by StereoKit, and is generally interpreted             as linear.|




