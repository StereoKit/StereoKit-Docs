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
|float [Intensity]({{site.url}}/Pages/StereoKit/SoundInst/Intensity.html)|The maximum intensity of the sound data since the last frame, as a value from 0-1. This is unaffected by its 3d position or volume settings, and is straight from the audio file's data.|
|bool [IsPlaying]({{site.url}}/Pages/StereoKit/SoundInst/IsPlaying.html)|Is this Sound instance currently playing? For streaming assets, this will be true even if they don't have any new data in them, and they're just idling at the end of their data.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [Position]({{site.url}}/Pages/StereoKit/SoundInst/Position.html)|The 3D position in world space this sound instance is currently playing at. If this instance is no longer valid, the position will be at zero.|
|float [Volume]({{site.url}}/Pages/StereoKit/SoundInst/Volume.html)|The volume multiplier of this Sound instance! A number between 0 and 1, where 0 is silent, and 1 is full volume.|

## Instance Methods

|  |  |
|--|--|
|[Stop]({{site.url}}/Pages/StereoKit/SoundInst/Stop.html)|This stops the sound early if it's still playing.|
