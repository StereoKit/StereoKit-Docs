---
layout: default
title: Interactor.Source
description: The physical source this interactor's input comes from, such as a specific hand, controller, or the mouse. Interactors that share a source will deactivate each other when one becomes active, for example the poke, pinch, and aim interactors of a single hand. InteractorSource.Unique indicates a source that never groups with other interactors. This is set at creation time and does not change.
---
# [Interactor]({{site.url}}/preview/Pages/StereoKit/Interactor.html).Source

<div class='signature' markdown='1'>
[InteractorSource]({{site.url}}/preview/Pages/StereoKit/InteractorSource.html) Source{ get }
</div>

## Description
The physical source this interactor's input comes from, such
as a specific hand, controller, or the mouse. Interactors that share
a source will deactivate each other when one becomes active, for
example the poke, pinch, and aim interactors of a single hand.
`InteractorSource.Unique` indicates a source that never groups with
other interactors. This is set at creation time and does not change.

