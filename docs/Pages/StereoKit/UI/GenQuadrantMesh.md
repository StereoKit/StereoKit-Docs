---
layout: default
title: UI.GenQuadrantMesh
description: This generates a quadrantified mesh meant for UI buttons by sweeping a lathe over the rounded corners of a rectangle! Note that this mesh is quadrantified, so it requires special shaders to draw properly!
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).GenQuadrantMesh

<div class='signature' markdown='1'>
```csharp
static Mesh GenQuadrantMesh(UICorner roundedCorners, float cornerRadius, uint cornerResolution, bool deleteFlatSides, UILathePt[] lathePts)
```
This generates a quadrantified mesh meant for UI buttons
by sweeping a lathe over the rounded corners of a rectangle! Note
that this mesh is quadrantified, so it requires special shaders to
draw properly!
</div>

|  |  |
|--|--|
|[UICorner]({{site.url}}/Pages/StereoKit/UICorner.html) roundedCorners|A bit-flag indicating which corners             should be rounded, and which should be sharp!|
|float cornerRadius|The radius of each rounded corner.|
|uint cornerResolution|How many slices/verts go into each corner?             More is smoother, but more expensive to render.|
|bool deleteFlatSides|If two adjacent corners are sharp, should             we skip connecting them with triangles? If this edge will always be             covered, then deleting these faces may save you some performance.|
|UILathePt[] lathePts|The lathe points to sweep around the edge.|
|RETURNS: [Mesh]({{site.url}}/Pages/StereoKit/Mesh.html)|The final Mesh, ready for use in SK's theming system.|




