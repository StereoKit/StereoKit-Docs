---
layout: default
title: AppWindow.RequestFullscreen
description: Asks for this window to cover its whole display, or to go back to a normal window. This is only ever a request, and it's never immediate! Window managers can refuse it, browsers wait for a user gesture, and some platforms don't implement it at all. None of those report back a refusal, so watch the Fullscreen property to see if and when it takes effect. Going fullscreen resizes the window, so expect the render surface to follow along.
---
# [AppWindow]({{site.url}}/preview/Pages/StereoKit/AppWindow.html).RequestFullscreen

<div class='signature' markdown='1'>
```csharp
void RequestFullscreen(bool fullscreen)
```
Asks for this window to cover its whole display, or to go
back to a normal window. This is only ever a request, and it's
never immediate! Window managers can refuse it, browsers wait for
a user gesture, and some platforms don't implement it at all. None
of those report back a refusal, so watch the Fullscreen property
to see if and when it takes effect. Going fullscreen resizes the
window, so expect the render surface to follow along.
</div>

|  |  |
|--|--|
|bool fullscreen|True to ask for fullscreen, false to ask for a normal window.|




