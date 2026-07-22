---
layout: default
title: Log.Info
description: Writes a formatted line to the log using a LogLevel.Info severity level!
---
# [Log]({{site.url}}/preview/Pages/StereoKit/Log.html).Info

<div class='signature' markdown='1'>
```csharp
static void Info(string text)
```
Writes a formatted line to the log using a LogLevel.Info
severity level!
</div>

|  |  |
|--|--|
|string text|Formatted text with color tags! See the Log class docs for guidance on color tags.|





## Examples

```csharp
Log.Info($"<~grn>{Time.Total:0.0}s<~clr> have elapsed since StereoKit start.");
```

