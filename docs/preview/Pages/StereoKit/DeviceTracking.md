---
layout: default
title: DeviceTracking
description: What type of user motion is the device capable of tracking? For the normal fully capable XR headset, this should be 6dof (rotation and translation), but more limited headsets may be restricted to 3dof (rotation) and flatscreen computers with the simulator off would be none.
---
# enum DeviceTracking

What type of user motion is the device capable of tracking? For the normal
fully capable XR headset, this should be 6dof (rotation and translation), but
more limited headsets may be restricted to 3dof (rotation) and flatscreen
computers with the simulator off would be none.

## Enum Values

|  |  |
|--|--|
|DoF3|This tracks rotation only, this may be a limited device without tracking cameras, or could be a more capable headset in a 3dof mode. DoF stands for Degrees of Freedom.|
|DoF6|This is capable of tracking both the position and rotation of the device, most fully featured XR headsets (such as a HoloLens 2) will have this. DoF stands for Degrees of Freedom.|
|None|No tracking is available! This is likely a flatscreen application, not an XR applicaion.|
