---
layout: default
title: Pose
description: Pose represents a location and orientation in space, excluding scale! CAUTION. the default value of a Pose includes a completely zero Quat, which can cause problems. Use Pose.Identity instead of new Pose() for creating a default pose.
---
# struct Pose

Pose represents a location and orientation in space,
excluding scale! CAUTION: the default value of a Pose includes a
completely zero Quat, which can cause problems. Use `Pose.Identity`
instead of `new Pose()` for creating a default pose.

## Instance Fields and Properties

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [Forward]({{site.url}}/Pages/StereoKit/Pose/Forward.html)|Calculates the forward direction from this pose. This is done by multiplying the orientation with Vec3.Forward. Remember that Forward points down the -Z axis!|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) [orientation]({{site.url}}/Pages/StereoKit/Pose/orientation.html)|Orientation of the pose, stored as a rotation from Vec3.Forward.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [position]({{site.url}}/Pages/StereoKit/Pose/position.html)|Location of the pose.|
|[Ray]({{site.url}}/Pages/StereoKit/Ray.html) [Ray]({{site.url}}/Pages/StereoKit/Pose/Ray.html)|This creates a ray starting at the Pose's position, and pointing in the 'Forward' direction. The Ray direction is a unit vector/normalized.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [Right]({{site.url}}/Pages/StereoKit/Pose/Right.html)|Calculates the right (+X) direction from this pose. This is done by multiplying the orientation with Vec3.Right.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [Up]({{site.url}}/Pages/StereoKit/Pose/Up.html)|Calculates the up (+Y) direction from this pose. This is done by multiplying the orientation with Vec3.Up.|

## Instance Methods

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose/Pose.html)|Basic initialization constructor! Just copies in the provided values directly.|
|[ToMatrix]({{site.url}}/Pages/StereoKit/Pose/ToMatrix.html)|Converts this pose into a transform matrix, incorporating a provided scale value.|
|[ToString]({{site.url}}/Pages/StereoKit/Pose/ToString.html)|A string representation of the Pose, in the format of "position, Forward". Mostly for debug visualization.|

## Static Fields and Properties

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) [Identity]({{site.url}}/Pages/StereoKit/Pose/Identity.html)|A default, empty pose. Positioned at zero, and using Quat.Identity for orientation.|

## Static Methods

|  |  |
|--|--|
|[Lerp]({{site.url}}/Pages/StereoKit/Pose/Lerp.html)|Interpolates between two poses! It is unclamped, so values outside of (0,1) will extrapolate their position.|
|[LookAt]({{site.url}}/Pages/StereoKit/Pose/LookAt.html)|Creates a Pose that looks from one location in the direction of another location. This leaves "Up" as the +Y axis.|

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

### Draw Pose

Having a raw and malleable position/orientation available is great,
but with `Pose.ToMatrix`, you can also quickly turn a `Pose` into a
`Matrix` for use with drawing functions or other places where
`Matrix` transforms are needed! `ToMatrix` also has overloads to
include a scale, if one is available.

![Drawing items at a Pose]({{site.screen_url}}/Docs/PoseDraw.jpg)

```csharp
Pose  pose  = new Pose(0,0,-0.5f, Quat.FromAngles(30,45,0));
float scale = 0.5f;

Mesh.Cube.Draw(Material.Default, pose.ToMatrix(scale));
```

### Pose Directions

![Pose direction lines]({{site.screen_url}}/Docs/PoseDirections.jpg)

`Pose` provides a few handy vector properties to help working with
`Pose` relative directions! `Forward`, `Right`, and `Up` are all
derived from the `Pose`'s orientation, and represent the -Z, +X and
+Y directions of the `Pose`.

```csharp
Pose p = new Pose(0,0,-0.5f);
model.Draw(p.ToMatrix(0.03f));

Lines.Add(p.position, p.position + 0.1f*p.Right,   new Color32(255,0,0,255), 0.005f);
Lines.Add(p.position, p.position + 0.1f*p.Up,      new Color32(0,255,0,255), 0.005f);
Lines.Add(p.position, p.position + 0.1f*p.Forward, Color32.White,            0.005f);
```

