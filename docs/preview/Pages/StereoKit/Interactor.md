---
layout: default
title: Interactor
description: Interactors are essentially capsules that allow interaction with StereoKit's interaction primitives used by the UI system. While StereoKit does provide a number of interactors by default, you can replace StereoKit's defaults, add additional interactors, or generally just customize your interactions!
---
# struct Interactor

Interactors are essentially capsules that allow interaction
with StereoKit's interaction primitives used by the UI system. While
StereoKit does provide a number of interactors by default, you can
replace StereoKit's defaults, add additional interactors, or generally
just customize your interactions!

## Instance Fields and Properties

|  |  |
|--|--|
|[IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html) [Active]({{site.url}}/preview/Pages/StereoKit/Interactor/Active.html)|The id of the interaction element that is currently active, this will be `IdHash.None` if this interactor has nothing active. This will always be the same id as `Focused` when not `None`.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) [End]({{site.url}}/preview/Pages/StereoKit/Interactor/End.html)|The world space end of the interactor capsule. Some interactions can be directional, especially for `Line` type interactors, so if you think of the interactor as an "oriented" capsule, this would be the end which the `Start`/origin points towards.|
|[IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html) [Focused]({{site.url}}/preview/Pages/StereoKit/Interactor/Focused.html)|The id of the interaction element that is currently focused, this will be `IdHash.None` if this interactor has nothing focused.|
|float [MinDistance]({{site.url}}/preview/Pages/StereoKit/Interactor/MinDistance.html)|The distance at which a ray starts being interactive. For pointing rays, you may not want them to interact right at their start, or you may want the start to move depending on how outstretched the hand is! This allows you to change that start location without affecting the movement caused by the ray, and still capturing occlusion from blocking elements too close to the start. By default, this is a large negative value.|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) [Motion]({{site.url}}/preview/Pages/StereoKit/Interactor/Motion.html)|This pose is the source of translation and rotation motion caused by the interactor. In most cases it will be the same as your Start with the orientation of your interactor, but in some instance may be something else!|
|float [Radius]({{site.url}}/preview/Pages/StereoKit/Interactor/Radius.html)|The world space radius of the interactor capsule, in meters.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) [Start]({{site.url}}/preview/Pages/StereoKit/Interactor/Start.html)|The world space start of the interactor capsule. Some interactions can be directional, especially for `Line` type interactors, so if you think of the interactor as an "oriented" capsule, this would be the origin which points towards the capsule `End`.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [Tracked]({{site.url}}/preview/Pages/StereoKit/Interactor/Tracked.html)|The tracking state of this interactor.|

## Instance Methods

|  |  |
|--|--|
|[Destroy]({{site.url}}/preview/Pages/StereoKit/Interactor/Destroy.html)|Interactors, unlike Assets, don't destroy themselves! You must explicitly Destroy an Interactor if you're finished with it, otherwise it will continue to interact with StereoKit's interactors. This function immediately removes the interactor from the interactor list.|
|[TryGetFocusBounds]({{site.url}}/preview/Pages/StereoKit/Interactor/TryGetFocusBounds.html)|If this interactor has an element focused, this will output information about the location of that element, as well as the interactor's intersection point with that element.|
|[Update]({{site.url}}/preview/Pages/StereoKit/Interactor/Update.html)|Update the interactor with data for the current frame! This should be called as soon as possible at the start of the frame before any UI is done, otherwise the UI will not properly react.|

## Static Fields and Properties

|  |  |
|--|--|
|int [Count]({{site.url}}/preview/Pages/StereoKit/Interactor/Count.html)|The number of interactors currently in the system. Can be used with `Get`.|

## Static Methods

|  |  |
|--|--|
|[Create]({{site.url}}/preview/Pages/StereoKit/Interactor/Create.html)|Create a new custom Interactor.|
|[Get]({{site.url}}/preview/Pages/StereoKit/Interactor/Get.html)|Returns the `Interactor` at the given index. Should be used with `Count`.|
