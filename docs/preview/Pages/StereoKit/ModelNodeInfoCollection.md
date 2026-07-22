---
layout: default
title: ModelNodeInfoCollection
description: A collection of key/value string pairs adding additional information to the ModelNode.
---
# struct ModelNodeInfoCollection

A collection of key/value string pairs adding additional
information to the ModelNode.

## Instance Fields and Properties

|  |  |
|--|--|
|int [Count]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/Count.html)|The number of key/value pairs in the collection.|
|IEnumerable`1 [Keys]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/Keys.html)|An enumerable for the keys in this collection.|
|IEnumerable`1 [Values]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/Values.html)|An enumerable for the values in this collection.|

## Instance Methods

|  |  |
|--|--|
|[Add]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/Add.html)|Adds a key/value pair, or replaces an existing key/value pair.|
|[Clear]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/Clear.html)|Clears all key/value pairs from the collection.|
|[Contains]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/Contains.html)|Finds if the key is present in the collection with a non-null value.|
|[Get]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/Get.html)|Finds the value associated with the given key, returns null if the key is not present.|
|[GetEnumerator]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/GetEnumerator.html)|The enumerator for the collection's KeyValuePairs. This is a concrete struct enumerator so that `foreach` over the collection stays allocation-free (aside from the key/value strings themselves).|
|[Remove]({{site.url}}/preview/Pages/StereoKit/ModelNodeInfoCollection/Remove.html)|Removes a specific key/value pair from the collection, if present.|
