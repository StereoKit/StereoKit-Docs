---
layout: default
title: Hierarchy.ToWorld
description: Converts a local point relative to the current hierarchy stack into world space!
---
# [Hierarchy]({{site.url}}/Pages/StereoKit/Hierarchy.html).ToWorld

<div class='signature' markdown='1'>
```csharp
static Vec3 ToWorld(Vec3 localPoint)
```
Converts a local point relative to the current hierarchy
stack into world space!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) localPoint|A point in local space.|
|RETURNS: [Vec3]({{site.url}}/Pages/StereoKit/Vec3.html)|The provided point now in world space!|

<div class='signature' markdown='1'>
```csharp
static Quat ToWorld(Quat localOrientation)
```
Converts a local rotation relative to the current
hierarchy stack into world space!
</div>

|  |  |
|--|--|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) localOrientation|A rotation in local space.|
|RETURNS: [Quat]({{site.url}}/Pages/StereoKit/Quat.html)|The provided rotation now in world space!|

<div class='signature' markdown='1'>
```csharp
static Pose ToWorld(Pose localPose)
```
Converts a local pose relative to the current
hierarchy stack into world space!
</div>

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) localPose|A pose in local space.|
|RETURNS: [Pose]({{site.url}}/Pages/StereoKit/Pose.html)|The provided pose now in world space!|

<div class='signature' markdown='1'>
```csharp
static Ray ToWorld(Ray localRay)
```
Converts a local ray relative to the current
hierarchy stack into world space!
</div>

|  |  |
|--|--|
|[Ray]({{site.url}}/Pages/StereoKit/Ray.html) localRay|A ray in local space.|
|RETURNS: [Ray]({{site.url}}/Pages/StereoKit/Ray.html)|The provided ray now in world space!|





## Examples

### Spaces and Intersections

One tricky thing you need to keep in mind when working with
different spaces like the ones created with `Hierarchy` is that any
values you use for math need to be in the same space! I like to
explicitly label my variables with the space they're in anytime I'm
working with anything even a little complicated!

![An intersecting Ray in a complicated hierarchy]({{site.screen_url}}/Docs/Hierarchy_Spaces.jpg)

Here's an example of intersecting a ray with some content that
exists inside of a `Hierarchy` stack. You always need to transform
your data into `Mesh` or `Model` space in order to do an
`Intersect`, but the `Hierarchy` here adds a bit of extra
complexity to the problem!
```csharp
// It can often be helpful to consider if you're making a function
// "Hierarchy aware", meaning that it will still work properly if the
// code _already_ exists within a transformed hierarchy! Here we're
// using `Hierarchy.ToWorld` to ensure our intersection ray is
// _for sure_ in World Space.
Ray parentSpaceRay = new Ray(V.XYZ(0.5f, 4, -0.5f), V.XYZ(-1, 0, 0));
Ray worldSpaceRay  = Hierarchy.ToWorld(parentSpaceRay);
Lines.Add(parentSpaceRay, 0.5f, Color.White, 0.005f);

// Sometimes it can help with clarity to add scope brackets to show
// how the hierarchy is affecting the code!
Hierarchy.Push(Matrix.T(0, 4, -0.5f));
{
	Matrix localTransform = Matrix.TRS(Vec3.Zero, Quat.FromAngles(20, 135, 45), 0.2f);
	Mesh.Cube.Draw(Material.Default, localTransform);

	// Mesh intersection _must_ be done in Mesh space, since that's
	// the space the Vertex data is in. So we need to convert our
	// intersection ray all the way from world space to mesh space here
	// before calling `Intersect`!
	Ray localSpaceRay = Hierarchy.ToLocal(worldSpaceRay);
	Ray meshSpaceRay  = localTransform.Inverse.Transform(localSpaceRay);
	if (meshSpaceRay.Intersect(Mesh.Cube, out Ray meshSpaceAt))
	{
		// Similarly, the intersection point needs to be transformed
		// from Mesh space back into our local space before drawing it.
		Ray localAt = localTransform.Transform(meshSpaceAt);
		Mesh.Sphere.Draw(Material.Default, Matrix.TS(localAt.position, 0.04f), Color.HSV(0.36f, .8f, .8f));
	}
}
Hierarchy.Pop();
```

