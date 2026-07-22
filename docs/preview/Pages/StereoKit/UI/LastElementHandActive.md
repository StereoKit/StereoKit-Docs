---
layout: default
title: UI.LastElementHandActive
description: Tells if the hand was involved in the active state of the most recently called UI element using an id. Active state is frequently a single frame in the case of Buttons, but could be many in the case of Sliders or Handles.
---
# [UI]({{site.url}}/preview/Pages/StereoKit/UI.html).LastElementHandActive

<div class='signature' markdown='1'>
```csharp
static BtnState LastElementHandActive(Handed hand)
```
Tells if the hand was involved in the active state of the
most recently called UI element using an id. Active state is
frequently a single frame in the case of Buttons, but could be many
in the case of Sliders or Handles.
</div>

|  |  |
|--|--|
|[Handed]({{site.url}}/preview/Pages/StereoKit/Handed.html) hand|Which hand we're checking.|
|RETURNS: [BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html)|A BtnState that indicated the hand was "just active" this frame, is currently "active" or if it "just became inactive" this frame.|




