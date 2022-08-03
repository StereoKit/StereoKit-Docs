---
layout: default
title: Shader.UIBox
description: A shader for indicating interaction volumes! It renders a border around the edges of the UV coordinates that will 'grow' on proximity to the user's finger. It will discard pixels outside of that border, but will also show the finger shadow. This is meant to be an opaque shader, so it works well for depth LSR.  This shader works best on cube-like meshes where each face has UV coordinates from 0-1.  Shader Parameters. color                - color border_size          - meters border_size_grow     - meters border_affect_radius - meters
---
# [Shader]({{site.url}}/Pages/StereoKit/Shader.html).UIBox

<div class='signature' markdown='1'>
static [Shader]({{site.url}}/Pages/StereoKit/Shader.html) UIBox{ get }
</div>

## Description
A shader for indicating interaction volumes! It renders
a border around the edges of the UV coordinates that will 'grow'
on proximity to the user's finger. It will discard pixels outside
of that border, but will also show the finger shadow. This is
meant to be an opaque shader, so it works well for depth LSR.

This shader works best on cube-like meshes where each face has
UV coordinates from 0-1.

Shader Parameters:
```color                - color
border_size          - meters
border_size_grow     - meters
border_affect_radius - meters```

