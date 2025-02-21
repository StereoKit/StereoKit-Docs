---
layout: default
title: Bounds
description: Bounds is an axis aligned bounding box type that can be used for storing the sizes of objects, calculating containment, intersections, and more!  While the constructor uses a center+dimensions for creating a bounds, don't forget the static From* methods that allow you to define a Bounds from different types of data!
---
# struct Bounds

Bounds is an axis aligned bounding box type that can be used
for storing the sizes of objects, calculating containment,
intersections, and more!

While the constructor uses a center+dimensions for creating a bounds,
don't forget the static From* methods that allow you to define a Bounds
from different types of data!

## Instance Fields and Properties

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [center]({{site.url}}/Pages/StereoKit/Bounds/center.html)|The exact center of the Bounds!|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [dimensions]({{site.url}}/Pages/StereoKit/Bounds/dimensions.html)|The total size of the box, from one end to the other. This is the width, height, and depth of the Bounds.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [TLB]({{site.url}}/Pages/StereoKit/Bounds/TLB.html)|From the front, this is the Top (Y+), Left (X+), Back (Z+) of the bounds. Useful when working with UI layout bounds.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [TLC]({{site.url}}/Pages/StereoKit/Bounds/TLC.html)|From the front, this is the Top (Y+), Left (X+), Center (Z0) of the bounds. Useful when working with UI layout bounds.|

## Instance Methods

|  |  |
|--|--|
|[Bounds]({{site.url}}/Pages/StereoKit/Bounds/Bounds.html)|Creates a bounding box object!|
|[Contains]({{site.url}}/Pages/StereoKit/Bounds/Contains.html)|Does the Bounds contain the given point? This includes points that are on the surface of the Bounds.|
|[Grown]({{site.url}}/Pages/StereoKit/Bounds/Grown.html)|Grow the Bounds to encapsulate the provided point. Returns the result, and does NOT modify the current bounds.|
|[Intersect]({{site.url}}/Pages/StereoKit/Bounds/Intersect.html)|Calculate the intersection between a Ray, and these bounds. Returns false if no intersection occurred, and 'at' will contain the nearest intersection point to the start of the ray if an intersection is found!|
|[Scale]({{site.url}}/Pages/StereoKit/Bounds/Scale.html)|Scale this bounds. It will scale the center as well as	the dimensions! Modifies this bounds object.|
|[Scaled]({{site.url}}/Pages/StereoKit/Bounds/Scaled.html)|Scale the bounds. It will scale the center as well as	the dimensions! Returns a new Bounds.|
|[ToString]({{site.url}}/Pages/StereoKit/Bounds/ToString.html)|Creates a text description of the Bounds, in the format of "[center:X dimensions:X]"|
|[Transformed]({{site.url}}/Pages/StereoKit/Bounds/Transformed.html)|This returns a Bounds that encapsulates the transformed points of the current Bounds's corners. Note that this will likely introduce a lot of extra empty volume in many cases, as the result is still always axis aligned.|

## Static Methods

|  |  |
|--|--|
|[FromCorner]({{site.url}}/Pages/StereoKit/Bounds/FromCorner.html)|Create a bounding box from a corner, plus box dimensions.|
|[FromCorners]({{site.url}}/Pages/StereoKit/Bounds/FromCorners.html)|Create a bounding box between two corner points.|

## Operators

|  |  |
|--|--|
|[*]({{site.url}}/Pages/StereoKit/Bounds/op_Multiply.html)|This operator will create a new Bounds that has been properly scaled up by the float. This does affect the center position of the Bounds.|

## Examples

### General Usage

```csharp
// All these create bounds for a 1x1x1m cube around the origin!
Bounds bounds = new Bounds(Vec3.One);
bounds = Bounds.FromCorner(new Vec3(-0.5f, -0.5f, -0.5f), Vec3.One);
bounds = Bounds.FromCorners(
	new Vec3(-0.5f, -0.5f, -0.5f),
	new Vec3( 0.5f,  0.5f,  0.5f));

// Note that positions must be in a coordinate space relative to 
// the bounds!
if (bounds.Contains(new Vec3(0,0.25f,0)))
	Log.Info("Super easy to check if something's in it!");

// Casting a ray at a bounds is trivial too, again, ensure 
// coordinates are in the same space!
Ray ray = new Ray(Vec3.Up, -Vec3.Up);
if (bounds.Intersect(ray, out Vec3 at))
	Log.Info($"Bounds intersection at {at}"); // <0, 0.5f, 0>

// You can also scale a Bounds using the '*' operator overload, 
// this is really useful if you're working with the Bounds of a
// Model that you've scaled. It will scale the center as well as
// the size!
bounds = bounds * 0.5f;

// Scale the current bounds reference using 'Scale'
bounds.Scale(0.5f);

// Scale the bounds by a Vec3
bounds = bounds * new Vec3(1, 10, 0.5f);
```

### An Interactive Model

![A grabbable GLTF Model using UI.Handle]({{site.screen_url}}/HandleBox.jpg)

If you want to grab a Model and move it around, then you can use a
`UI.Handle` to do it! Here's an example of loading a GLTF from file,
and using its information to create a Handle and a UI 'cage' box that
indicates an interactive element.

```csharp
Model model      = Model.FromFile("DamagedHelmet.gltf");
Pose  handlePose = new Pose(0,0,0, Quat.Identity);
float scale      = .15f;

public void StepHandle() {
	UI.HandleBegin("Model Handle", ref handlePose, model.Bounds*scale);

	model.Draw(Matrix.S(scale));
	Mesh.Cube.Draw(Material.UIBox, Matrix.TS(model.Bounds.center*scale, model.Bounds.dimensions*scale));

	UI.HandleEnd();
}
```

