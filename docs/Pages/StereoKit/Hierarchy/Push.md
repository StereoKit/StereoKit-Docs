---
layout: default
title: Hierarchy.Push
description: Pushes a transform Matrix onto the stack, and combines it with the Matrix below it. Any draw operation's Matrix will now be combined with this Matrix to make it relative to the current hierarchy. Use Hierarchy.Pop to remove it from the Hierarchy stack! All Push calls must have an accompanying Pop call.
---
# [Hierarchy]({{site.url}}/Pages/StereoKit/Hierarchy.html).Push

<div class='signature' markdown='1'>
```csharp
static void Push(Matrix& parentTransform, HierarchyParent parentBehavior)
```
Pushes a transform Matrix onto the stack, and combines
it with the Matrix below it. Any draw operation's Matrix will now
be combined with this Matrix to make it relative to the current
hierarchy. Use Hierarchy.Pop to remove it from the Hierarchy
stack! All Push calls must have an accompanying Pop call.
</div>

|  |  |
|--|--|
|Matrix& parentTransform|The transform Matrix you want to              apply to all following draw calls.|
|[HierarchyParent]({{site.url}}/Pages/StereoKit/HierarchyParent.html) parentBehavior|This determines how this matrix             combines with the parent matrix below it. Normal behavior is to             "inherit" the parent matrix, but there are cases where you may wish             to entirely ignore the parent transform. For example, if you're in             UI space, and wish to do some world space rendering.|





## Examples

### Transforming with Hierarchy

In StereoKit, draw calls all happen relative to the `Hierarchy`
stack! In this example, we make 2 draw calls with the same
transform matrix, but use the `Hierarchy` as a transform parent to
ensure the draws happen in different locations.

![Two spheres, one red and one blue, both at different locations]({{site.screen_url}}/Docs/Hierarchy_Transform.jpg)

`Push`/`Pop` calls can also be nested to create more complex
hierarchies on a stack! Each `Push` call is also relative to the
parent `Push`ed transform.

```csharp
Matrix transform = Matrix.S(0.2f);

Hierarchy.Push(Matrix.T(-0.2f, 0, -0.5f));
Mesh.Sphere.Draw(Material.Default, transform, Color.HSV(0.0f, .8f, .8f));
Hierarchy.Pop();

Hierarchy.Push(Matrix.T( 0.2f, 0, -0.5f));
Mesh.Sphere.Draw(Material.Default, transform, Color.HSV(0.5f, .8f, .8f));
Hierarchy.Pop();
```
> One key thing to remember is that you should _always_ match a `Pop` for each `Push`.
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

