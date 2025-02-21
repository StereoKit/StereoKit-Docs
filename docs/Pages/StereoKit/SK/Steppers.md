---
layout: default
title: SK.Steppers
description: An enumerable list of all currently active ISteppers registered with StereoKit. This does not include Steppers that have been added, but are not yet initialized. Stepper initialization happens at the beginning of the frame, before the app's Step.
---
# [SK]({{site.url}}/Pages/StereoKit/SK.html).Steppers

<div class='signature' markdown='1'>
static IEnumerable`1 Steppers{ get }
</div>

## Description
An enumerable list of all currently active ISteppers
registered with StereoKit. This does not include Steppers that have
been added, but are not yet initialized. Stepper initialization
happens at the beginning of the frame, before the app's Step.

