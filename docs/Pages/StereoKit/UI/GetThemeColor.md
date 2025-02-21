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
|[UIColor]({{site.url}}/Pages/StereoKit/UIColor.html) colorCategory|The category of UI elements that are             affected by this theme color. This can be a value _past_             UIColor.Max if you need extra UIColor slots for your own custom UI             elements. If the theme slot is empty, the color will be pulled from             UIColor.None.|
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
|[UIColor]({{site.url}}/Pages/StereoKit/UIColor.html) colorCategory|The category of UI elements that are             affected by this theme color. This can be a value _past_             UIColor.Max if you need extra UIColor slots for your own custom UI             elements. If the theme slot is empty, the color will be pulled from             UIColor.None.|
|[UIColorState]({{site.url}}/Pages/StereoKit/UIColorState.html) colorState|The state of the UI element this color             applies to.|
|RETURNS: [Color]({{site.url}}/Pages/StereoKit/Color.html)|The gamma space color for the theme color category in the indicated state.|




