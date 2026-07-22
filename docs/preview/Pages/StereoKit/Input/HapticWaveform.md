---
layout: default
title: Input.HapticWaveform
description: Plays a PCM waveform on the given output. Samples are signed values in [-1, 1] sampled at sampleRateHz, like an audio buffer. Requires the InputHapticCaps.Waveform capability bit; the call is a silent no-op on devices that lack XR_FB_haptic_pcm.  Buffers longer than the runtime's per-call limit are streamed transparently — pass any length and StereoKit will drip-feed chunks to the device over multiple frames. For procedural use, reuse the same float[] buffer across calls to avoid per-frame allocations. To explicitly cut a stream mid-playback, pass append=false here, or call HapticStop / HapticPulse.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).HapticWaveform

<div class='signature' markdown='1'>
```csharp
static void HapticWaveform(InputHaptic output, Single[] samples, float sampleRateHz, bool append)
```
Plays a PCM waveform on the given output. Samples are
signed values in [-1, 1] sampled at sampleRateHz, like an audio
buffer. Requires the InputHapticCaps.Waveform capability bit; the
call is a silent no-op on devices that lack XR_FB_haptic_pcm.

Buffers longer than the runtime's per-call limit are streamed
transparently — pass any length and StereoKit will drip-feed chunks
to the device over multiple frames. For procedural use, reuse the
same float[] buffer across calls to avoid per-frame allocations.
To explicitly cut a stream mid-playback, pass append=false here, or
call HapticStop / HapticPulse.
</div>

|  |  |
|--|--|
|[InputHaptic]({{site.url}}/preview/Pages/StereoKit/InputHaptic.html) output|Which haptic output to vibrate.|
|Single[] samples|Signed [-1, 1] PCM samples.|
|float sampleRateHz|The sample rate the buffer was authored at. See HapticPreferredRate for the device's native rate. If this differs from the in-flight stream's rate, append behavior degrades to a restart.|
|bool append|When true, queues these samples after any playback already in flight on this output. When false (default), cancels any current playback and starts the new buffer immediately.|

<div class='signature' markdown='1'>
```csharp
static void HapticWaveform(InputHaptic output, Single[] samples, float sampleRateHz, bool append, Int32& prevSamplesConsumed)
```
Plays a PCM waveform and reports how many samples the
runtime had drained from the previously-submitted chunk by the time
this call was processed. Streaming callers use the consumed count
to throttle their per-frame submission rate and bound playback
latency.
</div>

|  |  |
|--|--|
|[InputHaptic]({{site.url}}/preview/Pages/StereoKit/InputHaptic.html) output|Which haptic output to vibrate.|
|Single[] samples|Signed [-1, 1] PCM samples.|
|float sampleRateHz|The sample rate the buffer was authored at.|
|bool append|When true, queues after any in-flight playback; when false, replaces it.|
|Int32& prevSamplesConsumed|Receives the runtime's samplesConsumed count for the most recent chunk StereoKit submitted to the device, or 0 if no chunk was in flight. This is reported at chunk granularity, not at the granularity of HapticWaveform calls — a single HapticWaveform call may span multiple internal chunks.|





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

