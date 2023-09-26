---
layout: default
title: Model.SetTransform
description: [Obsolete] For removal in v0.4. Use Nodes / Visuals.ModelTransform instead. Changes the transform for the subset to a new one! This is in Model space, so it's relative to the origin of the model.
---
# [Model]({{site.url}}/Pages/StereoKit/Model.html).SetTransform

<div class='signature' markdown='1'>
```csharp
void SetTransform(int subsetIndex, Matrix& transform)
```
[Obsolete] For removal in v0.4. Use Nodes /
Visuals.ModelTransform instead. Changes the transform for the
subset to a new one! This is in Model space, so it's relative to
the origin of the model.
</div>

|  |  |
|--|--|
|int subsetIndex|Index of the transform to replace,             should be less than SubsetCount.|
|Matrix& transform|The new transform.|




