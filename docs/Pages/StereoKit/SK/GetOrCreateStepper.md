---
layout: default
title: SK.GetOrCreateStepper
description: This will search the list of ISteppers that are currently attached to StereoKit. This includes ISteppers that have been added but are not yet initialized. This will return the first IStepper in the list that is assignable to the provided type, and if one is not found, it will attempt to create one.
---
# [SK]({{site.url}}/Pages/StereoKit/SK.html).GetOrCreateStepper

<div class='signature' markdown='1'>
```csharp
static Object GetOrCreateStepper(Type type)
```
This will search the list of `IStepper`s that are
currently attached to StereoKit. This includes `IStepper`s that
have been added but are not yet initialized. This will return the
first `IStepper` in the list that is assignable to the provided
type, and if one is not found, it will attempt to create one.
</div>

|  |  |
|--|--|
|Type type|Any concrete type that contains an empty             constructor.|
|RETURNS: Object|The first `IStepper` in the list that is assignable to the provided generic type, or a new object of the given type.|




