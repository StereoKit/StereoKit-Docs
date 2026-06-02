---
layout: default
title: World.Occlusion
description: Gets or sets the active occlusion methods using flags. Use OcclusionCapabilities to check what the current device supports.
---
# [World]({{site.url}}/preview/Pages/StereoKit/World.html).Occlusion

<div class='signature' markdown='1'>
static [OcclusionCaps]({{site.url}}/preview/Pages/StereoKit/OcclusionCaps.html) Occlusion{ get set }
</div>

## Description
Gets or sets the active occlusion methods using flags.
Use `OcclusionCapabilities` to check what the current device
supports.


## Examples

### Configuring Quality Occlusion

If you expect the user's environment to change a lot, or you
anticipate the user's environment may not be well scanned already,
then you may wish to boost the frequency of world data updates. By
default, StereoKit is quite conservative about scanning to reduce
computation, but this can be configured using the World.RefreshX
properties as seen here.

```csharp
// If occlusion is not available, the rest of the code will have no
// effect.
if (World.OcclusionCapabilities == OcclusionCaps.None)
	Log.Info("Occlusion not available!");

// Configure SK to update the world data as fast as possible, this
// allows occlusion to accomodate better for moving objects.
World.Occlusion       = World.OcclusionCapabilities;
World.RefreshType     = WorldRefresh.Timer; // Refresh on a timer
World.RefreshInterval = 0; // Refresh every 0 seconds
World.RefreshRadius   = 6; // Get everything in a 6m radius
```
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

