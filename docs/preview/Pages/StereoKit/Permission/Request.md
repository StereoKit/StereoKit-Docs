---
layout: default
title: Permission.Request
description: This sends off a request to the OS for a particular permission! If the permission IsInteractive, then this will bring up a popup that the user may need to interact with. Otherwise, this will silently approve the permission. This means that the permission may take an arbitrary amount of time before it's approved, or declined.  If your app is an Android Service, this function will do nothing.
---
# [Permission]({{site.url}}/preview/Pages/StereoKit/Permission.html).Request

<div class='signature' markdown='1'>
```csharp
static void Request(PermissionType permission)
```
This sends off a request to the OS for a particular
permission! If the permission IsInteractive, then this will bring
up a popup that the user may need to interact with. Otherwise, this
will silently approve the permission. This means that the
permission may take an arbitrary amount of time before it's
approved, or declined.

If your app is an Android Service, this function will do nothing.
</div>

|  |  |
|--|--|
|[PermissionType]({{site.url}}/preview/Pages/StereoKit/PermissionType.html) permission|The permission to request.|




