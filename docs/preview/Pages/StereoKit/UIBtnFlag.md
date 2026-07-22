---
layout: default
title: UIBtnFlag
description: A bit-flag for modifying the behavior of a button, used with the lower-level UI.ButtonBehavior.
---
# enum UIBtnFlag

A bit-flag for modifying the behavior of a button, used with the lower-level
`UI.ButtonBehavior`.

## Enum Values

|  |  |
|--|--|
|NoCancel|Prevents the activation from being canceled when the interactor moves too far from the button. Used for elements like sliders that legitimately track an interactor well outside the button's bounds.|
|None|Default button behavior.|
