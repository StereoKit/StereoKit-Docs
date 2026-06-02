---
layout: default
title: SKSettings.colorFormat
description: What kind of color buffer should StereoKit use for the primary display surface? By default StereoKit will let the XR runtime choose from a list that StereoKit likes. This is generally the best choice, as the runtime can pick surface formats that can improve performance. If a requested format is not available, StereoKit will fall back to the XR runtime's preference.
---
# [SKSettings]({{site.url}}/preview/Pages/StereoKit/SKSettings.html).colorFormat

<div class='signature' markdown='1'>
[TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html) colorFormat
</div>

## Description
What kind of color buffer should StereoKit use for the
primary display surface? By default StereoKit will let the XR
runtime choose from a list that StereoKit likes. This is generally
the best choice, as the runtime can pick surface formats that can
improve performance. If a requested format is not available,
StereoKit will fall back to the XR runtime's preference.

