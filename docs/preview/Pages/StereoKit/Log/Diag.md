---
layout: default
title: Log.Diag
description: Writes a formatted line to the log using a LogLevel.Diagnostic severity level!
---
# [Log]({{site.url}}/preview/Pages/StereoKit/Log.html).Diag

<div class='signature' markdown='1'>
```csharp
static void Diag(string text)
```
Writes a formatted line to the log using a
LogLevel.Diagnostic severity level!
</div>

|  |  |
|--|--|
|string text|Formatted text with color tags! See the Log class docs for guidance on color tags.|





## Examples

```csharp
Log.Diag($"<~blu>{Time.Total:0.0}s<~clr> have elapsed since StereoKit start.");
```

