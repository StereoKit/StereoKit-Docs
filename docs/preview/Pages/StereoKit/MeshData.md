---
layout: default
title: MeshData
description: Bit-flags for controlling mesh data upload behavior.
---
# enum MeshData

Bit-flags for controlling mesh data upload behavior.

## Enum Values

|  |  |
|--|--|
|Async|Upload mesh data asynchronously on a background thread. The mesh will be skipped during rendering until the upload completes.|
|CalcBounds|Calculate mesh bounds from the provided vertices.|
|None|No special behavior. Mesh data will be uploaded synchronously with no bounds calculation.|
