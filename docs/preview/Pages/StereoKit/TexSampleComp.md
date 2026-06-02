---
layout: default
title: TexSampleComp
description: When sampling from a texture with comparison enabled, the sampler compares the sampled texel value against a reference value and returns a 0 or 1 based on the result. This is primarily useful for shadow mapping techniques, where a depth texture is sampled to determine if a surface is in shadow.
---
# enum TexSampleComp

When sampling from a texture with comparison enabled, the sampler
compares the sampled texel value against a reference value and returns
a 0 or 1 based on the result. This is primarily useful for shadow
mapping techniques, where a depth texture is sampled to determine if a
surface is in shadow.

## Enum Values

|  |  |
|--|--|
|Always|Always returns 1, regardless of values.|
|Equal|Returns 1 if the reference value is equal to the sampled texel value.|
|Greater|Returns 1 if the reference value is greater than the sampled texel value.|
|GreaterOrEq|Returns 1 if the reference value is greater than or equal to the sampled texel value.|
|Less|Returns 1 if the reference value is less than the sampled texel value.|
|LessOrEq|Returns 1 if the reference value is less than or equal to the sampled texel value.|
|Never|Always returns 0, regardless of values.|
|None|No comparison is performed, the texture is sampled normally. This is the default behavior for most textures.|
|NotEqual|Returns 1 if the reference value is not equal to the sampled texel value.|
