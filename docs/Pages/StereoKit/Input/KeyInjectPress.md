---
layout: default
title: Input.KeyInjectPress
description: This will inject a key press event into StereoKit's input event queue. It will be processed at the start of the next frame, and will be indistinguishable from a physical key press. Remember to release your key as well!  This will _not_ submit text to StereoKit's text queue, and will not show up in places like UI.Input. For that, you must submit a TextInjectChar call.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).KeyInjectPress

<div class='signature' markdown='1'>
```csharp
static void KeyInjectPress(Key key)
```
This will inject a key press event into StereoKit's input
event queue. It will be processed at the start of the next frame,
and will be indistinguishable from a physical key press. Remember
to release your key as well!

This will _not_ submit text to StereoKit's text queue, and will not
show up in places like UI.Input. For that, you must submit a
TextInjectChar call.
</div>

|  |  |
|--|--|
|[Key]({{site.url}}/Pages/StereoKit/Key.html) key|The key to press.|




