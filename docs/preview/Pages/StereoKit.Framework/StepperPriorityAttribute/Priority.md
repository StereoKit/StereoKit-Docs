---
layout: default
title: StepperPriorityAttribute.Priority
description: The priority value for this IStepper. Negative or zero values step before the app's main Step callback, positive values step after it, and all ISteppers are sorted in ascending order by this value.
---
# [StepperPriorityAttribute]({{site.url}}/preview/Pages/StereoKit.Framework/StepperPriorityAttribute.html).Priority

<div class='signature' markdown='1'>
int Priority{ get }
</div>

## Description
The priority value for this `IStepper`. Negative or zero
values step before the app's main `Step` callback, positive values
step after it, and all `IStepper`s are sorted in ascending order by
this value.

