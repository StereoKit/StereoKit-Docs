---
layout: default
title: Renderer.SetPostProcess
description: Sets the main display's post-process chain! The Materials apply in array order, at most 2 per pass, and calling this with no arguments clears the chain. Post-processing here is tile-renderer friendly. effects run as subpasses that stay in tile memory on mobile GPUs, and they apply to the main display and to screenshots - what you see is what you shoot.  A post-process Material's shader reads the scene through a pixel-local input attachment named 'color' (in HLSL, [[vk..input_attachment_index(0)]] SubpassInput<float4> color; read with color.SubpassLoad()), draws as a bufferless fullscreen triangle from SV_VertexID, and so cannot have vertex inputs. It may also read depth through an input attachment named 'depth' at index 1. Materials that don't qualify are rejected with an error log. Regular textures and Material parameters work normally, and can be animated per-frame.
---
# [Renderer]({{site.url}}/preview/Pages/StereoKit/Renderer.html).SetPostProcess

<div class='signature' markdown='1'>
```csharp
static void SetPostProcess(Material[] postProcessChain)
```
Sets the main display's post-process chain! The
Materials apply in array order, at most 2 per pass, and calling
this with no arguments clears the chain. Post-processing here is
tile-renderer friendly: effects run as subpasses that stay in
tile memory on mobile GPUs, and they apply to the main display
and to screenshots - what you see is what you shoot.

A post-process Material's shader reads the scene through a
pixel-local input attachment named 'color' (in HLSL,
`[[vk::input_attachment_index(0)]] SubpassInput<float4> color;`
read with `color.SubpassLoad()`), draws as a bufferless
fullscreen triangle from SV_VertexID, and so cannot have vertex
inputs. It may also read depth through an input attachment named
'depth' at index 1. Materials that don't qualify are rejected
with an error log. Regular textures and Material parameters work
normally, and can be animated per-frame.
</div>

|  |  |
|--|--|
|Material[] postProcessChain|Materials whose shaders qualify as post-process effects, applied in order. Empty clears the chain.|





## Examples

### Setting a post-process chain
A post-process effect is just a Material! Its shader reads the
scene through an input attachment named 'color', and its
parameters can be changed live, like any other Material. The
chain renders in argument order.
```csharp
Material vignette = new Material("postfx_vignette.hlsl");
vignette["strength"] = 0.4f;
Renderer.SetPostProcess(vignette);
```

And when you're done with it:
```csharp
Renderer.SetPostProcess();
```

