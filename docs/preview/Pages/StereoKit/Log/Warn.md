---
layout: default
title: Log.Warn
description: Writes a formatted line to the log using a LogLevel.Warn severity level!
---
# [Log]({{site.url}}/preview/Pages/StereoKit/Log.html).Warn

<div class='signature' markdown='1'>
```csharp
static void Warn(string text)
```
Writes a formatted line to the log using a LogLevel.Warn
severity level!
</div>

|  |  |
|--|--|
|string text|Formatted text with color tags! See the Log class docs for guidance on color tags.|





## Examples

```csharp
Log.Warn($"Warning! <~ylw>{Time.Total:0.0}s<~clr> have elapsed since StereoKit start!");
```

