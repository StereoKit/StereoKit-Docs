---
layout: default
title: TextAlign
description: A bit-flag enum for describing alignment or positioning. Items can be combined using the '|' operator, like so. Align alignment = Align.YTop | Align.XLeft; Avoid combining multiple items of the same axis. There are also a complete list of valid bit flag combinations! These are the values without an axis listed in their names, 'TopLeft', 'BottomCenter', etc.
---
# struct TextAlign

A bit-flag enum for describing alignment or positioning.
Items can be combined using the '|' operator, like so:
`Align alignment = Align.YTop | Align.XLeft;`
Avoid combining multiple items of the same axis. There are also a
complete list of valid bit flag combinations! These are the values
without an axis listed in their names, 'TopLeft', 'BottomCenter',
etc.

## Static Fields and Properties

|  |  |
|--|--|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [BottomCenter]({{site.url}}/preview/Pages/StereoKit/TextAlign/BottomCenter.html)|Center on the X axis, and bottom on the Y axis. This is a combination of XCenter and YBottom.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [BottomLeft]({{site.url}}/preview/Pages/StereoKit/TextAlign/BottomLeft.html)|Start on the left of the X axis, and bottom on the Y axis. This is a combination of XLeft and YBottom.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [BottomRight]({{site.url}}/preview/Pages/StereoKit/TextAlign/BottomRight.html)|Start on the right of the X axis, and bottom on the Y axis.This is a combination of XRight and YBottom.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [Center]({{site.url}}/preview/Pages/StereoKit/TextAlign/Center.html)|Center on both X and Y axes. This is a combination of XCenter and YCenter.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [CenterLeft]({{site.url}}/preview/Pages/StereoKit/TextAlign/CenterLeft.html)|Start on the left of the X axis, center on the Y axis. This is a combination of XLeft and YCenter.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [CenterRight]({{site.url}}/preview/Pages/StereoKit/TextAlign/CenterRight.html)|Start on the right of the X axis, center on the Y axis. This is a combination of XRight and YCenter.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [TopCenter]({{site.url}}/preview/Pages/StereoKit/TextAlign/TopCenter.html)|Center on the X axis, and top on the Y axis. This is a combination of XCenter and YTop.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [TopLeft]({{site.url}}/preview/Pages/StereoKit/TextAlign/TopLeft.html)|Start on the left of the X axis, and top on the Y axis. This is a combination of XLeft and YTop.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [TopRight]({{site.url}}/preview/Pages/StereoKit/TextAlign/TopRight.html)|Start on the right of the X axis, and top on the Y axis. This is a combination of XRight and YTop.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [XCenter]({{site.url}}/preview/Pages/StereoKit/TextAlign/XCenter.html)|On the x axis, the item should be centered.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [XLeft]({{site.url}}/preview/Pages/StereoKit/TextAlign/XLeft.html)|On the x axis, this item should start on the left.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [XRight]({{site.url}}/preview/Pages/StereoKit/TextAlign/XRight.html)|On the x axis, this item should start on the right.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [YBottom]({{site.url}}/preview/Pages/StereoKit/TextAlign/YBottom.html)|On the y axis, this item should start on the bottom.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [YCenter]({{site.url}}/preview/Pages/StereoKit/TextAlign/YCenter.html)|On the y axis, the item should be centered.|
|[TextAlign]({{site.url}}/preview/Pages/StereoKit/TextAlign.html) [YTop]({{site.url}}/preview/Pages/StereoKit/TextAlign/YTop.html)|On the y axis, this item should start at the top.|

## Operators

|  |  |
|--|--|
|[op_BitwiseAnd]({{site.url}}/preview/Pages/StereoKit/TextAlign/op_BitwiseAnd.html)|Allow Flag-like enum behavior.|
|[op_BitwiseOr]({{site.url}}/preview/Pages/StereoKit/TextAlign/op_BitwiseOr.html)|Allow Flag-like enum behavior.|
|[op_ExclusiveOr]({{site.url}}/preview/Pages/StereoKit/TextAlign/op_ExclusiveOr.html)|Allow Flag-like enum behavior.|
|[Implicit Conversions]({{site.url}}/preview/Pages/StereoKit/TextAlign/op_Implicit.html)|For back compatibility, allows conversion from a TextAlign into an Align while providing a good obsolescence message for it.|
|[op_OnesComplement]({{site.url}}/preview/Pages/StereoKit/TextAlign/op_OnesComplement.html)|Allow Flag-like enum behavior.|
