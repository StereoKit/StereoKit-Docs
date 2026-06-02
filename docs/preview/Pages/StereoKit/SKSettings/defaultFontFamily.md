---
layout: default
title: SKSettings.defaultFontFamily
description: A CSS-style comma-separated list of font families to use for StereoKit's default font, e.g. "Segoe UI, Arial, sans-serif". The first family that resolves on the host system is used, with the remainder acting as fallbacks for missing glyphs. If null, empty, or unresolvable, StereoKit falls back to its built-in per-platform default font selection.
---
# [SKSettings]({{site.url}}/preview/Pages/StereoKit/SKSettings.html).defaultFontFamily

<div class='signature' markdown='1'>
string defaultFontFamily{ get set }
</div>

## Description
A CSS-style comma-separated list of font families to use
for StereoKit's default font, e.g. "Segoe UI, Arial, sans-serif".
The first family that resolves on the host system is used, with
the remainder acting as fallbacks for missing glyphs. If null,
empty, or unresolvable, StereoKit falls back to its built-in
per-platform default font selection.

