---
layout: default
title: Interactor.TryGetFocusBounds
description: If this interactor has an element focused, this will output information about the location of that element, as well as the interactor's intersection point with that element.
---
# [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html).TryGetFocusBounds

<div class='signature' markdown='1'>
```csharp
bool TryGetFocusBounds(Pose& poseWorld, Bounds& boundsLocal, Vec3& atLocal)
```
If this interactor has an element focused, this will
output information about the location of that element, as well as
the interactor's intersection point with that element.
</div>

|  |  |
|--|--|
|Pose& poseWorld|The world space Pose of the element's hierarchy space. This is typically the Pose of the Window/Handle/Surface the element belongs to.|
|Bounds& boundsLocal|The bounds of the UI element relative to the Pose. Note that the `center` should always be accounted for here!|
|Vec3& atLocal|The intersection point relative to the Bounds, NOT relative to the Pose!|
|RETURNS: bool|True if bounds data is available.|




