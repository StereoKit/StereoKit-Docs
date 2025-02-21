---
layout: default
title: UI.GetElementColor
description: This will get a final linear draw color for a particular UI element type with a particular focus value. This obeys the current hierarchy of tinting and enabled states.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).GetElementColor

<div class='signature' markdown='1'>
```csharp
static Color GetElementColor(UIVisual elementVisual, float focus)
```
This will get a final linear draw color for a particular
UI element type with a particular focus value. This obeys the
current hierarchy of tinting and enabled states.
</div>

|  |  |
|--|--|
|[UIVisual]({{site.url}}/Pages/StereoKit/UIVisual.html) elementVisual|Get the color from this element type.             This can be a value _past_ UIVisual.Max to use extra UIVisual slots             for your own custom UI elements. If these slots are empty, SK will             fall back to UIVisual.Default.|
|float focus|The amount of visual focus this element             currently has, where 0 is unfocused, and 1 is active. You can             acquire a good focus value from `UI.GetAnimFocus`|
|RETURNS: [Color]({{site.url}}/Pages/StereoKit/Color.html)|A linear color good for tinting UI meshes.|




