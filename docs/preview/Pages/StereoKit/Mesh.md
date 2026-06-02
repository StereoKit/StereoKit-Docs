---
layout: default
title: Mesh
description: A Mesh is a single collection of triangular faces with extra surface information to enhance rendering! StereoKit meshes are composed of a list of vertices, and a list of indices to connect the vertices into faces. Nothing more than that is stored here, so typically meshes are combined with Materials, or added to Models in order to draw them.  Mesh vertices are composed of a position, a normal (direction of the vert), a uv coordinate (for mapping a texture to the mesh's surface), and a 32 bit color containing red, green, blue, and alpha (transparency).  Mesh indices are stored as unsigned ints, so you can have a mesh with a fudgeton of verts! 4 billion or so .)
---
# class Mesh

A Mesh is a single collection of triangular faces with extra surface
information to enhance rendering! StereoKit meshes are composed of a
list of vertices, and a list of indices to connect the vertices into
faces. Nothing more than that is stored here, so typically meshes are
combined with Materials, or added to Models in order to draw them.

Mesh vertices are composed of a position, a normal (direction of the
vert), a uv coordinate (for mapping a texture to the mesh's surface),
and a 32 bit color containing red, green, blue, and alpha
(transparency).

Mesh indices are stored as unsigned ints, so you can have a mesh with
a fudgeton of verts! 4 billion or so :)

## Instance Fields and Properties

|  |  |
|--|--|
|[AssetState]({{site.url}}/preview/Pages/StereoKit/AssetState.html) [AssetState]({{site.url}}/preview/Pages/StereoKit/Mesh/AssetState.html)|This tells you the current state of the Mesh asset. A Mesh starts in the None state, transitions to LoadedMeta when bounds are available (async path), and Loaded once GPU upload completes.|
|[Bounds]({{site.url}}/preview/Pages/StereoKit/Bounds.html) [Bounds]({{site.url}}/preview/Pages/StereoKit/Mesh/Bounds.html)|This is a bounding box that encapsulates the Mesh! It's used for collision, visibility testing, UI layout, and probably other things. While it's normally calculated from the mesh vertices, you can also override this to suit your needs.|
|bool [HasSkin]({{site.url}}/preview/Pages/StereoKit/Mesh/HasSkin.html)|Indicates whether this Mesh has CPU skinning data attached. A Mesh gains skin data when SetSkin is called, or when it's loaded from a skinned glTF.|
|string [Id]({{site.url}}/preview/Pages/StereoKit/Mesh/Id.html)|Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!|
|int [IndCount]({{site.url}}/preview/Pages/StereoKit/Mesh/IndCount.html)|The number of indices stored in this Mesh! This is available to you regardless of whether or not KeepData is set.|
|bool [KeepData]({{site.url}}/preview/Pages/StereoKit/Mesh/KeepData.html)|Should StereoKit keep the mesh data on the CPU for later access, or collision detection? Defaults to true. If you set this to false before setting data, the data won't be stored. If you call this after setting data, that stored data will be freed! If you set this to true again later on, it will not contain data until it's set again.|
|int [VertCount]({{site.url}}/preview/Pages/StereoKit/Mesh/VertCount.html)|The number of vertices stored in this Mesh! This is available to you regardless of whether or not KeepData is set.|

## Instance Methods

|  |  |
|--|--|
|[Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh/Mesh.html)|Creates an empty Mesh asset. Use SetVerts and SetInds to add data to it!|
|[Copy]({{site.url}}/preview/Pages/StereoKit/Mesh/Copy.html)|Creates an independent duplicate of this Mesh. Vertices, indices, bounds, and (if present) skin data are copied; the new Mesh has its own GPU buffers and shares no state with the source.  This is useful when one source mesh is shared across N animated entities: UpdateSkin mutates the target mesh's vertex buffer in place, so each entity needs its own Mesh instance to deform independently.  The source Mesh must have KeepData set to true.|
|[Draw]({{site.url}}/preview/Pages/StereoKit/Mesh/Draw.html)|Adds a mesh to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.|
|[GetInds]({{site.url}}/preview/Pages/StereoKit/Mesh/GetInds.html)|This marshalls the Mesh's index data into an array. If KeepData is false, then the Mesh is _not_ storing indices on the CPU, and this information will _not_ be available.  Due to the way marshalling works, this is _not_ a cheap function!|
|[GetTriangle]({{site.url}}/preview/Pages/StereoKit/Mesh/GetTriangle.html)|Retrieves the vertices associated with a particular triangle on the Mesh.|
|[GetVerts]({{site.url}}/preview/Pages/StereoKit/Mesh/GetVerts.html)|This marshalls the Mesh's vertex data into an array. If KeepData is false, then the Mesh is _not_ storing verts on the CPU, and this information will _not_ be available.  Due to the way marshalling works, this is _not_ a cheap function!|
|[Intersect]({{site.url}}/preview/Pages/StereoKit/Mesh/Intersect.html)|Checks the intersection point of this ray and a Mesh with collision data stored on the CPU. A mesh without collision data will always return false. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!|
|[SetData]({{site.url}}/preview/Pages/StereoKit/Mesh/SetData.html)|Assigns the vertices and indices for this Mesh! This will create a vertex buffer and index buffer object on the graphics card. If you're calling this a second time, the buffers will be marked as dynamic and re-allocated. If you're calling this a third time, the buffer will only re-allocate if the buffer is too small, otherwise it just copies in the data!  Remember to set all the relevant values! Your material will often show black if the Normals or Colors are left at their default values.  Calling SetData is slightly more efficient than calling SetVerts and SetInds separately.|
|[SetInds]({{site.url}}/preview/Pages/StereoKit/Mesh/SetInds.html)|Assigns the face indices for this Mesh! Faces are always triangles, there are only ever three indices per face. This function will create a index buffer object on the graphics card. If you're calling this a second time, the buffer will be marked as dynamic and re-allocated. If you're calling this a third time, the buffer will only re-allocate if the buffer is too small, otherwise it just copies in the data!|
|[SetSkin]({{site.url}}/preview/Pages/StereoKit/Mesh/SetSkin.html)|Attaches CPU skinning data to this Mesh. Once skin data is set, call UpdateSkin each frame with the current bone palette to deform the vertex buffer.  KeepData must be true and vertex data must already be set before calling this — the deformation runs on the CPU and needs a copy of the rest-pose vertices to work from.  The bone palette passed to UpdateSkin is expected to be bone world transforms in the same coordinate system the resting transforms were authored in. The skinning matrix for bone `i` is computed as `bonePalette[i] * inverse(boneRestingTransforms[i])`.|
|[SetVerts]({{site.url}}/preview/Pages/StereoKit/Mesh/SetVerts.html)|Assigns the vertices for this Mesh! This will create a vertex buffer object on the graphics card. If you're calling this a second time, the buffer will be marked as dynamic and re-allocated. If you're calling this a third time, the buffer will only re-allocate if the buffer is too small, otherwise it just copies in the data!  Remember to set all the relevant values! Your material will often show black if the Normals or Colors are left at their default values.|
|[UpdateSkin]({{site.url}}/preview/Pages/StereoKit/Mesh/UpdateSkin.html)|Drives the per-frame CPU deformation for a skinned Mesh. SetSkin must have been called first. This walks every vertex, blends the bone transforms by weight, and re-uploads the deformed vertices to the GPU.  `bonePalette` holds the current world-space transform for each bone, in the same coordinate system the resting transforms passed to SetSkin were authored in. Its length must match the bone count supplied to SetSkin.  Because deformation mutates this Mesh's vertex buffer in place, two entities driven by different bone palettes need their own Mesh instance — use Copy on a shared source mesh to get per-instance deformation.|

## Static Fields and Properties

|  |  |
|--|--|
|[Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html) [Cube]({{site.url}}/preview/Pages/StereoKit/Mesh/Cube.html)|A cube with dimensions of (1,1,1), this is equivalent to Mesh.GenerateCube(Vec3.One).|
|[Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html) [Quad]({{site.url}}/preview/Pages/StereoKit/Mesh/Quad.html)|A default quad mesh, 2 triangles, 4 verts, from (-0.5,-0.5,0) to (0.5,0.5,0) and facing forward on the Z axis (0,0,-1). White vertex colors, and UVs from (1,1) at vertex (-0.5,-0.5,0) to (0,0) at vertex (0.5,0.5,0).|
|[Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html) [Sphere]({{site.url}}/preview/Pages/StereoKit/Mesh/Sphere.html)|A sphere mesh with a diameter of 1. This is equivalent to Mesh.GenerateSphere(1,4).|

## Static Methods

|  |  |
|--|--|
|[Find]({{site.url}}/preview/Pages/StereoKit/Mesh/Find.html)|Finds the Mesh with the matching id, and returns a reference to it. If no Mesh is found, it returns null.|
|[GenerateCircle]({{site.url}}/preview/Pages/StereoKit/Mesh/GenerateCircle.html)|Generates a circle on the XZ axis facing up that is pre-sized to the given diameter. UV coordinates correspond to a unit circle centered at 0.5, 0.5! That is, the right-most point on the circle has UV coordinates 1, 0.5 and the top-most point has UV coordinates 0.5, 1.  NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene.|
|[GenerateCube]({{site.url}}/preview/Pages/StereoKit/Mesh/GenerateCube.html)|Generates a flat-shaded cube mesh, pre-sized to the given dimensions. UV coordinates are projected flat on each face, 0,0 -> 1,1.  NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene. You may also be interested in using the pre-generated `Mesh.Cube` asset if it already meets your needs.|
|[GenerateCylinder]({{site.url}}/preview/Pages/StereoKit/Mesh/GenerateCylinder.html)|Generates a cylinder mesh, pre-sized to the given diameter and depth, UV coordinates are from a flattened top view right now. Additional development is needed for making better UVs for the edges.  NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene.|
|[GeneratePlane]({{site.url}}/preview/Pages/StereoKit/Mesh/GeneratePlane.html)|Generates a plane on the XZ axis facing up that is optionally subdivided, pre-sized to the given dimensions. UV coordinates start at 0,0 at the -X,-Z corner, and go to 1,1 at the +X,+Z corner!  NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene. You may also be interested in using the pre-generated `Mesh.Quad` asset if it already meets your needs.|
|[GenerateRoundedCube]({{site.url}}/preview/Pages/StereoKit/Mesh/GenerateRoundedCube.html)|Generates a cube mesh with rounded corners, pre-sized to the given dimensions. UV coordinates are 0,0 -> 1,1 on each face, meeting at the middle of the rounded corners.  NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene.|
|[GenerateSphere]({{site.url}}/preview/Pages/StereoKit/Mesh/GenerateSphere.html)|Generates a sphere mesh, pre-sized to the given diameter, created by sphereifying a subdivided cube! UV coordinates are taken from the initial unspherified cube.  NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene. You may also be interested in using the pre-generated `Mesh.Sphere` asset if it already meets your needs.|

## Examples

### Generating a Mesh and Model

![Procedural Geometry Demo]({{site.url}}/img/screenshots/ProceduralGeometry.jpg)

Here's a quick example of generating a mesh! You can store it in just a
Mesh, or you can attach it to a Model for easier rendering later on.
```csharp
// Do this in your initialization
Mesh  roundedCubeMesh  = Mesh.GenerateRoundedCube(Vec3.One * 0.4f, 0.05f);
Model roundedCubeModel = Model.FromMesh(roundedCubeMesh, Default.Material);
```

Drawing both a Mesh and a Model generated this way is reasonably simple,
here's a short example! For the Mesh, you'll need to create your own material,
we just loaded up the default Material here.
```csharp
// Call this code every Step

Matrix roundedCubeTransform = Matrix.T(0, 0, 0);
roundedCubeMesh.Draw(Default.Material, roundedCubeTransform);

roundedCubeTransform = Matrix.T(1, 0, 0);
roundedCubeModel.Draw(roundedCubeTransform);
```

