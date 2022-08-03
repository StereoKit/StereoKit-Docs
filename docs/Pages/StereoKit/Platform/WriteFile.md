---
layout: default
title: Platform.WriteFile
description: Writes a UTF-8 text file to the filesystem, taking advantage of any permissions that may have been granted by Platform.FilePicker.
---
# [Platform]({{site.url}}/Pages/StereoKit/Platform.html).WriteFile

<div class='signature' markdown='1'>
```csharp
static bool WriteFile(string filename, string data)
```
Writes a UTF-8 text file to the filesystem, taking
advantage of any permissions that may have been granted by
Platform.FilePicker.
</div>

|  |  |
|--|--|
|string filename|Path to the new file. Not affected by             Assets folder path.|
|string data|A string to write to the file. This gets             converted to a UTF-8 encoding.|
|RETURNS: bool|True on success, False on failure.|

<div class='signature' markdown='1'>
```csharp
static bool WriteFile(string filename, Byte[] data)
```
Writes an array of bytes to the filesystem, taking
advantage of any permissions that may have been granted by
Platform.FilePicker.
</div>

|  |  |
|--|--|
|string filename|Path to the new file. Not affected by             Assets folder path.|
|Byte[] data|An array of bytes to write to the file.|
|RETURNS: bool|True on success, False on failure.|





## Examples

### Write Custom Files
```csharp
Platform.FilePicker(PickerMode.Save, file => {
	// On some platforms (like UWP), you may encounter permission
	// issues when trying to read or write to an arbitrary file.
	//
	// StereoKit's `Platform.FilePicker` and `Platform.WriteFile`
	// work together to avoid this permission issue, where the
	// FilePicker will grant permission to the WriteFile method.
	// C#'s built-in `File.WriteAllText` would fail on UWP here.
	Platform.WriteFile(file, "Text for the file.\n- Thanks!");
}, null, ".txt");
```

