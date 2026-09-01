---
layout: default
title: Input.KeyInjectRelease
description: This will inject a key release event into StereoKit's input event queue. It will be processed at the start of the next frame, and will be indistinguishable from a physical key release. This should be preceded by a key press!  This will _not_ submit text to StereoKit's text queue, so to type a character into something like UI.Input, you must submit a TextInject call. Editing keys are the other way around. backspace, delete, enter, and escape act on UI.Input through KeyInjectPress.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).KeyInjectRelease

<div class='signature' markdown='1'>
```csharp
static void KeyInjectRelease(Key key)
```
This will inject a key release event into StereoKit's
input event queue. It will be processed at the start of the next
frame, and will be indistinguishable from a physical key release.
This should be preceded by a key press!

This will _not_ submit text to StereoKit's text queue, so to type a
character into something like UI.Input, you must submit a
TextInject call. Editing keys are the other way around: backspace,
delete, enter, and escape act on UI.Input through KeyInjectPress.
</div>

|  |  |
|--|--|
|[Key]({{site.url}}/preview/Pages/StereoKit/Key.html) key|The key to release.|




