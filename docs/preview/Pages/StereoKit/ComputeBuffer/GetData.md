---
layout: default
title: ComputeBuffer.GetData
description: Read the full buffer back from the GPU! This blocks until the data is ready, and allocates a new array each call. For per-frame readbacks, prefer the GetData(ref T[]) overload to avoid GC pressure!
---
# [ComputeBuffer]({{site.url}}/preview/Pages/StereoKit/ComputeBuffer.html).GetData

<div class='signature' markdown='1'>
```csharp
T[] GetData()
```
Read the full buffer back from the GPU! This blocks
until the data is ready, and allocates a new array each
call. For per-frame readbacks, prefer the GetData(ref T[])
overload to avoid GC pressure!
</div>

|  |  |
|--|--|
|RETURNS: T[]|A new array containing the full buffer contents.|

<div class='signature' markdown='1'>
```csharp
void GetData(T[]& data)
```
Read GPU data into a pre-allocated array! This is
the allocation-free version of GetData, great for calling
every frame without creating GC garbage. Reads
Math.Min(data.Length, Count) elements.
</div>

|  |  |
|--|--|
|T[]& data|A pre-allocated array to fill. If it's             smaller than the buffer, only data.Length elements are             read.|




