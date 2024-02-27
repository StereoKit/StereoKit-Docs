---
layout: default
title: UILathePt
description: A point on a lathe for a mesh generation algorithm. This is the 'silhouette' of the mesh, or the shape the mesh would take if you spun this line of points in a cylinder.
---
# struct UILathePt

A point on a lathe for a mesh generation algorithm. This is the
'silhouette' of the mesh, or the shape the mesh would take if you spun
this line of points in a cylinder.

## Instance Fields and Properties

|  |  |
|--|--|
|[Color32]({{site.url}}/Pages/StereoKit/Color32.html) [color]({{site.url}}/Pages/StereoKit/UILathePt/color.html)|Vertex color of the current lathe vertex.|
|bool [connectNext]({{site.url}}/Pages/StereoKit/UILathePt/connectNext.html)|Will there be triangles connecting this lathe point to the next in the list, or is this a jump without triangles?|
|bool [flipFace]({{site.url}}/Pages/StereoKit/UILathePt/flipFace.html)|Should the triangles attaching this point to the next be ordered backwards?|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) [normal]({{site.url}}/Pages/StereoKit/UILathePt/normal.html)|The lathe normal point, which will be rotated along the surface of the mesh.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) [pt]({{site.url}}/Pages/StereoKit/UILathePt/pt.html)|Lathe point 'location', where 'x' is a percentage of the lathe radius alnong the current surface normal, and Y is the absolute Z axis value.|
