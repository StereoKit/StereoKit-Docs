---
layout: default
title: UI.LastElementHandFocused
description: Tells if the hand was involved in the focus state of the most recently called UI element using an id. Focus occurs when the hand is in or near an element, in such a way that indicates the user may be about to interact with it.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).LastElementHandFocused

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
|[Handed]({{site.url}}/Pages/StereoKit/Handed.html) hand|Which hand we're checking.|
|RETURNS: [BtnState]({{site.url}}/Pages/StereoKit/BtnState.html)|A BtnState that indicated the hand was "just focused" this frame, is currently "focused" or if it "just became focused" this frame.|





## Examples

### Checking UI element status
It can sometimes be nice to know how the user is interacting with a
particular UI element! The UI.LastElementX functions can be used to
query a bit of this information, but only for _the most recent_ UI
element that **uses an id**!

![A window containing the status of a UI element]({{site.screen_url}}/UI/LastElementAPI.jpg)

So in this example, we're querying the information for the "Slider"
UI element. Note that UI.Text does NOT use an id, which is why this
works.
```csharp
UI.WindowBegin("Last Element API", ref windowPose);

UI.HSlider("Slider", ref sliderVal, 0, 1, 0.1f, 0, UIConfirm.Pinch);
UI.Text("Element Info:", TextAlign.TopCenter);
if (UI.LastElementHandActive (Handed.Left ).IsActive()) UI.Label("Left Active");
if (UI.LastElementHandActive (Handed.Right).IsActive()) UI.Label("Right Active");
if (UI.LastElementHandFocused(Handed.Left ).IsActive()) UI.Label("Left Focused");
if (UI.LastElementHandFocused(Handed.Right).IsActive()) UI.Label("Right Focused");
if (UI.LastElementFocused                  .IsActive()) UI.Label("Focused");
if (UI.LastElementActive                   .IsActive()) UI.Label("Active");

UI.WindowEnd();
```

