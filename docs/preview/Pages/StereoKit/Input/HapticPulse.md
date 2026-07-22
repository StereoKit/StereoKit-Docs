---
layout: default
title: Input.HapticPulse
description: Plays a single sustained vibration on the given output. This is the simplest haptic mode and works on every controller that has any actuator at all. Cancels any in-flight HapticWaveform stream on this output before playing.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).HapticPulse

<div class='signature' markdown='1'>
```csharp
static void HapticPulse(InputHaptic output, float frequency, float amplitude, float durationSec)
```
Plays a single sustained vibration on the given output.
This is the simplest haptic mode and works on every controller that
has any actuator at all. Cancels any in-flight HapticWaveform stream
on this output before playing.
</div>

|  |  |
|--|--|
|[InputHaptic]({{site.url}}/preview/Pages/StereoKit/InputHaptic.html) output|Which haptic output to vibrate.|
|float frequency|Carrier frequency in Hz. Pass 0 or negative to let the runtime pick a sensible default for the device.|
|float amplitude|Vibration intensity, 0 (off) to 1 (full). Values outside this range are clamped.|
|float durationSec|How long to vibrate, in seconds. Pass 0 or negative for the shortest pulse the device supports.|





## Examples

### Driving haptics from controller velocity
This shows how to map a continuous physical signal (here, the
controller's grip-pose velocity) onto haptic output. There are two
paths: a simple per-frame `HapticPulse` that works on every device,
and a streaming `HapticWaveform` path that's used when
`XR_FB_haptic_pcm` is available.
```csharp
void StepProcedural(InputHaptic output)
{
	Handed   hand    = output == InputHaptic.LController ? Handed.Left : Handed.Right;
	InputPose pose   = output == InputHaptic.LController ? InputPose.LGrip : InputPose.RGrip;
	PoseState state  = Input.PoseState(pose);
	if (!state.IsTracked()) { haveLastPos = false; return; }

	Vec3 pos = Input.Pose(pose).position;
	if (!haveLastPos) { lastGripPos = pos; haveLastPos = true; return; }

	float speed   = (pos - lastGripPos).Length / Math.Max(0.001f, Time.Stepf);
	lastGripPos   = pos;
	float intensity = MathF.Min(1, speed / 2.0f); // ~2 m/s saturates

	InputHapticCaps caps = Input.HapticCaps(output);
	if ((caps & InputHapticCaps.Waveform) != 0)
	{
		// Streaming path: synthesize one frame's worth of samples at the
		// device's preferred rate, append onto the existing stream.
		float r     = Input.HapticPreferredRate(output);
		if (r <= 0) r = 4000;
		int   count = (int)(r * Time.Stepf);
		if (procBuffer.Length != count) procBuffer = new float[count];
		for (int i = 0; i < count; i++)
			procBuffer[i] = MathF.Sin(2 * MathF.PI * 220 * i / r) * intensity;
		Input.HapticWaveform(output, procBuffer, r, append: true);
	}
	else if ((caps & InputHapticCaps.Pulse) != 0)
	{
		// Fallback path: per-frame pulse with current intensity.
		Input.HapticPulse(output, 0, intensity, Time.Stepf);
	}
}
```

