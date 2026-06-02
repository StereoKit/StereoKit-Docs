---
layout: default
title: HandSource
description: This enum provides information about StereoKit's hand tracking data source. It allows you to distinguish between true hand data such as that provided by a Leap Motion Controller, and simulated data that StereoKit provides when true hand data is not present.
---
# enum HandSource

This enum provides information about StereoKit's hand tracking data source.
It allows you to distinguish between true hand data such as that provided by
a Leap Motion Controller, and simulated data that StereoKit provides when
true hand data is not present.

## Enum Values

|  |  |
|--|--|
|Articulated|This is true hand data which exhibits the full range of motion of a normal hand. It is backed by something like a Leap Motion Controller, or some other optical (or maybe glove?) hand tracking system.|
|None|There is currently no source of hand data! This means there are no tracked controllers, or active hand tracking systems. This may happen if the user has hand tracking disabled, and no active controllers.|
|Overridden|This hand data is provided by your use of SK's override functionality. What properties it exhibits depends on what override data you're sending to StereoKit!|
|Simulated|The current hand data is a simulation of hand data rather than true hand data. It is backed by either a controller, or a mouse, and may have a more limited range of motion.|
