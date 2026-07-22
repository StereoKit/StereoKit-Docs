---
layout: default
title: Input.HandGetVisible
description: Returns whether StereoKit is set to render the given hand. If Handed.Max is provided, this returns true if either hand is visible.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).HandGetVisible

<div class='signature' markdown='1'>
```csharp
static bool HandGetVisible(Handed hand)
```
Returns whether StereoKit is set to render the
given hand. If Handed.Max is provided, this returns true
if either hand is visible.
</div>

|  |  |
|--|--|
|[Handed]({{site.url}}/preview/Pages/StereoKit/Handed.html) hand|The hand to check visibility for, or Handed.Max to check if either hand is visible.|
|RETURNS: bool|True if StereoKit renders this hand, false if not.|




