---
layout: default
title: RenderList.RenderList
description: Creates a new empty RenderList.
---
# [RenderList]({{site.url}}/preview/Pages/StereoKit/RenderList.html).RenderList

<div class='signature' markdown='1'>
```csharp
void RenderList(RenderListRefs refs)
```
Creates a new empty RenderList.
</div>

|  |  |
|--|--|
|[RenderListRefs]({{site.url}}/preview/Pages/StereoKit/RenderListRefs.html) refs|Controls whether the list tracks asset references for the Meshes and Materials added to it. The default, `Tracked`, is safe across frames. `None` skips the addref/release pair on each add and clear, but the caller must ensure the list is cleared before any referenced asset could be released.|




