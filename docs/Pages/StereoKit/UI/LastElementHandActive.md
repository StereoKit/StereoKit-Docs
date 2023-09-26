---
layout: default
title: UI.LastElementHandActive
description: Tells if the hand was involved in the active state of the most recently called UI element using an id. Active state is frequently a single frame in the case of Buttons, but could be many in the case of Sliders or Handles.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).LastElementHandActive

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
|[Handed]({{site.url}}/Pages/StereoKit/Handed.html) hand|Which hand we're checking.|
|RETURNS: [BtnState]({{site.url}}/Pages/StereoKit/BtnState.html)|A BtnState that indicated the hand was "just active" this frame, is currently "active" or if it "just became inactive" this frame.|





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

