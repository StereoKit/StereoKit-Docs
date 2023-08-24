---
layout: default
title: Input.TextInjectChar
description: This will inject a UTF32 Unicode text character into StereoKit's text input queue. It will be available at the start of the next frame, and will be indistinguishable from normal text entry.  This will _not_ submit key press/release events to StereoKit's input queue, use KeyInjectPress/Release for that.
---
# [Input]({{site.url}}/Pages/StereoKit/Input.html).TextInjectChar

<div class='signature' markdown='1'>
```csharp
static void TextInjectChar(uint unicodeCharUTF32)
```
This will inject a UTF32 Unicode text character into
StereoKit's text input queue. It will be available at the start of
the next frame, and will be indistinguishable from normal text
entry.

This will _not_ submit key press/release events to StereoKit's
input queue, use KeyInjectPress/Release for that.
</div>

|  |  |
|--|--|
|uint unicodeCharUTF32|An unsigned integer representing a             single UTF32 character.|

<div class='signature' markdown='1'>
```csharp
static void TextInjectChar(string chars)
```
This will convert a C# string into a number of UTF32
Unicode text characters, and inject them into StereoKit's text
input queue. It will be available at the start of the next frame,
and will be indistinguishable from normal text entry.

This will _not_ submit key press/release events to StereoKit's
input queue, use KeyInjectPress/Release for that.
</div>

|  |  |
|--|--|
|string chars|A collection of characters to submit as text             input.|

<div class='signature' markdown='1'>
```csharp
static void TextInjectChar(Byte[] chars, Encoding charEncoding)
```
This will convert a byte array string into a number of
UTF32 Unicode text characters, and inject them into StereoKit's
text input queue. It will be available at the start of the next
frame, and will be indistinguishable from normal text entry.

This will _not_ submit key press/release events to StereoKit's
input queue, use KeyInjectPress/Release for that.
</div>

|  |  |
|--|--|
|Byte[] chars|A byte array representing a string in some             encoded format.|
|Encoding charEncoding|The encoding format of the byte array.             Note that an encoding of UTF32 will skip converting bytes to UTF32.|




