---
layout: default
title: PermissionType
description: A list of permissions that StereoKit knows about. On some platforms (like Android), these permissions may need to be explicitly requested before using certain features.
---
# enum PermissionType

A list of permissions that StereoKit knows about. On some platforms (like
Android), these permissions may need to be explicitly requested before using
certain features.

## Enum Values

|  |  |
|--|--|
|Camera|For access to camera data, this is typically an interactive permission that the user will need to explicitly approve. SK doesn't use this permission internally yet, but is often a useful permission for XR apps. This maps to android.permission.CAMERA on Android.|
|EyeInput|For access to input quality eye tracking data, this is typically an interactive permission that the user will need to explicitly approve. This maps to android.permission.EYE_TRACKING_FINE on Android XR, but varies per-runtime.|
|FaceTracking|For access to facial expression data, this is typically an interactive permission that the user will need to explicitly approve. This maps to android.permission.FACE_TRACKING on Android XR, but varies per-runtime.|
|HandTracking|For access to per-joint hand tracking data. Some runtimes may have this permission interactive, but many do not. This maps to android.permission.HAND_TRACKING on Android XR, but varies per-runtime.|
|Max|This enum is for tracking the number of value in this enum.|
|Microphone|For access to microphone data, this is typically an interactive permission that the user will need to explicitly approve. This maps to android.permission.RECORD_AUDIO on Android.|
|Scene|For access to data in the user's space, this can be for things like spatial anchors, plane detection, hit testing, etc. This is typically an interactive permission that the user will need to explicitly approve. This maps to android.permission.SCENE_UNDERSTANDING_COARSE on Android XR, but varies per-runtime.|
