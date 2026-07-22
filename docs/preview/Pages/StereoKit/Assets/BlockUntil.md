---
layout: default
title: Assets.BlockUntil
description: This will block execution until the given asset reaches the specified loading state. If the asset has already reached or passed that state, this returns immediately. If the asset is in an error state, this also returns immediately.
---
# [Assets]({{site.url}}/preview/Pages/StereoKit/Assets.html).BlockUntil

<div class='signature' markdown='1'>
```csharp
static void BlockUntil(IAsset asset, AssetState state)
```
This will block execution until the given asset reaches
the specified loading state. If the asset has already reached or
passed that state, this returns immediately. If the asset is in
an error state, this also returns immediately.
</div>

|  |  |
|--|--|
|[IAsset]({{site.url}}/preview/Pages/StereoKit/IAsset.html) asset|The asset to wait on.|
|[AssetState]({{site.url}}/preview/Pages/StereoKit/AssetState.html) state|The state to wait for, such as AssetState.Loaded or AssetState.LoadedMeta.|




