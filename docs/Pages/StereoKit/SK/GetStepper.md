---
layout: default
title: SK.GetStepper
description: This will search the list of ISteppers that are currently attached to StereoKit. This includes ISteppers that have been added but are not yet initialized. This will return the first IStepper in the list that is assignable to the provided type.
---
# [SK]({{site.url}}/Pages/StereoKit/SK.html).GetStepper

<div class='signature' markdown='1'>
```csharp
static Object GetStepper(Type type)
```
This will search the list of `IStepper`s that are
currently attached to StereoKit. This includes `IStepper`s that
have been added but are not yet initialized. This will return the
first `IStepper` in the list that is assignable to the provided
type.
</div>

|  |  |
|--|--|
|Type type|Any parent or exact type.|
|RETURNS: Object|The first `IStepper` in the list that is assignable to the provided generic type, or null if none is found.|




