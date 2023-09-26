---
layout: default
title: TexFormat
description: What type of color information will the texture contain? A good default here is Rgba32.
---
# enum TexFormat

What type of color information will the texture contain? A
good default here is Rgba32.

## Enum Values

|  |  |
|--|--|
|Bgra32|Blue/Green/Red/Transparency data channels, at 8 bits per-channel in sRGB color space. This is a common swapchain format on Windows.|
|Bgra32Linear|Blue/Green/Red/Transparency data channels, at 8 bits per-channel in linear color space. This is a common swapchain format on Windows.|
|Depth16|16 bits of depth is not a lot, but it can be enough if your far clipping plane is pretty close. If you're seeing lots of flickering where two objects overlap, you either need to bring your far clip in, or switch to 32/24 bit depth.|
|Depth32|32 bits of data per depth value! This is pretty detailed, and is excellent for experiences that have a very far view distance.|
|DepthStencil|A depth data format, 24 bits for depth data, and 8 bits to store stencil information! Stencil data can be used for things like clipping effects, deferred rendering, or shadow effects.|
|None|A default zero value for TexFormat! Uninitialized formats will get this value and **** **** up so you know to assign it properly :)|
|R16|A single channel of data, with 16 bits per-pixel! This is a good format for height maps, since it stores a fair bit of information in it. Values in the shader are always 0.0-1.0.|
|R32|A single channel of data, with 32 bits per-pixel! This basically treats each pixel as a generic float, so you can do all sorts of strange and interesting things with this.|
|R8|A single channel of data, with 8 bits per-pixel! This can be great when you're only using one channel, and want to reduce memory usage. Values in the shader are always 0.0-1.0.|
|R8g8|A double channel of data that supports 8 bits for the red channel and 8 bits for the green channel.|
|Rg11b10|Red/Green/Blue data channels, with 11 bits for R and G, and 10 bits for blue. This is a great presentation format for high bit depth displays that still fits in 32 bits! This format has no alpha channel.|
|Rgb10a2|Red/Green/Blue/Transparency data channels, with 10 bits for R, G, and B, and 2 for alpha. This is a great presentation format for high bit depth displays that still fits in 32 bits, and also includes at least a bit of transparency!|
|Rgba128|Red/Green/Blue/Transparency data channels at 32 bits per-channel! Basically 4 floats per color, which is bonkers expensive. Don't use this unless you know -exactly- what you're doing.|
|Rgba32|Red/Green/Blue/Transparency data channels, at 8 bits per-channel in sRGB color space. This is what you'll want most of the time you're dealing with color images! Matches well with the Color32 struct! If you're storing normals, rough/metal, or anything else, use Rgba32Linear.|
|Rgba32Linear|Red/Green/Blue/Transparency data channels, at 8 bits per-channel in linear color space. This is what you'll want most of the time you're dealing with color data! Matches well with the Color32 struct.|
|Rgba64|Red/Green/Blue/Transparency data channels, at 16 bits per-channel! This is not common, but you might encounter it with raw photos, or HDR images. TODO: remove during major version update, prefer s, f, or u postfixed versions of this format.|
|Rgba64f|Red/Green/Blue/Transparency data channels, at 16 bits per-channel! This is not common, but you might encounter it with raw photos, or HDR images. The f postfix indicates that the raw color data is stored as 16 bit floats, which may be tricky to work with in most languages.|
|Rgba64s|Red/Green/Blue/Transparency data channels, at 16 bits per-channel! This is not common, but you might encounter it with raw photos, or HDR images. The s postfix indicates that the raw color data is stored as a signed 16 bit integer, which is then normalized into the -1, +1 floating point range on the GPU.|
|Rgba64u|Red/Green/Blue/Transparency data channels, at 16 bits per-channel! This is not common, but you might encounter it with raw photos, or HDR images. The u postfix indicates that the raw color data is stored as an unsigned 16 bit integer, which is then normalized into the 0, 1 floating point range on the GPU.|
