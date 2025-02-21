---
layout: default
title: Text
description: A collection of functions for rendering and working with text. These are a lower level access to text rendering than the UI text functions, and are completely unaware of the UI code.
---
# static class Text

A collection of functions for rendering and working with text.
These are a lower level access to text rendering than the UI text
functions, and are completely unaware of the UI code.

## Static Methods

|  |  |
|--|--|
|[Add]({{site.url}}/Pages/StereoKit/Text/Add.html)|Renders text at the given location! Must be called every frame you want this text to be visible.|
|[MakeStyle]({{site.url}}/Pages/StereoKit/Text/MakeStyle.html)|Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project.  This overload will create a unique Material for this style based on Default.ShaderFont.|
|[Size]({{site.url}}/Pages/StereoKit/Text/Size.html)|Sometimes you just need to know how much room some text takes up! This finds the size of the text in meters when using the indicated style!|
|[SizeLayout]({{site.url}}/Pages/StereoKit/Text/SizeLayout.html)|Sometimes you just need to know how much room some text takes up! This finds the layout size of the text in meters when using the indicated style!  This does not include ascender and descender size, so rendering using this as a clipping size will result in ascenders and descenders getting clipped.|
|[SizeRender]({{site.url}}/Pages/StereoKit/Text/SizeRender.html)|This modifies a text layout size to include the tallest and lowest possible values for the glyphs in this font. This is for when you need to be careful about avoiding clipping that would happen if you only used the layout size.|
