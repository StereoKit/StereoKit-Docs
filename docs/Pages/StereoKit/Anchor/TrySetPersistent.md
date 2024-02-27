---
layout: default
title: Anchor.TrySetPersistent
description: This will attempt to make or prevent this Anchor from persisting across app sessions. You may want to check if the system is capable of persisting anchors via Anchors.Capabilities, but it's possible for this to fail on the OpenXR runtime's side as well.
---
# [Anchor]({{site.url}}/Pages/StereoKit/Anchor.html).TrySetPersistent

<div class='signature' markdown='1'>
```csharp
bool TrySetPersistent(bool persistent)
```
This will attempt to make or prevent this Anchor from
persisting across app sessions. You may want to check if the system
is capable of persisting anchors via Anchors.Capabilities, but it's
possible for this to fail on the OpenXR runtime's side as well.
</div>

|  |  |
|--|--|
|bool persistent|Whether this should or shouldn't persist             across sessions.|
|RETURNS: bool|Success or failure of setting persistence.|




