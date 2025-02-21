---
layout: default
title: StandbyMode.Slow
description: The main thread will continue to execute, but with 100ms sleeps each frame. This allows the app to continue polling and processing, but reduces power consumption by throttling a bit. This will not disable sound. In the Simulator, this will behave as Slow.
---
# [StandbyMode]({{site.url}}/Pages/StereoKit/StandbyMode.html).Slow

<div class='signature' markdown='1'>
static [StandbyMode]({{site.url}}/Pages/StereoKit/StandbyMode.html) Slow
</div>

## Description
The main thread will continue to execute, but with 100ms sleeps each
frame. This allows the app to continue polling and processing, but
reduces power consumption by throttling a bit. This will not disable
sound. In the Simulator, this will behave as Slow.

