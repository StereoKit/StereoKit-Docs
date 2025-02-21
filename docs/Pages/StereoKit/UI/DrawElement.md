---
layout: default
title: UI.DrawElement
description: This will draw a visual element from StereoKit's theming system, while paying attention to certain factors such as enabled/ disabled, tinting and more.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).DrawElement

<div class='signature' markdown='1'>
```csharp
static void DrawElement(UIVisual elementVisual, Vec3 start, Vec3 size, float focus)
```
This will draw a visual element from StereoKit's theming
system, while paying attention to certain factors such as enabled/
disabled, tinting and more.
</div>

|  |  |
|--|--|
|[UIVisual]({{site.url}}/Pages/StereoKit/UIVisual.html) elementVisual|The element type to draw. This can             be a value _past_ UIVisual.Max to use extra UIVisual slots for             your own custom UI elements. If these slots are empty, SK will fall             back to UIVisual.Default.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) start|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) size|The layout size for this element in Hierarchy             space.|
|float focus|The amount of visual focus this element             currently has, where 0 is unfocused, and 1 is active. You can             acquire a good focus value from `UI.GetAnimFocus`.|

<div class='signature' markdown='1'>
```csharp
static void DrawElement(UIVisual elementVisual, UIVisual elementColor, Vec3 start, Vec3 size, float focus)
```
This will draw a visual element from StereoKit's theming
system, while paying attention to certain factors such as enabled/
disabled, tinting and more.
</div>

|  |  |
|--|--|
|[UIVisual]({{site.url}}/Pages/StereoKit/UIVisual.html) elementVisual|The element type to draw. This can             be a value _past_ UIVisual.Max to use extra UIVisual slots for             your own custom UI elements. If these slots are empty, SK will fall             back to UIVisual.Default.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) start|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) size|The layout size for this element in Hierarchy             space.|
|float focus|The amount of visual focus this element             currently has, where 0 is unfocused, and 1 is active. You can             acquire a good focus value from `UI.GetAnimFocus`.|
|[UIVisual]({{site.url}}/Pages/StereoKit/UIVisual.html) elementColor|If you wish to use the coloring from a             different element, you can use this to override the theme color             used when drawing. This can be a value _past_ UIVisual.Max to use             extra UIVisual slots for your own custom UI elements. If these             slots are empty, SK will fall back to UIVisual.Default.|




