---
layout: default
title: UIGesture
description: This is a bit flag that describes different types and combinations of gestures used within the UI system.
---
# enum UIGesture

This is a bit flag that describes different types and
combinations of gestures used within the UI system.

## Enum Values

|  |  |
|--|--|
|Grip|A gripping or grasping motion meant to represent a full hand grab. This is calculated using the distance between the root and the tip of the ring finger.|
|None|Default zero state, no gesture at all.|
|Pinch|A pinching action, calculated by taking the distance between the tip of the thumb and the index finger.|
|PinchGrip|This is a bit flag combination of both Pinch and Grip.|
