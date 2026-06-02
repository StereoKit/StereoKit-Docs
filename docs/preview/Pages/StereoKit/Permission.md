---
layout: default
title: Permission
description: Certain features in XR require explicit permissions from the operating system and user! This is typically for features that surface sensitive data like eye gaze, or objects in the user's room. This is often complicated by the fact that permissions aren't standardized across XR runtimes, making these permissions fragile and a pain to work with.  This class attempts to manage feature permissions in a nice cross-platform manner that handles runtime specific differences. You will still need to add permission strings to your app's metadata file (like AndroidManifest.xml), but this class will handle figuring out which strings in the metadata to actually use.  On Android, if you use a Service or Context instead of an Activity for your app (unusual), StereoKit will not be able to manage permissions for you!  On platforms that don't use permissions, like Win32 or Linux, these functions will behave as though everything is granted automatically.
---
# static class Permission

Certain features in XR require explicit permissions from the
operating system and user! This is typically for features that surface
sensitive data like eye gaze, or objects in the user's room. This is
often complicated by the fact that permissions aren't standardized
across XR runtimes, making these permissions fragile and a pain to work
with.

This class attempts to manage feature permissions in a nice
cross-platform manner that handles runtime specific differences. You
will still need to add permission strings to your app's metadata file
(like AndroidManifest.xml), but this class will handle figuring out
which strings in the metadata to actually use.

On Android, if you use a Service or Context instead of an Activity for
your app (unusual), StereoKit will not be able to manage permissions
for you!

On platforms that don't use permissions, like Win32 or Linux, these
functions will behave as though everything is granted automatically.

## Static Methods

|  |  |
|--|--|
|[IsInteractive]({{site.url}}/preview/Pages/StereoKit/Permission/IsInteractive.html)|Does this permission need the user to approve it? This typically means a popup window will come up when you Request this permission, and the user has a chance to decline it.  If your app is an Android Service, this only reflects the Dangerous status of the permission.|
|[Request]({{site.url}}/preview/Pages/StereoKit/Permission/Request.html)|This sends off a request to the OS for a particular permission! If the permission IsInteractive, then this will bring up a popup that the user may need to interact with. Otherwise, this will silently approve the permission. This means that the permission may take an arbitrary amount of time before it's approved, or declined.  If your app is an Android Service, this function will do nothing.|
|[State]({{site.url}}/preview/Pages/StereoKit/Permission/State.html)|Retreives the current state of a particular permission. This is a fast check, so it's fine to call frequently.|
