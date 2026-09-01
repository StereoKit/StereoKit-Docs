---
layout: default
title: Input.KeyboardEventCount
description: The number of keyboard events this frame, for reading by index with Input.KeyboardEventAt. This is the whole frame's count, unaffected by what Input.KeyboardConsume has consumed.
---
# [Input]({{site.url}}/preview/Pages/StereoKit/Input.html).KeyboardEventCount

<div class='signature' markdown='1'>
static int KeyboardEventCount{ get }
</div>

## Description
The number of keyboard events this frame, for reading by
index with `Input.KeyboardEventAt`. This is the whole frame's count,
unaffected by what `Input.KeyboardConsume` has consumed.


## Examples

### Raw Keyboard Input
```csharp
// If you need to read the keyboard directly from a soft or hard keyboard,
// this gives you the frame's events in the exact order the user made them.
// Text events are language and keyboard layout sensitive, which makes them
// the correct choice for text content, and key events carry the editing
// intent that text can't express, like backspace and enter.
//
// `Input.KeyboardConsume` reads events destructively, so an element like
// UI.Input can hide input from whatever comes after it. Reading by index
// observes the frame's events without consuming anything, which is what a
// display like this window wants.
Pose         rawWinPose = new Pose(0.3f,0,0);
List<string> uniChars   = new List<string>(Enumerable.Repeat("", 10));
void ShowRawInputWindow()
{
	UI.WindowBegin("Raw keyboard events:", ref rawWinPose);

	// Read each of this frame's events, even the ones an earlier UI.Input
	// may have consumed.
	for (int evt = 0; evt < Input.KeyboardEventCount; evt++)
	{
		KeyboardEvent e = Input.KeyboardEventAt(evt);
		// Text events carry their character data in e.Text, which handles
		// emoji and other codepoints too large for a single C# char.
		string desc = e.type == KeyboardEventType.Text
			? $"U+{char.ConvertToUtf32(e.Text, 0):X4} '{e.Text}'"
			: $"{e.key} {(e.type == KeyboardEventType.KeyPress ? "down" : "up")}";

		// Insert at the start of the list, and bump off any more than 10.
		uniChars.Insert(0, desc);
		if (uniChars.Count > 10)
			uniChars.RemoveAt(uniChars.Count - 1);
	}

	// Show each event as a label
	for (int i = 0; i < uniChars.Count; i++)
		UI.Label(uniChars[i]);

	UI.WindowEnd();
}
```

