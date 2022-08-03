---
layout: default
title: Material.FaceCull
description: How should this material cull faces?
---
# [Material]({{site.url}}/Pages/StereoKit/Material.html).FaceCull

<div class='signature' markdown='1'>
[Cull]({{site.url}}/Pages/StereoKit/Cull.html) FaceCull{ get set }
</div>

## Description
How should this material cull faces?


## Examples

Here's setting FaceCull to Front, which is the opposite of the
default behavior. On a sphere, this is a little hard to see, but
you might notice here that the lighting is for the back side of
the sphere!
```csharp
matCull = Material.Default.Copy();
matCull.FaceCull = Cull.Front;
```
![FaceCull material example]({{site.screen_url}}/MaterialCull.jpg)

