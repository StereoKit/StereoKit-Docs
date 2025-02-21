---
layout: default
title: EaseVec3
description: A value that can ease from one state to another over time on its own. Useful for quick, juicy animations and effects!
---
# class EaseVec3

A value that can ease from one state to another over time on its
own. Useful for quick, juicy animations and effects!

## Instance Fields and Properties

|  |  |
|--|--|
|bool [IsFinished]({{site.url}}/Pages/StereoKit.Framework/EaseVec3/IsFinished.html)|Is this easing value currently easing from one state to the next, or is it finished and static?|

## Instance Methods

|  |  |
|--|--|
|[EaseVec3]({{site.url}}/Pages/StereoKit.Framework/EaseVec3/EaseVec3.html)|Create a new ease value that starts with an initial value. This object will not animate until AnimTo is called.|
|[AnimTo]({{site.url}}/Pages/StereoKit.Framework/EaseVec3/AnimTo.html)|This sets up an easing animation for this value. It will now ease from its current state, to its destination state over a duration of time.|
|[Resolve]({{site.url}}/Pages/StereoKit.Framework/EaseVec3/Resolve.html)|This will resolve the easing animation to its current value based on the current StereoKit time, and the state of the easing animation. This value is not cached internally.|
|[SetTo]({{site.url}}/Pages/StereoKit.Framework/EaseVec3/SetTo.html)|Sets this to a specific value with no easing animation. This will cancel any in-progress animations, and jump straight to the provided value.|

## Operators

|  |  |
|--|--|
|[Implicit Conversions]({{site.url}}/Pages/StereoKit.Framework/EaseVec3/op_Implicit.html)|An implicit "Resolve" of this easing type to its value.|

## Examples

### Easing a Cube
Here we're just animating a cube around, using some custom easing
functions as well as builtin ones! The color here is animated using a
conventional animation, just flipping through various hues, but the pose
and scale are using easing to go to a position _and_ come back!

![Easing Cube]({{site.screen_url}}/EasingCube.jpg)
```csharp
// Initial starting values for the pose, size, and color of a cube that
// we'll animate!
EasePose  pose  = new EasePose (V.XYZ(0,-0.1f,-0.5f), Quat.Identity);
EaseVec3  scale = new EaseVec3 (0.1f,0.1f,0.1f);
EaseColor color = new EaseColor(Color.White);

// Here's a custom easing function! This one goes from 0 to 1 and then back
// to 0 again! So it actually ends in the exact same place it started. We
// could achieve the same behavior with just sin(pi*t), but the rest of the
// math here softens the start and end of the animation.
// See a graph here: https://www.desmos.com/calculator/zz8cdvrvju
static float EaseReturn(float t) => (float)Math.Sin(2*Math.PI*t - 0.5*Math.PI) * 0.5f + 0.5f;

void StepEasedCube()
{
	// If the Ease animation for the Pose is finished or never started to
	// begin with, we can make it hop with our custom `EaseReturn`
	// function!
	if (pose.IsFinished)
		pose.AnimTo(
			new Pose(V.XYZ(0, 0.1f, -0.5f), Quat.FromAngles(0, 180, 0)),
			0.5f,
			EaseReturn);

	if (scale.IsFinished)
		scale.AnimTo(
			V.XYZ(0.15f, 0.15f, 0.15f),
			0.75f,
			EaseReturn);

	// For the color, we're picking a semi-random hue, and using one of the
	// built-in easing functions to just ease all the way to our
	// destination color!
	if (color.IsFinished)
		color.AnimTo(
			Color.HSV((Time.Frame % 100) / 100.0f, 0.7f, 0.7f),
			1,
			Ease.FastIn);

	// Convert `pose` and `scale` into a transform Matrix! Ease values have
	// implicit conversions that will automatically `Resolve` the current
	// value, so most of the time you can just pass them the same way you
	// would a normal type. In this case to call `ToMatrix` we need to
	// either explicitly cast, or call `Resolve`, and `Resolve` is the most
	// obvious action.
	Matrix transform = pose.Resolve().ToMatrix(scale);
	Mesh.Cube.Draw(Material.Default, transform, color);
}
```

