---
layout: default
title: SKSettings.origin
description: Set the behavior of StereoKit's initial origin. Default behavior is OriginMode.Local, which is the most universally supported origin mode. Different origin modes have varying levels of support on different XR runtimes, and StereoKit will provide reasonable fallbacks for each. NOTE that when falling back, StereoKit will use a different root origin mode plus an offset. You can check World.OriginMode and World.OriginOffset to inspect what StereoKit actually landed on.
---
# [SKSettings]({{site.url}}/Pages/StereoKit/SKSettings.html).origin

<div class='signature' markdown='1'>
[OriginMode]({{site.url}}/Pages/StereoKit/OriginMode.html) origin
</div>

## Description
Set the behavior of StereoKit's initial origin. Default
behavior is OriginMode.Local, which is the most universally
supported origin mode. Different origin modes have varying levels
of support on different XR runtimes, and StereoKit will provide
reasonable fallbacks for each. NOTE that when falling back,
StereoKit will use a different root origin mode plus an offset. You
can check World.OriginMode and World.OriginOffset to inspect what
StereoKit actually landed on.

