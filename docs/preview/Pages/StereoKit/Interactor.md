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
|[InteractorActivation]({{site.url}}/preview/Pages/StereoKit/InteractorActivation.html) [Activation]({{site.url}}/preview/Pages/StereoKit/Interactor/Activation.html)|How does this interactor activate elements? Does it use the physical position of the interactor, or its activation state? This is set at creation time and does not change.|
|[IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html) [Active]({{site.url}}/preview/Pages/StereoKit/Interactor/Active.html)|The id of the interaction element that is currently active, this will be `IdHash.None` if this interactor has nothing active. This will always be the same id as `Focused` when not `None`.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) [End]({{site.url}}/preview/Pages/StereoKit/Interactor/End.html)|The world space end of the interactor capsule. Some interactions can be directional, especially for `Line` type interactors, so if you think of the interactor as an "oriented" capsule, this would be the end which the `Start`/origin points towards.|
|[InteractorEvent]({{site.url}}/preview/Pages/StereoKit/InteractorEvent.html) [Events]({{site.url}}/preview/Pages/StereoKit/Interactor/Events.html)|What type of interaction events does this interactor fire? Interaction elements use this bitflag as a filter to avoid interacting with certain interactors. This is set at creation time and does not change.|
|[IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html) [Focused]({{site.url}}/preview/Pages/StereoKit/Interactor/Focused.html)|The id of the interaction element that is currently focused, this will be `IdHash.None` if this interactor has nothing focused.|
|float [MinDistance]({{site.url}}/preview/Pages/StereoKit/Interactor/MinDistance.html)|The distance at which a ray starts being interactive. For pointing rays, you may not want them to interact right at their start, or you may want the start to move depending on how outstretched the hand is! This allows you to change that start location without affecting the movement caused by the ray, and still capturing occlusion from blocking elements too close to the start. By default, this is a large negative value.|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) [Motion]({{site.url}}/preview/Pages/StereoKit/Interactor/Motion.html)|This pose is the source of translation and rotation motion caused by the interactor. In most cases it will be the same as your Start with the orientation of your interactor, but in some instance may be something else!|
|float [Radius]({{site.url}}/preview/Pages/StereoKit/Interactor/Radius.html)|The world space radius of the interactor capsule, in meters.|
|int [SecondaryDims]({{site.url}}/preview/Pages/StereoKit/Interactor/SecondaryDims.html)|How many axes of secondary motion can this interactor provide? Secondary motion is input that comes from somewhere other than the interactor's own movement through space. For example, a mouse's scroll wheel is 1 axis, and a controller's analog thumbstick is 2 axes (X/Y). This should be 0-3.|
|[InteractorSource]({{site.url}}/preview/Pages/StereoKit/InteractorSource.html) [Source]({{site.url}}/preview/Pages/StereoKit/Interactor/Source.html)|The physical source this interactor's input comes from, such as a specific hand, controller, or the mouse. Interactors that share a source will deactivate each other when one becomes active, for example the poke, pinch, and aim interactors of a single hand. `InteractorSource.Unique` indicates a source that never groups with other interactors. This is set at creation time and does not change.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) [Start]({{site.url}}/preview/Pages/StereoKit/Interactor/Start.html)|The world space start of the interactor capsule. Some interactions can be directional, especially for `Line` type interactors, so if you think of the interactor as an "oriented" capsule, this would be the origin which points towards the capsule `End`.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [Tracked]({{site.url}}/preview/Pages/StereoKit/Interactor/Tracked.html)|The tracking state of this interactor.|
|[InteractorType]({{site.url}}/preview/Pages/StereoKit/InteractorType.html) [Type]({{site.url}}/preview/Pages/StereoKit/Interactor/Type.html)|A line, or a point? These interactors behave slightly differently with respect to distance checks and directionality. See `InteractorType` for more details. This is set at creation time and does not change.|

## Instance Methods

|  |  |
|--|--|
|[Destroy]({{site.url}}/preview/Pages/StereoKit/Interactor/Destroy.html)|Interactors, unlike Assets, don't destroy themselves! You must explicitly Destroy an Interactor if you're finished with it, otherwise it will continue to interact with StereoKit's interactors. This function immediately removes the interactor from the interactor list.|
|[Equals]({{site.url}}/preview/Pages/StereoKit/Interactor/Equals.html)|An equality test. Two Interactors are equal when they refer to the same interactor instance.|
|[GetHashCode]({{site.url}}/preview/Pages/StereoKit/Interactor/GetHashCode.html)|A hash code based on the interactor's id.|
|[TryGetFocusBounds]({{site.url}}/preview/Pages/StereoKit/Interactor/TryGetFocusBounds.html)|If this interactor has an element focused, this will output information about the location of that element, as well as the interactor's intersection point with that element.|
|[Update]({{site.url}}/preview/Pages/StereoKit/Interactor/Update.html)|Update the interactor with data for the current frame! This should be called as soon as possible at the start of the frame before any UI is done, otherwise the UI will not properly react.|

## Static Fields and Properties

|  |  |
|--|--|
|[InteractorCollection]({{site.url}}/preview/Pages/StereoKit/InteractorCollection.html) [All]({{site.url}}/preview/Pages/StereoKit/Interactor/All.html)|An enumerable collection of all the Interactors currently in the system. Use this to inspect or visualize every Interactor, including any custom ones you've added.|
|[Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html) [None]({{site.url}}/preview/Pages/StereoKit/Interactor/None.html)|An empty Interactor that represents "no interactor". UI building blocks like `UI.ButtonBehavior` and `UI.VolumeAt` report this when nothing is interacting with them, so you can test their result against `Interactor.None`.|

## Static Methods

|  |  |
|--|--|
|[Create]({{site.url}}/preview/Pages/StereoKit/Interactor/Create.html)|Create a new custom Interactor.|
|[IsInteracting]({{site.url}}/preview/Pages/StereoKit/Interactor/IsInteracting.html)|Is any interactor from the given source currently interacting with an element, that is, actively pressing or focusing it? Sources can be combined as a bit-flag to ask about several at once, e.g. `InteractorSource.HandLeft | InteractorSource.HandRight`.|

## Operators

|  |  |
|--|--|
|[op_Equality]({{site.url}}/preview/Pages/StereoKit/Interactor/op_Equality.html)|An equality test.|
|[op_Inequality]({{site.url}}/preview/Pages/StereoKit/Interactor/op_Inequality.html)|An inequality test.|
