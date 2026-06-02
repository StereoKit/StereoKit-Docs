---
layout: default
title: Compute.DispatchNow
description: Run this compute dispatch synchronously, right now, on the calling thread. Use this for ad-hoc work that doesn't belong in the per-frame render pipeline (debugging, one-shot tasks, immediate readbacks). For compute work that feeds into later render passes within the same frame, prefer Dispatch, which queues into the pipeline and lets sk_renderer handle ordering and barriers automatically.
---
# [Compute]({{site.url}}/preview/Pages/StereoKit/Compute.html).DispatchNow

<div class='signature' markdown='1'>
```csharp
void DispatchNow(uint groupCountX, uint groupCountY, uint groupCountZ)
```
Run this compute dispatch synchronously, right now,
on the calling thread. Use this for ad-hoc work that doesn't
belong in the per-frame render pipeline (debugging, one-shot
tasks, immediate readbacks). For compute work that feeds into
later render passes within the same frame, prefer Dispatch,
which queues into the pipeline and lets sk_renderer handle
ordering and barriers automatically.
</div>

|  |  |
|--|--|
|uint groupCountX|Thread groups in X.|
|uint groupCountY|Thread groups in Y.|
|uint groupCountZ|Thread groups in Z.|




