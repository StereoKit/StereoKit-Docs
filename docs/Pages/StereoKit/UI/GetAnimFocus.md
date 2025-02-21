---
layout: default
title: UI.GetAnimFocus
description: This resolves a UI element with an ID and its current states into a nicely animated focus value.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).GetAnimFocus

<div class='signature' markdown='1'>
```csharp
static float GetAnimFocus(IdHash id, BtnState focusState, BtnState activationState)
```
This resolves a UI element with an ID and its current
states into a nicely animated focus value.
</div>

|  |  |
|--|--|
|[IdHash]({{site.url}}/Pages/StereoKit/IdHash.html) id|The hierarchical id of the UI element we're             checking the focus of, this can be created with `UI.StackHash`.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) focusState|The current focus state of the UI element.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) activationState|The current activation status of the             UI element.|
|RETURNS: float|A focus value in the realm of 0-1, where 0 is unfocused, and 1 is active.|




