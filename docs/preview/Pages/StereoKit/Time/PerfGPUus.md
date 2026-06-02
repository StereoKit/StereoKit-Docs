---
layout: default
title: Time.PerfGPUus
description: Microseconds the GPU spent executing rendering commands for the most recently completed frame. Measured via hardware timestamp queries at the top and bottom of the Vulkan pipeline, so this reflects actual GPU execution time independent of CPU pacing or vsync. Useful for identifying GPU-bound scenarios like expensive shaders or overdraw. Returns 0 if timing data is not yet available (first few frames).
---
# [Time]({{site.url}}/preview/Pages/StereoKit/Time.html).PerfGPUus

<div class='signature' markdown='1'>
static UInt64 PerfGPUus{ get }
</div>

## Description
Microseconds the GPU spent executing rendering
commands for the most recently completed frame. Measured via
hardware timestamp queries at the top and bottom of the
Vulkan pipeline, so this reflects actual GPU execution time
independent of CPU pacing or vsync. Useful for identifying
GPU-bound scenarios like expensive shaders or overdraw.
Returns 0 if timing data is not yet available (first few
frames).

