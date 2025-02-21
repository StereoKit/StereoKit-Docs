---
layout: default
title: Tex.ZBuffer
description: This allows you to attach or retreive a z/depth buffer from a rendertarget texture. This texture _must_ be a rendertarget to set this, and the zbuffer texture _must_ be a depth format (or null). For no-rendertarget textures, this will always be null.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).ZBuffer

<div class='signature' markdown='1'>
[Tex]({{site.url}}/Pages/StereoKit/Tex.html) ZBuffer{ get set }
</div>

## Description
This allows you to attach or retreive a z/depth buffer
from a rendertarget texture. This texture _must_ be a rendertarget
to set this, and the zbuffer texture _must_ be a depth format (or
null). For no-rendertarget textures, this will always be null.

