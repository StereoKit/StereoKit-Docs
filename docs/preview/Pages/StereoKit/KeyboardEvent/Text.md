---
layout: default
title: KeyboardEvent.Text
description: This event's text, as a string. Emoji and other codepoints outside the Basic Multilingual Plane don't fit in a single C# char, so this is the safe way to read one. Empty for key events.
---
# [KeyboardEvent]({{site.url}}/preview/Pages/StereoKit/KeyboardEvent.html).Text

<div class='signature' markdown='1'>
string Text{ get }
</div>

## Description
This event's text, as a string. Emoji and other codepoints
outside the Basic Multilingual Plane don't fit in a single C# char,
so this is the safe way to read one. Empty for key events.

