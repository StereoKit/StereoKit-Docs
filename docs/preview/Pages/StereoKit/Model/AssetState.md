---
layout: default
title: Model.AssetState
description: This tells you the current state of the Model asset. A Model starts in the Loading state when created from a file, transitions to LoadedMeta when the hierarchy is available, and Loaded once all mesh and texture data has been submitted for upload. This also reflects if an error occured while loading the Model with a variety of asset error codes!
---
# [Model]({{site.url}}/preview/Pages/StereoKit/Model.html).AssetState

<div class='signature' markdown='1'>
[AssetState]({{site.url}}/preview/Pages/StereoKit/AssetState.html) AssetState{ get }
</div>

## Description
This tells you the current state of the Model asset.
A Model starts in the Loading state when created from a file,
transitions to LoadedMeta when the hierarchy is available, and
Loaded once all mesh and texture data has been submitted for
upload. This also reflects if an error occured while loading the
Model with a variety of asset error codes!

