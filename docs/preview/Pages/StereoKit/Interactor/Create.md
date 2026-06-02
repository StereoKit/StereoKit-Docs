---
layout: default
title: Interactor.Create
description: Create a new custom Interactor.
---
# [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html).Create

<div class='signature' markdown='1'>
```csharp
static Interactor Create(InteractorType shapeType, InteractorEvent events, InteractorActivation activationType, int inputSourceId, float capsuleRadius, int secondaryMotionDimensions)
```
Create a new custom Interactor.
</div>

|  |  |
|--|--|
|[InteractorType]({{site.url}}/preview/Pages/StereoKit/InteractorType.html) shapeType|A line, or a point? These interactors             behave slightly differently with respect to distance checks and             directionality. See `InteractorType` for mor details.|
|[InteractorEvent]({{site.url}}/preview/Pages/StereoKit/InteractorEvent.html) events|What type of interaction events should this             interactor fire? Interaction elements use this bitflag as a filter             to avoid interacting with certain interactors.|
|[InteractorActivation]({{site.url}}/preview/Pages/StereoKit/InteractorActivation.html) activationType||
|int inputSourceId|An identifier that uniquely indicates a             shared source for inputs. This will deactivate other interactors             with a shared source if one is already active. For example, 3             interactors for poke, pinch, and aim on a hand would all come from             a single hand, and if one is actively interacting, then the whole             hand source is considered busy.|
|float capsuleRadius|The radius of the interactor's capsule,             in meters.|
|int secondaryMotionDimensions|How many axes of secondary             motion can this interactor provide? This should be 0-3.|
|RETURNS: [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html)|The Interactor that was just created.|




