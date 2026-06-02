---
layout: default
title: RenderListRefs.Tracked
description: The list calls addref on each item's mesh/material when added, and releaseref when cleared. This keeps assets alive for as long as the list holds them, and is the safe default.
---
# [RenderListRefs]({{site.url}}/preview/Pages/StereoKit/RenderListRefs.html).Tracked

<div class='signature' markdown='1'>
static [RenderListRefs]({{site.url}}/preview/Pages/StereoKit/RenderListRefs.html) Tracked
</div>

## Description
The list calls addref on each item's mesh/material when added, and
releaseref when cleared. This keeps assets alive for as long as the
list holds them, and is the safe default.

