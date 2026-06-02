---
layout: default
title: AnchorCaps
description: This is a bit flag that describes what an anchoring system is capable of doing.
---
# enum AnchorCaps

This is a bit flag that describes what an anchoring system is capable of
doing.

## Enum Values

|  |  |
|--|--|
|Stability|This anchor system will provide extra accuracy in locating the Anchor, so if the SLAM/6dof tracking drifts over time or distance, the anchor may remain fixed in the correct physical space, instead of drifting with the virtual content.|
|Storable|This anchor system can store/persist anchors across sessions. Anchors must still be explicitly marked as persistent.|
