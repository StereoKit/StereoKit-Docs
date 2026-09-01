---
layout: default
title: KeyboardEventType
description: Describes what kind of keyboard input event this is.
---
# enum KeyboardEventType

Describes what kind of keyboard input event this is.

## Enum Values

|  |  |
|--|--|
|KeyPress|A key was pressed. Auto-repeats arrive as additional press events with no release between them, one per repeat.|
|KeyRelease|A key was released.|
|None|Not an event. Consuming returns this once no events remain in this frame's queue, and reading by index returns it for an index outside the queue.|
|Text|A single codepoint of insertable text.|
