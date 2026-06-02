---
layout: default
title: Compute.Dispatch
description: Queue this compute dispatch into the render pipeline. It will run during the next frame's render setup phase, in source order with other queued render actions (Renderer.RenderTo, Renderer.SetGlobal*). This is the recommended path for compute work that participates in the frame's rendering pipeline (e.g. populating a texture that a later RenderTo or the main pass will sample), since sk_renderer can manage the necessary GPU barriers between queued items.  IMPORTANT. bindings (textures, buffers, constants, scalar parameters) are NOT snapshotted when Dispatch is called — they are read at execute time, which happens later in the frame. If you change a binding between two queued Dispatch calls on the same Compute, both dispatches will see the final binding state, not the state at their respective Dispatch times. To dispatch the same Compute with different bindings, either issue each Dispatch with DispatchNow, or use a separate Compute instance per binding set.  The parameters are the number of thread _groups_, not individual threads. Total thread count = groupCount * numthreads (as defined in your HLSL). So if your shader says [numthreads(8,8,1)] and you dispatch (64,64,1), you'll get 512*512 threads.
---
# [Compute]({{site.url}}/preview/Pages/StereoKit/Compute.html).Dispatch

<div class='signature' markdown='1'>
```csharp
void Dispatch(uint groupCountX, uint groupCountY, uint groupCountZ)
```
Queue this compute dispatch into the render pipeline.
It will run during the next frame's render setup phase, in
source order with other queued render actions
(Renderer.RenderTo, Renderer.SetGlobal*). This is the
recommended path for compute work that participates in the
frame's rendering pipeline (e.g. populating a texture that a
later RenderTo or the main pass will sample), since
sk_renderer can manage the necessary GPU barriers between
queued items.

IMPORTANT: bindings (textures, buffers, constants, scalar
parameters) are NOT snapshotted when Dispatch is called —
they are read at execute time, which happens later in the
frame. If you change a binding between two queued Dispatch
calls on the same Compute, both dispatches will see the
final binding state, not the state at their respective
Dispatch times. To dispatch the same Compute with different
bindings, either issue each Dispatch with DispatchNow, or
use a separate Compute instance per binding set.

The parameters are the number of thread _groups_, not
individual threads. Total thread count = groupCount *
numthreads (as defined in your HLSL). So if your shader says
[numthreads(8,8,1)] and you dispatch (64,64,1), you'll get
512*512 threads.
</div>

|  |  |
|--|--|
|uint groupCountX|Thread groups in X.|
|uint groupCountY|Thread groups in Y.|
|uint groupCountZ|Thread groups in Z.|




