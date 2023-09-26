---
layout: default
title: UI.LayoutPush
description: This pushes a layout rect onto the layout stack. All UI elements using the layout system will now exist inside this layout area! Note that some UI elements such as Windows will already be managing a layout of their own on the stack.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).LayoutPush

<div class='signature' markdown='1'>
```csharp
static void LayoutPush(Vec3 start, Vec2 dimensions, bool addMargin)
```
This pushes a layout rect onto the layout stack. All UI
elements using the layout system will now exist inside this layout
area! Note that some UI elements such as Windows will already be
managing a layout of their own on the stack.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) start|The top left position of the layout. Note that             Windows have their origin at the top center, the left side of a             window is X+, and content advances to the X- direction.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) dimensions|The total size of the layout area. A value             of zero means the layout will expand in that axis, but may prevent             certain types of layout "Cuts".|
|bool addMargin|Adds a spacing margin to the interior of             the layout. Most of the time you won't need this, but may be useful             when working without a Window.|




