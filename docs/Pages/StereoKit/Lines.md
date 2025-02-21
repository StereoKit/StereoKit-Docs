---
layout: default
title: Lines
description: A line drawing class! This is an easy way to visualize lines or relationships between objects. The current implementation uses a quad strip that always faces the user, via vertex shader manipulation.
---
# static class Lines

A line drawing class! This is an easy way to visualize lines
or relationships between objects. The current implementation uses a
quad strip that always faces the user, via vertex shader
manipulation.

## Static Methods

|  |  |
|--|--|
|[Add]({{site.url}}/Pages/StereoKit/Lines/Add.html)|Adds a line to the environment for the current frame.|
|[AddAxis]({{site.url}}/Pages/StereoKit/Lines/AddAxis.html)|Displays an RGB/XYZ axis widget at the pose! Each line is extended along the positive direction of each axis, so the red line is +X, green is +Y, and blue is +Z. A white line is drawn along -Z to indicate the Forward vector of the pose (-Z is forward in StereoKit).|

## Examples

### Identity Pose

The identity pose is a `Pose` at (0,0,0) facing Forward, which in
StereoKit is a direction of (0,0,-1) represented by a Quaternion of
(0,0,0,1). Note that a Quaternion of (0,0,0,0) is invalid, and can
cause problems with math, so using `default` or an empty
`new Pose()` with this struct can result in bad math results.
`Pose.Identity` is a good default to get used to!

![Identity pose at the origin]({{site.screen_url}}/Docs/PoseIdentity.jpg)

Note that `Lines.AddAxis` here shows the `Pose` orientation by
drawing the pose local X+ (red) Y+ (blue) Z+ (green) axis lines in
the positive direction, and `Forward` in white.

```csharp
Pose pose = Pose.Identity;
Lines.AddAxis(pose);

// Show the origin for clarity
Lines.Add(V.XYZ(-1,0,0), V.XYZ(1,0,0), new Color32(100,0,0,100), 0.0005f);
Lines.Add(V.XYZ(0,-1,0), V.XYZ(0,1,0), new Color32(0,100,0,100), 0.0005f);
Lines.Add(V.XYZ(0,0,-1), V.XYZ(0,0,1), new Color32(0,0,100,100), 0.0005f);
```

