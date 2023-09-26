---
layout: default
title: UI.SetThemeColor
description: This allows you to explicitly set a theme color, for finer grained control over the UI appearance. Each theme type is still used by many different UI elements. This will automatically generate colors for different UI element states.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).SetThemeColor

<div class='signature' markdown='1'>
```csharp
static void SetThemeColor(UIColor colorCategory, Color colorGamma)
```
This allows you to explicitly set a theme color, for finer
grained control over the UI appearance. Each theme type is still
used by many different UI elements. This will automatically
generate colors for different UI element states.
</div>

|  |  |
|--|--|
|[UIColor]({{site.url}}/Pages/StereoKit/UIColor.html) colorCategory|The category of UI elements that will             be affected by this theme color.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) colorGamma|The gamma corrected color that should be             applied to this theme color category in its normal resting state.             Active and disabled colors will be generated based on this color.|

<div class='signature' markdown='1'>
```csharp
static void SetThemeColor(UIColor colorCategory, UIColorState colorState, Color colorGamma)
```
This allows you to explicitly set a theme color, for finer
grained control over the UI appearance. Each theme type is still
used by many different UI elements. This applies specifically to
one state of this color category, and does not modify the others.
</div>

|  |  |
|--|--|
|[UIColor]({{site.url}}/Pages/StereoKit/UIColor.html) colorCategory|The category of UI elements that will             be affected by this theme color.|
|[UIColorState]({{site.url}}/Pages/StereoKit/UIColorState.html) colorState|The state of the UI element this color             should apply to.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) colorGamma|The gamma corrected color that should be             applied to this theme color category in the indicated state.|




