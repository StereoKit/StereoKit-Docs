---
layout: default
title: BackendVulkanQueue
description: Identifies a Vulkan queue family that StereoKit's Vulkan backend interacts with. Use this with the queue accessors on Backend.Vulkan.
---
# enum BackendVulkanQueue

Identifies a Vulkan queue family that StereoKit's Vulkan backend interacts
with. Use this with the queue accessors on Backend.Vulkan.

## Enum Values

|  |  |
|--|--|
|Graphics|The primary graphics queue. This is the queue StereoKit submits all of its rendering work to, and the only queue with a handle currently available via backend_vulkan_get_queue.|
|Transfer|A queue family suitable for transfer operations. StereoKit does not yet use a dedicated transfer queue, so no queue handle is available here yet, but the family index is provided for advanced interop.|
|VideoDecode|A queue family suitable for Vulkan video decode. Not present on all devices, in which case the family index will be UINT32_MAX.|
