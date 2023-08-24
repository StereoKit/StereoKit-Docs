---
layout: default
title: World.OriginMode
description: The mode or "reference space" that StereoKit uses for determining its base origin. This is determined by the initial value provided in SKSettings.origin, as well as by support from the underlying runtime. The mode reported here will _not_ necessarily be the one requested in initialization, as fallbacks are implemented using different available modes.
---
# [World]({{site.url}}/Pages/StereoKit/World.html).OriginMode

<div class='signature' markdown='1'>
static [OriginMode]({{site.url}}/Pages/StereoKit/OriginMode.html) OriginMode{ get }
</div>

## Description
The mode or "reference space" that StereoKit uses for
determining its base origin. This is determined by the initial
value provided in SKSettings.origin, as well as by support from the
underlying runtime. The mode reported here will _not_ necessarily
be the one requested in initialization, as fallbacks are
implemented using different available modes.

