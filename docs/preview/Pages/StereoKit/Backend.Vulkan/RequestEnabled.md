---
layout: default
title: Backend.Vulkan.RequestEnabled
description: Checks if a named request registered via Backend.Vulkan.Request was successfully enabled. This MUST only be called after SK.Initialize.
---
# [Backend.Vulkan]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan.html).RequestEnabled

<div class='signature' markdown='1'>
```csharp
static bool RequestEnabled(string name)
```
Checks if a named request registered via
[`Backend.Vulkan.Request`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html) was successfully enabled. This MUST only be
called after SK.Initialize.
</div>

|  |  |
|--|--|
|string name|The name given to the BackendVulkanRequest.|
|RETURNS: bool|If the request's extensions and features were all enabled.|




