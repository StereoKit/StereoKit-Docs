---
layout: default
title: Log
description: A class for logging errors, warnings and information! Different levels of information can be filtered out, and supports coloration via <~[colorCode]> and <~clr> tags.  Text colors can be set with a tag, and reset back to default with <~clr>. Color codes are as follows.  | Dark | Bright | Description | |------|--------|-------------| | DARK | BRIGHT | DESCRIPTION | | blk  | BLK    | Black       | | red  | RED    | Red         | | grn  | GRN    | Green       | | ylw  | YLW    | Yellow      | | blu  | BLU    | Blue        | | mag  | MAG    | Magenta     | | cyn  | cyn    | Cyan        | | grn  | GRN    | Green       | | wht  | WHT    | White       |
---
# static class Log

A class for logging errors, warnings and information!
Different levels of information can be filtered out, and supports
coloration via <~[colorCode]> and <~clr> tags.

Text colors can be set with a tag, and reset back to default with
<~clr>. Color codes are as follows:

| Dark | Bright | Description |
|------|--------|-------------|
| DARK | BRIGHT | DESCRIPTION |
| blk  | BLK    | Black       |
| red  | RED    | Red         |
| grn  | GRN    | Green       |
| ylw  | YLW    | Yellow      |
| blu  | BLU    | Blue        |
| mag  | MAG    | Magenta     |
| cyn  | cyn    | Cyan        |
| grn  | GRN    | Green       |
| wht  | WHT    | White       |

## Static Fields and Properties

|  |  |
|--|--|
|[LogLevel]({{site.url}}/Pages/StereoKit/LogLevel.html) [Filter]({{site.url}}/Pages/StereoKit/Log/Filter.html)|What's the lowest level of severity logs to display on the console? Default is LogLevel.Info. This property can safely be set before SK initialization.|

## Static Methods

|  |  |
|--|--|
|[Diag]({{site.url}}/Pages/StereoKit/Log/Diag.html)|Writes a formatted line to the log using a LogLevel.Diagnostic severity level!|
|[Err]({{site.url}}/Pages/StereoKit/Log/Err.html)|Writes a formatted line to the log using a LogLevel.Error severity level!|
|[Info]({{site.url}}/Pages/StereoKit/Log/Info.html)|Writes a formatted line to the log using a LogLevel.Info severity level!|
|[Subscribe]({{site.url}}/Pages/StereoKit/Log/Subscribe.html)|Allows you to listen in on log events! Any callback subscribed here will be called when something is logged. This does honor the Log.Filter, so filtered logs will not be received here. This method can safely be called before SK initialization.|
|[Unsubscribe]({{site.url}}/Pages/StereoKit/Log/Unsubscribe.html)|If you subscribed to the log callback, you can unsubscribe that callback here! This method can safely be called before initialization.|
|[Warn]({{site.url}}/Pages/StereoKit/Log/Warn.html)|Writes a formatted line to the log using a LogLevel.Warn severity level!|
|[Write]({{site.url}}/Pages/StereoKit/Log/Write.html)|Writes a formatted line to the log with the specified severity level!|

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

