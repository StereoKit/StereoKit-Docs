---
layout: default
title: Input.ControllerModelGet
description: This retreives the Model currently in use by StereoKit to represent the controller input source. By default, this will be a Model provided by OpenXR, or SK's fallback Model. This will never be null while SK is initialized.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).ControllerModelGet

<div class='signature' markdown='1'>
```csharp
static Model ControllerModelGet(Handed handed)
```
This retreives the Model currently in use by StereoKit to
represent the controller input source. By default, this will be a
Model provided by OpenXR, or SK's fallback Model. This will never
be null while SK is initialized.
</div>

|  |  |
|--|--|
|[Handed]({{site.url}}/Pages/StereoKit/Handed.html) handed|The hand of the controller Model to retreive.|
|RETURNS: [Model]({{site.url}}/Pages/StereoKit/Model.html)|The current controller Model. By default, his will be a Model provided by OpenXR, or SK's fallback Model. This will never be null while SK is initialized.|




