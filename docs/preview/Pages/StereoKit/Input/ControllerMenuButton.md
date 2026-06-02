---
layout: default
title: Input.ControllerMenuButton
description: This is the state of the controller's menu button, this is not attached to any particular hand, so it's independent of a left or right controller.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).ControllerMenuButton

<div class='signature' markdown='1'>
static [BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) ControllerMenuButton{ get }
</div>

## Description
This is the state of the controller's menu button, this
is not attached to any particular hand, so it's independent of a
left or right controller.


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

