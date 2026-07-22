---
layout: default
title: VertSemantic
description: What a vertex component means! This is matched against the semantics the shader's vertex inputs declare, so component order in a format doesn't need to match the shader's input order.
---
# enum VertSemantic

What a vertex component means! This is matched against the semantics
the shader's vertex inputs declare, so component order in a format
doesn't need to match the shader's input order.

## Enum Values

|  |  |
|--|--|
|Binormal|Binormal/bitangent direction for normal mapping.|
|Blendindices|Bone indices for skinning.|
|Blendweight|Bone weights for skinning.|
|Color|Vertex color.|
|None|Invalid semantic, this is not a valid value for a component.|
|Normal|Direction the vertex is facing.|
|Position|Vertex position, in model space coordinates.|
|Psize|Point size for point rendering.|
|Tangent|Tangent direction for normal mapping.|
|Texcoord|Texture coordinates.|

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

