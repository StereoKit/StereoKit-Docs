---
layout: default
title: SpatialNodeType.Dynamic
description: Dynamic spatial nodes track the pose of a physical object that moves continuously relative to reference spaces. The pose of dynamic spatial nodes can be very different within the duration of a rendering frame. It is important for the application to use the correct timestamp to query the space location. For example, a color camera mounted in front of a HMD is also tracked by the HMD so a web camera library can use a dynamic node to represent the camera location.
---
# [SpatialNodeType]({{site.url}}/Pages/StereoKit/SpatialNodeType.html).Dynamic

<div class='signature' markdown='1'>
static [SpatialNodeType]({{site.url}}/Pages/StereoKit/SpatialNodeType.html) Dynamic
</div>

## Description
Dynamic spatial nodes track the pose of a physical object
that moves continuously relative to reference spaces. The pose of
dynamic spatial nodes can be very different within the duration of
a rendering frame. It is important for the application to use the
correct timestamp to query the space location. For example, a color
camera mounted in front of a HMD is also tracked by the HMD so a
web camera library can use a dynamic node to represent the camera
location.

