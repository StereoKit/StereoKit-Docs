---
layout: default
title: Assets.Type
description: Allows for enumerating all StereoKit assets matching the specified type.
---
# [Assets]({{site.url}}/Pages/StereoKit/Assets.html).Type

<div class='signature' markdown='1'>
```csharp
static IEnumerable`1 Type(Type type)
```
Allows for enumerating all StereoKit assets matching the
specified type.
</div>

|  |  |
|--|--|
|Type type|Any `IAsset` type.|
|RETURNS: IEnumerable`1|An enumeration of all loaded asset objects that match the given type.|





## Examples

### Simple Asset Browser
A full asset browser might have a few more features, but here's a quick
and dirty window that will provide a filtered list of the current
live assets!

![An overly simple asset browser window]({{site.screen_url}}/TinyAssetBrowser.jpg)
```csharp
List<IAsset> filteredAssets = new List<IAsset>();
Type         filterType     = typeof(IAsset);
Pose         filterWindow   = Demo.contentPose.Pose;
float        filterScroll   = 0;
const int    filterScrollCt = 12;

void UpdateFilter(Type type)
{
	filterType   = type;
	filterScroll = 0.0f;
	filteredAssets.Clear();
	
	// Here's where the magic happens! `Assets.Type` can take a Type, or a
	// generic <T>, and will give a list of all assets that match that
	// type!
	filteredAssets.AddRange(Assets.Type(filterType));
}

public void AssetWindow()
{
	UISettings settings = UI.Settings;
	float height = filterScrollCt * (UI.LineHeight + settings.gutter) + settings.margin * 2;
	UI.WindowBegin("Asset Browser", ref filterWindow, V.XY(0.5f, height));

	UI.LayoutPushCut(UICut.Left, 0.08f);
	UI.PanelAt(UI.LayoutAt, UI.LayoutRemaining);

	UI.Label("Filter");

	UI.HSeparator();

	// A radio button selection for what to filter by
	Vec2 size = new Vec2(0.08f, 0);
	if (UI.Radio("Model",    filterType == typeof(Model   ), size)) UpdateFilter(typeof(Model));
	UI.SameLine();
	if (UI.Radio("Mesh",     filterType == typeof(Mesh    ), size)) UpdateFilter(typeof(Mesh));
	UI.SameLine();
	if (UI.Radio("Material", filterType == typeof(Material), size)) UpdateFilter(typeof(Material));
	UI.SameLine();
	if (UI.Radio("Sprite",   filterType == typeof(Sprite  ), size)) UpdateFilter(typeof(Sprite));
	UI.SameLine();
	if (UI.Radio("Sound",    filterType == typeof(Sound   ), size)) UpdateFilter(typeof(Sound));
	UI.SameLine();
	if (UI.Radio("Font",     filterType == typeof(Font    ), size)) UpdateFilter(typeof(Font));
	UI.SameLine();
	if (UI.Radio("Shader",   filterType == typeof(Shader  ), size)) UpdateFilter(typeof(Shader));
	UI.SameLine();
	if (UI.Radio("Tex",      filterType == typeof(Tex     ), size)) UpdateFilter(typeof(Tex));
	UI.SameLine();
	if (UI.Radio("All",      filterType == typeof(IAsset  ), size)) UpdateFilter(typeof(IAsset));

	UI.LayoutPop();

	UI.LayoutPushCut(UICut.Right, UI.LineHeight);
	UI.VSlider("scroll", ref filterScroll, 0, Math.Max(0,filteredAssets.Count-3), 1, 0, UIConfirm.Pinch);
	UI.LayoutPop();


	// We can visualize some of these assets, and just draw a label for
	// some others.
	for (int i = (int)filterScroll; i < Math.Min(filteredAssets.Count, (int)filterScroll + filterScrollCt); i++)
	{
		IAsset asset = filteredAssets[i];
		UI.PushId(i);
		switch (asset)
		{
			case Mesh     item: VisualizeMesh    (item); break;
			case Material item: VisualizeMaterial(item); break;
			case Sprite   item: VisualizeSprite  (item); break;
			case Model    item: VisualizeModel   (item); break;
			case Sound    item: VisualizeSound   (item); break;
		}
		UI.PopId();
		UI.Label(string.IsNullOrEmpty(asset.Id) ? "(null)" : asset.Id);
	}
	
	UI.WindowEnd();
}

void VisualizeMesh(Mesh item)
{
	Bounds meshSize = item.Bounds;
	Bounds b        = UI.LayoutReserve(V.XX(UI.LineHeight), false, UI.LineHeight);
	float  scale    = (1.0f/meshSize.dimensions.Length);
	item.Draw(Material.Default, Matrix.TS(b.center+meshSize.center*scale, b.dimensions*scale));

	UI.SameLine();
}

void VisualizeMaterial(Material item)
{
	// Default Materials have a number of special effect shaders that don't
	// visualize in a generic way.
	if (!string.IsNullOrEmpty(item.Id) && (item.Id.StartsWith("render/") || item.Id.StartsWith("default/")))
		return;

	Bounds b = UI.LayoutReserve(V.XX(UI.LineHeight), false, UI.LineHeight);
	Mesh.Sphere.Draw(item, Matrix.TS(b.center, b.dimensions));

	UI.SameLine();
}

void VisualizeSprite(Sprite item)
{
	UI.Image(item, V.XX(UI.LineHeight));
	UI.SameLine();
}

void VisualizeModel(Model item)
{
	UI.Model(item, V.XX(UI.LineHeight));
	UI.SameLine();
}

void VisualizeSound(Sound item)
{
	if (UI.Button(">", V.XX(UI.LineHeight)))
		item.Play(Hierarchy.ToWorld(UI.LayoutLast.center));
	UI.SameLine();
}
```

