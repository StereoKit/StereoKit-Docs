---
layout: default
title: Sound.Decibels
description: The sound's real-world loudness at 1 meter, in decibels! StereoKit measures the audio data's loudness, so the value you declare here is the loudness you get - the waveform is the *shape* of the sound, Decibels is how loud it is. Loudness then falls off physically with distance (-6dB per doubling), so louder things carry farther with no extra tuning.  Some reference points. rustling leaves 20, a whisper 30, calm conversation 60, a vacuum cleaner at arm's length 75, a busy street corner 80 (the default), shouting up close 88, a rock concert 110, thunder from a nearby strike 120.
---
# [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html).Decibels

<div class='signature' markdown='1'>
float Decibels{ get set }
</div>

## Description
The sound's real-world loudness at 1 meter, in
decibels! StereoKit measures the audio data's loudness, so the
value you declare here is the loudness you get - the waveform is
the *shape* of the sound, Decibels is how loud it is. Loudness
then falls off physically with distance (-6dB per doubling), so
louder things carry farther with no extra tuning.

Some reference points: rustling leaves 20, a whisper 30, calm
conversation 60, a vacuum cleaner at arm's length 75, a busy
street corner 80 (the default), shouting up close 88, a rock
concert 110, thunder from a nearby strike 120.

