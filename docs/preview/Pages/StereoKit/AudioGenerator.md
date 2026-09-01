---
layout: default
title: AudioGenerator
description: A callback for generating audio samples procedurally, one sample at a time. Convenient, but crosses the interop boundary per sample - for long generations, prefer the buffer overload of Sound.Generate.
---
# delegate AudioGenerator

A callback for generating audio samples procedurally, one
sample at a time. Convenient, but crosses the interop boundary per
sample - for long generations, prefer the buffer overload of
Sound.Generate.
