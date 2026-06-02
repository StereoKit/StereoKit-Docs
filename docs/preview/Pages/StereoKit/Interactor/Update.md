---
layout: default
title: Interactor.Update
description: Update the interactor with data for the current frame! This should be called as soon as possible at the start of the frame before any UI is done, otherwise the UI will not properly react.
---
# [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html).Update

<div class='signature' markdown='1'>
```csharp
void Update(Vec3 capsuleStart, Vec3 capsuleEnd, Pose motion, Vec3 motionAnchor, Vec3 secondaryMotion, BtnState active, BtnState tracked)
```
Update the interactor with data for the current frame!
This should be called as soon as possible at the start of the frame
before any UI is done, otherwise the UI will not properly react.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) capsuleStart|World space location of the collision             capsule's start. For Line interactors, this should be the 'origin'             of the capsule's orientation.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) capsuleEnd|World space location of the collision             capsule's end. For Line interactors, this should be in the             direction the Start/origin is facing.|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) motion|This pose is the source of translation and             rotation motion caused by the interactor. In most cases it will be             the same as your capsuleStart with the orientation of your             interactor, but in some instance may be something else!|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) motionAnchor|Some motion, like that of amplified             motion, needs some anchor point with which to determine the             amplification from. This might be a shoulder, or a head, or some             other point that the interactor will push from / pull towards.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) secondaryMotion|This is motion that comes from             somewhere other than the interactor itself! This can be something             like an analog stick on a controller, or the scroll wheel of a             mouse.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) active|The activation state of the Interactor.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) tracked|The tracking state of the Interactor.|




