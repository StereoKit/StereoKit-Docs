---
layout: default
title: Renderer.RenderTo
description: This renders the current scene to the indicated rendertarget texture, from the specified viewpoint. This call enqueues a render that occurs immediately before the screen itself is rendered.
---
# [Renderer]({{site.url}}/Pages/StereoKit/Renderer.html).RenderTo

<div class='signature' markdown='1'>
```csharp
static void RenderTo(Tex toRendertarget, Matrix camera, Matrix projection, RenderLayer layerFilter, RenderClear clear, Rect viewport)
```
This renders the current scene to the indicated
rendertarget texture, from the specified viewpoint. This call
enqueues a render that occurs immediately before the screen
itself is rendered.
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/Pages/StereoKit/Tex.html) toRendertarget|The texture to which the scene will             be rendered to. This must be a Rendertarget type texture.|
|[Matrix]({{site.url}}/Pages/StereoKit/Matrix.html) camera|A TRS matrix representing the location and             orientation of the camera. This matrix gets inverted later on, so             no need to do it yourself.|
|[Matrix]({{site.url}}/Pages/StereoKit/Matrix.html) projection|The projection matrix describes how the             geometry is flattened onto the draw surface. Normally, you'd use              Matrix.Perspective, and occasionally Matrix.Orthographic might be             helpful as well.|
|[RenderLayer]({{site.url}}/Pages/StereoKit/RenderLayer.html) layerFilter|This is a bit flag that allows you to             change which layers StereoKit renders for this particular render             viewpoint. To change what layers a visual is on, use a Draw             method that includes a RenderLayer as a parameter.|
|[RenderClear]({{site.url}}/Pages/StereoKit/RenderClear.html) clear|Describes if and how the rendertarget should             be cleared before rendering. Note that clearing the target is             unaffected by the viewport, so this will clean the entire              surface!|
|[Rect]({{site.url}}/Pages/StereoKit/Rect.html) viewport|Allows you to specify a region of the             rendertarget to draw to! This is in normalized coordinates, 0-1.             If the width of this value is zero, then this will render to the             entire texture.|




