---
layout: default
title: Time.PerfCPUus
description: Microseconds of CPU work for the renderer during the most recently completed frame. This measures wall-clock time from command buffer acquisition through queue submission, excluding any time spent waiting on GPU fences or vsync. This is useful for identifying CPU-side rendering bottlenecks such as draw call overhead or resource uploads. Returns 0 if timing data is not yet available (first few frames).
---
# [Time]({{site.url}}/preview/Pages/StereoKit/Time.html).PerfCPUus

<div class='signature' markdown='1'>
static UInt64 PerfCPUus{ get }
</div>

## Description
Microseconds of CPU work for the renderer during the
most recently completed frame. This measures wall-clock time
from command buffer acquisition through queue submission,
excluding any time spent waiting on GPU fences or vsync. This
is useful for identifying CPU-side rendering bottlenecks such
as draw call overhead or resource uploads. Returns 0 if timing
data is not yet available (first few frames).

