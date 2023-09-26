---
layout: default
title: TextStyle.FromFont
description: Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project.  This overload will create a unique Material for this style based on Default.ShaderFont.
---
# [TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html).FromFont

<div class='signature' markdown='1'>
```csharp
static TextStyle FromFont(Font font, float characterHeightMeters, Color colorGamma)
```
Create a text style for use with other text functions! A
text style is a font plus size/color/material parameters, and are
used to keep text looking more consistent through the application
by encouraging devs to re-use styles throughout the project.

This overload will create a unique Material for this style based
on Default.ShaderFont.
</div>

|  |  |
|--|--|
|[Font]({{site.url}}/Pages/StereoKit/Font.html) font|Font asset you want attached to this style.|
|float characterHeightMeters|Height of a text glyph in             meters. StereoKit currently bases this on the letter 'T'.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) colorGamma|The gamma space color of the text             style. This will be embedded in the vertex color of the text             mesh.|
|RETURNS: [TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html)|A text style id for use with text rendering functions.|

<div class='signature' markdown='1'>
```csharp
static TextStyle FromFont(Font font, float characterHeightMeters, Shader shader, Color colorGamma)
```
Create a text style for use with other text functions! A
text style is a font plus size/color/material parameters, and are
used to keep text looking more consistent through the application
by encouraging devs to re-use styles throughout the project.

This overload will create a unique Material for this style based
on the provided Shader.
</div>

|  |  |
|--|--|
|[Font]({{site.url}}/Pages/StereoKit/Font.html) font|Font asset you want attached to this style.|
|float characterHeightMeters|Height of a text glyph in             meters. StereoKit currently bases this on the letter 'T'.|
|[Shader]({{site.url}}/Pages/StereoKit/Shader.html) shader|This style will create and use a unique             Material based on the Shader that you provide here.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) colorGamma|The gamma space color of the text             style. This will be embedded in the vertex color of the text             mesh.|
|RETURNS: [TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html)|A text style id for use with text rendering functions.|

<div class='signature' markdown='1'>
```csharp
static TextStyle FromFont(Font font, float characterHeightMeters, Material material, Color colorGamma)
```
Create a text style for use with other text functions! A
text style is a font plus size/color/material parameters, and are
used to keep text looking more consistent through the application
by encouraging devs to re-use styles throughout the project.

This overload allows you to set the specific Material that is
used. This can be helpful if you're keeping styles similar enough
to re-use the material and save on draw calls. If you don't know
what that means, then prefer using the overload that takes a
Shader, or takes neither a Shader nor a Material!
</div>

|  |  |
|--|--|
|[Font]({{site.url}}/Pages/StereoKit/Font.html) font|Font asset you want attached to this style.|
|float characterHeightMeters|Height of a text glyph in             meters. StereoKit currently bases this on the letter 'T'.|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) material|Which material should be used to render             the text with? Note that this does NOT duplicate the material, so             some parameters of this Material instance will get overwritten,              like the texture used for the glyph atlas. You should either use             a new Material, or a Material that was already used with this             same font.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) colorGamma|The gamma space color of the text             style. This will be embedded in the vertex color of the text             mesh.|
|RETURNS: [TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html)|A text style id for use with text rendering functions.|




