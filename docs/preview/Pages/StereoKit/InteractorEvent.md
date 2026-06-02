---
layout: default
title: InteractorEvent
description: A bit-flag mask for interaction event types. This allows or informs what type of events an interactor can perform, or an element can respond to.
---
# enum InteractorEvent

A bit-flag mask for interaction event types. This allows or informs what type
of events an interactor can perform, or an element can respond to.

## Enum Values

|  |  |
|--|--|
|Grip|Grip events represent the gripping gesture of the hand. This can also map to something like the grip button on a controller. This is generally for larger objects where humans have a tendency to make full fisted grasping motions, like with door handles or sword hilts.|
|Pinch|Pinch events represent the pinching gesture of the hand, where the index finger tip and thumb tip come together. This can also map to something like the trigger button of a controller. This is generally for smaller objects where humans tend to grasp more delicately with just their fingertips, like with a pencil or switches.|
|Poke|Poke events represent direct physical interaction with elements via a single point. This might be like a fingertip pressing a button, or a pencil tip on a page of a paper.|
