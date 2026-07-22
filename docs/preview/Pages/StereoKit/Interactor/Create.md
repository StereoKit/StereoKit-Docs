---
layout: default
title: Interactor.Create
description: Create a new custom Interactor.
---
# [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html).Create

<div class='signature' markdown='1'>
```csharp
static Interactor Create(InteractorType shapeType, InteractorEvent events, InteractorActivation activationType, InteractorSource source, float capsuleRadius, int secondaryMotionDimensions)
```
Create a new custom Interactor.
</div>

|  |  |
|--|--|
|[InteractorType]({{site.url}}/preview/Pages/StereoKit/InteractorType.html) shapeType|A line, or a point? These interactors behave slightly differently with respect to distance checks and directionality. See `InteractorType` for mor details.|
|[InteractorEvent]({{site.url}}/preview/Pages/StereoKit/InteractorEvent.html) events|What type of interaction events should this interactor fire? Interaction elements use this bitflag as a filter to avoid interacting with certain interactors.|
|[InteractorActivation]({{site.url}}/preview/Pages/StereoKit/InteractorActivation.html) activationType||
|[InteractorSource]({{site.url}}/preview/Pages/StereoKit/InteractorSource.html) source|The physical source this interactor's input comes from. Interactors that share a source will deactivate each other if one is already active. For example, the poke, pinch, and aim interactors of a single hand all share that hand's source, so if one is actively interacting the whole hand is considered busy. Use `InteractorSource.Unique` for a source that never groups with others, or a custom value at or above `InteractorSource.Max` for your own sources.|
|float capsuleRadius|The radius of the interactor's capsule, in meters.|
|int secondaryMotionDimensions|How many axes of secondary motion can this interactor provide? Secondary motion is input from a source other than the interactor's own movement, such as a mouse's scroll wheel (1 axis) or a controller's analog thumbstick (2 axes, X/Y). This should be 0-3.|
|RETURNS: [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html)|The Interactor that was just created.|




