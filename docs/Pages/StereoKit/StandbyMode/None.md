---
layout: default
title: StandbyMode.None
description: The main thread will continue to execute, but with a very short sleep each frame. This allows the app to continue polling and processing, but without flooding the CPU with polling work while vsync is no longer the throttle. This will not disable sound.
---
# [StandbyMode]({{site.url}}/Pages/StereoKit/StandbyMode.html).None

<div class='signature' markdown='1'>
static [StandbyMode]({{site.url}}/Pages/StereoKit/StandbyMode.html) None
</div>

## Description
The main thread will continue to execute, but with a very short sleep
each frame. This allows the app to continue polling and processing, but
without flooding the CPU with polling work while vsync is no longer the
throttle. This will not disable sound.

