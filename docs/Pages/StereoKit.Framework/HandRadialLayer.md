---
layout: default
title: HandRadialLayer
description: This class represents a single layer in the HandRadialMenu. Each item in the layer is displayed around the radial menu's circle.
---
# class HandRadialLayer

This class represents a single layer in the HandRadialMenu.
Each item in the layer is displayed around the radial menu's circle.

## Instance Fields and Properties

|  |  |
|--|--|
|float [backAngle]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/backAngle.html)|What's the angle pointing towards the back button on this menu? If there is a back button. This is used to orient the back button towards the direction the finger just came from.|
|HandMenuItem[] [items]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/items.html)|A list of menu items to display in this menu layer.|
|string [layerName]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/layerName.html)|Name of the layer, this is used for layer traversal, so make sure you get the spelling right! Perhaps use const strings for these.|
|[HandRadialLayer]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer.html) [Parent]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/Parent.html)|The layer above this layer, will be null if this is the root layer.|
|float [startAngle]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/startAngle.html)|An angle offset for the layer, if you want a specific orientation for the menu's contents. Note this may not behave as expected if you're setting this manually and using the backAngle as well.|

## Instance Methods

|  |  |
|--|--|
|[HandRadialLayer]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/HandRadialLayer.html)|Creates a menu layer, this overload will calculate a backAngle if there are any back actions present in the item list.|
|[AddChild]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/AddChild.html)|This adds a menu layer as a child item of this layer.|
|[AddItem]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/AddItem.html)|This appends a new menu item to the end of the menu's list.|
|[FindChild]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/FindChild.html)|Find a child menu layer by name.|
|[FindItem]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/FindItem.html)|Find a menu item by name.|
|[RemoveChild]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/RemoveChild.html)|Finds the layer in the list of child layers, and removes it, if it exists.|
|[RemoveItem]({{site.url}}/Pages/StereoKit.Framework/HandRadialLayer/RemoveItem.html)|Finds the item in the list, and removes it, if it exists.|

## Examples

### Basic layered hand menu

The HandMenuRadial is an `IStepper`, so it should be registered with
`StereoKitApp.AddStepper` so it can run by itself! It's recommended to
keep track of it anyway, so you can remove it when you're done with it
via `StereoKitApp.RemoveStepper`

The constructor uses a params style argument list that makes it easy and
clean to provide lists of items! This means you can assemble the whole
menu on a single 'line'. You can still pass arrays instead if you prefer
that!
```csharp
handMenu = SK.AddStepper(new HandMenuRadial(
	new HandRadialLayer("Root",
		new HandMenuItem("File",   null, null, "File"),
		new HandMenuItem("Search", null, null, "Edit"),
		new HandMenuItem("About",  Sprite.FromFile("search.png"), () => Log.Info(SK.VersionName)),
		new HandMenuItem("Cancel", null, null)),
	new HandRadialLayer("File", 
		new HandMenuItem("New",    null, () => Log.Info("New")),
		new HandMenuItem("Open",   null, () => Log.Info("Open")),
		new HandMenuItem("Close",  null, () => Log.Info("Close")),
		new HandMenuItem("Back",   null, null, HandMenuAction.Back)),
	new HandRadialLayer("Edit",
		new HandMenuItem("Copy",   null, () => Log.Info("Copy")),
		new HandMenuItem("Paste",  null, () => Log.Info("Paste")),
		new HandMenuItem("Back",   null, null, HandMenuAction.Back))));
```

```csharp
SK.RemoveStepper(handMenu);
```

