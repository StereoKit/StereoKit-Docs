---
layout: default
title: UISliderData
description: Data about a UI slider element's current interaction state. Provided by the ui_slider_behavior function.
---
# struct UISliderData

Data about a UI slider element's current interaction state. Provided by the ui_slider_behavior function.

## Instance Fields and Properties

|  |  |
|--|--|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [activeState]({{site.url}}/preview/Pages/StereoKit/UISliderData/activeState.html)|The current active/pressed state of the slider.|
|[Vec2]({{site.url}}/preview/Pages/StereoKit/Vec2.html) [buttonCenter]({{site.url}}/preview/Pages/StereoKit/UISliderData/buttonCenter.html)|The center of the slider button in window-relative coordinates.|
|float [fingerOffset]({{site.url}}/preview/Pages/StereoKit/UISliderData/fingerOffset.html)|How far the finger is pressing into the slider, in meters.|
|[BtnState]({{site.url}}/preview/Pages/StereoKit/BtnState.html) [focusState]({{site.url}}/preview/Pages/StereoKit/UISliderData/focusState.html)|The current focus state of the slider.|
|int [interactor]({{site.url}}/preview/Pages/StereoKit/UISliderData/interactor.html)|The id of the interactor that is interacting with this slider, or -1 if none.|
