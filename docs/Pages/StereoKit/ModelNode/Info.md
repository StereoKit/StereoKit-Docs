---
layout: default
title: ModelNode.Info
description: A collection of key/value pairs that add additional information to this node. If this comes from a GLTF model, this will be populated with the contents of the "extras" section of the node.
---
# [ModelNode]({{site.url}}/Pages/StereoKit/ModelNode.html).Info

<div class='signature' markdown='1'>
[ModelNodeInfoCollection]({{site.url}}/Pages/StereoKit/ModelNodeInfoCollection.html) Info{ get }
</div>

## Description
A collection of key/value pairs that add additional
information to this node. If this comes from a GLTF model, this
will be populated with the contents of the "extras" section of the
node.


## Examples

### Modifying ModelNode.Info
While ModelNode.Info is automatically populated from a GLTF's
"extras", you can also embed or modify with your own data as well.
```csharp
ModelNode modelNode = model.AddNode("empty", Matrix.Identity);
modelNode.Info.Add("a", "1");
modelNode.Info.Add("b", "2");
modelNode.Info.Add("c", "3");
modelNode.Info.Add("c", "10"); // overwrite 'c's value
modelNode.Info.Remove("b");
```
### Iterating through ModelNode.Info
You can choose to iterate through different parts of ModelNode.Info
using foreach loops.
```csharp
foreach (ModelNode node in model.Nodes)
{
	foreach (KeyValuePair<string, string> kvp in node.Info)
		Log.Info($"{kvp.Key} - {kvp.Value}");

	foreach (string key in node.Info.Keys)
		Log.Info($"key: {key} - {node.Info[key]}");

	foreach (string val in node.Info.Values)
		Log.Info($"value: {val}");
}
```

