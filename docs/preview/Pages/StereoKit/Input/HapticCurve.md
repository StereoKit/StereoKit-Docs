---
layout: default
title: Input.HapticCurve
description: Plays an amplitude envelope on the given output. Each element is an unsigned amplitude in [0, 1] sampled at sampleRateHz; the runtime picks the carrier frequency and modulates intensity over time. Requires the InputHapticCaps.Curve capability bit; the call is a silent no-op on devices that lack the XR_FB_haptic_amplitude_envelope OpenXR extension.  Use HapticCurve for shaping the *intensity* of a vibration (fade, pulse, decay tail) when the texture of the underlying buzz isn't important. Use HapticWaveform when you need to author the underlying carrier yourself.  Each call replaces any in-flight playback (the underlying OpenXR extension has no append concept for envelopes), and amplitudes over 4000 samples are truncated to fit the extension's documented limit. For longer or streamed effects, use HapticWaveform.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).HapticCurve

<div class='signature' markdown='1'>
```csharp
static void HapticCurve(InputHaptic output, Single[] amplitudes, float sampleRateHz)
```
Plays an amplitude envelope on the given output. Each
element is an unsigned amplitude in [0, 1] sampled at
sampleRateHz; the runtime picks the carrier frequency and
modulates intensity over time. Requires the InputHapticCaps.Curve
capability bit; the call is a silent no-op on devices that lack
the XR_FB_haptic_amplitude_envelope OpenXR extension.

Use HapticCurve for shaping the *intensity* of a vibration (fade,
pulse, decay tail) when the texture of the underlying buzz isn't
important. Use HapticWaveform when you need to author the
underlying carrier yourself.

Each call replaces any in-flight playback (the underlying OpenXR
extension has no append concept for envelopes), and amplitudes
over 4000 samples are truncated to fit the extension's documented
limit. For longer or streamed effects, use HapticWaveform.
</div>

|  |  |
|--|--|
|[InputHaptic]({{site.url}}/preview/Pages/StereoKit/InputHaptic.html) output|Which haptic output to vibrate.|
|Single[] amplitudes|Unsigned [0, 1] intensity samples.|
|float sampleRateHz|The sample rate the envelope was              authored at.|




