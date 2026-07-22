---
layout: default
title: RenderClear
description: When rendering to a rendertarget, this tells if and what of the rendertarget gets cleared before rendering. For example, if you are assembling a sheet of images, you may want to clear everything on the first image draw, but not clear on subsequent draws.
---
# enum RenderClear

When rendering to a rendertarget, this tells if and what of the
rendertarget gets cleared before rendering. For example, if you
are assembling a sheet of images, you may want to clear
everything on the first image draw, but not clear on subsequent
draws.

## Enum Values

|  |  |
|--|--|
|All|Clear both color and depth data. A zero value also means this - it's the default, so zero-initialized settings clear everything.|
|Color|Clear the rendertarget's color data.|
|Depth|Clear the rendertarget's depth data, if present.|
|Keep|Don't clear anything, draw on top of what's already there.|
|None|Deprecated, use render_clear_keep.|
