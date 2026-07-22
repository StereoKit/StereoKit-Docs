---
layout: default
title: Log.Err
description: Writes a formatted line to the log using a LogLevel.Error severity level!
---
# [Log]({{site.url}}/preview/Pages/StereoKit/Log.html).Err

<div class='signature' markdown='1'>
```csharp
static void Err(string text)
```
Writes a formatted line to the log using a
LogLevel.Error severity level!
</div>

|  |  |
|--|--|
|string text|Formatted text with color tags! See the Log class docs for guidance on color tags.|





## Examples

```csharp
if (Time.Stepf > 0.017f)
	Log.Err($"Oh no! Frame time (<~red>{Time.Stepf}<~clr>) has exceeded 17ms! There's no way we'll hit even 60 frames per second!");
```

