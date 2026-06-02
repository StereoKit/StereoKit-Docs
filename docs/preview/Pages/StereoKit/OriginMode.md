---
layout: default
title: OriginMode
description: This describes where the origin of the application should be. While these origins map closely to OpenXR features, not all runtimes support each feature. StereoKit will provide reasonable fallback behavior in the event the origin mode isn't directly supported.
---
# enum OriginMode

This describes where the origin of the application should be. While these
origins map closely to OpenXR features, not all runtimes support each
feature. StereoKit will provide reasonable fallback behavior in the event the
origin mode isn't directly supported.

## Enum Values

|  |  |
|--|--|
|Floor|The origin will be at the floor beneath where the user starts, facing the direction of the user. If this mode is not natively supported, StereoKit will use the stage mode with an offset. If stage mode is unavailable, it will fall back to local mode with a -1.5 Y axis offset.|
|Local|The origin will be at the location of the user's head when the application starts, facing the same direction as the user. This mode is available on all runtimes, and will never fall back to another mode! However, due to variances in underlying behavior, StereoKit may introduce an origin offset to ensure consistent behavior.|
|Stage|The origin will be at the center of a safe play area or stage that the user or OS has defined, and will face one of the edges of the play area. If this mode is not natively supported, StereoKit will use the floor origin mode. If floor mode is unavailable, it will fall back to local mode with a -1.5 Y axis offset.|
