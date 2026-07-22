---
layout: default
title: VertComponent.VertComponent
description: Describes a single vertex component.
---
# [VertComponent]({{site.url}}/preview/Pages/StereoKit/VertComponent.html).VertComponent

<div class='signature' markdown='1'>
```csharp
void VertComponent(VertSemantic semantic, VertFmt format, int count, int semanticSlot)
```
Describes a single vertex component.
</div>

|  |  |
|--|--|
|[VertSemantic]({{site.url}}/preview/Pages/StereoKit/VertSemantic.html) semantic|What this component means, this is matched with the shader's vertex input semantics.|
|[VertFmt]({{site.url}}/preview/Pages/StereoKit/VertFmt.html) format|The data format of a single element of this component.|
|int count|How many format elements this component has, 1-4. A float3 position would be 3.|
|int semanticSlot|Distinguishes multiple components with the same semantic, like TEXCOORD0 vs TEXCOORD1.|




