---
layout: default
title: World.FromPerceptionAnchor
description: Converts a Windows.Perception.Spatial.SpatialAnchor's pose into SteroKit's coordinate system. This can be great for interacting with some of the UWP spatial APIs such as WorldAnchors.  This method only works on UWP platforms, check SK.System.perceptionBridgePresent to see if this is available.
---
# [World]({{site.url}}/Pages/StereoKit/World.html).FromPerceptionAnchor

<div class='signature' markdown='1'>
```csharp
static Pose FromPerceptionAnchor(Object perceptionSpatialAnchor)
```
Converts a Windows.Perception.Spatial.SpatialAnchor's pose
into SteroKit's coordinate system. This can be great for
interacting with some of the UWP spatial APIs such as WorldAnchors.

This method only works on UWP platforms, check
SK.System.perceptionBridgePresent to see if this is available.
</div>

|  |  |
|--|--|
|Object perceptionSpatialAnchor|A valid             Windows.Perception.Spatial.SpatialAnchor.|
|RETURNS: [Pose]({{site.url}}/Pages/StereoKit/Pose.html)|A Pose representing the current orientation of the SpatialAnchor.|

<div class='signature' markdown='1'>
```csharp
static bool FromPerceptionAnchor(Object perceptionSpatialAnchor, Pose& pose)
```
Converts a Windows.Perception.Spatial.SpatialAnchor's pose
into SteroKit's coordinate system. This can be great for
interacting with some of the UWP spatial APIs such as WorldAnchors.

This method only works on UWP platforms, check
SK.System.perceptionBridgePresent to see if this is available.
</div>

|  |  |
|--|--|
|Object perceptionSpatialAnchor|A valid             Windows.Perception.Spatial.SpatialAnchor.|
|Pose& pose|A resulting Pose representing the current             orientation of the spatial node.|
|RETURNS: bool|A Pose representing the current orientation of the SpatialAnchor.|




