---
layout: default
title: Material.QueueOffset
description: This property will force this material to draw earlier or later in the draw queue. Positive values make it draw later, negative makes it earlier. This is really helpful when doing tricks with the depth buffer, or are working with transparent objects. Good offset values should probably be specific, well managed, and small. Think of it as a layer rather than a distance, so probably less than 10, and definitely less than 1000.  This can also be helpful for tweaking performance! If you know an object is always going to be close to the user and likely to obscure lots of objects (like hands), drawing it earlier can mean objects behind it get discarded much faster! Similarly, objects that are far away (skybox!) can be pushed towards the back of the queue, so they're more likely to be discarded early.
---
# [Material]({{site.url}}/Pages/StereoKit/Material.html).QueueOffset

<div class='signature' markdown='1'>
int QueueOffset{ get set }
</div>

## Description
This property will force this material to draw earlier
or later in the draw queue. Positive values make it draw later,
negative makes it earlier. This is really helpful when doing tricks
with the depth buffer, or are working with transparent objects.
Good offset values should probably be specific, well managed, and
small. Think of it as a layer rather than a distance, so probably
less than 10, and definitely less than 1000.

This can also be helpful for tweaking performance! If you know an
object is always going to be close to the user and likely to
obscure lots of objects (like hands), drawing it earlier can mean
objects behind it get discarded much faster! Similarly, objects
that are far away (skybox!) can be pushed towards the back of the
queue, so they're more likely to be discarded early.

