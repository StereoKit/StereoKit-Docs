---
layout: default
title: Input.TextReset
description: Resets the Input.TextConsume read list back to the start. For example, UI.Input will _not_ call TextReset, so it effectively will consume those characters, hiding them from any TextConsume calls following it. If you wanted to check the current frame's text, but still allow UI.Input to work later on in the frame, you would read everything with TextConsume, and then TextReset afterwards to reset the read list for the following UI.Input.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).TextReset

<div class='signature' markdown='1'>
```csharp
static void TextReset()
```
Resets the `Input.TextConsume` read list back to the
start.
For example, `UI.Input` will _not_ call `TextReset`, so it
effectively will consume those characters, hiding them from
any `TextConsume` calls following it. If you wanted to check the
current frame's text, but still allow `UI.Input` to work later on
in the frame, you would read everything with `TextConsume`, and
then `TextReset` afterwards to reset the read list for the
following `UI.Input`.
</div>





## Examples

### Raw Text Input
```csharp
// If you need to read text input directly from a soft or hard keyboard,
// these functions give you direct access to the stream of Unicode
// characters produced! These characters are language and keyboard layout
// sensitive, making these functions the correct ones for working with text
// content vs. the `Input.Key` functions, which are not language specific.
//
// Every frame, `Input.TextConsume` will have a list of new characters that
// have been pressed or submitted to the app. Reading them will "consume"
// them, making them unavailable to anything that comes after. If you need
// to bypass some earlier element consuming them, you can reset the current
// frame's consume queue with `Input.TextReset`.
Pose         rawWinPose = new Pose(0.3f,0,0);
List<string> uniChars   = new List<string>(Enumerable.Repeat("", 10));
void ShowRawInputWindow()
{
	UI.WindowBegin("Raw keyboard code points:", ref rawWinPose);

	// Reset the text input back to the start of the list, since any
	// UI.Input before this will consume the characters first and we
	// always want to show input on this window.
	Input.TextReset();

	while (true)
	{
		// Consume each new character, 0 marks the end of the list of new
		// characters.
		char c = Input.TextConsume();
		if (c == 0) break;

		// Insert the codepoint at the start of the list, and bump off any
		// more than 10 items.
		uniChars.Insert(0, $"{(int)c}");
		if (uniChars.Count > 10)
			uniChars.RemoveAt(uniChars.Count - 1);
	}

	// Show each character code as a label
	for (int i = 0; i < uniChars.Count; i++)
		UI.Label(uniChars[i]);

	UI.WindowEnd();
}
```

