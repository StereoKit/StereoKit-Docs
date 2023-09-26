---
layout: default
title: Input
description: Input from the system come from this class! Hands, eyes, heads, mice and pointers!
---
# static class Input

Input from the system come from this class! Hands, eyes,
heads, mice and pointers!

## Static Fields and Properties

|  |  |
|--|--|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [ControllerMenuButton]({{site.url}}/Pages/StereoKit/Input/ControllerMenuButton.html)|This is the state of the controller's menu button, this is not attached to any particular hand, so it's independent of a left or right controller.|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) [Eyes]({{site.url}}/Pages/StereoKit/Input/Eyes.html)|If the device has eye tracking hardware and the app has permission to use it, then this is the most recently tracked eye pose. Check `Input.EyesTracked` to see if the pose is up-to date, or if it's a leftover!  You can also check `SK.System.eyeTrackingPresent` to see if the hardware is capable of providing eye tracking.  On Flatscreen when the MR sim is still enabled, then eyes are emulated using the cursor position when the user holds down Alt.|
|[BtnState]({{site.url}}/Pages/StereoKit/BtnState.html) [EyesTracked]({{site.url}}/Pages/StereoKit/Input/EyesTracked.html)|If eye hardware is available and app has permission, then this is the tracking state of the eyes. Eyes may move out of bounds, hardware may fail to detect eyes, or who knows what else!  On Flatscreen when MR sim is still enabled, this will report whether the user is simulating eye input with the Alt key.  **Permissions** - For UWP apps, permissions for eye tracking can be found in the project's .appxmanifest file under Capabilities->Gaze Input. - For Xamarin apps, you may need to add an entry to your AndroidManifest.xml, refer to your device's documentation for specifics.|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) [Head]({{site.url}}/Pages/StereoKit/Input/Head.html)|The position and orientation of the user's head! This is the center point between the user's eyes, NOT the center of the user's head. Forward points the same way the user's face is facing.|
|[Mouse]({{site.url}}/Pages/StereoKit/Mouse.html) [Mouse]({{site.url}}/Pages/StereoKit/Input/Mouse.html)|Information about this system's mouse, or lack thereof!|

## Static Methods

|  |  |
|--|--|
|[Controller]({{site.url}}/Pages/StereoKit/Input/Controller.html)|Gets raw controller input data from the system. Note that not all buttons provided here are guaranteed to be present on the user's physical controller. Controllers are also not guaranteed to be available on the system, and are never simulated.|
|[FireEvent]({{site.url}}/Pages/StereoKit/Input/FireEvent.html)|This function allows you to artifically insert an input event, simulating any device source and event type you want.|
|[Hand]({{site.url}}/Pages/StereoKit/Input/Hand.html)|Retrieves all the information about the user's hand! StereoKit will always provide hand information, however sometimes that information is simulated, like in the case of a mouse, or controllers.  Note that this is a copy of the hand information, and it's a good chunk of data, so it's a good idea to grab it once and keep it around for the frame, or at least function, rather than asking for it again and again each time you want to touch something.|
|[HandClearOverride]({{site.url}}/Pages/StereoKit/Input/HandClearOverride.html)|Clear out the override status from Input.HandOverride, and restore the user's control over it again.|
|[HandMaterial]({{site.url}}/Pages/StereoKit/Input/HandMaterial.html)|Set the Material used to render the hand! The default material uses an offset of 10 to ensure it gets drawn overtop of other elements.|
|[HandOverride]({{site.url}}/Pages/StereoKit/Input/HandOverride.html)|This allows you to completely override the hand's pose information! It is still treated like the user's hand, so this is great for simulating input for testing purposes. It will remain overridden until you call Input.HandClearOverride.|
|[HandSimPoseAdd]({{site.url}}/Pages/StereoKit/Input/HandSimPoseAdd.html)|StereoKit will use controller inputs to simulate an articulated hand. This function allows you to add new simulated poses to different controller or keyboard buttons!|
|[HandSimPoseClear]({{site.url}}/Pages/StereoKit/Input/HandSimPoseClear.html)|This clears all registered hand simulation poses, including the ones that StereoKit registers by default!|
|[HandSimPoseRemove]({{site.url}}/Pages/StereoKit/Input/HandSimPoseRemove.html)|Lets you remove an existing hand pose.|
|[HandSolid]({{site.url}}/Pages/StereoKit/Input/HandSolid.html)|Does StereoKit register the hand with the physics system? By default, this is true. Right now this is just a single block collider, but later will involve per-joint colliders!|
|[HandSource]({{site.url}}/Pages/StereoKit/Input/HandSource.html)|This gets the _current_ source of the hand joints! This allows you to distinguish between fully articulated joints, and simulated hand joints that may not have the same range of mobility. Note that this may change during a session, the user may put down their controllers, automatically switching to hands, or visa versa.|
|[HandVisible]({{site.url}}/Pages/StereoKit/Input/HandVisible.html)|Sets whether or not StereoKit should render the hand for you. Turn this to false if you're going to render your own, or don't need the hand itself to be visible.|
|[Key]({{site.url}}/Pages/StereoKit/Input/Key.html)|Keyboard key state! On desktop this is super handy, but even standalone MR devices can have bluetooth keyboards, or even just holographic system keyboards!|
|[KeyInjectPress]({{site.url}}/Pages/StereoKit/Input/KeyInjectPress.html)|This will inject a key press event into StereoKit's input event queue. It will be processed at the start of the next frame, and will be indistinguishable from a physical key press. Remember to release your key as well!  This will _not_ submit text to StereoKit's text queue, and will not show up in places like UI.Input. For that, you must submit a TextInjectChar call.|
|[KeyInjectRelease]({{site.url}}/Pages/StereoKit/Input/KeyInjectRelease.html)|This will inject a key release event into StereoKit's input event queue. It will be processed at the start of the next frame, and will be indistinguishable from a physical key release. This should be preceded by a key press!  This will _not_ submit text to StereoKit's text queue, and will not show up in places like UI.Input. For that, you must submit a TextInjectChar call.|
|[Pointer]({{site.url}}/Pages/StereoKit/Input/Pointer.html)|This gets the pointer by filter based index.|
|[PointerCount]({{site.url}}/Pages/StereoKit/Input/PointerCount.html)|The number of Pointer inputs that StereoKit is tracking that match the given filter.|
|[Subscribe]({{site.url}}/Pages/StereoKit/Input/Subscribe.html)|You can subscribe to input events from Pointer sources here. StereoKit will call your callback and pass along a Pointer that matches the position of that pointer at the moment the event occurred. This can be more accurate than polling for input data, since polling happens specifically at frame start.|
|[TextConsume]({{site.url}}/Pages/StereoKit/Input/TextConsume.html)|Returns the next text character from the list of characters that have been entered this frame! Will return '\0' if there are no more characters left in the list. These are from the system's text entry system, and so can be unicode, will repeat if their 'key' is held down, and could arrive from something like a copy/paste operation.  If you wish to reset this function to begin at the start of the read list on the next call, you can call `Input.TextReset`.|
|[TextInjectChar]({{site.url}}/Pages/StereoKit/Input/TextInjectChar.html)|This will inject a UTF32 Unicode text character into StereoKit's text input queue. It will be available at the start of the next frame, and will be indistinguishable from normal text entry.  This will _not_ submit key press/release events to StereoKit's input queue, use KeyInjectPress/Release for that.|
|[TextReset]({{site.url}}/Pages/StereoKit/Input/TextReset.html)|Resets the `Input.TextConsume` read list back to the start. For example, `UI.Input` will _not_ call `TextReset`, so it effectively will consume those characters, hiding them from any `TextConsume` calls following it. If you wanted to check the current frame's text, but still allow `UI.Input` to work later on in the frame, you would read everything with `TextConsume`, and then `TextReset` afterwards to reset the read list for the following `UI.Input`.|
|[Unsubscribe]({{site.url}}/Pages/StereoKit/Input/Unsubscribe.html)|Unsubscribes a listener from input events.|
