---
layout: default
title: StandbyMode
description: When the device StereoKit is running on goes into standby mode, how should StereoKit react? Typically the app should pause, stop playing sound, and consume as little power as possible, but some scenarios such as multiplayer games may need the app to continue running.
---
# enum StandbyMode

When the device StereoKit is running on goes into standby mode, how should
StereoKit react? Typically the app should pause, stop playing sound, and
consume as little power as possible, but some scenarios such as multiplayer
games may need the app to continue running.

## Enum Values

|  |  |
|--|--|
|Default|This will let StereoKit pick a mode based on its own preferences. On v0.3 and lower, this will be Slow, and on v0.4 and higher, this will be Pause.|
|None|The main thread will continue to execute, but with a very short sleep each frame. This allows the app to continue polling and processing, but without flooding the CPU with polling work while vsync is no longer the throttle. This will not disable sound.|
|Pause|The entire main thread will pause, and wait until the device has come out of standby. This is the most power efficient mode for the device to take when the device is in standby, and is recommended for the vast majority of apps. This will also disable sound.|
|Slow|The main thread will continue to execute, but with 100ms sleeps each frame. This allows the app to continue polling and processing, but reduces power consumption by throttling a bit. This will not disable sound. In the Simulator, this will behave as Slow.|
