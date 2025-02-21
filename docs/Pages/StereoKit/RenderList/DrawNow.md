---
layout: default
title: RenderList.DrawNow
description: Draws the RenderList to a rendertarget texture immediately. It does _not_ clear the list.
---
# [RenderList]({{site.url}}/Pages/StereoKit/RenderList.html).DrawNow

<div class='signature' markdown='1'>
```csharp
void DrawNow(Tex toRenderTarget, Matrix camera, Matrix projection, Color clearColor, RenderClear clear, Rect viewportPct, RenderLayer layerFilter)
```
Draws the RenderList to a rendertarget texture
immediately. It does _not_ clear the list.
</div>

|  |  |
|--|--|
|[Tex]({{site.url}}/Pages/StereoKit/Tex.html) toRenderTarget|The rendertarget texture to draw to.|
|[Matrix]({{site.url}}/Pages/StereoKit/Matrix.html) camera|A TRS matrix representing the location and             orientation of the camera. This matrix gets inverted later on, so             no need to do it yourself.|
|[Matrix]({{site.url}}/Pages/StereoKit/Matrix.html) projection|The projection matrix describes how the             geometry is flattened onto the draw surface. Normally, you'd use             Matrix.Perspective, and occasionally Matrix.Orthographic might be             helpful as well.|
|[Color]({{site.url}}/Pages/StereoKit/Color.html) clearColor|If the `clear` parameter is set to clear             the color of `toRenderTarget`, then this is the color it will clear             to. `default` would be a transparent black.|
|[RenderClear]({{site.url}}/Pages/StereoKit/RenderClear.html) clear|Describes if and how the rendertarget should             be cleared before rendering. Note that clearing the target is             unaffected by the viewport, so this will clean the entire             surface!|
|[Rect]({{site.url}}/Pages/StereoKit/Rect.html) viewportPct|Allows you to specify a region of the             rendertarget to draw to! This is in normalized coordinates, 0-1.             If the width of this value is zero, then this will render to the             entire texture.|
|[RenderLayer]({{site.url}}/Pages/StereoKit/RenderLayer.html) layerFilter|This is a bit flag that allows you to             change which layers StereoKit renders for this particular render             viewpoint. To change what layers a visual is on, use a Draw             method that includes a RenderLayer as a parameter.|





## Examples

### Render Icon From a Model

![UI with a custom rendererd icon]({{site.screen_url}}/Docs/RenderListIcon.jpg)

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

	// OpenGL renders upside-down to rendertargets, so this is a simple fix
	// for our case here, we just flip the camera upside down.
	Vec3 up = Backend.Graphics == BackendGraphics.D3D11
		?  Vec3.Up
		: -Vec3.Up;
	list.DrawNow(result,
		Matrix.LookAt(V.XYZ(0,0,-1), Vec3.Zero, up),
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

