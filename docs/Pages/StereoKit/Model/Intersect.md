---
layout: default
title: Model.Intersect
description: Checks the intersection point of this ray and a Model's visual nodes. This will skip any node that is not flagged as Solid, as well as any Mesh without collision data. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
---
# [Model]({{site.url}}/Pages/StereoKit/Model.html).Intersect

<div class='signature' markdown='1'>
```csharp
bool Intersect(Ray modelSpaceRay, Ray& modelSpaceAt)
```
Checks the intersection point of this ray and a Model's
visual nodes. This will skip any node that is not flagged as Solid,
as well as any Mesh without collision data. Ray must be in model
space, intersection point will be in model space too. You can use
the inverse of the mesh's world transform matrix to bring the ray
into model space, see the example in the docs!
</div>

|  |  |
|--|--|
|[Ray]({{site.url}}/Pages/StereoKit/Ray.html) modelSpaceRay|Ray must be in model space, the             intersection point will be in model space too. You can use the             inverse of the mesh's world transform matrix to bring the ray             into model space, see the example in the docs!|
|Ray& modelSpaceAt|The intersection point and surface             direction of the ray and the mesh, if an intersection occurs.             This is in model space, and must be transformed back into world             space later. Direction is not guaranteed to be normalized,             especially if your own model->world transform contains scale/skew             in it.|
|RETURNS: bool|True if an intersection occurs, false otherwise!|

<div class='signature' markdown='1'>
```csharp
bool Intersect(Ray modelSpaceRay, Cull cullFaces, Ray& modelSpaceAt)
```
Checks the intersection point of this ray and a Model's
visual nodes. This will skip any node that is not flagged as Solid,
as well as any Mesh without collision data. Ray must be in model
space, intersection point will be in model space too. You can use
the inverse of the mesh's world transform matrix to bring the ray
into model space, see the example in the docs!
</div>

|  |  |
|--|--|
|[Ray]({{site.url}}/Pages/StereoKit/Ray.html) modelSpaceRay|Ray must be in model space, the             intersection point will be in model space too. You can use the             inverse of the mesh's world transform matrix to bring the ray             into model space, see the example in the docs!|
|Ray& modelSpaceAt|The intersection point and surface             direction of the ray and the mesh, if an intersection occurs.             This is in model space, and must be transformed back into world             space later. Direction is not guaranteed to be normalized,             especially if your own model->world transform contains scale/skew             in it.|
|[Cull]({{site.url}}/Pages/StereoKit/Cull.html) cullFaces|How should intersection work with respect             to the direction the triangles are facing? Should we skip triangles             that are facing away from the ray, or don't skip anything?|
|RETURNS: bool|True if an intersection occurs, false otherwise!|




