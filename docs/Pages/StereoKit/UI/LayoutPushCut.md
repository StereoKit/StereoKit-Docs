---
layout: default
title: UI.LayoutPushCut
description: This cuts off a portion of the current layout area, and pushes that new area onto the layout stack. Left and Top cuts will always work, but Right and Bottom cuts can only exist inside of a parent layout with an explicit size, auto-resizing prevents these cuts. All UI elements using the layout system will now exist inside this layout area! Note that some UI elements such as Windows will already be managing a layout of their own on the stack.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).LayoutPushCut

<div class='signature' markdown='1'>
```csharp
static void LayoutPushCut(UICut cutTo, float sizeMeters, bool addMargin)
```
This cuts off a portion of the current layout area, and
pushes that new area onto the layout stack. Left and Top cuts will
always work, but Right and Bottom cuts can only exist inside of a
parent layout with an explicit size, auto-resizing prevents these
cuts.
All UI elements using the layout system will now exist inside this
layout area! Note that some UI elements such as Windows will already be
managing a layout of their own on the stack.
</div>

|  |  |
|--|--|
|[UICut]({{site.url}}/Pages/StereoKit/UICut.html) cutTo|Which side of the current layout should the cut             happen to? Note that Right and Bottom will require explicit sizes             in the parent layout, not auto-sizes.|
|float sizeMeters|The size of the layout cut, in meters.|
|bool addMargin|Adds a spacing margin to the interior of             the layout. Most of the time you won't need this, but may be useful             when working without a Window.|




