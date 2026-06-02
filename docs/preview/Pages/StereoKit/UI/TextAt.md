---
layout: default
title: UI.TextAt
description: Displays a large chunk of text on the current layout. This can include new lines and spaces, and will properly wrap once it fills the entire layout! Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle.
---
# [UI]({{site.url}}/preview/Pages/StereoKit/UI.html).TextAt

<div class='signature' markdown='1'>
```csharp
static void TextAt(string text, Align textAlign, TextFit fit, Vec3 topLeftCorner, Vec2 size)
```
Displays a large chunk of text on the current layout.
This can include new lines and spaces, and will properly wrap
once it fills the entire layout! Text uses the UI's current font
settings, which can be changed with UI.Push/PopTextStyle.
</div>

|  |  |
|--|--|
|string text|The text you wish to display, there's no             additional parsing done to this text, so put it in as you want to             see it!|
|[Align]({{site.url}}/preview/Pages/StereoKit/Align.html) textAlign|Where should the text position itself             within its bounds? Align.TopLeft is how most English text is             aligned.|
|[TextFit]({{site.url}}/preview/Pages/StereoKit/TextFit.html) fit|Describe how the text should behave when one of             its size dimensions conflicts with the provided 'size' parameter.             `UI.Text` uses `TextFit.Wrap` by default.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/preview/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|

<div class='signature' markdown='1'>
```csharp
static bool TextAt(string text, Vec2& scroll, UIScroll scrollDirection, Align textAlign, TextFit fit, Vec3 topLeftCorner, Vec2 size)
```
A scrolling text element! This is for reading large chunks
of text that may be too long to fit in the available space. It
requires a size, as well as a place to store the current scroll
value. Text uses the UI's current font settings, which can be
changed with UI.Push/PopTextStyle.
</div>

|  |  |
|--|--|
|string text|The text you wish to display, there's no             additional parsing done to this text, so put it in as you want to             see it!|
|Vec2& scroll|This is the current scroll value of the text,             in meters, _not_ percent.|
|[UIScroll]({{site.url}}/preview/Pages/StereoKit/UIScroll.html) scrollDirection|What scroll bars are allowed to show             on this text? Vertical, horizontal, both?|
|[Vec2]({{site.url}}/preview/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|[Align]({{site.url}}/preview/Pages/StereoKit/Align.html) textAlign|Where should the text position itself             within its bounds? Align.TopLeft is how most English text is             aligned.|
|[TextFit]({{site.url}}/preview/Pages/StereoKit/TextFit.html) fit|Describe how the text should behave when one of             its size dimensions conflicts with the provided 'size' parameter.             `UI.Text` uses `TextFit.Wrap` by default, and this scrolling             overload will always add `TextFit.Clip` internally.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/preview/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|RETURNS: bool|Returns true if any of the scroll bars have changed this frame.|




