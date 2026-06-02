---
layout: default
title: Material.SetVariant
description: Variants are used by special effects when a manual render pass selects a variant to use for the whole pass! Variants default to null, and null variants are not drawn.  For example, a shadow map render pass might use variant 1, and sets it to a simplified Material that skips textures and only does positional vertex transforms.
---
# [Material]({{site.url}}/preview/Pages/StereoKit/Material.html).SetVariant

<div class='signature' markdown='1'>
```csharp
void SetVariant(int variantIndex, Material variantMaterial)
```
Variants are used by special effects when a manual render
pass selects a variant to use for the whole pass! Variants default
to null, and null variants are not drawn.

For example, a shadow map render pass might use variant 1, and sets
it to a simplified Material that skips textures and only does
positional vertex transforms.
</div>

|  |  |
|--|--|
|int variantIndex|Which variant index should we set? 0 is             reserved for the primary material, and SK has a max of 4 total             variants, including the default.|
|[Material]({{site.url}}/preview/Pages/StereoKit/Material.html) variantMaterial|The Material to use for the variant.             Sub-variants are ignored, and a null variant means nothing will be             drawn when using the variant.|




