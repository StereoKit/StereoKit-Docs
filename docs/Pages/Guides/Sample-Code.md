---
layout: default
title: Sample Code
description: Here are a list of small demos that illustrate how certain parts of StereoKit works!  ## [Controllers](https.//...
---

# StereoKit Sample Code

Here are a list of small demos that illustrate how
certain parts of StereoKit works!

## [Controllers](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoControllers.cs)

While StereoKit prioritizes hand input, sometimes a controller has more precision! StereoKit provides access to any controllers via the Input.Controller function. This is a debug visualization of the controller data provided there.

StereoKit will simulate hands if only controllers are present, but it will not simulate controllers if only hands are present.

## [Eye Tracking](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoEyes.cs)

If the hardware supports it, and permissions are granted, eye tracking is as simple as grabbing Input.Eyes!

This scene is raycasting your eye ray at the indicated plane, and the dot's red/green color indicates eye tracking availability! On flatscreen you can simulate eye tracking with Alt+Mouse.

## [FB Passthrough Extension](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoFBPassthrough.cs)

Passthrough AR!

## [Mesh Generation](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoGeo.cs)

Generating a Mesh or Model via code can be an important task, and StereoKit provides a number of tools to make this pretty easy! In addition to the Default meshes, you can also generate a number of shapes, seen here. (See the Mesh.Gen functions)

If the provided shapes aren't enough, it's also pretty easy to procedurally assemble a mesh of your own from vertices and indices! That's the wavy surface all the way to the right.

## [Hand Input](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoHands.cs)

StereoKit uses a hands first approach to user input! Even when hand-sensors aren't available, hand data is simulated instead using existing devices. Check out Input.Hand for all the cool data you get!

This demo is the source for the 'Using Hands' guide, and is a collection of different options and examples of how to get, use, and visualize Hand data.

## [Microphone](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoMicrophone.cs)

Sometimes you need direct access to the microphone data! Maybe for a special effect, or maybe you just need to stream it to someone else. Well, there's an easy API for that!

This demo shows how to grab input from the microphone, and use it to drive an indicator that tells users that you're listening!

## [Model Nodes](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoNodes.cs)

ModelNode API lets...

## [Physics](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoPhysics.cs)

StereoKit supports some basic rigidbody physics simulation. See the 'Solid' class in the docs.

Use the panel to add or clear physics objects from the scene, and make a fist to interact with them yourself!

## [File Picker](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoPicker.cs)

Applications need to save and load files at runtime! StereoKit has a cross-platform, MR compatible file picker built in, Platform.FilePicker.

On systems/conditions where a native file picker is available, that's what you'll get! Otherwise, StereoKit will fall back to a custom picker built with StereoKit's UI.

## [Point Clouds](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoPointCloud.cs)

Point clouds are not a built-in feature of StereoKit, but it's not hard to do this yourself! Check out the code for this demo for a class that'll help you do this directly from data, or from a Model.

## [Skeleton Estimation](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoSkeleton.cs)

With knowledge about where the head and hands are, you can make a decent guess about where some other parts of the body are! The StereoKit repository contains an AvatarSkeleton IStepper to show a basic example of how something like this can be done.

## [Procedural Textures](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/DemoTextures.cs)

Here's a quick sample of procedurally assembling a texture!


