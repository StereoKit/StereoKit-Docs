---
layout: default
title: UI.Handle
description: This begins and ends a handle so you can just use  its grabbable/moveable functionality! Behaves much like a window, except with a more flexible handle, and no header. You can draw the handle, but it will have no text on it. Returns true for every frame the user is grabbing the handle.
---
# [UI]({{site.url}}/preview/Pages/StereoKit/UI.html).Handle

<div class='signature' markdown='1'>
```csharp
static bool Handle(string id, Pose& pose, Bounds handle, bool drawHandle, UIMove moveType, UIGesture allowedGestures)
```
This begins and ends a handle so you can just use  its
grabbable/moveable functionality! Behaves much like a window,
except with a more flexible handle, and no header. You can draw
the handle, but it will have no text on it. Returns true for
every frame the user is grabbing the handle.
</div>

|  |  |
|--|--|
|string id|An id for tracking element state. MUST be unique within current hierarchy.|
|Pose& pose|The pose state for the handle! The user will be able to grab this handle and move it around. The pose is relative to the current hierarchy stack.|
|[Bounds]({{site.url}}/preview/Pages/StereoKit/Bounds.html) handle|Size and location of the handle, relative to the pose.|
|bool drawHandle|Should this function draw the handle for you, or will you draw that yourself?|
|[UIMove]({{site.url}}/preview/Pages/StereoKit/UIMove.html) moveType|Describes how the handle will move when dragged around.|
|[UIGesture]({{site.url}}/preview/Pages/StereoKit/UIGesture.html) allowedGestures|Which hand gestures are used for interacting with this Handle?|
|RETURNS: bool|Returns true for every frame the user is grabbing the handle.|

<div class='signature' markdown='1'>
```csharp
static bool Handle(string id, Pose& pose, Bounds handle, Single& scale, bool drawHandle, UIMove moveType, UIGesture allowedGestures)
```
This begins and ends a handle, like `UI.Handle`, but with
support for multi-interactor uniform scaling. With two or more
interactors grabbing the handle, their motion is combined into a
translation, rotation, and a uniform scale. Interactors may freely
join or leave the interaction without the handle jumping. Providing a
scale here enables scaling; pass `UIMove.ExactNoscale` as the moveType
if you want multi-interactor translate/rotate but no scaling.
</div>

|  |  |
|--|--|
|string id|An id for tracking element state. MUST be unique within current hierarchy.|
|Pose& pose|The pose state for the handle! The user will be able to grab this handle and move it around. The pose is relative to the current hierarchy stack.|
|[Bounds]({{site.url}}/preview/Pages/StereoKit/Bounds.html) handle|Size and location of the handle, relative to the pose. When a `scale` is provided, the handle multiplies these Bounds by it - so pass your unscaled base size, and the grab volume and drawn handle grow and shrink to match your scaled content.|
|Single& scale|A uniform scale multiplier that gets accumulated as the user scales the handle with multiple interactors. Seed this with 1 (or your starting scale). Since the Pose has no scale of its own, apply this value to your content - the `handle` Bounds are scaled by it for you, so the grab volume and drawn handle stay matched.|
|bool drawHandle|Should this function draw the handle for you, or will you draw that yourself?|
|[UIMove]({{site.url}}/preview/Pages/StereoKit/UIMove.html) moveType|Describes how the handle will move when dragged around. Use `UIMove.ExactNoscale` to disable scaling.|
|[UIGesture]({{site.url}}/preview/Pages/StereoKit/UIGesture.html) allowedGestures|Which hand gestures are used for interacting with this Handle?|
|RETURNS: bool|Returns true for every frame the user is grabbing the handle.|




