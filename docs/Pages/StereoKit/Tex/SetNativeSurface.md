---
layout: default
title: Tex.SetNativeSurface
description: This function is dependent on the graphics backend! It will take a texture resource for the current graphics backend (D3D or GL) and wrap it in a StereoKit texture for use within StereoKit. This is a bit of an advanced feature.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).SetNativeSurface

<div class='signature' markdown='1'>
```csharp
void SetNativeSurface(IntPtr nativeTexture, TexType type, Int64 native_fmt, int width, int height, int surface_count, bool owned)
```
This function is dependent on the graphics backend! It
will take a texture resource for the current graphics backend (D3D
or GL) and wrap it in a StereoKit texture for use within StereoKit.
This is a bit of an advanced feature.
</div>

|  |  |
|--|--|
|IntPtr nativeTexture|For D3D, this should be an             ID3D11Texture2D*, and for GL, this should be a uint32_t from a             glGenTexture call, coerced into the IntPtr.|
|[TexType]({{site.url}}/Pages/StereoKit/TexType.html) type|The image flags that tell SK how to treat the             texture, this should match up with the settings the texture was             originally created with. If SK can figure the appropriate settings,             it _may_ override the value provided here.|
|Int64 native_fmt|The texture's format using the graphics             backend's value, not SK's. This should match up with the settings             the texture was originally created with. If SK can figure the             appropriate settings, it _may_ override the value provided here.|
|int width|Width of the texture. This should match up with             the settings the texture was originally created with. If SK can             figure the appropriate settings, it _may_ override the value             provided here.|
|int height|Height of the texture. This should match up             with the settings the texture was originally created with. If SK             can figure the appropriate settings, it _may_ override the value             provided here.|
|int surface_count|Texture array surface count. This             should match up with the settings the texture was originally             created with. If SK can figure the appropriate settings, it _may_             override the value provided here.|
|bool owned|Should ownership of this texture resource be             passed on to StereoKit? If so, StereoKit may delete it when it's             finished with it. If this is not desired, pass in false.|




