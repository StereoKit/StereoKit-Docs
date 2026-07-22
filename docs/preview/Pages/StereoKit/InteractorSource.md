---
layout: default
title: InteractorSource
description: A bit-flag describing the physical source an interactor's input comes from, such as a specific hand, controller, or the mouse. Interactors that share a source are mutually exclusive. while one is actively interacting, the others won't begin a new interaction. This is how the poke, pinch, and aim interactors of a single hand avoid fighting over the same element. The bits at and above InteractorSource.Max are free for your own custom sources.
---
# enum InteractorSource

A bit-flag describing the physical source an interactor's input comes from,
such as a specific hand, controller, or the mouse. Interactors that share a
source are mutually exclusive: while one is actively interacting, the others
won't begin a new interaction. This is how the poke, pinch, and aim
interactors of a single hand avoid fighting over the same element. The bits
at and above `InteractorSource.Max` are free for your own custom sources.

## Enum Values

|  |  |
|--|--|
|Any|Matches with all sources!|
|ControllerLeft|The left motion controller.|
|ControllerRight|The right motion controller.|
|Gaze|Gaze or eye tracking based input.|
|HandLeft|The left hand.|
|HandRight|The right hand.|
|Max|The first bit available for your own custom interactor sources. Bits at and above this are unused by StereoKit, so you can define your own relative to it, for example `(InteractorSource)((int)InteractorSource.Max << 1)`.|
|Mouse|A mouse pointer.|
|Unique|A unique, independent source. Interactors with this source never group with any other interactor, and are invisible to source queries like `Interactor.IsInteracting`. This is the default 'shares nothing' source.|
