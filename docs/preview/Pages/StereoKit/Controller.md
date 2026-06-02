---
layout: default
title: Controller
description: This represents a physical controller input device! Tracking information, buttons, analog sticks and triggers! There's also a Menu button that's tracked separately at Input.ContollerMenu.
---
# class Controller

This represents a physical controller input device! Tracking
information, buttons, analog sticks and triggers! There's also a Menu
button that's tracked separately at Input.ContollerMenu.

## Instance Fields and Properties

|  |  |
|--|--|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) [aim]({{site.url}}/preview/Pages/StereoKit/Controller/aim.html)|The aim pose of a controller is where the controller 'points' from and to. This is great for pointer rays and far interactions.|
|float [grip]({{site.url}}/preview/Pages/StereoKit/Controller/grip.html)|The grip button typically sits under the user's middle finger. These buttons occasionally have a wide range of activation, so this is provided as a value from 0.0 -> 1.0, where 0 is no interaction, and 1 is full interaction. If a controller has binary activation, this will jump straight from 0 to 1.|
|bool [IsJustTracked]({{site.url}}/preview/Pages/StereoKit/Controller/IsJustTracked.html)|Has the controller just started being tracked this frame?|
|bool [IsJustUntracked]({{site.url}}/preview/Pages/StereoKit/Controller/IsJustUntracked.html)|Has the controller just stopped being tracked this frame?|
|bool [IsStickClicked]({{site.url}}/preview/Pages/StereoKit/Controller/IsStickClicked.html)|Is the analog stick/directional controller button currently being actively pressed?|
|bool [IsStickJustClicked]({{site.url}}/preview/Pages/StereoKit/Controller/IsStickJustClicked.html)|Has the analog stick/directional controller button just been pressed this frame?|
|bool [IsStickJustUnclicked]({{site.url}}/preview/Pages/StereoKit/Controller/IsStickJustUnclicked.html)|Has the analog stick/directional controller button just been released this frame?|
|bool [IsTracked]({{site.url}}/preview/Pages/StereoKit/Controller/IsTracked.html)|Is the controller being tracked by the sensors right now?|
|bool [IsX1JustPressed]({{site.url}}/preview/Pages/StereoKit/Controller/IsX1JustPressed.html)|Has the controller's X1 button just been pressed this frame? Depending on the specific hardware, this is the first general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'X' on the left controller, and 'A' on the right controller.|
|bool [IsX1JustUnPressed]({{site.url}}/preview/Pages/StereoKit/Controller/IsX1JustUnPressed.html)|Has the controller's X1 button just been released this frame? Depending on the specific hardware, this is the first general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'X' on the left controller, and 'A' on the right controller.|
|bool [IsX1Pressed]({{site.url}}/preview/Pages/StereoKit/Controller/IsX1Pressed.html)|Is the controller's X1 button currently pressed? Depending on the specific hardware, this is the first general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'X' on the left controller, and 'A' on the right controller.|
|bool [IsX2JustPressed]({{site.url}}/preview/Pages/StereoKit/Controller/IsX2JustPressed.html)|Has the controller's X2 button just been pressed this frame? Depending on the specific hardware, this is the second general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'Y' on the left controller, and 'B' on the right controller.|
|bool [IsX2JustUnPressed]({{site.url}}/preview/Pages/StereoKit/Controller/IsX2JustUnPressed.html)|Has the controller's X2 button just been released this frame? Depending on the specific hardware, this is the second general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'Y' on the left controller, and 'B' on the right controller.|
|bool [IsX2Pressed]({{site.url}}/preview/Pages/StereoKit/Controller/IsX2Pressed.html)|Is the controller's X2 button currently pressed? Depending on the specific hardware, this is the second general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'Y' on the left controller, and 'B' on the right controller.|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) [palm]({{site.url}}/preview/Pages/StereoKit/Controller/palm.html)|This is the pose of the hand's palm on the controller. You can use it for rendering items where the hands are when holding a controller. This pose's Forward is towards the fingers, and Up is toward the thumbs. On the right hand, X+ goes into the palm, and on the left hand, X+ goes out of the palm. This is used by StereoKit for placing the hand mesh!|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) [pose]({{site.url}}/preview/Pages/StereoKit/Controller/pose.html)|The grip pose of the controller. This approximately represents the center of the controller where it's gripped by the user's hand. Check `trackedPos` and `trackedRot` for the current state of the pose data.|
|[Vec2]({{site.url}}/preview/Pages/StereoKit/Vec2.html) [stick]({{site.url}}/preview/Pages/StereoKit/Controller/stick.html)|This is the current 2-axis position of the analog stick or equivalent directional controller. This generally ranges from -1 to +1 on each axis. This is a raw input, so dead-zones and similar issues are not accounted for here, unless modified by the OpenXR platform itself.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [stickClick]({{site.url}}/preview/Pages/StereoKit/Controller/stickClick.html)|This represents the click state of the controller's analog stick or directional controller.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [tracked]({{site.url}}/preview/Pages/StereoKit/Controller/tracked.html)|This tells the current tracking state of this controller overall. If either position or rotation are trackable, then this will report tracked. Typically, positional tracking will be lost first, when the controller goes out of view, and rotational tracking will often remain as long as the controller is still connected. This is a good way to check if the controller is connected to the system at all.|
|[TrackState]({{site.url}}/preview/Pages/StereoKit/TrackState.html) [trackedPos]({{site.url}}/preview/Pages/StereoKit/Controller/trackedPos.html)|This tells the current tracking state of the controller's position information. This is often the first part of tracking data to go, so it can often be good to account for this on occasions.|
|[TrackState]({{site.url}}/preview/Pages/StereoKit/TrackState.html) [trackedRot]({{site.url}}/preview/Pages/StereoKit/Controller/trackedRot.html)|This tells the current tracking state of the controller's rotational information.|
|float [trigger]({{site.url}}/preview/Pages/StereoKit/Controller/trigger.html)|The trigger button at the user's index finger. These buttons typically have a wide range of activation, so this is provided as a value from 0.0 -> 1.0, where 0 is no interaction, and 1 is full interaction. If a controller has binary activation, this will jump straight from 0 to 1.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [x1]({{site.url}}/preview/Pages/StereoKit/Controller/x1.html)|The current state of the controller's X1 button. Depending on the specific hardware, this is the first general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'X' on the left controller, and 'A' on the right controller.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [x2]({{site.url}}/preview/Pages/StereoKit/Controller/x2.html)|The current state of the controller's X2 button. Depending on the specific hardware, this is the second general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'Y' on the left controller, and 'B' on the right controller.|

## Examples

### Controller Debug Visualizer
This function shows a debug visualization of the current state of
the controller! It's not something you'd show to users, but it's
nice for just seeing how the API works, or as a temporary
visualization.
```csharp
void ShowController(Handed hand)
{
	bool      isLeft = hand == Handed.Left;
	PoseState state  = Input.PoseState(isLeft ? InputPose.LGrip : InputPose.RGrip);
	if (!state.IsTracked()) return;

	Hierarchy.Push(Input.Pose(isLeft?InputPose.LGrip:InputPose.RGrip));
		// Pick the controller color based on trackin info state
		Color color = Color.Black;
		if ((state & PoseState.PosInferred) > 0) color.g = 0.5f;
		if ((state & PoseState.PosKnown   ) > 0) color.g = 1;
		if ((state & PoseState.RotInferred) > 0) color.b = 0.5f;
		if ((state & PoseState.RotKnown   ) > 0) color.b = 1;
		Default.MeshCube.Draw(Default.Material, Matrix.S(new Vec3(3, 3, 8) * U.cm), color);

		// Show button info on the back of the controller
		Hierarchy.Push(Matrix.TR(0,1.6f*U.cm,0, Quat.LookAt(Vec3.Zero, new Vec3(0,1,0), new Vec3(0,0,-1))));

			// Show the tracking states as text
			Text.Add(state.IsPosKnown()?"(pos)":(state.IsPosInferred()?"~pos~":"pos"), Matrix.TS(0,-0.03f,0, 0.25f));
			Text.Add(state.IsRotKnown()?"(rot)":(state.IsRotInferred()?"~rot~":"rot"), Matrix.TS(0,-0.02f,0, 0.25f));

			// Show the controller's buttons
			Text.Add(Input.Button(isLeft?InputButton.LMenu:InputButton.RMenu).IsActive()?"(menu)":"menu", Matrix.TS(0,-0.01f,0, 0.25f));
			Text.Add(Input.Button(isLeft?InputButton.LX1  :InputButton.RX1  ).IsActive()?"(X1)":"X1", Matrix.TS(0,0.00f,0, 0.25f));
			Text.Add(Input.Button(isLeft?InputButton.LX2  :InputButton.RX2  ).IsActive()?"(X2)":"X2", Matrix.TS(0,0.01f,0, 0.25f));

			// Show the analog stick's information
			Vec3 stickAt = new Vec3(0, 0.03f, 0);
			Lines.Add(stickAt, stickAt + Input.XY(isLeft?InputXY.LStick:InputXY.RStick).XY0*0.01f, Color.White, 0.001f);
			if (Input.Button(isLeft?InputButton.LStick:InputButton.RStick).IsActive()) Text.Add("O", Matrix.TS(stickAt, 0.25f));

			// And show the trigger and grip buttons
			float trigger = Input.Float(isLeft?InputFloat.LTrigger:InputFloat.RTrigger);
			float grip    = Input.Float(isLeft?InputFloat.LGrip   :InputFloat.RGrip   );
			Default.MeshCube.Draw(Default.Material, Matrix.TS(0, -0.015f, -0.005f, new Vec3(0.01f, 0.04f, 0.01f)) * Matrix.TR(new Vec3(0,0.02f,0.03f), Quat.FromAngles(-45+trigger*40, 0,0) ));
			Default.MeshCube.Draw(Default.Material, Matrix.TS(0.0149f*(hand == Handed.Right?1:-1), 0, 0.015f, new Vec3(0.01f*(1-grip), 0.04f, 0.01f)));

		Hierarchy.Pop();
	Hierarchy.Pop();

	// And show the pointer
	Default.MeshCube.Draw(Default.Material, Input.Pose(isLeft?InputPose.LAim:InputPose.RAim).ToMatrix(new Vec3(1,1,4) * U.cm), Color.HSV(0,0.5f,0.8f).ToLinear());
}
```

