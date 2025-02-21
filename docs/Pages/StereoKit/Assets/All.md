---
layout: default
title: Assets.All
description: This is an enumeration of all asset object loaded by StereoKit at the current moment.
---
# [Assets]({{site.url}}/Pages/StereoKit/Assets.html).All

<div class='signature' markdown='1'>
static IEnumerable`1 All{ get }
</div>

## Description
This is an enumeration of all asset object loaded by
StereoKit at the current moment.


## Examples

### Enumerating all Assets
With Assets.All, you can take a peek at all the currently loaded
Assets! Here's a quick example of iterating through all assets and
dumping a quick summary to the log.
```csharp
foreach (var asset in Assets.All)
	Log.Info($"{asset.GetType().Name,-10} - {asset.Id}");
```

