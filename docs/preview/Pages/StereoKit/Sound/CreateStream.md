---
layout: default
title: Sound.CreateStream
description: Create a sound used for streaming audio in or out! This is useful for things like reading from a microphone stream, or playing audio from a source streaming over the network, or even procedural sounds that are generated on the fly!  Use stream sounds with the WriteSamples and ReadSamples functions.
---
# [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html).CreateStream

<div class='signature' markdown='1'>
```csharp
static Sound CreateStream(float streamBufferDuration)
```
Create a sound used for streaming audio in or out! This
is useful for things like reading from a microphone stream, or
playing audio from a source streaming over the network, or even
procedural sounds that are generated on the fly!

Use stream sounds with the WriteSamples and ReadSamples
functions.
</div>

|  |  |
|--|--|
|float streamBufferDuration|How much audio time should this stream be able to hold without writing back over itself?|
|RETURNS: [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html)|A stream sound that can be read and written to.|

<div class='signature' markdown='1'>
```csharp
static Sound CreateStream(float streamBufferDuration, SoundChannels channels, SoundSampleRate sampleRate)
```
Create a stream sound with an explicit channel format
and sample rate! A 16,000hz mono stream suits speech pipelines,
while a stereo stream can carry pre-rendered music. Written
samples are interleaved for multi-channel formats, and playback
resamples to the mixer's 48,000hz automatically.
</div>

|  |  |
|--|--|
|float streamBufferDuration|How much audio time should this stream be able to hold without writing back over itself?|
|[SoundChannels]({{site.url}}/preview/Pages/StereoKit/SoundChannels.html) channels|The stream's channel format.|
|[SoundSampleRate]({{site.url}}/preview/Pages/StereoKit/SoundSampleRate.html) sampleRate|Capture/playback rate. SoundSampleRate names the common rates with notes - Default uses the mixer's native 48,000, Speech (16,000) suits speech pipelines. The enum value is the rate in Hz, so cast any integer rate to it for something off this list; playback resamples to 48,000 automatically.|
|RETURNS: [Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html)|A stream sound that can be read and written to.|




