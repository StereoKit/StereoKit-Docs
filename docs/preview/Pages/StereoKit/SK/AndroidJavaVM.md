---
layout: default
title: SK.AndroidJavaVM
description: On Android systems, this is the pointer to the JavaVM object. If not set, StereoKit will attempt to find it at runtime via JNI_GetCreatedJavaVMs, but this may fail on Android API 24-30 due to linker namespace restrictions. Setting this ensures compatibility across all Android versions.
---
# [SK]({{site.url}}/preview/Pages/StereoKit/SK.html).AndroidJavaVM

<div class='signature' markdown='1'>
static IntPtr AndroidJavaVM{ get set }
</div>

## Description
On Android systems, this is the pointer to the JavaVM
object. If not set, StereoKit will attempt to find it at runtime
via JNI_GetCreatedJavaVMs, but this may fail on Android API 24-30
due to linker namespace restrictions. Setting this ensures
compatibility across all Android versions.

