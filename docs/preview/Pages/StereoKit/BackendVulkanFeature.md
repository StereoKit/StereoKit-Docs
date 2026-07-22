---
layout: default
title: BackendVulkanFeature
description: A single Vulkan feature struct to request as part of a BackendVulkanRequest. See Backend.Vulkan.Request for details.
---
# struct BackendVulkanFeature

A single Vulkan feature struct to request as part of a
[`BackendVulkanRequest`]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest.html). See
[`Backend.Vulkan.Request`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html) for details.

## Instance Fields and Properties

|  |  |
|--|--|
|int [size]({{site.url}}/preview/Pages/StereoKit/BackendVulkanFeature/size.html)|The size of the struct vkStruct points at, in bytes.|
|IntPtr [vkStruct]({{site.url}}/preview/Pages/StereoKit/BackendVulkanFeature/vkStruct.html)|A pointer to a pinned VkPhysicalDevice*Features struct with its sType set, and the feature bits you want enabled set to VK_TRUE. This must NOT be a VkPhysicalDeviceFeatures2. The pointer only needs to remain valid for the duration of the Backend.Vulkan.Request call.|

## Instance Methods

|  |  |
|--|--|
|[BackendVulkanFeature]({{site.url}}/preview/Pages/StereoKit/BackendVulkanFeature/BackendVulkanFeature.html)|Creates a feature request from a pointer to a pinned VkPhysicalDevice*Features struct and its size in bytes.|
