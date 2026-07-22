---
layout: default
title: Material.GetVariant
description: This retreives the variant assigned to the specified variant index. Null is the default value for variants, and it's not valid to ask for variant 0 (already the current Material).
---
# [Material]({{site.url}}/preview/Pages/StereoKit/Material.html).GetVariant

<div class='signature' markdown='1'>
```csharp
Material GetVariant(int variantIndex)
```
This retreives the variant assigned to the specified
variant index. Null is the default value for variants, and it's not
valid to ask for variant 0 (already the current Material).
</div>

|  |  |
|--|--|
|int variantIndex|The variant to retreive. 0 is already the current material, and an invalid index here. SK has a max of 4 total variants, including the default.|
|RETURNS: [Material]({{site.url}}/preview/Pages/StereoKit/Material.html)|The Material variant, or null.|




