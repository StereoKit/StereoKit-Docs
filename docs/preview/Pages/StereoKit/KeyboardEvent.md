---
layout: default
title: KeyboardEvent
description: A single keyboard input event, either a key press, a key release, or one codepoint of insertable text. Events preserve the exact order they were produced in, including how text and keys interleave.
---
# struct KeyboardEvent

A single keyboard input event, either a key press, a key
release, or one codepoint of insertable text. Events preserve the exact
order they were produced in, including how text and keys interleave.

## Instance Fields and Properties

|  |  |
|--|--|
|[Key]({{site.url}}/preview/Pages/StereoKit/Key.html) [key]({{site.url}}/preview/Pages/StereoKit/KeyboardEvent/key.html)|The key for press and release events, and none for text events. Mouse buttons arrive here too, as the mouse key values.|
|[KeyMod]({{site.url}}/preview/Pages/StereoKit/KeyMod.html) [modifiers]({{site.url}}/preview/Pages/StereoKit/KeyboardEvent/modifiers.html)|The modifier keys held when this event was produced. A modifier's own press event includes itself, its release event does not.|
|string [Text]({{site.url}}/preview/Pages/StereoKit/KeyboardEvent/Text.html)|This event's text, as a string. Emoji and other codepoints outside the Basic Multilingual Plane don't fit in a single C# char, so this is the safe way to read one. Empty for key events.|
|[KeyboardEventType]({{site.url}}/preview/Pages/StereoKit/KeyboardEventType.html) [type]({{site.url}}/preview/Pages/StereoKit/KeyboardEvent/type.html)|What kind of event this is, and which of the fields below apply.|

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

