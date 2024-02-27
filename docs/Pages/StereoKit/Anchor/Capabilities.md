---
layout: default
title: Anchor.Capabilities
description: This describes the anchoring capabilities of the current XR anchoring backend. Some systems like a HoloLens can create Anchors that provide stability, and can persist across multiple sessions. Some like SteamVR might be able to make a persistent Anchor that's relative to the stage, but doesn't provide any stability benefits.
---
# [Anchor]({{site.url}}/Pages/StereoKit/Anchor.html).Capabilities

<div class='signature' markdown='1'>
static [AnchorCaps]({{site.url}}/Pages/StereoKit/AnchorCaps.html) Capabilities{ get }
</div>

## Description
This describes the anchoring capabilities of the current
XR anchoring backend. Some systems like a HoloLens can create
Anchors that provide stability, and can persist across multiple
sessions. Some like SteamVR might be able to make a persistent
Anchor that's relative to the stage, but doesn't provide any
stability benefits.

