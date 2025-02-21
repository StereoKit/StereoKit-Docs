---
layout: default
title: Text.SizeLayout
description: Sometimes you just need to know how much room some text takes up! This finds the layout size of the text in meters when using the indicated style!  This does not include ascender and descender size, so rendering using this as a clipping size will result in ascenders and descenders getting clipped.
---
# [Text]({{site.url}}/Pages/StereoKit/Text.html).SizeLayout

<div class='signature' markdown='1'>
```csharp
static Vec2 SizeLayout(string text, TextStyle style)
```
Sometimes you just need to know how much room some text
takes up! This finds the layout size of the text in meters when
using the indicated style!  This does not include ascender and
descender size, so rendering using this as a clipping size will
result in ascenders and descenders getting clipped.
</div>

|  |  |
|--|--|
|string text|Text you want to find the size of.|
|[TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html) style|The visual style of the text, see             Text.MakeStyle or the TextStyle object for more details.|
|RETURNS: [Vec2]({{site.url}}/Pages/StereoKit/Vec2.html)|The width and height of the text in meters.|

<div class='signature' markdown='1'>
```csharp
static Vec2 SizeLayout(string text, TextStyle style, float maxWidth)
```
Need to know how much layout space text will take when
constrained to a certain width? This will find it using the
indicated text style! This does not include ascender and descender
size, so rendering using this as a clipping size will result in
ascenders and descenders getting clipped.
</div>

|  |  |
|--|--|
|string text|Text to measure the size of.|
|float maxWidth|Width of the available space in meters.|
|RETURNS: [Vec2]({{site.url}}/Pages/StereoKit/Vec2.html)|The layoutsize that this text will take up, in meters! Width will be the same as maxWidth as long as the text takes more than one line, and height will be the total layout height of the text.|





## Examples

### Text Sizes

When you need to work with placing text, `Text.SizeLayout` and
`Text.SizeRender` are the keys to the kingdom! `SizeLayout` will
give you the size of your text as far as layout is generally
concerned, while `SizeRender` will take your layout size and
provide the total bounds that you need to watch out for! Some fonts
can have absolutely _unreasonable_ ascenders and descenders for
some of  their glyphs. Extreme cases can be a bit rare, so in
general you'll only need to work with the layout size. Just watch
out when you need to clip your text!

![Text sizes]({{site.screen_url}}/Docs/Text_Sizes.jpg)
_You can see here with Segoe UI, the ascender area for rendering looks ridiculous._

In this screenshot, the black area represents the layout size,
while the gray area represents the render size. "lÔTy" is a decent
set of characters to illustrate a pretty normal range of height
variation.
```csharp
string text  = "lÔTy";
TextStyle style = TextStyle.Default;

Text.Add(text, Matrix.Identity, style, TextAlign.Center);

// Calculate the text sizes! Layout size is used for placing text, but
// render size indicates the total area where text could end up,
// accounting for _extreme_ ascenders and descenders.
Vec2 layoutSz = Text.SizeLayout(text,     style);
Vec2 renderSz = Text.SizeRender(layoutSz, style, out float renderYOff);

// Draw the layout size behind the text in black
Mesh.Quad.Draw(Material.Unlit,
	Matrix.TS(V.XYZ(0, 0, 0.0001f), (-layoutSz).XY1),
	Color.Black);

// Draw the render size behind the text in gray, note that we're
// dividing the y offset by 2 because we're drawing from the _center_
// of a quad rather than something like the top left.
Mesh.Quad.Draw(Material.Unlit,
	Matrix.TS(V.XYZ(0, renderYOff/2.0f, 0.0002f), (-renderSz).XY1),
	new Color(0.2f,0.2f,0.2f));
```

