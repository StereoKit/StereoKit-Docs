---
layout: default
title: HandMenuItem
description: This is a collection of display and behavior information for a single item on the hand menu.
---
# class HandMenuItem

This is a collection of display and behavior information for
a single item on the hand menu.

## Instance Fields and Properties

|  |  |
|--|--|
|[HandMenuAction]({{site.url}}/Pages/StereoKit.Framework/HandMenuAction.html) [action]({{site.url}}/Pages/StereoKit.Framework/HandMenuItem/action.html)|Describes the menu related behavior of this menu item, should it close the menu? Open another layer? Go back to the previous menu?|
|Action [callback]({{site.url}}/Pages/StereoKit.Framework/HandMenuItem/callback.html)|The callback that should be performed when this menu item is selected.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [image]({{site.url}}/Pages/StereoKit.Framework/HandMenuItem/image.html)|Display image of the item, null is fine!|
|string [layerName]({{site.url}}/Pages/StereoKit.Framework/HandMenuItem/layerName.html)|If the action is set to Layer, then this is the layer name used to find the next layer for the menu!|
|string [name]({{site.url}}/Pages/StereoKit.Framework/HandMenuItem/name.html)|Display name of the item.|

## Instance Methods

|  |  |
|--|--|
|[HandMenuItem]({{site.url}}/Pages/StereoKit.Framework/HandMenuItem/HandMenuItem.html)|A menu item that'll load another layer when selected.|
|[Draw]({{site.url}}/Pages/StereoKit.Framework/HandMenuItem/Draw.html)|This draws the menu item on the radial menu!|

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

