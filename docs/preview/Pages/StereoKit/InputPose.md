---
layout: default
title: InputPose
description: Index values for input poses. These represent tracked spatial poses from the XR system, such as hand or controller positions and orientations.
---
# enum InputPose

Index values for input poses. These represent tracked spatial poses
from the XR system, such as hand or controller positions and
orientations.

## Enum Values

|  |  |
|--|--|
|Eyes|The user's eye gaze, where they're looking in the world. Requires eye tracking hardware and permissions to provide meaningful data.|
|LAim|The left hand/controller aim pose. This points forward from the hand like a laser pointer, useful for UI interaction at a distance.|
|LDetached|The left pose of a "detached controller", when the user has both hands and controllers active in the scene.|
|LGrip|The left hand/controller grip pose, centered in the hand where you'd hold something like a sword hilt or a tool handle.|
|LPalm|The left hand/controller palm pose, located at the surface of the palm facing outward. This uses the palm pose OpenXR extension when available, and falls back to an approximation when it's not.|
|Max|Total number of input pose types.|
|RAim|The right hand/controller aim pose. This points forward from the hand like a laser pointer, useful for UI interaction at a distance.|
|RDetached|The right pose of a "detached controller", when the user has both hands and controllers active in the scene.|
|RGrip|The right hand/controller grip pose, centered in the hand where you'd hold something like a sword hilt or a tool handle.|
|RPalm|The right hand/controller palm pose, located at the surface of the palm facing outward. This uses the palm pose OpenXR extension when available, and falls back to an approximation when it's not.|
