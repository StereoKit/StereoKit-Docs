---
layout: default
title: Backend.Vulkan.Request
description: Registers a request for Vulkan instance/device extensions and device features. This MUST be called before SK.Initialize. A request enables atomically. only when all of its extensions are present, and every requested feature bit is supported. If BackendVulkanRequest.required is true and the request can't be satisfied, SK.Initialize will fail! After initialization, check the result with Backend.Vulkan.RequestEnabled (by name) or Backend.Vulkan.ExtEnabled (by extension name).
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).Request

<div class='signature' markdown='1'>
```csharp
static void Request(BackendVulkanRequest request)
```
Registers a request for Vulkan instance/device
extensions and device features. This MUST be called before
SK.Initialize. A request enables atomically: only when all of
its extensions are present, and every requested feature bit is
supported. If [`BackendVulkanRequest.required`]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest/required.html) is true
and the request can't be satisfied, SK.Initialize will fail!
After initialization, check the result with
[`Backend.Vulkan.RequestEnabled`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/RequestEnabled.html) (by name) or [`Backend.Vulkan.ExtEnabled`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/ExtEnabled.html)
(by extension name).
</div>

|  |  |
|--|--|
|[BackendVulkanRequest]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest.html) request|The extensions and features to request. Its arrays and feature struct pointers only need to remain valid for the duration of this call - StereoKit copies everything it needs.|




