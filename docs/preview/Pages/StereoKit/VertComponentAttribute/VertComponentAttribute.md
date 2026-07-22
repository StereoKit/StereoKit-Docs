---
layout: default
title: VertComponentAttribute.VertComponentAttribute
description: Describe the vertex component this field contains.
---
# [VertComponentAttribute]({{site.url}}/preview/Pages/StereoKit/VertComponentAttribute.html).VertComponentAttribute

<div class='signature' markdown='1'>
```csharp
void VertComponentAttribute(VertSemantic semantic, VertFmt format, int count, int semanticSlot)
```
Describe the vertex component this field contains.
</div>

|  |  |
|--|--|
|[VertSemantic]({{site.url}}/preview/Pages/StereoKit/VertSemantic.html) semantic|What this component means, this is matched with the shader's vertex input semantics.|
|[VertFmt]({{site.url}}/preview/Pages/StereoKit/VertFmt.html) format|The data format of a single element of this component.|
|int count|How many format elements this component has, 1-4. A Vec3 position would be 3.|
|int semanticSlot|Distinguishes multiple components with the same semantic, like TEXCOORD0 vs TEXCOORD1.|




