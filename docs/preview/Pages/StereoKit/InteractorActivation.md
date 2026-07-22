---
layout: default
title: InteractorActivation
description: This describes how an interactor commits an interaction with an element - does it activate from the physical position of the interactor (like a finger poking through a button), or from its activation/button state (like a pinch or a trigger click)? This is independent of InteractorType, which describes the interactor's shape rather than what triggers it.
---
# enum InteractorActivation

This describes how an interactor commits an interaction with an element - does
it activate from the physical position of the interactor (like a finger poking
through a button), or from its activation/button state (like a pinch or a
trigger click)? This is independent of `InteractorType`, which describes the
interactor's shape rather than what triggers it.

## Enum Values

|  |  |
|--|--|
|Position|This interactor uses its motion position to determine the element activation.|
|State|This interactor uses its `active` state to determine element activation.|
