---
layout: default
title: UI.VSlider
description: A vertical slider element! You can stick your finger in it, and slide the value up and down.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).VSlider

<div class='signature' markdown='1'>
```csharp
static bool VSlider(string id, Single& value, float min, float max, float step, float height, UIConfirm confirmMethod, UINotify notifyOn)
```
A vertical slider element! You can stick your finger
in it, and slide the value up and down.
</div>

|  |  |
|--|--|
|string id|An id for tracking element state. MUST be unique             within current hierarchy.|
|Single& value|The value that the slider will store slider             state in.|
|float min|The minimum value the slider can set, top side             of the slider.|
|float max|The maximum value the slider can set, bottom             side of the slider.|
|float step|Locks the value to increments of step. Starts             at min, and increments by step. 0 is valid, and means "don't lock             to increments".|
|float height|Physical width of the slider on the window. 0             will fill the remaining amount of window space.|
|[UIConfirm]({{site.url}}/Pages/StereoKit/UIConfirm.html) confirmMethod|How should the slider be activated?             Push will be a push-button the user must press first, and pinch             will be a tab that the user must pinch and drag around.|
|[UINotify]({{site.url}}/Pages/StereoKit/UINotify.html) notifyOn|Allows you to modify the behavior of the             return value.|
|RETURNS: bool|Returns true any time the value changes.|

<div class='signature' markdown='1'>
```csharp
static bool VSlider(string id, Double& value, double min, double max, double step, float height, UIConfirm confirmMethod, UINotify notifyOn)
```
A vertical slider element! You can stick your finger
in it, and slide the value up and down.
</div>

|  |  |
|--|--|
|string id|An id for tracking element state. MUST be unique             within current hierarchy.|
|Double& value|The value that the slider will store slider             state in.|
|double min|The minimum value the slider can set, top side             of the slider.|
|double max|The maximum value the slider can set, bottom             side of the slider.|
|double step|Locks the value to increments of step. Starts             at min, and increments by step. 0 is valid, and means "don't lock             to increments".|
|float height|Physical height of the slider on the window. 0             will fill the remaining amount of window space.|
|[UIConfirm]({{site.url}}/Pages/StereoKit/UIConfirm.html) confirmMethod|How should the slider be activated?             Push will be a push-button the user must press first, and pinch             will be a tab that the user must pinch and drag around.|
|[UINotify]({{site.url}}/Pages/StereoKit/UINotify.html) notifyOn|Allows you to modify the behavior of the             return value.|
|RETURNS: bool|Returns true any time the value changes.|




