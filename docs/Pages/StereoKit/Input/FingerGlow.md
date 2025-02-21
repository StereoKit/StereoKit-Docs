---
layout: default
title: Input.FingerGlow
description: This controls the visibility of StereoKit's finger glow effect on the UI. When true, SK will fill out global shader variable sk_fingertip[2] with the location of the pointer finger's tips. When false, or the hand is untracked, the location will be set to an unlikely faraway position.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).FingerGlow

<div class='signature' markdown='1'>
static bool FingerGlow{ get set }
</div>

## Description
This controls the visibility of StereoKit's finger glow
effect on the UI. When true, SK will fill out global shader
variable `sk_fingertip[2]` with the location of the pointer
finger's tips. When false, or the hand is untracked, the location
will be set to an unlikely faraway position.


## Examples

### Disabling Finger Glow
When using StereoKit's built-in UI shaders, or the shader API's
`sk_finger_glow`, StereoKit provides a glowing aura around the
pointer finger.

![Finger Glow on a Window panel]({{site.screen_url}}/Docs/Input_FingerGlow.jpg)

This feature is on by default, but can be disabled without
modifying shaders! As long as `Input.FingerGlow` is `false` at
_the end of the frame_, StereoKit will skip providing the shaders
with valid finger pose data for the glow effect.
```csharp
Input.FingerGlow = false;
```

