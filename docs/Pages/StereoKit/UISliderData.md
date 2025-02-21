---
layout: default
title: UISliderData
description: Information about the current state of the UI's SliderBehavior. You can use this information to draw or react to the slider's activities.
---
# struct UISliderData

Information about the current state of the UI's
SliderBehavior. You can use this information to draw or react to the
slider's activities.

## Instance Fields and Properties

|  |  |
|--|--|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [activeState]({{site.url}}/Pages/StereoKit/UISliderData/activeState.html)|This is the current frame's "active" state for the button.|
|[Vec2]({{site.url}}/Pages/StereoKit/Vec2.html) [buttonCenter]({{site.url}}/Pages/StereoKit/UISliderData/buttonCenter.html)|The center location of where the slider's interaction element is.|
|float [fingerOffset]({{site.url}}/Pages/StereoKit/UISliderData/fingerOffset.html)|The current distance of the finger, within the pressable volume of the slider, from the bottom of the slider.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [focusState]({{site.url}}/Pages/StereoKit/UISliderData/focusState.html)|This is the current frame's "focus" state for the button.|
|int [interactor]({{site.url}}/Pages/StereoKit/UISliderData/interactor.html)|The interactor that is currently driving the activity or focus of the slider. Or -1 if there is no interaction.|
