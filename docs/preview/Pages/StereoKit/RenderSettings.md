---
layout: default
title: RenderSettings
description: Optional settings for rendering a camera viewpoint to a rendertarget, used by Renderer.RenderTo and RenderList.DrawNow. This is a plain struct where zero means 'default' - a default or new RenderSettings gives you. all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.
---
# struct RenderSettings

Optional settings for rendering a camera viewpoint to a
rendertarget, used by Renderer.RenderTo and RenderList.DrawNow. This
is a plain struct where zero means 'default' - a `default` or `new`
RenderSettings gives you: all layers, the default material variant,
clear everything to transparent black, a full-target viewport, and no
post-processing.

## Instance Fields and Properties

|  |  |
|--|--|
|[RenderClear]({{site.url}}/preview/Pages/StereoKit/RenderClear.html) [clear]({{site.url}}/preview/Pages/StereoKit/RenderSettings/clear.html)|Describes if and how the rendertarget should be cleared before rendering. A value of 0 (the default) clears everything, use RenderClear.Keep to draw on top of the target's existing content. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!|
|[Color]({{site.url}}/preview/Pages/StereoKit/Color.html) [clearColor]({{site.url}}/preview/Pages/StereoKit/RenderSettings/clearColor.html)|If `clear` clears color, this is the color it will clear to, in linear space. Default is a transparent black.|
|[RenderLayer]({{site.url}}/preview/Pages/StereoKit/RenderLayer.html) [layerFilter]({{site.url}}/preview/Pages/StereoKit/RenderSettings/layerFilter.html)|This is a bit flag that allows you to change which layers StereoKit renders for this particular pass. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter. A value of 0 (the default) means RenderLayer.All.|
|int [materialVariant]({{site.url}}/preview/Pages/StereoKit/RenderSettings/materialVariant.html)|Specifies which Material variant should be used for rendering. 0 is the normal default material, any others will generally be application-defined by setting up each Material's Variant with specific shaders. If a Material has no corresponding variant, it will not be drawn.|
|Material[] [postProcess]({{site.url}}/preview/Pages/StereoKit/RenderSettings/postProcess.html)|An optional list of post-process Materials for this pass, applied in array order. These are tile-friendly subpass effects, see Renderer.SetPostProcess for the shader requirements. Null is fine here, and means no post-processing.|
|[Rect]({{site.url}}/preview/Pages/StereoKit/Rect.html) [viewport]({{site.url}}/preview/Pages/StereoKit/RenderSettings/viewport.html)|Allows you to specify a region of the rendertarget to draw to! This is in normalized coordinates, 0-1. If the width of this value is zero (the default), then this will render to the entire texture.|

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

