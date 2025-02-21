---
layout: default
title: Renderer.ViewportScaling
description: This allows you to trivially scale down the area of the swapchain that StereoKit renders to! This can be used to boost performance in situations where full resolution is not needed, or to reduce GPU time. This value is locked to the 0-1 range.
---
# [Renderer]({{site.url}}/Pages/StereoKit/Renderer.html).ViewportScaling

<div class='signature' markdown='1'>
static float ViewportScaling{ get set }
</div>

## Description
This allows you to trivially scale down the area of the
swapchain that StereoKit renders to! This can be used to boost
performance in situations where full resolution is not needed, or
to reduce GPU time. This value is locked to the 0-1 range.

