---
layout: default
title: InteractorType
description: Should this interactor behave like a single point in space interacting with elements? Or should it behave more like an intangible line? Hit detection is still capsule shaped, but behavior may change a little to reflect the primary position of the point interactor. This can also be thought of as direct interaction vs indirect interaction.
---
# enum InteractorType

Should this interactor behave like a single point in space interacting with
elements? Or should it behave more like an intangible line? Hit detection is
still capsule shaped, but behavior may change a little to reflect the primary
position of the point interactor. This can also be thought of as direct
interaction vs indirect interaction.

## Enum Values

|  |  |
|--|--|
|Line|The interactor represents a less tangible line or ray of interaction, such as a laser pointer or eye gaze. Lines will occasionally consider the directionality of the interactor to discard backpressing certain elements,and use distance along the line for occluding elements that are behind other elements.|
|Point|The interactor represents a physical point in space, such as a fingertip or the point of a pencil. Points do not use directionality for their interactions, nor do they take into account the distance of an element along the 'ray' of the capsule.|
