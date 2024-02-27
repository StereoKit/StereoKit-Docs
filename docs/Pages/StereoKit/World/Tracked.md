---
layout: default
title: World.Tracked
description: This reports the status of the device's positional tracking. If the room is too dark, or a hand is covering tracking sensors, or some other similar 6dof tracking failure, this would report as not tracked.  Note that this does not factor in the status of rotational tracking. Rotation is typically done via gyroscopes/accelerometers, which don't really fail the same way positional tracking system can.
---
# [World]({{site.url}}/Pages/StereoKit/World.html).Tracked

<div class='signature' markdown='1'>
static [BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) Tracked{ get }
</div>

## Description
This reports the status of the device's positional
tracking. If the room is too dark, or a hand is covering tracking
sensors, or some other similar 6dof tracking failure, this would
report as not tracked.

Note that this does not factor in the status of rotational
tracking. Rotation is typically done via gyroscopes/accelerometers,
which don't really fail the same way positional tracking system
can.

