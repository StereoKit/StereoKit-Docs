---
layout: default
title: Sprite
description: A Sprite is an image that's set up for direct 2D rendering, without using a mesh or model! This is technically a wrapper over a texture, but it also includes atlasing functionality, which can be pretty important to performance! This is used a lot in UI, for image rendering.  Atlasing is not currently implemented, it'll swap to Single for now. But here's how it works!  StereoKit will batch your sprites into an atlas if you ask it to! This puts all the images on a single texture to significantly reduce draw calls when many images are present. Any time you add a sprite to an atlas, it'll be marked as dirty and rebuilt at the end of the frame. So it can be a good idea to add all your images to the atlas on initialize rather than during execution!  Since rendering is atlas based, you also have only one material per atlas. So this is why you might wish to put a sprite in one atlas or another, so you can apply different
---
# class Sprite

A Sprite is an image that's set up for direct 2D rendering,
without using a mesh or model! This is technically a wrapper over a
texture, but it also includes atlasing functionality, which can be
pretty important to performance! This is used a lot in UI, for image
rendering.

Atlasing is not currently implemented, it'll swap to Single for now.
But here's how it works!

StereoKit will batch your sprites into an atlas if you ask it to!
This puts all the images on a single texture to significantly reduce
draw calls when many images are present. Any time you add a sprite to
an atlas, it'll be marked as dirty and rebuilt at the end of the
frame. So it can be a good idea to add all your images to the atlas
on initialize rather than during execution!

Since rendering is atlas based, you also have only one material per
atlas. So this is why you might wish to put a sprite in one atlas or
another, so you can apply different

## Instance Fields and Properties

|  |  |
|--|--|
|float [Aspect]({{site.url}}/Pages/StereoKit/Sprite/Aspect.html)|The aspect ratio of the sprite! This is width/height. You may also be interested in the NormalizedDimensions property, which are normalized to the 0-1 range.|
|int [Height]({{site.url}}/Pages/StereoKit/Sprite/Height.html)|Height of the sprite, in pixels.|
|string [Id]({{site.url}}/Pages/StereoKit/Sprite/Id.html)|Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managine your assets, or finding them later on!|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) [NormalizedDimensions]({{site.url}}/Pages/StereoKit/Sprite/NormalizedDimensions.html)|Width and height of the sprite, normalized so the maximum value is 1.|
|int [Width]({{site.url}}/Pages/StereoKit/Sprite/Width.html)|Width of the sprite, in pixels.|

## Instance Methods

|  |  |
|--|--|
|[Draw]({{site.url}}/Pages/StereoKit/Sprite/Draw.html)|Draw the sprite on a quad with the provided transform!|

## Static Fields and Properties

|  |  |
|--|--|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [ArrowDown]({{site.url}}/Pages/StereoKit/Sprite/ArrowDown.html)|This is a 64x64 image of a slightly rounded triangle pointing down.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [ArrowLeft]({{site.url}}/Pages/StereoKit/Sprite/ArrowLeft.html)|This is a 64x64 image of a slightly rounded triangle pointing left.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [ArrowRight]({{site.url}}/Pages/StereoKit/Sprite/ArrowRight.html)|This is a 64x64 image of a slightly rounded triangle pointing right.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [ArrowUp]({{site.url}}/Pages/StereoKit/Sprite/ArrowUp.html)|This is a 64x64 image of a slightly rounded triangle pointing up.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [Backspace]({{site.url}}/Pages/StereoKit/Sprite/Backspace.html)|This is a 64x64 image of a backspace action button, similar to a backspace button you might find on a mobile keyboard.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [Close]({{site.url}}/Pages/StereoKit/Sprite/Close.html)|This is a 64x64 image of a square aspect X, with rounded edge. It's used to indicate a 'close' icon.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [RadioOff]({{site.url}}/Pages/StereoKit/Sprite/RadioOff.html)|This is a 64x64 image of an empty hole. This is common iconography for radio buttons which use an empty hole to indicate an un-selected radio, and a filled hole for a selected radio. This is used by the UI for radio buttons!|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [RadioOn]({{site.url}}/Pages/StereoKit/Sprite/RadioOn.html)|This is a 64x64 image of a filled hole. This is common iconography for radio buttons which use an empty hole to indicate an un-selected radio, and a filled hole for a selected radio. This is used by the UI for radio buttons!|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [Shift]({{site.url}}/Pages/StereoKit/Sprite/Shift.html)|This is a 64x64 image of an upward facing rounded arrow. This is a triangular top with a narrow rectangular base, and is used to indicate a 'shift' icon on a keyboard.|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [ToggleOff]({{site.url}}/Pages/StereoKit/Sprite/ToggleOff.html)|This is a 64x64 image of an empty rounded square. This is common iconography for checkboxes which use an empty square to indicate an un-selected checkbox, and a filled square for a selected checkbox. This is used by the UI for toggle buttons!|
|[Sprite]({{site.url}}/Pages/StereoKit/Sprite.html) [ToggleOn]({{site.url}}/Pages/StereoKit/Sprite/ToggleOn.html)|This is a 64x64 image of a filled rounded square. This is common iconography for checkboxes which use an empty square to indicate an un-selected checkbox, and a filled square for a selected checkbox. This is used by the UI for toggle buttons!|

## Static Methods

|  |  |
|--|--|
|[Find]({{site.url}}/Pages/StereoKit/Sprite/Find.html)|Finds a sprite that matches the given id! Check out the DefaultIds static class for some built-in ids. Sprites will auto-id themselves using this pattern if single sprites: {Tex.Id}/spr, and this pattern if atlased sprites: atlas_spr/{atlas}/{Tex.Id}.|
|[FromFile]({{site.url}}/Pages/StereoKit/Sprite/FromFile.html)|Create a sprite from an image file! This loads a Texture from file, and then uses that Texture as the source for the Sprite.|
|[FromTex]({{site.url}}/Pages/StereoKit/Sprite/FromTex.html)|Create a sprite from a Texture object!|
