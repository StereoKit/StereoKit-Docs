---
layout: default
title: UI.GetThemeColor
description: This allows you to inspect the current normal color of the theme color category! If you set the color with UI.ColorScheme, this will be one of the generated colors, and not necessarily the color that was provided there.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).GetThemeColor

<div class='signature' markdown='1'>
```csharp
static Color GetThemeColor(UIColor colorCategory)
```
This allows you to inspect the current normal color of the
theme color category! If you set the color with UI.ColorScheme,
this will be one of the generated colors, and not necessarily the
color that was provided there.
</div>

|  |  |
|--|--|
|[UIColor]({{site.url}}/Pages/StereoKit/UIColor.html) colorCategory|The category of UI elements that are             affected by this theme color.|
|RETURNS: [Color]({{site.url}}/Pages/StereoKit/Color.html)|The gamma space color for the theme color category in its normal state.|

<div class='signature' markdown='1'>
```csharp
static Color GetThemeColor(UIColor colorCategory, UIColorState colorState)
```
This allows you to inspect the current color of the theme
color category in a specific state! If you set the color with
UI.ColorScheme, or without specifying a state, this may be a
generated color, and not necessarily the color that was provided
there.
</div>

|  |  |
|--|--|
|[UIColor]({{site.url}}/Pages/StereoKit/UIColor.html) colorCategory|The category of UI elements that are             affected by this theme color.|
|[UIColorState]({{site.url}}/Pages/StereoKit/UIColorState.html) colorState|The state of the UI element this color             applies to.|
|RETURNS: [Color]({{site.url}}/Pages/StereoKit/Color.html)|The gamma space color for the theme color category in the indicated state.|

<div class='signature' markdown='1'>
```csharp
static Color GetThemeColor(UIColor colorCategory, Color colorGamma)
```
This overload is obsolete, and will be removed soon.
</div>

|  |  |
|--|--|
|[UIColor]({{site.url}}/Pages/StereoKit/UIColor.html) colorCategory|The category of UI elements that are             affected by this theme color.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) colorGamma|Unused.|
|RETURNS: [Color]({{site.url}}/Pages/StereoKit/Color.html)|The gamma space color for the theme color category in the indicated state.|




