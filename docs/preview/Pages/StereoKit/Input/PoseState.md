---
layout: default
title: Input.PoseState
description: Gets the tracking state of a tracked pose. This tells you whether the position and rotation components are actively being tracked by the XR system, and at what quality.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).PoseState

<div class='signature' markdown='1'>
```csharp
static PoseState PoseState(InputPose poseType)
```
Gets the tracking state of a tracked pose. This tells
you whether the position and rotation components are actively
being tracked by the XR system, and at what quality.
</div>

|  |  |
|--|--|
|[InputPose]({{site.url}}/preview/Pages/StereoKit/InputPose.html) poseType|The type of pose to check tracking state for.|
|RETURNS: [PoseState]({{site.url}}/preview/Pages/StereoKit/PoseState.html)|A PoseState flags value indicating which components are tracked and whether they are inferred or known.|




