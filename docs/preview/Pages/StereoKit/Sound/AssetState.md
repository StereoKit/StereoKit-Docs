---
layout: default
title: Sound.AssetState
description: Sounds loaded from file decode asynchronously - this tells you where that's at! Playing is safe at any point. a Play while still Loading is held until the data lands, then catches up as if it had started on time. Negative states mean the load failed, and any held plays die quietly.
---
# [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html).AssetState

<div class='signature' markdown='1'>
[AssetState]({{site.url}}/preview/Pages/StereoKit/AssetState.html) AssetState{ get }
</div>

## Description
Sounds loaded from file decode asynchronously - this
tells you where that's at! Playing is safe at any point: a Play
while still Loading is held until the data lands, then catches
up as if it had started on time. Negative states mean the load
failed, and any held plays die quietly.

