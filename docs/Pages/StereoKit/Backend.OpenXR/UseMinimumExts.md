---
layout: default
title: Backend.OpenXR.UseMinimumExts
description: Tells StereoKit to request only the extensions that are absolutely critical to StereoKit. You can still request extensions via OpenXR.RequestExt, and this can be used to opt-in to extensions that StereoKit would normally request automatically.
---
# [Backend.OpenXR]({{site.url}}/Pages/StereoKit/Backend.OpenXR.html).UseMinimumExts

<div class='signature' markdown='1'>
static bool UseMinimumExts{ set }
</div>

## Description
Tells StereoKit to request only the extensions that
are absolutely critical to StereoKit. You can still request
extensions via `OpenXR.RequestExt`, and this can be used to
opt-in to extensions that StereoKit would normally request
automatically.

