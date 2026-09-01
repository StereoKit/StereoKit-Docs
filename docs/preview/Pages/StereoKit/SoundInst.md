---
layout: default
title: SoundInst
description: This represents a play instance of a Sound! You can get one when you call Sound.Play(). This allows you to do things like cancel a piece of audio early, or change the volume and position of it as it's playing.
---
# struct SoundInst

This represents a play instance of a Sound! You can get one
when you call Sound.Play(). This allows you to do things like cancel
a piece of audio early, or change the volume and position of it as
it's playing.

## Instance Fields and Properties

|  |  |
|--|--|
|UInt64 [Cursor]({{site.url}}/preview/Pages/StereoKit/SoundInst/Cursor.html)|This voice's playback position in source samples. For stream sounds this is an absolute position in the stream, so Sound.TotalSamples - Cursor is how much audio is queued ahead of this voice. Only fully in-memory sounds can Seek, streams read forward only.|
|float [Intensity]({{site.url}}/preview/Pages/StereoKit/SoundInst/Intensity.html)|The maximum intensity of the sound data since the last frame, as a value from 0-1. This is unaffected by its 3d position or volume settings, and is straight from the audio file's data.|
|bool [IsPlaying]({{site.url}}/preview/Pages/StereoKit/SoundInst/IsPlaying.html)|Is this Sound instance currently playing? For streaming assets, this will be true even if they don't have any new data in them, and they're just idling at the end of their data.|
|bool [Paused]({{site.url}}/preview/Pages/StereoKit/SoundInst/Paused.html)|Pause and resume this voice. A paused voice keeps its place and stays alive until stopped or stolen.|
|float [Pitch]({{site.url}}/preview/Pages/StereoKit/SoundInst/Pitch.html)|Playback rate multiplier, clamped to 0.25-4. 1 is normal speed, 2 is twice as fast and an octave up. Animatable while playing.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) [Position]({{site.url}}/preview/Pages/StereoKit/SoundInst/Position.html)|The 3D position in world space this sound instance is currently playing at. If this instance is no longer valid, the position will be at zero.|
|float [Spread]({{site.url}}/preview/Pages/StereoKit/SoundInst/Spread.html)|Apparent size of the source, 0-1. 0 is a point in space, 1 fills the whole sound field. Shaped emitters compute this themselves, treating a set value as their minimum.|
|float [Volume]({{site.url}}/preview/Pages/StereoKit/SoundInst/Volume.html)|The volume multiplier of this Sound instance! Typically 0-1, where 0 is silent, and 1 is full volume. Values above 1 amplify, and negatives clamp to 0.|

## Instance Methods

|  |  |
|--|--|
|[Seek]({{site.url}}/preview/Pages/StereoKit/SoundInst/Seek.html)|Jump this voice's playback to a sample position. Only works for fully in-memory sounds! Files up to ~10 seconds decode fully into memory on load, while longer files stream, and stream playback reads forward only.|
|[SetCutoff]({{site.url}}/preview/Pages/StereoKit/SoundInst/SetCutoff.html)|Overrides the voice's low-pass filter cutoff in Hz, replacing the automatic distance model. 0 hands control back to the distance model.|
|[SetShape]({{site.url}}/preview/Pages/StereoKit/SoundInst/SetShape.html)|Gives this voice a polyline emitter shape! The emitter follows the listener along the shape - position becomes the closest point, apparent size grows as the shape fills more of the view, and the sound goes fully diffuse inside it. Great for streams, wind lines, and shorelines. Points are copied, max 32.|
|[Stop]({{site.url}}/preview/Pages/StereoKit/SoundInst/Stop.html)|This stops the sound early if it's still playing.|
