---
layout: default
title: Input.HandSource
description: This gets the _current_ source of the hand joints! This allows you to distinguish between fully articulated joints, and simulated hand joints that may not have the same range of mobility. Note that this may change during a session, the user may put down their controllers, automatically switching to hands, or visa versa.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).HandSource

<div class='signature' markdown='1'>
```csharp
static HandSource HandSource(Handed hand)
```
This gets the _current_ source of the hand joints! This
allows you to distinguish between fully articulated joints, and
simulated hand joints that may not have the same range of mobility.
Note that this may change during a session, the user may put down
their controllers, automatically switching to hands, or visa versa.
</div>

|  |  |
|--|--|
|[Handed]({{site.url}}/Pages/StereoKit/Handed.html) hand|Do  you want the left or right hand? 0 is left,             and 1 is right.|
|RETURNS: [HandSource]({{site.url}}/Pages/StereoKit/HandSource.html)|Returns information about hand tracking data source.|




