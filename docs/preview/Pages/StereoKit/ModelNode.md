---
layout: default
title: ModelNode
description: This class is a link to a node in a Model's internal hierarchy tree. It's composed of node information, and links to the directly adjacent tree nodes.
---
# class ModelNode

This class is a link to a node in a Model's internal
hierarchy tree. It's composed of node information, and links to
the directly adjacent tree nodes.

## Instance Fields and Properties

|  |  |
|--|--|
|[ModelNode]({{site.url}}/preview/Pages/StereoKit/ModelNode.html) [Child]({{site.url}}/preview/Pages/StereoKit/ModelNode/Child.html)|The first child node "below" on the hierarchy tree, or null if there are none. To see all children, get the Child and then iterate through its Siblings.|
|[ModelNodeInfoCollection]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection.html) [Info]({{site.url}}/preview/Pages/StereoKit/ModelNode/Info.html)|A collection of key/value pairs that add additional information to this node. If this comes from a GLTF model, this will be populated with the contents of the "extras" section of the node.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) [LocalTransform]({{site.url}}/preview/Pages/StereoKit/ModelNode/LocalTransform.html)|The transform of this node relative to the Parent node. Setting this transform will update the ModelTransform, as well as all Child nodes below this one.|
|[Material]({{site.url}}/preview/Pages/StereoKit/Material.html) [Material]({{site.url}}/preview/Pages/StereoKit/ModelNode/Material.html)|The Material associated with this node. May be null, or may also be re-used elsewhere. Getting this will block until the Model's metadata has finished loading.|
|[Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html) [Mesh]({{site.url}}/preview/Pages/StereoKit/ModelNode/Mesh.html)|The Mesh associated with this node. May be null, or may also be re-used elsewhere. Getting this will block until the Model has fully finished loading.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) [ModelTransform]({{site.url}}/preview/Pages/StereoKit/ModelNode/ModelTransform.html)|The transform of this node relative to the Model itself. This incorporates transforms from all parent nodes. Setting this transform will update the LocalTransform, as well as all Child nodes below this one.|
|string [Name]({{site.url}}/preview/Pages/StereoKit/ModelNode/Name.html)|This is the ASCII name that identifies this ModelNode. It is generally provided by the Model's file, but in the event no name (or null name) is provided, the name will default to "node"+index. Names are not required to be unique.|
|[ModelNode]({{site.url}}/preview/Pages/StereoKit/ModelNode.html) [Parent]({{site.url}}/preview/Pages/StereoKit/ModelNode/Parent.html)|The ModelNode above this one ("up") in the hierarchy tree, or null if this is a root node.|
|[ModelNode]({{site.url}}/preview/Pages/StereoKit/ModelNode.html) [Sibling]({{site.url}}/preview/Pages/StereoKit/ModelNode/Sibling.html)|The next ModelNode in the hierarchy, at the same level as this one. To the "right" on a hierarchy tree. Null if there are no more ModelNodes in the tree there.|
|bool [Solid]({{site.url}}/preview/Pages/StereoKit/ModelNode/Solid.html)|A flag that indicates the Mesh for this node will be used in ray intersection tests. This flag is ignored if no Mesh is attached.|
|bool [Visible]({{site.url}}/preview/Pages/StereoKit/ModelNode/Visible.html)|Is this node flagged as visible? By default, this is true for all nodes with visual elements attached. These nodes will not be drawn or skinned if you set this flag to false. If a ModelNode has no visual elements attached to it, it will always return false, and setting this value will have no effect.|

## Instance Methods

|  |  |
|--|--|
|[AddChild]({{site.url}}/preview/Pages/StereoKit/ModelNode/AddChild.html)|Adds a Child node below this node, at the end of the child chain!|
|[GetInfo]({{site.url}}/preview/Pages/StereoKit/ModelNode/GetInfo.html)|Get a Key/Value pair associated with this ModelNode. This is auto-populated from the GLTF extras, and you can also add your own items here as well.|
|[MoveChild]({{site.url}}/preview/Pages/StereoKit/ModelNode/MoveChild.html)|Moves this ModelNode class to the first Child of this node. If it cannot, then it remains the same.|
|[MoveParent]({{site.url}}/preview/Pages/StereoKit/ModelNode/MoveParent.html)|Moves this ModelNode class to the Parent up the hierarchy tree. If it cannot, then it remains the same.|
|[MoveSibling]({{site.url}}/preview/Pages/StereoKit/ModelNode/MoveSibling.html)|Advances this ModelNode class to the next Sibling in the hierarchy tree. If it cannot, then it remains the same.|
|[SetInfo]({{site.url}}/preview/Pages/StereoKit/ModelNode/SetInfo.html)|Set a Key/Value pair associated with this ModelNode. This is auto-populated from the GLTF extras, and you can also add your own items here as well.|
