---
layout: default
title: BackendVulkanFeature.BackendVulkanFeature
description: Creates a feature request from a pointer to a pinned VkPhysicalDevice*Features struct and its size in bytes.
---
# [BackendVulkanFeature]({{site.url}}/preview/Pages/StereoKit/BackendVulkanFeature.html).BackendVulkanFeature

<div class='signature' markdown='1'>
```csharp
void BackendVulkanFeature(IntPtr vkStruct, int size)
```
Creates a feature request from a pointer to a pinned
VkPhysicalDevice*Features struct and its size in bytes.
</div>

|  |  |
|--|--|
|IntPtr vkStruct|A pointer to a pinned VkPhysicalDevice*Features struct, with its sType and desired VK_TRUE bits set.|
|int size|The size of the struct vkStruct points at, in bytes.|




