---
layout: default
title: ModelNode.Material
description: The Model associated with this node. May be null, or may also be re-used elsewhere.
---
# [ModelNode]({{site.url}}/Pages/StereoKit/ModelNode.html).Material

<div class='signature' markdown='1'>
[Material]({{site.url}}/Pages/StereoKit/Material.html) Material{ get set }
</div>

## Description
The Model associated with this node. May be null, or may
also be re-used elsewhere.


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

