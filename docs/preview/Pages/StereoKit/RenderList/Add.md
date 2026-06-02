---
layout: default
title: RenderList.Add
description: Add a Mesh/Material to the RenderList. The RenderList will hold a reference to these Assets until the list is cleared.
---
# [RenderList]({{site.url}}/preview/Pages/StereoKit/RenderList.html).Add

<div class='signature' markdown='1'>
```csharp
void Add(Mesh mesh, Material material, Matrix transform, Color colorLinear, RenderLayer layer)
```
Add a Mesh/Material to the RenderList. The RenderList will
hold a reference to these Assets until the list is cleared.
</div>

|  |  |
|--|--|
|[Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html) mesh|A valid Mesh you wish to draw.|
|[Material]({{site.url}}/preview/Pages/StereoKit/Material.html) material|A Material to apply to the Mesh.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) transform|A transformation Matrix relative to the             current Hierarchy.|
|[Color]({{site.url}}/preview/Pages/StereoKit/Color.html) colorLinear|A per-instance linear space color value             to pass into the shader! Normally this gets used like a material             tint. If you're  adventurous and don't need per-instance colors,             this is a great spot to pack in extra per-instance data for the             shader!|
|[RenderLayer]({{site.url}}/preview/Pages/StereoKit/RenderLayer.html) layer|All visuals are rendered using a layer             bit-flag. By default, all layers are rendered, but this can be             useful for filtering out objects for different rendering             purposes! For example: rendering a mesh over the user's head from             a 3rd person perspective, but filtering it out from the 1st             person perspective.|

<div class='signature' markdown='1'>
```csharp
void Add(Model model, Matrix transform, Color colorLinear, RenderLayer layer)
```
Add a Model to the RenderList. The RenderList will
hold a reference to these Assets until the list is cleared.
</div>

|  |  |
|--|--|
|[Model]({{site.url}}/preview/Pages/StereoKit/Model.html) model|A valid Model you wish to draw.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) transform|A transformation Matrix relative to the             current Hierarchy.|
|[Color]({{site.url}}/preview/Pages/StereoKit/Color.html) colorLinear|A per-instance linear space color value             to pass into the shader! Normally this gets used like a material             tint. If you're  adventurous and don't need per-instance colors,             this is a great spot to pack in extra per-instance data for the             shader!|
|[RenderLayer]({{site.url}}/preview/Pages/StereoKit/RenderLayer.html) layer|All visuals are rendered using a layer             bit-flag. By default, all layers are rendered, but this can be             useful for filtering out objects for different rendering             purposes! For example: rendering a mesh over the user's head from             a 3rd person perspective, but filtering it out from the 1st             person perspective.|

<div class='signature' markdown='1'>
```csharp
void Add(Model model, Material materialOverride, Matrix transform, Color colorLinear, RenderLayer layer)
```
Add a Model to the RenderList. The RenderList will
hold a reference to these Assets until the list is cleared.
</div>

|  |  |
|--|--|
|[Model]({{site.url}}/preview/Pages/StereoKit/Model.html) model|A valid Model you wish to draw.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) transform|A transformation Matrix relative to the             current Hierarchy.|
|[Color]({{site.url}}/preview/Pages/StereoKit/Color.html) colorLinear|A per-instance linear space color value             to pass into the shader! Normally this gets used like a material             tint. If you're  adventurous and don't need per-instance colors,             this is a great spot to pack in extra per-instance data for the             shader!|
|[RenderLayer]({{site.url}}/preview/Pages/StereoKit/RenderLayer.html) layer|All visuals are rendered using a layer             bit-flag. By default, all layers are rendered, but this can be             useful for filtering out objects for different rendering             purposes! For example: rendering a mesh over the user's head from             a 3rd person perspective, but filtering it out from the 1st             person perspective.|
|[Material]({{site.url}}/preview/Pages/StereoKit/Material.html) materialOverride|Allows you to override the Material             of all nodes on this Model with your own Material.|





## Examples

### Render Icon From a Model

![UI with a custom rendererd icon]({{site.url}}/preview/img/screenshots/Docs/RenderListIcon.jpg)

One place where RenderList excels, is at rendering icons or previews of
Models or scenes! This snippet of code will take a Model asset, and
render a preview of it into a small Sprite.

```csharp
static Sprite MakeIcon(Model model, int resolution)
{
	RenderList list   = new RenderList();
	Tex        result = Tex.RenderTarget(resolution, resolution, 8);

	// Calculate a standard size that will fill the icon to the edges,
	// based on the camera parameters we pass to DrawNow.
	float scale = 1/model.Bounds.dimensions.Length;

	list.Add(model, Matrix.TS(-model.Bounds.center*scale, scale), Color.White);

	list.DrawNow(result,
		Matrix.LookAt(V.XYZ(0,0,-1), Vec3.Zero, Vec3.Up),
		Matrix.Perspective(45, 1, 0.01f, 10));

	// Clearing isn't _necessary_ here, but DrawNow does not clear the list
	// after drawing! This will free up assets that were referenced in the
	// list without waiting for GC to destroy the RenderList object.
	list.Clear();

	return Sprite.FromTex(result.Copy());
}
```
From there, it's pretty easy to load a Model up, and draw it on a button
in the UI.
```csharp
Sprite icon;
public void Initialize()
{
	Model model = Model.FromFile("Watermelon.glb");
	// Model loading is async, so we want to make sure the Model is fully
	// loaded before comitting it to a Sprite!
	Assets.BlockForPriority(int.MaxValue);
	icon = MakeIcon(model, 128);
}

Pose windowPose = new Pose(0,0,-0.5f, Quat.LookDir(0,0,1));
void ShowWindow()
{
	UI.WindowBegin("RenderList Icons", ref windowPose);
	UI.ButtonImg("Icon", icon, UIBtnLayout.CenterNoText, V.XX(UI.LineHeight*2));
	UI.WindowEnd();
}
```

