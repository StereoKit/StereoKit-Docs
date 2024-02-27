---
layout: default
title: Device.Runtime
description: This is the name of the OpenXR runtime that powers the current device! This can help you determine which implementation quirks to expect based on the codebase used. On the simulator, this will be "Simulator", and in other non-XR modes this will be "None".
---
# [Device]({{site.url}}/Pages/StereoKit/Device.html).Runtime

<div class='signature' markdown='1'>
static string Runtime{ get }
</div>

## Description
This is the name of the OpenXR runtime that powers the
current device! This can help you determine which implementation
quirks to expect based on the codebase used. On the simulator, this
will be "Simulator", and in other non-XR modes this will be "None".

