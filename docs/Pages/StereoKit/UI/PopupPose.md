---
layout: default
title: UI.PopupPose
description: This creates a Pose that is friendly towards UI popup windows, or windows that are created due to some type of user interaction. The fallback file picker and soft keyboard both use this function to position themselves!
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).PopupPose

<div class='signature' markdown='1'>
```csharp
static Pose PopupPose(Vec3 shift)
```
This creates a Pose that is friendly towards UI popup
windows, or windows that are created due to some type of user
interaction. The fallback file picker and soft keyboard both use
this function to position themselves!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) shift|A positional shift from the default location,             this is useful to account for the height of the window, and center             or offset this pose. A value of [0,-0.1,0] may be a good starting             point.|
|RETURNS: [Pose]({{site.url}}/Pages/StereoKit/Pose.html)|A pose between the UI or hand that is currently active, and the user's head. Good for popup windows.|




