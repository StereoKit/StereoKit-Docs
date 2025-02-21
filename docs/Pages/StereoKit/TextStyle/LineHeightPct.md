---
layout: default
title: TextStyle.LineHeightPct
description: This is the space a full line of text takes, from baseline to baseline, as a 0-1 percentage of the font's TotalHeight. This is similar to CSS line-height, a value of 1.0 means this line's descenders will squish up adjacent to the next line's tallest ascenders.
---
# [TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html).LineHeightPct

<div class='signature' markdown='1'>
float LineHeightPct{ get set }
</div>

## Description
This is the space a full line of text takes, from baseline
to baseline, as a 0-1 percentage of the font's TotalHeight. This
is similar to CSS line-height, a value of 1.0 means this line's
descenders will squish up adjacent to the next line's tallest
ascenders.


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

