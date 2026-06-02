---
layout: default
title: Platform.FilePicker
description: Starts a file picker window! This will create a native file picker window if one is available in the current setup, and if it is not, it'll create a fallback filepicker build using StereoKit's UI.  Flatscreen apps will show traditional file pickers, but some platforms may have an OS provided file picker that works in MR. Some pickers will block the system and return right away, but others will stick around and let users continue to interact with the app.
---
# [Platform]({{site.url}}/preview/Pages/StereoKit/Platform.html).FilePicker

<div class='signature' markdown='1'>
```csharp
static void FilePicker(PickerMode mode, Action`1 onSelectFile, Action onCancel, String[] filters)
```
Starts a file picker window! This will create a native
file picker window if one is available in the current setup, and
if it is not, it'll create a fallback filepicker build using
StereoKit's UI.

Flatscreen apps will show traditional file pickers, but some
platforms may have an OS provided file picker that works in MR.
Some pickers will block the system and return right away, but
others will stick around and let users continue to interact with
the app.
</div>

|  |  |
|--|--|
|[PickerMode]({{site.url}}/preview/Pages/StereoKit/PickerMode.html) mode|Are we trying to Open a file, or Save a file?             This changes the appearance and behavior of the picker to support             the specified action.|
|Action`1 onSelectFile|This Action will be called with the             proper filename when the picker has successfully completed! On a             cancel or close event, this Action is not called.|
|Action onCancel|If the user cancels the file picker, or              the picker is closed via FilePickerClose, this Action is called.|
|String[] filters|A list of file extensions that the picker             should filter for. This is in the format of ".glb" and is case             insensitive.|

<div class='signature' markdown='1'>
```csharp
static void FilePicker(PickerMode mode, Action`2 onComplete, String[] filters)
```
Starts a file picker window! This will create a native
file picker window if one is available in the current setup, and
if it is not, it'll create a fallback filepicker build using
StereoKit's UI.

Flatscreen apps will show traditional file pickers, but some
platforms may have an OS provided file picker that works in MR.
Some pickers will block the system and return right away, but
others will stick around and let users continue to interact with
the app.
</div>

|  |  |
|--|--|
|[PickerMode]({{site.url}}/preview/Pages/StereoKit/PickerMode.html) mode|Are we trying to Open a file, or Save a file?             This changes the appearance and behavior of the picker to support             the specified action.|
|Action`2 onComplete|This action will be called when the file             picker has finished, either via a cancel event, or from a confirm             event. First parameter is a bool, where true indicates the              presence of a valid filename, and false indicates a failure or              cancel event.|
|String[] filters|A list of file extensions that the picker             should filter for. This is in the format of ".glb" and is case             insensitive.|





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
### Write Custom Files
```csharp
Platform.FilePicker(PickerMode.Save, file => {
	// On some platforms, using StereoKit's Platform.WriteFile
	// instead of C#'s File IO functions may help bypass permission
	// issues.
	Platform.WriteFile(file, "Text for the file.\n- Thanks!");
}, null, ".txt");
```
### Opening a Model
This is a simple button that will open a 3D model selection
file picker, and make a call to OnLoadModel after a file has
been successfully picked!
```csharp
if (UI.Button("Open Model") && !Platform.FilePickerVisible) {
	Platform.FilePicker(PickerMode.Open, OnLoadModel, null, Assets.ModelFormats);
}
```
Once you have the filename, it's simply a matter of loading it
from file. This is an example of async loading a model, and
calculating a scale value that ensures the model is a reasonable
size.
```csharp
private void OnLoadModel(string filename)
{
	model          = Model.FromFile(filename);
	modelTask      = Assets.CurrentTask;
	modelScale     = 1;
	modelScaleDone = false;
	model.OnLoaded += (m) => {
		if (m.Anims.Count > 0)
			m.PlayAnim(m.Anims[0], AnimMode.Loop);
	};
}
```

