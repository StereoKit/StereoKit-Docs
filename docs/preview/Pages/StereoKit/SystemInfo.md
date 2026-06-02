---
layout: default
title: SystemInfo
description: Information about a system's capabilities and properties!
---
# struct SystemInfo

Information about a system's capabilities and properties!

## Instance Fields and Properties

|  |  |
|--|--|
|int [displayHeight]({{site.url}}/preview/Pages/StereoKit/SystemInfo/displayHeight.html)|Height of the display surface, in pixels! For a stereo display, this will be the height of a single eye.|
|[DisplayBlend]({{site.url}}/preview/Pages/StereoKit/DisplayBlend.html) [displayType]({{site.url}}/preview/Pages/StereoKit/SystemInfo/displayType.html)|Obsolete, please use Device.DisplayBlend|
|int [displayWidth]({{site.url}}/preview/Pages/StereoKit/SystemInfo/displayWidth.html)|Width of the display surface, in pixels! For a stereo display, this will be the width of a single eye.|
|bool [eyeTrackingPresent]({{site.url}}/preview/Pages/StereoKit/SystemInfo/eyeTrackingPresent.html)|Does the device we're on have eye tracking support present for input purposes? This is _not_ an indicator that the user has given the application permission to access this information. See `Input.Gaze` for how to use this data.|
|bool [overlayApp]({{site.url}}/preview/Pages/StereoKit/SystemInfo/overlayApp.html)|This tells if the app was successfully started as an overlay application. If this is true, then expect this application to be composited with other content below it!|
|bool [perceptionBridgePresent]({{site.url}}/preview/Pages/StereoKit/SystemInfo/perceptionBridgePresent.html)|Can the device work with externally provided spatial anchors, like UWP's `Windows.Perception.Spatial.SpatialAnchor`|
|bool [spatialBridgePresent]({{site.url}}/preview/Pages/StereoKit/SystemInfo/spatialBridgePresent.html)|Does the device we're currently on have the spatial graph bridge extension? The extension is provided through the function `World.FromSpatialNode`. This allows OpenXR to talk with certain windows APIs, such as the QR code API that provides Graph Node GUIDs for the pose.|
|bool [worldOcclusionPresent]({{site.url}}/preview/Pages/StereoKit/SystemInfo/worldOcclusionPresent.html)|Does this device support world occlusion of digital objects? If this is true, then World.OcclusionEnabled can be set to true, and World.OcclusionMaterial can be modified.|
|bool [worldRaycastPresent]({{site.url}}/preview/Pages/StereoKit/SystemInfo/worldRaycastPresent.html)|Can this device get ray intersections from the environment? If this is true, then World.RaycastEnabled can be set to true, and World.Raycast can be used.|
