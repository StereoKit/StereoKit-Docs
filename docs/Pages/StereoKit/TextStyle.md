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
|float [CharHeight]({{site.url}}/Pages/StereoKit/TextStyle/CharHeight.html)|Returns the maximum height of a text character using this style, in meters.|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [Material]({{site.url}}/Pages/StereoKit/TextStyle/Material.html)|This provides a reference to the Material used by this style, so you can override certain features! Note that if you're creating TextStyles with manually provided Materials, this Material may not be unique to this style.|

## Static Fields and Properties

|  |  |
|--|--|
|[TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html) [Default]({{site.url}}/Pages/StereoKit/TextStyle/Default.html)|This is the default text style used by StereoKit.|

## Static Methods

|  |  |
|--|--|
|[FromFont]({{site.url}}/Pages/StereoKit/TextStyle/FromFont.html)|Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project.  This overload will create a unique Material for this style based on Default.ShaderFont.|
