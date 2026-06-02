---
layout: default
title: Tex.SampleComp
description: When sampling from a texture with comparison enabled, the sampler compares the sampled texel value against a reference value and returns a 0 or 1 based on the result. This is primarily useful for shadow mapping techniques, where a depth texture is sampled to determine if a surface is in shadow.
---
# [Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html).SampleComp

<div class='signature' markdown='1'>
[TexSampleComp]({{site.url}}/preview/Pages/StereoKit/TexSampleComp.html) SampleComp{ get set }
</div>

## Description
When sampling from a texture with comparison enabled, the
sampler compares the sampled texel value against a reference value
and returns a 0 or 1 based on the result. This is primarily useful
for shadow mapping techniques, where a depth texture is sampled to
determine if a surface is in shadow.

