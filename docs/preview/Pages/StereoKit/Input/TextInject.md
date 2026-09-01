---
layout: default
title: Input.TextInject
description: Injects text into StereoKit's keyboard event queue, as if the user had typed or pasted it. It will be available at the start of the next frame, and is indistinguishable from normal text entry. The whole string arrives as one uninterrupted run of events.  This is for text only. Carriage returns arrive as newlines, with CRLF counting as a single one. Other control characters are ignored here with a warning, since editing keys belong in Input.KeyInjectPress.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).TextInject

<div class='signature' markdown='1'>
```csharp
static void TextInject(string text)
```
Injects text into StereoKit's keyboard event queue, as if
the user had typed or pasted it. It will be available at the start
of the next frame, and is indistinguishable from normal text entry.
The whole string arrives as one uninterrupted run of events.

This is for text only. Carriage returns arrive as newlines, with
CRLF counting as a single one. Other control characters are ignored
here with a warning, since editing keys belong in
`Input.KeyInjectPress`.
</div>

|  |  |
|--|--|
|string text|The text to inject, as a normal string.|




