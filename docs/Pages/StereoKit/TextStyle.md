---
layout: default
title: TextStyle
description: A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project. See Text.MakeStyle for making a TextStyle object.
---
# struct TextStyle

A text style is a font plus size/color/material parameters,
and are used to keep text looking more consistent through the
application by encouraging devs to re-use styles throughout the
project. See Text.MakeStyle for making a TextStyle object.

## Instance Fields and Properties

|  |  |
|--|--|
|float [Ascender]({{site.url}}/Pages/StereoKit/TextStyle/Ascender.html)|(meters) The layout ascender of the font, this is the height of the "tallest" glyphs as far as layout is concerned. Characters such as 'l' typically rise above the CapHeight, and this value usually matches this height. Some glyphs such as those with hats or umlauts will almost always be taller than this height (see Text.SizeRender), but this is not used when laying out characters.|
|float [CapHeight]({{site.url}}/Pages/StereoKit/TextStyle/CapHeight.html)|(meters) The height of a standard captial letter, such as 'H' or 'T'.|
|float [CharHeight]({{site.url}}/Pages/StereoKit/TextStyle/CharHeight.html)|Returns the maximum height of a text character using this style, in meters.|
|float [Descender]({{site.url}}/Pages/StereoKit/TextStyle/Descender.html)|(meters) The layout descender of the font, this is the positive height below the baseline|
|float [LayoutHeight]({{site.url}}/Pages/StereoKit/TextStyle/LayoutHeight.html)|(meters) Layout height is the height of the font's CapHeight, which is used for calculating the vertical height of the text when doing text layouts. This does _not_ include the height of the descender, nor does it represent the maximum possible height a glyph may extend upwards (use Text.SizeRender).|
|float [LineHeightPct]({{site.url}}/Pages/StereoKit/TextStyle/LineHeightPct.html)|This is the space a full line of text takes, from baseline to baseline, as a 0-1 percentage of the font's TotalHeight. This is similar to CSS line-height, a value of 1.0 means this line's descenders will squish up adjacent to the next line's tallest ascenders.|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [Material]({{site.url}}/Pages/StereoKit/TextStyle/Material.html)|This provides a reference to the Material used by this style, so you can override certain features! Note that if you're creating TextStyles with manually provided Materials, this Material may not be unique to this style.|
|float [TotalHeight]({{site.url}}/Pages/StereoKit/TextStyle/TotalHeight.html)|(meters) Height from the layout descender to the layout ascender. This is most equivalent to the 'font-size' in CSS or other text layout tools. Since ascender and descenders can vary a lot, using LayoutHeight in many cases can lead to more consistency in the long run.|

## Static Fields and Properties

|  |  |
|--|--|
|[TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html) [Default]({{site.url}}/Pages/StereoKit/TextStyle/Default.html)|This is the default text style used by StereoKit.|

## Static Methods

|  |  |
|--|--|
|[FromFont]({{site.url}}/Pages/StereoKit/TextStyle/FromFont.html)|Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project.  This overload will create a unique Material for this style based on Default.ShaderFont.|

## Examples

### TextStyle Info
If you're doing advanced text layout, StereoKit does provide some
information about the font underlying the TextStyle! Here's a
quick sketch that shows what all that info represents:

![Where style info lands on text]({{site.screen_url}}/Docs/Text_StyleInfo.jpg)

```csharp
// Some representative characters:
// l frequently goes above CapHeight all the way to the Ascender.
// Ô will go past the Ascender outside the layout bounds, and slightly below the baseline.
// T goes the whole way from Baseline to CapHeight.
// y will go all the way down to the descender.
string text = "lÔTy";

// Draw the text
Text.Add(text, Matrix.Identity, style, TextAlign.TopLeft, TextAlign.TopLeft);

// Show the bounding regions for the size of the text
Color colLayoutArea = new Color(0.1f,  0.1f, 0.1f);
Color colRenderArea = new Color(0.25f, 0.5f, 0.25f);

Vec2 size  = Text.SizeLayout(text, style);
Vec2 sizeR = Text.SizeRender(size, style, out float yOff);

Mesh.Quad.Draw(Material.Unlit, Matrix.TS(size .XY0/-2 + V.XYZ(0, 0,    0.0001f), size .XY1), colLayoutArea);
Mesh.Quad.Draw(Material.Unlit, Matrix.TS(sizeR.XY0/-2 + V.XYZ(0, yOff, 0.0002f), sizeR.XY1), colRenderArea);

// Show lines representing the typography units for this style
Color32 colCapHeight  = new Color32( 50, 255,  50, 255);
Color32 colBaseline   = new Color32(255, 255, 255, 255);
Color32 colAscender   = new Color32(255,  50,  50, 255);
Color32 colDescender  = new Color32( 50,  50, 255, 255);
Color32 colLineHeight = new Color32(255, 255, 255, 255);

float baselineAt   = -style.CapHeight;
float ascenderAt   = baselineAt + style.Ascender;
float capHeightAt  = baselineAt + style.CapHeight;
float descenderAt  = baselineAt - style.Descender;
float lineHeightAt = ascenderAt - style.LineHeightPct * style.TotalHeight;

Lines.Add(V.XY0(0, ascenderAt  ), V.XY0(-size.x, ascenderAt  ), colAscender,   0.003f);
Lines.Add(V.XY0(0, baselineAt  ), V.XY0(-size.x, baselineAt  ), colBaseline,   0.003f);
Lines.Add(V.XY0(0, capHeightAt ), V.XY0(-size.x, capHeightAt ), colCapHeight,  0.003f);
Lines.Add(V.XY0(0, descenderAt ), V.XY0(-size.x, descenderAt ), colDescender,  0.003f);
Lines.Add(V.XY0(0, lineHeightAt), V.XY0(-size.x, lineHeightAt), colLineHeight, 0.003f);
```

