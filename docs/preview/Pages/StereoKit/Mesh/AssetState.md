---
layout: default
title: Mesh.AssetState
description: This tells you the current state of the Mesh asset. A Mesh starts in the None state, transitions to LoadedMeta when bounds are available (async path), and Loaded once GPU upload completes.
---
# [Mesh]({{site.url}}/preview/Pages/StereoKit/Mesh.html).AssetState

<div class='signature' markdown='1'>
[AssetState]({{site.url}}/preview/Pages/StereoKit/AssetState.html) AssetState{ get }
</div>

## Description
This tells you the current state of the Mesh asset.
A Mesh starts in the None state, transitions to LoadedMeta when
bounds are available (async path), and Loaded once GPU upload
completes.

