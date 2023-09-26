---
layout: default
title: RenderLayer
description: When rendering content, you can filter what you're rendering by the RenderLayer that they're on. This allows you to draw items that are visible in one render, but not another. For example, you may wish to draw a player's avatar in a 'mirror' rendertarget, but not in the primary display. See Renderer.LayerFilter for configuring what the primary display renders.
---
# enum RenderLayer

When rendering content, you can filter what you're rendering
by the RenderLayer that they're on. This allows you to draw items that
are visible in one render, but not another. For example, you may wish
to draw a player's avatar in a 'mirror' rendertarget, but not in
the primary display. See `Renderer.LayerFilter` for configuring what
the primary display renders.

## Enum Values

|  |  |
|--|--|
|All|This is a flag that specifies all possible layers. If you want to render all layers, then this is the layer filter you would use. This is the default for render filtering.|
|AllFirstPerson|All layers except for the third person layer.|
|AllRegular|This is a combination of all layers that are not the VFX layer.|
|AllThirdPerson|All layers except for the first person layer.|
|FirstPerson|For items that should only be drawn from the first person perspective. By default, this is enabled for renders that are from a 1st person viewpoint.|
|Layer0|The default render layer. All Draw use this layer unless otherwise specified.|
|Layer1|Render layer 1.|
|Layer2|Render layer 2.|
|Layer3|Render layer 3.|
|Layer4|Render layer 4.|
|Layer5|Render layer 5.|
|Layer6|Render layer 6.|
|Layer7|Render layer 7.|
|Layer8|Render layer 8.|
|Layer9|Render layer 9.|
|ThirdPerson|For items that should only be drawn from the third person perspective. By default, this is enabled for renders that are from a 3rd person viewpoint.|
|Vfx|The default VFX layer, StereoKit draws some non-standard mesh content using this flag, such as lines.|
