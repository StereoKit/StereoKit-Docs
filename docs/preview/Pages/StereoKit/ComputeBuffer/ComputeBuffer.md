---
layout: default
title: ComputeBuffer.ComputeBuffer
description: Creates a GPU storage buffer with room for elementCount elements, initially uninitialized! The contents will be whatever was in GPU memory before, so make sure to write before you read.
---
# [ComputeBuffer]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer.html).ComputeBuffer

<div class='signature' markdown='1'>
```csharp
void ComputeBuffer(ComputeBufferType type, int elementCount)
```
Creates a GPU storage buffer with room for
elementCount elements, initially uninitialized! The contents
will be whatever was in GPU memory before, so make sure to
write before you read.
</div>

|  |  |
|--|--|
|[ComputeBufferType]({{site.url}}/preview/Pages/StereoKit/ComputeBufferType.html) type|Read or ReadWrite access from compute shaders.|
|int elementCount|Number of T elements to allocate.|

<div class='signature' markdown='1'>
```csharp
void ComputeBuffer(ComputeBufferType type, T[] initialData)
```
Creates a GPU storage buffer and immediately uploads
initialData to it! The buffer capacity is set to the array
length.
</div>

|  |  |
|--|--|
|[ComputeBufferType]({{site.url}}/preview/Pages/StereoKit/ComputeBufferType.html) type|Read or ReadWrite access from compute shaders.|
|T[] initialData|Array of data to upload to the GPU.|




