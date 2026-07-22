---
layout: default
title: IStepper.Step
description: This Step method will be called every frame of the application, as long as Enabled is true. By default this happens immediately before the main application's Step callback, but this can be configured by adding a [StepperPriority] attribute to the IStepper type. a positive priority steps _after_ the app's Step callback, and ISteppers are sorted in ascending order of priority.
---
# [IStepper]({{site.url}}/preview/Pages/StereoKit.Framework/IStepper.html).Step

<div class='signature' markdown='1'>
```csharp
void Step()
```
This Step method will be called every frame of the
application, as long as `Enabled` is `true`. By default this happens
immediately before the main application's `Step` callback, but this
can be configured by adding a `[StepperPriority]` attribute to the
`IStepper` type: a positive priority steps _after_ the app's `Step`
callback, and `IStepper`s are sorted in ascending order of priority.
</div>




