---
layout: default
title: ComputeBufferType
description: Describes the access mode of a ComputeBuffer for use in compute shaders.
---
# enum ComputeBufferType

Describes the access mode of a ComputeBuffer for use in compute
shaders.

## Enum Values

|  |  |
|--|--|
|Read|Read-only from compute shaders. Maps to StructuredBuffer<T> in HLSL.|
|ReadWrite|Read-write from compute shaders. Maps to RWStructuredBuffer<T> in HLSL.|
