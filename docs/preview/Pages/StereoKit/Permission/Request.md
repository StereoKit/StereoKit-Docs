---
layout: default
title: Permission.Request
description: This sends off a request to the OS for one or more permissions! If a permission IsInteractive, then this will bring up a popup that the user may need to interact with. Otherwise, this will silently approve the permission. This means that the permission may take an arbitrary amount of time before it's approved, or declined.  Requesting multiple permissions in a single call is preferable to chaining individual requests yourself, since the OS gets to present them together and you avoid the risk of a follow-up request getting dropped while an earlier popup is still up.  Any permissions that aren't known on the current platform are skipped with a warning. If your app is an Android Service, this function will do nothing.
---
# [Permission]({{site.url}}/preview/Pages/StereoKit/Permission.html).Request

<div class='signature' markdown='1'>
```csharp
static void Request(PermissionType[] permissions)
```
This sends off a request to the OS for one or more
permissions! If a permission IsInteractive, then this will bring
up a popup that the user may need to interact with. Otherwise, this
will silently approve the permission. This means that the
permission may take an arbitrary amount of time before it's
approved, or declined.

Requesting multiple permissions in a single call is preferable to
chaining individual requests yourself, since the OS gets to present
them together and you avoid the risk of a follow-up request getting
dropped while an earlier popup is still up.

Any permissions that aren't known on the current platform are
skipped with a warning. If your app is an Android Service, this
function will do nothing.
</div>

|  |  |
|--|--|
|PermissionType[] permissions|The permission(s) to request.|




