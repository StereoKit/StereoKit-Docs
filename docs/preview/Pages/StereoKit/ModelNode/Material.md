---
layout: default
title: ModelNode.Material
description: The Material associated with this node. May be null, or may also be re-used elsewhere. Getting this will block until the Model's metadata has finished loading.
---
# [ModelNode]({{site.url}}/preview/Pages/StereoKit/ModelNode.html).Material

<div class='signature' markdown='1'>
[Material]({{site.url}}/preview/Pages/StereoKit/Material.html) Material{ get set }
</div>

## Description
The Material associated with this node. May be null, or
may also be re-used elsewhere. Getting this will block until
the Model's metadata has finished loading.


## Examples

```csharp
foreach (ModelNode node in model.Nodes)
{
	// ModelNode.Material will often returned a shared resource, so
	// copy it if you don't wish to change all assets that share it.
	Material mat = node.Material.Copy();
	mat[MatParamName.ColorTint] = Color.HSV(0, 1, 1);
	node.Material = mat;
}
```

