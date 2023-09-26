---
layout: default
title: Input.HandSimPoseAdd
description: StereoKit will use controller inputs to simulate an articulated hand. This function allows you to add new simulated poses to different controller or keyboard buttons!
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).HandSimPoseAdd

<div class='signature' markdown='1'>
```csharp
static HandSimId HandSimPoseAdd(Pose[] handJointsPalmRelative25, ControllerKey button1, ControllerKey andButton2, Key orHotkey1, Key andHotkey2)
```
StereoKit will use controller inputs to simulate an
articulated hand. This function allows you to add new simulated
poses to different controller or keyboard buttons!
</div>

|  |  |
|--|--|
|Pose[] handJointsPalmRelative25|25 joint poses, thumb to pinky, and root             to tip with two duplicate poses for the thumb root joint. These             should be right handed, and relative to the palm joint.|
|[ControllerKey]({{site.url}}/Pages/StereoKit/ControllerKey.html) button1|Controller button to activate this pose, can             be None if this is a keyboard only pose.|
|[ControllerKey]({{site.url}}/Pages/StereoKit/ControllerKey.html) andButton2|Second controller button required to             activate this pose. First must also be pressed. Can be None if it's             only a single button pose.|
|[Key]({{site.url}}/Pages/StereoKit/Key.html) orHotkey1|Keyboard key to activate this pose, can be             None if this is a controller only pose.|
|[Key]({{site.url}}/Pages/StereoKit/Key.html) andHotkey2|Second keyboard key required to activate             this pose. First must also be pressed. Can be None if it's only a             single key pose.|
|RETURNS: [HandSimId]({{site.url}}/Pages/StereoKit/HandSimId.html)|Returns the id of the hand sim pose, so it can be removed later.|




