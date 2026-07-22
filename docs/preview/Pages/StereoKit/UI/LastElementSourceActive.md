---
layout: default
title: UI.LastElementSourceActive
description: Tells if an interactor from the given source was involved in the active state of the most recently called UI element using an id. Active state is frequently a single frame in the case of Buttons, but could be many in the case of Sliders or Handles. Sources can be combined as a bit-flag to ask about several at once.
---
# [UI]({{site.url}}/preview/Pages/StereoKit/UI.html).LastElementSourceActive

<div class='signature' markdown='1'>
```csharp
static BtnState LastElementSourceActive(InteractorSource source)
```
Tells if an interactor from the given source was involved in
the active state of the most recently called UI element using an id.
Active state is frequently a single frame in the case of Buttons, but
could be many in the case of Sliders or Handles. Sources can be
combined as a bit-flag to ask about several at once.
</div>

|  |  |
|--|--|
|[InteractorSource]({{site.url}}/preview/Pages/StereoKit/InteractorSource.html) source|The source, or combination of sources, to check.|
|RETURNS: [BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html)|A BtnState that indicates the source was "just active" this frame, is currently "active", or if it "just became inactive" this frame.|





## Examples

### Checking UI element status
It can sometimes be nice to know how the user is interacting with a
particular UI element! The UI.LastElementX functions can be used to
query a bit of this information, but only for _the most recent_ UI
element that **uses an id**!

![A window containing the status of a UI element]({{site.url}}/preview/img/screenshots/UI/LastElementAPI.jpg)

So in this example, we're querying the information for the "Slider"
UI element. Note that UI.Text does NOT use an id, which is why this
works.
```csharp
UI.WindowBegin("Last Element API", ref windowPose);

UI.HSlider("Slider", ref sliderVal, 0, 1, 0.1f, 0, UIConfirm.Pinch);
UI.Text("Element Info:", Align.TopCenter);
if (UI.LastElementSourceActive (InteractorSource.HandLeft  | InteractorSource.ControllerLeft ).IsActive()) UI.Label("Left Active");
if (UI.LastElementSourceActive (InteractorSource.HandRight | InteractorSource.ControllerRight).IsActive()) UI.Label("Right Active");
if (UI.LastElementSourceFocused(InteractorSource.HandLeft  | InteractorSource.ControllerLeft ).IsActive()) UI.Label("Left Focused");
if (UI.LastElementSourceFocused(InteractorSource.HandRight | InteractorSource.ControllerRight).IsActive()) UI.Label("Right Focused");
if (UI.LastElementFocused.IsActive()) UI.Label("Focused");
if (UI.LastElementActive .IsActive()) UI.Label("Active");

UI.WindowEnd();
```

