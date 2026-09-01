---
layout: default
title: LogColors.Ansi
description: Use console coloring annotations, when the console supports them! StereoKit checks the terminal for ANSI support, whether output has been redirected to a file or pipe, and the NO_COLOR environment variable. If any of those say no, colors are scraped out and logs fall back to plain text.
---
# [LogColors]({{site.url}}/preview/Pages/StereoKit/LogColors.html).Ansi

<div class='signature' markdown='1'>
static [LogColors]({{site.url}}/preview/Pages/StereoKit/LogColors.html) Ansi
</div>

## Description
Use console coloring annotations, when the console supports them!
StereoKit checks the terminal for ANSI support, whether output has
been redirected to a file or pipe, and the NO_COLOR environment
variable. If any of those say no, colors are scraped out and logs
fall back to plain text.

