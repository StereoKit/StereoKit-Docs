---
layout: default
title: BackendVulkanFeature.vkStruct
description: A pointer to a pinned VkPhysicalDevice*Features struct with its sType set, and the feature bits you want enabled set to VK_TRUE. This must NOT be a VkPhysicalDeviceFeatures2. The pointer only needs to remain valid for the duration of the Backend.Vulkan.Request call.
---
# [BackendVulkanFeature]({{site.url}}/preview/Pages/StereoKit/BackendVulkanFeature.html).vkStruct

<div class='signature' markdown='1'>
IntPtr vkStruct
</div>

## Description
A pointer to a pinned VkPhysicalDevice*Features struct with
its sType set, and the feature bits you want enabled set to VK_TRUE.
This must NOT be a VkPhysicalDeviceFeatures2. The pointer only needs
to remain valid for the duration of the Backend.Vulkan.Request call.

