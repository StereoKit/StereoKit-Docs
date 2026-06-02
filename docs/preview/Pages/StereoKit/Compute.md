---
layout: default
title: Compute
description: Compute shaders allow you to run code on the GPU in a massively parallel way! This is great for accelerating complex work, or simply for working inline with the graphics pipeline with easy access to GPU memory.  This behaves very much like Materials do! You can set parameters, and attach buffers or textures! Unlike Materials, you need to dispatch the compute shader to make it run. You may need to be a bit cautious about compute data, since the GPU can be picky about what and when it reads and writes to!
---
# class Compute

Compute shaders allow you to run code on the GPU in a
massively parallel way! This is great for accelerating complex work, or
simply for working inline with the graphics pipeline with easy access
to GPU memory.

This behaves very much like Materials do! You can set parameters, and
attach buffers or textures! Unlike Materials, you need to dispatch the
compute shader to make it run. You may need to be a bit cautious about
compute data, since the GPU can be picky about what and when it reads
and writes to!

## Instance Fields and Properties

|  |  |
|--|--|
|string [Id]({{site.url}}/preview/Pages/StereoKit/Compute/Id.html)|Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!|
|int [ParamCount]({{site.url}}/preview/Pages/StereoKit/Compute/ParamCount.html)|The number of shader parameters available on this Compute! This includes both variables and textures/buffers, great for building a GUI that can inspect any shader.|
|[Shader]({{site.url}}/preview/Pages/StereoKit/Shader.html) [Shader]({{site.url}}/preview/Pages/StereoKit/Compute/Shader.html)|The shader associated with this compute object. Each access here creates a new reference!|

## Instance Methods

|  |  |
|--|--|
|[Compute]({{site.url}}/preview/Pages/StereoKit/Compute/Compute.html)|Create a Compute dispatch from a shader that has a compute stage! If the shader doesn't have a compute stage, this will fail.|
|[Dispatch]({{site.url}}/preview/Pages/StereoKit/Compute/Dispatch.html)|Queue this compute dispatch into the render pipeline. It will run during the next frame's render setup phase, in source order with other queued render actions (Renderer.RenderTo, Renderer.SetGlobal*). This is the recommended path for compute work that participates in the frame's rendering pipeline (e.g. populating a texture that a later RenderTo or the main pass will sample), since sk_renderer can manage the necessary GPU barriers between queued items.  IMPORTANT: bindings (textures, buffers, constants, scalar parameters) are NOT snapshotted when Dispatch is called — they are read at execute time, which happens later in the frame. If you change a binding between two queued Dispatch calls on the same Compute, both dispatches will see the final binding state, not the state at their respective Dispatch times. To dispatch the same Compute with different bindings, either issue each Dispatch with DispatchNow, or use a separate Compute instance per binding set.  The parameters are the number of thread _groups_, not individual threads. Total thread count = groupCount * numthreads (as defined in your HLSL). So if your shader says [numthreads(8,8,1)] and you dispatch (64,64,1), you'll get 512*512 threads.|
|[DispatchNow]({{site.url}}/preview/Pages/StereoKit/Compute/DispatchNow.html)|Run this compute dispatch synchronously, right now, on the calling thread. Use this for ad-hoc work that doesn't belong in the per-frame render pipeline (debugging, one-shot tasks, immediate readbacks). For compute work that feeds into later render passes within the same frame, prefer Dispatch, which queues into the pipeline and lets sk_renderer handle ordering and barriers automatically.|
|[GetAllParamInfo]({{site.url}}/preview/Pages/StereoKit/Compute/GetAllParamInfo.html)|Gets an enumerable list of all parameter info on this Compute! Handy for building auto-generated shader GUIs or inspectors.|
|[GetBool]({{site.url}}/preview/Pages/StereoKit/Compute/GetBool.html)|Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.|
|[GetColor]({{site.url}}/preview/Pages/StereoKit/Compute/GetColor.html)|Gets a color parameter by name! Note that SetColor converts gamma to linear, so this returns the _linear_ value the shader is actually using.|
|[GetFloat]({{site.url}}/preview/Pages/StereoKit/Compute/GetFloat.html)|Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.|
|[GetInt]({{site.url}}/preview/Pages/StereoKit/Compute/GetInt.html)|Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.|
|[GetMatrix]({{site.url}}/preview/Pages/StereoKit/Compute/GetMatrix.html)|Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.|
|[GetParamInfo]({{site.url}}/preview/Pages/StereoKit/Compute/GetParamInfo.html)|Gets parameter info at a specific index! Parameters are listed as variables first, then textures and buffers.|
|[GetUInt]({{site.url}}/preview/Pages/StereoKit/Compute/GetUInt.html)|Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.|
|[GetVector2]({{site.url}}/preview/Pages/StereoKit/Compute/GetVector2.html)|Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.|
|[GetVector3]({{site.url}}/preview/Pages/StereoKit/Compute/GetVector3.html)|Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.|
|[GetVector4]({{site.url}}/preview/Pages/StereoKit/Compute/GetVector4.html)|Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.|
|[SetBool]({{site.url}}/preview/Pages/StereoKit/Compute/SetBool.html)|Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!|
|[SetColor]({{site.url}}/preview/Pages/StereoKit/Compute/SetColor.html)|Set a color parameter by name! Color is converted from gamma to linear space, so what the shader receives will be in linear. If you're working in linear already, use SetVector with a Vec4 instead!|
|[SetConstant]({{site.url}}/preview/Pages/StereoKit/Compute/SetConstant.html)|Sets a constant/uniform buffer (cbuffer) on the shader. This is for smaller chunks of data (16kb max) that can be read from faster than textures or StructuredBuffers.|
|[SetFloat]({{site.url}}/preview/Pages/StereoKit/Compute/SetFloat.html)|Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!|
|[SetInt]({{site.url}}/preview/Pages/StereoKit/Compute/SetInt.html)|Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!|
|[SetMatrix]({{site.url}}/preview/Pages/StereoKit/Compute/SetMatrix.html)|Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!|
|[SetStorage]({{site.url}}/preview/Pages/StereoKit/Compute/SetStorage.html)|Sets a RW/StructuredBuffer or ByteAddressBuffer on the shader. This is used to provide BIG arrays of data to the GPU, for both reading and writing! These perform very similarly to textures, and can be thought of as big textures of just data!|
|[SetTexture]({{site.url}}/preview/Pages/StereoKit/Compute/SetTexture.html)|Bind a texture to a named resource in the shader! If you're writing to it (RWTexture2D), the texture _must_ have TexType.Compute set, and use a format like TexFormat.Rgba128. Read-only Texture2D bindings work with any texture. Fallbacks are resolved at Dispatch time, so textures that are still loading will Just Work.|
|[SetUInt]({{site.url}}/preview/Pages/StereoKit/Compute/SetUInt.html)|Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!|
|[SetVector]({{site.url}}/preview/Pages/StereoKit/Compute/SetVector.html)|Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!|

## Static Methods

|  |  |
|--|--|
|[Find]({{site.url}}/preview/Pages/StereoKit/Compute/Find.html)|Looks for a Compute object that has already been created with a matching id!|
