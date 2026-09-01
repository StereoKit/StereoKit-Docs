---
layout: default
title: UI.HasKeyboardFocus
description: Is a UI.Input currently focused and taking keyboard input? A focused Input reads the whole keyboard event queue, so this is how you tell whether your own keyboard handling should stand down for the frame.
---
# [UI]({{site.url}}/preview/Pages/StereoKit/UI.html).HasKeyboardFocus

<div class='signature' markdown='1'>
static bool HasKeyboardFocus{ get }
</div>

## Description
Is a `UI.Input` currently focused and taking keyboard
input? A focused Input reads the whole keyboard event queue, so
this is how you tell whether your own keyboard handling should
stand down for the frame.

