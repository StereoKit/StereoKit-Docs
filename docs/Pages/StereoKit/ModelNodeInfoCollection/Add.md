---
layout: default
title: ModelNodeInfoCollection.Add
description: Adds a key/value pair, or replaces an existing key/value pair.
---
# [ModelNodeInfoCollection]({{site.url}}/Pages/StereoKit/ModelNodeInfoCollection.html).Add

<div class='signature' markdown='1'>
```csharp
void Add(string key, string val)
```
Adds a key/value pair, or replaces an existing key/value
pair.
</div>

|  |  |
|--|--|
|string key|Identifying key.|
|string val|Value to associate with the key.|





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

