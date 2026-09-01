---
layout: default
title: AppWindow
description: A desktop OS window belonging to the app, like the one the Simulator and Window app modes render into. There is no window available in XR mode, so if you're working with this class, be prepared to gate against AppWindow objects being null!
---
# class AppWindow

A desktop OS window belonging to the app, like the one the
Simulator and Window app modes render into. There is no window
available in XR mode, so if you're working with this class, be prepared
to gate against `AppWindow` objects being null!

## Instance Fields and Properties

|  |  |
|--|--|
|bool [Fullscreen]({{site.url}}/preview/Pages/StereoKit/AppWindow/Fullscreen.html)|Is this window currently covering its whole display? This is always the window's real state, so it also picks up fullscreen changes the user made through the window manager. Use RequestFullscreen to change it.|
|int [Height]({{site.url}}/preview/Pages/StereoKit/AppWindow/Height.html)|The height of the window's drawable area, in physical pixels. This is the size the swapchain renders at, and it changes whenever the window is resized.|
|int [Width]({{site.url}}/preview/Pages/StereoKit/AppWindow/Width.html)|The width of the window's drawable area, in physical pixels. This is the size the swapchain renders at, and it changes whenever the window is resized.|

## Instance Methods

|  |  |
|--|--|
|[RequestFullscreen]({{site.url}}/preview/Pages/StereoKit/AppWindow/RequestFullscreen.html)|Asks for this window to cover its whole display, or to go back to a normal window. This is only ever a request, and it's never immediate! Window managers can refuse it, browsers wait for a user gesture, and some platforms don't implement it at all. None of those report back a refusal, so watch the Fullscreen property to see if and when it takes effect. Going fullscreen resizes the window, so expect the render surface to follow along.|

## Static Fields and Properties

|  |  |
|--|--|
|[AppWindow]({{site.url}}/preview/Pages/StereoKit/AppWindow.html) [Main]({{site.url}}/preview/Pages/StereoKit/AppWindow/Main.html)|The app's main window! Only the Simulator and Window app modes have one, everywhere else this is null. This handle belongs to StereoKit, so don't hold onto it across SK.Shutdown.|
