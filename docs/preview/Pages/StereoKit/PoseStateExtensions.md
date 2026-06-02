---
layout: default
title: PoseStateExtensions
description: A collection of extension methods for the PoseState enum that makes bit-field checks a little easier.
---
# static class PoseStateExtensions

A collection of extension methods for the PoseState enum that
makes bit-field checks a little easier.

## Static Methods

|  |  |
|--|--|
|[IsPosInferred]({{site.url}}/preview/Pages/StereoKit/PoseStateExtensions/IsPosInferred.html)|Is the position an educated guess rather than directly tracked?|
|[IsPosKnown]({{site.url}}/preview/Pages/StereoKit/PoseStateExtensions/IsPosKnown.html)|Is the position actively tracked by the hardware?|
|[IsRotInferred]({{site.url}}/preview/Pages/StereoKit/PoseStateExtensions/IsRotInferred.html)|Is the orientation an educated guess rather than directly tracked?|
|[IsRotKnown]({{site.url}}/preview/Pages/StereoKit/PoseStateExtensions/IsRotKnown.html)|Is the orientation actively tracked by the hardware?|
|[IsTracked]({{site.url}}/preview/Pages/StereoKit/PoseStateExtensions/IsTracked.html)|Is the pose tracked at all, on either position or orientation?|
