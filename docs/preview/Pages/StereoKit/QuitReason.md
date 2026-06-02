---
layout: default
title: QuitReason
description: Provides a reason on why StereoKit has quit.
---
# enum QuitReason

Provides a reason on why StereoKit has quit.

## Enum Values

|  |  |
|--|--|
|Error|Some runtime error occurred, causing the application to quit gracefully.|
|InitializationFailed|If initialization failed, StereoKit won't run to begin with!|
|None|Default state when SK has not quit.|
|SessionLost|The runtime under StereoKit has encountered an issue and has been lost.|
|User|The user (or possibly the OS) has explicitly asked to exit the application under normal circumstances.|
