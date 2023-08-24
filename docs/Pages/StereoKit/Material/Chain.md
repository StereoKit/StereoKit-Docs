---
layout: default
title: Material.Chain
description: Allows you to chain Materials together in a form of multi-pass rendering! Any time the Material is used, the chained Materials will also be used to draw the same item.
---
# [Material]({{site.url}}/Pages/StereoKit/Material.html).Chain

<div class='signature' markdown='1'>
[Material]({{site.url}}/Pages/StereoKit/Material.html) Chain{ get set }
</div>

## Description
Allows you to chain Materials together in a form of
multi-pass rendering! Any time the Material is used, the chained
Materials will also be used to draw the same item.


## Examples

### Inverted Shell Chain
Materials can be chained together to create a multi-pass material! What
you're seeing here is an 'Inverted Shell' outline, a two-pass effect
where a second render pass is scaled along the normals and flipped
inside-out.

![A sphere with an inverted shell outline]({{site.screen_url}}/InvertedShell.jpg)
```csharp
Material outlineMaterial;

void CreateShellMaterial()
{
	Material shellMaterial = new Material("inflatable.hlsl");
	shellMaterial.FaceCull = Cull.Front;
	shellMaterial[MatParamName.ColorTint] = Color.HSV(0.1f, 0.7f, 1);

	outlineMaterial = Material.Default.Copy();
	outlineMaterial.Chain = shellMaterial;
}

void DrawOutlineObject()
{
	Mesh.Sphere.Draw(outlineMaterial, Matrix.S(0.3f));
}
```

