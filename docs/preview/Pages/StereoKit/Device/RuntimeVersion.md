---
layout: default
title: Device.RuntimeVersion
description: This is the multi-part version of the active OpenXR runtime packed into a 64-bit integer. The major version number is a 16-bit integer packed into bits 63-48. The minor version number is a 16-bit integer packed into bits 47-32. The patch version number is a 32-bit integer packed into bits 31-0. On the simulator and other non-XR modes, this will be 0.
---
# [Device]({{site.url}}/preview/Pages/StereoKit/Device.html).RuntimeVersion

<div class='signature' markdown='1'>
static UInt64 RuntimeVersion{ get }
</div>

## Description
This is the multi-part version of the active OpenXR runtime
packed into a 64-bit integer. The major version number is a 16-bit
integer packed into bits 63-48. The minor version number is a 16-bit
integer packed into bits 47-32. The patch version number is a 32-bit
integer packed into bits 31-0. On the simulator and other non-XR modes,
this will be 0.

