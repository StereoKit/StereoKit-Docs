---
layout: default
title: UI.ProgressBarAt
description: This is a simple horizontal progress indicator bar. This is used by the HSlider to draw the slider bar beneath the interactive element. Does not include any text or label.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).ProgressBarAt

<div class='signature' markdown='1'>
```csharp
static void ProgressBarAt(float percent, Vec3 topLeftCorner, Vec2 size, UIDir barDirection, bool flipFillDirection)
```
This is a simple horizontal progress indicator bar. This
is used by the HSlider to draw the slider bar beneath the
interactive element. Does not include any text or label.
</div>

|  |  |
|--|--|
|float percent|A value between 0 and 1 indicating progress             from 0% to 100%.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) topLeftCorner|This is the top left corner of the UI             element relative to the current Hierarchy.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The layout size for this element in Hierarchy             space.|




