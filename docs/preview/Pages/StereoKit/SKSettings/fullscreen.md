---
layout: default
title: SKSettings.fullscreen
description: In the Simulator and Window app modes, ask for the desktop window to start out fullscreen! Like AppWindow.RequestFullscreen, this is only ever a request. window managers can refuse it, and browsers wait for a user gesture, so check AppWindow.Main.Fullscreen for the window's real state. Default is false.
---
# [SKSettings]({{site.url}}/preview/Pages/StereoKit/SKSettings.html).fullscreen

<div class='signature' markdown='1'>
bool fullscreen{ get set }
</div>

## Description
In the Simulator and Window app modes, ask for the
desktop window to start out fullscreen! Like
`AppWindow.RequestFullscreen`, this is only ever a request: window
managers can refuse it, and browsers wait for a user gesture, so
check `AppWindow.Main.Fullscreen` for the window's real state.
Default is false.

