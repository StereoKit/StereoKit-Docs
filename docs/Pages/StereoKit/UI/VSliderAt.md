---
layout: default
title: UI.VSliderAt
description: A variant of UI.VSlider that doesn't use the layout system, and instead goes exactly where you put it.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).VSliderAt

<div class='signature' markdown='1'>
```csharp
static bool VSliderAt(string id, Single& value, float min, float max, float step, Vec3 topLeftCorner, Vec2 size, UIConfirm confirmMethod, UINotify notifyOn)
```
A variant of UI.VSlider that doesn't use the layout
system, and instead goes exactly where you put it.
</div>

|  |  |
|--|--|
|string id|An id for tracking element state. MUST be unique             within current hierarchy.|
|Single& value|The value that the slider will store slider             state in.|
|float min|The minimum value the slider can set, top side             of the slider.|
|float max|The maximum value the slider can set, bottom             side of the slider.|
|float step|Locks the value to increments of step. Starts             at min, and increments by step. 0 is valid, and means "don't lock             to increments".|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|[UIConfirm]({{site.url}}/Pages/StereoKit/UIConfirm.html) confirmMethod|How should the slider be activated?             Push will be a push-button the user must press first, and pinch             will be a tab that the user must pinch and drag around.|
|[UINotify]({{site.url}}/Pages/StereoKit/UINotify.html) notifyOn|Allows you to modify the behavior of the             return value.|
|RETURNS: bool|Returns true any time the value changes.|

<div class='signature' markdown='1'>
```csharp
static bool VSliderAt(string id, Double& value, double min, double max, double step, Vec3 topLeftCorner, Vec2 size, UIConfirm confirmMethod, UINotify notifyOn)
```
A variant of UI.VSlider that doesn't use the layout
system, and instead goes exactly where you put it.
</div>

|  |  |
|--|--|
|string id|An id for tracking element state. MUST be unique             within current hierarchy.|
|Double& value|The value that the slider will store slider             state in.|
|double min|The minimum value the slider can set, top side             of the slider.|
|double max|The maximum value the slider can set, bottom             side of the slider.|
|double step|Locks the value to intervals of step. Starts             at min, and increments by step.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|[UIConfirm]({{site.url}}/Pages/StereoKit/UIConfirm.html) confirmMethod|How should the slider be activated?             Push will be a push-button the user must press first, and pinch             will be a tab that the user must pinch and drag around.|
|[UINotify]({{site.url}}/Pages/StereoKit/UINotify.html) notifyOn|Allows you to modify the behavior of the             return value.|
|RETURNS: bool|Returns true any time the value changes.|




