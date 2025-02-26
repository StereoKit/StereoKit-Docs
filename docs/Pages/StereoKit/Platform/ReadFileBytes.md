---
layout: default
title: Platform.ReadFileBytes
description: Reads the entire contents of the file as a byte array, taking advantage of any permissions that may have been granted by Platform.FilePicker. Returns null on failure.
---
# [Platform]({{site.url}}/Pages/StereoKit/Platform.html).ReadFileBytes

<div class='signature' markdown='1'>
```csharp
static Byte[] ReadFileBytes(string filename)
```
Reads the entire contents of the file as a byte array,
taking advantage of any permissions that may have been granted by
Platform.FilePicker. Returns null on failure.
</div>

|  |  |
|--|--|
|string filename|Path to the file.|
|RETURNS: Byte[]|A raw byte array if successful, null if not.|




