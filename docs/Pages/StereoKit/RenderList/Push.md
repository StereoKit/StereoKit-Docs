---
layout: default
title: RenderList.Push
description: All draw calls that don't specify a render list will get submitted to the active RenderList at the top of the stack. By default, that's RenderList.Primary, but you can push your own list onto the stack here to capture draw calls, like those done in the UI.
---
# [RenderList]({{site.url}}/Pages/StereoKit/RenderList.html).Push

<div class='signature' markdown='1'>
```csharp
static void Push(RenderList list)
```
All draw calls that don't specify a render list will get
submitted to the active RenderList at the top of the stack. By
default, that's RenderList.Primary, but you can push your own list
onto the stack here to capture draw calls, like those done in the
UI.
</div>

|  |  |
|--|--|
|[RenderList]({{site.url}}/Pages/StereoKit/RenderList.html) list|The list that should go on top of the stack as             the active RenderList.|




