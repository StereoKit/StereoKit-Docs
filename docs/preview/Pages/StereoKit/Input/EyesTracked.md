---
layout: default
title: Input.EyesTracked
description: If eye hardware is available and app has permission, then this is the tracking state of the eyes. Eyes may move out of bounds, hardware may fail to detect eyes, or who knows what else!  On Flatscreen when MR sim is still enabled, this will report whether the user is simulating eye input with the Alt key.  **Permissions** - On some platforms (like Android) explicit permission is required to access eye info. See the Permissions class for details.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).EyesTracked

<div class='signature' markdown='1'>
static [BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) EyesTracked{ get }
</div>

## Description
If eye hardware is available and app has permission,
then this is the tracking state of the eyes. Eyes may move out of
bounds, hardware may fail to detect eyes, or who knows what else!

On Flatscreen when MR sim is still enabled, this will report
whether the user is simulating eye input with the Alt key.

**Permissions**
- On some platforms (like Android) explicit permission is required to access eye info. See the Permissions class for details.


## Examples

```csharp
if (Input.EyesTracked.IsActive())
{
	// Intersect the eye Ray with a floor plane
	Plane plane = new Plane(Vec3.Zero, Vec3.Up);
	if (Input.Eyes.Ray.Intersect(plane, out Vec3 at))
	{
		Default.MeshSphere.Draw(Default.Material, Matrix.TS(at, .05f));
	}
}
```

