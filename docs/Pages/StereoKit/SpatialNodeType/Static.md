---
layout: default
title: SpatialNodeType.Static
description: Static spatial nodes track the pose of a fixed location in the world relative to reference spaces. The tracking of static nodes may slowly adjust the pose over time for better accuracy but the pose is relatively stable in the short term, such as between rendering frames. For example, a QR code tracking library can use a static node to represent the location of the tracked QR code.
---
# [SpatialNodeType]({{site.url}}/Pages/StereoKit/SpatialNodeType.html).Static

<div class='signature' markdown='1'>
static [SpatialNodeType]({{site.url}}/Pages/StereoKit/SpatialNodeType.html) Static
</div>

## Description
Static spatial nodes track the pose of a fixed location in
the world relative to reference spaces. The tracking of static
nodes may slowly adjust the pose over time for better accuracy but
the pose is relatively stable in the short term, such as between
rendering frames. For example, a QR code tracking library can use a
static node to represent the location of the tracked QR code.

