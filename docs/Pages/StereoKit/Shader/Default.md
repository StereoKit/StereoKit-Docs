---
layout: default
title: Shader.Default
description: This is a fast, general purpose shader. It uses a texture for 'diffuse', a 'color' property for tinting the material, and a 'tex_scale' for scaling the UV coordinates. For lighting, it just uses a lookup from the current cubemap.
---
# [Shader]({{site.url}}/Pages/StereoKit/Shader.html).Default

<div class='signature' markdown='1'>
static [Shader]({{site.url}}/Pages/StereoKit/Shader.html) Default{ get }
</div>

## Description
This is a fast, general purpose shader. It uses a
texture for 'diffuse', a 'color' property for tinting the
material, and a 'tex_scale' for scaling the UV coordinates. For
lighting, it just uses a lookup from the current cubemap.

