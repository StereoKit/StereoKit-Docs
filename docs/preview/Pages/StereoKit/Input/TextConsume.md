---
layout: default
title: Input.TextConsume
description: Returns the next text character from the list of characters that have been entered this frame! Will return '\0' if there are no more characters left in the list. These are from the system's text entry system, and so can be unicode, will repeat if their 'key' is held down, and could arrive from something like a copy/paste operation.  This is insertable text only. Editing keys such as backspace, delete, enter, and escape never arrive here, so a text field must read them with Input.Key, the same way it reads the arrow keys. Newline and tab are text, and can arrive from a paste or an IME.  If you wish to reset this function to begin at the start of the read list on the next call, you can call Input.TextReset.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).TextConsume

<div class='signature' markdown='1'>
```csharp
static Char TextConsume()
```
Returns the next text character from the list of
characters that have been entered this frame! Will return '\0' if
there are no more characters left in the list. These are from the
system's text entry system, and so can be unicode, will repeat if
their 'key' is held down, and could arrive from something like a
copy/paste operation.

This is insertable text only. Editing keys such as backspace,
delete, enter, and escape never arrive here, so a text field must
read them with `Input.Key`, the same way it reads the arrow keys.
Newline and tab are text, and can arrive from a paste or an IME.

If you wish to reset this function to begin at the start of the
read list on the next call, you can call `Input.TextReset`.
</div>

|  |  |
|--|--|
|RETURNS: Char|The next character in this frame's list, or '\0' if none remain.|




