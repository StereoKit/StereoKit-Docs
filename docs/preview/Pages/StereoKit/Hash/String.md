---
layout: default
title: Hash.String
description: This will hash the UTF8 representation of the given string into a hash value that StereoKit can use.
---
# [Hash]({{site.url}}/preview/Pages/StereoKit/Hash.html).String

<div class='signature' markdown='1'>
```csharp
static IdHash String(string str)
```
This will hash the UTF8 representation of the given string
into a hash value that StereoKit can use.
</div>

|  |  |
|--|--|
|string str|A C# string that will be converted to UTF8, and then hashed.|
|RETURNS: [IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html)|A StereoKit hash representing the provided string.|

<div class='signature' markdown='1'>
```csharp
static IdHash String(string str, IdHash root)
```
This will hash the UTF8 representation of the given string
into a hash value that StereoKit can use. This overload allows you
to combine your hash with an existing hash.
</div>

|  |  |
|--|--|
|string str|A C# string that will be converted to UTF8, and then hashed.|
|[IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html) root|The hash value this new hash will start from.|
|RETURNS: [IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html)|A StereoKit hash representing a combination of the provided string and the root hash.|




