---
layout: default
title: VertComponent
description: A single component of a custom vertex layout, such as a position or a UV coordinate. A vertex format is described by an array of these, in the same order the components appear in the vertex data. Data is always tightly packed, aligned to nothing, so the format fully describes the vertex layout.  This maps to a compact 4 byte native representation, the properties here disguise that byte packing.
---
# struct VertComponent

A single component of a custom vertex layout, such as a
position or a UV coordinate. A vertex format is described by an array
of these, in the same order the components appear in the vertex data.
Data is always tightly packed, aligned to nothing, so the format
fully describes the vertex layout.

This maps to a compact 4 byte native representation, the properties
here disguise that byte packing.

## Instance Fields and Properties

|  |  |
|--|--|
|int [Count]({{site.url}}/preview/Pages/StereoKit/VertComponent/Count.html)|How many format elements this component has, 1-4. A float3 position would be 3.|
|[VertFmt]({{site.url}}/preview/Pages/StereoKit/VertFmt.html) [Format]({{site.url}}/preview/Pages/StereoKit/VertComponent/Format.html)|The data format of a single element of this component.|
|[VertSemantic]({{site.url}}/preview/Pages/StereoKit/VertSemantic.html) [Semantic]({{site.url}}/preview/Pages/StereoKit/VertComponent/Semantic.html)|What this component means, this is matched with the shader's vertex input semantics.|
|int [SemanticSlot]({{site.url}}/preview/Pages/StereoKit/VertComponent/SemanticSlot.html)|Distinguishes multiple components with the same semantic, like TEXCOORD0 vs TEXCOORD1. Usually 0.|

## Instance Methods

|  |  |
|--|--|
|[VertComponent]({{site.url}}/preview/Pages/StereoKit/VertComponent/VertComponent.html)|Describes a single vertex component.|
