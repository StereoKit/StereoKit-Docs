---
layout: default
title: Permission.IsInteractive
description: Does this permission need the user to approve it? This typically means a popup window will come up when you Request this permission, and the user has a chance to decline it.  If your app is an Android Service, this only reflects the Dangerous status of the permission.
---
# [Permission]({{site.url}}/preview/Pages/StereoKit/Permission.html).IsInteractive

<div class='signature' markdown='1'>
```csharp
static bool IsInteractive(PermissionType permission)
```
Does this permission need the user to approve it? This
typically means a popup window will come up when you Request this
permission, and the user has a chance to decline it.

If your app is an Android Service, this only reflects the Dangerous
status of the permission.
</div>

|  |  |
|--|--|
|[PermissionType]({{site.url}}/preview/Pages/StereoKit/PermissionType.html) permission|The permission you're interested in.|
|RETURNS: bool|True if the permission requires user interaction, false otherwise.|




