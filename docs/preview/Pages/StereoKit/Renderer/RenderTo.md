---
layout: default
title: Renderer.RenderTo
description: This renders the current scene to the indicated rendertarget texture, from the specified viewpoint. This call enqueues a render that occurs immediately before the screen itself is rendered.
---
# [Renderer]({{site.url}}/preview/Pages/StereoKit/Renderer.html).RenderTo

<div class='signature' markdown='1'>
```csharp
static void RenderTo(Tex toRendertarget, Matrix camera, Matrix projection, RenderLayer layerFilter, int materialVariant, RenderClear clear, Rect viewport)
```
This renders the current scene to the indicated
rendertarget texture, from the specified viewpoint. This call
enqueues a render that occurs immediately before the screen
itself is rendered.
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html) toRendertarget|The texture to which the scene will be rendered to. This must be a Rendertarget type texture.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) camera|A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) projection|The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.|
|[RenderLayer]({{site.url}}/preview/Pages/StereoKit/RenderLayer.html) layerFilter|This is a bit flag that allows you to change which layers StereoKit renders for this particular render viewpoint. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter.|
|int materialVariant|Specifies which Material variant should be used for rendering. 0 will be the normal default material, any others will generally be application-defined by setting up each Material's Variant with specific shaders. If a Material has no corresponding variant, it will not be drawn.|
|[RenderClear]({{site.url}}/preview/Pages/StereoKit/RenderClear.html) clear|Describes if and how the rendertarget should be cleared before rendering. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!|
|[Rect]({{site.url}}/preview/Pages/StereoKit/Rect.html) viewport|Allows you to specify a region of the rendertarget to draw to! This is in normalized coordinates, 0-1. If the width of this value is zero, then this will render to the entire texture.|

<div class='signature' markdown='1'>
```csharp
static void RenderTo(Tex toRendertarget, int toTargetIndex, Matrix camera, Matrix projection, RenderLayer layerFilter, int materialVariant, RenderClear clear, Rect viewport)
```
This renders the current scene to the indicated
rendertarget texture, from the specified viewpoint. This call
enqueues a render that occurs immediately before the screen
itself is rendered.
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html) toRendertarget|The texture to which the scene will be rendered to. This must be a Rendertarget type texture.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) camera|A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) projection|The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.|
|[RenderLayer]({{site.url}}/preview/Pages/StereoKit/RenderLayer.html) layerFilter|This is a bit flag that allows you to change which layers StereoKit renders for this particular render viewpoint. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter.|
|int materialVariant|Specifies which Material variant should be used for rendering. 0 will be the normal default material, any others will generally be application-defined by setting up each Material's Variant with specific shaders. If a Material has no corresponding variant, it will not be drawn.|
|[RenderClear]({{site.url}}/preview/Pages/StereoKit/RenderClear.html) clear|Describes if and how the rendertarget should be cleared before rendering. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!|
|[Rect]({{site.url}}/preview/Pages/StereoKit/Rect.html) viewport|Allows you to specify a region of the rendertarget to draw to! This is in normalized coordinates, 0-1. If the width of this value is zero, then this will render to the entire texture.|
|int toTargetIndex|Index of the render target's array texture we want to draw to.|

<div class='signature' markdown='1'>
```csharp
static void RenderTo(Tex toRendertarget, Matrix camera, Matrix projection, RenderSettings settings)
```
This renders the current scene to the indicated
rendertarget texture from the specified viewpoint, using a
RenderSettings struct for everything else - including
tile-friendly post-processing effects! This call enqueues a
render that occurs immediately before the screen itself is
rendered.
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html) toRendertarget|The texture to which the scene will be rendered to. This must be a Rendertarget type texture.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) camera|A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) projection|The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.|
|[RenderSettings]({{site.url}}/preview/Pages/StereoKit/RenderSettings.html) settings|Settings for this render pass, a `default` here means all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.|

<div class='signature' markdown='1'>
```csharp
static void RenderTo(Tex toRendertarget, int toTargetIndex, Matrix camera, Matrix projection, RenderSettings settings)
```
This renders the current scene to the indicated
rendertarget texture from the specified viewpoint, using a
RenderSettings struct for everything else - including
tile-friendly post-processing effects! This call enqueues a
render that occurs immediately before the screen itself is
rendered.
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html) toRendertarget|The texture to which the scene will be rendered to. This must be a Rendertarget type texture.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) camera|A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) projection|The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.|
|[RenderSettings]({{site.url}}/preview/Pages/StereoKit/RenderSettings.html) settings|Settings for this render pass, a `default` here means all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.|
|int toTargetIndex|Index of the render target's array texture we want to draw to.|

<div class='signature' markdown='1'>
```csharp
static void RenderTo(Tex toRendertarget, Matrix[]& cameras, Matrix[]& projections, RenderLayer layerFilter, int materialVariant, RenderClear clear, Rect viewport)
```
Multi-view variant of RenderTo. Queues a single render
pass that draws the active list into N views at once, with one
camera + projection per view, writing into N consecutive layers
of an array rendertarget. The number of views is capped by the
engine's max-views constant. Like the single-view RenderTo,
this is queued for the next pipeline frame.
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html) toRendertarget|An array or cubemap rendertarget with at least `cameras.Length` layers.|
|Matrix[]& cameras|View transforms, one per view.|
|Matrix[]& projections|Projection matrices, one per view. Length must match `cameras`.|
|[RenderLayer]({{site.url}}/preview/Pages/StereoKit/RenderLayer.html) layerFilter|Bit flag for which render layers to include this pass.|
|int materialVariant|Which material variant to use.|
|[RenderClear]({{site.url}}/preview/Pages/StereoKit/RenderClear.html) clear|Whether and how to clear the rendertarget.|
|[Rect]({{site.url}}/preview/Pages/StereoKit/Rect.html) viewport|Subregion in normalized 0-1 coordinates.|

<div class='signature' markdown='1'>
```csharp
static void RenderTo(Tex toRendertarget, Matrix[]& cameras, Matrix[]& projections, RenderSettings settings)
```
This renders the current scene to the indicated
rendertarget texture from the specified viewpoint, using a
RenderSettings struct for everything else - including
tile-friendly post-processing effects! This call enqueues a
render that occurs immediately before the screen itself is
rendered.
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html) toRendertarget|The texture to which the scene will be rendered to. This must be a Rendertarget type texture.|
|[RenderSettings]({{site.url}}/preview/Pages/StereoKit/RenderSettings.html) settings|Settings for this render pass, a `default` here means all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.|
|Matrix[]& cameras|View transforms, one per view.|
|Matrix[]& projections|Projection matrices, one per view. Length must match `cameras`.|





## Examples

### Rendering a viewpoint with post-processing
RenderSettings works with Renderer.RenderTo and RenderList.DrawNow,
and can carry a post-process chain that applies to just that pass!
```csharp
Tex target = Tex.RenderTarget(512, 512);
Renderer.RenderTo(target, Matrix.T(0, 0, 1), Matrix.Perspective(90, 1, 0.1f, 50),
	new RenderSettings { clearColor  = Color.Black,
	                     postProcess = new Material[] { vignette } });
```

