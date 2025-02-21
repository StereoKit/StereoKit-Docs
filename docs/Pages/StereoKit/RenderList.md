---
layout: default
title: RenderList
description: A RenderList is a collection of Draw commands that can be submitted to various surfaces. RenderList.Primary is where all normal Draw calls get added to, and this RenderList is renderer to primary display surface.  Manually working with a RenderList can be useful for "baking down matrices" or caching a scene of objects. Or for drawing a separate scene to an offscreen surface, like for thumbnails of Models.
---
# class RenderList

A RenderList is a collection of Draw commands that can be
submitted to various surfaces. RenderList.Primary is where all normal
Draw calls get added to, and this RenderList is renderer to primary
display surface.

Manually working with a RenderList can be useful for "baking down
matrices" or caching a scene of objects. Or for drawing a separate
scene to an offscreen surface, like for thumbnails of Models.

## Instance Fields and Properties

|  |  |
|--|--|
|int [Count]({{site.url}}/Pages/StereoKit/RenderList/Count.html)|The number of Mesh/Material pairs that have been submitted to the render list so far this frame.|
|string [Id]({{site.url}}/Pages/StereoKit/RenderList/Id.html)|Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!|
|int [PrevCount]({{site.url}}/Pages/StereoKit/RenderList/PrevCount.html)|This is the number of items in the RenderList before it was most recently cleared. If this is a list that is drawn and cleared each frame, you can think of this as "last frame's count".|

## Instance Methods

|  |  |
|--|--|
|[RenderList]({{site.url}}/Pages/StereoKit/RenderList/RenderList.html)|Creates a new empty RenderList.|
|[Add]({{site.url}}/Pages/StereoKit/RenderList/Add.html)|Add a Mesh/Material to the RenderList. The RenderList will hold a reference to these Assets until the list is cleared.|
|[Clear]({{site.url}}/Pages/StereoKit/RenderList/Clear.html)|Clears out and de-references all Draw items currently in the RenderList.|
|[DrawNow]({{site.url}}/Pages/StereoKit/RenderList/DrawNow.html)|Draws the RenderList to a rendertarget texture immediately. It does _not_ clear the list.|

## Static Fields and Properties

|  |  |
|--|--|
|[RenderList]({{site.url}}/Pages/StereoKit/RenderList.html) [Primary]({{site.url}}/Pages/StereoKit/RenderList/Primary.html)|The default RenderList used by the Renderer for the primary display surface.|

## Static Methods

|  |  |
|--|--|
|[Find]({{site.url}}/Pages/StereoKit/RenderList/Find.html)|Finds the RenderList with the matching id, and returns a reference to it. If no RenderList is found, it returns null.|
|[Pop]({{site.url}}/Pages/StereoKit/RenderList/Pop.html)|This removes the current top of the RenderList stack, making the next list as active|
|[Push]({{site.url}}/Pages/StereoKit/RenderList/Push.html)|All draw calls that don't specify a render list will get submitted to the active RenderList at the top of the stack. By default, that's RenderList.Primary, but you can push your own list onto the stack here to capture draw calls, like those done in the UI.|

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

