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
|double [Elapsed]({{site.url}}/Pages/StereoKit/Time/Elapsed.html)|(Deprecated, use Time.Step) How many seconds have elapsed since the last frame? 64 bit time precision, calculated at the start of the frame.|
|float [Elapsedf]({{site.url}}/Pages/StereoKit/Time/Elapsedf.html)|(Deprecated, use Time.Stepf) How many seconds have elapsed since the last frame? 32 bit time precision, calculated at the start of the frame.|
|double [ElapsedUnscaled]({{site.url}}/Pages/StereoKit/Time/ElapsedUnscaled.html)|(Deprecated, use Time.StepUnscaled) How many seconds have elapsed during the last frame? 64 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|
|float [ElapsedUnscaledf]({{site.url}}/Pages/StereoKit/Time/ElapsedUnscaledf.html)|(Deprecated, use Time.StepUnscaledf) How many seconds have elapsed during the last frame? 32 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|
|UInt64 [Frame]({{site.url}}/Pages/StereoKit/Time/Frame.html)|The number of frames/steps since the app started.|
|double [Scale]({{site.url}}/Pages/StereoKit/Time/Scale.html)|Time is scaled by this value! Want time to pass slower? Set it to 0.5! Faster? Try 2!|
|double [Step]({{site.url}}/Pages/StereoKit/Time/Step.html)|How many seconds have elapsed since the last frame? 64 bit time precision, calculated at the start of the frame.|
|float [Stepf]({{site.url}}/Pages/StereoKit/Time/Stepf.html)|How many seconds have elapsed since the last frame? 32 bit time precision, calculated at the start of the frame.|
|double [StepUnscaled]({{site.url}}/Pages/StereoKit/Time/StepUnscaled.html)|How many seconds have elapsed since the last frame? 64 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|
|float [StepUnscaledf]({{site.url}}/Pages/StereoKit/Time/StepUnscaledf.html)|How many seconds have elapsed since the last frame? 32 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|
|double [Total]({{site.url}}/Pages/StereoKit/Time/Total.html)|How many seconds have elapsed since StereoKit was initialized? 64 bit time precision, calculated at the start of the frame.|
|float [Totalf]({{site.url}}/Pages/StereoKit/Time/Totalf.html)|How many seconds have elapsed since StereoKit was initialized? 32 bit time precision, calculated at the start of the frame.|
|double [TotalUnscaled]({{site.url}}/Pages/StereoKit/Time/TotalUnscaled.html)|How many seconds have elapsed since StereoKit was initialized? 64 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|
|float [TotalUnscaledf]({{site.url}}/Pages/StereoKit/Time/TotalUnscaledf.html)|How many seconds have elapsed since StereoKit was initialized? 32 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!|

## Static Methods

|  |  |
|--|--|
|[SetTime]({{site.url}}/Pages/StereoKit/Time/SetTime.html)|This allows you to override the application time! The application will progress from this time using the current timescale.|
