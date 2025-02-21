---
layout: default
title: UI.Text
description: Displays a large chunk of text on the current layout. This can include new lines and spaces, and will properly wrap once it fills the entire layout! Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).Text

<div class='signature' markdown='1'>
```csharp
static void Text(string text, TextAlign textAlign)
```
Displays a large chunk of text on the current layout.
This can include new lines and spaces, and will properly wrap
once it fills the entire layout! Text uses the UI's current font
settings, which can be changed with UI.Push/PopTextStyle.
</div>

|  |  |
|--|--|
|string text|The text you wish to display, there's no              additional parsing done to this text, so put it in as you want to             see it!|
|[TextAlign]({{site.url}}/Pages/StereoKit/TextAlign.html) textAlign|Where should the text position itself             within its bounds? TextAlign.TopLeft is how most English text is             aligned.|

<div class='signature' markdown='1'>
```csharp
static void Text(string text, TextAlign textAlign, TextFit fit, Vec2 size)
```
Displays a large chunk of text on the current layout.
This can include new lines and spaces, and will properly wrap
once it fills the entire layout! Text uses the UI's current font
settings, which can be changed with UI.Push/PopTextStyle.
</div>

|  |  |
|--|--|
|string text|The text you wish to display, there's no             additional parsing done to this text, so put it in as you want to             see it!|
|[TextAlign]({{site.url}}/Pages/StereoKit/TextAlign.html) textAlign|Where should the text position itself             within its bounds? TextAlign.TopLeft is how most English text is             aligned.|
|[TextFit]({{site.url}}/Pages/StereoKit/TextFit.html) fit|Describe how the text should behave when one of             its size dimensions conflicts with the provided 'size' parameter.             `UI.Text` uses `TextFit.Wrap` by default.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space. If an axis is left as zero, it will be auto-calculated. For             X this is the remaining width of the current layout, and for Y this             is UI.LineHeight.|

<div class='signature' markdown='1'>
```csharp
static bool Text(string text, Vec2& scroll, UIScroll scrollDirection, Vec2 size, TextAlign textAlign, TextFit fit)
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
|[UIScroll]({{site.url}}/Pages/StereoKit/UIScroll.html) scrollDirection|What scroll bars are allowed to show             on this text? Vertical, horizontal, both?|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|
|[TextAlign]({{site.url}}/Pages/StereoKit/TextAlign.html) textAlign|Where should the text position itself             within its bounds? TextAlign.TopLeft is how most English text is             aligned.|
|[TextFit]({{site.url}}/Pages/StereoKit/TextFit.html) fit|Describe how the text should behave when one of             its size dimensions conflicts with the provided 'size' parameter.             `UI.Text` uses `TextFit.Wrap` by default, and this scrolling             overload will always add `TextFit.Clip` internally.|
|RETURNS: bool|Returns true if any of the scroll bars have changed this frame.|

<div class='signature' markdown='1'>
```csharp
static bool Text(string text, Vec2& scroll, UIScroll scrollDirection, float height, TextAlign textAlign, TextFit fit)
```
A scrolling text element! This is for reading large chunks
of text that may be too long to fit in the available space. It
requires a height, as well as a place to store the current scroll
value. Text uses the UI's current font settings, which can be
changed with UI.Push/PopTextStyle.
</div>

|  |  |
|--|--|
|string text|The text you wish to display, there's no             additional parsing done to this text, so put it in as you want to             see it!|
|Vec2& scroll|This is the current scroll value of the text,             in meters, _not_ percent.|
|[UIScroll]({{site.url}}/Pages/StereoKit/UIScroll.html) scrollDirection|What scroll bars are allowed to show             on this text? Vertical, horizontal, both?|
|float height|The vertical height of this Text element,             width will automatically take the remainder of the current layout             width.|
|[TextAlign]({{site.url}}/Pages/StereoKit/TextAlign.html) textAlign|Where should the text position itself             within its bounds? TextAlign.TopLeft is how most English text is             aligned.|
|[TextFit]({{site.url}}/Pages/StereoKit/TextFit.html) fit|Describe how the text should behave when one of             its size dimensions conflicts with the provided 'size' parameter.             `UI.Text` uses `TextFit.Wrap` by default, and this scrolling             overload will always add `TextFit.Clip` internally.|
|RETURNS: bool|Returns true if any of the scroll bars have changed this frame.|





## Examples

### Separating UI Visually

![A window with text and a separator]({{site.screen_url}}/UI/SeparatorWindow.jpg)

A separator is a simple visual element that fills the window
horizontally. It's nothing complicated, but can help create visual
association between groups of UI elements.

```csharp
Pose windowPoseSeparator = new Pose(.6f, 0, 0, Quat.Identity);
void ShowWindowSeparator()
{
	UI.WindowBegin("Window Separator", ref windowPoseSeparator, UIWin.Body);

	UI.Label("Content Header");
	UI.HSeparator();
	UI.Text("A separator can go a long way towards making your content "
	      + "easier to look at!", TextAlign.TopCenter);

	UI.WindowEnd();
}
```
### Scrolling Text

`UI.Text` has an optional overload that allows you to scroll long
chunks of text! Here's a simple example that allows you to scroll some
Lorem Ipsum text vertically.

![A window with a scrolling text box]({{site.screen_url}}/UI/TextScrollWindow.jpg)
```csharp
Pose windowPoseScroll = new Pose(2.1f, 0, 0, Quat.Identity);
Vec2 scroll           = V.XY(0,0.1f);
void ShowWindowTextScroll()
{
	UI.WindowBegin("Window Text Scroll", ref windowPoseScroll);

	UI.Text(loremIpsum, ref scroll, UIScroll.Vertical, 0.1f);

	UI.WindowEnd();
}
```

