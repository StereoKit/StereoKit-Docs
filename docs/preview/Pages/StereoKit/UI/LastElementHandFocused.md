---
layout: default
title: UI.LastElementHandFocused
description: Tells if the hand was involved in the focus state of the most recently called UI element using an id. Focus occurs when the hand is in or near an element, in such a way that indicates the user may be about to interact with it.
---
# [UI]({{site.url}}/preview/Pages/StereoKit/UI.html).LastElementHandFocused

<div class='signature' markdown='1'>
```csharp
static BtnState LastElementHandFocused(Handed hand)
```
Tells if the hand was involved in the focus state of the
most recently called UI element using an id. Focus occurs when the
hand is in or near an element, in such a way that indicates the
user may be about to interact with it.
</div>

|  |  |
|--|--|
|[Handed]({{site.url}}/preview/Pages/StereoKit/Handed.html) hand|Which hand we're checking.|
|RETURNS: [BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html)|A BtnState that indicated the hand was "just focused" this frame, is currently "focused" or if it "just became focused" this frame.|




