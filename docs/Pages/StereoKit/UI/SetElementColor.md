---
layout: default
title: UI.SetElementColor
description: This allows you to override the color category that a UI element is assigned to.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).SetElementColor

<div class='signature' markdown='1'>
```csharp
static void SetElementColor(UIVisual visual, UIColor colorCategory)
```
This allows you to override the color category that a UI
element is assigned to.
</div>

|  |  |
|--|--|
|[UIVisual]({{site.url}}/Pages/StereoKit/UIVisual.html) visual|The UI element type to set the color category             of. This can be a value _past_ UIVisual.Max if you need extra             UIVisual slots for your own custom UI elements.|
|[UIColor]({{site.url}}/Pages/StereoKit/UIColor.html) colorCategory|The category of color to assign to this             UI element. Use UI.SetThemeColor in combination with this to assign             a specific color. This can be a value _past_ UIColor.Max if you             need extra UIColor slots for your own custom UI elements.|




