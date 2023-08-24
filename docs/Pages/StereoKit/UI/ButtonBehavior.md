---
layout: default
title: UI.ButtonBehavior
description: This is the core functionality of StereoKit's buttons, without any of the rendering parts! If you're trying to create your own pressable UI elements, or do more extreme customization of the look and feel of UI elements, then this function will provide a lot of complex pressing functionality for you!
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).ButtonBehavior

<div class='signature' markdown='1'>
```csharp
static void ButtonBehavior(Vec3 windowRelativePos, Vec2 size, string id, Single& fingerOffset, BtnState& buttonState, BtnState& focusState)
```
This is the core functionality of StereoKit's buttons,
without any of the rendering parts! If you're trying to create your
own pressable UI elements, or do more extreme customization of the
look and feel of UI elements, then this function will provide a lot
of complex pressing functionality for you!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) windowRelativePos|The layout position of the             pressable area.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The size of the pressable area.|
|string id|The id for this pressable element to track its             state with.|
|Single& fingerOffset|This is the current distance of the             finger, within the pressable volume, from the bottom of the button.|
|BtnState& buttonState|This is the current frame's "active"             state for the button.|
|BtnState& focusState|This is the current frame's "focus" state             for the button.|

<div class='signature' markdown='1'>
```csharp
static void ButtonBehavior(Vec3 windowRelativePos, Vec2 size, string id, Single& fingerOffset, BtnState& buttonState, BtnState& focusState, Int32& hand)
```
This is the core functionality of StereoKit's buttons,
without any of the rendering parts! If you're trying to create your
own pressable UI elements, or do more extreme customization of the
look and feel of UI elements, then this function will provide a lot
of complex pressing functionality for you!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) windowRelativePos|The layout position of the             pressable area.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The size of the pressable area.|
|string id|The id for this pressable element to track its             state with.|
|Single& fingerOffset|This is the current distance of the             finger, within the pressable volume, from the bottom of the button.|
|BtnState& buttonState|This is the current frame's "active"             state for the button.|
|BtnState& focusState|This is the current frame's "focus" state             for the button.|
|Int32& hand|Id of the hand that interacted with the button.             This will be -1 if no interaction has occurred.|

<div class='signature' markdown='1'>
```csharp
static void ButtonBehavior(Vec3 windowRelativePos, Vec2 size, string id, float buttonDepth, float buttonActivationDepth, Single& fingerOffset, BtnState& buttonState, BtnState& focusState, Int32& hand)
```
This is the core functionality of StereoKit's buttons,
without any of the rendering parts! If you're trying to create your
own pressable UI elements, or do more extreme customization of the
look and feel of UI elements, then this function will provide a lot
of complex pressing functionality for you!
This overload allows for customizing the depth of the button, which
otherwise would use UISettings.depth for its values.
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) windowRelativePos|The layout position of the             pressable area.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The size of the pressable area.|
|string id|The id for this pressable element to track its             state with.|
|float buttonDepth|This is the z axis depth of the pressable             area.|
|float buttonActivationDepth|This is the depth at which the             button will activate. Normally this is 1/2 of buttonDepth.|
|Single& fingerOffset|This is the current distance of the             finger, within the pressable volume, from the bottom of the button.|
|BtnState& buttonState|This is the current frame's "active"             state for the button.|
|BtnState& focusState|This is the current frame's "focus" state             for the button.|
|Int32& hand|Id of the hand that interacted with the button.             This will be -1 if no interaction has occurred.|




