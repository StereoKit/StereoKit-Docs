---
layout: default
title: IdHash.Implicit Conversions
description: For back compatibility, allows conversion from an IdHash into a ulong, which may still be used in some parts of the older API.
---
# [IdHash]({{site.url}}/Pages/StereoKit/IdHash.html).Implicit Conversions

<div class='signature' markdown='1'>
```csharp
static UInt64 Implicit Conversions(IdHash h)
```
For back compatibility, allows conversion from an IdHash
into a ulong, which may still be used in some parts of the older
API.
</div>

|  |  |
|--|--|
|[IdHash]({{site.url}}/Pages/StereoKit/IdHash.html) h|Source id.|
|RETURNS: UInt64|An older style ulong hash.|

<div class='signature' markdown='1'>
```csharp
static IdHash Implicit Conversions(UInt64 h)
```
For back compatibility, allows old ulong hashes to auto
convert to the newer opaque IdHash representation.
</div>

|  |  |
|--|--|
|UInt64 h|Source id.|
|RETURNS: [IdHash]({{site.url}}/Pages/StereoKit/IdHash.html)|A new style IdHash hash.|




