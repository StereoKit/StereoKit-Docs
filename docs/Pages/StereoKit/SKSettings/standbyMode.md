---
layout: default
title: SKSettings.standbyMode
description: Configures StereoKit's behavior during device standby. By default in v0.4, SK will completely pause the main thread and disable audio. In v0.3, SK will continue to execute at a throttled pace, and audio will remain on.
---
# [SKSettings]({{site.url}}/Pages/StereoKit/SKSettings.html).standbyMode

<div class='signature' markdown='1'>
[StandbyMode]({{site.url}}/Pages/StereoKit/StandbyMode.html) standbyMode
</div>

## Description
Configures StereoKit's behavior during device standby. By
default in v0.4, SK will completely pause the main thread and
disable audio. In v0.3, SK will continue to execute at a throttled
pace, and audio will remain on.

