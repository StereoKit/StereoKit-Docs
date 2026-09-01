---
layout: default
title: LogColors
description: The log tool will write to the console with annotations for console colors, which helps with readability, but isn't always supported. These are the options available for configuring those colors.
---
# enum LogColors

The log tool will write to the console with annotations for console
colors, which helps with readability, but isn't always supported.
These are the options available for configuring those colors.

## Enum Values

|  |  |
|--|--|
|Ansi|Use console coloring annotations, when the console supports them! StereoKit checks the terminal for ANSI support, whether output has been redirected to a file or pipe, and the NO_COLOR environment variable. If any of those say no, colors are scraped out and logs fall back to plain text.|
|None|Scrape out any color annotations, so logs are all completely plain text.|
