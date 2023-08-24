---
layout: default
title: Tex.GetNativeSurface
description: This will return the texture's native resource for use with external libraries. For D3D, this will be an ID3D11Texture2D*, and for GL, this will be a uint32_t from a glGenTexture call, coerced into the IntPtr. This call will block execution until the texture is loaded, if it is not already.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).GetNativeSurface

<div class='signature' markdown='1'>
```csharp
IntPtr GetNativeSurface()
```
This will return the texture's native resource for use
with external libraries. For D3D, this will be an ID3D11Texture2D*,
and for GL, this will be a uint32_t from a glGenTexture call,
coerced into the IntPtr. This call will block execution until the
texture is loaded, if it is not already.
</div>

|  |  |
|--|--|
|RETURNS: IntPtr|For D3D, this will be an ID3D11Texture2D*, and for GL, this will be a uint32_t from a glGenTexture call, coerced into the IntPtr.|




