---
layout: default
title: UI.Model
description: This adds a non-interactive Model to the UI panel layout.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).Model

<div class='signature' markdown='1'>
```csharp
static void Model(Model model)
```
This adds a non-interactive Model to the UI panel layout.
</div>

|  |  |
|--|--|
|[Model]({{site.url}}/Pages/StereoKit/Model.html) model|The Model to use.|

<div class='signature' markdown='1'>
```csharp
static void Model(Model model, Vec2 uiSize, float modelScale)
```
This adds a non-interactive Model to the UI panel layout,
and allows you to specify its size.
</div>

|  |  |
|--|--|
|[Model]({{site.url}}/Pages/StereoKit/Model.html) model|The Model to use.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) uiSize|The size this element should take from the             layout.|
|float modelScale|0 will auto-scale the model to fit the             layout space, but you can specify a different scale in case you'd             like a different size.|




