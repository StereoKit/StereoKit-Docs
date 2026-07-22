---
layout: default
title: Interactor.IsInteracting
description: Is any interactor from the given source currently interacting with an element, that is, actively pressing or focusing it? Sources can be combined as a bit-flag to ask about several at once, e.g. InteractorSource.HandLeft | InteractorSource.HandRight.
---
# [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html).IsInteracting

<div class='signature' markdown='1'>
```csharp
static bool IsInteracting(InteractorSource source)
```
Is any interactor from the given source currently
interacting with an element, that is, actively pressing or focusing
it? Sources can be combined as a bit-flag to ask about several at
once, e.g. `InteractorSource.HandLeft | InteractorSource.HandRight`.
</div>

|  |  |
|--|--|
|[InteractorSource]({{site.url}}/preview/Pages/StereoKit/InteractorSource.html) source|The source, or combination of sources, to check.|
|RETURNS: bool|True if a matching interactor has an active element.|




