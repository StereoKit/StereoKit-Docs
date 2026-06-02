---
layout: default
title: Pointer
description: Pointer is an abstraction of a number of different input sources, and a way to surface input events!
---
# struct Pointer

Pointer is an abstraction of a number of different input sources,
and a way to surface input events!

## Instance Fields and Properties

|  |  |
|--|--|
|[Quat]({{site.url}}/preview/Pages/StereoKit/Quat.html) [orientation]({{site.url}}/preview/Pages/StereoKit/Pointer/orientation.html)|Orientation of the pointer! Since a Ray has no concept of 'up', this can be used to retrieve more orientation information.|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) [Pose]({{site.url}}/preview/Pages/StereoKit/Pointer/Pose.html)|Convenience property that turns ray.position and orientation into a Pose.|
|[Ray]({{site.url}}/preview/Pages/StereoKit/Ray.html) [ray]({{site.url}}/preview/Pages/StereoKit/Pointer/ray.html)|A ray in the direction of the pointer.|
|[InputSource]({{site.url}}/preview/Pages/StereoKit/InputSource.html) [source]({{site.url}}/preview/Pages/StereoKit/Pointer/source.html)|What input source did this pointer come from? This is a bit-flag that contains input family and capability information.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [state]({{site.url}}/preview/Pages/StereoKit/Pointer/state.html)|What is the state of the input source's 'button', if it has one?|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [tracked]({{site.url}}/preview/Pages/StereoKit/Pointer/tracked.html)|Is the pointer source being tracked right now?|
