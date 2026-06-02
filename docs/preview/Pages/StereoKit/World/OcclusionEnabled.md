---
layout: default
title: World.OcclusionEnabled
description: Off by default. This tells StereoKit to load up and display an occlusion surface that allows the real world to occlude the application's digital content! Most systems may allow you to customize the visual appearance of this occlusion surface via the World.OcclusionMaterial. Check SK.System.worldOcclusionPresent to see if occlusion can be enabled. This will reset itself to false if occlusion isn't possible. Loading occlusion data is asynchronous, so occlusion may not occur immediately after setting this flag.
---
# [World]({{site.url}}/preview/Pages/StereoKit/World.html).OcclusionEnabled

<div class='signature' markdown='1'>
static bool OcclusionEnabled{ get set }
</div>

## Description
Off by default. This tells StereoKit to load up and
display an occlusion surface that allows the real world to
occlude the application's digital content! Most systems may allow
you to customize the visual appearance of this occlusion surface
via the World.OcclusionMaterial.
Check SK.System.worldOcclusionPresent to see if occlusion can be
enabled. This will reset itself to false if occlusion isn't
possible. Loading occlusion data is asynchronous, so occlusion
may not occur immediately after setting this flag.

