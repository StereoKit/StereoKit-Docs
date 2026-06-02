---
layout: default
title: Hash.Int
description: This will hash an integer into a hash value that StereoKit can use. This is helpful for adding in some uniqueness using something like a for loop index. This may be best when combined with additional hashes.
---
# [Hash]({{site.url}}/preview/Pages/StereoKit/Hash.html).Int

<div class='signature' markdown='1'>
```csharp
static IdHash Int(int val)
```
This will hash an integer into a hash value that StereoKit
can use. This is helpful for adding in some uniqueness using
something like a for loop index. This may be best when combined
with additional hashes.
</div>

|  |  |
|--|--|
|int val|An integer that will be hashed.|
|RETURNS: [IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html)|A StereoKit hash representing the provided integer.|

<div class='signature' markdown='1'>
```csharp
static IdHash Int(int val, IdHash root)
```
This will hash an integer into a hash value that StereoKit
can use. This is helpful for adding in some uniqueness using
something like a for loop index. This overload allows you to
combine your hash with an existing hash.
</div>

|  |  |
|--|--|
|int val|An integer that will be hashed.|
|[IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html) root|The hash value this new hash will start from.|
|RETURNS: [IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html)|A StereoKit hash representing a combination of the provided string and the root hash.|




