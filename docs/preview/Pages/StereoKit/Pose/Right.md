---
layout: default
title: Pose.Right
description: Calculates the right (+X) direction from this pose. This is done by multiplying the orientation with Vec3.Right.
---
# [Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html).Right

<div class='signature' markdown='1'>
[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) Right{ get }
</div>

## Description
Calculates the right (+X) direction from this pose. This
is done by multiplying the orientation with Vec3.Right.


## Examples

### Pose Directions

![Pose direction lines]({{site.url}}/preview/img/screenshots/Docs/PoseDirections.jpg)

`Pose` provides a few handy vector properties to help working with
`Pose` relative directions! `Forward`, `Right`, and `Up` are all
derived from the `Pose`'s orientation, and represent the -Z, +X and
+Y directions of the `Pose`.

```csharp
Pose p = new Pose(0,0,-0.5f);
model.Draw(p.ToMatrix(0.03f));

Lines.Add(p.position, p.position + 0.1f*p.Right,   new Color32(255,0,0,255), 0.005f);
Lines.Add(p.position, p.position + 0.1f*p.Up,      new Color32(0,255,0,255), 0.005f);
Lines.Add(p.position, p.position + 0.1f*p.Forward, Color32.White,            0.005f);
```

