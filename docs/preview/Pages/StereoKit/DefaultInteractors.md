---
layout: default
title: DefaultInteractors
description: Options for what type of interactors StereoKit provides by default.
---
# enum DefaultInteractors

Options for what type of interactors StereoKit provides by default.

## Enum Values

|  |  |
|--|--|
|All|Auto-switch between hands and controllers based on the current input source. This provides aim, pinch, and poke interactors for hands, and aim rays for controllers.|
|Controllers|Always use the default controller interactors.|
|Default|Use the XR backend's default interactor mode. This is 'all' for XR, 'mouse' for simulator and window, and 'none' for offscreen.|
|Hands|Always use the default hand interactors, using simulated hands when articulated hand tracking is not available.|
|Mouse|Always use the default mouse interactor.|
|None|Don't provide any interactors at all. This means you either don't want interaction, or are providing your own custom interactors.|
