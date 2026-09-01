---
layout: default
title: Input.KeyboardConsume
description: Reads the next keyboard event from this frame's queue, and advances to the one after it. Key presses, key releases, and text all arrive here in the exact order the user produced them, so a text field can apply them without guessing at what came first.  Each auto-repeat of a held key is its own press event, which is why this is the right way to drive editing keys. Input.Key reports state for the whole frame instead, so it cannot tell one press from several.  Events are consumed as they're read, and a focused UI.Input reads the whole queue. To observe events without consuming them, read by index with Input.KeyboardEventCount and Input.KeyboardEventAt instead. Like the rest of the input API, the queue belongs to the main thread, and is rebuilt at the start of each frame.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).KeyboardConsume

<div class='signature' markdown='1'>
```csharp
static bool KeyboardConsume(KeyboardEvent& keyboardEvent)
```
Reads the next keyboard event from this frame's queue, and
advances to the one after it. Key presses, key releases, and text
all arrive here in the exact order the user produced them, so a
text field can apply them without guessing at what came first.

Each auto-repeat of a held key is its own press event, which is why
this is the right way to drive editing keys. `Input.Key` reports
state for the whole frame instead, so it cannot tell one press from
several.

Events are consumed as they're read, and a focused `UI.Input` reads
the whole queue. To observe events without consuming them, read by
index with `Input.KeyboardEventCount` and `Input.KeyboardEventAt`
instead. Like the rest of the input API, the queue belongs to the
main thread, and is rebuilt at the start of each frame.
</div>

|  |  |
|--|--|
|KeyboardEvent& keyboardEvent|The next event in this frame's queue, or an event of type `KeyboardEventType.None` if none remain.|
|RETURNS: bool|True if an event was read, false once the queue is empty.|





## Examples

### Reading the keyboard event queue
`Input.KeyboardConsume` reads this frame's key presses, releases, and
text in the exact order the user produced them, which is the right
foundation for custom text editing. Text events carry the layout and
language sensitive characters to insert, while key events carry the
editing intent that text can't express, and each auto-repeat of a held
key is its own press event.

Reading consumes, so a focused `UI.Input` earlier in the frame will
empty the queue. If observing is all you need, `Input.KeyboardEventAt`
reads by index without consuming anything.
```csharp
static string typed = "";
static void ReadKeyboardEvents()
{
	while (Input.KeyboardConsume(out KeyboardEvent e))
	{
		switch (e.type)
		{
			case KeyboardEventType.Text:
				// Text may be two chars, for emoji and other codepoints
				// too large for a single C# char.
				typed += e.Text;
				break;
			case KeyboardEventType.KeyPress:
				if (e.key == Key.Backspace && typed.Length > 0)
				{
					// Erase the whole codepoint, which may be two chars
					int last = char.IsLowSurrogate(typed[typed.Length-1]) ? 2 : 1;
					typed = typed.Remove(typed.Length - last);
				}
				break;
		}
	}
}
```

