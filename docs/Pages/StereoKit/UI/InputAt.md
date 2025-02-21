---
layout: default
title: UI.InputAt
description: This is an input field where users can input text to the app! Selecting it will spawn a virtual keyboard, or act as the keyboard focus. Hitting escape or enter, or focusing another UI element will remove focus from this Input.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).InputAt

<div class='signature' markdown='1'>
```csharp
static bool InputAt(string id, String& value, Vec3 topLeftCorner, Vec2 size, TextContext type)
```
This is an input field where users can input text to the
app! Selecting it will spawn a virtual keyboard, or act as the
keyboard focus. Hitting escape or enter, or focusing another UI
element will remove focus from this Input.
</div>

|  |  |
|--|--|
|string id|An id for tracking element state. MUST be unique             within current hierarchy.|
|String& value|The string that will store the Input's             content in.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|[TextContext]({{site.url}}/Pages/StereoKit/TextContext.html) type|What category of text this Input represents.             This may affect what kind of soft keyboard will be displayed, if             one is shown to the user.|
|RETURNS: bool|Returns true every time the contents of 'value' change.|




