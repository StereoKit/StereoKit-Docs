---
layout: default
title: Quat.Delta
description: Creates a quaternion that goes from one rotation to another.
---
# [Quat]({{site.url}}/Pages/StereoKit/Quat.html).Delta

<div class='signature' markdown='1'>
```csharp
static Quat Delta(Quat from, Quat to)
```
Creates a quaternion that goes from one rotation to
another.
</div>

|  |  |
|--|--|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) from|The origin rotation.|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) to|And the target rotation!|
|RETURNS: [Quat]({{site.url}}/Pages/StereoKit/Quat.html)|The quaternion between from and to.|

<div class='signature' markdown='1'>
```csharp
static Quat Delta(Vec3 from, Vec3 to)
```
Creates a rotation that goes from one direction to
another. Which is comes in handy when trying to roll
something around with position data.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) from|The origin direction.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) to|And the target direction!|
|RETURNS: [Quat]({{site.url}}/Pages/StereoKit/Quat.html)|The quaternion between from and to.|





## Examples

```csharp
Pose spherePose  = new Pose(-1, 0, 1, Quat.Identity);
Quat sphereDelta = Quat.Identity;
Vec3 oldPalmPos;
void SpinningSphere()
{
	// Draw a sphere that you can spin around with your right hand!
	Vec3 palmPos = Input.Hand(Handed.Right).palm.position - spherePose.position;
	if (palmPos.Length < 0.3f)
	{
		sphereDelta = Quat.Delta(oldPalmPos.Normalized, palmPos.Normalized);
	}
	spherePose.orientation = sphereDelta * spherePose.orientation;
	oldPalmPos = palmPos;
	Mesh.Sphere.Draw(matDev, spherePose.ToMatrix(0.5f));
}
```

