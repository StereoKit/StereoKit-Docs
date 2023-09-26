---
layout: default
title: Tex.SetMemory
description: Loads an image file stored in memory directly into the created texture! Supported formats are. jpg, png, tga, bmp, psd, gif, hdr, pic. This method introduces a blocking boolean parameter, which allows you to specify whether this method blocks until the image fully loads! The default case is to have it as part of the asynchronous asset pipeline, in which the Asset Id will be the same as the filename.
---
# [Tex]({{site.url}}/Pages/StereoKit/Tex.html).SetMemory

<div class='signature' markdown='1'>
```csharp
void SetMemory(Byte[]& imageFileData, bool sRGBData, bool blocking, int priority)
```
Loads an image file stored in memory directly into
the created texture! Supported formats are: jpg, png, tga,
bmp, psd, gif, hdr, pic. This method introduces a blocking
boolean parameter, which allows you to specify whether this
method blocks until the image fully loads! The default case
is to have it as part of the asynchronous asset pipeline, in
which the Asset Id will be the same as the filename.
</div>

|  |  |
|--|--|
|Byte[]& imageFileData|The binary data of an image file,             this is NOT a raw RGB color array!|
|bool sRGBData|Is this image color data in sRGB format,             or is it normal/metal/rough/data that's not for direct display?             sRGB colors get converted to linear color space on the graphics             card, so getting this right can have a big impact on visuals.|
|bool blocking|Will this method wait for the image              to load. By default, we try to load it asynchronously.|
|int priority|The priority sort order for this asset in             the async loading system. Lower values mean loading sooner.|




