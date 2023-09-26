---
layout: default
title: UI.RadioAt
description: A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true. This version allows you to override the images used by the Radio.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).RadioAt

<div class='signature' markdown='1'>
```csharp
static bool RadioAt(string text, bool active, Sprite imageOff, Sprite imageOn, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size)
```
A Radio is similar to a button, except you can specify if
it looks pressed or not regardless of interaction. This can be
useful for radio-like behavior! Check an enum for a value, and use
that as the 'active' state, Then switch to that enum value if Radio
returns true. This version allows you to override the images used
by the Radio.
</div>

|  |  |
|--|--|
|string text|Text to display on the Radio and id for             tracking element state. MUST be unique within current hierarchy.|
|bool active|Does this button look like it's pressed?|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) imageOff|Image to use when the radio value is             false.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) imageOn|Image to use when the radio value is             true.|
|[UIBtnLayout]({{site.url}}/Pages/StereoKit/UIBtnLayout.html) imageLayout|This enum specifies how the text and             image should be laid out on the radio. For example,             `UIBtnLayout.Left` will have the image on the left, and text on the             right.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|RETURNS: bool|Will return true only on the first frame it is pressed!|




