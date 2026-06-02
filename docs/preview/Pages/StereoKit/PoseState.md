---
layout: default
title: PoseState
description: A bit-flag describing the tracking state of a pose, with separate bits for position and orientation. The PosAny, RotAny, and Any combinations are handy when you only care if there's tracking at all, and not whether it's directly measured or just an educated guess.
---
# enum PoseState

A bit-flag describing the tracking state of a pose, with separate
bits for position and orientation. The PosAny, RotAny, and Any
combinations are handy when you only care if there's tracking at
all, and not whether it's directly measured or just an educated
guess.

## Enum Values

|  |  |
|--|--|
|Any|Matches any tracking at all, on position or orientation. A pose with no overlap with this is fully lost.|
|Lost|The pose has no tracking at all, neither position nor orientation should be trusted.|
|PosAny|Matches any positional tracking, whether the position is directly known or just inferred.|
|PosInferred|The position isn't directly tracked, but the system has an educated guess for it. For example, a controller's accelerometer can keep dead-reckoning the position for a short time after it leaves optical view.|
|PosKnown|The position is actively tracked by the underlying hardware, to the best of its ability.|
|RotAny|Matches any orientation tracking, whether the orientation is directly known or just inferred.|
|RotInferred|The orientation isn't directly tracked, but the system has an educated guess for it, often from an IMU after the source has left direct view.|
|RotKnown|The orientation is actively tracked by the underlying hardware, to the best of its ability.|
