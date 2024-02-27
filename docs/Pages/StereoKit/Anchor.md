---
layout: default
title: Anchor
description: An Anchor in StereoKit is a completely virtual pose that is pinned to a real-world location. They are creatable via code, generally can persist across sessions, may provide additional stability beyond the system's 6dof tracking, and are not physical objects!  This functionality is backed by extensions like the Microsoft Spatial Anchor, or the Facebook Spatial Entity. If a proper anchoring system isn't present on the device, StereoKit will fall back to a stage- relative anchor. Stage-relative anchors may be a good solution for devices with a consistent stage, but may be troublesome if the user adjusts their stage frequently.  A conceptual guide to Anchors. - A cloud anchor is an Anchor - A QR code is _not_ an Anchor (it's physical) - That spot around where your coffee usually sits can be an Anchor - A semantically labeled floor plane is _not_ an Anchor (it's physical)
---
# class Anchor

An Anchor in StereoKit is a completely virtual pose that is
pinned to a real-world location. They are creatable via code, generally
can persist across sessions, may provide additional stability beyond
the system's 6dof tracking, and are not physical objects!

This functionality is backed by extensions like the Microsoft Spatial
Anchor, or the Facebook Spatial Entity. If a proper anchoring system
isn't present on the device, StereoKit will fall back to a stage-
relative anchor. Stage-relative anchors may be a good solution for
devices with a consistent stage, but may be troublesome if the user
adjusts their stage frequently.

A conceptual guide to Anchors:
- A cloud anchor is an Anchor
- A QR code is _not_ an Anchor (it's physical)
- That spot around where your coffee usually sits can be an Anchor
- A semantically labeled floor plane is _not_ an Anchor (it's physical)

## Instance Fields and Properties

|  |  |
|--|--|
|string [Id]({{site.url}}/Pages/StereoKit/Anchor/Id.html)|Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managine your assets, or finding them later on! This is StereoKit's asset ID, and not the system's unique Name for the anchor.|
|string [Name]({{site.url}}/Pages/StereoKit/Anchor/Name.html)|A unique system provided name identifying this anchor. This will be the same across sessions for persistent Anchors.|
|bool [Persistent]({{site.url}}/Pages/StereoKit/Anchor/Persistent.html)|Will this Anchor persist across multiple app sessions? You can use `TrySetPersistent` to change this value.|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) [Pose]({{site.url}}/Pages/StereoKit/Anchor/Pose.html)|The most recently identified Pose of the Anchor. While an Anchor will generally be in the same position once discovered, it may shift slightly to compensate for drift in the device's 6dof tracking. Anchor Poses when tracked are more accurate than world-space positions.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [Tracked]({{site.url}}/Pages/StereoKit/Anchor/Tracked.html)|Does the device consider this Anchor to be tracked? This doesn't require the Anchor to be visible, just that the device knows where this Anchor is located.|

## Instance Methods

|  |  |
|--|--|
|[TryGetPerceptionAnchor]({{site.url}}/Pages/StereoKit/Anchor/TryGetPerceptionAnchor.html)|Tries to get the underlying perception spatial anchor for platforms using Microsoft spatial anchors.|
|[TrySetPersistent]({{site.url}}/Pages/StereoKit/Anchor/TrySetPersistent.html)|This will attempt to make or prevent this Anchor from persisting across app sessions. You may want to check if the system is capable of persisting anchors via Anchors.Capabilities, but it's possible for this to fail on the OpenXR runtime's side as well.|

## Static Fields and Properties

|  |  |
|--|--|
|IEnumerable`1 [Anchors]({{site.url}}/Pages/StereoKit/Anchor/Anchors.html)|This is an enumeration of all Anchors that exist in StereoKit at the current moment.|
|[AnchorCaps]({{site.url}}/Pages/StereoKit/AnchorCaps.html) [Capabilities]({{site.url}}/Pages/StereoKit/Anchor/Capabilities.html)|This describes the anchoring capabilities of the current XR anchoring backend. Some systems like a HoloLens can create Anchors that provide stability, and can persist across multiple sessions. Some like SteamVR might be able to make a persistent Anchor that's relative to the stage, but doesn't provide any stability benefits.|
|IEnumerable`1 [NewAnchors]({{site.url}}/Pages/StereoKit/Anchor/NewAnchors.html)|This is an enumeration of all Anchors that are new to StereoKit this frame.|

## Static Methods

|  |  |
|--|--|
|[ClearStored]({{site.url}}/Pages/StereoKit/Anchor/ClearStored.html)|This will remove persistence from all Anchors the app knows about, even if they aren't tracked.|
|[FromPose]({{site.url}}/Pages/StereoKit/Anchor/FromPose.html)|This creates a new Anchor from a world space pose.|
