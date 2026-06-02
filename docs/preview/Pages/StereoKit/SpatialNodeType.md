---
layout: default
title: SpatialNodeType
description: For use with World.FromSpatialNode, this indicates the type of node that's being bridged with OpenXR.
---
# enum SpatialNodeType

For use with World.FromSpatialNode, this indicates the type of
node that's being bridged with OpenXR.

## Enum Values

|  |  |
|--|--|
|Dynamic|Dynamic spatial nodes track the pose of a physical object that moves continuously relative to reference spaces. The pose of dynamic spatial nodes can be very different within the duration of a rendering frame. It is important for the application to use the correct timestamp to query the space location. For example, a color camera mounted in front of a HMD is also tracked by the HMD so a web camera library can use a dynamic node to represent the camera location.|
|Static|Static spatial nodes track the pose of a fixed location in the world relative to reference spaces. The tracking of static nodes may slowly adjust the pose over time for better accuracy but the pose is relatively stable in the short term, such as between rendering frames. For example, a QR code tracking library can use a static node to represent the location of the tracked QR code.|
