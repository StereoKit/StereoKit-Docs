---
layout: default
title: Log.Subscribe
description: Allows you to listen in on log events! Any callback subscribed here will be called when something is logged. This does honor the Log.Filter, so filtered logs will not be received here.
---
# [Log]({{site.url}}/preview/Pages/StereoKit/Log.html).Subscribe

<div class='signature' markdown='1'>
```csharp
static void Subscribe(LogCallback onLog)
```
Allows you to listen in on log events! Any callback
subscribed here will be called when something is logged. This
does honor the Log.Filter, so filtered logs will not be received
here.
</div>

|  |  |
|--|--|
|[LogCallback]({{site.url}}/preview/Pages/StereoKit/LogCallback.html) onLog|The function to call when a log event occurs.|





## Examples

Then you add the OnLog method into the log events like this in
your initialization code!
```csharp
Log.Subscribe(OnLog);
```
And in your Update loop, you can draw the window.
```csharp
LogWindow();
```
And that's it!
### An in-application log window
Here's an example of using the Log.Subscribe method to build a simple
logging window. This can be pretty handy to have around somewhere in
your application!

Here's the code for the window, and log tracking.
```csharp
static Pose logPose = new Pose(0, -0.1f, 0.5f, Quat.LookDir(Vec3.Forward));
static List<string> logList = new List<string>();
static float logIndex = 0;
static string logString = "";
static void OnLog(LogLevel level, string text)
{
	logList.Insert(0, text.Length < 100 ? text + "\n" : text.Substring(0, 100) + "...\n");
	UpdateLogStr((int)logIndex);
}

static void UpdateLogStr(int index)
{
	logIndex = Math.Max(Math.Min(index, logList.Count - 1), 0);
	logString = "";
	for (int i = index; i < index + 15 && i < logList.Count; i++)
		logString += logList[i];
}

static void LogWindow()
{
	UI.WindowBegin("Log", ref logPose, new Vec2(40, 0) * U.cm);

	UI.LayoutPushCut(UICut.Right, UI.LineHeight);
	if (UI.VSlider("scroll", ref logIndex, 0, Math.Max(logList.Count - 3, 0), 1))
		UpdateLogStr((int)logIndex);
	UI.LayoutPop();

	UI.Text(logString);
	UI.WindowEnd();
}
```

