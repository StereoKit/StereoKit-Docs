---
layout: default
title: UI.VProgressBar
description: This is a simple vertical progress indicator bar. This is used by the VSlider to draw the slider bar beneath the interactive element. Does not include any text or label.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).VProgressBar

<div class='signature' markdown='1'>
```csharp
static void VProgressBar(float percent, float height, bool flipFillDirection)
```
This is a simple vertical progress indicator bar. This
is used by the VSlider to draw the slider bar beneath the
interactive element. Does not include any text or label.
</div>

|  |  |
|--|--|
|float percent|A value between 0 and 1 indicating progress             from 0% to 100%.|
|float height|Physical height of the slider on the window. 0             will fill the remaining amount of window space.|
|bool flipFillDirection|By default, this fills from top to             bottom. This allows you to flip the fill direction to bottom to              top.|




