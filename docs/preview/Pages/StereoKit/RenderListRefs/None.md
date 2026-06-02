---
layout: default
title: RenderListRefs.None
description: The list does not addref or releaseref its items. The caller is responsible for ensuring referenced assets remain valid until the list is cleared. Useful for per-frame lists that are filled and drained inside a single frame.
---
# [RenderListRefs]({{site.url}}/preview/Pages/StereoKit/RenderListRefs.html).None

<div class='signature' markdown='1'>
static [RenderListRefs]({{site.url}}/preview/Pages/StereoKit/RenderListRefs.html) None
</div>

## Description
The list does not addref or releaseref its items. The caller is
responsible for ensuring referenced assets remain valid until the
list is cleared. Useful for per-frame lists that are filled and
drained inside a single frame.

