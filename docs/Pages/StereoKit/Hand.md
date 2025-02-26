---
layout: default
title: Hand
description: Information about a hand!
---
# class Hand

Information about a hand!

## Instance Fields and Properties

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) [aim]({{site.url}}/Pages/StereoKit/Hand/aim.html)|A pose an orientation representing where the hand is pointing to. This may be provided by the OpenXR runtime, or be a fallback provided by StereoKit. Typically this starts and the index finger's primary knuckle, and points in the same direction as a line drawn from the shoulder to the knuckle.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [aimReady]({{site.url}}/Pages/StereoKit/Hand/aimReady.html)|This is a filter state for when the hand is ready to interact with something at a distance. This often factors into account palm direction, as well as distance from the body, and the current pinch and tracked state.|
|HandJoint[] [fingers]({{site.url}}/Pages/StereoKit/Hand/fingers.html)|This is a 2D array with 25 HandJoints. You can get the right joint by `finger*5 + joint`, but really, just use Hand.Get or Hand[] instead. See Hand.Get for more info!|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [grip]({{site.url}}/Pages/StereoKit/Hand/grip.html)|Is the hand making a grip gesture right now? Fingers next to the palm.|
|float [gripActivation]({{site.url}}/Pages/StereoKit/Hand/gripActivation.html)|What percentage of activation is the grip gesture right now? Where 0 is a hand in an outstretched resting position, and 1 is ring finger touching the base of the palm, within a device error tolerant threshold.|
|[Handed]({{site.url}}/Pages/StereoKit/Handed.html) [handed]({{site.url}}/Pages/StereoKit/Hand/handed.html)|Is this a right hand, or a left hand?|
|bool [IsGripped]({{site.url}}/Pages/StereoKit/Hand/IsGripped.html)|Are the fingers currently gripped?|
|bool [IsJustGripped]({{site.url}}/Pages/StereoKit/Hand/IsJustGripped.html)|Have the fingers just been gripped this frame?|
|bool [IsJustPinched]({{site.url}}/Pages/StereoKit/Hand/IsJustPinched.html)|Have the fingers just been pinched this frame?|
|bool [IsJustTracked]({{site.url}}/Pages/StereoKit/Hand/IsJustTracked.html)|Has the hand just started being tracked this frame?|
|bool [IsJustUngripped]({{site.url}}/Pages/StereoKit/Hand/IsJustUngripped.html)|Have the fingers just stopped being gripped this frame?|
|bool [IsJustUnpinched]({{site.url}}/Pages/StereoKit/Hand/IsJustUnpinched.html)|Have the fingers just stopped being pinched this frame?|
|bool [IsJustUntracked]({{site.url}}/Pages/StereoKit/Hand/IsJustUntracked.html)|Has the hand just stopped being tracked this frame?|
|bool [IsPinched]({{site.url}}/Pages/StereoKit/Hand/IsPinched.html)|Are the fingers currently pinched?|
|bool [IsTracked]({{site.url}}/Pages/StereoKit/Hand/IsTracked.html)|Is the hand being tracked by the sensors right now?|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [Material]({{site.url}}/Pages/StereoKit/Hand/Material.html)|Set the Material used to render the hand! The default material uses an offset of 10 to ensure it gets drawn overtop of other elements.|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) [palm]({{site.url}}/Pages/StereoKit/Hand/palm.html)|The position and orientation of the palm! Position is specifically defined as the middle of the middle finger's root (metacarpal) bone. For orientation, Forward is the direction the flat of the palm is facing, "Iron Man" style. X+ is to the outside of the right hand, and to the inside of the left hand.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [pinch]({{site.url}}/Pages/StereoKit/Hand/pinch.html)|Is the hand making a pinch gesture right now? Finger and thumb together.|
|float [pinchActivation]({{site.url}}/Pages/StereoKit/Hand/pinchActivation.html)|What percentage of activation is the pinch gesture right now? Where 0 is a hand in an outstretched resting position, and 1 is fingers touching, within a device error tolerant threshold.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [pinchPt]({{site.url}}/Pages/StereoKit/Hand/pinchPt.html)|This is an approximation of where the center of a 'pinch' gesture occurs, and is used internally by StereoKit for some tasks, such as UI. For simulated hands, this position will give you the most stable pinch location possible. For real hands, it'll be pretty close to the stablest point you'll get. This is especially important for when the user begins and ends their pinch action, as you'll often see a lot of extra movement in the fingers then.|
|float [size]({{site.url}}/Pages/StereoKit/Hand/size.html)|This is the size of the hand, calculated by measuring the length of the middle finger! This is calculated by adding the distances between each joint, then adding the joint radius of the root and tip. This value is recalculated at relatively frequent intervals, and can vary by as much as a centimeter.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [tracked]({{site.url}}/Pages/StereoKit/Hand/tracked.html)|Is the hand being tracked by the sensors right now?|
|bool [Visible]({{site.url}}/Pages/StereoKit/Hand/Visible.html)|Sets whether or not StereoKit should render this hand for you. Turn this to false if you're going to render your own, or don't need the hand itself to be visible.|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) [wrist]({{site.url}}/Pages/StereoKit/Hand/wrist.html)|Pose of the wrist. This is located at the base of your hand, and has a rigid orientation that points forward towards your fingers. Its orientation is unrelated to the forearm. This pose can be useful for making a hand relative coordinate space!|

## Instance Methods

|  |  |
|--|--|
|[Get]({{site.url}}/Pages/StereoKit/Hand/Get.html)|Returns the joint information of the indicated hand joint! This also includes fingertips as a 'joint'. This is the same as the [] operator. Note that for thumbs, there are only 4 'joints' in reality, so StereoKit has JointId.Root and JointId.KnuckleMajor as the same pose, so JointId.Tip is still the tip of the thumb!|

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

