---
layout: default
title: ModelNodeInfoCollection.Values
description: An enumerable for the values in this collection.
---
# [ModelNodeInfoCollection]({{site.url}}/Pages/StereoKit/ModelNodeInfoCollection.html).Values

<div class='signature' markdown='1'>
IEnumerable`1 Values{ get }
</div>

## Description
An enumerable for the values in this collection.


## Examples

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

