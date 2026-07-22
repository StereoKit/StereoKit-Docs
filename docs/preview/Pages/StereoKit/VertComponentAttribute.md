---
layout: default
title: VertComponentAttribute
description: Describes how a field of a vertex struct maps to a component of a vertex format! Tag every field of your custom vertex struct with this attribute, and Mesh.SetVerts<T> will derive the complete vertex format from the struct via reflection.  The field's format is explicit rather than inferred from the field's type, so the field just needs to be the right size for the format. This means packed data like a pair of half floats can live in a plain uint field, with bit math or types like System.Half used to fill it in.  Vertex structs must be tightly packed, with no padding between fields or at the end of the struct. If your field sizes don't naturally align, use [StructLayout(LayoutKind.Sequential, Pack = 1)].
---
# class VertComponentAttribute

Describes how a field of a vertex struct maps to a component
of a vertex format! Tag every field of your custom vertex struct with
this attribute, and `Mesh.SetVerts<T>` will derive the complete
vertex format from the struct via reflection.

The field's format is explicit rather than inferred from the field's
type, so the field just needs to be the right size for the format.
This means packed data like a pair of half floats can live in a plain
`uint` field, with bit math or types like `System.Half` used to fill
it in.

Vertex structs must be tightly packed, with no padding between fields
or at the end of the struct. If your field sizes don't naturally align,
use `[StructLayout(LayoutKind.Sequential, Pack = 1)]`.

## Instance Fields and Properties

|  |  |
|--|--|
|int [Count]({{site.url}}/preview/Pages/StereoKit/VertComponentAttribute/Count.html)|How many format elements this component has, 1-4. A Vec3 position would be 3.|
|[VertFmt]({{site.url}}/preview/Pages/StereoKit/VertFmt.html) [Format]({{site.url}}/preview/Pages/StereoKit/VertComponentAttribute/Format.html)|The data format of a single element of this component.|
|[VertSemantic]({{site.url}}/preview/Pages/StereoKit/VertSemantic.html) [Semantic]({{site.url}}/preview/Pages/StereoKit/VertComponentAttribute/Semantic.html)|What this component means, this is matched with the shader's vertex input semantics.|
|int [SemanticSlot]({{site.url}}/preview/Pages/StereoKit/VertComponentAttribute/SemanticSlot.html)|Distinguishes multiple components with the same semantic, like TEXCOORD0 vs TEXCOORD1. Usually 0.|

## Instance Methods

|  |  |
|--|--|
|[VertComponentAttribute]({{site.url}}/preview/Pages/StereoKit/VertComponentAttribute/VertComponentAttribute.html)|Describe the vertex component this field contains.|

## Examples

### Custom vertex formats
Meshes can use custom vertex layouts! Define a struct that provides
what your shader's vertex stage needs, and tag each field with a
VertComponent attribute saying what it is. StereoKit derives the
vertex format from the struct automatically. Since vertex data is
matched to shader inputs by semantic, fields don't need to be in the
same order as the shader declares them!
```csharp
[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct VertPosColor
{
	[VertComponent(VertSemantic.Color,    VertFmt.U8Normalized, 4)]
	public Color32 color;
	[VertComponent(VertSemantic.Position, VertFmt.F32,          3)]
	public Vec3    pos;

	public VertPosColor(Vec3 position, Color32 c) { pos = position; color = c; }
}

Mesh     _mesh;
Material _material;

Mesh BuildOctahedron(float s)
{
	Mesh mesh = new Mesh();
	mesh.SetVerts(new VertPosColor[] {
		new VertPosColor(V.XYZ( s, 0, 0), new Color32(255,  0,  0,255)),
		new VertPosColor(V.XYZ(-s, 0, 0), new Color32(  0,255,  0,255)),
		new VertPosColor(V.XYZ( 0, s, 0), new Color32(  0,  0,255,255)),
		new VertPosColor(V.XYZ( 0,-s, 0), new Color32(255,255,  0,255)),
		new VertPosColor(V.XYZ( 0, 0, s), new Color32(  0,255,255,255)),
		new VertPosColor(V.XYZ( 0, 0,-s), new Color32(255,  0,255,255)) });
	mesh.SetInds(new uint[] {
		2,4,0,  2,0,5,  2,5,1,  2,1,4,
		3,0,4,  3,5,0,  3,1,5,  3,4,1 });
	return mesh;
}
```

