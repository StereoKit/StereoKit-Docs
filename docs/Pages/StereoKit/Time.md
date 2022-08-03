---
layout: default
title: Time
description: This class contains time information for the current session and frame!
---
# static class Time

This class contains time information for the current session and frame!

## Static Fields and Properties

|  |  |
|--|--|
|double [Elapsed]({{site.url}}/Pages/StereoKit/Time/Elapsed.html)|How much time elapsed during the last frame? 64 bit time precision.|
|float [Elapsedf]({{site.url}}/Pages/StereoKit/Time/Elapsedf.html)|How much time elapsed during the last frame? 32 bit time precision.|
|double [ElapsedUnscaled]({{site.url}}/Pages/StereoKit/Time/ElapsedUnscaled.html)|How much time elapsed during the last frame? 64 bit time precision. This version is unaffected by the Time.Scale value!|
|float [ElapsedUnscaledf]({{site.url}}/Pages/StereoKit/Time/ElapsedUnscaledf.html)|How much time elapsed during the last frame? 32 bit time precision. This version is unaffected by the Time.Scale value!|
|double [Scale]({{site.url}}/Pages/StereoKit/Time/Scale.html)|Time is scaled by this value! Want time to pass slower? Set it to 0.5! Faster? Try 2!|
|double [Total]({{site.url}}/Pages/StereoKit/Time/Total.html)|How much time has elapsed since StereoKit was initialized? 64 bit time precision.|
|float [Totalf]({{site.url}}/Pages/StereoKit/Time/Totalf.html)|How much time has elapsed since StereoKit was initialized? 32 bit time precision.|
|double [TotalUnscaled]({{site.url}}/Pages/StereoKit/Time/TotalUnscaled.html)|How much time has elapsed since StereoKit was initialized? 64 bit time precision. This version is unaffected by the Time.Scale value!|
|float [TotalUnscaledf]({{site.url}}/Pages/StereoKit/Time/TotalUnscaledf.html)|How much time has elapsed since StereoKit was initialized? 32 bit time precision. This version is unaffected by the Time.Scale value!|

## Static Methods

|  |  |
|--|--|
|[SetTime]({{site.url}}/Pages/StereoKit/Time/SetTime.html)|This allows you to override the application time! The application will progress from this time using the current timescale.|
