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
|LPalm|The left hand/controller palm pose, located at the surface of the palm. Forward points along the fingers and Up toward the thumb, with X+ into the palm on the right hand, and out of the palm on the left. This is the controller's palm orientation, which faces along the fingers rather than out from the palm. Uses the palm pose OpenXR extension when available, and falls back to an approximation when it's not.|
|LPinch|The left pinch pose, located between the tips of the thumb and index finger. This is provided by hand interaction systems such as the OpenXR hand interaction extension, and may be present even when full articulated hand tracking is not.|
|LPoke|The left poke pose, located at the tip of the index finger. This is provided by hand interaction systems such as the OpenXR hand interaction extension, and may be present even when full articulated hand tracking is not.|
|Max|Total number of input pose types.|
|RAim|The right hand/controller aim pose. This points forward from the hand like a laser pointer, useful for UI interaction at a distance.|
|RDetached|The right pose of a "detached controller", when the user has both hands and controllers active in the scene.|
|RGrip|The right hand/controller grip pose, centered in the hand where you'd hold something like a sword hilt or a tool handle.|
|RPalm|The right hand/controller palm pose, located at the surface of the palm. Forward points along the fingers and Up toward the thumb, with X+ into the palm on the right hand, and out of the palm on the left. This is the controller's palm orientation, which faces along the fingers rather than out from the palm. Uses the palm pose OpenXR extension when available, and falls back to an approximation when it's not.|
|RPinch|The right pinch pose, located between the tips of the thumb and index finger. This is provided by hand interaction systems such as the OpenXR hand interaction extension, and may be present even when full articulated hand tracking is not.|
|RPoke|The right poke pose, located at the tip of the index finger. This is provided by hand interaction systems such as the OpenXR hand interaction extension, and may be present even when full articulated hand tracking is not.|
