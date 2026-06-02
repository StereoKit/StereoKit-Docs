---
layout: default
title: TexType
description: Textures come in various types and flavors! These are bit-flags that tell StereoKit what type of texture we want, and how the application might use it!
---
# enum TexType

Textures come in various types and flavors! These are bit-flags
that tell StereoKit what type of texture we want, and how the application
might use it!

## Enum Values

|  |  |
|--|--|
|Compute|This texture can be used as a RWTexture in compute shaders. Create it with a format that supports storage images, such as tex_format_rgba128.|
|Cubemap|A size sided texture that's used for things like skyboxes, environment maps, and reflection probes. It behaves like a texture array with 6 textures.|
|Depth|This texture contains depth data, not color data! It is writeable, but not readable. This makes it great for zbuffers, but not shadowmaps or other textures that need to be read from later on.|
|Depthtarget|This texture contains depth data, not color data! It is writeable and readable. This makes it great for shadowmaps or other textures that need to be read from later on.|
|Dynamic|This texture's data will be updated frequently from the CPU (not renders)! This ensures the graphics card stores it someplace where writes are easy to do quickly.|
|Image|A standard color image that also generates mip-maps automatically.|
|ImageNomips|A standard color image, without any generated mip-maps.|
|Mips|This texture will generate mip-maps any time the contents change. Mip-maps are a list of textures that are each half the size of the one before them! This is used to prevent textures from 'sparkling' or aliasing in the distance.|
|Rendertarget|This texture can be rendered to! This is great for textures that might be passed in as a target to Renderer.Blit, or other such situations.|
|Volume|A volumetric (3D) texture, sized with width, height, and depth. Volume textures are mutually exclusive with Cubemap and array textures, and don't pair with a zbuffer.|
|Zbuffer|This texture contains depth data, not color data! It is writeable, but not readable. This makes it great for zbuffers, but not shadowmaps or other textures that need to be read from later on.|
