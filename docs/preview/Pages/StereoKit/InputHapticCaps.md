---
layout: default
title: InputHapticCaps
description: Bit flags describing what playback modes a haptic output currently supports. Queryable via Input.HapticCaps. The set of supported modes may change at runtime whenever the active OpenXR interaction profile changes, which typically happens as the user picks up, sets down, or swaps a controller.
---
# enum InputHapticCaps

Bit flags describing what playback modes a haptic output currently
supports. Queryable via Input.HapticCaps. The set of supported modes
may change at runtime whenever the active OpenXR interaction profile
changes, which typically happens as the user picks up, sets down, or
swaps a controller.

## Enum Values

|  |  |
|--|--|
|Curve|Amplitude envelope playback via Input.HapticCurve. Requires the XR_FB_haptic_amplitude_envelope OpenXR extension.|
|None|No haptic output is available right now (e.g. no controller is bound, or the haptic action isn't active).|
|Pulse|Simple frequency / amplitude / duration vibration via Input.HapticPulse. Supported by every controller that has any haptic actuator.|
|Waveform|Sample-by-sample PCM playback via Input.HapticWaveform. Requires the XR_FB_haptic_pcm OpenXR extension.|
