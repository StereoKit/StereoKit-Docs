---
layout: default
title: Pose.Lerp
description: Interpolates between two poses! It is unclamped, so values outside of (0,1) will extrapolate their position.
---
# [Pose]({{site.url}}/Pages/StereoKit/Pose.html).Lerp

<div class='signature' markdown='1'>
```csharp
static Pose Lerp(Pose a, Pose b, float percent)
```
Interpolates between two poses! It is unclamped, so values
outside of (0,1) will extrapolate their position.
</div>

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) a|Starting pose, or percent == 0|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) b|Ending pose, or percent == 1|
|float percent|A value usually 0->1 that tells the blend             between a and b.|
|RETURNS: [Pose]({{site.url}}/Pages/StereoKit/Pose.html)|A new pose, blended between a and b based on percent!|





## Examples

### Lerping Poses

![Lerping between two poses]({{site.screen_url}}/Docs/PoseLerp.jpg)

Here we construct two `Pose`s, one using a position + direction
constructor, and one using a from -> to LookAt function. Both are
valid ways of constructing a `Pose`, check out the [`Quat`]({{site.url}}/Pages/StereoKit/Quat.html)
functions for more tools for creating `Pose` orientations!

After that, we're just blending between these two `Pose`s with a
`Pose.Lerp`, and showing the result at 10% intervals.
```csharp
Pose a = new Pose(0, 0.5f, -0.5f, Quat.LookDir(1,0,0));
Pose b = Pose.LookAt(V.XYZ(0,0,0), V.XYZ(0,1,0));

for (int i = 0; i < 11; i++) {
	Pose p = Pose.Lerp(a, b, i/10.0f);
	Lines.AddAxis(p, 0.05f);
}

// Show the origin for clarity
Lines.Add(V.XYZ(-1,0,0), V.XYZ(1,0,0), new Color32(100,0,0,100), 0.0025f);
Lines.Add(V.XYZ(0,-1,0), V.XYZ(0,1,0), new Color32(0,100,0,100), 0.0025f);
Lines.Add(V.XYZ(0,0,-1), V.XYZ(0,0,1), new Color32(0,0,100,100), 0.0025f);
```

