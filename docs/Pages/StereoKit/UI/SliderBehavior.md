---
layout: default
title: UI.SliderBehavior
description: This is the core functionality of StereoKit's slider elements, without any of the rendering parts! If you're trying to create your own sliding UI elements, or do more extreme customization of the look and feel of slider UI elements, then this function will provide a lot of complex pressing functionality for you!
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).SliderBehavior

<div class='signature' markdown='1'>
```csharp
static void SliderBehavior(Vec3 windowRelativePos, Vec2 size, IdHash id, Vec2& value, Vec2 min, Vec2 max, Vec2 buttonSizeVisual, Vec2 buttonSizeInteract, UIConfirm confirmMethod, UISliderData& data)
```
This is the core functionality of StereoKit's slider
elements, without any of the rendering parts! If you're trying to
create your own sliding UI elements, or do more extreme
customization of the look and feel of slider UI elements, then this
function will provide a lot of complex pressing functionality for
you!
</div>

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) windowRelativePos|The layout position of the             pressable area.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) size|The size of the pressable area.|
|[IdHash]({{site.url}}/Pages/StereoKit/IdHash.html) id|The id for this pressable element to track its             state with.|
|Vec2& value|The value that the slider will store slider             state in.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) min|The minimum value the slider can set, left side             of the slider.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) max|The maximum value the slider can set, right             side of the slider.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) buttonSizeVisual|This is the visual size of the             element representing the touchable area of the slider. This is used             to calculate the center of the button's placement without going             outside the provided bounds.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) buttonSizeInteract|The size of the interactive touch             element of the slider. Set this to zero to use the entire area as a             touchable surface.|
|[UIConfirm]({{site.url}}/Pages/StereoKit/UIConfirm.html) confirmMethod|How should the slider be activated?             Push will be a push-button the user must press first, and pinch             will be a tab that the user must pinch and drag around.|
|UISliderData& data|This is data about the slider interaction, you             can use this for visualizing the slider behavior, or reacting to             its events.|




