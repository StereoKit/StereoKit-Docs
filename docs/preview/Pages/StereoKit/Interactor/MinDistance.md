---
layout: default
title: Interactor.MinDistance
description: The distance at which a ray starts being interactive. For pointing rays, you may not want them to interact right at their start, or you may want the start to move depending on how outstretched the hand is! This allows you to change that start location without affecting the movement caused by the ray, and still capturing occlusion from blocking elements too close to the start. By default, this is a large negative value.
---
# [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html).MinDistance

<div class='signature' markdown='1'>
float MinDistance{ get set }
</div>

## Description
The distance at which a ray starts being interactive. For
pointing rays, you may not want them to interact right at their
start, or you may want the start to move depending on how
outstretched the hand is! This allows you to change that start
location without affecting the movement caused by the ray, and
still capturing occlusion from blocking elements too close to the
start. By default, this is a large negative value.

