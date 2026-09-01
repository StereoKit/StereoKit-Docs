---
layout: default
title: Sound
description: This class represents a sound effect! Excellent for blips and bloops and little clips that you might play around your scene. Right now, this supports .wav, .mp3, and procedurally generated noises!
---
# class Sound

This class represents a sound effect! Excellent for blips
and bloops and little clips that you might play around your scene.
Right now, this supports .wav, .mp3, and procedurally generated
noises!

## Instance Fields and Properties

|  |  |
|--|--|
|[AssetState]({{site.url}}/preview/Pages/StereoKit/AssetState.html) [AssetState]({{site.url}}/preview/Pages/StereoKit/Sound/AssetState.html)|Sounds loaded from file decode asynchronously - this tells you where that's at! Playing is safe at any point: a Play while still Loading is held until the data lands, then catches up as if it had started on time. Negative states mean the load failed, and any held plays die quietly.|
|[SoundChannels]({{site.url}}/preview/Pages/StereoKit/SoundChannels.html) [Channels]({{site.url}}/preview/Pages/StereoKit/Sound/Channels.html)|The channel format of this sound's data. Only Mono sounds spatialize - Stereo plays head-locked with its image intact, and Ambisonic1 is a world-fixed sound field that counter-rotates against the head.|
|int [CursorSamples]({{site.url}}/preview/Pages/StereoKit/Sound/CursorSamples.html)|How far ReadSamples has consumed into a stream sound, in samples. Playing voices don't move this - each tracks its own position in SoundInst.Cursor. Non-stream sounds return 0.|
|float [Decibels]({{site.url}}/preview/Pages/StereoKit/Sound/Decibels.html)|The sound's real-world loudness at 1 meter, in decibels! StereoKit measures the audio data's loudness, so the value you declare here is the loudness you get - the waveform is the *shape* of the sound, Decibels is how loud it is. Loudness then falls off physically with distance (-6dB per doubling), so louder things carry farther with no extra tuning.  Some reference points: rustling leaves 20, a whisper 30, calm conversation 60, a vacuum cleaner at arm's length 75, a busy street corner 80 (the default), shouting up close 88, a rock concert 110, thunder from a nearby strike 120.|
|float [Duration]({{site.url}}/preview/Pages/StereoKit/Sound/Duration.html)|This will return the total length of the sound in seconds.|
|string [Id]({{site.url}}/preview/Pages/StereoKit/Sound/Id.html)|Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!|
|int [TotalSamples]({{site.url}}/preview/Pages/StereoKit/Sound/TotalSamples.html)|This will return the total number of audio samples used by the sound! StereoKit currently uses 48,000 samples per second for all audio. For stream sounds this is everything ever written. Against a playing SoundInst.Cursor, the difference is how much audio is queued ahead of that voice's playback.|
|int [UnreadSamples]({{site.url}}/preview/Pages/StereoKit/Sound/UnreadSamples.html)|This is the maximum number of samples in the sound that are currently available for reading via ReadSamples! ReadSamples will reduce this number by the amount of samples read. Playback doesn't consume samples - playing voices each keep their own cursor, see SoundInst.Cursor.  This is only really valid for Stream sounds, all other sound types will just return 0.|

## Instance Methods

|  |  |
|--|--|
|[Play]({{site.url}}/preview/Pages/StereoKit/Sound/Play.html)|Plays the sound at the 3D location specified, using the volume parameter as an additional volume control option! Sound volume falls off from 3D location, and can also indicate direction and location through spatial audio cues. So make sure the position is where you want people to think it's from! Currently, if this sound is playing somewhere else, it'll be canceled, and moved to this location.|
|[ReadSamples]({{site.url}}/preview/Pages/StereoKit/Sound/ReadSamples.html)|This will read samples from the sound stream, starting from the first unread sample. Check UnreadSamples for how many samples are available to read.|
|[WriteSamples]({{site.url}}/preview/Pages/StereoKit/Sound/WriteSamples.html)|Only works if this Sound is a stream type! This writes a number of audio samples to the sample buffer, and samples should be between -1 and +1. Streams are stored as ring buffers of a fixed size, so writing beyond the capacity of the ring buffer will overwrite the oldest samples.  StereoKit uses 48,000 samples per second of audio.|

## Static Fields and Properties

|  |  |
|--|--|
|[Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html) [Click]({{site.url}}/preview/Pages/StereoKit/Sound/Click.html)|A default click sound that lasts for 300ms. It's a procedurally generated sound based on a mouse press, with extra low frequencies in it.|
|[Sound]({{site.url}}/preview/Pages/StereoKit/Sound.html) [Unclick]({{site.url}}/preview/Pages/StereoKit/Sound/Unclick.html)|A default click sound that lasts for 300ms. It's a procedurally generated sound based on a mouse release, with extra low frequencies in it.|

## Static Methods

|  |  |
|--|--|
|[CreateStream]({{site.url}}/preview/Pages/StereoKit/Sound/CreateStream.html)|Create a sound used for streaming audio in or out! This is useful for things like reading from a microphone stream, or playing audio from a source streaming over the network, or even procedural sounds that are generated on the fly!  Use stream sounds with the WriteSamples and ReadSamples functions.|
|[Find]({{site.url}}/preview/Pages/StereoKit/Sound/Find.html)|Looks for a Sound asset that's already loaded, matching the given id!|
|[FromFile]({{site.url}}/preview/Pages/StereoKit/Sound/FromFile.html)|Loads a sound from file! StereoKit supports .wav and .mp3 files. Mono sounds spatialize, stereo plays head-locked, and 4 channel files load as first order ambisonics: world-fixed sound fields that counter-rotate against the user's head, ideal for environmental beds like rain, wind, or crowds. Bare 4 channel content is read as ambiX (ACN order, SN3D - the YouTube 360 convention), FuMa-tagged .amb files are converted on load, and other surround layouts downmix to stereo. Check Channels for what a file loaded as. Decoding happens asynchronously, but playing right away is fine - a Play before the decode finishes catches up to real time once it lands, as if it had started on schedule.|
|[FromMemory]({{site.url}}/preview/Pages/StereoKit/Sound/FromMemory.html)|Loads a sound from a file's data in memory! Same format support and async decode behavior as FromFile. The data is copied, so the array is yours again as soon as this returns.|
|[FromSamples]({{site.url}}/preview/Pages/StereoKit/Sound/FromSamples.html)|This function will create a sound from an array of samples. Values should range from -1 to +1, and there should be 48,000 values per second of audio.|
|[Generate]({{site.url}}/preview/Pages/StereoKit/Sound/Generate.html)|This function will generate a sound from a function you provide! The function is called once for each sample in the duration. As an example, it may be called 48,000 times for each second of duration.|

## Examples

### Getting streaming sound intensity
This example shows how to read data from a Sound stream such as the
microphone! In this case, we're just finding the average 'intensity'
of the audio, and returning it as a value approximately between 0 and 1.
Microphone.Start() should be called before this example :)
```csharp
float[] micBuffer    = new float[0];
float   micIntensity = 0;
float GetMicIntensity()
{
	if (!Microphone.IsRecording) return 0;

	// Ensure our buffer of samples is large enough to contain all the
	// data the mic has ready for us this frame
	if (Microphone.Sound.UnreadSamples > micBuffer.Length)
		micBuffer = new float[Microphone.Sound.UnreadSamples];

	// Read data from the microphone stream into our buffer, and track 
	// how much was actually read. Since the mic data collection runs in
	// a separate thread, this will often be a little inconsistent. Some
	// frames will have nothing ready, and others may have a lot!
	int samples = Microphone.Sound.ReadSamples(ref micBuffer);

	// This is a cumulative moving average over the last 1000 samples! We
	// Abs() the samples since audio waveforms are half negative.
	for (int i = 0; i < samples; i++)
		micIntensity = (micIntensity*999.0f + Math.Abs(micBuffer[i]))/1000.0f;

	return micIntensity;
}
```

### Basic usage
```csharp
Sound sound = Sound.FromFile("BlipNoise.wav");
sound.Play(Vec3.Zero);
```

### Generating a sound via generator
Making a procedural sound is pretty straightforward! Here's
an example of building a 500ms sound from two frequencies of
sin wave.
```csharp
Sound genSound = Sound.Generate((t) =>
{
	float band1 = SKMath.Sin(t * 523.25f * SKMath.Tau); // a 'C' tone
	float band2 = SKMath.Sin(t * 659.25f * SKMath.Tau); // an 'E' tone
	const float volume = 0.1f;
	return (band1*0.6f + band2*0.4f) * volume;
}, 0.5f);
genSound.Play(Vec3.Zero);
```

### Generating a sound via samples
Making a procedural sound is pretty straightforward! Here's
an example of building a 500ms sound from two frequencies of
sin wave.
```csharp
float[] samples = new float[(int)(48000*0.5f)];
for (int i = 0; i < samples.Length; i++)
{
	float t = i/48000.0f;
	float band1 = SKMath.Sin(t * 523.25f * SKMath.Tau); // a 'C' tone
	float band2 = SKMath.Sin(t * 659.25f * SKMath.Tau); // an 'E' tone
	const float volume = 0.1f;
	samples[i] = (band1 * 0.6f + band2 * 0.4f) * volume;
}
Sound sampleSound = Sound.FromSamples(samples);
sampleSound.Play(Vec3.Zero);
```

