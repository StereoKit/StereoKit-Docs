---
layout: default
title: SK.AddStepper
description: This instantiates and registers an instance of the IStepper type provided as the generic parameter. SK will hold onto it, Initialize it, Step it every frame, and call Shutdown when the application ends. This is generally safe to do before SK.Initialize is called, the constructor is called right away, and Initialize is called right after SK.Initialize, or at the start of the next frame before the next main Step callback if SK is already initialized.
---
# [SK]({{site.url}}/Pages/StereoKit/SK.html).AddStepper

<div class='signature' markdown='1'>
```csharp
static Object AddStepper(Type type)
```
This instantiates and registers an instance of the
`IStepper` type provided as the generic parameter. SK will hold
onto it, Initialize it, Step it every frame, and call Shutdown when
the application ends. This is generally safe to do before
SK.Initialize is called, the constructor is called right away, and
Initialize is called right after SK.Initialize, or at the start of
the next frame before the next main Step callback if SK is already
initialized.
</div>

|  |  |
|--|--|
|Type type|Any object that implements IStepper, and has a             constructor with zero parameters.|
|RETURNS: Object|Just for convenience, this returns the instance that was just added.|




