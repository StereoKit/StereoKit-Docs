---
layout: default
title: VertFmt
description: The data format of a single element of a vertex component. Normalized formats map their integer range onto 0-1 (unsigned) or -1-1 (signed) when read by the GPU, other integer formats arrive as integers.
---
# enum VertFmt

The data format of a single element of a vertex component. Normalized
formats map their integer range onto 0-1 (unsigned) or -1-1 (signed)
when read by the GPU, other integer formats arrive as integers.

## Enum Values

|  |  |
|--|--|
|F16|16 bit half float.|
|F32|32 bit float.|
|I16|16 bit signed integer.|
|I16Normalized|16 bit signed integer, normalized to -1-1 on the GPU.|
|I32|32 bit signed integer.|
|I8|8 bit signed integer.|
|I8Normalized|8 bit signed integer, normalized to -1-1 on the GPU.|
|None|Invalid format, this is not a valid value for a component.|
|U16|16 bit unsigned integer.|
|U16Normalized|16 bit unsigned integer, normalized to 0-1 on the GPU.|
|U32|32 bit unsigned integer.|
|U8|8 bit unsigned integer.|
|U8Normalized|8 bit unsigned integer, normalized to 0-1 on the GPU. A color32 is 4 of these.|

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

