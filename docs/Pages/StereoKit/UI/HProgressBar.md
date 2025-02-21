---
layout: default
title: UI.HProgressBar
description: This is a simple horizontal progress indicator bar. This is used by the HSlider to draw the slider bar beneath the interactive element. Does not include any text or label.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).HProgressBar

<div class='signature' markdown='1'>
```csharp
static void HProgressBar(float percent, float width, bool flipFillDirection)
```
This is a simple horizontal progress indicator bar. This
is used by the HSlider to draw the slider bar beneath the
interactive element. Does not include any text or label.
</div>

|  |  |
|--|--|
|float percent|A value between 0 and 1 indicating progress             from 0% to 100%.|
|float width|Physical width of the slider on the window. 0             will fill the remaining amount of window space.|
|bool flipFillDirection|By default, this fills from left to             right. This allows you to flip the fill direction to right to left.|




