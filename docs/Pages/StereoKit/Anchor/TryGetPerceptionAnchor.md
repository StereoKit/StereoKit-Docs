---
layout: default
title: Anchor.TryGetPerceptionAnchor
description: Tries to get the underlying perception spatial anchor as a COM pointer. Use this when you need the raw IntPtr for interop or custom marshalling.
---
# [Anchor]({{site.url}}/Pages/StereoKit/Anchor.html).TryGetPerceptionAnchor

<div class='signature' markdown='1'>
```csharp
bool TryGetPerceptionAnchor(IntPtr& spatialAnchor)
```
Tries to get the underlying perception spatial anchor as a COM pointer.
Use this when you need the raw IntPtr for interop or custom marshalling.
</div>

|  |  |
|--|--|
|IntPtr& spatialAnchor|The raw COM pointer to the spatial anchor.|
|RETURNS: bool|True if the pointer was successfully obtained, false otherwise.|




