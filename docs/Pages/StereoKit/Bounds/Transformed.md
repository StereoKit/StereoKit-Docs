---
layout: default
title: Bounds.Transformed
description: This returns a Bounds that encapsulates the transformed points of the current Bounds's corners. Note that this will likely introduce a lot of extra empty volume in many cases, as the result is still always axis aligned.
---
# [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html).Transformed

<div class='signature' markdown='1'>
```csharp
Bounds Transformed(Matrix transform)
```
This returns a Bounds that encapsulates the transformed
points of the current Bounds's corners. Note that this will likely
introduce a lot of extra empty volume in many cases, as the result
is still always axis aligned.
</div>

|  |  |
|--|--|
|[Matrix]({{site.url}}/Pages/StereoKit/Matrix.html) transform|A transform Matrix for the current Bounds's             corners.|
|RETURNS: [Bounds]({{site.url}}/Pages/StereoKit/Bounds.html)|A Bounds that encapsulates the transformed points of the current Bounds's corners|




