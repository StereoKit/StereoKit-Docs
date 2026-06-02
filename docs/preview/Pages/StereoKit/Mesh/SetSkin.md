---
layout: default
title: Mesh.SetSkin
description: Attaches CPU skinning data to this Mesh. Once skin data is set, call UpdateSkin each frame with the current bone palette to deform the vertex buffer.  KeepData must be true and vertex data must already be set before calling this — the deformation runs on the CPU and needs a copy of the rest-pose vertices to work from.  The bone palette passed to UpdateSkin is expected to be bone world transforms in the same coordinate system the resting transforms were authored in. The skinning matrix for bone i is computed as bonePalette[i] * inverse(boneRestingTransforms[i]).
---
# [Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html).SetSkin

<div class='signature' markdown='1'>
```csharp
void SetSkin(UInt16[] boneIds, Vec4[] boneWeights, Matrix[] boneRestingTransforms)
```
Attaches CPU skinning data to this Mesh. Once skin
data is set, call UpdateSkin each frame with the current
bone palette to deform the vertex buffer.

KeepData must be true and vertex data must already be set
before calling this — the deformation runs on the CPU and
needs a copy of the rest-pose vertices to work from.

The bone palette passed to UpdateSkin is expected to be
bone world transforms in the same coordinate system the
resting transforms were authored in. The skinning matrix
for bone `i` is computed as
`bonePalette[i] * inverse(boneRestingTransforms[i])`.
</div>

|  |  |
|--|--|
|UInt16[] boneIds|Per-vertex bone indices, packed 4 per              vertex (so this array has length VertCount * 4). Each index              references a slot in the bone palette and resting transforms.|
|Vec4[] boneWeights|Per-vertex bone weights, one Vec4              per vertex (length must equal VertCount). The four              components correspond to the four bone ids for that vertex.              Weights should sum to ~1 for a stable result.|
|Matrix[] boneRestingTransforms|Bind-pose transform for              each bone, expressed in the mesh's model space. StereoKit              inverts these internally to produce the inverse-bind              matrices used by the skinning math.|




