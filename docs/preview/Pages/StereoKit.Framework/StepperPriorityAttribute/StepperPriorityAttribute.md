---
layout: default
title: StepperPriorityAttribute.StepperPriorityAttribute
description: Creates a priority attribute for an IStepper type.
---
# [StepperPriorityAttribute]({{site.url}}/preview/Pages/StereoKit.Framework/StepperPriorityAttribute.html).StepperPriorityAttribute

<div class='signature' markdown='1'>
```csharp
void StepperPriorityAttribute(int priority)
```
Creates a priority attribute for an `IStepper` type.
</div>

|  |  |
|--|--|
|int priority|The priority value. Negative or zero values step before the app's main `Step` callback, positive values step after it, and all `IStepper`s are sorted in ascending order by this value.|




