---
layout: default
title: PermissionState
description: Permissions can be in a variety of states, depending on how users interact with them. Sometimes they're automatically granted, user denied, or just unknown for the current runtime!
---
# enum PermissionState

Permissions can be in a variety of states, depending on how users interact
with them. Sometimes they're automatically granted, user denied, or just
unknown for the current runtime!

## Enum Values

|  |  |
|--|--|
|Capable|This app is capable of using the permission, but it needs to be requested first with Permission.Request.|
|Granted|This permission is entirely approved and you can go ahead and use the associated features!|
|Unavailable|This permission is known to StereoKit, but not available to request. Typically this means the correct permission string is not listed in the AndroidManfiest.xml or similar.|
|Unknown|StereoKit doesn't know about the permission on the current runtime. This happens when the runtime has a unique permission string (or not) and StereoKit doesn't know what it is to look up its current status.|
