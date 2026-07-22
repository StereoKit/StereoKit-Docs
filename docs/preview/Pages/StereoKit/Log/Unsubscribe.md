---
layout: default
title: Log.Unsubscribe
description: If you subscribed to the log callback, you can unsubscribe that callback here!
---
# [Log]({{site.url}}/preview/Pages/StereoKit/Log.html).Unsubscribe

<div class='signature' markdown='1'>
```csharp
static void Unsubscribe(LogCallback onLog)
```
If you subscribed to the log callback, you can
unsubscribe that callback here!
</div>

|  |  |
|--|--|
|[LogCallback]({{site.url}}/preview/Pages/StereoKit/LogCallback.html) onLog|The subscribed callback to remove.|





## Examples

```csharp
LogCallback onLog = (LogLevel level, string logText) 
	=> Console.WriteLine(logText);

Log.Subscribe(onLog);
```
...
```csharp
Log.Unsubscribe(onLog);
```

