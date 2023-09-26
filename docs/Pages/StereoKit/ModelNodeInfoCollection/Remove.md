---
layout: default
title: ModelNodeInfoCollection.Remove
description: Removes a specific key/value pair from the collection, if present.
---
# [ModelNodeInfoCollection]({{site.url}}/Pages/StereoKit/ModelNodeInfoCollection.html).Remove

<div class='signature' markdown='1'>
```csharp
bool Remove(string key)
```
Removes a specific key/value pair from the collection, if
present.
</div>

|  |  |
|--|--|
|string key|Identifying key.|
|RETURNS: bool|True if found and removed, false if not.|





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

