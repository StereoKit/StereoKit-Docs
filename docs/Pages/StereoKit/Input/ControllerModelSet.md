---
layout: default
title: Input.ControllerModelSet
description: When StereoKit is rendering the input source, this allows you to override the controller Model SK uses. The Model SK uses by default may be provided from the OpenXR runtime depending on extension support, but if not, SK does have a default Model. Setting this to null will restore SK's default.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).ControllerModelSet

<div class='signature' markdown='1'>
```csharp
static void ControllerModelSet(Handed handed, Model model)
```
When StereoKit is rendering the input source, this allows
you to override the controller Model SK uses. The Model SK uses by
default may be provided from the OpenXR runtime depending on
extension support, but if not, SK does have a default Model.
Setting this to null will restore SK's default.
</div>

|  |  |
|--|--|
|[Handed]({{site.url}}/Pages/StereoKit/Handed.html) handed|The hand to assign the Model to.|
|[Model]({{site.url}}/Pages/StereoKit/Model.html) model|The Model to use to represent the controller.             Null is valid, and will restore SK's default model.|




