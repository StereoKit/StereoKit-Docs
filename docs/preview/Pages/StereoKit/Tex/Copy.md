---
layout: default
title: Tex.Copy
description: Copy the current texture into a new texture, with the option to convert it to a different format or type! This is a GPU blit operation, so the source texture does not need to be readable from the CPU. If the source texture doesn't have mip-maps but the destination type does, they'll be generated for you!
---
# [Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html).Copy

<div class='signature' markdown='1'>
```csharp
Tex Copy(TexType textureType, TexFormat textureFormat)
```
Copy the current texture into a new texture, with the
option to convert it to a different format or type! This is a GPU
blit operation, so the source texture does not need to be readable
from the CPU. If the source texture doesn't have mip-maps but the
destination type does, they'll be generated for you!
</div>

|  |  |
|--|--|
|[TexType]({{site.url}}/preview/Pages/StereoKit/TexType.html) textureType|What type of texture should the new             texture be? Image types with mip-maps will have mips generated for             them if the source doesn't have them.|
|[TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html) textureFormat|What format should the new texture             be in? If None is specified, the new texture will use the same             format as the source.|
|RETURNS: [Tex]({{site.url}}/preview/Pages/StereoKit/Tex.html)|A new texture copied from this one, or null if the copy failed.|




