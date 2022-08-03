---
layout: default
title: Material.UnlitClip
description: The default unlit material with alpha clipping! This is used by StereoKit for unlit content with transparency, where completely transparent pixels are discarded. This means less alpha blending, and fewer visible alpha blending issues! In particular, this is how Sprites are drawn. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default unlit clipped behavior, here's where you do it!
---
# [Material]({{site.url}}/Pages/StereoKit/Material.html).UnlitClip

<div class='signature' markdown='1'>
static [Material]({{site.url}}/Pages/StereoKit/Material.html) UnlitClip{ get }
</div>

## Description
The default unlit material with alpha clipping! This is
used by StereoKit for unlit content with transparency, where
completely transparent pixels are discarded. This means less
alpha blending, and fewer visible alpha blending issues! In
particular, this is how Sprites are drawn. Its shader may change
based on system performance characteristics, so it can be great
to copy this one when creating your own materials! Or if you want
to override StereoKit's default unlit clipped behavior, here's
where you do it!

