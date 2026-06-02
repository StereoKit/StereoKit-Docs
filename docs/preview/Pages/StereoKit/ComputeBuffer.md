---
layout: default
title: ComputeBuffer
description: A GPU storage buffer for shuttling data to and from compute shaders! In HLSL, this maps to StructuredBuffer<T> or RWStructuredBuffer<T> depending on the ComputeBufferType.  Your struct T needs to be unmanaged (no reference types!) and its layout _must_ match the HLSL struct. Watch out for padding differences between C# and HLSL!
---
# class ComputeBuffer

A GPU storage buffer for shuttling data to and from
compute shaders! In HLSL, this maps to StructuredBuffer<T>
or RWStructuredBuffer<T> depending on the
ComputeBufferType.

Your struct T needs to be unmanaged (no reference types!) and
its layout _must_ match the HLSL struct. Watch out for
padding differences between C# and HLSL!

## Instance Fields and Properties

|  |  |
|--|--|
|int [Count]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer/Count.html)|The capacity of the buffer, in number of T elements. This is the max you can Set or Get without clamping.|
|string [Id]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer/Id.html)|Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!|
|int [Stride]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer/Stride.html)|Size of a single element in bytes, derived from your T struct. Handy for sanity-checking that your C# struct matches the HLSL side!|

## Instance Methods

|  |  |
|--|--|
|[ComputeBuffer]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer/ComputeBuffer.html)|Creates a GPU storage buffer with room for elementCount elements, initially uninitialized! The contents will be whatever was in GPU memory before, so make sure to write before you read.|
|[GetData]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer/GetData.html)|Read the full buffer back from the GPU! This blocks until the data is ready, and allocates a new array each call. For per-frame readbacks, prefer the GetData(ref T[]) overload to avoid GC pressure!|
|[SetData]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer/SetData.html)|Upload data from the CPU to the GPU! If data.Length exceeds the buffer's capacity, it will be clamped with a warning.|
