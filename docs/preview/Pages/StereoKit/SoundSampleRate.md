---
layout: default
title: SoundSampleRate
description: Common audio sample rates, in Hz, for sound streams and microphone capture. The enum value _is_ the rate in Hz, so you can cast any integer rate to this type - these are just the well-supported ones, tagged with where each is typically used. StereoKit mixes everything at 48kHz and resamples to and from other rates as needed, so any positive rate works, but a rate a device captures or plays natively avoids an extra resample.
---
# enum SoundSampleRate

Common audio sample rates, in Hz, for sound streams and microphone capture.
The enum value _is_ the rate in Hz, so you can cast any integer rate to this
type - these are just the well-supported ones, tagged with where each is
typically used. StereoKit mixes everything at 48kHz and resamples to and from
other rates as needed, so any positive rate works, but a rate a device
captures or plays natively avoids an extra resample.

## Enum Values

|  |  |
|--|--|
|Broadcast|32kHz, seen in some broadcast audio and Bluetooth wideband (mSBC).|
|Cd|44.1kHz, the CD-audio standard and a common consumer device default.|
|Default|Use StereoKit's native mix rate, 48kHz. No resampling in the mixer, and the best default unless you have a specific reason otherwise.|
|Speech|16kHz wideband speech - the rate that speech-to-text, wake-word, and VoIP pipelines typically expect. A good low-bandwidth choice for voice.|
|Standard|48kHz, the AV/pro standard and StereoKit's native mix rate. The modern default for most capture hardware.|
|Studio|96kHz high-resolution pro audio. Rare for a microphone, and resampled down to 48kHz for mixing anyway.|
|Telephony|8kHz narrowband telephony, classic Bluetooth headset (HFP/SCO) quality. Tiny data rate, intelligible speech only.|
|Ultra|192kHz, the extreme end of pro audio interfaces. Almost never a real microphone rate, and heavily oversampled for StereoKit's purposes.|
