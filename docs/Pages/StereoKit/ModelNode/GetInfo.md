---
layout: default
title: ModelNode.GetInfo
description: Get a Key/Value pair associated with this ModelNode. This is auto-populated from the GLTF extras, and you can also add your own items here as well.
---
# [ModelNode]({{site.url}}/Pages/StereoKit/ModelNode.html).GetInfo

<div class='signature' markdown='1'>
```csharp
string GetInfo(string key)
```
Get a Key/Value pair associated with this ModelNode. This
is auto-populated from the GLTF extras, and you can also add your
own items here as well.
</div>

|  |  |
|--|--|
|string key|The dictionary key to look up.|
|RETURNS: string|Null if this key does not exist, or a string with data otherwise.|




