---
layout: default
title: Material.DepthClamp
description: Should depth values be clamped to the near/far planes instead of being clipped? This defaults to false, meaning depth clipping is enabled. Setting this to true can be useful for shadow map rendering, where near/far clip planes are really critical, and out of clip objects are still useful to have.
---
# [Material]({{site.url}}/preview/Pages/StereoKit/Material.html).DepthClamp

<div class='signature' markdown='1'>
bool DepthClamp{ get set }
</div>

## Description
Should depth values be clamped to the near/far planes
instead of being clipped? This defaults to false, meaning depth
clipping is enabled. Setting this to true can be useful for
shadow map rendering, where near/far clip planes are really
critical, and out of clip objects are still useful to have.

