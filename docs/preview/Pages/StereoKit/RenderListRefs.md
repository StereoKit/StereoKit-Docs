---
layout: default
title: RenderListRefs
description: Controls whether a RenderList holds asset references for the items it contains. Tracked lists are safe to keep around across frames at the cost of an addref/releaseref pair per item.
---
# enum RenderListRefs

Controls whether a RenderList holds asset references for the items it
contains. Tracked lists are safe to keep around across frames at the cost
of an addref/releaseref pair per item.

## Enum Values

|  |  |
|--|--|
|None|The list does not addref or releaseref its items. The caller is responsible for ensuring referenced assets remain valid until the list is cleared. Useful for per-frame lists that are filled and drained inside a single frame.|
|Tracked|The list calls addref on each item's mesh/material when added, and releaseref when cleared. This keeps assets alive for as long as the list holds them, and is the safe default.|
