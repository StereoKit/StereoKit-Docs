---
layout: default
title: Lines.AddAxis
description: Displays an RGB/XYZ axis widget at the pose! Each line is extended along the positive direction of each axis, so the red line is +X, green is +Y, and blue is +Z. A white line is drawn along -Z to indicate the Forward vector of the pose (-Z is forward in StereoKit).
---
# [Lines]({{site.url}}/Pages/StereoKit/Lines.html).AddAxis

<div class='signature' markdown='1'>
```csharp
static void AddAxis(Pose atPose, float size, float thickness)
```
Displays an RGB/XYZ axis widget at the pose! Each line
is extended along the positive direction of each axis, so the red
line is +X, green is +Y, and blue is +Z. A white line is drawn
along -Z to indicate the Forward vector of the pose (-Z is
forward in StereoKit).
</div>

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) atPose|What position and orientation do we want             this axis widget at?|
|float size|How long should the widget lines be, in             meters?|
|float thickness|How thick should the lines be, in meters?|

<div class='signature' markdown='1'>
```csharp
static void AddAxis(Pose atPose, float size)
```
Displays an RGB/XYZ axis widget at the pose! Each line
is extended along the positive direction of each axis, so the red
line is +X, green is +Y, and blue is +Z. A white line is drawn
along -Z to indicate the Forward vector of the pose (-Z is
forward in StereoKit).
</div>

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) atPose|What position and orientation do we want             this axis widget at?|
|float size|How long should the widget lines be, in             meters?|





## Examples

Here's a small example of checking to see if a finger joint is inside
a box, and drawing an axis gizmo when it is!
```csharp
// A volume for checking inside of! 10cm on each side, at the origin
Bounds testArea = new Bounds(Vec3.One * 0.1f);

// This is a decent way to show we're working with both hands
for (int h = 0; h < (int)Handed.Max; h++)
{
	// Get the pose for the index fingertip
	Hand hand      = Input.Hand((Handed)h);
	Pose fingertip = hand[FingerId.Index, JointId.Tip].Pose;

	// Skip this hand if it's not tracked
	if (!hand.IsTracked) continue;

	// Draw the fingertip pose axis if it's inside the volume
	if (testArea.Contains(fingertip.position))
		Lines.AddAxis(fingertip);
}
```

