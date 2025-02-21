---
layout: default
title: Text.Size
description: Sometimes you just need to know how much room some text takes up! This finds the size of the text in meters when using the indicated style!
---
# [Text]({{site.url}}/Pages/StereoKit/Text.html).Size

<div class='signature' markdown='1'>
```csharp
static Vec2 Size(string text, TextStyle style)
```
Sometimes you just need to know how much room some text
takes up! This finds the size of the text in meters when using the
indicated style!
</div>

|  |  |
|--|--|
|string text|Text you want to find the size of.|
|[TextStyle]({{site.url}}/Pages/StereoKit/TextStyle.html) style|The visual style of the text, see             Text.MakeStyle or the TextStyle object for more details.|
|RETURNS: [Vec2]({{site.url}}/Pages/StereoKit/Vec2.html)|The width and height of the text in meters.|

<div class='signature' markdown='1'>
```csharp
static Vec2 Size(string text)
```
Sometimes you just need to know how much room some text
takes up! This finds the size of the text in meters when using the
default style!
</div>

|  |  |
|--|--|
|string text|Text you want to find the size of.|
|RETURNS: [Vec2]({{site.url}}/Pages/StereoKit/Vec2.html)|The width and height of the text in meters.|

<div class='signature' markdown='1'>
```csharp
static Vec2 Size(string text, float maxWidth)
```
Need to know how much space text will take when
constrained to a certain width? This will find it using the default
text style!
</div>

|  |  |
|--|--|
|string text|Text to measure the size of.|
|float maxWidth|Width of the available space in meters.|
|RETURNS: [Vec2]({{site.url}}/Pages/StereoKit/Vec2.html)|The size that this text will take up, in meters! Width will be the same as maxWidth as long as the text takes more than one line, and height will be the total height of the text.|

<div class='signature' markdown='1'>
```csharp
static Vec2 Size(string text, TextStyle style, float maxWidth)
```
Need to know how much space text will take when
constrained to a certain width? This will find it using the
indicated text style!
</div>

|  |  |
|--|--|
|string text|Text to measure the size of.|
|float maxWidth|Width of the available space in meters.|
|RETURNS: [Vec2]({{site.url}}/Pages/StereoKit/Vec2.html)|The size that this text will take up, in meters! Width will be the same as maxWidth as long as the text takes more than one line, and height will be the total height of the text.|




