---
layout: default
title: Mouse
description: This stores information about the mouse! What's its state, where's it pointed, do we even have one?
---
# struct Mouse

This stores information about the mouse! What's its state, where's it
pointed, do we even have one?

## Instance Fields and Properties

|  |  |
|--|--|
|bool [available]({{site.url}}/preview/Pages/StereoKit/Mouse/available.html)|Is the mouse available to use? Most MR systems likely won't have a mouse!|
|[Vec2]({{site.url}}/preview/Pages/StereoKit/Vec2.html) [pos]({{site.url}}/preview/Pages/StereoKit/Mouse/pos.html)|Position of the mouse relative to the window it's in! This is the number of pixels from the top left corner of the screen.|
|[Vec2]({{site.url}}/preview/Pages/StereoKit/Vec2.html) [posChange]({{site.url}}/preview/Pages/StereoKit/Mouse/posChange.html)|How much has the mouse's position changed in the current frame? Measured in pixels.|
|[Ray]({{site.url}}/preview/Pages/StereoKit/Ray.html) [Ray]({{site.url}}/preview/Pages/StereoKit/Mouse/Ray.html)|Ray representing the position and orientation that the current Input.Mouse.pos is pointing in.|
|float [scroll]({{site.url}}/preview/Pages/StereoKit/Mouse/scroll.html)|What's the current scroll value for the mouse's scroll wheel?|
|float [scrollChange]({{site.url}}/preview/Pages/StereoKit/Mouse/scrollChange.html)|How much has the scroll wheel value changed during this frame?|
