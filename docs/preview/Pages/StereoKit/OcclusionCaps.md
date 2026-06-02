---
layout: default
title: OcclusionCaps
description: Flags that describe which occlusion methods are active or available. These can be combined to enable multiple occlusion techniques simultaneously.
---
# enum OcclusionCaps

Flags that describe which occlusion methods are active or
available. These can be combined to enable multiple occlusion
techniques simultaneously.

## Enum Values

|  |  |
|--|--|
|Depth|Depth texture-based occlusion (e.g. META environment depth).|
|Hands|When combined with Depth: hands will also occlude virtual content. Without this flag, hands are removed from the depth buffer and will not occlude.|
|Mesh|Scene Understanding mesh-based occlusion (e.g. HoloLens).|
|None|No occlusion is active.|

## Examples

### Basic World Occlusion

A simple example of turning on occlusion. The method you use depends
on what the device supports — check `World.OcclusionCapabilities` to
see what's available. For example, HoloLens supports
`OcclusionCaps.Mesh`, while Quest supports `OcclusionCaps.Depth`.
```csharp
OcclusionCaps prevOcclusion;

public void Start()
{
	OcclusionCaps available = World.OcclusionCapabilities;
	if (available == OcclusionCaps.None)
		Log.Info("Occlusion not available!");

	// Store current state so we can restore it later
	prevOcclusion = World.Occlusion;

	// Enable whatever occlusion the device supports
	World.Occlusion = available;
}

public void Stop()
{
	// Restore the previous occlusion state
	World.Occlusion = prevOcclusion;
}
```

