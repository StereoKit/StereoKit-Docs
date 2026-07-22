---
layout: default
title: UI.LastElementActive
description: Tells the Active state of the most recently called UI element that used an id.
---
# [UI]({{site.url}}/preview/Pages/StereoKit/UI.html).LastElementActive

<div class='signature' markdown='1'>
static [BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) LastElementActive{ get }
</div>

## Description
Tells the Active state of the most recently called UI
element that used an id.


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

