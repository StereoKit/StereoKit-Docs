---
layout: default
title: StepperPriorityAttribute
description: An optional [StepperPriority] attribute for IStepper types that controls when and in what order their Step method is called relative to the app's main Step callback.  The priority value determines both the _phase_ and the _sort order_. ISteppers with a negative priority (or the default of 0) are stepped _before_ the app's main Step callback, and ISteppers with a positive priority are stepped _after_ it. In all cases, ISteppers are stepped in ascending order of priority, and ties preserve the order they were added in.  If an IStepper type does not have this attribute, it behaves as though it has a priority of 0.
---
# class StepperPriorityAttribute

An optional `[StepperPriority]` attribute for `IStepper` types
that controls when and in what order their `Step` method is called
relative to the app's main `Step` callback.

The priority value determines both the _phase_ and the _sort order_:
`IStepper`s with a negative priority (or the default of 0) are stepped
_before_ the app's main `Step` callback, and `IStepper`s with a positive
priority are stepped _after_ it. In all cases, `IStepper`s are stepped in
ascending order of priority, and ties preserve the order they were added
in.

If an `IStepper` type does not have this attribute, it behaves as though
it has a priority of 0.

## Instance Fields and Properties

|  |  |
|--|--|
|int [Priority]({{site.url}}/preview/Pages/StereoKit.Framework/StepperPriorityAttribute/Priority.html)|The priority value for this `IStepper`. Negative or zero values step before the app's main `Step` callback, positive values step after it, and all `IStepper`s are sorted in ascending order by this value.|

## Instance Methods

|  |  |
|--|--|
|[StepperPriorityAttribute]({{site.url}}/preview/Pages/StereoKit.Framework/StepperPriorityAttribute/StepperPriorityAttribute.html)|Creates a priority attribute for an `IStepper` type.|
