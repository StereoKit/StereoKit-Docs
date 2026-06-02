---
layout: default
title: Platform.ReadFile
description: Reads the entire contents of the file as a UTF-8 string, taking advantage of any permissions that may have been granted by Platform.FilePicker.
---
# [Platform]({{site.url}}/preview/Pages/StereoKit/Platform.html).ReadFile

<div class='signature' markdown='1'>
```csharp
static bool ReadFile(string filename, String& data)
```
Reads the entire contents of the file as a UTF-8 string,
taking advantage of any permissions that may have been granted by
Platform.FilePicker.
</div>

|  |  |
|--|--|
|string filename|Path to the file. Not affected by Assets             folder path.|
|String& data|A UTF-8 decoded string representing the             contents of the file. Will be null on failure.|
|RETURNS: bool|True on success, False on failure.|

<div class='signature' markdown='1'>
```csharp
static bool ReadFile(string filename, Byte[]& data)
```
Reads the entire contents of the file as a byte array,
taking advantage of any permissions that may have been granted by
Platform.FilePicker.
</div>

|  |  |
|--|--|
|string filename|Path to the file.|
|Byte[]& data|A raw byte array representing the contents of             the file. Will be null on failure.|
|RETURNS: bool|True on success, False on failure.|





## Examples

### Read Custom Files
```csharp
Platform.FilePicker(PickerMode.Open, file => {
	// On some platforms, using StereoKit's Platform.ReadFile
	// instead of C#'s File IO functions may help bypass permission
	// issues.
	if (Platform.ReadFile(file, out string text))
		Log.Info(text);
}, null, ".txt");
```

