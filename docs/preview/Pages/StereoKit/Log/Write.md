---
layout: default
title: Log.Write
description: Writes a formatted line to the log with the specified severity level!
---
# [Log]({{site.url}}/preview/Pages/StereoKit/Log.html).Write

<div class='signature' markdown='1'>
```csharp
static void Write(LogLevel level, string text)
```
Writes a formatted line to the log with the specified
severity level!
</div>

|  |  |
|--|--|
|[LogLevel]({{site.url}}/preview/Pages/StereoKit/LogLevel.html) level|Severity level of this log message.|
|string text|Formatted text with color tags! See the Log class docs for guidance on color tags.|





## Examples

```csharp
Log.Write(LogLevel.Info, $"<~grn>{Time.Total:0.0}s<~clr> have elapsed since StereoKit start.");
```

