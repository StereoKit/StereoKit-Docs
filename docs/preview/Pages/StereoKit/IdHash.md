---
layout: default
title: IdHash
description: This represents an identifier for some item, calculated by hashing some or all of that item's data! StereoKit frequently uses id hashes to represent UI elements. See UI.StackHash for creating a UI identifier.
---
# struct IdHash

This represents an identifier for some item, calculated by
hashing some or all of that item's data! StereoKit frequently uses id
hashes to represent UI elements. See `UI.StackHash` for creating a UI
identifier.

## Instance Methods

|  |  |
|--|--|
|[Equals]({{site.url}}/preview/Pages/StereoKit/IdHash/Equals.html)|An equality test.|
|[GetHashCode]({{site.url}}/preview/Pages/StereoKit/IdHash/GetHashCode.html)|Same as ulong.GetHashCode|

## Static Fields and Properties

|  |  |
|--|--|
|[IdHash]({{site.url}}/preview/Pages/StereoKit/IdHash.html) [None]({{site.url}}/preview/Pages/StereoKit/IdHash/None.html)|An empty IdHash that represents the unassigned state.|

## Operators

|  |  |
|--|--|
|[op_Equality]({{site.url}}/preview/Pages/StereoKit/IdHash/op_Equality.html)|An equality test.|
|[Implicit Conversions]({{site.url}}/preview/Pages/StereoKit/IdHash/op_Implicit.html)|For back compatibility, allows conversion from an IdHash into a ulong, which may still be used in some parts of the older API.|
|[op_Inequality]({{site.url}}/preview/Pages/StereoKit/IdHash/op_Inequality.html)|An inequality test.|
