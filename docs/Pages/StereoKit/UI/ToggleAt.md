---
layout: default
title: UI.ToggleAt
description: A variant of UI.Toggle that doesn't use the layout system, and instead goes exactly where you put it.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).ToggleAt

<div class='signature' markdown='1'>
```csharp
static bool ToggleAt(string text, Boolean& value, Vec3 topLeftCorner, Vec2 size)
```
A variant of UI.Toggle that doesn't use the layout system,
and instead goes exactly where you put it.
</div>

|  |  |
|--|--|
|string text|Text to display on the Toggle and id for             tracking element state. MUST be unique within current hierarchy.|
|Boolean& value|The current state of the toggle button! True              means it's toggled on, and false means it's toggled off.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|RETURNS: bool|Will return true any time the toggle value changes, NOT the toggle value itself!|

<div class='signature' markdown='1'>
```csharp
static bool ToggleAt(string text, Boolean& value, Sprite image, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size)
```
A variant of UI.Toggle that doesn't use the layout system,
and instead goes exactly where you put it.
</div>

|  |  |
|--|--|
|string text|Text to display on the Toggle and id for             tracking element state. MUST be unique within current hierarchy.|
|Boolean& value|The current state of the toggle button! True              means it's toggled on, and false means it's toggled off.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) image|Image to use for the button, this will be used             regardless of the toggle value.|
|[UIBtnLayout]({{site.url}}/Pages/StereoKit/UIBtnLayout.html) imageLayout|This enum specifies how the text and             image should be laid out on the button. For example, `UIBtnLayout.Left`             will have the image on the left, and text on the right.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|RETURNS: bool|Will return true any time the toggle value changes, NOT the toggle value itself!|

<div class='signature' markdown='1'>
```csharp
static bool ToggleAt(string text, Boolean& value, Sprite toggleOff, Sprite toggleOn, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size)
```
A variant of UI.Toggle that doesn't use the layout system,
and instead goes exactly where you put it.
</div>

|  |  |
|--|--|
|string text|Text to display on the Toggle and id for             tracking element state. MUST be unique within current hierarchy.|
|Boolean& value|The current state of the toggle button! True              means it's toggled on, and false means it's toggled off.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) toggleOff|Image to use when the toggle value is             false.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) toggleOn|Image to use when the toggle value is             true.|
|[UIBtnLayout]({{site.url}}/Pages/StereoKit/UIBtnLayout.html) imageLayout|This enum specifies how the text and             image should be laid out on the button. For example, `UIBtnLayout.Left`             will have the image on the left, and text on the right.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|RETURNS: bool|Will return true any time the toggle value changes, NOT the toggle value itself!|




