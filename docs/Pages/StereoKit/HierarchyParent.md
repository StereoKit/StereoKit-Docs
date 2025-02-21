---
layout: default
title: HierarchyParent
description: When used with a hierarchy modifying function that will push/pop items onto a stack, this can be used to change the behavior of how parent hierarchy items will affect the item being added to the top of the stack.
---
# enum HierarchyParent

When used with a hierarchy modifying function that will push/pop items onto a
stack, this can be used to change the behavior of how parent hierarchy items
will affect the item being added to the top of the stack.

## Enum Values

|  |  |
|--|--|
|Ignore|Ignoring the parent hierarchy stack item will let you skip inheriting anything from the parent item. The new item remains exactly as provided.|
|Inherit|Inheriting is generally the default behavior of a hierarchy stack, the current item will inherit the properties of the parent stack item in some form or another.|
