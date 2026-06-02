---
layout: default
title: Time
description: This class contains time information for the current session and frame!
---
# static class Time

This class contains time information for the current session
and frame!

## Static Fields and Properties

|  |  |
|--|--|
|UInt64 [Frame]({{site.url}}/preview/Pages/StereoKit/Time/Frame.html)|The number of frames/steps since the app started.|
|UInt64 [PerfCPUus]({{site.url}}/preview/Pages/StereoKit/Time/PerfCPUus.html)|Microseconds of CPU work for the renderer during the most recently completed frame. This measures wall-clock time from command buffer acquisition through queue submission, excluding any time spent waiting on GPU fences or vsync. This is useful for identifying CPU-side rendering bottlenecks such as draw call overhead or resource uploads. Returns 0 if timing data is not yet available (first few frames).|
|UInt64 [PerfGPUus]({{site.url}}/preview/Pages/StereoKit/Time/PerfGPUus.html)|Microseconds the GPU spent executing rendering commands for the most recently completed frame. Measured via hardware timestamp queries at the top and bottom of the Vulkan pipeline, so this reflects actual GPU execution time independent of CPU pacing or vsync. Useful for identifying GPU-bound scenarios like expensive shaders or overdraw. Returns 0 if timing data is not yet available (first few frames).|
|double [Scale]({{site.url}}/preview/Pages/StereoKit/Time/Scale.html)|Time is scaled by this value! Want time to pass slower? Set it to 0.5! Faster? Try 2!|
|double [Step]({{site.url}}/preview/Pages/StereoKit/Time/Step.html)|How many seconds have elapsed since the last frame? 64 bit time precision, calculated at the start of the frame.|
|float [Stepf]({{site.url}}/preview/Pages/StereoKit/Time/Stepf.html)|How many seconds have elapsed since the last frame? 32 bit time precision, calculated at the start of the frame.|
|double [StepUnscaled]({{site.url}}/preview/Pages/StereoKit/Time/StepUnscaled.html)|How many seconds have elapsed since the last frame? 64 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|
|float [StepUnscaledf]({{site.url}}/preview/Pages/StereoKit/Time/StepUnscaledf.html)|How many seconds have elapsed since the last frame? 32 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|
|double [Total]({{site.url}}/preview/Pages/StereoKit/Time/Total.html)|How many seconds have elapsed since StereoKit was initialized? 64 bit time precision, calculated at the start of the frame.|
|float [Totalf]({{site.url}}/preview/Pages/StereoKit/Time/Totalf.html)|How many seconds have elapsed since StereoKit was initialized? 32 bit time precision, calculated at the start of the frame.|
|double [TotalUnscaled]({{site.url}}/preview/Pages/StereoKit/Time/TotalUnscaled.html)|How many seconds have elapsed since StereoKit was initialized? 64 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|
|float [TotalUnscaledf]({{site.url}}/preview/Pages/StereoKit/Time/TotalUnscaledf.html)|How many seconds have elapsed since StereoKit was initialized? 32 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|

## Static Methods

|  |  |
|--|--|
|[SetTime]({{site.url}}/preview/Pages/StereoKit/Time/SetTime.html)|This allows you to override the application time! The application will progress from this time using the current timescale.|
