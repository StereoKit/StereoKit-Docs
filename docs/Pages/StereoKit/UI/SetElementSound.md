---
layout: default
title: UI.SetElementSound
description: This sets the sound that a particulat UI element will make when you interact with it. One sound when the interaction starts, and one when it ends.
---
# [UI]({{site.url}}/Pages/StereoKit/UI.html).SetElementSound

<div class='signature' markdown='1'>
```csharp
static void SetElementSound(UIVisual visual, Sound activate, Sound deactivate)
```
This sets the sound that a particulat UI element will make
when you interact with it. One sound when the interaction starts,
and one when it ends.
</div>

|  |  |
|--|--|
|[UIVisual]({{site.url}}/Pages/StereoKit/UIVisual.html) visual|The UI element to apply the sounds to. This             can be a value _past_ UIVisual.Max if you need extra UIVisual slots             for your own custom UI elements.|
|[Sound]({{site.url}}/Pages/StereoKit/Sound.html) activate|The sound made when the interaction begins.             A null sound will fall back to the default sound.|
|[Sound]({{site.url}}/Pages/StereoKit/Sound.html) deactivate|The sound made when the interaction ends.             A null sound will fall back to the default sound.|




