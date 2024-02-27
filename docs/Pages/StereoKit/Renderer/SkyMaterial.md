---
layout: default
title: Renderer.SkyMaterial
description: This is the Material that StereoKit is currently using to draw the skybox! It needs a special shader that's tuned for a full-screen quad. If you just want to change the skybox image, try setting Renderer.SkyTex instead.  This value will never be null! If you try setting this to null, it will assign SK's built-in default sky material. If you want to turn off the skybox, see Renderer.EnableSky instead.  Recommended Material settings would be. - DepthWrite. false - DepthTest. LessOrEq - QueueOffset. 100
---
# [Renderer]({{site.url}}/Pages/StereoKit/Renderer.html).SkyMaterial

<div class='signature' markdown='1'>
static [Material]({{site.url}}/Pages/StereoKit/Material.html) SkyMaterial{ get set }
</div>

## Description
This is the Material that StereoKit is currently using to
draw the skybox! It needs a special shader that's tuned for a
full-screen quad. If you just want to change the skybox image, try
setting `Renderer.SkyTex` instead.

This value will never be null! If you try setting this to null, it
will assign SK's built-in default sky material. If you want to turn
off the skybox, see `Renderer.EnableSky` instead.

Recommended Material settings would be:
- DepthWrite: false
- DepthTest: LessOrEq
- QueueOffset: 100

