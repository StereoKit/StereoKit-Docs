# StereoKit — API Reference

StereoKit is a lightweight, low-dependency C# library for XR apps and games built on OpenXR.
This file is part of a 2-file AI-friendly documentation set:
- **StereoKit-docs-API.md** — condensed API reference for every type — signatures, summaries, parameters (this file)
- StereoKit-docs-reference.md — conceptual guides and runnable C# code examples, one section per API member
Source: https://stereokit.net/preview  (generated from StereoKit's XML doc comments)

## enum Align

A bit-flag enum for describing alignment or positioning. Items can be combined using the '|' operator, like so: `Align alignment = Align.YTop | Align.XLeft;` Avoid combining multiple items of the same axis. There are also a complete list of valid bit flag combinations! These are the values without an axis listed in their names, 'TopLeft', 'BottomCenter', etc.

- `Align.BottomCenter` — Center on the X axis, and bottom on the Y axis. This is a combination of XCenter and YBottom.
- `Align.BottomLeft` — Start on the left of the X axis, and bottom on the Y axis. This is a combination of XLeft and YBottom.
- `Align.BottomRight` — Start on the right of the X axis, and bottom on the Y axis.This is a combination of XRight and YBottom.
- `Align.Center` — Center on both X and Y axes. This is a combination of XCenter and YCenter.
- `Align.CenterLeft` — Start on the left of the X axis, center on the Y axis. This is a combination of XLeft and YCenter.
- `Align.CenterRight` — Start on the right of the X axis, center on the Y axis. This is a combination of XRight and YCenter.
- `Align.None` — No alignment specified. For elements that have a natural default alignment (such as image buttons), this falls back to that default.
- `Align.TopCenter` — Center on the X axis, and top on the Y axis. This is a combination of XCenter and YTop.
- `Align.TopLeft` — Start on the left of the X axis, and top on the Y axis. This is a combination of XLeft and YTop.
- `Align.TopRight` — Start on the right of the X axis, and top on the Y axis. This is a combination of XRight and YTop.
- `Align.XCenter` — On the x axis, the item should be centered.
- `Align.XLeft` — On the x axis, this item should start on the left.
- `Align.XRight` — On the x axis, this item should start on the right.
- `Align.YBottom` — On the y axis, this item should start on the bottom.
- `Align.YCenter` — On the y axis, the item should be centered.
- `Align.YTop` — On the y axis, this item should start at the top.

## class Anchor

An Anchor in StereoKit is a completely virtual pose that is pinned to a real-world location. They are creatable via code, generally can persist across sessions, may provide additional stability beyond the system's 6dof tracking, and are not physical objects! This functionality is backed by extensions like the Microsoft Spatial Anchor, or the Facebook Spatial Entity. If a proper anchoring system isn't present on the device, StereoKit will fall back to a stage- relative anchor. Stage-relative anchors may be a good solution for devices with a consistent stage, but may be troublesome if the user adjusts their stage frequently. A conceptual guide to Anchors: - A cloud anchor is an Anchor - A QR code is _not_ an Anchor (it's physical) - That spot around where your coffee usually sits can be an Anchor - A semantically labeled floor plane is _not_ an Anchor (it's physical)

- `string Anchor.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on! This is StereoKit's asset ID, and not the system's unique Name for the anchor.
- `string Anchor.Name` — A unique system provided name identifying this anchor. This will be the same across sessions for persistent Anchors.
- `bool Anchor.Persistent` — Will this Anchor persist across multiple app sessions? You can use `TrySetPersistent` to change this value.
- `Pose Anchor.Pose` — The most recently identified Pose of the Anchor. While an Anchor will generally be in the same position once discovered, it may shift slightly to compensate for drift in the device's 6dof tracking. Anchor Poses when tracked are more accurate than world-space positions.
- `BtnState Anchor.Tracked` — Does the device consider this Anchor to be tracked? This doesn't require the Anchor to be visible, just that the device knows where this Anchor is located.
- `static IEnumerable`1 Anchor.Anchors` — This is an enumeration of all Anchors that exist in StereoKit at the current moment.
- `static AnchorCaps Anchor.Capabilities` — This describes the anchoring capabilities of the current XR anchoring backend. Some systems like a HoloLens can create Anchors that provide stability, and can persist across multiple sessions. Some like SteamVR might be able to make a persistent Anchor that's relative to the stage, but doesn't provide any stability benefits.
- `static IEnumerable`1 Anchor.NewAnchors` — This is an enumeration of all Anchors that are new to StereoKit this frame.
- `static void Anchor.ClearStored()` — This will remove persistence from all Anchors the app knows about, even if they aren't tracked.
- `static Anchor Anchor.FromPose(Pose pose)` — This creates a new Anchor from a world space pose.
  - `pose` — A world space pose for the new Anchor.
  - returns — A new Anchor at the Pose provided. This Anchor is not guaranteed to be tracked, but will start at the Pose provided.
- `bool Anchor.TryGetPerceptionAnchor(IntPtr& spatialAnchor)` — Tries to get the underlying perception spatial anchor as a COM pointer. Use this when you need the raw IntPtr for interop or custom marshalling.
  - `spatialAnchor` — The raw COM pointer to the spatial anchor.
  - returns — True if the pointer was successfully obtained, false otherwise.
- `bool Anchor.TryGetPerceptionAnchor(T& spatialAnchor)` — Tries to get the underlying perception spatial anchor for platforms using Microsoft spatial anchors.
  - `spatialAnchor` — The spatial anchor.
  - returns — True if the perception spatial anchor was successfully obtained, false otherwise.
- `bool Anchor.TrySetPersistent(bool persistent)` — This will attempt to make or prevent this Anchor from persisting across app sessions. You may want to check if the system is capable of persisting anchors via Anchors.Capabilities, but it's possible for this to fail on the OpenXR runtime's side as well.
  - `persistent` — Whether this should or shouldn't persist across sessions.
  - returns — Success or failure of setting persistence.

## enum AnchorCaps

This is a bit flag that describes what an anchoring system is capable of doing.

- `AnchorCaps.Stability` — This anchor system will provide extra accuracy in locating the Anchor, so if the SLAM/6dof tracking drifts over time or distance, the anchor may remain fixed in the correct physical space, instead of drifting with the virtual content.
- `AnchorCaps.Storable` — This anchor system can store/persist anchors across sessions. Anchors must still be explicitly marked as persistent.

## class Anim

A link to a Model's animation! You can use this to get some basic information about the animation, or store it for reference. This maintains a link to the Model asset, and will keep it alive as long as this object lives.

- `float Anim.Duration` — The duration of the animation at normal playback speed, in seconds.
- `string Anim.Name` — The name of the animation as provided by the original asset.

## enum AnimMode

Describes how an animation is played back, and what to do when the animation hits the end.

- `AnimMode.Loop` — If the animation reaches the end, it will always loop back around to the start again.
- `AnimMode.Manual` — The animation will not progress on its own, and instead must be driven by providing information to the model's AnimTime or AnimCompletion properties.
- `AnimMode.Once` — When the animation reaches the end, it will freeze in-place.

## enum AppFocus

This tells about the app's current focus state, whether it's active and receiving input, or if it's backgrounded or hidden. This can be important since apps may still run and render when unfocused, as the app may still be visible behind the app that _does_ have focus.

- `AppFocus.Active` — This StereoKit app is active, focused, and receiving input from the user. Application should behave as normal.
- `AppFocus.Background` — This StereoKit app has been unfocused, something may be compositing on top of the app such as an OS dashboard. The app is still visible, but some other thing has focus and is receiving input. You may wish to pause, disable input tracking, or other such things.
- `AppFocus.Hidden` — This app is not rendering currently.

## enum AppMode

Specifies a type of display mode StereoKit uses, like Mixed Reality headset display vs. a PC display, or even just rendering to an offscreen surface, or not rendering at all!

- `AppMode.None` — No mode has been specified, default behavior will be used. StereoKit will pick XR in this case.
- `AppMode.Offscreen` — No display at all! StereoKit won't even render to a texture unless requested to. This may be good for running tests on a server, or doing graphics related tool or CLI work.
- `AppMode.Simulator` — Creates a flat window, and simulates some XR functionality. Great for development and debugging.
- `AppMode.Window` — Creates a flat window and displays to that, but doesn't simulate XR at all. You will need to control your own camera here. This can be useful if using StereoKit for non-XR 3D applications.
- `AppMode.XR` — Creates an OpenXR or WebXR instance, and drives display/input through that.

## delegate AppShutdown

This is the callback signature for SK.Run's shutdown function. It receives context data that was passed to SK.Run.

## delegate AppStep

This is the callback signature for SK.Run's step function. It receives context data that was passed to SK.Run.

## delegate AssetOnLoadCallback

A callback for when an asset finishes loading.

## static class Assets

If you want to manage loading assets, this is the class for you!

- `static IEnumerable`1 Assets.All` — This is an enumeration of all asset object loaded by StereoKit at the current moment.
- `static int Assets.CurrentTask` — This is the index of the current asset loading task. Note that to load one asset, multiple tasks are generated.
- `static int Assets.CurrentTaskPriority` — StereoKit processes tasks in order of priority. This returns the priority of the current task, and can be used to wait until all tasks within a certain priority range have been completed.
- `static String[] Assets.ModelFormats` — A list of supported model format extensions. This pairs pretty well with `Platform.FilePicker` when attempting to load a `Model`!
- `static String[] Assets.TextureFormats` — A list of supported texture format extensions. This pairs pretty well with `Platform.FilePicker` when attempting to load a `Tex`!
- `static int Assets.TotalTasks` — This is the total number of tasks that have been added to the loading system, including all completed and pending tasks. Note that to load one asset, multiple tasks are generated.
- `static void Assets.BlockForPriority(int priority)` — This will block the execution of the application until all asset tasks below the priority value have completed loading. To block until all assets are loaded, pass in int.MaxValue for the priority.
  - `priority` — Block the app until this priority level is complete.
- `static void Assets.BlockUntil(IAsset asset, AssetState state)` — This will block execution until the given asset reaches the specified loading state. If the asset has already reached or passed that state, this returns immediately. If the asset is in an error state, this also returns immediately.
  - `asset` — The asset to wait on.
  - `state` — The state to wait for, such as AssetState.Loaded or AssetState.LoadedMeta.
- `static IEnumerable`1 Assets.Type(Type type)` — Allows for enumerating all StereoKit assets matching the specified type.
  - `type` — Any `IAsset` type.
  - returns — An enumeration of all loaded asset objects that match the given type.
  - Example: see `Assets.Type` in StereoKit-docs-reference.md
- `static IEnumerable`1 Assets.Type()` — Allows for enumerating all StereoKit assets matching the specified type.
  - returns — An enumeration of all loaded asset objects that match the given type.
  - Example: see `Assets.Type` in StereoKit-docs-reference.md

## enum AssetState

StereoKit uses an asynchronous loading system to prevent assets from blocking execution! This means that asset loading systems will return an asset to you right away, even though it is still being processed in the background. This enum will tell you about what state the asset is currently in, so you know what sort of behavior to expect from it.

- `AssetState.Error` — An unknown error occurred when trying to load the asset! Check the logs for additional details.
- `AssetState.ErrorNotFound` — The asset data was not found! This is most likely an issue with a bad file path, or file permissions. Check the logs for additional details.
- `AssetState.ErrorUnsupported` — This asset encountered an issue when parsing the source data. Either the format is unrecognized by StereoKit, or the data may be corrupt. Check the logs for additional details.
- `AssetState.Loaded` — This asset is completely loaded without issues, and is ready for use!
- `AssetState.LoadedMeta` — This asset is still loading, but some of the higher level data is already available for inspection without blocking the app. Attempting to access the core asset data will result in blocking the app's execution until that data is loaded!
- `AssetState.Loading` — This asset is currently queued for loading, but hasn't received any data yet. Attempting to access metadata or asset data will result in blocking the app's execution until that data is loaded!
- `AssetState.None` — This asset is in its default state. It has not been told to load anything, nor does it have any data!

## enum AssetType

A flag for what 'type' an Asset may store.

- `AssetType.Anchor` — An Anchor.
- `AssetType.Compute` — A Compute dispatch object
- `AssetType.ComputeBuffer` — A ComputeBuffer
- `AssetType.Font` — A Font.
- `AssetType.Material` — A Material.
- `AssetType.MaterialBuffer` — A MaterialBuffer
- `AssetType.Mesh` — A Mesh.
- `AssetType.Model` — A Model.
- `AssetType.None` — No type, this may come from some kind of invalid Asset id.
- `AssetType.RenderList` — A RenderList
- `AssetType.Shader` — A Shader.
- `AssetType.Solid` — A Solid.
- `AssetType.Sound` — A Sound.
- `AssetType.Sprite` — A Sprite.
- `AssetType.Tex` — A Tex.

## delegate AudioGenerator

A callback for generating audio samples procedurally.

## static class Backend

This class exposes some of StereoKit's backend functionality. This allows for tighter integration with certain platforms, but also means your code becomes less portable. Everything in this class should be guarded by availability checks.

- `static BackendGraphics Backend.Graphics` — This describes the graphics API that StereoKit is using for rendering. StereoKit is Vulkan-only, so this will report [`BackendGraphics.Vulkan`]({{site.url}}/Pages/StereoKit/BackendGraphics/Vulkan.html) on all supported platforms.
- `static BackendPlatform Backend.Platform` — What kind of platform is StereoKit running on? This can be important to tell you what APIs or functionality is available to the app.
- `static BackendXRType Backend.XRType` — What technology is being used to drive StereoKit's XR functionality? OpenXR is the most likely candidate here, but if you're running the flatscreen Simulator, or running in the web with WebXR, then this will reflect that.

## static class Backend.Android

This class contains variables that may be useful for interop with the Android operating system, or other Android libraries.

- `static IntPtr Backend.Android.Activity` — This is the `jobject` activity that StereoKit uses on Android. This is only valid after SK.Initialize, on Android systems.
- `static IntPtr Backend.Android.JavaVM` — This is the `JavaVM*` object that StereoKit uses on Android. This is only valid after SK.Initialize, on Android systems.
- `static IntPtr Backend.Android.JNIEnvironment` — This is the `JNIEnv*` object that StereoKit uses on Android. This is only valid after SK.Initialize, on Android systems.

## static class Backend.D3D11

When using Direct3D11 for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. This is the default rendering backend on Windows.

- `static IntPtr Backend.D3D11.D3DContext` — This is the main `ID3D11DeviceContext*` StereoKit uses for rendering. (No longer supported, always returns IntPtr.Zero)
- `static IntPtr Backend.D3D11.D3DDevice` — This is the main `ID3D11Device*` StereoKit uses for rendering. (No longer supported, always returns IntPtr.Zero)

## static class Backend.OpenGL_GLX

When using OpenGL with the GLX loader for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. This is the default rendering backend for Linux.

- `static IntPtr Backend.OpenGL_GLX.Context` — This is the `GLXContext` that StereoKit uses with `glXMakeCurrent` (No longer supported, always returns IntPtr.Zero)
- `static IntPtr Backend.OpenGL_GLX.Display` — This is the `Display*` from X used to create the GLX context. (No longer supported, always returns IntPtr.Zero)
- `static IntPtr Backend.OpenGL_GLX.Drawable` — This is the `GLXDrawable` that StereoKit uses with `glXMakeCurrent`. (No longer supported, always returns IntPtr.Zero)

## static class Backend.OpenGL_WGL

When using OpenGL with the WGL loader for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. This is Windows only, and requires gloabally defining SKG_FORCE_OPENGL when building the core StereoKitC library.

- `static IntPtr Backend.OpenGL_WGL.HDC` — This is the Handle to Device Context `HDC` StereoKit uses with `wglMakeCurrent`. (No longer supported, always returns IntPtr.Zero)
- `static IntPtr Backend.OpenGL_WGL.HGLRC` — This is the Handle to an OpenGL Rendering Context `HGLRC` StereoKit uses with `wglMakeCurrent`. (No longer supported, always returns IntPtr.Zero)

## static class Backend.OpenGLES_EGL

When using OpenGL ES with the EGL loader for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. This is the default rendering backend for Android, and Linux builds can be configured to use this with the SK_LINUX_EGL cmake option when building the core StereoKitC library.

- `static IntPtr Backend.OpenGLES_EGL.Context` — This is the `EGLContext` StereoKit receives from `eglCreateContext`. (No longer supported, always returns IntPtr.Zero)
- `static IntPtr Backend.OpenGLES_EGL.Display` — This is the `EGLDisplay` StereoKit receives from `eglGetDisplay` (No longer supported, always returns IntPtr.Zero)

## static class Backend.OpenXR

This class is NOT of general interest, unless you are trying to add support for some unusual OpenXR extension! StereoKit should do all the OpenXR work that most people will need. If you find yourself here anyhow for something you feel StereoKit should support already, please add a feature request on GitHub! This class contains handles and methods for working directly with OpenXR. This may allow you to activate or work with OpenXR extensions that StereoKit hasn't implemented or exposed yet. Check that Backend.XRType is OpenXR before using any of this. These properties may best be used with some external OpenXR binding library, but you may get some limited mileage with the API as provided here.

- `static Int64 Backend.OpenXR.EyesSampleTime` — Type: XrTime. This is the OpenXR time of the eye tracker sample associated with the current value of [`Input.Eyes`]({{site.url}}/Pages/StereoKit/Input/Eyes.html).
- `static UInt64 Backend.OpenXR.HeadSpace` — Type: XrSpace. StereoKit's head/view reference space, valid after SK.Initialize, this is created from `XR_REFERENCE_SPACE_TYPE_VIEW`.
- `static UInt64 Backend.OpenXR.Instance` — Type: XrInstance. StereoKit's instance handle, valid after SK.Initialize.
- `static UInt64 Backend.OpenXR.Session` — Type: XrSession. StereoKit's current session handle, this will be valid after SK.Initialize, but the session may not be started quite so early.
- `static UInt64 Backend.OpenXR.Space` — Type: XrSpace. StereoKit's primary coordinate space, valid after SK.Initialize, this will most likely be created from `XR_REFERENCE_SPACE_TYPE_UNBOUNDED_MSFT` or `XR_REFERENCE_SPACE_TYPE_LOCAL`.
- `static UInt64 Backend.OpenXR.SystemId` — Type: XrSystemId. This is the id of the device StereoKit is currently using! This is the result of calling `xrGetSystem` with `XR_FORM_FACTOR_HEAD_MOUNTED_DISPLAY`.
- `static Int64 Backend.OpenXR.Time` — Type: XrTime. This is the OpenXR time for the current frame, and is available after SK.Initialize.
- `static bool Backend.OpenXR.UseMinimumExts` — Tells StereoKit to request only the extensions that are absolutely critical to StereoKit. You can still request extensions via `OpenXR.RequestExt`, and this can be used to opt-in to extensions that StereoKit would normally request automatically.
- `static void Backend.OpenXR.AddCompositionLayer(T XrCompositionLayerX, int sortOrder)` — This allows you to add XrCompositionLayers to the list that StereoKit submits to xrEndFrame. You must call this every frame you wish the layer to be included.
  - `XrCompositionLayerX` — A serializable XrCompositionLayer struct that follows the XrCompositionLayerBaseHeader data pattern.
  - `sortOrder` — An sort order value for sorting with other composition layers in the list. The primary projection layer that StereoKit renders to is at 0, -1 would be before it, and +1 would be after.
- `static void Backend.OpenXR.AddEndFrameChain(T XrBaseHeader)` — This adds an item to the chain of objects submitted to StereoKit's xrEndFrame call!
  - `XrBaseHeader` — An OpenXR object that will be chained into the xrEndFrame call.
- `static void Backend.OpenXR.ExcludeExt(string extensionName)` — This ensures that StereoKit does not load a particular extension! StereoKit will behave as if the extension is not available on the device. It will also be excluded even if you explicitly requested it with `RequestExt` earlier, or afterwards. This MUST be called before SK.Initialize.
  - `extensionName` — The extension name as listed in the OpenXR spec. For example: "XR_EXT_hand_tracking".
- `static bool Backend.OpenXR.ExtEnabled(string extensionName)` — This tells if an OpenXR extension has been requested and successfully loaded by the runtime. This MUST only be called after SK.Initialize.
  - `extensionName` — The extension name as listed in the OpenXR spec. For example: "XR_EXT_hand_tracking".
  - returns — If the extension is available to use.
  - Example: see `Backend.OpenXR.ExtEnabled` in StereoKit-docs-reference.md
- `static TDelegate Backend.OpenXR.GetFunction(string functionName)` — This is basically `xrGetInstanceProcAddr` from OpenXR, you can use this to get and call functions from an extension you've loaded. This uses `Marshal.GetDelegateForFunctionPointer` to turn the result into a delegate that you can call.
  - `functionName` — 
  - returns — A delegate, or null on failure.
  - Example: see `Backend.OpenXR.GetFunction` in StereoKit-docs-reference.md
- `static IntPtr Backend.OpenXR.GetFunctionPtr(string functionName)` — This is basically `xrGetInstanceProcAddr` from OpenXR, you can use this to get and call functions from an extension you've loaded. You can use `Marshal.GetDelegateForFunctionPointer` to turn the result into a delegate that you can call.
  - `functionName` — 
  - returns — A function pointer, or null on failure. You can use `Marshal.GetDelegateForFunctionPointer` to turn this into a delegate that you can call.
- `static void Backend.OpenXR.RequestExt(string extensionName)` — Requests that OpenXR load a particular extension. This MUST be called before SK.Initialize. Note that it's entirely possible that your extension will not load on certain runtimes, so be sure to check ExtEnabled to see if it's available to use.
  - `extensionName` — The extension name as listed in the OpenXR spec. For example: "XR_EXT_hand_tracking".
  - Example: see `Backend.OpenXR.RequestExt` in StereoKit-docs-reference.md
- `static void Backend.OpenXR.SetHandJointScale(float scaleFactor)` — This sets a scaling value for joints provided by the articulated hand extension. Some systems just don't seem to get their joint sizes right!
  - `scaleFactor` — 1 being the default value, 2 being twice as large as normal, and 0.5 being half as big as normal.

## static class Backend.Vulkan

When using Vulkan for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. Vulkan is StereoKit's only rendering backend, so these are valid on all supported platforms after SK.Initialize.

- `static IntPtr Backend.Vulkan.Device` — The `VkDevice` StereoKit created (or was given, when running under OpenXR) for rendering. Valid after SK.Initialize.
- `static IntPtr Backend.Vulkan.Instance` — The `VkInstance` StereoKit created (or was given, when running under OpenXR) for rendering. Valid after SK.Initialize.
- `static IntPtr Backend.Vulkan.PhysicalDevice` — The `VkPhysicalDevice` StereoKit is rendering with. Valid after SK.Initialize.
- `static bool Backend.Vulkan.ExtEnabled(string extensionName)` — Checks if a Vulkan extension was enabled at init, regardless of which request asked for it. This MUST only be called after SK.Initialize.
  - `extensionName` — The extension name, for example "VK_KHR_swapchain".
  - returns — If the extension is available to use.
- `static int Backend.Vulkan.GetFrameFenceFd()` — Returns a sync file descriptor for the most recently submitted frame's GPU work! Waiting on it (e.g. via EGL_ANDROID_native_fence_sync) guarantees all rendering submitted up to the last frame end has completed. Call from StereoKit's main thread. The caller owns the descriptor and must close it. Only functional on platforms and devices supporting external fence export.
  - returns — A sync file descriptor, or -1 when unsupported or no frame has been submitted yet.
- `static TDelegate Backend.Vulkan.GetFunction(string functionName)` — Resolves a Vulkan function pointer and wraps it as a delegate, using `vkGetDeviceProcAddr` with a `vkGetInstanceProcAddr` fallback. Use this to call into extensions you've enabled via [`Backend.Vulkan.Request`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/Request.html).
  - `functionName` — The Vulkan function name, for example "vkCmdBeginRenderingKHR".
  - returns — A delegate, or null on failure.
- `static IntPtr Backend.Vulkan.GetFunctionPtr(string functionName)` — Resolves a Vulkan function pointer, using `vkGetDeviceProcAddr` with a `vkGetInstanceProcAddr` fallback. Use this to call into extensions you've enabled via [`Backend.Vulkan.Request`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/Request.html). You can use `Marshal.GetDelegateForFunctionPointer` to turn the result into a callable delegate.
  - `functionName` — The Vulkan function name, for example "vkCmdBeginRenderingKHR".
  - returns — A function pointer, or IntPtr.Zero on failure.
- `static IntPtr Backend.Vulkan.Queue(BackendVulkanQueue queue)` — Gets the `VkQueue` StereoKit uses for the given queue family. Currently only [`BackendVulkanQueue.Graphics`]({{site.url}}/Pages/StereoKit/BackendVulkanQueue/Graphics.html) has a handle available; the others return IntPtr.Zero until StereoKit makes real use of them. If you submit work to this queue, you MUST guard it with [`Backend.Vulkan.QueueLock`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/QueueLock.html) / [`Backend.Vulkan.QueueUnlock`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html), since StereoKit shares it across threads.
  - `queue` — Which queue family to retrieve the queue for.
  - returns — A `VkQueue` handle, or IntPtr.Zero if no queue handle is available for that family.
- `static uint Backend.Vulkan.QueueFamilyIndex(BackendVulkanQueue queue)` — Gets the queue family index StereoKit uses for the given queue family. This is the value you'd use when creating command pools or performing queue family ownership transfers.
  - `queue` — Which queue family to look up.
  - returns — The Vulkan queue family index, or uint.MaxValue if that family is not available on this device (for example, video decode).
- `static void Backend.Vulkan.QueueLock(BackendVulkanQueue queue)` — Locks the mutex StereoKit uses to guard the given queue family, so you can safely submit work to a queue StereoKit also uses. Always pair this with [`Backend.Vulkan.QueueUnlock`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html). Note that queue families that resolve to the same index share a single lock, so don't nest locks across two families that may alias.
  - `queue` — Which queue family's lock to acquire.
- `static void Backend.Vulkan.QueueUnlock(BackendVulkanQueue queue)` — Releases the queue family lock acquired via [`Backend.Vulkan.QueueLock`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/QueueLock.html).
  - `queue` — Which queue family's lock to release.
- `static void Backend.Vulkan.Request(BackendVulkanRequest request)` — Registers a request for Vulkan instance/device extensions and device features. This MUST be called before SK.Initialize. A request enables atomically: only when all of its extensions are present, and every requested feature bit is supported. If [`BackendVulkanRequest.required`]({{site.url}}/Pages/StereoKit/BackendVulkanRequest/required.html) is true and the request can't be satisfied, SK.Initialize will fail! After initialization, check the result with [`Backend.Vulkan.RequestEnabled`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/RequestEnabled.html) (by name) or [`Backend.Vulkan.ExtEnabled`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/ExtEnabled.html) (by extension name).
  - `request` — The extensions and features to request. Its arrays and feature struct pointers only need to remain valid for the duration of this call - StereoKit copies everything it needs.
- `static bool Backend.Vulkan.RequestEnabled(string name)` — Checks if a named request registered via [`Backend.Vulkan.Request`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/Request.html) was successfully enabled. This MUST only be called after SK.Initialize.
  - `name` — The name given to the BackendVulkanRequest.
  - returns — If the request's extensions and features were all enabled.

## enum BackendGraphics

This describes the graphics API that StereoKit is using for rendering.

- `BackendGraphics.D3D11` — DirectX's Direct3D11 is used for rendering! This is used by default on Windows. (No longer supported)
- `BackendGraphics.None` — An invalid default value.
- `BackendGraphics.OpenGL_GLX` — OpenGL is used for rendering, using GLX (OpenGL Extension to the X Window System) for loading. This is used by default on Linux. (No longer supported)
- `BackendGraphics.OpenGL_WGL` — OpenGL is used for rendering, using WGL (Windows Extensions to OpenGL) for loading. Native developers can configure SK to use this on Windows. (No longer supported)
- `BackendGraphics.OpenGLES_EGL` — OpenGL ES is used for rendering, using EGL (EGL Native Platform Graphics Interface) for loading. This is used by default on Android, and native developers can configure SK to use this on Linux. (No longer supported)
- `BackendGraphics.Vulkan` — Vulkan is used for rendering, this works basically on every platform, and is the only backend StereoKit currently supports!
- `BackendGraphics.WebGL` — WebGL is used for rendering. This is used by default on Web. (No longer supported)

## enum BackendPlatform

This describes the platform that StereoKit is running on.

- `BackendPlatform.Android` — This is running as an Android app.
- `BackendPlatform.Linux` — This is running as a Linux app.
- `BackendPlatform.Macos` — This is running as a macOS app.
- `BackendPlatform.Uwp` — This is running as a Windows app using the UWP APIs. (No longer supported)
- `BackendPlatform.Web` — This is running in a browser.
- `BackendPlatform.Win32` — This is running as a Windows app using the Win32 APIs.

## struct BackendVulkanFeature

A single Vulkan feature struct to request as part of a [`BackendVulkanRequest`]({{site.url}}/Pages/StereoKit/BackendVulkanRequest.html). See [`Backend.Vulkan.Request`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/Request.html) for details.

- `int BackendVulkanFeature.size` — The size of the struct vkStruct points at, in bytes.
- `IntPtr BackendVulkanFeature.vkStruct` — A pointer to a pinned VkPhysicalDevice*Features struct with its sType set, and the feature bits you want enabled set to VK_TRUE. This must NOT be a VkPhysicalDeviceFeatures2. The pointer only needs to remain valid for the duration of the Backend.Vulkan.Request call.
- `void BackendVulkanFeature(IntPtr vkStruct, int size)` — Creates a feature request from a pointer to a pinned VkPhysicalDevice*Features struct and its size in bytes.
  - `vkStruct` — A pointer to a pinned VkPhysicalDevice*Features struct, with its sType and desired VK_TRUE bits set.
  - `size` — The size of the struct vkStruct points at, in bytes.

## enum BackendVulkanQueue

Identifies a Vulkan queue family that StereoKit's Vulkan backend interacts with. Use this with the queue accessors on Backend.Vulkan.

- `BackendVulkanQueue.Graphics` — The primary graphics queue. This is the queue StereoKit submits all of its rendering work to, and the only queue with a handle currently available via backend_vulkan_get_queue.
- `BackendVulkanQueue.Transfer` — A queue family suitable for transfer operations. StereoKit does not yet use a dedicated transfer queue, so no queue handle is available here yet, but the family index is provided for advanced interop.
- `BackendVulkanQueue.VideoDecode` — A queue family suitable for Vulkan video decode. Not present on all devices, in which case the family index will be UINT32_MAX.

## struct BackendVulkanRequest

A request for Vulkan instance/device extensions and device features, registered via [`Backend.Vulkan.Request`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/Request.html) before SK.Initialize.

- `String[] BackendVulkanRequest.deviceExtensions` — Vulkan device extension names this request needs.
- `BackendVulkanFeature[] BackendVulkanRequest.features` — Vulkan device features this request needs. Their bits are queried for support before being enabled.
- `String[] BackendVulkanRequest.instanceExtensions` — Vulkan instance extension names this request needs.
- `string BackendVulkanRequest.name` — An optional name used as a handle for [`Backend.Vulkan.RequestEnabled`]({{site.url}}/Pages/StereoKit/Backend.Vulkan/RequestEnabled.html). null makes the request anonymous - it still contributes its extensions and features, but can't be queried by name.
- `bool BackendVulkanRequest.required` — If true, SK.Initialize will fail should this request go unsatisfied. If false, an unmet request is simply left disabled.

## enum BackendXRType

This describes what technology is being used to power StereoKit's XR backend.

- `BackendXRType.None` — StereoKit is not using an XR backend of any sort. That means the application is flatscreen and has the simulator disabled.
- `BackendXRType.OpenXR` — StereoKit is currently powered by OpenXR! This means we're running on a real XR device. Not all OpenXR runtimes provide the same functionality, but we will have access to more fun stuff :)
- `BackendXRType.Simulator` — StereoKit is using the flatscreen XR simulator. Inputs are emulated, and some advanced XR functionality may not be available.
- `BackendXRType.WebXR` — StereoKit is running in a browser, and is using WebXR!

## struct Bounds

Bounds is an axis aligned bounding box type that can be used for storing the sizes of objects, calculating containment, intersections, and more! While the constructor uses a center+dimensions for creating a bounds, don't forget the static From* methods that allow you to define a Bounds from different types of data!

- `Vec3 Bounds.center` — The exact center of the Bounds!
- `Vec3 Bounds.dimensions` — The total size of the box, from one end to the other. This is the width, height, and depth of the Bounds.
- `Vec3 Bounds.TLB` — From the front, this is the Top (Y+), Left (X+), Back (Z+) of the bounds. Useful when working with UI layout bounds.
- `Vec3 Bounds.TLC` — From the front, this is the Top (Y+), Left (X+), Center (Z0) of the bounds. Useful when working with UI layout bounds.
- `void Bounds(Vec3 center, Vec3 totalDimensions)` — Creates a bounding box object!
  - `center` — The exact center of the box.
  - `totalDimensions` — The total size of the box, from one end to the other. This is the width, height, and depth of the Bounds.
- `void Bounds(Vec3 totalDimensions)` — Creates a bounding box object centered around zero!
  - `totalDimensions` — The total size of the box, from one end to the other. This is the width, height, and depth of the Bounds.
- `void Bounds(float totalDimensionX, float totalDimensionY, float totalDimensionZ)` — Creates a bounding box object centered around zero!
  - `totalDimensionX` — Total size on the X axis.
  - `totalDimensionY` — Total size on the Y axis.
  - `totalDimensionZ` — Total size on the Z axis.
- `bool Bounds.Contains(Vec3 pt)` — Does the Bounds contain the given point? This includes points that are on the surface of the Bounds.
  - `pt` — A point in the same coordinate space as the Bounds.
  - returns — True if the point is on, or in the Bounds.
- `bool Bounds.Contains(Vec3 linePt1, Vec3 linePt2)` — Does the Bounds contain or intersects with the given line?
  - `linePt1` — Start of the line
  - `linePt2` — End of the line
  - returns — True if the line is in, or intersects with the bounds.
- `bool Bounds.Contains(Vec3 linePt1, Vec3 linePt2, float radius)` — Does the bounds contain or intersect with the given capsule?
  - `linePt1` — Start of the capsule.
  - `linePt2` — End of the capsule
  - `radius` — Radius of the capsule.
  - returns — True if the capsule is in, or intersects with the bounds.
  - Example: see `Bounds.Contains` in StereoKit-docs-reference.md
- `static Bounds Bounds.FromCorner(Vec3 bottomLeftBack, Vec3 dimensions)` — Create a bounding box from a corner, plus box dimensions.
  - `bottomLeftBack` — The -X,-Y,-Z corner of the box.
  - `dimensions` — The total dimensions of the box.
  - returns — A Bounds object that extends from bottomLeftBack to bottomLeftBack+dimensions.
  - Example: see `Bounds.FromCorner` in StereoKit-docs-reference.md
- `static Bounds Bounds.FromCorners(Vec3 bottomLeftBack, Vec3 topRightFront)` — Create a bounding box between two corner points.
  - `bottomLeftBack` — The -X,-Y,-Z corner of the box.
  - `topRightFront` — The +X,+Y,+Z corner of the box.
  - returns — A Bounds object that extends from bottomLeftBack to topRightFront.
  - Example: see `Bounds.FromCorners` in StereoKit-docs-reference.md
- `Bounds Bounds.Grown(Vec3 pt)` — Grow the Bounds to encapsulate the provided point. Returns the result, and does NOT modify the current bounds.
  - `pt` — The point to encapsulate! This should be in the same space as the bounds.
  - returns — The bounds that also encapsulate the provided point.
- `Bounds Bounds.Grown(Bounds box, Matrix boxTransform)` — Grow the Bounds to encapsulate the provided box after it has been transformed by the provided matrix transform. This will transform each corner of the box, and expand the bounds to encapsulate each point!
  - `box` — The box to encapsulate! The corners of this box are transformed, and then used to grow the Bounds.
  - `boxTransform` — The Matrix transform for the box. If this is just an Identity matrix, you can skip providing a Matrix.
  - returns — The bounds that also encapsulate the provided transformed box.
- `Bounds Bounds.Grown(Bounds box)` — Grow the Bounds to encapsulate the provided box.
  - `box` — The box to encapsulate!
  - returns — The bounds that also encapsulate the provided box.
- `bool Bounds.Intersect(Ray ray, Vec3& at)` — Calculate the intersection between a Ray, and these bounds. Returns false if no intersection occurred, and 'at' will contain the nearest intersection point to the start of the ray if an intersection is found!
  - `ray` — Any Ray in the same coordinate space as the Bounds.
  - `at` — If the return is true, this point will be the closest intersection point to the origin of the Ray.
  - returns — True if an intersection occurred, false if not.
  - Example: see `Bounds.Intersect` in StereoKit-docs-reference.md
- `static Bounds Bounds.*(Bounds a, float b)` — This operator will create a new Bounds that has been properly scaled up by the float. This does affect the center position of the Bounds.
  - `a` — The source Bounds.
  - `b` — A scalar multiplier for the Bounds.
  - returns — A new Bounds that has been scaled.
- `static Bounds Bounds.*(Bounds a, Vec3 b)` — This operator will create a new Bounds that has been properly scaled up by the Vec3. This does affect the center position of the Bounds.
  - `a` — The source Bounds.
  - `b` — A Vec3 multiplier for the Bounds.
  - returns — A new Bounds that has been scaled.
- `void Bounds.Scale(float scale)` — Scale this bounds. It will scale the center as well as	the dimensions! Modifies this bounds object.
  - `scale` — Scale to apply
- `void Bounds.Scale(Vec3 scale)` — Scale this bounds. It will scale the center as well as	the dimensions! Modifies this bounds object.
  - `scale` — Scale to apply
- `Bounds Bounds.Scaled(float scale)` — Scale the bounds. It will scale the center as well as	the dimensions! Returns a new Bounds.
  - `scale` — Scale
  - returns — A new scaled bounds
- `Bounds Bounds.Scaled(Vec3 scale)` — Scale the bounds. It will scale the center as well as	the dimensions! Returns a new Bounds.
  - `scale` — Scale
  - returns — A new scaled bounds
- `string Bounds.ToString()` — Creates a text description of the Bounds, in the format of "[center:X dimensions:X]"
  - returns — A text description of the Bounds, in the format of "[center:X dimensions:X]"
- `Bounds Bounds.Transformed(Matrix transform)` — This returns a Bounds that encapsulates the transformed points of the current Bounds's corners. Note that this will likely introduce a lot of extra empty volume in many cases, as the result is still always axis aligned.
  - `transform` — A transform Matrix for the current Bounds's corners.
  - returns — A Bounds that encapsulates the transformed points of the current Bounds's corners

## enum BtnState

A bit-flag for the current state of a button input.

- `BtnState.Active` — Is the button currently down, pressed?
- `BtnState.Any` — Matches with all states!
- `BtnState.Changed` — Has the button just changed state this frame? Includes presses, releases, and canceled activations.
- `BtnState.Inactive` — Is the button currently up, unpressed?
- `BtnState.JustActive` — Has the button just been pressed? Only true for a single frame.
- `BtnState.JustCanceled` — Was a button activation just canceled this frame, ending without firing because the interactor moved too far away? Only true for a single frame.
- `BtnState.JustInactive` — Has the button just been released? Only true for a single frame.

## static class BtnStateExtensions

A collection of extension methods for the BtnState enum that makes bit-field checks a little easier.
- `static bool BtnStateExtensions.IsActive(BtnState state)` — Is the button pressed?
  - returns — True if pressed, false if not.
- `static bool BtnStateExtensions.IsChanged(BtnState state)` — Was the button either presses or released this frame?
  - returns — True if the state just changed this frame, false if not.
- `static bool BtnStateExtensions.IsJustActive(BtnState state)` — Has the button just been pressed this frame?
  - returns — True if pressed, false if not.
- `static bool BtnStateExtensions.IsJustCanceled(BtnState state)` — Was a button activation just canceled this frame, ending without firing because the interactor moved too far away?
  - returns — True if just canceled, false if not.
- `static bool BtnStateExtensions.IsJustInactive(BtnState state)` — Has the button just been released this frame?
  - returns — True if released, false if not.
- `static BtnState BtnStateExtensions.Make(bool wasActive, bool isActive)` — Creates a Button State using the current and previous frame's state! These two states allow us to add the "JustActive" and "JustInactive" bitflags when changes happen.
  - `wasActive` — Was it active previously?
  - `isActive` — And is it active currently?
  - returns — A bitflag with "Just" events added in!

## struct Color

A color value stored as 4 floats with values that are generally between 0 and 1! Note that there's also a Color32 structure, and that 4 floats is generally a lot more than you need. So, use this for calculating individual colors at quality, but maybe store them en-masse with Color32! Also note that RGB is often a terrible color format for picking colors, but it's how our displays work and we're stuck with it. If you want to create a color via code, try out the static Color.HSV method instead! A note on gamma space vs. linear space colors! `Color` is not inherently one or the other, but most color values we work with tend to be gamma space colors, so most functions in StereoKit are gamma space. There are occasional functions that will ask for linear space colors instead, primarily in performance critical places, or places where a color may not always be a color! However, performing math on gamma space colors is bad, and will result in incorrect colors. We do our best to indicate what color space a function uses, but it's not enforced through syntax!

- `float Color.a` — Alpha, or opacity component, a value that is generally between 0-1, where 0 is completely transparent, and 1 is completely opaque.
- `float Color.b` — Blue component, a value that is generally between 0-1
- `float Color.g` — Green component, a value that is generally between 0-1
- `float Color.r` — Red component, a value that is generally between 0-1
- `static Color Color.Black` — Pure opaque black! Same as (0,0,0,1).
- `static Color Color.BlackTransparent` — Pure transparent black! Same as (0,0,0,0).
- `static Color Color.White` — Pure opaque white! Same as (1,1,1,1).
- `void Color(float red, float green, float blue, float opacity)` — Try Color.HSV instead! But if you really need to create a color from RGB values, I suppose you're in the right place. All parameter values are generally in the range of 0-1.
  - `red` — Red component, 0-1.
  - `green` — Green component, 0-1.
  - `blue` — Blue component, 0-1.
  - `opacity` — Opacity, or the alpha component, 0-1 where 0 is completely transparent, and 1 is completely opaque.
- `static Color Color.Hex(uint hexValue)` — Create a color from an integer based hex value! This can make it easier to copy over colors from the web. This isn't a string function though, so you'll need to fill it out the whole way. Ex: `Color.Hex(0x0000FFFF)` would be RGBA(0,0,1,1).
  - `hexValue` — An integer representing RGBA hex values! Like: `0x0000FFFF`.
  - returns — A 128 bit Color value.
  - Example: see `Color.Hex` in StereoKit-docs-reference.md
- `static Color Color.HSV(float hue, float saturation, float value, float opacity)` — Creates a Red/Green/Blue gamma space color from Hue/Saturation/Value information.
  - `hue` — Hue most directly relates to the color as we think of it! 0 is red, 0.1667 is yellow, 0.3333 is green, 0.5 is cyan, 0.6667 is blue, 0.8333 is magenta, and 1 is red again!
  - `saturation` — The vibrancy of the color, where 0 is straight up a shade of gray, and 1 is 'poke you in the eye colorful'.
  - `value` — The brightness of the color! 0 is always black.
  - `opacity` — Also known as alpha! This is does not affect the rgb components of the resulting color, it'll just get slotted into the colors opacity value.
  - returns — A gamma space RGB color!
- `static Color Color.HSV(Vec3 hsvColor, float opacity)` — Creates a Red/Green/Blue gamma space color from Hue/Saturation/Value information.
  - `hsvColor` — For convenience, XYZ is HSV. Hue most directly relates to the color as we think of it! 0 is red, 0.1667 is yellow, 0.3333 is green, 0.5 is cyan, 0.6667 is blue, 0.8333 is magenta, and 1 is red again! Saturation is the vibrancy of the color, where 0 is straight up a shade of gray, and 1 is 'poke you in the eye colorful'. Value is the brightness of the color! 0 is always black.
  - `opacity` — Also known as alpha! This is does not affect the rgb components of the resulting color, it'll just get slotted into the colors opacity value.
  - returns — A gamma space RGB color!
  - Example: see `Color.HSV` in StereoKit-docs-reference.md
- `static Color Color.LAB(float l, float a, float b, float opacity)` — Creates a gamma space RGB color from a CIE-L*ab color space. CIE-L*ab is a color space that models human perception, and has significantly more accurate to perception lightness values, so this is an excellent color space for color operations that wish to preserve color brightness properly. Traditionally, values are L [0,100], a,b [-200,+200] but here we normalize them all to the 0-1 range. If you hate it, let me know why!
  - `l` — Lightness of the color! Range is 0-1.
  - `a` — 'a' is from red to green. Range is 0-1.
  - `b` — 'b' is from blue to yellow. Range is 0-1.
  - `opacity` — The opacity copied into the final color!
  - returns — A gamma space RGBA color constructed from the LAB values.
- `static Color Color.LAB(Vec3 lab, float opacity)` — Creates a gamma space RGB color from a CIE-L*ab color space. CIE-L*ab is a color space that models human perception, and has significantly more accurate to perception lightness values, so this is an excellent color space for color operations that wish to preserve color brightness properly. Traditionally, values are L [0,100], a,b [-200,+200] but here we normalize them all to the 0-1 range. If you hate it, let me know why!
  - `lab` — For convenience, XYZ is LAB. Lightness of the color! Range is 0-1. 'a' is from red to green. Range is 0-1. 'b' is from blue to yellow. Range is 0-1.
  - `opacity` — The opacity copied into the final color!
  - returns — A gamma space RGBA color constructed from the LAB values.
  - Example: see `Color.LAB` in StereoKit-docs-reference.md
- `static Color Color.Lerp(Color a, Color b, float t)` — This will linearly blend between two different colors! Best done on linear colors, rather than gamma corrected colors, but will work either way. This will not clamp the percentage to the 0-1 range.
  - `a` — The first color, this will be the result if `t` is 0.
  - `b` — The second color, this will be the result if `t` is 1.
  - `t` — A percentage representing the blend between `a` and `b`. This is _not_ clamped to the 0-1 range, and will result in extrapolation outside this range.
  - returns — A blended color.
- `static Color Color.+(Color a, Color b)` — This will add a color component-wise with another color, including alpha. Best done on colors in linear space. No clamping is applied.
  - `a` — The first color.
  - `b` — The second color.
  - returns — An added color.
- `static Color Color./(Color a, float b)` — This will divide a color linearly, including alpha. Best done on a color in linear space. No clamping is applied.
  - `a` — The source color.
  - `b` — The float to divide by.
  - returns — A divided color.
- `static Color Color./(Color a, Color b)` — This will divide a color component-wise against another color, including alpha. Best done on colors in linear space. No clamping is applied.
  - `a` — The first color.
  - `b` — The second color.
  - returns — A divided color.
- `static Color32 Color.Implicit Conversions(Color c)` — This allows for implicit conversion to Color32. This does _not_ convert from linear to gamma corrected, or clamp to 0-1 first.
  - `c` — A 128 bit color to crush down.
  - returns — A crushed down color.
- `static Color Color.*(Color a, float b)` — This will multiply a color linearly, including alpha. Best done on a color in linear space. No clamping is applied.
  - `a` — The source color.
  - `b` — The float to multiply by.
  - returns — A multiplied color.
- `static Color Color.*(Color a, Color b)` — This will multiply a color component-wise against another color, including alpha. Best done on colors in linear space. No clamping is applied.
  - `a` — The first color.
  - `b` — The second color.
  - returns — A multiplied color.
- `static Color Color.-(Color a, Color b)` — This will subtract color `b` component-wise from color `a`, including alpha. Best done on colors in linear space. No clamping is applied.
  - `a` — The first color.
  - `b` — The second color.
  - returns — A color where b has been subtracted from a.
- `Color Color.ToGamma()` — Converts this from a linear space color, into a gamma space color! If this is not a linear space color, this will just make your color wacky!
  - returns — A gamma space color.
- `Vec3 Color.ToHSV()` — Converts the gamma space color to a Hue/Saturation/Value format! Does not consider transparency when calculating the result.
  - returns — Hue, Saturation, and Value, stored in x, y, and z respectively. All values are between 0-1.
  - Example: see `Color.ToHSV` in StereoKit-docs-reference.md
- `Vec3 Color.ToLAB()` — Converts the gamma space RGB color to a CIE LAB color space value! Conversion back and forth from LAB space could be somewhat lossy.
  - returns — An LAB vector where x=L, y=A, z=B.
  - Example: see `Color.ToLAB` in StereoKit-docs-reference.md
- `Color Color.ToLinear()` — Converts this from a gamma space color, into a linear space color! If this is not a gamma space color, this will just make your color wacky!
  - returns — A linear space color.
- `string Color.ToString()` — Mostly for debug purposes, this is a decent way to log or inspect the color in debug mode. Looks like "[r, g, b, a]"
  - returns — A string that looks like "[r, g, b, a]"

## struct Color32

A 32 bit color struct! This is often directly used by StereoKit data structures, and so is often necessary for setting texture data, or mesh data. Note that the Color type implicitly converts to Color32, so you can use the static methods there to create Color32 values! It's generally best to avoid doing math on 32-bit color values, as they lack the precision necessary to create results. It's best to think of a Color32 as an optimized end stage format of a color.

- `Byte Color32.a` — Color components in the range of 0-255.
- `Byte Color32.b` — Color components in the range of 0-255.
- `Byte Color32.g` — Color components in the range of 0-255.
- `Byte Color32.r` — Color components in the range of 0-255.
- `static Color32 Color32.Black` — Pure opaque black! Same as (0,0,0,255).
- `static Color32 Color32.BlackTransparent` — Pure transparent black! Same as (0,0,0,0).
- `static Color32 Color32.White` — Pure opaque white! Same as (255,255,255,255).
- `void Color32(Byte r, Byte g, Byte b, Byte a)` — Constructs a 32-bit color from bytes! You may also be interested in `Color32.Hex`.
  - `r` — Red channel.
  - `g` — Green channel.
  - `b` — Blue channel.
  - `a` — Alpha channel.
- `static Color32 Color32.Hex(uint hexValue)` — Create a color from an integer based hex value! This can make it easier to copy over colors from the web. This isn't a string function though, so you'll need to fill it out the whole way. Ex: `Color.Hex(0x0000FFFF)` would be RGBA(0,0,255,255).
  - `hexValue` — An integer representing RGBA hex values! Like: `0x0000FFFF`.
  - returns — A 32 bit Color32 value.
  - Example: see `Color32.Hex` in StereoKit-docs-reference.md
- `string Color32.ToString()` — Mostly for debug purposes, this is a decent way to log or inspect the color in debug mode. Looks like "[r, g, b, a]"
  - returns — A string that looks like "[r, g, b, a]"

## class Compute

Compute shaders allow you to run code on the GPU in a massively parallel way! This is great for accelerating complex work, or simply for working inline with the graphics pipeline with easy access to GPU memory. This behaves very much like Materials do! You can set parameters, and attach buffers or textures! Unlike Materials, you need to dispatch the compute shader to make it run. You may need to be a bit cautious about compute data, since the GPU can be picky about what and when it reads and writes to!

- `string Compute.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `int Compute.ParamCount` — The number of shader parameters available on this Compute! This includes both variables and textures/buffers, great for building a GUI that can inspect any shader.
- `Shader Compute.Shader` — The shader associated with this compute object. Each access here creates a new reference!
- `void Compute(Shader computeShader)` — Create a Compute dispatch from a shader that has a compute stage! If the shader doesn't have a compute stage, this will fail.
  - `computeShader` — A shader containing a compute stage.
- `void Compute(string shaderFilename)` — Create a Compute dispatch from a shader file! The file should be a compiled .sks shader with a compute stage.
  - `shaderFilename` — The filename of a compiled shader asset containing a compute stage.
- `void Compute.Dispatch(uint groupCountX, uint groupCountY, uint groupCountZ)` — Queue this compute dispatch into the render pipeline. It will run during the next frame's render setup phase, in source order with other queued render actions (Renderer.RenderTo, Renderer.SetGlobal*). This is the recommended path for compute work that participates in the frame's rendering pipeline (e.g. populating a texture that a later RenderTo or the main pass will sample), since sk_renderer can manage the necessary GPU barriers between queued items. IMPORTANT: bindings (textures, buffers, constants, scalar parameters) are NOT snapshotted when Dispatch is called — they are read at execute time, which happens later in the frame. If you change a binding between two queued Dispatch calls on the same Compute, both dispatches will see the final binding state, not the state at their respective Dispatch times. To dispatch the same Compute with different bindings, either issue each Dispatch with DispatchNow, or use a separate Compute instance per binding set. The parameters are the number of thread _groups_, not individual threads. Total thread count = groupCount * numthreads (as defined in your HLSL). So if your shader says [numthreads(8,8,1)] and you dispatch (64,64,1), you'll get 512*512 threads.
  - `groupCountX` — Thread groups in X.
  - `groupCountY` — Thread groups in Y.
  - `groupCountZ` — Thread groups in Z.
- `void Compute.DispatchNow(uint groupCountX, uint groupCountY, uint groupCountZ)` — Run this compute dispatch synchronously, right now, on the calling thread. Use this for ad-hoc work that doesn't belong in the per-frame render pipeline (debugging, one-shot tasks, immediate readbacks). For compute work that feeds into later render passes within the same frame, prefer Dispatch, which queues into the pipeline and lets sk_renderer handle ordering and barriers automatically.
  - `groupCountX` — Thread groups in X.
  - `groupCountY` — Thread groups in Y.
  - `groupCountZ` — Thread groups in Z.
- `static Compute Compute.Find(string computeId)` — Looks for a Compute object that has already been created with a matching id!
  - `computeId` — The id to search for.
  - returns — A Compute with a matching id, or null if none exists.
- `IEnumerable`1 Compute.GetAllParamInfo()` — Gets an enumerable list of all parameter info on this Compute! Handy for building auto-generated shader GUIs or inspectors.
  - returns — An IEnumerable of MatParamInfo, usable with foreach.
- `bool Compute.GetBool(string name)` — Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.
- `Color Compute.GetColor(string name)` — Gets a color parameter by name! Note that SetColor converts gamma to linear, so this returns the _linear_ value the shader is actually using.
- `float Compute.GetFloat(string name)` — Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.
- `int Compute.GetInt(string name)` — Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.
- `Matrix Compute.GetMatrix(string name)` — Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.
- `MatParamInfo Compute.GetParamInfo(int index)` — Gets parameter info at a specific index! Parameters are listed as variables first, then textures and buffers.
  - `index` — Index of the parameter, bounded by ParamCount.
  - returns — Name and type info for this parameter.
- `uint Compute.GetUInt(string name)` — Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.
- `Vec2 Compute.GetVector2(string name)` — Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.
- `Vec3 Compute.GetVector3(string name)` — Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.
- `Vec4 Compute.GetVector4(string name)` — Gets the value of a shader parameter by name! If the name isn't found, you'll get a default value back.
- `void Compute.SetBool(string name, bool value)` — Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!
- `void Compute.SetColor(string name, Color colorGamma)` — Set a color parameter by name! Color is converted from gamma to linear space, so what the shader receives will be in linear. If you're working in linear already, use SetVector with a Vec4 instead!
- `void Compute.SetColor(string name, Color32 colorGamma)` — Set a color parameter by name! Color is converted from gamma to linear space, so what the shader receives will be in linear. If you're working in linear already, use SetVector with a Vec4 instead!
- `bool Compute.SetConstant(string name, MaterialBuffer`1 buffer)` — Sets a constant/uniform buffer (cbuffer) on the shader. This is for smaller chunks of data (16kb max) that can be read from faster than textures or StructuredBuffers.
  - `name` — Name of the shader parameter in the HLSL.
  - `buffer` — The buffer to assign, or null to clear.
  - returns — True if a matching resource was found in the shader.
- `void Compute.SetFloat(string name, float value)` — Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!
- `void Compute.SetInt(string name, int value)` — Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!
- `void Compute.SetMatrix(string name, Matrix value)` — Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!
- `bool Compute.SetStorage(string name, ComputeBuffer`1 buffer)` — Sets a RW/StructuredBuffer or ByteAddressBuffer on the shader. This is used to provide BIG arrays of data to the GPU, for both reading and writing! These perform very similarly to textures, and can be thought of as big textures of just data!
  - `name` — Name of the shader parameter in the HLSL.
  - `buffer` — The buffer to assign, or null to clear.
  - returns — True if a matching resource was found in the shader.
- `bool Compute.SetTexture(string name, Tex texture)` — Bind a texture to a named resource in the shader! If you're writing to it (RWTexture2D), the texture _must_ have TexType.Compute set, and use a format like TexFormat.Rgba128. Read-only Texture2D bindings work with any texture. Fallbacks are resolved at Dispatch time, so textures that are still loading will Just Work.
  - `name` — The texture name in the HLSL shader. Must match exactly!
  - `texture` — The texture to bind.
  - returns — True if a matching resource was found in the shader, false if the name didn't match anything.
- `void Compute.SetUInt(string name, uint value)` — Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!
- `void Compute.SetVector(string name, Vec2 value)` — Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!
- `void Compute.SetVector(string name, Vec3 value)` — Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!
- `void Compute.SetVector(string name, Vec4 value)` — Set a shader parameter by name! The name must match a variable in the HLSL compute shader exactly, and if no match is found, nothing happens. Same as Material!

## class ComputeBuffer

A GPU storage buffer for shuttling data to and from compute shaders! In HLSL, this maps to StructuredBuffer<T> or RWStructuredBuffer<T> depending on the ComputeBufferType. Your struct T needs to be unmanaged (no reference types!) and its layout _must_ match the HLSL struct. Watch out for padding differences between C# and HLSL!

- `int ComputeBuffer.Count` — The capacity of the buffer, in number of T elements. This is the max you can Set or Get without clamping.
- `string ComputeBuffer.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `int ComputeBuffer.Stride` — Size of a single element in bytes, derived from your T struct. Handy for sanity-checking that your C# struct matches the HLSL side!
- `void ComputeBuffer(ComputeBufferType type, int elementCount)` — Creates a GPU storage buffer with room for elementCount elements, initially uninitialized! The contents will be whatever was in GPU memory before, so make sure to write before you read.
  - `type` — Read or ReadWrite access from compute shaders.
  - `elementCount` — Number of T elements to allocate.
- `void ComputeBuffer(ComputeBufferType type, T[] initialData)` — Creates a GPU storage buffer and immediately uploads initialData to it! The buffer capacity is set to the array length.
  - `type` — Read or ReadWrite access from compute shaders.
  - `initialData` — Array of data to upload to the GPU.
- `T[] ComputeBuffer.GetData()` — Read the full buffer back from the GPU! This blocks until the data is ready, and allocates a new array each call. For per-frame readbacks, prefer the GetData(ref T[]) overload to avoid GC pressure!
  - returns — A new array containing the full buffer contents.
- `void ComputeBuffer.GetData(T[]& data)` — Read GPU data into a pre-allocated array! This is the allocation-free version of GetData, great for calling every frame without creating GC garbage. Reads Math.Min(data.Length, Count) elements.
  - `data` — A pre-allocated array to fill. If it's smaller than the buffer, only data.Length elements are read.
- `void ComputeBuffer.SetData(T[] data)` — Upload data from the CPU to the GPU! If data.Length exceeds the buffer's capacity, it will be clamped with a warning.
  - `data` — The data to upload.

## enum ComputeBufferType

Describes the access mode of a ComputeBuffer for use in compute shaders.

- `ComputeBufferType.Read` — Read-only from compute shaders. Maps to StructuredBuffer<T> in HLSL.
- `ComputeBufferType.ReadWrite` — Read-write from compute shaders. Maps to RWStructuredBuffer<T> in HLSL.

## class Controller

This represents a physical controller input device! Tracking information, buttons, analog sticks and triggers! There's also a Menu button that's tracked separately at Input.ContollerMenu.

- `Pose Controller.aim` — The aim pose of a controller is where the controller 'points' from and to. This is great for pointer rays and far interactions.
- `float Controller.grip` — The grip button typically sits under the user's middle finger. These buttons occasionally have a wide range of activation, so this is provided as a value from 0.0 -> 1.0, where 0 is no interaction, and 1 is full interaction. If a controller has binary activation, this will jump straight from 0 to 1.
- `bool Controller.IsJustTracked` — Has the controller just started being tracked this frame?
- `bool Controller.IsJustUntracked` — Has the controller just stopped being tracked this frame?
- `bool Controller.IsStickClicked` — Is the analog stick/directional controller button currently being actively pressed?
- `bool Controller.IsStickJustClicked` — Has the analog stick/directional controller button just been pressed this frame?
- `bool Controller.IsStickJustUnclicked` — Has the analog stick/directional controller button just been released this frame?
- `bool Controller.IsTracked` — Is the controller being tracked by the sensors right now?
- `bool Controller.IsX1JustPressed` — Has the controller's X1 button just been pressed this frame? Depending on the specific hardware, this is the first general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'X' on the left controller, and 'A' on the right controller.
- `bool Controller.IsX1JustUnPressed` — Has the controller's X1 button just been released this frame? Depending on the specific hardware, this is the first general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'X' on the left controller, and 'A' on the right controller.
- `bool Controller.IsX1Pressed` — Is the controller's X1 button currently pressed? Depending on the specific hardware, this is the first general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'X' on the left controller, and 'A' on the right controller.
- `bool Controller.IsX2JustPressed` — Has the controller's X2 button just been pressed this frame? Depending on the specific hardware, this is the second general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'Y' on the left controller, and 'B' on the right controller.
- `bool Controller.IsX2JustUnPressed` — Has the controller's X2 button just been released this frame? Depending on the specific hardware, this is the second general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'Y' on the left controller, and 'B' on the right controller.
- `bool Controller.IsX2Pressed` — Is the controller's X2 button currently pressed? Depending on the specific hardware, this is the second general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'Y' on the left controller, and 'B' on the right controller.
- `Pose Controller.palm` — This is the pose of the hand's palm on the controller. You can use it for rendering items where the hands are when holding a controller. This pose's Forward is towards the fingers, and Up is toward the thumbs. On the right hand, X+ goes into the palm, and on the left hand, X+ goes out of the palm. This is used by StereoKit for placing the hand mesh!
- `Pose Controller.pose` — The grip pose of the controller. This approximately represents the center of the controller where it's gripped by the user's hand. Check `trackedPos` and `trackedRot` for the current state of the pose data.
- `Vec2 Controller.stick` — This is the current 2-axis position of the analog stick or equivalent directional controller. This generally ranges from -1 to +1 on each axis. This is a raw input, so dead-zones and similar issues are not accounted for here, unless modified by the OpenXR platform itself.
- `BtnState Controller.stickClick` — This represents the click state of the controller's analog stick or directional controller.
- `BtnState Controller.tracked` — This tells the current tracking state of this controller overall. If either position or rotation are trackable, then this will report tracked. Typically, positional tracking will be lost first, when the controller goes out of view, and rotational tracking will often remain as long as the controller is still connected. This is a good way to check if the controller is connected to the system at all.
- `TrackState Controller.trackedPos` — This tells the current tracking state of the controller's position information. This is often the first part of tracking data to go, so it can often be good to account for this on occasions.
- `TrackState Controller.trackedRot` — This tells the current tracking state of the controller's rotational information.
- `float Controller.trigger` — The trigger button at the user's index finger. These buttons typically have a wide range of activation, so this is provided as a value from 0.0 -> 1.0, where 0 is no interaction, and 1 is full interaction. If a controller has binary activation, this will jump straight from 0 to 1.
- `BtnState Controller.x1` — The current state of the controller's X1 button. Depending on the specific hardware, this is the first general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'X' on the left controller, and 'A' on the right controller.
- `BtnState Controller.x2` — The current state of the controller's X2 button. Depending on the specific hardware, this is the second general purpose button on the controller. For example, on an Oculus Quest Touch controller this would represent 'Y' on the left controller, and 'B' on the right controller.

## enum ControllerKey

Represents an input from an XR headset's controller!

- `ControllerKey.Grip` — The grip button on the controller, usually where the fingers that are not the index finger sit.
- `ControllerKey.Menu` — This is the menu, or settings button of the controller.
- `ControllerKey.None` — Doesn't represent a key, generally means this item has not been set to any particular value!
- `ControllerKey.Stick` — This is when the thumbstick on the controller is actually pressed. This has nothing to do with the horizontal or vertical movement of the stick.
- `ControllerKey.Trigger` — The trigger button on the controller, where the user's index finger typically sits.
- `ControllerKey.X1` — This is the lower of the two primary thumb buttons, sometimes labelled X, and sometimes A.
- `ControllerKey.X2` — This is the upper of the two primary thumb buttons, sometimes labelled Y, and sometimes B.

## enum Cull

Culling is discarding an object from the render pipeline! This enum describes how mesh faces get discarded on the graphics card. With culling set to none, you can double the number of pixels the GPU ends up drawing, which can have a big impact on performance. None can be appropriate in cases where the mesh is designed to be 'double sided'. Front can also be helpful when you want to flip a mesh 'inside-out'!

- `Cull.Back` — Discard if the back of the triangle face is pointing towards the camera. This is the default behavior.
- `Cull.Front` — Discard if the front of the triangle face is pointing towards the camera. This is opposite the default behavior.
- `Cull.None` — No culling at all! Draw the triangle regardless of which way it's pointing.

## static class Default

This is a collection of StereoKit default assets that are created or loaded by StereoKit during its initialization phase! Feel free to use them or Copy them, but be wary about modifying them, since it could affect many things throughout the system.

- `static Tex Default.Cubemap` — The default cubemap that StereoKit generates, this is the cubemap that's visible as the background and initial scene lighting.
- `static Font Default.Font` — The default font used by StereoKit's text. This varies from platform to platform, but is typically a sans-serif general purpose font, such as Segoe UI.
- `static Material Default.Material` — The default material! This is used by many models and meshes rendered from within StereoKit. Its shader is tuned for high performance, and may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default material, here's where you do it!
- `static Material Default.MaterialEquirect` — This material is used for projecting equirectangular textures into cubemap faces. It's probably not a great idea to change this one much!
- `static Material Default.MaterialFont` — This material is used as the default for rendering text! By default, it uses the 'default/shader_font' shader, which is a two-sided alpha-clip shader. This also turns off backface culling.
- `static Material Default.MaterialHand` — This is the default material for rendering the hand! It's a copy of the default material, but set to transparent, and using a generated texture.
- `static Material Default.MaterialPBR` — The default Physically Based Rendering material! This is used by StereoKit anytime a mesh or model has metallic or roughness properties, or needs to look more realistic. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default PBR behavior, here's where you do it! Note that the shader used by default here is much more costly than Default.Material.
- `static Material Default.MaterialPBRClip` — Same as MaterialPBR, but it uses a discard clip for transparency.
- `static Material Default.MaterialUI` — The material used by the UI! By default, it uses a shader that creates a 'finger shadow' that shows how close the finger is to the UI.
- `static Material Default.MaterialUIBox` — A material for indicating interaction volumes! It renders a border around the edges of the UV coordinates that will 'grow' on proximity to the user's finger. It will discard pixels outside of that border, but will also show the finger shadow. This is meant to be an opaque material, so it works well for depth LSR. This material works best on cube-like meshes where each face has UV coordinates from 0-1. Shader Parameters: ``` color                - color border_size          - meters border_size_grow     - meters border_affect_radius - meters ```
- `static Material Default.MaterialUIQuadrant` — The material used by the UI for Quadrant Sized UI elements. See UI.QuadrantSizeMesh for additional details. By default, it uses a shader that creates a 'finger shadow' that shows how close the finger is to the UI.
- `static Material Default.MaterialUnlit` — The default unlit material! This is used by StereoKit any time a mesh or model needs to be rendered with an unlit surface. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default unlit behavior, here's where you do it!
- `static Material Default.MaterialUnlitClip` — The default unlit material with alpha clipping! This is used by StereoKit for unlit content with transparency, where completely transparent pixels are discarded. This means less alpha blending, and fewer visible alpha blending issues! In particular, this is how Sprites are drawn. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default unlit clipped behavior, here's where you do it!
- `static Mesh Default.MeshCube` — A cube with dimensions of (1,1,1), this is equivalent to Mesh.GenerateCube(Vec3.One).
- `static Mesh Default.MeshQuad` — A default quad mesh, 2 triangles, 4 verts, from (-0.5,-0.5,0) to (0.5,0.5,0) and facing forward on the Z axis (0,0,-1). White vertex colors, and UVs from (1,1) at vertex (-0.5,-0.5,0) to (0,0) at vertex (0.5,0.5,0).
- `static Mesh Default.MeshScreenQuad` — A default quad mesh designed for full-screen rendering. 2 triangles, 4 verts, from (-1,-1,0) to (1,1,0) and facing backwards on the Z axis (0,0,1). White vertex colors, and UVs from (0,0) at vertex (-1,-1,0) to (1,1) at vertex (1,1,0).
- `static Mesh Default.MeshSphere` — A sphere mesh with a diameter of 1. This is equivalent to Mesh.GenerateSphere(1,4).
- `static RenderList Default.RenderList` — The default RenderList used by the Renderer for the primary display surface.
- `static Shader Default.Shader` — This is a fast, general purpose shader. It uses a texture for 'diffuse', a 'color' property for tinting the material, and a 'tex_scale' for scaling the UV coordinates. For lighting, it just uses a lookup from the current cubemap.
- `static Shader Default.ShaderEquirect` — A shader for projecting equirectangular textures onto cube faces! This is for equirectangular texture loading.
- `static Shader Default.ShaderFont` — A shader for text! Right now, this will render a font atlas texture, and perform alpha-testing for transparency, and super-sampling for better readability. It also flips normals of the back-face of the surface, so  backfaces get lit properly when backface culling is turned off, as it is by default for text.
- `static Shader Default.ShaderPbr` — A physically based shader.
- `static Shader Default.ShaderPbrClip` — Same as ShaderPBR, but with a discard clip for transparency.
- `static Shader Default.ShaderUI` — A shader for UI or interactable elements, this'll be the same as the Shader, but with an additional finger 'shadow' and distance circle effect that helps indicate finger distance from the surface of the object.
- `static Shader Default.ShaderUIBox` — A shader for indicating interaction volumes! It renders a border around the edges of the UV coordinates that will 'grow' on proximity to the user's finger. It will discard pixels outside of that border, but will also show the finger shadow. This is meant to be an opaque shader, so it works well for depth LSR. This shader works best on cube-like meshes where each face has UV coordinates from 0-1. Shader Parameters: ``` color                - color border_size          - meters border_size_grow     - meters border_affect_radius - meters ```
- `static Shader Default.ShaderUnlit` — Sometimes lighting just gets in the way! This is an extremely simple and fast shader that uses a 'diffuse' texture and a 'color' tint property to draw a model without any lighting at all!
- `static Shader Default.ShaderUnlitClip` — Sometimes lighting just gets in the way! This is an extremely simple and fast shader that uses a 'diffuse' texture and a 'color' tint property to draw a model without any lighting at all! This shader will also discard pixels with an alpha of zero.
- `static Sound Default.SoundClick` — A default click sound that lasts for 300ms. It's a procedurally generated sound based on a mouse press, with extra low frequencies in it.
- `static Sound Default.SoundUnclick` — A default click sound that lasts for 300ms. It's a procedurally generated sound based on a mouse release, with extra low frequencies in it.
- `static Sprite Default.SpriteArrowDown` — This is a 64x64 image of a slightly rounded triangle pointing down.
- `static Sprite Default.SpriteArrowLeft` — This is a 64x64 image of a slightly rounded triangle pointing left.
- `static Sprite Default.SpriteArrowRight` — This is a 64x64 image of a slightly rounded triangle pointing right.
- `static Sprite Default.SpriteArrowUp` — This is a 64x64 image of a slightly rounded triangle pointing up.
- `static Sprite Default.SpriteBackspace` — This is a 64x64 image of a backspace action button, similar to a backspace button you might find on a mobile keyboard.
- `static Sprite Default.SpriteClose` — This is a 64x64 image of a square aspect X, with rounded edge. It's used to indicate a 'close' icon.
- `static Sprite Default.SpriteGrid` — A 3x3 grid of squares, indicating a grid of items.
- `static Sprite Default.SpriteList` — 3 horizontal bars, indicating either a 'hamburger' menu, or a list of items.
- `static Sprite Default.SpriteRadioOff` — This is a 64x64 image of an empty hole. This is common iconography for radio buttons which use an empty hole to indicate an un-selected radio, and a filled hole for a selected radio. This is used by the UI for radio buttons!
- `static Sprite Default.SpriteRadioOn` — This is a 64x64 image of a filled hole. This is common iconography for radio buttons which use an empty hole to indicate an un-selected radio, and a filled hole for a selected radio. This is used by the UI for radio buttons!
- `static Sprite Default.SpriteShift` — This is a 64x64 image of an upward facing rounded arrow. This is a triangular top with a narrow rectangular base, and is used to indicate a 'shift' icon on a keyboard.
- `static Sprite Default.SpriteToggleOff` — This is a 64x64 image of an empty rounded square. This is common iconography for checkboxes which use an empty square to indicate an un-selected checkbox, and a filled square for a selected checkbox. This is used by the UI for toggle buttons!
- `static Sprite Default.SpriteToggleOn` — This is a 64x64 image of a filled rounded square. This is common iconography for checkboxes which use an empty square to indicate an un-selected checkbox, and a filled square for a selected checkbox. This is used by the UI for toggle buttons!
- `static Tex Default.Tex` — Default 2x2 white opaque texture, this is the texture referred to as 'white' in the shader texture defaults.
- `static Tex Default.TexBlack` — Default 2x2 black opaque texture, this is the texture referred to as 'black' in the shader texture defaults.
- `static Tex Default.TexDevTex` — This is a white checkered grid texture used to easily add visual features to materials. By default, this is used for the loading fallback texture for all Tex objects.
- `static Tex Default.TexError` — This is a red checkered grid texture used to indicate some sort of error has occurred. By default, this is used for the error fallback texture for all Tex objects.
- `static Tex Default.TexFlat` — Default 2x2 flat normal texture, this is a normal that faces out from the, face, and has a color value of (0.5,0.5,1). This is the texture referred to as 'flat' in the shader texture defaults.
- `static Tex Default.TexGray` — Default 2x2 middle gray (0.5,0.5,0.5) opaque texture, this is the texture referred to as 'gray' in the shader texture defaults.
- `static Tex Default.TexRough` — Default 2x2 roughness color (1,1,0,1) texture, this is the texture referred to as 'rough' in the shader texture defaults.

## enum DefaultInteractors

Options for what type of interactors StereoKit provides by default.

- `DefaultInteractors.All` — Auto-switch between hands and controllers based on the current input source. This provides aim, pinch, and poke interactors for hands, and aim rays for controllers.
- `DefaultInteractors.Controllers` — Always use the default controller interactors.
- `DefaultInteractors.Default` — Use the XR backend's default interactor mode. This is 'all' for XR, 'mouse' for simulator and window, and 'none' for offscreen.
- `DefaultInteractors.Hands` — Always use the default hand interactors, using simulated hands when articulated hand tracking is not available.
- `DefaultInteractors.Mouse` — Always use the default mouse interactor.
- `DefaultInteractors.None` — Don't provide any interactors at all. This means you either don't want interaction, or are providing your own custom interactors.

## enum DepthMode

This is used to determine what kind of depth buffer StereoKit uses!

- `DepthMode.D16` — 16 bit depth buffer, this is fast and recommended for devices like the HoloLens. This is especially important for fast depth based reprojection. Far view distances will suffer here though, so keep your clipping far plane as close as possible.
- `DepthMode.D32` — 32 bit depth buffer, should look great at any distance! If you must have the best, then this is the best. If you're interested in this one, Stencil may also be plenty for you, as 24 bit depth is also pretty peachy.
- `DepthMode.Default` — Default mode, uses the OpenXR runtime's preferred depth format. This is typically 16 bit on standalone/battery powered devices like Quest and HoloLens, and 32 bit on higher powered platforms like PC. If you need a far view distance even on mobile devices, prefer D32 or Stencil instead.
- `DepthMode.Stencil` — 24 bit depth buffer with 8 bits of stencil data. 24 bits is generally plenty for a depth buffer, so using the rest for stencil can open up some nice options! StereoKit has limited stencil support right now though (v0.3).

## enum DepthTest

Depth test describes how this material looks at and responds to depth information in the zbuffer! The default is Less, which means if the material pixel's depth is Less than the existing depth data, (basically, is this in front of some other object) it will draw that pixel. Similarly, Greater would only draw the material if it's 'behind' the depth buffer. Always would just draw all the time, and not read from the depth buffer at all.

- `DepthTest.Always` — Don't look at the zbuffer at all, just draw everything, always, all the time! At this point, the order at which the mesh gets drawn will be super important, so don't forget about `Material.QueueOffset`!
- `DepthTest.Equal` — Only draw pixels if they're at exactly the same depth as the zbuffer!
- `DepthTest.Greater` — Pixels in front of the zbuffer will be discarded! This is opposite of how things normally work. Great for drawing indicators that something is occluded by a wall or other geometry.
- `DepthTest.GreaterOrEq` — Pixels in front of (or exactly at) the zbuffer will be discarded! This is opposite of how things normally work. Great for drawing indicators that something is occluded by a wall or other geometry.
- `DepthTest.Less` — Default behavior, pixels behind the depth buffer will be discarded, and pixels in front of it will be drawn.
- `DepthTest.LessOrEq` — Pixels behind the depth buffer will be discarded, and pixels in front of, or at the depth buffer's value it will be drawn. This could be great for things that might be sitting exactly on a floor or wall.
- `DepthTest.Never` — Never draw a pixel, regardless of what's in the zbuffer. I can think of better ways to do this, but uhh, this is here for completeness! Maybe you can find a use for it.
- `DepthTest.NotEqual` — Draw any pixel that's not exactly at the value in the zbuffer.

## static class Device

This class describes the device that is running this application! It contains identifiers, capabilities, and a few adjustable settings here and there.

- `static DisplayBlend Device.DisplayBlend` — Allows you to set and get the current blend mode of the device! Setting this may not succeed if the blend mode is not valid.
- `static float Device.DisplayRefreshRate` — The refresh rate of the display in Hz, derived from OpenXR's predictedDisplayPeriod. Returns 0 if not available.
- `static DisplayType Device.DisplayType` — What type of display is this? Most XR headsets will report stereo, but the Simulator will report flatscreen.
- `static string Device.GPU` — The reported name of the GPU, this will differ between D3D and GL.
- `static bool Device.HasEyeGaze` — Does the device we're on have eye tracking support present for input purposes? This is _not_ an indicator that the user has given the application permission to access this information. See `Input.Gaze` for how to use this data.
- `static bool Device.HasHandTracking` — Tells if the device is capable of tracking hands. This does not tell if the user is actually using their hands for input, merely that it's possible to!
- `static string Device.Name` — This is the name of the active device! From OpenXR, this is the same as systemName from XrSystemProperties. The simulator will say "Simulator".
- `static string Device.Runtime` — This is the name of the OpenXR runtime that powers the current device! This can help you determine which implementation quirks to expect based on the codebase used. On the simulator, this will be "Simulator", and in other non-XR modes this will be "None".
- `static UInt64 Device.RuntimeVersion` — This is the multi-part version of the active OpenXR runtime packed into a 64-bit integer. The major version number is a 16-bit integer packed into bits 63-48. The minor version number is a 16-bit integer packed into bits 47-32. The patch version number is a 32-bit integer packed into bits 31-0. On the simulator and other non-XR modes, this will be 0.
- `static DeviceTracking Device.Tracking` — The tracking capabilities of this device! Is it 3DoF, rotation only? Or is it 6DoF, with positional tracking as well? Maybe it can't track at all!
- `static bool Device.ValidBlend(DisplayBlend blend)` — Tells if a particular blend mode is valid on this device. Some devices may be capable of more than one blend mode.
  - `blend` — The blend mode to check agains! AnyTransparent will check against additive and blend.
  - returns — True if valid, false if not.

## enum DeviceTracking

What type of user motion is the device capable of tracking? For the normal fully capable XR headset, this should be 6dof (rotation and translation), but more limited headsets may be restricted to 3dof (rotation) and flatscreen computers with the simulator off would be none.

- `DeviceTracking.DoF3` — This tracks rotation only, this may be a limited device without tracking cameras, or could be a more capable headset in a 3dof mode. DoF stands for Degrees of Freedom.
- `DeviceTracking.DoF6` — This is capable of tracking both the position and rotation of the device, most fully featured XR headsets (such as a HoloLens 2) will have this. DoF stands for Degrees of Freedom.
- `DeviceTracking.None` — No tracking is available! This is likely a flatscreen application, not an XR applicaion.

## enum DisplayBlend

This describes the way the display's content blends with whatever is behind it. VR headsets are normally Opaque, but some VR headsets provide passthrough video, and can support Opaque as well as Blend, like the Varjo. Transparent AR displays like the HoloLens would be Additive.

- `DisplayBlend.Additive` — This display is transparent, and adds light on top of the real world. This is equivalent to a HoloLens type of device.
- `DisplayBlend.AnyTransparent` — This matches either transparent display type! Additive or Blend. For use when you just want to see the world behind your application.
- `DisplayBlend.Blend` — This is a physically opaque display, but with a camera passthrough displaying the world behind it anyhow. This would be like a Varjo XR-1, or phone-camera based AR.
- `DisplayBlend.None` — Default value, when using this as a search type, it will fall back to default behavior which defers to platform preference.
- `DisplayBlend.Opaque` — This display is opaque, with no view into the real world! This is equivalent to a VR headset, or a PC screen.

## enum DisplayMode

Specifies a type of display mode StereoKit uses, like Mixed Reality headset display vs. a PC display, or even just rendering to an offscreen surface, or not rendering at all!

- `DisplayMode.Flatscreen` — Creates a flat, Win32 window, and simulates some MR functionality. Great for debugging.
- `DisplayMode.MixedReality` — Creates an OpenXR instance, and drives display/input through that.
- `DisplayMode.None` — Not tested yet, but this is meant to run StereoKit without rendering to any display at all. This would allow for rendering to textures, running a server that can do MR related tasks, etc.

## enum DisplayType

This describes a type of display hardware!

- `DisplayType.Flatscreen` — This is a single flat screen, with no stereo depth. This could be something like either a computer monitor, or a phone with passthrough AR.
- `DisplayType.None` — Not a display at all, or the variable hasn't been initialized properly yet.
- `DisplayType.Stereo` — This is a stereo display! It has 2 screens, or two sections that display content in stereo, one for each eye. This could be a VR headset, or like a 3D tv.

## enum FingerId

Index values for each finger! From 0-4, from thumb to little finger.

- `FingerId.Index` — The primary index/pointer finger! Finger 1.
- `FingerId.Little` — Finger 4, the smallest little finger! AKA, The Pinky.
- `FingerId.Middle` — Finger 2, next to the index finger.
- `FingerId.Ring` — Finger 3! What does one do with this finger? I guess... wear rings on it?
- `FingerId.Thumb` — Finger 0.

## class Font

This class represents a text font asset! On the back-end, this asset is composed of a texture with font characters rendered to it, and a list of data about where, and how large those characters are on the texture. This asset is used anywhere that text shows up, like in the UI or Text classes!

- `string Font.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `static Font Font.Default` — The default font used by StereoKit's text. This varies from platform to platform, but is typically a sans-serif general purpose font, such as Segoe UI.
- `static Font Font.Find(string fontId)` — Searches the asset list for a font with the given Id, returning null if none is found.
  - `fontId` — Id of the font you're looking for.
  - returns — An existing font asset, or null if none is found.
- `static Font Font.FromFamily(string fontFamily)` — Loads font from a specified list of font family names
  - `fontFamily` — List of font family names separated by comma(,) similar to a list of names css allows.
  - returns — A font from the given font family names. If none of them match a usable font, this falls back to StereoKit's builtin font, so this will always be a valid asset.
- `static Font Font.FromFile(String[] fontFiles)` — Loads a font and creates a font asset from it.
  - `fontFiles` — A list of file addresses for the font! For example: 'C:/Windows/Fonts/segoeui.ttf'. If a glyph is not found, StereoKit will look in the next font file in the list.
  - returns — A font from the given files, or null if all of the files failed to load properly! If any of the given files successfully loads, then this font will be a valid asset.
  - Example: see `Font.FromFile` in StereoKit-docs-reference.md

## struct FovInfo

This describes the field of view of a display, in degrees.

- `float FovInfo.bottom` — The bottom edge of the field of view, in degrees.
- `float FovInfo.left` — The left edge of the field of view, in degrees.
- `float FovInfo.right` — The right edge of the field of view, in degrees.
- `float FovInfo.top` — The top edge of the field of view, in degrees.

## class Gradient

A Gradient is a sparse collection of color keys that are used to represent a ramp of colors! This class is largely just storing colors and allowing you to sample between them. Since the Gradient is just interpolating values, you can use whatever color space you want here, as long as it's linear and not gamma! Gamma space RGB can't math properly at all. It can be RGB(linear), HSV, LAB, just remember which one you have, and be sure to convert it appropriately later. Data is stored as float colors, so this'll be a high accuracy blend!

- `int Gradient.Count` — The number of color keys present in this gradient.
- `void Gradient()` — Creates a new, completely empty gradient.
- `void Gradient(GradientKey[] keys)` — Creates a new gradient from the list of color keys!
  - `keys` — These can be in any order that you like, they'll be sorted by their GradientKey.position value regardless!
- `void Gradient.Add(Color colorLinear, float position)` — This adds a color key into the list. It'll get inserted to the right slot based on its position.
  - `colorLinear` — Any linear space color you like!
  - `position` — Typically a value between 0-1! This is the position of the color along the 'x-axis' of the gradient.
- `Color Gradient.Get(float at)` — Samples the gradient's color at the given position!
  - `at` — Typically a value between 0-1, but if you used larger or smaller values for your color key's positions, it'll be in that range!
  - returns — The interpolated color at the given position. If 'at' is smaller or larger than the gradient's position range, then the color will be clamped to the color at the beginning or end of the gradient!
- `Color32 Gradient.Get32(float at)` — Samples the gradient's color at the given position, and converts it to a 32 bit color. If your RGBA color values are outside of the 0-1 range, then you'll get some issues as they're converted to 0-255 range bytes!
  - `at` — Typically a value between 0-1, but if you used larger or smaller values for your color key's positions, it'll be in that range!
  - returns — The interpolated 32 bit color at the given position. If 'at' is smaller or larger than the gradient's position range, then the color will be clamped to the color at the beginning or end of the gradient!
- `void Gradient.Remove(int index)` — Removes the color key at the given index!
  - `index` — Index of the color key to remove.
- `void Gradient.Set(int index, Color colorLinear, float position)` — Updates the color key at the given index! This will NOT re-order color keys if they are moved past another key's position, which could lead to strange behavior.
  - `index` — Index of the color key to change.
  - `colorLinear` — Any linear space color you like!
  - `position` — Typically a value between 0-1! This is the position of the color along the 'x-axis' of the gradient.

## struct GradientKey

A color/position pair for Gradient values!

- `Color GradientKey.color` — The color for this item, preferably in some form of linear color space. Gamma corrected colors will definitely not math correctly.
- `float GradientKey.position` — Typically a value between 0-1! This is the position of the color along the 'x-axis' of the gradient.
- `void GradientKey(Color colorLinear, float position)` — A basic copy constructor for GradientKey.
  - `colorLinear` — The color for this item, preferably in some form of linear color space. Gamma corrected colors will definitely not math correctly.
  - `position` — Typically a value between 0-1! This is the position of the color along the 'x-axis' of the gradient.

## class Hand

Information about a hand!

- `Pose Hand.aim` — A pose an orientation representing where the hand is pointing to. This may be provided by the OpenXR runtime, or be a fallback provided by StereoKit. Typically this starts and the index finger's primary knuckle, and points in the same direction as a line drawn from the shoulder to the knuckle.
- `BtnState Hand.aimReady` — This is a filter state for when the hand is ready to interact with something at a distance. This often factors into account palm direction, as well as distance from the body, and the current pinch and tracked state.
- `HandJoint[] Hand.fingers` — This is a 2D array with 25 HandJoints. You can get the right joint by `finger*5 + joint`, but really, just use Hand.Get or Hand[] instead. See Hand.Get for more info!
- `BtnState Hand.grip` — Is the hand making a grip gesture right now? Fingers next to the palm.
- `float Hand.gripActivation` — What percentage of activation is the grip gesture right now? Where 0 is a hand in an outstretched resting position, and 1 is ring finger touching the base of the palm, within a device error tolerant threshold.
- `Handed Hand.handed` — Is this a right hand, or a left hand?
- `bool Hand.IsGripped` — Are the fingers currently gripped?
- `bool Hand.IsJustGripped` — Have the fingers just been gripped this frame?
- `bool Hand.IsJustPinched` — Have the fingers just been pinched this frame?
- `bool Hand.IsJustTracked` — Has the hand just started being tracked this frame?
- `bool Hand.IsJustUngripped` — Have the fingers just stopped being gripped this frame?
- `bool Hand.IsJustUnpinched` — Have the fingers just stopped being pinched this frame?
- `bool Hand.IsJustUntracked` — Has the hand just stopped being tracked this frame?
- `bool Hand.IsPinched` — Are the fingers currently pinched?
- `bool Hand.IsTracked` — Is the hand being tracked by the sensors right now?
- `Material Hand.Material` — Set the Material used to render the hand! The default material uses an offset of 10 to ensure it gets drawn overtop of other elements.
- `Pose Hand.palm` — The position and orientation of the palm! Position is specifically defined as the middle of the middle finger's root (metacarpal) bone. For orientation, Forward is the direction the flat of the palm is facing, "Iron Man" style. X+ is to the outside of the right hand, and to the inside of the left hand.
- `BtnState Hand.pinch` — Is the hand making a pinch gesture right now? Finger and thumb together.
- `float Hand.pinchActivation` — What percentage of activation is the pinch gesture right now? Where 0 is a hand in an outstretched resting position, and 1 is fingers touching, within a device error tolerant threshold.
- `Vec3 Hand.pinchPt` — This is an approximation of where the center of a 'pinch' gesture occurs, and is used internally by StereoKit for some tasks, such as UI. For simulated hands, this position will give you the most stable pinch location possible. For real hands, it'll be pretty close to the stablest point you'll get. This is especially important for when the user begins and ends their pinch action, as you'll often see a lot of extra movement in the fingers then.
- `float Hand.size` — This is the size of the hand, calculated by measuring the length of the middle finger! This is calculated by adding the distances between each joint, then adding the joint radius of the root and tip. This value is recalculated at relatively frequent intervals, and can vary by as much as a centimeter.
- `BtnState Hand.tracked` — Is the hand being tracked by the sensors right now?
- `bool Hand.Visible` — Sets whether or not StereoKit should render this hand for you. Turn this to false if you're going to render your own, or don't need the hand itself to be visible.
- `Pose Hand.wrist` — Pose of the wrist. This is located at the base of your hand, and has a rigid orientation that points forward towards your fingers. Its orientation is unrelated to the forearm. This pose can be useful for making a hand relative coordinate space!
- `HandJoint Hand.Get(FingerId finger, JointId joint)` — Returns the joint information of the indicated hand joint! This also includes fingertips as a 'joint'. This is the same as the [] operator. Note that for thumbs, there are only 4 'joints' in reality, so StereoKit has JointId.Root and JointId.KnuckleMajor as the same pose, so JointId.Tip is still the tip of the thumb!
  - `finger` — Which finger are we getting from here, 0 is thumb, and pinky is 4!
  - `joint` — Which joint on the finger are we getting? 0 is the root, which is all the way at the base of the palm, and 4 is the tip, the very end of the finger.
  - returns — Position, orientation, and radius of the finger joint.
- `HandJoint Hand.Get(int finger, int joint)` — Returns the joint information of the indicated hand joint! This also includes fingertips as a 'joint'. This is the same as the [] operator. Note that for thumbs, there are only 4 'joints' in reality, so StereoKit has JointId.Root and JointId.KnuckleMajor as the same pose, so JointId.Tip is still the tip of the thumb!
  - `finger` — Which finger are we getting from here, 0 is thumb, and pinky is 4!
  - `joint` — Which joint on the finger are we getting? 0 is the root, which is all the way at the base of the palm, and 4 is the tip, the very end of the finger.
  - returns — Position, orientation, and radius of the finger joint.

## enum Handed

An enum for indicating which hand to use!

- `Handed.Left` — Left hand.
- `Handed.Max` — The number of hands one generally has, this is much nicer than doing a for loop with '2' as the condition! It's much clearer when you can loop Hand.Max times instead.
- `Handed.Right` — Right hand.

## struct HandJoint

Contains information to represents a joint on the hand.

- `Quat HandJoint.orientation` — The joint's world space orientation, where Forward points to the next joint down the finger, and Up will point towards the back of the hand. On the left hand, Right will point towards the thumb, and on the right hand, Right will point away from the thumb.
- `Pose HandJoint.Pose` — Pose position is the center of the joint's world space location. Pose orientation is the world space orientation, where Forward points to the next joint down the finger. On the left hand, Right will point towards the thumb, and on the right hand, Right will point away from the thumb.
- `Vec3 HandJoint.position` — The center of the joint's world space location.
- `float HandJoint.radius` — The distance, in meters, to the surface of the hand from this joint.
- `void HandJoint(Vec3 position, Quat orientation, float radius)` — You can make a hand joint of your own here, but most likely you'd rather fetch one from `Input.Hand().Get()`!
  - `position` — The center of the joint's world space location.
  - `orientation` — The joint's world space orientation, where Forward points to the next joint down the finger, and Up will point towards the back of the hand. On the left hand, Right will point towards the thumb, and on the right hand, Right will point away from the thumb.
  - `radius` — The distance, in meters, to the surface of the hand from this joint.

## struct HandSimId

Id of a simulated hand pose, for use with `Input.HandSimPoseRemove`

- `static HandSimId HandSimId.None` — An id for testing emptiness.
- `bool HandSimId.Equals(Object obj)` — Same as ==
  - `obj` — Must be a HandSimId
  - returns — Equality.
- `int HandSimId.GetHashCode()` — Hash code of the id.
  - returns — Hash code of the id.
- `static bool HandSimId.op_Equality(HandSimId a, HandSimId b)` — Compares the equality of two HandSimIds, nothing fancy here.
  - `a` — First hand id.
  - `b` — Second hand id.
  - returns — a == b
- `static bool HandSimId.op_Inequality(HandSimId a, HandSimId b)` — Compares the equality of two HandSimIds, nothing fancy here.
  - `a` — First hand id.
  - `b` — Second hand id.
  - returns — a != b

## enum HandSource

This enum provides information about StereoKit's hand tracking data source. It allows you to distinguish between true hand data such as that provided by a Leap Motion Controller, and simulated data that StereoKit provides when true hand data is not present.

- `HandSource.Articulated` — This is true hand data which exhibits the full range of motion of a normal hand. It is backed by something like a Leap Motion Controller, or some other optical (or maybe glove?) hand tracking system.
- `HandSource.None` — There is currently no source of hand data! This means there are no tracked controllers, or active hand tracking systems. This may happen if the user has hand tracking disabled, and no active controllers.
- `HandSource.Overridden` — This hand data is provided by your use of SK's override functionality. What properties it exhibits depends on what override data you're sending to StereoKit!
- `HandSource.Simulated` — The current hand data is a simulation of hand data rather than true hand data. It is backed by either a controller, or a mouse, and may have a more limited range of motion.

## static class Hash

This class contains some tools for hashing data within StereoKit! Certain systems in StereoKit use string hashes instead of full strings for faster search and compare, like UI and Materials, so this class gives access to the code SK uses for hashing. StereoKit currently internally uses a 64 bit FNV hash, though this detail should be pretty transparent to developers.
- `static IdHash Hash.Int(int val)` — This will hash an integer into a hash value that StereoKit can use. This is helpful for adding in some uniqueness using something like a for loop index. This may be best when combined with additional hashes.
  - `val` — An integer that will be hashed.
  - returns — A StereoKit hash representing the provided integer.
- `static IdHash Hash.Int(int val, IdHash root)` — This will hash an integer into a hash value that StereoKit can use. This is helpful for adding in some uniqueness using something like a for loop index. This overload allows you to combine your hash with an existing hash.
  - `val` — An integer that will be hashed.
  - `root` — The hash value this new hash will start from.
  - returns — A StereoKit hash representing a combination of the provided string and the root hash.
- `static IdHash Hash.String(string str)` — This will hash the UTF8 representation of the given string into a hash value that StereoKit can use.
  - `str` — A C# string that will be converted to UTF8, and then hashed.
  - returns — A StereoKit hash representing the provided string.
- `static IdHash Hash.String(string str, IdHash root)` — This will hash the UTF8 representation of the given string into a hash value that StereoKit can use. This overload allows you to combine your hash with an existing hash.
  - `str` — A C# string that will be converted to UTF8, and then hashed.
  - `root` — The hash value this new hash will start from.
  - returns — A StereoKit hash representing a combination of the provided string and the root hash.

## static class Hierarchy

This class represents a stack of transform matrices that build up a transform hierarchy! This can be used like an object-less parent-child system, where you push a parent's transform onto the stack, render child objects relative to that parent transform and then pop it off the stack. Performance note: if any matrices are on the hierarchy stack, any render will cause a matrix multiplication to occur! So if you have a collection of objects with their transforms baked and cached into matrices for performance reasons, you'll want to ensure there are no matrices in the hierarchy stack, or that the hierarchy is disabled! It'll save you a matrix multiplication in that case :)

- `static bool Hierarchy.Enabled` — This is enabled by default. Disabling this will cause any draw call to ignore any Matrices that are on the Hierarchy stack.
- `static void Hierarchy.Pop()` — Removes the top Matrix from the stack!
  - Example: see `Hierarchy.Pop` in StereoKit-docs-reference.md
- `static void Hierarchy.Push(Matrix& parentTransform, HierarchyParent parentBehavior)` — Pushes a transform Matrix onto the stack, and combines it with the Matrix below it. Any draw operation's Matrix will now be combined with this Matrix to make it relative to the current hierarchy. Use Hierarchy.Pop to remove it from the Hierarchy stack! All Push calls must have an accompanying Pop call.
  - `parentTransform` — The transform Matrix you want to apply to all following draw calls.
  - `parentBehavior` — This determines how this matrix combines with the parent matrix below it. Normal behavior is to "inherit" the parent matrix, but there are cases where you may wish to entirely ignore the parent transform. For example, if you're in UI space, and wish to do some world space rendering.
- `static void Hierarchy.Push(Pose parentTransform, HierarchyParent parentBehavior)` — Pushes a transform Matrix calculated from a Pose onto the stack, and combines it with the Matrix below it. Any draw operation's Matrix will now be combined with this Matrix to make it relative to the current hierarchy. Use Hierarchy.Pop to remove it from the Hierarchy stack! All Push calls must have an accompanying Pop call.
  - `parentTransform` — The transform Pose you want to apply to all following draw calls.
  - `parentBehavior` — This determines how this Pose's Matrix combines with the parent matrix below it. Normal behavior is to "inherit" the parent matrix, but there are cases where you may wish to entirely ignore the parent transform. For example, if you're in UI space, and wish to do some world space rendering.
  - Example: see `Hierarchy.Push` in StereoKit-docs-reference.md
- `static Vec3 Hierarchy.ToLocal(Vec3 worldPoint)` — Converts a world space point into the local space of the current Hierarchy stack!
  - `worldPoint` — A point in world space.
  - returns — The provided point now in local hierarchy space!
- `static Quat Hierarchy.ToLocal(Quat worldOrientation)` — Converts a world space rotation into the local space of the current Hierarchy stack!
  - `worldOrientation` — A rotation in world space.
  - returns — The provided rotation now in local hierarchy space!
- `static Pose Hierarchy.ToLocal(Pose worldPose)` — Converts a world pose relative to the current hierarchy stack into local space!
  - `worldPose` — A pose in world space.
  - returns — The provided pose now in local hierarchy space!
- `static Ray Hierarchy.ToLocal(Ray worldRay)` — Converts a world ray relative to the current hierarchy stack into local space!
  - `worldRay` — A ray in world space.
  - returns — The provided ray now in local hierarchy space!
  - Example: see `Hierarchy.ToLocal` in StereoKit-docs-reference.md
- `static Vec3 Hierarchy.ToLocalDirection(Vec3 worldDirection)` — Converts a world space direction into the local space of the current Hierarchy stack! This excludes the translation component normally applied to vectors, so it's still a valid direction.
  - `worldDirection` — A direction in world space.
  - returns — The provided direction now in local hierarchy space!
- `static Vec3 Hierarchy.ToWorld(Vec3 localPoint)` — Converts a local point relative to the current hierarchy stack into world space!
  - `localPoint` — A point in local space.
  - returns — The provided point now in world space!
- `static Quat Hierarchy.ToWorld(Quat localOrientation)` — Converts a local rotation relative to the current hierarchy stack into world space!
  - `localOrientation` — A rotation in local space.
  - returns — The provided rotation now in world space!
- `static Pose Hierarchy.ToWorld(Pose localPose)` — Converts a local pose relative to the current hierarchy stack into world space!
  - `localPose` — A pose in local space.
  - returns — The provided pose now in world space!
- `static Ray Hierarchy.ToWorld(Ray localRay)` — Converts a local ray relative to the current hierarchy stack into world space!
  - `localRay` — A ray in local space.
  - returns — The provided ray now in world space!
  - Example: see `Hierarchy.ToWorld` in StereoKit-docs-reference.md
- `static Vec3 Hierarchy.ToWorldDirection(Vec3 localDirection)` — Converts a local direction relative to the current hierarchy stack into world space! This excludes the translation component normally applied to vectors, so it's still a valid direction.
  - `localDirection` — A direction in local space.
  - returns — The provided direction now in world space!

## enum HierarchyParent

When used with a hierarchy modifying function that will push/pop items onto a stack, this can be used to change the behavior of how parent hierarchy items will affect the item being added to the top of the stack.

- `HierarchyParent.Ignore` — Ignoring the parent hierarchy stack item will let you skip inheriting anything from the parent item. The new item remains exactly as provided.
- `HierarchyParent.Inherit` — Inheriting is generally the default behavior of a hierarchy stack, the current item will inherit the properties of the parent stack item in some form or another.

## interface IAsset

All StereoKit assets implement this interface! This is mostly to help group and hold Asset objects, and is particularly useful when working with Assets at a high level with the `Assets` class.

- `string IAsset.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!

## struct IdHash

This represents an identifier for some item, calculated by hashing some or all of that item's data! StereoKit frequently uses id hashes to represent UI elements. See `UI.StackHash` for creating a UI identifier.

- `static IdHash IdHash.None` — An empty IdHash that represents the unassigned state.
- `bool IdHash.Equals(Object b)` — An equality test.
  - `b` — Another hash.
  - returns — True if equal, false otherwise.
- `bool IdHash.Equals(IdHash b)` — An equality test.
  - `b` — Another hash.
  - returns — True if equal, false otherwise.
- `int IdHash.GetHashCode()` — Same as ulong.GetHashCode
  - returns — Same as ulong.GetHashCode
- `static bool IdHash.op_Equality(IdHash a, IdHash b)` — An equality test.
  - `a` — A hashed id.
  - `b` — A hashed id.
  - returns — True if equal, false otherwise.
- `static UInt64 IdHash.Implicit Conversions(IdHash h)` — For back compatibility, allows conversion from an IdHash into a ulong, which may still be used in some parts of the older API.
  - `h` — Source id.
  - returns — An older style ulong hash.
- `static IdHash IdHash.Implicit Conversions(UInt64 h)` — For back compatibility, allows old ulong hashes to auto convert to the newer opaque IdHash representation.
  - `h` — Source id.
  - returns — A new style IdHash hash.
- `static bool IdHash.op_Inequality(IdHash a, IdHash b)` — An inequality test.
  - `a` — A hashed id.
  - `b` — A hashed id.
  - returns — True if unequal, false otherwise.

## static class Input

Input from the system come from this class! Hands, eyes, heads, mice and pointers!

- `static BtnState Input.ControllerMenuButton` — This is the state of the controller's menu button, this is not attached to any particular hand, so it's independent of a left or right controller.
- `static Pose Input.Eyes` — If the device has eye tracking hardware and the app has permission to use it, then this is the most recently tracked eye pose. Check `Input.EyesTracked` to see if the pose is up-to date, or if it's a leftover! You can also check `SK.System.eyeTrackingPresent` to see if the hardware is capable of providing eye tracking. On Flatscreen when the MR sim is still enabled, then eyes are emulated using the cursor position when the user holds down Alt.
- `static BtnState Input.EyesTracked` — If eye hardware is available and app has permission, then this is the tracking state of the eyes. Eyes may move out of bounds, hardware may fail to detect eyes, or who knows what else! On Flatscreen when MR sim is still enabled, this will report whether the user is simulating eye input with the Alt key. **Permissions** - On some platforms (like Android) explicit permission is required to access eye info. See the Permissions class for details.
- `static bool Input.FingerGlow` — This controls the visibility of StereoKit's finger glow effect on the UI. When true, SK will fill out global shader variable `sk_fingertip[2]` with the location of the pointer finger's tips. When false, or the hand is untracked, the location will be set to an unlikely faraway position.
- `static Pose Input.Head` — The position and orientation of the user's head in world space! This is the center point between the user's eyes, NOT the center of the user's head. Forward points the same way the user's face is facing.
- `static Mouse Input.Mouse` — Information about this system's mouse, or lack thereof!
- `static BtnState Input.Button(InputButton buttonType)` — Gets a binary button state from the input system. These are on/off inputs like controller face buttons and thumbstick clicks.
  - `buttonType` — The type of button input to retrieve.
  - returns — A BtnState describing whether the button is active, just became active, or just became inactive this frame.
- `static Controller Input.Controller(Handed handed)` — Gets raw controller input data from the system. Note that not all buttons provided here are guaranteed to be present on the user's physical controller. Controllers are also not guaranteed to be available on the system, and are never simulated.
  - `handed` — The handedness of the controller to get the state of.
  - returns — A reference to a class that contains state information about the indicated controller.
  - Example: see `Input.Controller` in StereoKit-docs-reference.md
- `static Model Input.ControllerModelGet(Handed handed)` — This retreives the Model currently in use by StereoKit to represent the controller input source. By default, this will be a Model provided by OpenXR, or SK's fallback Model. This will never be null while SK is initialized.
  - `handed` — The hand of the controller Model to retreive.
  - returns — The current controller Model. By default, his will be a Model provided by OpenXR, or SK's fallback Model. This will never be null while SK is initialized.
- `static void Input.ControllerModelSet(Handed handed, Model model)` — When StereoKit is rendering the input source, this allows you to override the controller Model SK uses. The Model SK uses by default may be provided from the OpenXR runtime depending on extension support, but if not, SK does have a default Model. Setting this to null will restore SK's default.
  - `handed` — The hand to assign the Model to.
  - `model` — The Model to use to represent the controller. Null is valid, and will restore SK's default model.
- `static void Input.FireEvent(InputSource eventSource, BtnState eventTypes, Pointer pointer)` — This function allows you to artifically insert an input event, simulating any device source and event type you want.
  - `eventSource` — The event source to simulate, this is a bit flag.
  - `eventTypes` — The event type to simulate, this is a bit flag.
  - `pointer` — The pointer data to pass along with this simulated input event.
- `static float Input.Float(InputFloat floatType)` — Gets an analog float input value from the input system. These are inputs like controller triggers and grip buttons that range from 0 to 1.
  - `floatType` — The type of float input to retrieve.
  - returns — A value from 0 to 1 representing how far the input is pressed.
- `static Hand Input.Hand(Handed handed)` — Retrieves all the information about the user's hand! StereoKit will always provide hand information, however sometimes that information is simulated, like in the case of a mouse, or controllers. Note that this is a copy of the hand information, and it's a good chunk of data, so it's a good idea to grab it once and keep it around for the frame, or at least function, rather than asking for it again and again each time you want to touch something.
  - `handed` — Do you want the left or the right hand?
  - returns — A copy of the entire set of hand data!
- `static Hand Input.Hand(int handed)` — Retrieves all the information about the user's hand! StereoKit will always provide hand information, however sometimes that information is simulated, like in the case of a mouse, or controllers. Note that this is a copy of the hand information, and it's a good chunk of data, so it's a good idea to grab it once and keep it around for the frame, or at least function, rather than asking for it again and again each time you want to touch something.
  - `handed` — Do you want the left or the right hand? 0 is left, and 1 is right.
  - returns — A copy of the entire set of hand data!
  - Example: see `Input.Hand` in StereoKit-docs-reference.md
- `static void Input.HandClearOverride(Handed hand)` — Clear out the override status from Input.HandOverride, and restore the user's control over it again.
  - `hand` — Which hand are we clearing the override on?
- `static bool Input.HandGetVisible(Handed hand)` — Returns whether StereoKit is set to render the given hand. If Handed.Max is provided, this returns true if either hand is visible.
  - `hand` — The hand to check visibility for, or Handed.Max to check if either hand is visible.
  - returns — True if StereoKit renders this hand, false if not.
- `static void Input.HandMaterial(Handed hand, Material material)` — Set the Material used to render the hand! The default material uses an offset of 10 to ensure it gets drawn overtop of other elements.
  - `hand` — If Handed.Max, this will set the value for both hands.
  - `material` — The new Material!
- `static void Input.HandOverride(Handed hand, HandJoint[]& joints)` — This allows you to completely override the hand's pose information! It is still treated like the user's hand, so this is great for simulating input for testing purposes. It will remain overridden until you call Input.HandClearOverride.
  - `hand` — Which hand should be overridden?
  - `joints` — A 2D array of 25 joints that should be used as StereoKit's hand information. See `Hand.fingers` for more information.
- `static HandSimId Input.HandSimPoseAdd(Pose[] handJointsPalmRelative25, ControllerKey button1, ControllerKey andButton2, Key orHotkey1, Key andHotkey2)` — StereoKit will use controller inputs to simulate an articulated hand. This function allows you to add new simulated poses to different controller or keyboard buttons!
  - `handJointsPalmRelative25` — 25 joint poses, thumb to pinky, and root to tip with two duplicate poses for the thumb root joint. These should be right handed, and relative to the palm joint.
  - `button1` — Controller button to activate this pose, can be None if this is a keyboard only pose.
  - `andButton2` — Second controller button required to activate this pose. First must also be pressed. Can be None if it's only a single button pose.
  - `orHotkey1` — Keyboard key to activate this pose, can be None if this is a controller only pose.
  - `andHotkey2` — Second keyboard key required to activate this pose. First must also be pressed. Can be None if it's only a single key pose.
  - returns — Returns the id of the hand sim pose, so it can be removed later.
- `static void Input.HandSimPoseClear()` — This clears all registered hand simulation poses, including the ones that StereoKit registers by default!
- `static void Input.HandSimPoseRemove(HandSimId id)` — Lets you remove an existing hand pose.
  - `id` — Any valid or invalid hand sim pose id.
- `static HandSource Input.HandSource(Handed hand)` — This gets the _current_ source of the hand joints! This allows you to distinguish between fully articulated joints, and simulated hand joints that may not have the same range of mobility. Note that this may change during a session, the user may put down their controllers, automatically switching to hands, or visa versa.
  - `hand` — Do  you want the left or right hand? 0 is left, and 1 is right.
  - returns — Returns information about hand tracking data source.
- `static void Input.HandVisible(Handed hand, bool visible)` — Sets whether or not StereoKit should render the hand for you. Turn this to false if you're going to render your own, or don't need the hand itself to be visible.
  - `hand` — If Handed.Max, this will set the value for both hands.
  - `visible` — True, StereoKit renders this. False, it doesn't.
- `static InputHapticCaps Input.HapticCaps(InputHaptic output)` — Returns the playback modes the given haptic output supports right now. The result depends on which controller is active and which OpenXR extensions are available, so it can change at runtime whenever the active OpenXR interaction profile changes — typically when the user picks up, sets down, or swaps a controller. Code that relies on HapticWaveform or HapticCurve should check this first and fall back to HapticPulse when the relevant capability bit is missing.
  - `output` — Which haptic output to query.
  - returns — A flags value with one bit per supported playback mode, or None if the output isn't currently bound.
  - Example: see `Input.HapticCaps` in StereoKit-docs-reference.md
- `static void Input.HapticCurve(InputHaptic output, Single[] amplitudes, float sampleRateHz)` — Plays an amplitude envelope on the given output. Each element is an unsigned amplitude in [0, 1] sampled at sampleRateHz; the runtime picks the carrier frequency and modulates intensity over time. Requires the InputHapticCaps.Curve capability bit; the call is a silent no-op on devices that lack the XR_FB_haptic_amplitude_envelope OpenXR extension. Use HapticCurve for shaping the *intensity* of a vibration (fade, pulse, decay tail) when the texture of the underlying buzz isn't important. Use HapticWaveform when you need to author the underlying carrier yourself. Each call replaces any in-flight playback (the underlying OpenXR extension has no append concept for envelopes), and amplitudes over 4000 samples are truncated to fit the extension's documented limit. For longer or streamed effects, use HapticWaveform.
  - `output` — Which haptic output to vibrate.
  - `amplitudes` — Unsigned [0, 1] intensity samples.
  - `sampleRateHz` — The sample rate the envelope was authored at.
- `static float Input.HapticPreferredRate(InputHaptic output)` — Reports the controller's preferred PCM sample rate in Hz. Authoring HapticWaveform buffers at this rate avoids runtime resampling, which matters for procedural / streaming use. Returns 0 when the runtime accepts any rate or PCM playback isn't available on this device.
  - `output` — Which haptic output to query.
  - returns — Preferred sample rate in Hz, or 0 if unspecified.
  - Example: see `Input.HapticPreferredRate` in StereoKit-docs-reference.md
- `static void Input.HapticPulse(InputHaptic output, float frequency, float amplitude, float durationSec)` — Plays a single sustained vibration on the given output. This is the simplest haptic mode and works on every controller that has any actuator at all. Cancels any in-flight HapticWaveform stream on this output before playing.
  - `output` — Which haptic output to vibrate.
  - `frequency` — Carrier frequency in Hz. Pass 0 or negative to let the runtime pick a sensible default for the device.
  - `amplitude` — Vibration intensity, 0 (off) to 1 (full). Values outside this range are clamped.
  - `durationSec` — How long to vibrate, in seconds. Pass 0 or negative for the shortest pulse the device supports.
  - Example: see `Input.HapticPulse` in StereoKit-docs-reference.md
- `static void Input.HapticStop(InputHaptic output)` — Cancels any haptic playback on the given output, including in-flight PCM streams.
  - `output` — Which haptic output to silence.
  - Example: see `Input.HapticStop` in StereoKit-docs-reference.md
- `static void Input.HapticWaveform(InputHaptic output, Single[] samples, float sampleRateHz, bool append)` — Plays a PCM waveform on the given output. Samples are signed values in [-1, 1] sampled at sampleRateHz, like an audio buffer. Requires the InputHapticCaps.Waveform capability bit; the call is a silent no-op on devices that lack XR_FB_haptic_pcm. Buffers longer than the runtime's per-call limit are streamed transparently — pass any length and StereoKit will drip-feed chunks to the device over multiple frames. For procedural use, reuse the same float[] buffer across calls to avoid per-frame allocations. To explicitly cut a stream mid-playback, pass append=false here, or call HapticStop / HapticPulse.
  - `output` — Which haptic output to vibrate.
  - `samples` — Signed [-1, 1] PCM samples.
  - `sampleRateHz` — The sample rate the buffer was authored at. See HapticPreferredRate for the device's native rate. If this differs from the in-flight stream's rate, append behavior degrades to a restart.
  - `append` — When true, queues these samples after any playback already in flight on this output. When false (default), cancels any current playback and starts the new buffer immediately.
- `static void Input.HapticWaveform(InputHaptic output, Single[] samples, float sampleRateHz, bool append, Int32& prevSamplesConsumed)` — Plays a PCM waveform and reports how many samples the runtime had drained from the previously-submitted chunk by the time this call was processed. Streaming callers use the consumed count to throttle their per-frame submission rate and bound playback latency.
  - `output` — Which haptic output to vibrate.
  - `samples` — Signed [-1, 1] PCM samples.
  - `sampleRateHz` — The sample rate the buffer was authored at.
  - `append` — When true, queues after any in-flight playback; when false, replaces it.
  - `prevSamplesConsumed` — Receives the runtime's samplesConsumed count for the most recent chunk StereoKit submitted to the device, or 0 if no chunk was in flight. This is reported at chunk granularity, not at the granularity of HapticWaveform calls — a single HapticWaveform call may span multiple internal chunks.
  - Example: see `Input.HapticWaveform` in StereoKit-docs-reference.md
- `static BtnState Input.Key(Key key)` — Keyboard key state! On desktop this is super handy, but even standalone MR devices can have bluetooth keyboards, or even just holographic system keyboards!
  - `key` — The key to get the state of. Any key!
  - returns — A BtnState with a number of different bits of info about whether or not the key was pressed or released this frame.
- `static void Input.KeyInjectPress(Key key)` — This will inject a key press event into StereoKit's input event queue. It will be processed at the start of the next frame, and will be indistinguishable from a physical key press. Remember to release your key as well! This will _not_ submit text to StereoKit's text queue, and will not show up in places like UI.Input. For that, you must submit a TextInjectChar call.
  - `key` — The key to press.
- `static void Input.KeyInjectRelease(Key key)` — This will inject a key release event into StereoKit's input event queue. It will be processed at the start of the next frame, and will be indistinguishable from a physical key release. This should be preceded by a key press! This will _not_ submit text to StereoKit's text queue, and will not show up in places like UI.Input. For that, you must submit a TextInjectChar call.
  - `key` — The key to release.
- `static Pointer Input.Pointer(int index, InputSource filter)` — This gets the pointer by filter based index.
  - `index` — Index of the pointer.
  - `filter` — Filter used to search for the Pointer.
  - returns — The Pointer data.
- `static int Input.PointerCount(InputSource filter)` — The number of Pointer inputs that StereoKit is tracking that match the given filter.
  - `filter` — You can filter input sources using this bit flag.
  - returns — The number of Pointers StereoKit knows about that matches the given filter.
- `static Pose Input.Pose(InputPose poseType)` — Gets a tracked pose from the input system by type. These are spatial poses provided by the XR runtime, such as hand or controller positions and orientations.
  - `poseType` — The type of pose to retrieve.
  - returns — The most recent pose of the given type.
- `static PoseState Input.PoseState(InputPose poseType)` — Gets the tracking state of a tracked pose. This tells you whether the position and rotation components are actively being tracked by the XR system, and at what quality.
  - `poseType` — The type of pose to check tracking state for.
  - returns — A PoseState flags value indicating which components are tracked and whether they are inferred or known.
- `static void Input.Subscribe(InputSource eventSource, BtnState eventTypes, Action`3 onEvent)` — You can subscribe to input events from Pointer sources here. StereoKit will call your callback and pass along a Pointer that matches the position of that pointer at the moment the event occurred. This can be more accurate than polling for input data, since polling happens specifically at frame start.
  - `eventSource` — What input sources do we want to listen for. This is a bit flag.
  - `eventTypes` — What events do we want to listen for. This is a bit flag.
  - `onEvent` — The callback to call when the event occurs!
- `static Char Input.TextConsume()` — Returns the next text character from the list of characters that have been entered this frame! Will return '\0' if there are no more characters left in the list. These are from the system's text entry system, and so can be unicode, will repeat if their 'key' is held down, and could arrive from something like a copy/paste operation. If you wish to reset this function to begin at the start of the read list on the next call, you can call `Input.TextReset`.
  - returns — The next character in this frame's list, or '\0' if none remain.
  - Example: see `Input.TextConsume` in StereoKit-docs-reference.md
- `static void Input.TextInjectChar(uint unicodeCharUTF32)` — This will inject a UTF32 Unicode text character into StereoKit's text input queue. It will be available at the start of the next frame, and will be indistinguishable from normal text entry. This will _not_ submit key press/release events to StereoKit's input queue, use KeyInjectPress/Release for that.
  - `unicodeCharUTF32` — An unsigned integer representing a single UTF32 character.
- `static void Input.TextInjectChar(string chars)` — This will convert a C# string into a number of UTF32 Unicode text characters, and inject them into StereoKit's text input queue. It will be available at the start of the next frame, and will be indistinguishable from normal text entry. This will _not_ submit key press/release events to StereoKit's input queue, use KeyInjectPress/Release for that.
  - `chars` — A collection of characters to submit as text input.
- `static void Input.TextInjectChar(Byte[] chars, Encoding charEncoding)` — This will convert a byte array string into a number of UTF32 Unicode text characters, and inject them into StereoKit's text input queue. It will be available at the start of the next frame, and will be indistinguishable from normal text entry. This will _not_ submit key press/release events to StereoKit's input queue, use KeyInjectPress/Release for that.
  - `chars` — A byte array representing a string in some encoded format.
  - `charEncoding` — The encoding format of the byte array. Note that an encoding of UTF32 will skip converting bytes to UTF32.
- `static void Input.TextReset()` — Resets the `Input.TextConsume` read list back to the start. For example, `UI.Input` will _not_ call `TextReset`, so it effectively will consume those characters, hiding them from any `TextConsume` calls following it. If you wanted to check the current frame's text, but still allow `UI.Input` to work later on in the frame, you would read everything with `TextConsume`, and then `TextReset` afterwards to reset the read list for the following `UI.Input`.
  - Example: see `Input.TextReset` in StereoKit-docs-reference.md
- `static void Input.Unsubscribe(InputSource eventSource, BtnState eventTypes, Action`3 onEvent)` — Unsubscribes a listener from input events.
  - `eventSource` — The source this listener was originally registered for.
  - `eventTypes` — The events this listener was originally registered for.
  - `onEvent` — The callback this listener originally used.
- `static Vec2 Input.XY(InputXY xyType)` — Gets a 2D axis input from the input system, like a controller thumbstick. X is left/right, and Y is forward/back, each ranging from -1 to 1.
  - `xyType` — The type of XY input to retrieve.
  - returns — A Vec2 representing the current stick position.

## enum InputButton

Index values for binary button inputs from controllers. These are on/off inputs that provide button_state_ information.

- `InputButton.LAimReady` — Is the left hand ready to interact at a distance? This maps to the pinch_ext/ready_ext binding from the hand interaction extension, and factors in facing direction and pinch readiness.
- `InputButton.LMenu` — The menu or settings button on the left controller.
- `InputButton.LStick` — The left controller's thumbstick button, pressed by clicking the stick inward. This has nothing to do with the stick's XY position.
- `InputButton.LX1` — The lower of the two left thumb buttons, sometimes labelled X, and sometimes A.
- `InputButton.LX2` — The upper of the two left thumb buttons, sometimes labelled Y, and sometimes B.
- `InputButton.Max` — Total number of input button types.
- `InputButton.RAimReady` — Is the right hand ready to interact at a distance? This maps to the pinch_ext/ready_ext binding from the hand interaction extension, and factors in facing direction and pinch readiness.
- `InputButton.RMenu` — The menu or settings button on the right controller.
- `InputButton.RStick` — The right controller's thumbstick button, pressed by clicking the stick inward. This has nothing to do with the stick's XY position.
- `InputButton.RX1` — The lower of the two right thumb buttons, sometimes labelled X, and sometimes A.
- `InputButton.RX2` — The upper of the two right thumb buttons, sometimes labelled Y, and sometimes B.

## delegate InputEventCallback

A callback for when input events occur.

## enum InputFloat

Index values for analog float inputs from controllers. These are inputs that range from 0-1 based on how far the user has pressed them.

- `InputFloat.LGrip` — The grip button on the left controller, usually where the remaining fingers sit.
- `InputFloat.LTrigger` — The trigger on the left controller, where the user's index finger typically rests.
- `InputFloat.Max` — Total number of input float types.
- `InputFloat.RGrip` — The grip button on the right controller, usually where the remaining fingers sit.
- `InputFloat.RTrigger` — The trigger on the right controller, where the user's index finger typically rests.

## enum InputHaptic

Index values for haptic outputs on controllers. These represent a destination for vibration playback, requested via Input.HapticPulse, Input.HapticWaveform, or Input.HapticCurve.

- `InputHaptic.LController` — The left controller's primary haptic actuator.
- `InputHaptic.Max` — Total number of haptic outputs.
- `InputHaptic.RController` — The right controller's primary haptic actuator.

## enum InputHapticCaps

Bit flags describing what playback modes a haptic output currently supports. Queryable via Input.HapticCaps. The set of supported modes may change at runtime whenever the active OpenXR interaction profile changes, which typically happens as the user picks up, sets down, or swaps a controller.

- `InputHapticCaps.Curve` — Amplitude envelope playback via Input.HapticCurve. Requires the XR_FB_haptic_amplitude_envelope OpenXR extension.
- `InputHapticCaps.None` — No haptic output is available right now (e.g. no controller is bound, or the haptic action isn't active).
- `InputHapticCaps.Pulse` — Simple frequency / amplitude / duration vibration via Input.HapticPulse. Supported by every controller that has any haptic actuator.
- `InputHapticCaps.Waveform` — Sample-by-sample PCM playback via Input.HapticWaveform. Requires the XR_FB_haptic_pcm OpenXR extension.

## enum InputPose

Index values for input poses. These represent tracked spatial poses from the XR system, such as hand or controller positions and orientations.

- `InputPose.Eyes` — The user's eye gaze, where they're looking in the world. Requires eye tracking hardware and permissions to provide meaningful data.
- `InputPose.LAim` — The left hand/controller aim pose. This points forward from the hand like a laser pointer, useful for UI interaction at a distance.
- `InputPose.LDetached` — The left pose of a "detached controller", when the user has both hands and controllers active in the scene.
- `InputPose.LGrip` — The left hand/controller grip pose, centered in the hand where you'd hold something like a sword hilt or a tool handle.
- `InputPose.LPalm` — The left hand/controller palm pose, located at the surface of the palm. Forward points along the fingers and Up toward the thumb, with X+ into the palm on the right hand, and out of the palm on the left. This is the controller's palm orientation, which faces along the fingers rather than out from the palm. Uses the palm pose OpenXR extension when available, and falls back to an approximation when it's not.
- `InputPose.LPinch` — The left pinch pose, located between the tips of the thumb and index finger. This is provided by hand interaction systems such as the OpenXR hand interaction extension, and may be present even when full articulated hand tracking is not.
- `InputPose.LPoke` — The left poke pose, located at the tip of the index finger. This is provided by hand interaction systems such as the OpenXR hand interaction extension, and may be present even when full articulated hand tracking is not.
- `InputPose.Max` — Total number of input pose types.
- `InputPose.RAim` — The right hand/controller aim pose. This points forward from the hand like a laser pointer, useful for UI interaction at a distance.
- `InputPose.RDetached` — The right pose of a "detached controller", when the user has both hands and controllers active in the scene.
- `InputPose.RGrip` — The right hand/controller grip pose, centered in the hand where you'd hold something like a sword hilt or a tool handle.
- `InputPose.RPalm` — The right hand/controller palm pose, located at the surface of the palm. Forward points along the fingers and Up toward the thumb, with X+ into the palm on the right hand, and out of the palm on the left. This is the controller's palm orientation, which faces along the fingers rather than out from the palm. Uses the palm pose OpenXR extension when available, and falls back to an approximation when it's not.
- `InputPose.RPinch` — The right pinch pose, located between the tips of the thumb and index finger. This is provided by hand interaction systems such as the OpenXR hand interaction extension, and may be present even when full articulated hand tracking is not.
- `InputPose.RPoke` — The right poke pose, located at the tip of the index finger. This is provided by hand interaction systems such as the OpenXR hand interaction extension, and may be present even when full articulated hand tracking is not.

## enum InputSource

What type of device is the source of the pointer? This is a bit-flag that can contain some input source family information.

- `InputSource.Any` — Matches with all input sources!
- `InputSource.CanPress` — Matches with any input source that has an activation button!
- `InputSource.Gaze` — Matches with Gaze category input sources.
- `InputSource.GazeCursor` — Matches with mouse cursor simulated gaze as an input source.
- `InputSource.GazeEyes` — Matches with the eye gaze input source.
- `InputSource.GazeHead` — Matches with the head gaze input source.
- `InputSource.Hand` — Matches with any hand input source.
- `InputSource.HandLeft` — Matches with left hand input sources.
- `InputSource.HandRight` — Matches with right hand input sources.

## enum InputXY

Index values for 2D axis inputs from controllers, like thumbsticks. These provide a vec2 with X and Y ranging from -1 to 1.

- `InputXY.LStick` — The thumbstick on the left controller. X is left/right, Y is forward/back.
- `InputXY.Max` — Total number of input XY types.
- `InputXY.RStick` — The thumbstick on the right controller. X is left/right, Y is forward/back.

## static class Interaction

Controls for the interaction system, and the interactors that StereoKit provides by default.

- `static bool Interaction.DefaultDraw` — By default, StereoKit will draw indicators for some of the default interactors, such as the far interaction / aiming rays. This doesn't affect custom interactors. Setting this to false will prevent StereoKit from drawing any of these indicators.
- `static DefaultInteractors Interaction.DefaultInteractors` — This allows you to  control what kind of interactors StereoKit will provide for you. This also allows you to entirely disable StereoKit's interactors so you can just use custom ones!

## struct Interactor

Interactors are essentially capsules that allow interaction with StereoKit's interaction primitives used by the UI system. While StereoKit does provide a number of interactors by default, you can replace StereoKit's defaults, add additional interactors, or generally just customize your interactions!

- `InteractorActivation Interactor.Activation` — How does this interactor activate elements? Does it use the physical position of the interactor, or its activation state? This is set at creation time and does not change.
- `IdHash Interactor.Active` — The id of the interaction element that is currently active, this will be `IdHash.None` if this interactor has nothing active. This will always be the same id as `Focused` when not `None`.
- `Vec3 Interactor.End` — The world space end of the interactor capsule. Some interactions can be directional, especially for `Line` type interactors, so if you think of the interactor as an "oriented" capsule, this would be the end which the `Start`/origin points towards.
- `InteractorEvent Interactor.Events` — What type of interaction events does this interactor fire? Interaction elements use this bitflag as a filter to avoid interacting with certain interactors. This is set at creation time and does not change.
- `IdHash Interactor.Focused` — The id of the interaction element that is currently focused, this will be `IdHash.None` if this interactor has nothing focused.
- `float Interactor.MinDistance` — The distance at which a ray starts being interactive. For pointing rays, you may not want them to interact right at their start, or you may want the start to move depending on how outstretched the hand is! This allows you to change that start location without affecting the movement caused by the ray, and still capturing occlusion from blocking elements too close to the start. By default, this is a large negative value.
- `Pose Interactor.Motion` — This pose is the source of translation and rotation motion caused by the interactor. In most cases it will be the same as your Start with the orientation of your interactor, but in some instance may be something else!
- `float Interactor.Radius` — The world space radius of the interactor capsule, in meters.
- `int Interactor.SecondaryDims` — How many axes of secondary motion can this interactor provide? Secondary motion is input that comes from somewhere other than the interactor's own movement through space. For example, a mouse's scroll wheel is 1 axis, and a controller's analog thumbstick is 2 axes (X/Y). This should be 0-3.
- `InteractorSource Interactor.Source` — The physical source this interactor's input comes from, such as a specific hand, controller, or the mouse. Interactors that share a source will deactivate each other when one becomes active, for example the poke, pinch, and aim interactors of a single hand. `InteractorSource.Unique` indicates a source that never groups with other interactors. This is set at creation time and does not change.
- `Vec3 Interactor.Start` — The world space start of the interactor capsule. Some interactions can be directional, especially for `Line` type interactors, so if you think of the interactor as an "oriented" capsule, this would be the origin which points towards the capsule `End`.
- `BtnState Interactor.Tracked` — The tracking state of this interactor.
- `InteractorType Interactor.Type` — A line, or a point? These interactors behave slightly differently with respect to distance checks and directionality. See `InteractorType` for more details. This is set at creation time and does not change.
- `static InteractorCollection Interactor.All` — An enumerable collection of all the Interactors currently in the system. Use this to inspect or visualize every Interactor, including any custom ones you've added.
- `static Interactor Interactor.None` — An empty Interactor that represents "no interactor". UI building blocks like `UI.ButtonBehavior` and `UI.VolumeAt` report this when nothing is interacting with them, so you can test their result against `Interactor.None`.
- `static Interactor Interactor.Create(InteractorType shapeType, InteractorEvent events, InteractorActivation activationType, InteractorSource source, float capsuleRadius, int secondaryMotionDimensions)` — Create a new custom Interactor.
  - `shapeType` — A line, or a point? These interactors behave slightly differently with respect to distance checks and directionality. See `InteractorType` for mor details.
  - `events` — What type of interaction events should this interactor fire? Interaction elements use this bitflag as a filter to avoid interacting with certain interactors.
  - `activationType` — 
  - `source` — The physical source this interactor's input comes from. Interactors that share a source will deactivate each other if one is already active. For example, the poke, pinch, and aim interactors of a single hand all share that hand's source, so if one is actively interacting the whole hand is considered busy. Use `InteractorSource.Unique` for a source that never groups with others, or a custom value at or above `InteractorSource.Max` for your own sources.
  - `capsuleRadius` — The radius of the interactor's capsule, in meters.
  - `secondaryMotionDimensions` — How many axes of secondary motion can this interactor provide? Secondary motion is input from a source other than the interactor's own movement, such as a mouse's scroll wheel (1 axis) or a controller's analog thumbstick (2 axes, X/Y). This should be 0-3.
  - returns — The Interactor that was just created.
- `void Interactor.Destroy()` — Interactors, unlike Assets, don't destroy themselves! You must explicitly Destroy an Interactor if you're finished with it, otherwise it will continue to interact with StereoKit's interactors. This function immediately removes the interactor from the interactor list.
- `bool Interactor.Equals(Object b)` — An equality test. Two Interactors are equal when they refer to the same interactor instance.
  - `b` — Another Interactor.
  - returns — True if equal, false otherwise.
- `bool Interactor.Equals(Interactor b)` — An equality test. Two Interactors are equal when they refer to the same interactor instance.
  - `b` — Another Interactor.
  - returns — True if equal, false otherwise.
- `int Interactor.GetHashCode()` — A hash code based on the interactor's id.
  - returns — A hash code.
- `static bool Interactor.IsInteracting(InteractorSource source)` — Is any interactor from the given source currently interacting with an element, that is, actively pressing or focusing it? Sources can be combined as a bit-flag to ask about several at once, e.g. `InteractorSource.HandLeft | InteractorSource.HandRight`.
  - `source` — The source, or combination of sources, to check.
  - returns — True if a matching interactor has an active element.
- `static bool Interactor.op_Equality(Interactor a, Interactor b)` — An equality test.
  - `a` — An Interactor.
  - `b` — An Interactor.
  - returns — True if equal, false otherwise.
- `static bool Interactor.op_Inequality(Interactor a, Interactor b)` — An inequality test.
  - `a` — An Interactor.
  - `b` — An Interactor.
  - returns — True if unequal, false otherwise.
- `bool Interactor.TryGetFocusBounds(Pose& poseWorld, Bounds& boundsLocal, Vec3& atLocal)` — If this interactor has an element focused, this will output information about the location of that element, as well as the interactor's intersection point with that element.
  - `poseWorld` — The world space Pose of the element's hierarchy space. This is typically the Pose of the Window/Handle/Surface the element belongs to.
  - `boundsLocal` — The bounds of the UI element relative to the Pose. Note that the `center` should always be accounted for here!
  - `atLocal` — The intersection point relative to the Bounds, NOT relative to the Pose!
  - returns — True if bounds data is available.
- `void Interactor.Update(Vec3 capsuleStart, Vec3 capsuleEnd, Pose motion, Vec3 motionAnchor, Vec3 secondaryMotion, BtnState active, BtnState tracked)` — Update the interactor with data for the current frame! This should be called as soon as possible at the start of the frame before any UI is done, otherwise the UI will not properly react.
  - `capsuleStart` — World space location of the collision capsule's start. For Line interactors, this should be the 'origin' of the capsule's orientation.
  - `capsuleEnd` — World space location of the collision capsule's end. For Line interactors, this should be in the direction the Start/origin is facing.
  - `motion` — This pose is the source of translation and rotation motion caused by the interactor. In most cases it will be the same as your capsuleStart with the orientation of your interactor, but in some instance may be something else!
  - `motionAnchor` — Some motion, like that of amplified motion, needs some anchor point with which to determine the amplification from. This might be a shoulder, or a head, or some other point that the interactor will push from / pull towards.
  - `secondaryMotion` — This is motion that comes from somewhere other than the interactor itself! This can be something like an analog stick on a controller, or the scroll wheel of a mouse.
  - `active` — The activation state of the Interactor.
  - `tracked` — The tracking state of the Interactor.

## enum InteractorActivation

This describes how an interactor commits an interaction with an element - does it activate from the physical position of the interactor (like a finger poking through a button), or from its activation/button state (like a pinch or a trigger click)? This is independent of `InteractorType`, which describes the interactor's shape rather than what triggers it.

- `InteractorActivation.Position` — This interactor uses its motion position to determine the element activation.
- `InteractorActivation.State` — This interactor uses its `active` state to determine element activation.

## struct InteractorCollection

An enumerable collection of all the Interactors in the system. Retrieved via `Interactor.All`.

- `int InteractorCollection.Count` — The number of Interactors currently in the system.
- `Enumerator InteractorCollection.GetEnumerator()` — Gets an enumerator for the collection. This returns a concrete struct enumerator so that `foreach` over the collection stays allocation-free.
  - returns — An enumerator.

## struct InteractorCollection.Enumerator

An allocation-free struct enumerator for an `InteractorCollection`.
- `void InteractorCollection.Enumerator.Dispose()` — Nothing to dispose, this is here to satisfy the IEnumerator interface.
- `bool InteractorCollection.Enumerator.MoveNext()` — Advances to the next Interactor.
  - returns — False once the end of the collection is reached.
- `void InteractorCollection.Enumerator.Reset()` — Resets the enumerator to before the first element.

## enum InteractorEvent

A bit-flag mask for interaction event types. This allows or informs what type of events an interactor can perform, or an element can respond to.

- `InteractorEvent.Grip` — Grip events represent the gripping gesture of the hand. This can also map to something like the grip button on a controller. This is generally for larger objects where humans have a tendency to make full fisted grasping motions, like with door handles or sword hilts.
- `InteractorEvent.Pinch` — Pinch events represent the pinching gesture of the hand, where the index finger tip and thumb tip come together. This can also map to something like the trigger button of a controller. This is generally for smaller objects where humans tend to grasp more delicately with just their fingertips, like with a pencil or switches.
- `InteractorEvent.Poke` — Poke events represent direct physical interaction with elements via a single point. This might be like a fingertip pressing a button, or a pencil tip on a page of a paper.

## enum InteractorSource

A bit-flag describing the physical source an interactor's input comes from, such as a specific hand, controller, or the mouse. Interactors that share a source are mutually exclusive: while one is actively interacting, the others won't begin a new interaction. This is how the poke, pinch, and aim interactors of a single hand avoid fighting over the same element. The bits at and above `InteractorSource.Max` are free for your own custom sources.

- `InteractorSource.Any` — Matches with all sources!
- `InteractorSource.ControllerLeft` — The left motion controller.
- `InteractorSource.ControllerRight` — The right motion controller.
- `InteractorSource.Gaze` — Gaze or eye tracking based input.
- `InteractorSource.HandLeft` — The left hand.
- `InteractorSource.HandRight` — The right hand.
- `InteractorSource.Max` — The first bit available for your own custom interactor sources. Bits at and above this are unused by StereoKit, so you can define your own relative to it, for example `(InteractorSource)((int)InteractorSource.Max << 1)`.
- `InteractorSource.Mouse` — A mouse pointer.
- `InteractorSource.Unique` — A unique, independent source. Interactors with this source never group with any other interactor, and are invisible to source queries like `Interactor.IsInteracting`. This is the default 'shares nothing' source.

## enum InteractorType

Should this interactor behave like a single point in space interacting with elements? Or should it behave more like an intangible line? Hit detection is still capsule shaped, but behavior may change a little to reflect the primary position of the point interactor. This can also be thought of as direct interaction vs indirect interaction.

- `InteractorType.Line` — The interactor represents a less tangible line or ray of interaction, such as a laser pointer or eye gaze. Lines will occasionally consider the directionality of the interactor to discard backpressing certain elements,and use distance along the line for occluding elements that are behind other elements.
- `InteractorType.Point` — The interactor represents a physical point in space, such as a fingertip or the point of a pencil. Points do not use directionality for their interactions, nor do they take into account the distance of an element along the 'ray' of the capsule.

## enum JointId

Here's where hands get crazy! Technical terms, and watch out for the thumbs!

- `JointId.KnuckleMajor` — Joint 1. These are the knuckles at the top of the palm! For the thumb, Root and KnuckleMajor have the same value.
- `JointId.KnuckleMid` — Joint 2. These are the knuckles in the middle of the finger! First joints on the fingers themselves.
- `JointId.KnuckleMinor` — Joint 3. The joints right below the fingertip!
- `JointId.Root` — Joint 0. This is at the base of the hand, right above the wrist. For the thumb, Root and KnuckleMajor have the same value.
- `JointId.Tip` — Joint 4. The end/tip of each finger!

## enum Key

A collection of system key codes, representing keyboard characters and mouse buttons. Based on VK codes.

- `Key.A` — a/A
- `Key.Add` — Numpad '+', NOT the same as number row '+'.
- `Key.Alt` — Left or right Alt key.
- `Key.Apostrophe` — '/"
- `Key.B` — b/B
- `Key.Backspace` — Backspace
- `Key.Backtick` — `/~
- `Key.BracketClose` — ]/}
- `Key.BracketOpen` — [/{
- `Key.C` — c/C
- `Key.CapsLock` — This behaves a little differently! This tells the toggle state of caps lock, rather than the key state itself.
- `Key.Comma` — ,/&lt;
- `Key.Ctrl` — Left or right Control key.
- `Key.D` — d/D
- `Key.Decimal` — Numpad '.', NOT the same as character '.'.
- `Key.Del` — Any Delete key.
- `Key.Divide` — Numpad '/', NOT the same as character '/'.
- `Key.Down` — Down arrow key.
- `Key.E` — e/E
- `Key.End` — End
- `Key.Equals` — =/+
- `Key.Esc` — Escape
- `Key.F` — f/F
- `Key.F1` — Function key F1.
- `Key.F10` — Function key F10.
- `Key.F11` — Function key F11.
- `Key.F12` — Function key F12.
- `Key.F2` — Function key F2.
- `Key.F3` — Function key F3.
- `Key.F4` — Function key F4.
- `Key.F5` — Function key F5.
- `Key.F6` — Function key F6.
- `Key.F7` — Function key F7.
- `Key.F8` — Function key F8.
- `Key.F9` — Function key F9.
- `Key.G` — g/G
- `Key.H` — h/H
- `Key.Home` — Home
- `Key.I` — i/I
- `Key.Insert` — Any Insert key.
- `Key.J` — j/J
- `Key.K` — k/K
- `Key.L` — l/L
- `Key.LCmd` — The Windows/Mac Command button on the left side of the keyboard.
- `Key.Left` — Left arrow key.
- `Key.M` — m/M
- `Key.MAX` — Maximum value for key codes.
- `Key.Minus` — -/_
- `Key.MouseBack` — Mouse back button.
- `Key.MouseCenter` — Center mouse button.
- `Key.MouseForward` — Mouse forward button.
- `Key.MouseLeft` — Left mouse button.
- `Key.MouseRight` — Right mouse button.
- `Key.Multiply` — Numpad '*', NOT the same as number row '*'.
- `Key.N` — n/N
- `Key.N0` — Keyboard top row 0, with shift is ')'.
- `Key.N1` — Keyboard top row 1, with shift is '!'.
- `Key.N2` — Keyboard top row 2, with shift is '@'.
- `Key.N3` — Keyboard top row 3, with shift is '#'.
- `Key.N4` — Keyboard top row 4, with shift is '$'.
- `Key.N5` — Keyboard top row 5, with shift is '%'.
- `Key.N6` — Keyboard top row 6, with shift is '^'.
- `Key.N7` — Keyboard top row 7, with shift is '&'.
- `Key.N8` — Keyboard top row 8, with shift is '*'.
- `Key.N9` — Keyboard top row 9, with shift is '('.
- `Key.None` — Doesn't represent a key, generally means this item has not been set to any particular value!
- `Key.Num0` — 0 on the numpad, when numlock is on.
- `Key.Num1` — 1 on the numpad, when numlock is on.
- `Key.Num2` — 2 on the numpad, when numlock is on.
- `Key.Num3` — 3 on the numpad, when numlock is on.
- `Key.Num4` — 4 on the numpad, when numlock is on.
- `Key.Num5` — 5 on the numpad, when numlock is on.
- `Key.Num6` — 6 on the numpad, when numlock is on.
- `Key.Num7` — 7 on the numpad, when numlock is on.
- `Key.Num8` — 8 on the numpad, when numlock is on.
- `Key.Num9` — 9 on the numpad, when numlock is on.
- `Key.O` — o/O
- `Key.P` — p/P
- `Key.PageDown` — Page down
- `Key.PageUp` — Page up
- `Key.Period` — ./&gt;
- `Key.Printscreen` — Printscreen
- `Key.Q` — q/Q
- `Key.R` — r/R
- `Key.RCmd` — The Windows/Mac Command button on the right side of the keyboard.
- `Key.Return` — Return, or Enter.
- `Key.Right` — Right arrow key.
- `Key.S` — s/S
- `Key.Semicolon` — ;/:
- `Key.Shift` — Left or right Shift.
- `Key.SlashBack` — \
- `Key.SlashFwd` — /
- `Key.Space` — Space
- `Key.Subtract` — Numpad '-', NOT the same as number row '-'.
- `Key.T` — t/T
- `Key.Tab` — Tab
- `Key.U` — u/U
- `Key.Up` — Up arrow key.
- `Key.V` — v/V
- `Key.W` — w/W
- `Key.X` — x/X
- `Key.Y` — y/Y
- `Key.Z` — z/Z

## struct LinePoint

Used to represent lines for the line drawing functions! This is just a snapshot of information about each individual point on a line.

- `Color32 LinePoint.color` — The vertex color for the line at this position.
- `Vec3 LinePoint.pt` — Location of the line point.
- `float LinePoint.thickness` — Total thickness of the line, in meters.
- `void LinePoint(Vec3 point, Color32 color, float thickness)` — This creates and fills out a LinePoint.
  - `point` — The location of this point on a line.
  - `color` — The Color for this line vertex.
  - `thickness` — The thickness of the line at this vertex.

## static class Lines

A line drawing class! This is an easy way to visualize lines or relationships between objects. The current implementation uses a quad strip that always faces the user, via vertex shader manipulation.
- `static void Lines.Add(Vec3 start, Vec3 end, Color32 color, float thickness)` — Adds a line to the environment for the current frame.
  - `start` — Starting point of the line.
  - `end` — End point of the line.
  - `color` — Color for the line, this is embedded in the vertex color of the line.
  - `thickness` — Thickness of the line in meters.
- `static void Lines.Add(Vec3 start, Vec3 end, Color32 colorStart, Color32 colorEnd, float thickness)` — Adds a line to the environment for the current frame.
  - `start` — Starting point of the line.
  - `end` — End point of the line.
  - `colorStart` — Color for the start of the line, this is embedded in the vertex color of the line.
  - `colorEnd` — Color for the end of the line, this is embedded in the vertex color of the line.
  - `thickness` — Thickness of the line in meters.
- `static void Lines.Add(Ray ray, float length, Color32 color, float thickness)` — Adds a line based on a ray to the environment for the current frame.
  - `ray` — The ray we want to visualize!
  - `length` — How long should the ray be? Actual length will be ray.direction.Magnitude * length.
  - `color` — Color for the line, this is embedded in the vertex color of the line.
  - `thickness` — Thickness of the line in meters.
- `static void Lines.Add(LinePoint[]& points)` — Adds a line from a list of line points to the environment. This does not close the path, so if you want it closed, you'll have to add an extra point or two at the end yourself!
  - `points` — An array of line points.
  - Example: see `Lines.Add` in StereoKit-docs-reference.md
- `static void Lines.AddAxis(Pose atPose, float size, float thickness)` — Displays an RGB/XYZ axis widget at the pose! Each line is extended along the positive direction of each axis, so the red line is +X, green is +Y, and blue is +Z. A white line is drawn along -Z to indicate the Forward vector of the pose (-Z is forward in StereoKit).
  - `atPose` — What position and orientation do we want this axis widget at?
  - `size` — How long should the widget lines be, in meters?
  - `thickness` — How thick should the lines be, in meters?
- `static void Lines.AddAxis(Pose atPose, float size)` — Displays an RGB/XYZ axis widget at the pose! Each line is extended along the positive direction of each axis, so the red line is +X, green is +Y, and blue is +Z. A white line is drawn along -Z to indicate the Forward vector of the pose (-Z is forward in StereoKit).
  - `atPose` — What position and orientation do we want this axis widget at?
  - `size` — How long should the widget lines be, in meters?
  - Example: see `Lines.AddAxis` in StereoKit-docs-reference.md

## static class Log

A class for logging errors, warnings and information! Different levels of information can be filtered out, and supports coloration via <~[colorCode]> and <~clr> tags. Text colors can be set with a tag, and reset back to default with <~clr>. Color codes are as follows: | Dark | Bright | Description | |------|--------|-------------| | DARK | BRIGHT | DESCRIPTION | | blk  | BLK    | Black       | | red  | RED    | Red         | | grn  | GRN    | Green       | | ylw  | YLW    | Yellow      | | blu  | BLU    | Blue        | | mag  | MAG    | Magenta     | | cyn  | cyn    | Cyan        | | grn  | GRN    | Green       | | wht  | WHT    | White       |

- `static LogLevel Log.Filter` — What's the lowest level of severity logs to display on the console? Default is LogLevel.Info.
- `static void Log.Diag(string text)` — Writes a formatted line to the log using a LogLevel.Diagnostic severity level!
  - `text` — Formatted text with color tags! See the Log class docs for guidance on color tags.
  - Example: see `Log.Diag` in StereoKit-docs-reference.md
- `static void Log.Err(string text)` — Writes a formatted line to the log using a LogLevel.Error severity level!
  - `text` — Formatted text with color tags! See the Log class docs for guidance on color tags.
  - Example: see `Log.Err` in StereoKit-docs-reference.md
- `static void Log.Info(string text)` — Writes a formatted line to the log using a LogLevel.Info severity level!
  - `text` — Formatted text with color tags! See the Log class docs for guidance on color tags.
  - Example: see `Log.Info` in StereoKit-docs-reference.md
- `static void Log.Subscribe(LogCallback onLog)` — Allows you to listen in on log events! Any callback subscribed here will be called when something is logged. This does honor the Log.Filter, so filtered logs will not be received here.
  - `onLog` — The function to call when a log event occurs.
  - Example: see `Log.Subscribe` in StereoKit-docs-reference.md
- `static void Log.Unsubscribe(LogCallback onLog)` — If you subscribed to the log callback, you can unsubscribe that callback here!
  - `onLog` — The subscribed callback to remove.
  - Example: see `Log.Unsubscribe` in StereoKit-docs-reference.md
- `static void Log.Warn(string text)` — Writes a formatted line to the log using a LogLevel.Warn severity level!
  - `text` — Formatted text with color tags! See the Log class docs for guidance on color tags.
  - Example: see `Log.Warn` in StereoKit-docs-reference.md
- `static void Log.Write(LogLevel level, string text)` — Writes a formatted line to the log with the specified severity level!
  - `level` — Severity level of this log message.
  - `text` — Formatted text with color tags! See the Log class docs for guidance on color tags.
  - Example: see `Log.Write` in StereoKit-docs-reference.md

## delegate LogCallback

A callback for when log events occur.

## enum LogColors

The log tool will write to the console with annotations for console colors, which helps with readability, but isn't always supported. These are the options available for configuring those colors.

- `LogColors.Ansi` — Use console coloring annotations.
- `LogColors.None` — Scrape out any color annotations, so logs are all completely plain text.

## enum LogLevel

Severity of a log item.

- `LogLevel.Diagnostic` — This is for diagnostic information, where you need to know details about what -exactly- is going on in the system. This info doesn't surface by default.
- `LogLevel.Error` — Danger Will Robinson! Something really bad just happened and needs fixing!
- `LogLevel.Info` — This is non-critical information, just to let you know what's going on.
- `LogLevel.None` — A default log level that indicates it has not yet been set.
- `LogLevel.Warning` — Something bad has happened, but it's still within the realm of what's expected.

## class Material

A Material describes the surface of anything drawn on the graphics card! It is typically composed of a Shader, and shader properties like colors, textures, transparency info, etc. Items drawn with the same Material can be batched together into a single, fast operation on the graphics card, so re-using materials can be extremely beneficial for performance!

- `Material Material.Chain` — Allows you to chain Materials together in a form of multi-pass rendering! Any time the Material is used, the chained Materials will also be used to draw the same item.
- `bool Material.DepthClamp` — Should depth values be clamped to the near/far planes instead of being clipped? This defaults to false, meaning depth clipping is enabled. Setting this to true can be useful for shadow map rendering, where near/far clip planes are really critical, and out of clip objects are still useful to have.
- `DepthTest Material.DepthTest` — How does this material interact with the ZBuffer? Generally DepthTest.Less would be normal behavior: don't draw objects that are occluded. But this can also be used to achieve some interesting effects, like you could use DepthTest.Greater to draw a glow that indicates an object is behind something.
- `bool Material.DepthWrite` — Should this material write to the ZBuffer? For opaque objects, this generally should be true. But transparent objects writing to the ZBuffer can be problematic and cause draw order issues. Note that turning this off can mean that this material won't get properly accounted for when the MR system is performing late stage reprojection. Not writing to the buffer can also be faster! :)
- `Cull Material.FaceCull` — How should this material cull faces?
- `string Material.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `int Material.ParamCount` — The number of shader parameters available to this material, includes global shader variables as well as textures.
- `int Material.QueueOffset` — This property will force this material to draw earlier or later in the draw queue. Positive values make it draw later, negative makes it earlier. This is really helpful when doing tricks with the depth buffer, or are working with transparent objects. Good offset values should probably be specific, well managed, and small. Think of it as a layer rather than a distance, so probably less than 10, and definitely less than 1000. This can also be helpful for tweaking performance! If you know an object is always going to be close to the user and likely to obscure lots of objects (like hands), drawing it earlier can mean objects behind it get discarded much faster! Similarly, objects that are far away (skybox!) can be pushed towards the back of the queue, so they're more likely to be discarded early.
- `Shader Material.Shader` — Gets a link to the Shader that the Material is currently using, or overrides the Shader this material uses.
- `Transparency Material.Transparency` — What type of transparency does this Material use? Default is None. Transparency has an impact on performance, and draw order. Check the Transparency enum for details.
- `bool Material.Wireframe` — Should this material draw only the edges/wires of the mesh? This can be useful for debugging, and even some kinds of visualization work. Note that this may not work on some mobile OpenGL systems like Quest.
- `static Material Material.Default` — The default material! This is used by many models and meshes rendered from within StereoKit. Its shader is tuned for high performance, and may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default material, here's where you do it!
- `static Material Material.PBR` — The default Physically Based Rendering material! This is used by StereoKit anytime a mesh or model has metallic or roughness properties, or needs to look more realistic. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default PBR behavior, here's where you do it! Note that the shader used by default here is much more costly than Default.Material.
- `static Material Material.PBRClip` — Same as MaterialPBR, but it uses a discard clip for transparency.
- `static Material Material.UI` — The material used by the UI! By default, it uses a shader that creates a 'finger shadow' that shows how close the finger is to the UI.
- `static Material Material.UIBox` — A material for indicating interaction volumes! It renders a border around the edges of the UV coordinates that will 'grow' on proximity to the user's finger. It will discard pixels outside of that border, but will also show the finger shadow. This is meant to be an opaque material, so it works well for depth LSR. This material works best on cube-like meshes where each face has UV coordinates from 0-1. Shader Parameters: ``` color                - color border_size          - meters border_size_grow     - meters border_affect_radius - meters ```
- `static Material Material.UIQuadrant` — The material used by the UI for Quadrant Sized UI elements. See UI.QuadrantSizeMesh for additional details. By default, it uses a shader that creates a 'finger shadow' that shows how close the finger is to the UI.
- `static Material Material.Unlit` — The default unlit material! This is used by StereoKit any time a mesh or model needs to be rendered with an unlit surface. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default unlit behavior, here's where you do it!
- `static Material Material.UnlitClip` — The default unlit material with alpha clipping! This is used by StereoKit for unlit content with transparency, where completely transparent pixels are discarded. This means less alpha blending, and fewer visible alpha blending issues! In particular, this is how Sprites are drawn. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default unlit clipped behavior, here's where you do it!
- `void Material(Shader shader)` — Creates a material from a shader, and uses the shader's default settings. If the shader is null, a warning will be added to the log, and this Material will default to using an Unlit shader. Uses an auto-generated id.
  - `shader` — Any valid shader, null is okay, but will log a warning and default to Unlit.
- `void Material(string shaderFilename)` — Loads a Shader asset and creates a Material using it. If the shader fails to load, a warning will be added to the log, and this Material will default to using an Unlit shader. Uses an auto-generated id.
  - `shaderFilename` — The filename of a Shader asset. If the file is not present, the Shader will default to Unlit.
- `void Material(string id, string shaderFilename)` — Loads a Shader asset and creates a Material using it. If the shader fails to load, a warning will be added to the log, and this Material will default to using an Unlit shader. Uses an auto-generated id.
  - `id` — Set the material's id to this.
  - `shaderFilename` — The filename of a Shader asset. If the file is not present, the Shader will default to Unlit.
- `void Material(string id, Shader shader)` — Creates a material from a shader, and uses the shader's default settings. If the shader is null, a warning will be added to the log, and this Material will default to using an Unlit shader.
  - `id` — Set the material's id to this.
  - `shader` — Any valid shader, null is okay, but will log a warning and default to Unlit.
- `Material Material.Copy()` — Creates a new Material asset with the same shader and properties! Draw calls with the new Material will not batch together with this one.
  - returns — A new Material asset with the same shader and properties.
- `static Material Material.Copy(string materialId)` — Creates a new Material asset with the same shader and properties! Draw calls with the new Material will not batch together with the source Material.
  - `materialId` — Which Material are you looking for?
  - returns — A new Material asset with the same shader and properties. Returns null if no materials are found with the given id.
  - Example: see `Material.Copy` in StereoKit-docs-reference.md
- `static Material Material.Find(string materialId)` — Looks for a Material asset that's already loaded, matching the given id!
  - `materialId` — Which Material are you looking for?
  - returns — A link to the Material matching 'id', null if none is found.
- `IEnumerable`1 Material.GetAllParamInfo()` — Gets an enumerable list of all parameter information on the Material. This includes all global shader variables and textures.
  - returns — A pretty standard IEnumarable of MatParamInfo that can be used with foreach.
  - Example: see `Material.GetAllParamInfo` in StereoKit-docs-reference.md
- `bool Material.GetBool(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of 'false' will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise false.
- `Color Material.GetColor(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Color.White will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise Color.White.
- `float Material.GetFloat(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of '0' will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise 0.
- `int Material.GetInt(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of '0' will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise 0.
- `Matrix Material.GetMatrix(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Matrix.Identity will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise Matrix.Identity.
- `MatParamInfo Material.GetParamInfo(int index)` — Gets available shader parameter information for the parameter at the indicated index. Parameters are listed as variables first, then textures.
  - `index` — Index of the shader parameter, bounded by ParamCount.
  - returns — A structure that contains all the available information about the parameter.
  - Example: see `Material.GetParamInfo` in StereoKit-docs-reference.md
- `Tex Material.GetTexture(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of null will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise null.
- `uint Material.GetUInt(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of '0' will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise 0.
- `Material Material.GetVariant(int variantIndex)` — This retreives the variant assigned to the specified variant index. Null is the default value for variants, and it's not valid to ask for variant 0 (already the current Material).
  - `variantIndex` — The variant to retreive. 0 is already the current material, and an invalid index here. SK has a max of 4 total variants, including the default.
  - returns — The Material variant, or null.
- `Vec2 Material.GetVector2(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Vec2.Zero will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise Vec2.Zero.
- `Vec3 Material.GetVector3(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Vec3.Zero will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise Vec3.Zero.
- `Vec4 Material.GetVector4(string name)` — Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Vec4.Zero will be returned.
  - `name` — Name of the shader parameter.
  - returns — The parameter's value, if present, otherwise Vec4.Zero.
- `void Material.SetBool(string name, bool value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.
  - Example: see `Material.SetBool` in StereoKit-docs-reference.md
- `void Material.SetColor(string name, Color32 colorGamma)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `colorGamma` — The gamma space color for the shader to use.
- `void Material.SetColor(string name, Color colorGamma)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `colorGamma` — The gamma space color for the shader to use.
- `bool Material.SetConstant(string name, MaterialBuffer`1 buffer)` — Sets a constant/uniform buffer (cbuffer) on the shader. This is for smaller chunks of data (16kb max) that can be read from faster than textures or StructuredBuffers.
  - `name` — Name of the shader parameter in the HLSL.
  - `buffer` — The buffer to assign, or null to clear.
  - returns — True if a matching resource was found in the shader.
- `void Material.SetData(string name, T& serializableData)` — This allows you to set more complex shader data types such as structs. Note the SK doesn't guard against setting data of the wrong size here, so pay extra attention to the size of your data here, and ensure it matched up with the shader!
  - `name` — Name of the shader parameter.
  - `serializableData` — New value for the parameter.
  - Example: see `Material.SetData` in StereoKit-docs-reference.md
- `void Material.SetFloat(string name, float value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.
  - Example: see `Material.SetFloat` in StereoKit-docs-reference.md
- `void Material.SetInt(string name, int value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.
- `void Material.SetInt(string name, int value1, int value2)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value1` — New value for the parameter.
  - `value2` — New value for the parameter.
- `void Material.SetInt(string name, int value1, int value2, int value3)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value1` — New value for the parameter.
  - `value2` — New value for the parameter.
  - `value3` — New value for the parameter.
- `void Material.SetInt(string name, int value1, int value2, int value3, int value4)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value1` — New value for the parameter.
  - `value2` — New value for the parameter.
  - `value3` — New value for the parameter.
  - `value4` — New value for the parameter.
  - Example: see `Material.SetInt` in StereoKit-docs-reference.md
- `void Material.SetMatrix(string name, Matrix value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.
- `bool Material.SetStorage(string name, ComputeBuffer`1 buffer)` — Sets a RW/StructuredBuffer or ByteAddressBuffer on the shader. This is used to provide BIG arrays of data to the GPU, for both reading and writing! These perform very similarly to textures, and can be thought of as big textures of just data!
  - `name` — Name of the shader parameter in the HLSL.
  - `buffer` — The buffer to assign, or null to clear.
  - returns — True if a matching resource was found in the shader.
- `void Material.SetTexture(string name, Tex value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.
- `void Material.SetUInt(string name, uint value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.
- `void Material.SetUInt(string name, uint value1, uint value2)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value1` — New value for the parameter.
  - `value2` — New value for the parameter.
- `void Material.SetUInt(string name, uint value1, uint value2, uint value3)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value1` — New value for the parameter.
  - `value2` — New value for the parameter.
  - `value3` — New value for the parameter.
- `void Material.SetUInt(string name, uint value1, uint value2, uint value3, uint value4)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value1` — New value for the parameter.
  - `value2` — New value for the parameter.
  - `value3` — New value for the parameter.
  - `value4` — New value for the parameter.
  - Example: see `Material.SetUInt` in StereoKit-docs-reference.md
- `void Material.SetVariant(int variantIndex, Material variantMaterial)` — Variants are used by special effects when a manual render pass selects a variant to use for the whole pass! Variants default to null, and null variants are not drawn. For example, a shadow map render pass might use variant 1, and sets it to a simplified Material that skips textures and only does positional vertex transforms.
  - `variantIndex` — Which variant index should we set? 0 is reserved for the primary material, and SK has a max of 4 total variants, including the default.
  - `variantMaterial` — The Material to use for the variant. Sub-variants are ignored, and a null variant means nothing will be drawn when using the variant.
- `void Material.SetVector(string name, Vec4 value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.
- `void Material.SetVector(string name, Vec3 value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.
- `void Material.SetVector(string name, Vec2 value)` — Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
  - `name` — Name of the shader parameter.
  - `value` — New value for the parameter.

## class MaterialBuffer

This is a chunk of memory that will get bound to all shaders at a particular register slot. StereoKit uses this to provide engine values to the shader, and you can also use this to drive graphical shader systems of your own! For example, if your application has a custom lighting system, fog, wind, or some other system that multiple shaders might need to refer to, this is the perfect tool to use. The type 'T' for this buffer must be a struct that uses the `[StructLayout(LayoutKind.Sequential)]` attribute for proper copying. It should also match the layout of your equivalent cbuffer in the shader file. Note that shaders often have [specific byte alignment](https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-packing-rules) requirements! Example: C# ```csharp [StructLayout(LayoutKind.Sequential)] struct BufferData { Vec3  windDirection; float windStrength } ``` HLSL ```c cbuffer BufferData : register(b3) { float3 windDirection; float  windStrength; } ```

- `string MaterialBuffer.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `void MaterialBuffer(int registerSlot)` — Create a new global MaterialBuffer bound to the register slot id. All shaders will have access to the data provided via this instance's `Set`.
  - `registerSlot` — Valid values are 3-16. This is the register id that this data will be bound to. In HLSL, you'll see the slot id for '3' indicated like this `: register(b3)`
- `void MaterialBuffer()` — Create a new global MaterialBuffer that can be bound to a register slot id via Renderer.SetGlobalBuffer. All shaders will have access to the data provided via this instance's `Set`.
- `void MaterialBuffer.Set(T& data)` — This will upload your data to the GPU for shaders to use.
  - `data` — The data you wish to upload to the GPU.

## enum MaterialParam

What type of data does this material parameter need? This is used to tell the shader how large the data is, and where to attach it to on the shader.

- `MaterialParam.Buffer` — A structured buffer resource, such as StructuredBuffer<T> or RWStructuredBuffer<T> in HLSL.
- `MaterialParam.Color128` — A color value described by 4 floating point values. Memory-wise this is the same as a Vector4, but in the shader this variable has a ':color' tag applied to it using StereoKits's shader info syntax, indicating it's a color value. Color values for shaders should be in linear space, not gamma.
- `MaterialParam.Float` — A single 32 bit float value.
- `MaterialParam.Int` — A 1 component vector composed of signed integers.
- `MaterialParam.Int2` — A 2 component vector composed of signed integers.
- `MaterialParam.Int3` — A 3 component vector composed of signed integers.
- `MaterialParam.Int4` — A 4 component vector composed of signed integers.
- `MaterialParam.Matrix` — A 4x4 matrix of floats.
- `MaterialParam.Texture` — Texture information!
- `MaterialParam.UInt` — A 1 component vector composed of unsigned integers. This may also be a boolean.
- `MaterialParam.UInt2` — A 2 component vector composed of unsigned integers.
- `MaterialParam.UInt3` — A 3 component vector composed of unsigned integers.
- `MaterialParam.UInt4` — A 4 component vector composed of unsigned integers.
- `MaterialParam.Unknown` — This data type is not currently recognized. Please report your case on GitHub Issues!
- `MaterialParam.Vector2` — A 2 component vector composed of floating point values.
- `MaterialParam.Vector3` — A 3 component vector composed of floating point values.
- `MaterialParam.Vector4` — A 4 component vector composed of floating point values.

## struct MatParamInfo

Information and details about the shader parameters available on a Material. Currently only the text name and data type of the parameter are surfaced here. This contains textures as well as global constant buffer variables.

- `string MatParamInfo.name` — The name of the shader parameter, as provided inside of the shader file itself. These are the 'global' variables defined in the shader, as well as textures. The shader compiler will output a list of parameter names when compiling, so check the output window after building if you're uncertain what you'll find. See `MatParamName` for a list of "standardized" parameter names.
- `MaterialParam MatParamInfo.type` — This is the data type that StereoKit recognizes the parameter to be.

## enum MatParamName

A better way to access standard shader parameter names, instead of using just strings! If you have your own custom parameters, you can still access them via the string methods, but this is checked and verified by the compiler!

- `MatParamName.ClipCutoff` — In clip shaders, this is the cutoff value below which pixels are discarded. Typically, the diffuse/albedo's alpha component is sampled for comparison here. This represents the float param 'cutoff'.
- `MatParamName.ColorTint` — A per-material color tint, behavior could vary from shader to shader, but often this is just multiplied against the diffuse texture right at the start. This represents the Color param 'color'.
- `MatParamName.DiffuseTex` — The primary color texture for the shader! Diffuse, Albedo, 'The Texture', or whatever you want to call it, this is usually the base color that the shader works with. This represents the texture param 'diffuse'.
- `MatParamName.EmissionFactor` — A multiplier for emission values sampled from the emission texture. The default emission texture in SK shaders is white, and the default value for this parameter is 0,0,0,0. This represents the Color param 'emission_factor'.
- `MatParamName.EmissionTex` — This texture is unaffected by lighting, and is frequently just added in on top of the material's final color! Tends to look really glowy. This represents the texture param 'emission'.
- `MatParamName.MetallicAmount` — For physically based shader, this is a multiplier to scale the metallic properties of the material. This represents the float param 'metallic'.
- `MatParamName.MetalTex` — For physically based shaders, metal is a texture that encodes metallic and roughness data into the 'B' and 'G' channels, respectively. This represents the texture param 'metal'.
- `MatParamName.NormalTex` — The 'normal map' texture for the material! This texture contains information about the direction of the material's surface, which is used to calculate lighting, and make surfaces look like they have more detail than they actually do. Normals are in Tangent Coordinate Space, and the RGB values map to XYZ values. This represents the texture param 'normal'.
- `MatParamName.OcclusionTex` — Used by physically based shaders, this can be used for baked ambient occlusion lighting, or to remove specular reflections from areas that are surrounded by geometry that would likely block reflections. This represents the texture param 'occlusion'.
- `MatParamName.RoughnessAmount` — For physically based shader, this is a multiplier to scale the roughness properties of the material. This represents the float param 'roughness'.
- `MatParamName.TexScale` — Not necessarily present in all shaders, this multiplies the UV coordinates of the mesh, so that the texture will repeat. This is great for tiling textures! This represents the float param 'tex_scale'.
- `MatParamName.TexTransform` — Not necessarily present in all shaders, this transforms the UV coordinates of the mesh, so that the texture can repeat and scroll. XY components are offset, and ZW components are scale. This represents the float param 'tex_trans'.

## struct Matrix

A Matrix in StereoKit is a 4x4 grid of numbers that is used to represent a transformation for any sort of position or vector! This is an oversimplification of what a matrix actually is, but it's accurate in this case. Matrices are really useful for transforms because you can chain together all sorts of transforms into a single Matrix! A Matrix transform really shines when applied to many positions, as the more expensive operations get cached within the matrix values. Multiple matrix transforms can be combined by multiplying them. In StereoKit, to create a matrix that first scales an object, followed by rotating it, and finally translating it you would use this order: `Matrix M = Matrix.S(...) * Matrix.R(...) * Matrix.T(...);` This order is related to the fact that StereoKit uses row-major order to store matrices. Note that in other 3D frameworks and certain 3D math references you may find column-major matrices, which would need the reverse order (i.e. T*R*S), so please keep this in mind when creating transformations. Matrices are prominently used within shaders for mesh transforms!

- `Matrix Matrix.Inverse` — Creates an inverse matrix! If the matrix takes a point from a -> b, then its inverse takes the point from b -> a.
- `Matrix4x4 Matrix.m` — The internal, wrapped System.Numerics type. This can be nice to have around so you can pass its fields as 'ref', which you can't do with properties. You won't often need this, as implicit conversions to System.Numerics types are also provided.
- `Pose Matrix.Pose` — Extracts translation and rotation information from the transform matrix, and makes a Pose from it! Not exactly fast. This is backed by Decompose, so if you need any additional info, it's better to just call Decompose instead.
- `Quat Matrix.Rotation` — A slow function that returns the rotation quaternion embedded in this transform matrix. This is backed by Decompose, so if you need any additional info, it's better to just call Decompose instead.
- `Vec3 Matrix.Scale` — Returns the scale embedded in this transform matrix. Not exactly cheap, requires 3 sqrt calls, but is cheaper than calling Decompose.
- `Vec3 Matrix.Translation` — A fast Property that will return or set the translation component embedded in this transform matrix.
- `Matrix Matrix.Transposed` — Creates a matrix that has been transposed! Transposing is like rotating the matrix 90 clockwise, or turning the rows into columns. This can be useful for inverting orthogonal matrices, or converting matrices for use in a math library that uses different conventions!
- `static Matrix Matrix.Identity` — An identity Matrix is the matrix equivalent of '1'! Transforming anything by this will leave it at the exact same place.
- `void Matrix(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)` — This constructor is for manually creating a matrix from a grid of floats! You'll likely want to use one of the static Matrix functions to create a Matrix instead.
  - `m11` — m11
  - `m12` — m12
  - `m13` — m13
  - `m14` — m14
  - `m21` — m21
  - `m22` — m22
  - `m23` — m23
  - `m24` — m24
  - `m31` — m31
  - `m32` — m32
  - `m33` — m33
  - `m34` — m34
  - `m41` — m41
  - `m42` — m42
  - `m43` — m43
  - `m44` — m44
- `void Matrix(Matrix4x4 matrix)` — Create a Matrix from the equivalent System.Numerics Matrix type. You can also implicitly convert between these types, as this Matrix is backed by the System.Numerics type anyhow.
  - `matrix` — A System.Numerics matrix.
- `bool Matrix.Decompose(Vec3& translation, Quat& rotation, Vec3& scale)` — Returns this transformation matrix to its original translation, rotation and scale components. Not exactly a cheap function. If this is not a transform matrix, there's a chance this call will fail, and return false.
  - `translation` — XYZ translation of the matrix.
  - `rotation` — The rotation quaternion, some lossiness may be encountered when composing/decomposing.
  - `scale` — XYZ scale components.
  - returns — If this is not a transform matrix, there's a chance this call will fail, and return false.
- `void Matrix.Invert()` — Inverts this Matrix! If the matrix takes a point from a -> b, then its inverse takes the point from b -> a.
- `static Matrix Matrix.LookAt(Vec3 from, Vec3 at)` — A transformation that describes one position looking at another point. This is particularly useful for describing camera transforms!
  - `from` — The location the transform is looking from, or the position of the 'camera'.
  - `at` — The location the transform is looking towards, or the subject of the 'camera'.
  - returns — A common camera-like transform matrix.
- `static Matrix Matrix.LookAt(Vec3 from, Vec3 at, Vec3 up)` — A transformation that describes one position looking at another point. This is particularly useful for describing camera transforms!
  - `from` — The location the transform is looking from, or the position of the 'camera'.
  - `at` — The location the transform is looking towards, or the subject of the 'camera'.
  - `up` — This controlls the roll value of the lookat transform, this would be the direction the top of the camera is facing. In most cases, this is just Vec3.Up.
  - returns — A common camera-like transform matrix.
- `static Matrix Matrix.Implicit Conversions(Matrix4x4 m)` — Allows implicit conversion from System.Numerics.Matrix4x4 to StereoKit.Matrix.
  - `m` — Any System.Numerics Matrix4x4.
  - returns — A StereoKit compatible matrix.
- `static Matrix4x4 Matrix.Implicit Conversions(Matrix m)` — Allows implicit conversion from StereoKit.Matrix to System.Numerics.Matrix4x4
  - `m` — Any StereoKit.Matrix.
  - returns — A System.Numerics compatible matrix.
- `static Matrix Matrix.*(Matrix a, Matrix b)` — Multiplies two matrices together! This is a great way to combine transform operations. Note that StereoKit's matrices are row-major, and multiplication order is important! To translate, then scale, multiply in order of 'translate * scale'.
  - `a` — First Matrix.
  - `b` — Second Matrix.
  - returns — Result of matrix multiplication.
- `static Vec3 Matrix.*(Matrix a, Vec3 b)` — Multiplies the vector by the Matrix! Since only a 1x4 vector can be multiplied against a 4x4 matrix, this uses '1' for the 4th element, so the result will also include translation! To exclude translation, use `Matrix.TransformNormal`.
  - `a` — A transform matrix.
  - `b` — Any Vector.
  - returns — The Vec3 transformed by the matrix, including translation.
- `static Ray Matrix.*(Matrix a, Ray b)` — Transforms a Ray by the Matrix! The position and direction are both multiplied by the matrix, accounting properly for which should include translation, and which should not.
  - `a` — A transform matrix.
  - `b` — A Ray to be transformed.
  - returns — A Ray transformed by the Matrix.
- `static Pose Matrix.*(Matrix a, Pose b)` — Transforms a Pose by the Matrix! The position and orientation are both transformed by the matrix, accounting properly for the Pose's quaternion.
  - `a` — A transform matrix.
  - `b` — A Pose to be transformed.
  - returns — A Ray transformed by the Matrix.
- `static Matrix Matrix.Orthographic(float width, float height, float nearClip, float farClip)` — This creates a matrix used for projecting 3D geometry onto a 2D surface for rasterization. Orthographic projection matrices will preserve parallel lines. This is great for 2D scenes or content.
  - `width` — The width, in meters, of the area that will be projected.
  - `height` — The height, in meters, of the area that will be projected.
  - `nearClip` — Anything closer than this distance (in meters) will be discarded. Must not be zero, and if you make this too small, you may experience glitching in your depth buffer.
  - `farClip` — Anything further than this distance (in meters) will be discarded. For low resolution depth buffers, this should not be too far away, or you'll see bad z-fighting artifacts.
  - returns — The final orthographic matrix.
- `static Matrix Matrix.Perspective(float fovDegrees, float aspectRatio, float nearClip, float farClip)` — This creates a matrix used for projecting 3D geometry onto a 2D surface for rasterization. Perspective projection matrices will cause parallel lines to converge at the horizon. This is great for normal looking content.
  - `fovDegrees` — This is the vertical field of view of the perspective matrix, units are in degrees.
  - `aspectRatio` — The projection surface's width/height.
  - `nearClip` — Anything closer than this distance (in meters) will be discarded. Must not be zero, and if you make this too small, you may experience glitching in your depth buffer.
  - `farClip` — Anything further than this distance (in meters) will be discarded. For low resolution depth buffers, this should not be too far away, or you'll see bad z-fighting artifacts.
  - returns — The final perspective matrix.
- `static Matrix Matrix.Perspective(Vec2 imageResolution, Vec2 focalLengthPx, float nearClip, float farClip)` — This creates a matrix used for projecting 3D geometry onto a 2D surface for rasterization. With the known camera intrinsics, you can replicate its perspective!
  - `imageResolution` — The resolution of the image. This should be the image's width and height in pixels.
  - `focalLengthPx` — The focal length of camera in pixels, with image coordinates +X (pointing right) and +Y (pointing up).
  - `nearClip` — Anything closer than this distance (in meters) will be discarded. Must not be zero, and if you make this too small, you may experience glitching in your depth buffer.
  - `farClip` — Anything further than this distance (in meters) will be discarded. For low resolution depth buffers, this should not be too far away, or you'll see bad z-fighting artifacts.
  - returns — The final perspective matrix.
- `static Matrix Matrix.Perspective(Vec2 imageResolution, Vec2 focalLengthPx, Vec2 principalPointPx, float nearClip, float farClip)` — This creates a matrix used for projecting 3D geometry onto a 2D surface for rasterization. With the known camera intrinsics, you can replicate its perspective!
  - `imageResolution` — The resolution of the image. This should be the image's width and height in pixels.
  - `focalLengthPx` — The focal length of the camera in pixels, with image coordinates +X (pointing right) and +Y (pointing up).
  - `principalPointPx` — The principal point of the camera in pixels, with image coordinates +X (pointing right) and +Y (pointing up).
  - `nearClip` — Anything closer than this distance (in meters) will be discarded. Must not be zero, and if you make this too small, you may experience glitching in your depth buffer.
  - `farClip` — Anything further than this distance (in meters) will be discarded. For low resolution depth buffers, this should not be too far away, or you'll see bad z-fighting artifacts.
  - returns — The final perspective matrix.
- `static Matrix Matrix.R(Quat rotation)` — Create a rotation matrix from a Quaternion.
  - `rotation` — A Quaternion describing the rotation for this transform.
  - returns — A Matrix that will rotate by the provided Quaternion orientation.
- `static Matrix Matrix.R(float pitchXDeg, float yawYDeg, float rollZDeg)` — Create a rotation matrix from pitch, yaw, and roll information. Units are in degrees.
  - `pitchXDeg` — Pitch, or rotation around the X axis, in degrees.
  - `yawYDeg` — Yaw, or rotation around the Y axis, in degrees.
  - `rollZDeg` — Roll, or rotation around the Z axis, in degrees.
  - returns — A Matrix that will rotate by the provided pitch, yaw and roll.
- `static Matrix Matrix.R(Vec3 pitchYawRollDeg)` — Create a rotation matrix from pitch, yaw, and roll information. Units are in degrees.
  - `pitchYawRollDeg` — Pitch (x-axis), yaw (y-axis), and roll (z-axis) stored as x, y and z respectively in this Vec3. Units are in degrees.
  - returns — A Matrix that will rotate by the provided pitch, yaw and roll.
- `static Matrix Matrix.S(Vec3 scale)` — Creates a scaling Matrix, where scale can be different on each axis (non-uniform).
  - `scale` — How much larger or smaller this transform makes things. Vec3.One is a good default, as Vec3.Zero will shrink it to nothing!
  - returns — A non-uniform scaling matrix.
- `static Matrix Matrix.S(float x, float y, float z)` — Creates a scaling Matrix, where scale can be different on each axis (non-uniform).
  - `x` — How much larger or smaller this transform makes things. 1 is a good default, as 0 will shrink it to nothing!
  - returns — A non-uniform scaling matrix.
- `static Matrix Matrix.S(float scale)` — Creates a scaling Matrix, where the scale is the same on each axis (uniform).
  - `scale` — How much larger or smaller this transform makes things. 1 is a good default, as 0 will shrink it to nothing! This will expand to a scale vector of (size, size, size)
  - returns — A uniform scaling matrix.
- `static Matrix Matrix.T(Vec3 translation)` — Translate. Creates a translation Matrix!
  - `translation` — Move an object by this amount.
  - returns — A Matrix containing a simple translation!
- `static Matrix Matrix.T(float x, float y, float z)` — Translate. Creates a translation Matrix!
  - `x` — Move an object on the x axis by this amount.
  - `y` — Move an object on the y axis by this amount.
  - `z` — Move an object on the z axis by this amount.
  - returns — A Matrix containing a simple translation!
- `static Matrix Matrix.TR(Vec3 translation, Quat rotation)` — Translate, Rotate. Creates a transform Matrix using these components!
  - `translation` — Move an object by this amount.
  - `rotation` — A Quaternion describing the rotation for this transform.
  - returns — A Matrix that combines translation and rotation information into a single Matrix!
- `static Matrix Matrix.TR(float x, float y, float z, Quat rotation)` — Translate, Rotate. Creates a transform Matrix using these components!
  - `x` — Move an object on the x axis by this amount.
  - `y` — Move an object on the y axis by this amount.
  - `z` — Move an object on the z axis by this amount.
  - `rotation` — A Quaternion describing the rotation for this transform.
  - returns — A Matrix that combines translation and rotation information into a single Matrix!
- `static Matrix Matrix.TR(Vec3 translation, Vec3 pitchYawRollDeg)` — Translate, Rotate. Creates a transform Matrix using these components!
  - `translation` — Move an object by this amount.
  - `pitchYawRollDeg` — Pitch (x-axis), yaw (y-axis), and roll (z-axis) stored as x, y and z respectively in this Vec3. Units are in degrees.
  - returns — A Matrix that combines translation and rotation information into a single Matrix!
- `static Matrix Matrix.TR(float x, float y, float z, Vec3 pitchYawRollDeg)` — Translate, Rotate. Creates a transform Matrix using these components!
  - `x` — Move an object on the x axis by this amount.
  - `y` — Move an object on the y axis by this amount.
  - `z` — Move an object on the z axis by this amount.
  - `pitchYawRollDeg` — Pitch (x-axis), yaw (y-axis), and roll (z-axis) stored as x, y and z respectively in this Vec3. Units are in degrees.
  - returns — A Matrix that combines translation and rotation information into a single Matrix!
- `Vec3 Matrix.Transform(Vec3 point)` — Transforms a point through the Matrix! This is basically just multiplying a vector (x,y,z,1) with the Matrix.
  - `point` — The point to transform.
  - returns — The point transformed by the Matrix.
- `Ray Matrix.Transform(Ray ray)` — Shorthand to transform a ray though the Matrix! This properly transforms the position with the point transform method, and the direction with the direction transform method. Does not normalize, nor does it preserve a normalized direction if the Matrix contains scale data.
  - `ray` — A ray you wish to transform from one space to another.
  - returns — The transformed ray!
- `Pose Matrix.Transform(Pose pose)` — Shorthand for transforming a Pose! This will transform the position of the Pose with the matrix, extract a rotation Quat from the matrix and apply that to the Pose's orientation. Note that extracting a rotation Quat is an expensive operation, so if you're doing it more than once, you should cache the rotation Quat and do this transform manually.
  - `pose` — The original pose.
  - returns — The transformed pose.
- `Vec3 Matrix.TransformNormal(Vec3 normal)` — Transforms a point through the Matrix, but excluding translation! This is great for transforming vectors that are -directions- rather than points in space. Use this to transform normals and directions. The same as multiplying (x,y,z,0) with the Matrix.
  - `normal` — The direction to transform.
  - returns — The direction transformed by the Matrix.
- `void Matrix.Transpose()` — Transposes this Matrix! Transposing is like rotating the matrix 90 clockwise, or turning the rows into columns. This can be useful for inverting orthogonal matrices, or converting matrices for use in a math library that uses different conventions!
- `static Matrix Matrix.TRS(Vec3 translation, Quat rotation, float scale)` — Translate, Rotate, Scale. Creates a transform Matrix using all these components!
  - `translation` — Move an object by this amount.
  - `rotation` — A Quaternion describing the rotation for this transform.
  - `scale` — How much larger or smaller this transform makes things. 1 is a good default, as 0 will shrink it to nothing! This will expand to a scale vector of (size, size, size)
  - returns — A Matrix that combines translation, rotation, and scale information into a single Matrix!
- `static Matrix Matrix.TRS(Vec3 translation, Quat rotation, Vec3 scale)` — Translate, Rotate, Scale. Creates a transform Matrix using all these components!
  - `translation` — Move an object by this amount.
  - `rotation` — A Quaternion describing the rotation for this transform.
  - `scale` — How much larger or smaller this transform makes things. Vec3.One is a good default, as Vec3.Zero will shrink it to nothing!
  - returns — A Matrix that combines translation, rotation, and scale information into a single Matrix!
- `static Matrix Matrix.TRS(Vec3 translation, Vec3 pitchYawRollDeg, float scale)` — Translate, Rotate, Scale. Creates a transform Matrix using all these components!
  - `translation` — Move an object by this amount.
  - `pitchYawRollDeg` — Pitch (x-axis), yaw (y-axis), and roll (z-axis) stored as x, y and z respectively in this Vec3. Units are in degrees.
  - `scale` — How much larger or smaller this transform makes things. Vec3.One is a good default, as Vec3.Zero will shrink it to nothing!
  - returns — A Matrix that combines translation, rotation, and scale information into a single Matrix!
- `static Matrix Matrix.TRS(Vec3 translation, Vec3 pitchYawRollDeg, Vec3 scale)` — Translate, Rotate, Scale. Creates a transform Matrix using all these components!
  - `translation` — Move an object by this amount.
  - `pitchYawRollDeg` — Pitch (x-axis), yaw (y-axis), and roll (z-axis) stored as x, y and z respectively in this Vec3. Units are in degrees.
  - `scale` — How much larger or smaller this transform makes things. Vec3.One is a good default, as Vec3.Zero will shrink it to nothing!
  - returns — A Matrix that combines translation, rotation, and scale information into a single Matrix!
- `static Matrix Matrix.TS(Vec3 translation, float scale)` — Translate, Scale. Creates a transform Matrix using both these components!
  - `translation` — Move an object by this amount.
  - `scale` — How much larger or smaller this transform makes things. 1 is a good default, as 0 will shrink it to nothing! This will expand to a scale vector of (size, size, size)
  - returns — A Matrix that combines translation and scale information into a single Matrix!
- `static Matrix Matrix.TS(Vec3 translation, Vec3 scale)` — Translate, Scale. Creates a transform Matrix using both these components!
  - `translation` — Move an object by this amount.
  - `scale` — How much larger or smaller this transform makes things. Vec3.One is a good default, as Vec3.Zero will shrink it to nothing!
  - returns — A Matrix that combines translation and scale information into a single Matrix!
- `static Matrix Matrix.TS(float x, float y, float z, float scale)` — Translate, Scale. Creates a transform Matrix using both these components!
  - `x` — Move an object on the x axis by this amount.
  - `y` — Move an object on the y axis by this amount.
  - `z` — Move an object on the z axis by this amount.
  - `scale` — How much larger or smaller this transform makes things. Vec3.One is a good default, as Vec3.Zero will shrink it to nothing!
  - returns — A Matrix that combines translation and scale information into a single Matrix!
- `static Matrix Matrix.TS(float x, float y, float z, Vec3 scale)` — Translate, Scale. Creates a transform Matrix using both these components!
  - `x` — Move an object on the x axis by this amount.
  - `y` — Move an object on the y axis by this amount.
  - `z` — Move an object on the z axis by this amount.
  - `scale` — How much larger or smaller this transform makes things. Vec3.One is a good default, as Vec3.Zero will shrink it to nothing!
  - returns — A Matrix that combines translation and scale information into a single Matrix!

## enum Memory

For performance sensitive areas, or places dealing with large chunks of memory, it can be faster to get a reference to that memory rather than copying it! However, if this isn't explicitly stated, it isn't necessarily clear what's happening. So this enum allows us to visibly specify what type of memory reference is occurring.

- `Memory.Copy` — This memory is now _yours_ and you must free it yourself! Memory has been allocated, and the data has been copied over to it. Pricey! But safe.
- `Memory.Reference` — The chunk of memory involved here is a reference that is still managed or used by StereoKit! You should _not_ free it, and be extremely cautious about modifying it.

## class Mesh

A Mesh is a single collection of triangular faces with extra surface information to enhance rendering! StereoKit meshes are composed of a list of vertices, and a list of indices to connect the vertices into faces. Nothing more than that is stored here, so typically meshes are combined with Materials, or added to Models in order to draw them. Mesh vertices are composed of a position, a normal (direction of the vert), a uv coordinate (for mapping a texture to the mesh's surface), and a 32 bit color containing red, green, blue, and alpha (transparency). Mesh indices are stored as unsigned ints, so you can have a mesh with a fudgeton of verts! 4 billion or so :)

- `AssetState Mesh.AssetState` — This tells you the current state of the Mesh asset. A Mesh starts in the None state, transitions to LoadedMeta when bounds are available (async path), and Loaded once GPU upload completes.
- `Bounds Mesh.Bounds` — This is a bounding box that encapsulates the Mesh! It's used for collision, visibility testing, UI layout, and probably other things. While it's normally calculated from the mesh vertices, you can also override this to suit your needs.
- `bool Mesh.HasSkin` — Indicates whether this Mesh has CPU skinning data attached. A Mesh gains skin data when SetSkin is called, or when it's loaded from a skinned glTF.
- `string Mesh.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `int Mesh.IndCount` — The number of indices stored in this Mesh! This is available to you regardless of whether or not KeepData is set.
- `bool Mesh.KeepData` — Should StereoKit keep the mesh data on the CPU for later access, or collision detection? Defaults to true. If you set this to false before setting data, the data won't be stored. If you call this after setting data, that stored data will be freed! If you set this to true again later on, it will not contain data until it's set again.
- `int Mesh.VertCount` — The number of vertices stored in this Mesh! This is available to you regardless of whether or not KeepData is set.
- `static Mesh Mesh.Cube` — A cube with dimensions of (1,1,1), this is equivalent to Mesh.GenerateCube(Vec3.One).
- `static Mesh Mesh.Quad` — A default quad mesh, 2 triangles, 4 verts, from (-0.5,-0.5,0) to (0.5,0.5,0) and facing forward on the Z axis (0,0,-1). White vertex colors, and UVs from (1,1) at vertex (-0.5,-0.5,0) to (0,0) at vertex (0.5,0.5,0).
- `static Mesh Mesh.Sphere` — A sphere mesh with a diameter of 1. This is equivalent to Mesh.GenerateSphere(1,4).
- `void Mesh()` — Creates an empty Mesh asset. Use SetVerts and SetInds to add data to it!
- `void Mesh(Vertex[] vertices, UInt32[] indices, MeshData flags, int priority)` — Creates a Mesh asset and sets its vertex and index data with control over upload behavior. This is a shorthand for creating a Mesh and calling SetData on it.
  - `vertices` — An array of vertices for the mesh. Null is okay here, but may require a special shader.
  - `indices` — A list of face indices, must be a multiple of 3.
  - `flags` — Flags controlling upload behavior. See MeshData for options.
  - `priority` — Loading priority for async upload. Lower values load sooner.
- `Mesh Mesh.Copy()` — Creates an independent duplicate of this Mesh. Vertices, indices, bounds, and (if present) skin data are copied; the new Mesh has its own GPU buffers and shares no state with the source. This is useful when one source mesh is shared across N animated entities: UpdateSkin mutates the target mesh's vertex buffer in place, so each entity needs its own Mesh instance to deform independently. The source Mesh must have KeepData set to true.
  - returns — A new Mesh that shares no GPU state with this one.
- `void Mesh.Draw(Material material, Matrix transform, Color colorLinear, RenderLayer layer)` — Adds a mesh to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `material` — A Material to apply to the Mesh.
  - `transform` — A Matrix that will transform the mesh from Model Space into the current Hierarchy Space.
  - `colorLinear` — A per-instance linear space color value to pass into the shader! Normally this gets used like a material tint. If you're  adventurous and don't need per-instance colors, this is a great spot to pack in extra per-instance data for the shader!
  - `layer` — All visuals are rendered using a layer bit-flag. By default, all layers are rendered, but this can be useful for filtering out objects for different rendering purposes! For example: rendering a mesh over the user's head from a 3rd person perspective, but filtering it out from the 1st person perspective.
- `void Mesh.Draw(Material material, Matrix transform)` — Adds a mesh to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `material` — A Material to apply to the Mesh.
  - `transform` — A Matrix that will transform the mesh from Model Space into the current Hierarchy Space.
  - Example: see `Mesh.Draw` in StereoKit-docs-reference.md
- `static Mesh Mesh.Find(string meshId)` — Finds the Mesh with the matching id, and returns a reference to it. If no Mesh is found, it returns null.
  - `meshId` — Id of the Mesh we're looking for.
  - returns — A Mesh with a matching id, or null if none is found.
- `static Mesh Mesh.GenerateCircle(float diameter, int spokes, bool doubleSided)` — Generates a circle on the XZ axis facing up that is pre-sized to the given diameter. UV coordinates correspond to a unit circle centered at 0.5, 0.5! That is, the right-most point on the circle has UV coordinates 1, 0.5 and the top-most point has UV coordinates 0.5, 1. NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene.
  - `diameter` — The diameter of the circle in meters, or 2*radius. This is the full length from one side to the other.
  - `spokes` — How many vertices compose the circumference of the circle? Clamps to a minimum of 3. More is smoother, but less performant.
  - `doubleSided` — Should both sides of the circle be rendered?
  - returns — A circle mesh, pre-sized to the given dimensions.
- `static Mesh Mesh.GenerateCircle(float diameter, Vec3 planeNormal, Vec3 planeTopDirection, int spokes, bool doubleSided)` — Generates a circle with an arbitrary orientation that is pre-sized to the given diameter. UV coordinates start at the top left indicated with 'planeTopDirection' and correspond to a unit circle centered at 0.5, 0.5. NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene.
  - `diameter` — The diameter of the circle in meters, or 2*radius. This is the full length from one side to the other.
  - `planeNormal` — What is the normal of the surface this circle is generated on?
  - `planeTopDirection` — A normal defines the plane, but this is technically a rectangle on the plane. So which direction is up? It's important for UVs, but doesn't need to be exact. This function takes the planeNormal as law, and uses this vector to find the right and up vectors via cross-products.
  - `spokes` — How many vertices compose the circumference of the circle? Clamps to a minimum of 3. More is smoother, but less performant.
  - `doubleSided` — Should both sides of the circle be rendered?
  - returns — A circle mesh, pre-sized to the given dimensions.
  - Example: see `Mesh.GenerateCircle` in StereoKit-docs-reference.md
- `static Mesh Mesh.GenerateCube(Vec3 dimensions, int subdivisions)` — Generates a flat-shaded cube mesh, pre-sized to the given dimensions. UV coordinates are projected flat on each face, 0,0 -> 1,1. NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene. You may also be interested in using the pre-generated `Mesh.Cube` asset if it already meets your needs.
  - `dimensions` — How large is this cube on each axis, in meters?
  - `subdivisions` — Use this to add extra slices of vertices across the cube's faces. This can be useful for some types of vertex-based effects !
  - returns — A flat-shaded cube mesh, pre-sized to the given dimensions.
  - Example: see `Mesh.GenerateCube` in StereoKit-docs-reference.md
- `static Mesh Mesh.GenerateCylinder(float diameter, float depth, Vec3 direction, int subdivisions)` — Generates a cylinder mesh, pre-sized to the given diameter and depth, UV coordinates are from a flattened top view right now. Additional development is needed for making better UVs for the edges. NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene.
  - `diameter` — Diameter of the circular part of the cylinder in meters. Diameter is 2*radius.
  - `depth` — How tall is this cylinder, in meters?
  - `direction` — What direction do the circular surfaces face? This is the surface normal for the top, it does not need to be normalized.
  - `subdivisions` — How many vertices compose the edges of the cylinder? More is smoother, but less performant.
  - returns — Returns a cylinder mesh, pre-sized to the given diameter and depth, UV coordinates are from a flattened top view right now.
  - Example: see `Mesh.GenerateCylinder` in StereoKit-docs-reference.md
- `static Mesh Mesh.GeneratePlane(Vec2 dimensions, int subdivisions, bool doubleSided)` — Generates a plane on the XZ axis facing up that is optionally subdivided, pre-sized to the given dimensions. UV coordinates start at 0,0 at the -X,-Z corner, and go to 1,1 at the +X,+Z corner! NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene. You may also be interested in using the pre-generated `Mesh.Quad` asset if it already meets your needs.
  - `dimensions` — How large is this plane on the XZ axis, in meters?
  - `subdivisions` — Use this to add extra slices of vertices across the plane. This can be useful for some types of vertex-based effects!
  - `doubleSided` — Should both sides of the plane be rendered?
  - returns — A plane mesh, pre-sized to the given dimensions.
- `static Mesh Mesh.GeneratePlane(Vec2 dimensions, Vec3 planeNormal, Vec3 planeTopDirection, int subdivisions, bool doubleSided)` — Generates a plane with an arbitrary orientation that is optionally subdivided, pre-sized to the given dimensions. UV coordinates start at the top left indicated with 'planeTopDirection'. NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene. You may also be interested in using the pre-generated `Mesh.Quad` asset if it already meets your needs.
  - `dimensions` — How large is this plane on the XZ axis, in meters?
  - `planeNormal` — What is the normal of the surface this plane is generated on?
  - `planeTopDirection` — A normal defines the plane, but this is technically a rectangle on the plane. So which direction is up? It's important for UVs, but doesn't need to be exact. This function takes the planeNormal as law, and uses this vector to find the right and up vectors via cross-products.
  - `subdivisions` — Use this to add extra slices of vertices across the plane. This can be useful for some types of vertex-based effects!
  - `doubleSided` — Should both sides of the plane be rendered?
  - returns — A plane mesh, pre-sized to the given dimensions.
  - Example: see `Mesh.GeneratePlane` in StereoKit-docs-reference.md
- `static Mesh Mesh.GenerateRoundedCube(Vec3 dimensions, float edgeRadius, int subdivisions)` — Generates a cube mesh with rounded corners, pre-sized to the given dimensions. UV coordinates are 0,0 -> 1,1 on each face, meeting at the middle of the rounded corners. NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene.
  - `dimensions` — How large is this cube on each axis, in meters?
  - `edgeRadius` — Radius of the corner rounding, in meters.
  - `subdivisions` — How many subdivisions should be used for creating the corners? A larger value results in smoother corners, but can decrease performance.
  - returns — A cube mesh with rounded corners, pre-sized to the given dimensions.
  - Example: see `Mesh.GenerateRoundedCube` in StereoKit-docs-reference.md
- `static Mesh Mesh.GenerateSphere(float diameter, int subdivisions)` — Generates a sphere mesh, pre-sized to the given diameter, created by sphereifying a subdivided cube! UV coordinates are taken from the initial unspherified cube. NOTE: This generates a completely new Mesh asset on the GPU, and is best done during 'initialization' of your app/scene. You may also be interested in using the pre-generated `Mesh.Sphere` asset if it already meets your needs.
  - `diameter` — The diameter of the sphere in meters, or 2*radius. This is the full length from one side to the other.
  - `subdivisions` — How many times should the initial cube be subdivided?
  - returns — A sphere mesh, pre-sized to the given diameter, created by sphereifying a subdivided cube! UV coordinates are taken from the initial unspherified cube.
  - Example: see `Mesh.GenerateSphere` in StereoKit-docs-reference.md
- `UInt32[] Mesh.GetInds()` — This marshalls the Mesh's index data into an array. If KeepData is false, then the Mesh is _not_ storing indices on the CPU, and this information will _not_ be available. Due to the way marshalling works, this is _not_ a cheap function!
  - returns — An array of indices representing the Mesh, or null if KeepData is false.
- `bool Mesh.GetTriangle(uint triangleIndex, Vertex& a, Vertex& b, Vertex& c)` — Retrieves the vertices associated with a particular triangle on the Mesh.
  - `triangleIndex` — Starting index of the triangle, should be a multiple of 3.
  - `a` — The first vertex of the found triangle
  - `b` — The second vertex of the found triangle
  - `c` — The third vertex of the found triangle
  - returns — Returns true if triangle index was valid
- `Vertex[] Mesh.GetVerts()` — This marshalls the Mesh's vertex data into an array. If KeepData is false, then the Mesh is _not_ storing verts on the CPU, and this information will _not_ be available. Due to the way marshalling works, this is _not_ a cheap function!
  - returns — An array of vertices representing the Mesh, or null if KeepData is false.
- `Vertex[] Mesh.GetVerts()` — This marshalls the vertex data of a custom format Mesh into an array of T. T's [VertComponent] derived format must exactly match the format the Mesh was created with, and KeepData must be true for vertex data to be available. Due to the way marshalling works, this is _not_ a cheap function!
  - returns — An array of vertices representing the Mesh, or null if KeepData is false.
- `bool Mesh.Intersect(Ray modelSpaceRay, Ray& modelSpaceAt)` — Checks the intersection point of this ray and a Mesh with collision data stored on the CPU. A mesh without collision data will always return false. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `modelSpaceRay` — Ray must be in model space, the intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - returns — True if an intersection occurs, false otherwise!
- `bool Mesh.Intersect(Ray modelSpaceRay, Ray& modelSpaceAt, UInt32& outStartInds)` — Checks the intersection point of this ray and a Mesh with collision data stored on the CPU. A mesh without collision data will always return false. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `modelSpaceRay` — Ray must be in model space, the intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - `outStartInds` — The index of the first index of the triangle that was hit
  - returns — True if an intersection occurs, false otherwise!
- `bool Mesh.Intersect(Ray modelSpaceRay, Vec3& modelSpaceAt)` — Checks the intersection point of this ray and a Mesh with collision data stored on the CPU. A mesh without collision data will always return false. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `modelSpaceRay` — Ray must be in model space, the intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `modelSpaceAt` — The intersection point of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later.
  - returns — True if an intersection occurs, false otherwise!
  - Example: see `Mesh.Intersect` in StereoKit-docs-reference.md
- `void Mesh.SetData(Vertex[] vertices, UInt32[] indices, bool calculateBounds)` — Assigns the vertices and indices for this Mesh! This will create a vertex buffer and index buffer object on the graphics card. If you're calling this a second time, the buffers will be marked as dynamic and re-allocated. If you're calling this a third time, the buffer will only re-allocate if the buffer is too small, otherwise it just copies in the data! Remember to set all the relevant values! Your material will often show black if the Normals or Colors are left at their default values. Calling SetData is slightly more efficient than calling SetVerts and SetInds separately.
  - `vertices` — An array of vertices to add to the mesh. Remember to set all the relevant values! Your material will often show black if the Normals or Colors are left at their default values. Null is okay here, but may require a special shader.
  - `indices` — A list of face indices, must be a multiple of 3. Each index represents a vertex from the provided vertex array.
  - `calculateBounds` — If true, this will also update the Mesh's bounds based on the vertices provided. Since this does require iterating through all the verts with some logic, there is performance cost to doing this. If you're updating a mesh frequently or need all the performance you can get, setting this to false is a nice way to gain some speed!
- `void Mesh.SetData(Vertex[] vertices, UInt32[] indices, MeshData flags, int priority)` — Assigns the vertices and indices for this Mesh with control over upload behavior via flags. Upload is synchronous by default — pass MeshData.Async for background upload.
  - `vertices` — An array of vertices to add to the mesh. Remember to set all the relevant values! Your material will often show black if the Normals or Colors are left at their default values. Null is okay here, but may require a special shader.
  - `indices` — A list of face indices, must be a multiple of 3. Each index represents a vertex from the provided vertex array.
  - `flags` — Flags controlling upload behavior. See MeshData for options.
  - `priority` — Loading priority for async upload. Lower values load sooner.
  - Example: see `Mesh.SetData` in StereoKit-docs-reference.md
- `void Mesh.SetData(T[] vertices, UInt32[] indices, bool calculateBounds)` — Assigns vertices with a custom vertex format along with face indices for this Mesh in a single call! The format is derived from T's [VertComponent] tagged fields, see SetVerts for details. Calling SetData is slightly more efficient than calling SetVerts and SetInds separately.
  - `vertices` — An array of vertices to add to the mesh.
  - `indices` — A list of face indices, must be a multiple of 3. Each index represents a vertex from the provided vertex array.
  - `calculateBounds` — If true, this will also update the Mesh's bounds based on the vertices provided. This requires the format to contain a float3 position component.
- `void Mesh.SetData(T[] vertices, UInt32[] indices, MeshData flags, int priority)` — Assigns vertices with a custom vertex format along with face indices for this Mesh in a single call, with control over upload behavior via flags! Upload is synchronous by default — pass MeshData.Async for background upload. The format is derived from T's [VertComponent] tagged fields, see SetVerts for details.
  - `vertices` — An array of vertices to add to the mesh.
  - `indices` — A list of face indices, must be a multiple of 3. Each index represents a vertex from the provided vertex array.
  - `flags` — Flags controlling upload behavior. See MeshData for options.
  - `priority` — Loading priority for async upload. Lower values load sooner.
  - Example: see `Mesh.SetData` in StereoKit-docs-reference.md
- `void Mesh.SetInds(UInt32[] indices)` — Assigns the face indices for this Mesh! Faces are always triangles, there are only ever three indices per face. This function will create a index buffer object on the graphics card. If you're calling this a second time, the buffer will be marked as dynamic and re-allocated. If you're calling this a third time, the buffer will only re-allocate if the buffer is too small, otherwise it just copies in the data!
  - `indices` — A list of face indices, must be a multiple of 3. Each index represents a vertex from the array assigned using SetVerts.
  - Example: see `Mesh.SetInds` in StereoKit-docs-reference.md
- `void Mesh.SetSkin(UInt16[] boneIds, Vec4[] boneWeights, Matrix[] boneRestingTransforms)` — Attaches CPU skinning data to this Mesh. Once skin data is set, call UpdateSkin each frame with the current bone palette to deform the vertex buffer. KeepData must be true and vertex data must already be set before calling this — the deformation runs on the CPU and needs a copy of the rest-pose vertices to work from. The bone palette passed to UpdateSkin is expected to be bone world transforms in the same coordinate system the resting transforms were authored in. The skinning matrix for bone `i` is computed as `bonePalette[i] * inverse(boneRestingTransforms[i])`.
  - `boneIds` — Per-vertex bone indices, packed 4 per vertex (so this array has length VertCount * 4). Each index references a slot in the bone palette and resting transforms.
  - `boneWeights` — Per-vertex bone weights, one Vec4 per vertex (length must equal VertCount). The four components correspond to the four bone ids for that vertex. Weights should sum to ~1 for a stable result.
  - `boneRestingTransforms` — Bind-pose transform for each bone, expressed in the mesh's model space. StereoKit inverts these internally to produce the inverse-bind matrices used by the skinning math.
- `void Mesh.SetVerts(Vertex[] vertices, bool calculateBounds)` — Assigns the vertices for this Mesh! This will create a vertex buffer object on the graphics card. If you're calling this a second time, the buffer will be marked as dynamic and re-allocated. If you're calling this a third time, the buffer will only re-allocate if the buffer is too small, otherwise it just copies in the data! Remember to set all the relevant values! Your material will often show black if the Normals or Colors are left at their default values.
  - `vertices` — An array of vertices to add to the mesh. Remember to set all the relevant values! Your material will often show black if the Normals or Colors are left at their default values.
  - `calculateBounds` — If true, this will also update the Mesh's bounds based on the vertices provided. Since this does require iterating through all the verts with some logic, there is performance cost to doing this. If you're updating a mesh frequently or need all the performance you can get, setting this to false is a nice way to gain some speed!
  - Example: see `Mesh.SetVerts` in StereoKit-docs-reference.md
- `void Mesh.SetVerts(T[] vertices, bool calculateBounds)` — Assigns vertices with a custom vertex format to this Mesh! The format is derived from T's fields, each of which must be tagged with a [VertComponent] attribute describing what it is. The shader this Mesh is drawn with must be one that works with the components this format provides, StereoKit's built-in shaders all expect position, normal, texcoord and color. A T that doesn't exactly describe its own memory layout will throw an ArgumentException here, see [VertComponent] docs for the rules.
  - `vertices` — An array of vertices to add to the mesh.
  - `calculateBounds` — If true, this will also update the Mesh's bounds based on the vertices provided. This requires the format to contain a float3 position component.
  - Example: see `Mesh.SetVerts` in StereoKit-docs-reference.md
- `void Mesh.UpdateSkin(Matrix[] bonePalette)` — Drives the per-frame CPU deformation for a skinned Mesh. SetSkin must have been called first. This walks every vertex, blends the bone transforms by weight, and re-uploads the deformed vertices to the GPU. `bonePalette` holds the current world-space transform for each bone, in the same coordinate system the resting transforms passed to SetSkin were authored in. Its length must match the bone count supplied to SetSkin. Because deformation mutates this Mesh's vertex buffer in place, two entities driven by different bone palettes need their own Mesh instance — use Copy on a shared source mesh to get per-instance deformation.
  - `bonePalette` — World-space transform per bone for this frame. Length must match the bone count supplied to SetSkin.

## enum MeshData

Bit-flags for controlling mesh data upload behavior.

- `MeshData.Async` — Upload mesh data asynchronously on a background thread. The mesh will be skipped during rendering until the upload completes.
- `MeshData.CalcBounds` — Calculate mesh bounds from the provided vertices.
- `MeshData.None` — No special behavior. Mesh data will be uploaded synchronously with no bounds calculation.

## static class Microphone

This class provides access to the hardware's microphone, and stores it in a Sound stream. Start and Stop recording, and check the Sound property for the results! Remember to ensure your application has microphone permissions enabled!

- `static bool Microphone.IsRecording` — Tells if the Microphone is currently recording audio.
- `static Sound Microphone.Sound` — This is the sound stream of the Microphone when it is recording. This Asset is created the first time it is accessed via this property, or during Start, and will persist. It is re-used for the Microphone stream if you start/stop/switch devices.
- `static String[] Microphone.GetDevices()` — Constructs a list of valid Microphone devices attached to the system. These names can be passed into Start to select a specific device to record from. It's recommended to cache this list if you're using it frequently, as this list is constructed each time you call it. It's good to note that a user might occasionally plug or unplug microphone devices from their system, so this list may occasionally change.
  - returns — List of human readable microphone device names.
  - Example: see `Microphone.GetDevices` in StereoKit-docs-reference.md
- `static bool Microphone.Start(string deviceName)` — This begins recording audio from the Microphone! Audio is stored in Microphone.Sound as a stream of audio. If the Microphone is already recording with a different device, it will stop the previous recording and start again with the new device. If null is provided as the device, then they system's default input device will be used. Some systems may not provide access to devices other than the system's default. On Android, this function requires user approved permissions to use. If these permissions are not already granted when Start is called, but the permission is available to the app, then this call will request permission and fail. You can check Permission.State and explicitly manage the permission yourself if you want to avoid this function failing the first time.
  - `deviceName` — The name of the microphone device to use, as seen in the GetDevices list. null will use the system's default device preference.
  - returns — True if recording started successfully, false for failure. This could fail if the app does not have mic permissions, or if the deviceName is for a mic that has since been unplugged.
  - Example: see `Microphone.Start` in StereoKit-docs-reference.md
- `static void Microphone.Stop()` — If the Microphone is recording, this will stop it.

## class Model

A Model is a collection of meshes, materials, and transforms that make up a visual element! This is a great way to group together complex objects that have multiple parts in them, and in fact, most model formats are composed this way already! This class contains a number of methods for creation. If you pass in a .obj, .stl, , .ply (ASCII), .gltf, or .glb, StereoKit will load that model from file, and assemble materials and transforms from the file information. But you can also assemble a model from procedurally generated meshes! Because models include an offset transform for each mesh element, this does have the overhead of an extra matrix multiplication in order to execute a render command. So if you need speed, and only have a single mesh with a precalculated transform matrix, it can be faster to render a Mesh instead of a Model!

- `Anim Model.ActiveAnim` — This is a link to the currently active animation. If no animation is active, this value will be null. To set the active animation, use `PlayAnim`.
- `float Model.AnimCompletion` — This is the percentage of completion of the active animation. This will always be a value between 0-1. If no animation is active, this will be zero.
- `AnimMode Model.AnimMode` — The playback mode of the active animation.
- `ModelAnimCollection Model.Anims` — An enumerable collection of animations attached to this Model. You can do Linq stuff with it, foreach it, or just treat it like a List or array! Accessing Count or iterating will block until the Model has fully finished loading.
- `float Model.AnimTime` — This is the current time of the active animation in seconds, from the start of the animation. If no animation is active, this will be zero. This will always be a value between zero and the active animation's `Duration`. For a percentage of completion, see `AnimCompletion` instead.
- `AssetState Model.AssetState` — This tells you the current state of the Model asset. A Model starts in the Loading state when created from a file, transitions to LoadedMeta when the hierarchy is available, and Loaded once all mesh and texture data has been submitted for upload. This also reflects if an error occured while loading the Model with a variety of asset error codes!
- `Bounds Model.Bounds` — This is a bounding box that encapsulates the Model and all its subsets! It's used for collision, visibility testing, UI layout, and probably other things. While it's normally calculated from the mesh bounds, you can also override this to suit your needs. If the Model is still loading, this returns a default 10cm cube.
- `string Model.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `ModelNodeCollection Model.Nodes` — This is an enumerable collection of all the nodes in this Model, ordered non-hierarchically by when they were added. You can do Linq stuff with it, foreach it, or just treat it like a List or array! Accessing Count or iterating will block until the Model's metadata has finished loading.
- `ModelNode Model.RootNode` — Returns the first root node in the Model's hierarchy. There may be additional root nodes, and these will be Siblings of this ModelNode. If there are no nodes present on the Model, this will be null. This will block until the Model's metadata has finished loading.
- `ModelVisualCollection Model.Visuals` — This is an enumerable collection of all the nodes with Mesh/Material data in this Model, ordered non-hierarchically by when they were added. You can do Linq stuff with it, foreach it, or just treat it like a List or array! Accessing Count or iterating will block until the Model's metadata has finished loading.
- `void Model(Mesh mesh, Material material)` — Creates a single mesh subset Model using the indicated Mesh and Material! An id will be automatically generated for this asset.
  - `mesh` — Any Mesh asset.
  - `material` — Any Material asset.
- `void Model()` — Creates an empty Model object with an automatically generated id. Use the AddSubset methods to fill this model out.
- `void Model(string id, Mesh mesh, Material material)` — Creates a single mesh subset Model using the indicated Mesh and Material!
  - `id` — Uses this as the id, so you can Find it later.
  - `mesh` — Any Mesh asset.
  - `material` — Any Material asset.
  - Example: see `Model.Model` in StereoKit-docs-reference.md
- `ModelNode Model.AddNode(string name, Matrix modelTransform, Mesh mesh, Material material, bool solid)` — This adds a root node to the `Model`'s node hierarchy! If There is already an initial root node, this node will still be a root node, but will be a `Sibling` of the `Model`'s `RootNode`. If this is the first root node added, you'll be able to access it via `RootNode`.
  - `name` — A text name to identify the node. If null is provided, it will be auto named to "node"+index.
  - `modelTransform` — A Matrix describing this node's transform in Model space.
  - `mesh` — The Mesh to attach to this Node's visual, if this is null, then material must also be null.
  - `material` — The Material to attach to this Node's visual, if this is null, then mesh must also be null.
  - `solid` — A flag that indicates the Mesh for this node will be used in ray intersection tests. This flag is ignored if no Mesh is attached.
  - returns — This returns the newly added ModelNode, or if there's an issue with mesh and material being inconsistently null, then this result will also be null.
  - Example: see `Model.AddNode` in StereoKit-docs-reference.md
- `Model Model.Copy()` — Creates a shallow copy of a Model asset! Meshes and Materials referenced by this Model will be referenced, not copied.
  - returns — A new shallow copy of a Model.
  - Example: see `Model.Copy` in StereoKit-docs-reference.md
- `void Model.Draw(Matrix transform, Color colorLinear, RenderLayer layer)` — Adds this Model to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `transform` — A Matrix that will transform the Model from Model Space into the current Hierarchy Space.
  - `colorLinear` — A per-instance linear space color value to pass into the shader! Normally this gets used like a material tint. If you're  adventurous and don't need per-instance colors, this is a great spot to pack in extra per-instance data for the shader!
  - `layer` — All visuals are rendered using a layer bit-flag. By default, all layers are rendered, but this can be useful for filtering out objects for different rendering purposes! For example: rendering a mesh over the user's head from a 3rd person perspective, but filtering it out from the 1st person perspective.
- `void Model.Draw(Material materialOverride, Matrix transform, Color colorLinear, RenderLayer layer)` — Adds this Model to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `transform` — A Matrix that will transform the Model from Model Space into the current Hierarchy Space.
  - `colorLinear` — A per-instance linear space color value to pass into the shader! Normally this gets used like a material tint. If you're  adventurous and don't need per-instance colors, this is a great spot to pack in extra per-instance data for the shader!
  - `layer` — All visuals are rendered using a layer bit-flag. By default, all layers are rendered, but this can be useful for filtering out objects for different rendering purposes! For example: rendering a mesh over the user's head from a 3rd person perspective, but filtering it out from the 1st person perspective.
  - `materialOverride` — Allows you to override the Material of all nodes on this Model with your own Material.
- `void Model.Draw(Matrix transform)` — Adds this Model to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `transform` — A Matrix that will transform the Model from Model Space into the current Hierarchy Space.
- `static Model Model.Find(string modelId)` — Looks for a Model asset that's already loaded, matching the given id!
  - `modelId` — Which Model are you looking for?
  - returns — A link to the Model matching 'modelId', null if none is found.
- `Anim Model.FindAnim(string name)` — Searches the list of animations for the first one matching the given name. This will block until the Model has fully finished loading.
  - `name` — Case sensitive name of the animation.
  - returns — A link to the animation, or null if none is found.
  - Example: see `Model.FindAnim` in StereoKit-docs-reference.md
- `ModelNode Model.FindNode(string name)` — Searches the entire list of Nodes, and will return the first on that matches this name exactly. If no ModelNode is found, then this will return null. Node Names are not guaranteed to be unique. This will block until the Model's metadata is loaded.
  - `name` — Exact name to match against. ASCII only for now.
  - returns — The first matching ModelNode, or null if none are found.
  - Example: see `Model.FindNode` in StereoKit-docs-reference.md
- `static Model Model.FromFile(string file, Shader shader, int loadPriority)` — Loads a list of mesh and material subsets from a .obj, .stl, .ply (ASCII), .gltf, or .glb file.
  - `file` — Name of the file to load! This gets prefixed with the StereoKit asset folder if no drive letter is specified in the path.
  - `shader` — The shader to use for the model's materials! If null, this will automatically determine the best shader available to use.
  - returns — Always returns a valid Model created from the file, check the AssetState to see if a failure occurred.
  - Example: see `Model.FromFile` in StereoKit-docs-reference.md
- `static Model Model.FromMemory(string filename, Byte[]& data, Shader shader, int loadPriority)` — Loads a list of mesh and material subsets from a .obj, .stl, .ply (ASCII), .gltf, or .glb file stored in memory. Note that this function won't work well on files that reference other files, such as .gltf files with references in them.
  - `filename` — StereoKit still uses the filename of the data for format discovery, but not asset Id creation. If you don't have a real filename for the data, just pass in an extension with a leading '.' character here, like ".glb".
  - `data` — The binary data of a model file, this is NOT a raw array of vertex and index data!
  - `shader` — The shader to use for the model's materials! If null, this will automatically determine the best shader available to use.
  - returns — Always returns a valid Model created from the file, check the AssetState to see if a failure occurred.
- `static Model Model.FromMesh(Mesh mesh, Material material)` — Creates a single mesh subset Model using the indicated Mesh and Material! An id will be automatically generated for this asset.
  - `mesh` — Any Mesh asset.
  - `material` — Any Material asset.
  - returns — A Model composed of a single mesh and Material.
- `static Model Model.FromMesh(string id, Mesh mesh, Material material)` — Creates a single mesh subset Model using the indicated Mesh and Material!
  - `id` — Uses this as the id, so you can Find it later.
  - `mesh` — Any Mesh asset.
  - `material` — Any Material asset.
  - returns — A Model composed of a single mesh and Material.
- `bool Model.Intersect(Ray modelSpaceRay, Ray& modelSpaceAt)` — Checks the intersection point of this ray and a Model's visual nodes. This will skip any node that is not flagged as Solid, as well as any Mesh without collision data. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs! If the Model is still loading, this returns false immediately.
  - `modelSpaceRay` — Ray must be in model space, the intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - returns — True if an intersection occurs, false otherwise!
- `bool Model.Intersect(Ray modelSpaceRay, Cull cullFaces, Ray& modelSpaceAt)` — Checks the intersection point of this ray and a Model's visual nodes. This will skip any node that is not flagged as Solid, as well as any Mesh without collision data. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs! If the Model is still loading, this returns false immediately.
  - `modelSpaceRay` — Ray must be in model space, the intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - `cullFaces` — How should intersection work with respect to the direction the triangles are facing? Should we skip triangles that are facing away from the ray, or don't skip anything?
  - returns — True if an intersection occurs, false otherwise!
- `void Model.PlayAnim(string animationName, AnimMode mode)` — Searches for an animation with the given name, and if it's found, sets it up as the active animation and begins playing it with the animation mode.
  - `animationName` — Case sensitive name of the animation.
  - `mode` — The mode with which to play the animation.
- `void Model.PlayAnim(Anim animation, AnimMode mode)` — Sets the animation up as the active animation, and begins playing it with the animation mode.
  - `animation` — The new active animation.
  - `mode` — The mode with which to play the animation.
  - Example: see `Model.PlayAnim` in StereoKit-docs-reference.md
- `void Model.RecalculateBounds()` — Examines the visuals as they currently are, and rebuilds the bounds based on that! This is normally done automatically, but if you modify a Mesh that this Model is using, the Model can't see it, and you should call this manually.
- `void Model.RecalculateBoundsExact()` — Examines the visuals as they currently are, and rebuilds the bounds based on all the vertices in the model! This leads (in general) to a tighter bound than the default bound based on bounding boxes. However, computing the exact bound can take much longer!
- `void Model.StepAnim()` — Calling Draw will automatically step the Model's animation, but if you don't draw the Model, or need access to the animated nodes before drawing, then you can step the animation early manually via this method. Animation will only ever be stepped once per frame, so it's okay to call this multiple times, or in addition to Draw.

## class ModelAnimCollection

An enumerable for Model's Anims

- `int ModelAnimCollection.Count` — This is the total number of animations attached to the model. This will block until the Model has fully finished loading.
- `Enumerator ModelAnimCollection.GetEnumerator()` — Gets an enumerator for the collection. This returns a concrete struct enumerator so that `foreach` over the collection stays allocation-free (aside from the Anim objects themselves).
  - returns — An enumerator.

## struct ModelAnimCollection.Enumerator

An allocation-free struct enumerator for a `ModelAnimCollection`.
- `void ModelAnimCollection.Enumerator.Dispose()` — Nothing to dispose, this is here to satisfy the IEnumerator interface.
- `bool ModelAnimCollection.Enumerator.MoveNext()` — Advances to the next Anim.
  - returns — False once the end of the collection is reached.
- `void ModelAnimCollection.Enumerator.Reset()` — Resets the enumerator to before the first element.

## class ModelNode

This class is a link to a node in a Model's internal hierarchy tree. It's composed of node information, and links to the directly adjacent tree nodes.

- `ModelNode ModelNode.Child` — The first child node "below" on the hierarchy tree, or null if there are none. To see all children, get the Child and then iterate through its Siblings.
- `ModelNodeInfoCollection ModelNode.Info` — A collection of key/value pairs that add additional information to this node. If this comes from a GLTF model, this will be populated with the contents of the "extras" section of the node.
- `Matrix ModelNode.LocalTransform` — The transform of this node relative to the Parent node. Setting this transform will update the ModelTransform, as well as all Child nodes below this one.
- `Material ModelNode.Material` — The Material associated with this node. May be null, or may also be re-used elsewhere. Getting this will block until the Model's metadata has finished loading.
- `Mesh ModelNode.Mesh` — The Mesh associated with this node. May be null, or may also be re-used elsewhere. Getting this will block until the Model has fully finished loading.
- `Matrix ModelNode.ModelTransform` — The transform of this node relative to the Model itself. This incorporates transforms from all parent nodes. Setting this transform will update the LocalTransform, as well as all Child nodes below this one.
- `string ModelNode.Name` — This is the ASCII name that identifies this ModelNode. It is generally provided by the Model's file, but in the event no name (or null name) is provided, the name will default to "node"+index. Names are not required to be unique.
- `ModelNode ModelNode.Parent` — The ModelNode above this one ("up") in the hierarchy tree, or null if this is a root node.
- `ModelNode ModelNode.Sibling` — The next ModelNode in the hierarchy, at the same level as this one. To the "right" on a hierarchy tree. Null if there are no more ModelNodes in the tree there.
- `bool ModelNode.Solid` — A flag that indicates the Mesh for this node will be used in ray intersection tests. This flag is ignored if no Mesh is attached.
- `bool ModelNode.Visible` — Is this node flagged as visible? By default, this is true for all nodes with visual elements attached. These nodes will not be drawn or skinned if you set this flag to false. If a ModelNode has no visual elements attached to it, it will always return false, and setting this value will have no effect.
- `ModelNode ModelNode.AddChild(string name, Matrix localTransform, Mesh mesh, Material material, bool solid)` — Adds a Child node below this node, at the end of the child chain!
  - `name` — A text name to identify the node. If null is provided, it will be auto named to "node"+index.
  - `localTransform` — A Matrix describing this node's transform in local space relative to the currently selected node.
  - `mesh` — The Mesh to attach to this Node's visual, if this is null, then material must also be null.
  - `material` — The Material to attach to this Node's visual, if this is null, then mesh must also be null.
  - `solid` — A flag that indicates the Mesh for this node will be used in ray intersection tests. This flag is ignored if no Mesh is attached.
  - returns — This returns the newly added ModelNode, or if there's an issue with mesh and material being inconsistently null, then this result will also be null.
  - Example: see `ModelNode.AddChild` in StereoKit-docs-reference.md
- `string ModelNode.GetInfo(string key)` — Get a Key/Value pair associated with this ModelNode. This is auto-populated from the GLTF extras, and you can also add your own items here as well.
  - `key` — The dictionary key to look up.
  - returns — Null if this key does not exist, or a string with data otherwise.
- `bool ModelNode.MoveChild()` — Moves this ModelNode class to the first Child of this node. If it cannot, then it remains the same.
  - returns — True if it moved to the Child, false if there was no Child to move to.
- `bool ModelNode.MoveParent()` — Moves this ModelNode class to the Parent up the hierarchy tree. If it cannot, then it remains the same.
  - returns — True if it moved to the Parent, false if there was no Parent to move to.
- `bool ModelNode.MoveSibling()` — Advances this ModelNode class to the next Sibling in the hierarchy tree. If it cannot, then it remains the same.
  - returns — True if it moved to the Sibling, false if there was no Sibling to move to.
- `void ModelNode.SetInfo(string key, string value)` — Set a Key/Value pair associated with this ModelNode. This is auto-populated from the GLTF extras, and you can also add your own items here as well.
  - `key` — The dictionary key to look up.
  - `value` — 

## class ModelNodeCollection

An enumerable for Model's ModelNodes

- `int ModelNodeCollection.Count` — This is the total number of nodes in the Model. This will block until the Model's metadata has finished loading.
- `ModelNode ModelNodeCollection.Add(string name, Matrix modelTransform, Mesh mesh, Material material, bool solid)` — This adds a root node to the `Model`'s node hierarchy! If There is already an initial root node, this node will still be a root node, but will be a `Sibling` of the `Model`'s `RootNode`. If this is the first root node added, you'll be able to access it via `RootNode`.
  - `name` — A text name to identify the node. If null is provided, it will be auto named to "node"+index.
  - `modelTransform` — A Matrix describing this node's transform in Model space.
  - `mesh` — The Mesh to attach to this Node's visual, if this is null, then material must also be null.
  - `material` — The Material to attach to this Node's visual, if this is null, then mesh must also be null.
  - `solid` — A flag that indicates the Mesh for this node will be used in ray intersection tests. This flag is ignored if no Mesh is attached.
  - returns — This returns the newly added ModelNode, or if there's an issue with mesh and material being inconsistently null, then this result will also be null.
- `Enumerator ModelNodeCollection.GetEnumerator()` — Gets an enumerator for the collection. This returns a concrete struct enumerator so that `foreach` over the collection stays allocation-free.
  - returns — An enumerator.

## struct ModelNodeCollection.Enumerator

An allocation-free struct enumerator for a `ModelNodeCollection`.
- `void ModelNodeCollection.Enumerator.Dispose()` — Nothing to dispose, this is here to satisfy the IEnumerator interface.
- `bool ModelNodeCollection.Enumerator.MoveNext()` — Advances to the next ModelNode.
  - returns — False once the end of the collection is reached.
- `void ModelNodeCollection.Enumerator.Reset()` — Resets the enumerator to before the first element.

## struct ModelNodeInfoCollection

A collection of key/value string pairs adding additional information to the ModelNode.

- `int ModelNodeInfoCollection.Count` — The number of key/value pairs in the collection.
- `IEnumerable`1 ModelNodeInfoCollection.Keys` — An enumerable for the keys in this collection.
- `IEnumerable`1 ModelNodeInfoCollection.Values` — An enumerable for the values in this collection.
- `void ModelNodeInfoCollection.Add(string key, string val)` — Adds a key/value pair, or replaces an existing key/value pair.
  - `key` — Identifying key.
  - `val` — Value to associate with the key.
  - Example: see `ModelNodeInfoCollection.Add` in StereoKit-docs-reference.md
- `void ModelNodeInfoCollection.Clear()` — Clears all key/value pairs from the collection.
- `bool ModelNodeInfoCollection.Contains(string key)` — Finds if the key is present in the collection with a non-null value.
  - `key` — Identifying key.
  - returns — True if found, false if not.
- `string ModelNodeInfoCollection.Get(string key)` — Finds the value associated with the given key, returns null if the key is not present.
  - `key` — Identifying key.
  - returns — Associated value, or null if not found.
- `Enumerator ModelNodeInfoCollection.GetEnumerator()` — The enumerator for the collection's KeyValuePairs. This is a concrete struct enumerator so that `foreach` over the collection stays allocation-free (aside from the key/value strings themselves).
  - returns — Each consecutive pair in the collection.
- `bool ModelNodeInfoCollection.Remove(string key)` — Removes a specific key/value pair from the collection, if present.
  - `key` — Identifying key.
  - returns — True if found and removed, false if not.
  - Example: see `ModelNodeInfoCollection.Remove` in StereoKit-docs-reference.md

## struct ModelNodeInfoCollection.Enumerator

An allocation-free struct enumerator for a `ModelNodeInfoCollection`.
- `void ModelNodeInfoCollection.Enumerator.Dispose()` — Nothing to dispose, this is here to satisfy the IEnumerator interface.
- `bool ModelNodeInfoCollection.Enumerator.MoveNext()` — Advances to the next key/value pair.
  - returns — False once the end of the collection is reached.
- `void ModelNodeInfoCollection.Enumerator.Reset()` — Resets the enumerator to before the first element.

## class ModelVisualCollection

An enumerable for Model's visual ModelNodes

- `int ModelVisualCollection.Count` — This is the total number of nodes with visual data attached to them. This will block until the Model's metadata has finished loading.
- `Enumerator ModelVisualCollection.GetEnumerator()` — Gets an enumerator for the collection. This returns a concrete struct enumerator so that `foreach` over the collection stays allocation-free.
  - returns — An enumerator.

## struct ModelVisualCollection.Enumerator

An allocation-free struct enumerator for a `ModelVisualCollection`.
- `void ModelVisualCollection.Enumerator.Dispose()` — Nothing to dispose, this is here to satisfy the IEnumerator interface.
- `bool ModelVisualCollection.Enumerator.MoveNext()` — Advances to the next ModelNode.
  - returns — False once the end of the collection is reached.
- `void ModelVisualCollection.Enumerator.Reset()` — Resets the enumerator to before the first element.

## struct Mouse

This stores information about the mouse! What's its state, where's it pointed, do we even have one?

- `bool Mouse.available` — Is the mouse available to use? Most MR systems likely won't have a mouse!
- `Vec2 Mouse.pos` — Position of the mouse relative to the window it's in! This is the number of pixels from the top left corner of the screen.
- `Vec2 Mouse.posChange` — How much has the mouse's position changed in the current frame? Measured in pixels.
- `Ray Mouse.Ray` — Ray representing the position and orientation that the current Input.Mouse.pos is pointing in.
- `float Mouse.scroll` — What's the current scroll value for the mouse's scroll wheel?
- `float Mouse.scrollChange` — How much has the scroll wheel value changed during this frame?

## enum OcclusionCaps

Flags that describe which occlusion methods are active or available. These can be combined to enable multiple occlusion techniques simultaneously.

- `OcclusionCaps.Depth` — Depth texture-based occlusion (e.g. META environment depth).
- `OcclusionCaps.Hands` — When combined with Depth: hands will also occlude virtual content. Without this flag, hands are removed from the depth buffer and will not occlude.
- `OcclusionCaps.Mesh` — Scene Understanding mesh-based occlusion (e.g. HoloLens).
- `OcclusionCaps.None` — No occlusion is active.

## enum OriginMode

This describes where the origin of the application should be. While these origins map closely to OpenXR features, not all runtimes support each feature. StereoKit will provide reasonable fallback behavior in the event the origin mode isn't directly supported.

- `OriginMode.Floor` — The origin will be at the floor beneath where the user starts, facing the direction of the user. If this mode is not natively supported, StereoKit will use the stage mode with an offset. If stage mode is unavailable, it will fall back to local mode with a -1.5 Y axis offset.
- `OriginMode.Local` — The origin will be at the location of the user's head when the application starts, facing the same direction as the user. This mode is available on all runtimes, and will never fall back to another mode! However, due to variances in underlying behavior, StereoKit may introduce an origin offset to ensure consistent behavior.
- `OriginMode.Stage` — The origin will be at the center of a safe play area or stage that the user or OS has defined, and will face one of the edges of the play area. If this mode is not natively supported, StereoKit will use the floor origin mode. If floor mode is unavailable, it will fall back to local mode with a -1.5 Y axis offset.

## static class Permission

Certain features in XR require explicit permissions from the operating system and user! This is typically for features that surface sensitive data like eye gaze, or objects in the user's room. This is often complicated by the fact that permissions aren't standardized across XR runtimes, making these permissions fragile and a pain to work with. This class attempts to manage feature permissions in a nice cross-platform manner that handles runtime specific differences. You will still need to add permission strings to your app's metadata file (like AndroidManifest.xml), but this class will handle figuring out which strings in the metadata to actually use. On Android, if you use a Service or Context instead of an Activity for your app (unusual), StereoKit will not be able to manage permissions for you! On platforms that don't use permissions, like Win32 or Linux, these functions will behave as though everything is granted automatically.
- `static bool Permission.IsInteractive(PermissionType permission)` — Does this permission need the user to approve it? This typically means a popup window will come up when you Request this permission, and the user has a chance to decline it. If your app is an Android Service, this only reflects the Dangerous status of the permission.
  - `permission` — The permission you're interested in.
  - returns — True if the permission requires user interaction, false otherwise.
- `static void Permission.Request(PermissionType[] permissions)` — This sends off a request to the OS for one or more permissions! If a permission IsInteractive, then this will bring up a popup that the user may need to interact with. Otherwise, this will silently approve the permission. This means that the permission may take an arbitrary amount of time before it's approved, or declined. Requesting multiple permissions in a single call is preferable to chaining individual requests yourself, since the OS gets to present them together and you avoid the risk of a follow-up request getting dropped while an earlier popup is still up. Any permissions that aren't known on the current platform are skipped with a warning. If your app is an Android Service, this function will do nothing.
  - `permissions` — The permission(s) to request.
- `static PermissionState Permission.State(PermissionType permission)` — Retreives the current state of a particular permission. This is a fast check, so it's fine to call frequently.
  - `permission` — The permission you're interested in.
  - returns — Check `PermissionState` for details.

## enum PermissionState

Permissions can be in a variety of states, depending on how users interact with them. Sometimes they're automatically granted, user denied, or just unknown for the current runtime!

- `PermissionState.Capable` — This app is capable of using the permission, but it needs to be requested first with Permission.Request.
- `PermissionState.Granted` — This permission is entirely approved and you can go ahead and use the associated features!
- `PermissionState.Unavailable` — This permission is known to StereoKit, but not available to request. Typically this means the correct permission string is not listed in the AndroidManfiest.xml or similar.
- `PermissionState.Unknown` — StereoKit doesn't know about the permission on the current runtime. This happens when the runtime has a unique permission string (or not) and StereoKit doesn't know what it is to look up its current status.

## enum PermissionType

A list of permissions that StereoKit knows about. On some platforms (like Android), these permissions may need to be explicitly requested before using certain features.

- `PermissionType.Camera` — For access to camera data, this is typically an interactive permission that the user will need to explicitly approve. SK doesn't use this permission internally yet, but is often a useful permission for XR apps. This maps to android.permission.CAMERA on Android.
- `PermissionType.EyeInput` — For access to input quality eye tracking data, this is typically an interactive permission that the user will need to explicitly approve. This maps to android.permission.EYE_TRACKING_FINE on Android XR, but varies per-runtime.
- `PermissionType.FaceTracking` — For access to facial expression data, this is typically an interactive permission that the user will need to explicitly approve. This maps to android.permission.FACE_TRACKING on Android XR, but varies per-runtime.
- `PermissionType.HandTracking` — For access to per-joint hand tracking data. Some runtimes may have this permission interactive, but many do not. This maps to android.permission.HAND_TRACKING on Android XR, but varies per-runtime.
- `PermissionType.Max` — This enum is for tracking the number of value in this enum.
- `PermissionType.Microphone` — For access to microphone data, this is typically an interactive permission that the user will need to explicitly approve. This maps to android.permission.RECORD_AUDIO on Android.
- `PermissionType.Scene` — For access to data in the user's space, this can be for things like spatial anchors, plane detection, hit testing, etc. This is typically an interactive permission that the user will need to explicitly approve. This maps to android.permission.SCENE_UNDERSTANDING_COARSE on Android XR, but varies per-runtime.

## enum PickerMode

When opening the Platform.FilePicker, this enum describes how the picker should look and behave.

- `PickerMode.Open` — Allow opening a single file.
- `PickerMode.Save` — Allow the user to enter or select the name of the destination file.

## enum Pivot

A bit-flag enum for describing alignment or positioning. Items can be combined using the '|' operator, like so: `Align alignment = Align.YTop | Align.XLeft;` Avoid combining multiple items of the same axis. There are also a complete list of valid bit flag combinations! These are the values without an axis listed in their names, 'TopLeft', 'BottomCenter', etc.

- `Pivot.BottomCenter` — Center on the X axis, and bottom on the Y axis. This is a combination of XCenter and YBottom.
- `Pivot.BottomLeft` — Start on the left of the X axis, and bottom on the Y axis. This is a combination of XLeft and YBottom.
- `Pivot.BottomRight` — Start on the right of the X axis, and bottom on the Y axis.This is a combination of XRight and YBottom.
- `Pivot.Center` — Center on both X and Y axes. This is a combination of XCenter and YCenter.
- `Pivot.CenterLeft` — Start on the left of the X axis, center on the Y axis. This is a combination of XLeft and YCenter.
- `Pivot.CenterRight` — Start on the right of the X axis, center on the Y axis. This is a combination of XRight and YCenter.
- `Pivot.TopCenter` — Center on the X axis, and top on the Y axis. This is a combination of XCenter and YTop.
- `Pivot.TopLeft` — Start on the left of the X axis, and top on the Y axis. This is a combination of XLeft and YTop.
- `Pivot.TopRight` — Start on the right of the X axis, and top on the Y axis. This is a combination of XRight and YTop.
- `Pivot.XCenter` — On the x axis, the item should be centered.
- `Pivot.XLeft` — On the x axis, this item should start on the left.
- `Pivot.XRight` — On the x axis, this item should start on the right.
- `Pivot.YBottom` — On the y axis, this item should start on the bottom.
- `Pivot.YCenter` — On the y axis, the item should be centered.
- `Pivot.YTop` — On the y axis, this item should start at the top.

## struct Plane

Planes are really useful for collisions, intersections, and visibility testing! This plane is stored using the ax + by + cz + d = 0 formula, where the normal is a,b,c, and the d is, well, d.

- `float Plane.d` — The distance/travel along the plane's normal from the origin to the surface of the plane.
- `Vec3 Plane.normal` — The direction the plane is facing.
- `Plane Plane.p` — The internal, wrapped System.Numerics type. This can be nice to have around so you can pass its fields as 'ref', which you can't do with properties. You won't often need this, as implicit conversions to System.Numerics types are also provided.
- `void Plane(Vec3 normal, float d)` — Creates a Plane directly from the ax + by + cz + d = 0 formula!
  - `normal` — Direction the plane is facing.
  - `d` — Distance along the normal from the origin to the surface of the plane.
- `void Plane(Vec3 pointOnPlane, Vec3 planeNormal)` — Creates a plane from a normal, and any point on the plane!
  - `pointOnPlane` — Any point directly on the surface of the plane.
  - `planeNormal` — Direction the plane is facing.
- `void Plane(Vec3 pointOnPlane1, Vec3 pointOnPlane2, Vec3 pointOnPlane3)` — Creates a plane from 3 points that are directly on that plane.
  - `pointOnPlane1` — First point on the plane.
  - `pointOnPlane2` — Second point on the plane.
  - `pointOnPlane3` — Third point on the plane.
- `Vec3 Plane.Closest(Vec3 to)` — Finds the closest point on this plane to the given point!
  - `to` — The point you have that's not necessarily on the plane.
  - returns — The point on the plane that's closest to the 'to' parameter.
- `static Plane Plane.FromPoint(Vec3 pointOnPlane, Vec3 planeNormal)` — Creates a plane from a normal, and any point on the plane!
  - `pointOnPlane` — Any point directly on the surface of the plane.
  - `planeNormal` — Direction the plane is facing.
  - returns — A plane that contains pointOnPlane, and faces planeNormal.
- `static Plane Plane.FromPoints(Vec3 pointOnPlane1, Vec3 pointOnPlane2, Vec3 pointOnPlane3)` — Creates a plane from 3 points that are directly on that plane.
  - `pointOnPlane1` — First point on the plane.
  - `pointOnPlane2` — Second point on the plane.
  - `pointOnPlane3` — Third point on the plane.
  - returns — A plane that contains all three points.
- `bool Plane.Intersect(Ray ray, Vec3& at)` — Checks the intersection of a ray with this plane!
  - `ray` — Ray we're checking with.
  - `at` — An out parameter that will hold the intersection point. If there's no intersection, this will be (0,0,0).
  - returns — True if there's an intersection, false if not. Refer to the 'at' parameter for intersection information!
- `bool Plane.Intersect(Vec3 lineStart, Vec3 lineEnd, Vec3& at)` — Checks the intersection of a line with this plane!
  - `lineStart` — Start of the line.
  - `lineEnd` — End of the line.
  - `at` — An out parameter that will hold the intersection point. If there's no intersection, this will be (0,0,0).
  - returns — True if there's an intersection, false if not. Refer to the 'at' parameter for intersection information!
- `static Plane Plane.Implicit Conversions(Plane p)` — Implicit conversion from the System.Numerics backing type.
  - `p` — A System.Numerics plane.
  - returns — Returns a copy of the given Plane.
- `static Plane Plane.Implicit Conversions(Plane p)` — Implicit conversion to the System.Numerics backing Plane type.
  - `p` — The StereoKit Plane.
  - returns — Returns a reference of the internal, wrapped Systems.Numerics type.

## static class Platform

This class provides some platform related code that runs cross-platform. You might be able to do many of these things with C#, but you might not be able to do them in as portable a manner as these methods do!

- `static bool Platform.FilePickerVisible` — This will check if the file picker interface is currently visible. Some pickers will never show this, as they block the application until the picker has completed.
- `static bool Platform.ForceFallbackKeyboard` — Force the use of StereoKit's built-in fallback keyboard instead of the system keyboard. This may be great for testing or look and feel matching, but the system keyboard should generally be preferred for accessibility reasons.
- `static bool Platform.KeyboardVisible` — Check if a soft keyboard is currently visible. This may be an OS provided keyboard or StereoKit's fallback keyboard, but will not indicate the presence of a physical keyboard.
- `static void Platform.FilePicker(PickerMode mode, Action`1 onSelectFile, Action onCancel, String[] filters)` — Starts a file picker window! This will create a native file picker window if one is available in the current setup, and if it is not, it'll create a fallback filepicker build using StereoKit's UI. Flatscreen apps will show traditional file pickers, but some platforms may have an OS provided file picker that works in MR. Some pickers will block the system and return right away, but others will stick around and let users continue to interact with the app.
  - `mode` — Are we trying to Open a file, or Save a file? This changes the appearance and behavior of the picker to support the specified action.
  - `onSelectFile` — This Action will be called with the proper filename when the picker has successfully completed! On a cancel or close event, this Action is not called.
  - `onCancel` — If the user cancels the file picker, or the picker is closed via FilePickerClose, this Action is called.
  - `filters` — A list of file extensions that the picker should filter for. This is in the format of ".glb" and is case insensitive.
- `static void Platform.FilePicker(PickerMode mode, Action`2 onComplete, String[] filters)` — Starts a file picker window! This will create a native file picker window if one is available in the current setup, and if it is not, it'll create a fallback filepicker build using StereoKit's UI. Flatscreen apps will show traditional file pickers, but some platforms may have an OS provided file picker that works in MR. Some pickers will block the system and return right away, but others will stick around and let users continue to interact with the app.
  - `mode` — Are we trying to Open a file, or Save a file? This changes the appearance and behavior of the picker to support the specified action.
  - `onComplete` — This action will be called when the file picker has finished, either via a cancel event, or from a confirm event. First parameter is a bool, where true indicates the presence of a valid filename, and false indicates a failure or cancel event.
  - `filters` — A list of file extensions that the picker should filter for. This is in the format of ".glb" and is case insensitive.
  - Example: see `Platform.FilePicker` in StereoKit-docs-reference.md
- `static void Platform.FilePickerClose()` — If the picker is visible, this will close it and immediately trigger a cancel event for the active picker.
- `static bool Platform.KeyboardSetLayout(TextContext keyboardType, String[] keyboardLayout)` — Replace the default keyboard type with a custom layout.
  - `keyboardType` — Type of keyboard.
  - `keyboardLayout` — Custom keyboard layout to replace the defualt layout.
  - returns — True if keyboard type was swapped with the provided layout.
- `static void Platform.KeyboardShow(bool show, TextContext inputType)` — Request or hide a soft keyboard for the user to type on. StereoKit will surface OS provided soft keyboards where available, and use a fallback keyboard when not. On systems with physical keyboards, soft keyboards generally will not be shown if the user has interacted with their physical keyboard recently.
  - `show` — Tells whether or not to open or close the soft keyboard.
  - `inputType` — Soft keyboards can change layout to optimize for the type of text that's required. StereoKit will request the soft keyboard layout that most closely represents the TextContext provided.
- `static bool Platform.ReadFile(string filename, String& data)` — Reads the entire contents of the file as a UTF-8 string, taking advantage of any permissions that may have been granted by Platform.FilePicker.
  - `filename` — Path to the file. Not affected by Assets folder path.
  - `data` — A UTF-8 decoded string representing the contents of the file. Will be null on failure.
  - returns — True on success, False on failure.
- `static bool Platform.ReadFile(string filename, Byte[]& data)` — Reads the entire contents of the file as a byte array, taking advantage of any permissions that may have been granted by Platform.FilePicker.
  - `filename` — Path to the file.
  - `data` — A raw byte array representing the contents of the file. Will be null on failure.
  - returns — True on success, False on failure.
  - Example: see `Platform.ReadFile` in StereoKit-docs-reference.md
- `static Byte[] Platform.ReadFileBytes(string filename)` — Reads the entire contents of the file as a byte array, taking advantage of any permissions that may have been granted by Platform.FilePicker. Returns null on failure.
  - `filename` — Path to the file.
  - returns — A raw byte array if successful, null if not.
- `static string Platform.ReadFileText(string filename)` — Reads the entire contents of the file as a UTF-8 string, taking advantage of any permissions that may have been granted by Platform.FilePicker. Returns null on failure.
  - `filename` — Path to the file.
  - returns — A UTF-8 decoded string if successful, null if not.
- `static bool Platform.WriteFile(string filename, string data)` — Writes a UTF-8 text file to the filesystem, taking advantage of any permissions that may have been granted by Platform.FilePicker.
  - `filename` — Path to the new file. Not affected by Assets folder path.
  - `data` — A string to write to the file. This gets converted to a UTF-8 encoding.
  - returns — True on success, False on failure.
- `static bool Platform.WriteFile(string filename, Byte[] data)` — Writes an array of bytes to the filesystem, taking advantage of any permissions that may have been granted by Platform.FilePicker.
  - `filename` — Path to the new file. Not affected by Assets folder path.
  - `data` — An array of bytes to write to the file.
  - returns — True on success, False on failure.
  - Example: see `Platform.WriteFile` in StereoKit-docs-reference.md

## struct Pointer

Pointer is an abstraction of a number of different input sources, and a way to surface input events!

- `Quat Pointer.orientation` — Orientation of the pointer! Since a Ray has no concept of 'up', this can be used to retrieve more orientation information.
- `Pose Pointer.Pose` — Convenience property that turns ray.position and orientation into a Pose.
- `Ray Pointer.ray` — A ray in the direction of the pointer.
- `InputSource Pointer.source` — What input source did this pointer come from? This is a bit-flag that contains input family and capability information.
- `BtnState Pointer.state` — What is the state of the input source's 'button', if it has one?
- `BtnState Pointer.tracked` — Is the pointer source being tracked right now?

## struct Pose

Pose represents a location and orientation in space, excluding scale! CAUTION: the default value of a Pose includes a completely zero Quat, which can cause problems. Use `Pose.Identity` instead of `new Pose()` for creating a default pose.

- `Vec3 Pose.Forward` — Calculates the forward direction from this pose. This is done by multiplying the orientation with Vec3.Forward. Remember that Forward points down the -Z axis!
- `Quat Pose.orientation` — Orientation of the pose, stored as a rotation from Vec3.Forward.
- `Vec3 Pose.position` — Location of the pose.
- `Ray Pose.Ray` — This creates a ray starting at the Pose's position, and pointing in the 'Forward' direction. The Ray direction is a unit vector/normalized.
- `Vec3 Pose.Right` — Calculates the right (+X) direction from this pose. This is done by multiplying the orientation with Vec3.Right.
- `Vec3 Pose.Up` — Calculates the up (+Y) direction from this pose. This is done by multiplying the orientation with Vec3.Up.
- `static Pose Pose.Identity` — A default, empty pose. Positioned at zero, and using Quat.Identity for orientation.
- `void Pose(Vec3 position, Quat orientation)` — Basic initialization constructor! Just copies in the provided values directly.
  - `position` — Location of the pose.
  - `orientation` — Orientation of the pose, stored as a rotation from Vec3.Forward.
- `void Pose(Vec3 position)` — Basic initialization constructor! Just copies in the provided values directly, and uses Identity for the orientation.
  - `position` — Location of the pose.
- `void Pose(float x, float y, float z, Quat orientation)` — Basic initialization constructor! Just copies in the provided values directly.
  - `x` — X location of the pose.
  - `y` — Y location of the pose.
  - `z` — Z location of the pose.
  - `orientation` — Orientation of the pose, stored as a rotation from Vec3.Forward.
- `void Pose(float x, float y, float z)` — Basic initialization constructor! Just copies in the provided values directly, and uses Identity for the orientation.
  - `x` — X location of the pose.
  - `y` — Y location of the pose.
  - `z` — Z location of the pose.
  - Example: see `Pose.Pose` in StereoKit-docs-reference.md
- `static Pose Pose.Lerp(Pose a, Pose b, float percent)` — Interpolates between two poses! It is unclamped, so values outside of (0,1) will extrapolate their position.
  - `a` — Starting pose, or percent == 0
  - `b` — Ending pose, or percent == 1
  - `percent` — A value usually 0->1 that tells the blend between a and b.
  - returns — A new pose, blended between a and b based on percent!
  - Example: see `Pose.Lerp` in StereoKit-docs-reference.md
- `static Pose Pose.LookAt(Vec3 from, Vec3 at)` — Creates a Pose that looks from one location in the direction of another location. This leaves "Up" as the +Y axis.
  - `from` — Starting location.
  - `at` — Lookat location.
  - returns — A pose at position `from`, oriented to look towards `at`.
  - Example: see `Pose.LookAt` in StereoKit-docs-reference.md
- `Matrix Pose.ToMatrix(Vec3 scale)` — Converts this pose into a transform matrix, incorporating a provided scale value.
  - `scale` — A scale vector! Vec3.One would be an identity scale.
  - returns — A Matrix that transforms to the given pose.
- `Matrix Pose.ToMatrix(float scale)` — Converts this pose into a transform matrix, incorporating a provided scale value.
  - `scale` — A uniform scale factor! 1 would be an identity scale.
  - returns — A Matrix that transforms to the given pose.
- `Matrix Pose.ToMatrix()` — Converts this pose into a transform matrix. This can be used to transform points into the space represented by the Pose.
  - returns — A Matrix that transforms to the given pose.
  - Example: see `Pose.ToMatrix` in StereoKit-docs-reference.md
- `Matrix Pose.ToMatrixInv(Vec3 scale)` — Converts this pose into the inverse of the Pose's transform matrix. This can be used to transform points from the space represented by the Pose into world space.
  - `scale` — A scale vector! Vec3.One would be an identity scale.
  - returns — A Matrix that transforms from the given pose.
- `Matrix Pose.ToMatrixInv(float scale)` — Converts this pose into the inverse of the Pose's transform matrix. This can be used to transform points from the space represented by the Pose into world space.
  - `scale` — A scale vector! Vec3.One would be an identity scale.
  - returns — A Matrix that transforms from the given pose.
- `Matrix Pose.ToMatrixInv()` — Converts this pose into the inverse of the Pose's transform matrix. This can be used to transform points from the space represented by the Pose into world space.
  - returns — A Matrix that transforms from the given pose.
- `string Pose.ToString()` — A string representation of the Pose, in the format of "position, Forward". Mostly for debug visualization.
  - returns — A string representation of the Pose, in the format of "position, Forward"

## enum PoseState

A bit-flag describing the tracking state of a pose, with separate bits for position and orientation. The PosAny, RotAny, and Any combinations are handy when you only care if there's tracking at all, and not whether it's directly measured or just an educated guess.

- `PoseState.Any` — Matches any tracking at all, on position or orientation. A pose with no overlap with this is fully lost.
- `PoseState.Lost` — The pose has no tracking at all, neither position nor orientation should be trusted.
- `PoseState.PosAny` — Matches any positional tracking, whether the position is directly known or just inferred.
- `PoseState.PosInferred` — The position isn't directly tracked, but the system has an educated guess for it. For example, a controller's accelerometer can keep dead-reckoning the position for a short time after it leaves optical view.
- `PoseState.PosKnown` — The position is actively tracked by the underlying hardware, to the best of its ability.
- `PoseState.RotAny` — Matches any orientation tracking, whether the orientation is directly known or just inferred.
- `PoseState.RotInferred` — The orientation isn't directly tracked, but the system has an educated guess for it, often from an IMU after the source has left direct view.
- `PoseState.RotKnown` — The orientation is actively tracked by the underlying hardware, to the best of its ability.

## static class PoseStateExtensions

A collection of extension methods for the PoseState enum that makes bit-field checks a little easier.
- `static bool PoseStateExtensions.IsPosInferred(PoseState state)` — Is the position an educated guess rather than directly tracked?
  - returns — True if inferred, false if not.
- `static bool PoseStateExtensions.IsPosKnown(PoseState state)` — Is the position actively tracked by the hardware?
  - returns — True if directly known, false if not.
- `static bool PoseStateExtensions.IsRotInferred(PoseState state)` — Is the orientation an educated guess rather than directly tracked?
  - returns — True if inferred, false if not.
- `static bool PoseStateExtensions.IsRotKnown(PoseState state)` — Is the orientation actively tracked by the hardware?
  - returns — True if directly known, false if not.
- `static bool PoseStateExtensions.IsTracked(PoseState state)` — Is the pose tracked at all, on either position or orientation?
  - returns — True if any tracking is present, false if fully lost.

## enum Projection

The projection mode used by StereoKit for the main camera! You can use this with Renderer.Projection. These options are only available in flatscreen mode, as MR headsets provide very specific projection matrices.

- `Projection.Ortho` — Orthographic projection mode is often used for tools, 2D rendering, thumbnails of 3D objects, or other similar cases. In this mode, parallel lines remain parallel regardless of how far they travel.
- `Projection.Perspective` — This is the default projection mode, and the one you're most likely to be familiar with! This is where parallel lines will converge as they go into the distance.

## struct Quat

Quaternions are efficient and robust mathematical objects for representing rotations! Understanding the details of how a quaternion works is not generally necessary for using them effectively, so don't worry too much if they seem weird to you. They're weird to me too. If you're interested in learning the details though, 3Blue1Brown and Ben Eater have an [excellent interactive lesson](https://eater.net/quaternions) about them!

- `Quat Quat.Inverse` — The reverse rotation! If this quat goes from A to B, the inverse will go from B to A.
- `Quat Quat.Normalized` — A normalized quaternion has the same orientation, and a length of 1.
- `Quaternion Quat.q` — The internal, wrapped System.Numerics type. This can be nice to have around so you can pass its fields as 'ref', which you can't do with properties. You won't often need this, as implicit conversions to System.Numerics types are also provided.
- `Vec4 Quat.Vec4` — Sometimes you want to do weird stuff with your Quaternions. I won't judge. This just turns the Quat into a Vec4, makes some types of math easier!
- `float Quat.w` — W component.
- `float Quat.x` — X component. Sometimes known as I.
- `float Quat.y` — Y component. Sometimes known as J.
- `float Quat.z` — Z component. Sometimes known as K.
- `static Quat Quat.Identity` — This is the 'multiply by one!' of the quaternion rotation world. It's basically a default, no rotation quaternion.
- `void Quat(float x, float y, float z, float w)` — You may want to use static creation methods, like Quat.LookAt, or Quat.Identity instead of this one! Unless you know what you're doing.
  - `x` — X component of the Quat.
  - `y` — Y component of the Quat.
  - `z` — Z component of the Quat.
  - `w` — W component of the Quat.
- `static Quat Quat.Delta(Quat from, Quat to)` — Creates a quaternion that goes from one rotation to another.
  - `from` — The origin rotation.
  - `to` — And the target rotation!
  - returns — The quaternion between from and to.
- `static Quat Quat.Delta(Vec3 from, Vec3 to)` — Creates a rotation that goes from one direction to another. Which is comes in handy when trying to roll something around with position data.
  - `from` — The origin direction.
  - `to` — And the target direction!
  - returns — The quaternion between from and to.
  - Example: see `Quat.Delta` in StereoKit-docs-reference.md
- `static Quat Quat.Difference(Quat a, Quat b)` — This gives a relative rotation between the first and second quaternion rotations. Remember that order is important here!
  - `a` — Starting rotation.
  - `b` — Ending rotation.
  - returns — A rotation that will take a point from rotation a, to rotation b.
- `static Quat Quat.FromAngles(float pitchXDeg, float yawYDeg, float rollZDeg)` — Creates a Roll/Pitch/Yaw rotation (applied in that order) from the provided angles in degrees!
  - `pitchXDeg` — Pitch is rotation around the x axis, measured in degrees.
  - `yawYDeg` — Yaw is rotation around the y axis, measured in degrees.
  - `rollZDeg` — Roll is rotation around the z axis, measured in degrees.
  - returns — A quaternion representing the given Roll/Pitch/Yaw rotation!
- `static Quat Quat.FromAngles(Vec3 pitchYawRollDeg)` — Creates a Roll/Pitch/Yaw rotation (applied in that order) from the provided angles in degrees!
  - `pitchYawRollDeg` — Pitch, yaw, and roll stored as X, Y, and Z in this Vector. Angle values are in degrees.
  - returns — A quaternion representing the given Roll/Pitch/Yaw rotation!
- `void Quat.Invert()` — Makes this Quat the reverse rotation! If this quat goes from A to B, the inverse will go from B to A.
  - returns — The inverse quaternion.
- `static Quat Quat.LookAt(Vec3 lookFromPoint, Vec3 lookAtPoint, Vec3 upDirection)` — Creates a rotation that describes looking from a point, to another point! This is a great function for camera style rotation, or other facing behavior when you know where an object is, and where you want it to look at. This rotation works best when applied to objects that face Vec3.Forward in their resting/model space pose.
  - `lookFromPoint` — Position of where the 'object' is.
  - `lookAtPoint` — Position of where the 'object' should be looking towards!
  - `upDirection` — Look From/At positions describe X and Y axis rotation well, but leave Z Axis/Roll undefined. Providing an upDirection vector helps to indicate roll around the From/At line. A common up direction would be (0,1,0), to prevent roll.
  - returns — A rotation that describes looking from a point, towards another point.
- `static Quat Quat.LookAt(Vec3 lookFromPoint, Vec3 lookAtPoint)` — Creates a rotation that describes looking from a point, to another point! This is a great function for camera style rotation, or other facing behavior when you know where an object is, and where you want it to look at. This rotation works best when applied to objects that face Vec3.Forward in their resting/model space pose. This overload automatically defines 'upDirection' as (0,1,0). This indicates the rotation should contain no roll around the Z axis, and is the most common way of using this type of rotation.
  - `lookFromPoint` — Position of where the 'object' is.
  - `lookAtPoint` — Position of where the 'object' should be looking towards!
  - returns — A rotation that describes looking from a point, towards another point.
  - Example: see `Quat.LookAt` in StereoKit-docs-reference.md
- `static Quat Quat.LookDir(Vec3 direction)` — Creates a rotation that describes looking towards a direction. This is great for quickly describing facing behavior! This rotation works best when applied to objects that face Vec3.Forward in their resting/model space pose.
  - `direction` — Direction the rotation should be looking. Doesn't need to be normalized.
  - returns — A rotation that describes looking towards a direction.
- `static Quat Quat.LookDir(float x, float y, float z)` — Creates a rotation that describes looking towards a direction. This is great for quickly describing facing behavior! This rotation works best when applied to objects that face Vec3.Forward in their resting/model space pose.
  - `x` — X component of the direction the rotation should be looking. Doesn't need to be normalized.
  - `y` — Y component of the direction the rotation should be looking. Doesn't need to be normalized.
  - `z` — Z component of the direction the rotation should be looking. Doesn't need to be normalized.
  - returns — A rotation that describes looking towards a direction.
- `void Quat.Normalize()` — A normalized quaternion has the same orientation, and a length of 1.
- `static Quat Quat.Implicit Conversions(Quaternion q)` — Allows implicit conversion from System.Numerics.Quaternion to StereoKit.Quat.
  - `q` — Any System.Numerics Quaternion.
  - returns — A StereoKit compatible quaternion.
- `static Quaternion Quat.Implicit Conversions(Quat q)` — Allows implicit conversion from StereoKit.Quat to System.Numerics.Quaternion
  - `q` — Any StereoKit.Quat.
  - returns — A System.Numerics compatible quaternion.
- `static Quat Quat.*(Quat a, Quat b)` — This is the combination of rotations `a` and `b`. Note that order matters here.
  - `a` — First Quat.
  - `b` — Second Quat.
  - returns — A multiplication of the two Quats.
- `static Vec3 Quat.*(Quat a, Vec3 pt)` — This rotates a point around the origin by the Quat.
  - `a` — The rotation Quat.
  - `pt` — The point that gets rotated around the origin.
  - returns — A rotated point.
- `static Vec3 Quat.*(Vec3 pt, Quat a)` — This rotates a point around the origin by the Quat.
  - `a` — The rotation Quat.
  - `pt` — The point that gets rotated around the origin.
  - returns — A rotated point.
- `static Quat Quat.-(Quat a, Quat b)` — Gets a Quat representing the rotation from `a` to `b`.
  - `a` — Starting Quat.
  - `b` — Ending Quat.
  - returns — A rotation Quat from `a` to `b`.
- `Quat Quat.Relative(Quat to)` — Rotates a quaternion making it relative to another rotation while preserving it's "Length"!
  - `to` — The relative quaternion.
  - returns — This quaternion made relative to another rotation.
- `Vec3 Quat.Rotate(Vec3 pt)` — This rotates a point around the origin by the Quat.
  - `pt` — The point that gets rotated around the origin.
  - returns — A rotated point.
- `static Vec3 Quat.Rotate(Quat q, Vec3 pt)` — This rotates a point around the origin by the Quat.
  - `q` — The rotation Quat.
  - `pt` — The point that gets rotated around the origin.
  - returns — A rotated point.
- `static Quat Quat.Slerp(Quat a, Quat b, float slerp)` — Spherical Linear intERPolation. Interpolates between two quaternions! Both Quats should be normalized/unit quaternions, or you may get unexpected results.
  - `a` — Start quaternion, should be normalized/unit length.
  - `b` — End quaternion, should be normalized/unit length.
  - `slerp` — The interpolation amount! This'll be a if 0, and b if 1. Unclamped.
  - returns — A blend between the two quaternions!
- `string Quat.ToString()` — Mostly for debug purposes, this is a decent way to log or inspect the quaternion in debug mode. Looks like "[x, y, z, w]"
  - returns — A string that looks like "[x, y, z, w]"

## enum QuitReason

Provides a reason on why StereoKit has quit.

- `QuitReason.Error` — Some runtime error occurred, causing the application to quit gracefully.
- `QuitReason.InitializationFailed` — If initialization failed, StereoKit won't run to begin with!
- `QuitReason.None` — Default state when SK has not quit.
- `QuitReason.SessionLost` — The runtime under StereoKit has encountered an issue and has been lost.
- `QuitReason.User` — The user (or possibly the OS) has explicitly asked to exit the application under normal circumstances.

## struct Ray

A position and a direction indicating a ray through space! This is a great tool for intersection testing with geometrical shapes.

- `Vec3 Ray.direction` — The direction the ray is facing, typically does not require being a unit vector, or normalized direction.
- `Vec3 Ray.position` — The position or origin point of the Ray.
- `void Ray(Vec3 position, Vec3 direction)` — Basic initialization constructor! Just copies the parameters into the fields.
  - `position` — The position or origin point of the Ray.
  - `direction` — The direction the ray is facing, typically does not require being a unit vector, or normalized direction.
- `Vec3 Ray.At(float percent)` — Gets a point along the ray! This is basically just position + direction*percent. If Ray.direction is normalized, then percent is functionally distance, and can be used to find the point a certain distance out along the ray.
  - `percent` — How far along the ray should we get the point at? This is in multiples of Ray.direction's magnitude. If Ray.direction is normalized, this is functionally the distance.
  - returns — The point at position + direction*percent.
- `Vec3 Ray.Closest(Vec3 to)` — Calculates the point on the Ray that's closest to the given point! This will be clamped if the point is behind the ray's origin.
  - `to` — Any point in the same coordinate space as the Ray.
  - returns — The point on the ray that's closest to the given point.
- `static Ray Ray.FromTo(Vec3 a, Vec3 b)` — A convenience function that creates a ray from point a, towards point b. Resulting direction is not normalized.
  - `a` — Ray starting point.
  - `b` — Location the ray is pointing towards.
  - returns — A ray from point a to point b. Not normalized.
- `bool Ray.Intersect(Plane plane, Vec3& at)` — Checks the intersection of this ray with a plane!
  - `plane` — Any plane you want to intersect with.
  - `at` — An out parameter that will hold the intersection point. If there's no intersection, this will be (0,0,0).
  - returns — True if there's an intersection, false if not. Refer to the 'at' parameter for intersection information!
- `bool Ray.Intersect(Sphere sphere, Vec3& at)` — Checks the intersection of this ray with a sphere!
  - `sphere` — Any Sphere you want to intersect with.
  - `at` — An out parameter that will hold the closest intersection point to the ray's origin. If there's no intersection, this will be (0,0,0).
  - returns — True if intersection occurs, false if it doesn't. Refer to the 'at' parameter for intersection information!
- `bool Ray.Intersect(Bounds bounds, Vec3& at)` — Checks the intersection of this ray with a bounding box!
  - `bounds` — Any Bounds you want to intersect with.
  - `at` — If the return is true, this point will be the closest intersection point to the origin of the Ray. If there's no intersection, this will be (0,0,0).
  - returns — True if intersection occurs, false if it doesn't. Refer to the 'at' parameter for intersection information!
- `bool Ray.Intersect(Mesh mesh, Ray& modelSpaceAt)` — Checks the intersection point of this ray and a Mesh with collision data stored on the CPU. A mesh without collision data will always return false. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `mesh` — A mesh containing collision data on the CPU. You can check this with Mesh.KeepData.
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - returns — True if an intersection occurs, false otherwise!
- `bool Ray.Intersect(Mesh mesh, Cull cullFaces, Ray& modelSpaceAt)` — Checks the intersection point of this ray and a Mesh with collision data stored on the CPU. A mesh without collision data will always return false. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `mesh` — A mesh containing collision data on the CPU. You can check this with Mesh.KeepData.
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - `cullFaces` — How should intersection work with respect to the direction the triangles are facing? Should we skip triangles that are facing away from the ray, or don't skip anything? A good default would be Cull.Back.
  - returns — True if an intersection occurs, false otherwise!
- `bool Ray.Intersect(Mesh mesh, Cull cullFaces, Ray& modelSpaceAt, UInt32& outStartInds)` — Checks the intersection point of this ray and a Mesh with collision data stored on the CPU. A mesh without collision data will always return false. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `mesh` — A mesh containing collision data on the CPU. You can check this with Mesh.KeepData.
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - `outStartInds` — The index of the first index of the triangle that was hit
  - `cullFaces` — How should intersection work with respect to the direction the triangles are facing? Should we skip triangles that are facing away from the ray, or don't skip anything? A good default would be Cull.Back.
  - returns — True if an intersection occurs, false otherwise!
- `bool Ray.Intersect(Mesh mesh, Vec3& modelSpaceAt)` — Checks the intersection point of this ray and a Mesh with collision data stored on the CPU. A mesh without collision data will always return false. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the point into model space, see the example in the docs!
  - `mesh` — A mesh containing collision data on the CPU. You can check this with Mesh.KeepData.
  - `modelSpaceAt` — The intersection point of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later.
  - returns — True if an intersection occurs, false otherwise!
- `bool Ray.Intersect(Model model, Ray& modelSpaceAt)` — Checks the intersection point of this ray and the Solid flagged Meshes in the Model's visual nodes. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `model` — Any Model that may or may not contain Solid flagged nodes, and Meshes with collision data.
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - returns — True if an intersection occurs, false otherwise!
- `bool Ray.Intersect(Model model, Cull cullFaces, Ray& modelSpaceAt)` — Checks the intersection point of this ray and the Solid flagged Meshes in the Model's visual nodes. Ray must be in model space, intersection point will be in model space too. You can use the inverse of the mesh's world transform matrix to bring the ray into model space, see the example in the docs!
  - `model` — Any Model that may or may not contain Solid flagged nodes, and Meshes with collision data.
  - `modelSpaceAt` — The intersection point and surface direction of the ray and the mesh, if an intersection occurs. This is in model space, and must be transformed back into world space later. Direction is not guaranteed to be normalized, especially if your own model->world transform contains scale/skew in it.
  - `cullFaces` — How should intersection work with respect to the direction the triangles are facing? Should we skip triangles that are facing away from the ray, or don't skip anything? A good default would be Cull.Back.
  - returns — True if an intersection occurs, false otherwise!
  - Example: see `Ray.Intersect` in StereoKit-docs-reference.md
- `string Ray.ToString()` — Mostly for debug purposes, this is a decent way to log or inspect the Ray in debug mode. Looks like "[position], [direction]"
  - returns — A string that looks like "[position], [direction]"

## struct Rect

A pretty straightforward 2D rectangle, defined by the top left corner of the rectangle, and its width/height.

- `float Rect.height` — The height of the rectangle.
- `float Rect.width` — The width of the rectangle.
- `float Rect.x` — The X axis position of the top left corner of the rectangle.
- `float Rect.y` — The Y axis position of the top left corner of the rectangle.
- `void Rect(float x, float y, float width, float height)` — Create a 2D rectangle, defined by the top left  corner of the rectangle, and its width/height.
  - `x` — The X axis position of the top left corner of the rectangle.
  - `y` — The Y axis position of the top left corner of the rectangle.
  - `width` — The width of the rectangle.
  - `height` — The height of the rectangle.

## enum RenderClear

When rendering to a rendertarget, this tells if and what of the rendertarget gets cleared before rendering. For example, if you are assembling a sheet of images, you may want to clear everything on the first image draw, but not clear on subsequent draws.

- `RenderClear.All` — Clear both color and depth data. A zero value also means this - it's the default, so zero-initialized settings clear everything.
- `RenderClear.Color` — Clear the rendertarget's color data.
- `RenderClear.Depth` — Clear the rendertarget's depth data, if present.
- `RenderClear.Keep` — Don't clear anything, draw on top of what's already there.
- `RenderClear.None` — Deprecated, use render_clear_keep.

## static class Renderer

Do you need to draw something? Well, you're probably in the right place! This static class includes a variety of different drawing methods, from rendering Models and Meshes, to setting rendering options and drawing to offscreen surfaces! Even better, it's entirely a static class, so you can call it from anywhere :)

- `static Matrix Renderer.CameraRoot` — Sets and gets the root transform of the camera! This will be the identity matrix by default. The user's head  location will then be relative to this point. This is great to use if you're trying to do teleportation, redirected walking, or just shifting the floor around.
- `static RenderLayer Renderer.CaptureFilter` — This is the current render layer mask for Mixed Reality Capture, or 2nd person observer rendering. By default, this is directly linked to Renderer.LayerFilter, but this behavior can be overridden via `Renderer.OverrideCaptureFilter`.
- `static Color Renderer.ClearColor` — This is the gamma space color the renderer will clear the screen to when beginning to draw a new frame.
- `static bool Renderer.EnableSky` — Enables or disables rendering of the skybox texture! It's enabled by default on Opaque displays, and completely unavailable for transparent displays.
- `static float Renderer.FOV` — Only works for 2D windowed modes! This updates the camera's projection matrix with a new vertical field of view. This value only affects perspective mode projection, which is the default projection mode.
- `static bool Renderer.HasCaptureFilter` — This tells if CaptureFilter has been overridden to a specific value via `Renderer.OverrideCaptureFilter`.
- `static RenderLayer Renderer.LayerFilter` — By default, StereoKit renders all first-person layers. This is a bit flag that allows you to change which layers StereoKit renders for the primary viewpoint. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter.
- `static int Renderer.Multisample` — Allows you to set the multisample (MSAA) level of the render surface. Valid values are 1, 2, 4, and 8, though this is clamped to what the GPU actually supports. Note that while this can greatly smooth out edges, it also increases RAM usage and fill rate. How much it costs depends a lot on the GPU! Tiled renderers, like the mobile chips in most standalone XR headsets, resolve MSAA in tile memory, which makes it nearly free. Desktop GPUs instead pay memory bandwidth for the multisampled surface and for resolving it, so MSAA is far more expensive there, especially at high resolutions. A value of 1 skips the multisampled surface entirely. If known in advance, set this via SKSettings in initialization. This is a _very_ costly change to make. Defaults to 4.
- `static float Renderer.OrthoSize` — This sets the size of the orthographic projection's viewport. You can use this feature to zoom in and out of the scene. This value only affects orthographic mode projection, which is only available in 2D window modes.
- `static Projection Renderer.Projection` — For flatscreen applications only! This allows you to change the camera projection between perspective and orthographic projection. This may be of interest for some category of UI work, but is generally a niche piece of functionality. Swapping between perspective and orthographic will also switch the clipping planes and field of view to the values associated with that mode. See `SetClip`/`SetFov` for perspective, and `SetOrthoClip`/`SetOrthoSize` for orthographic.
- `static float Renderer.Scaling` — OpenXR has a recommended default for the main render surface, this variable allows you to set SK's surface to a multiple of the recommended size. Note that the final resolution may also be clamped or quantized. Only works in XR mode. If known in advance, set this via SKSettings in initialization. This is a _very_ costly change to make. Consider if ViewportScaling will work for you instead, and prefer that.
- `static SphericalHarmonics Renderer.SkyLight` — Sets the lighting information for the scene! You can build one through `SphericalHarmonics.FromLights`, or grab one from `Tex.FromEquirectangular` or `Tex.GenCubemap`
- `static Material Renderer.SkyMaterial` — This is the Material that StereoKit is currently using to draw the skybox! It needs a special shader that's tuned for a full-screen quad. If you just want to change the skybox image, try setting `Renderer.SkyTex` instead. This value will never be null! If you try setting this to null, it will assign SK's built-in default sky material. If you want to turn off the skybox, see `Renderer.EnableSky` instead. Recommended Material settings would be: - DepthWrite: false - DepthTest: LessOrEq - QueueOffset: 100
- `static Tex Renderer.SkyTex` — Set a cubemap skybox texture for rendering a background! This is only visible on Opaque displays, since transparent displays have the real world behind them already! StereoKit has a a default procedurally generated skybox. You can load one with `Tex.FromEquirectangular`, `Tex.GenCubemap`. If you're trying to affect the lighting, see `Renderer.SkyLight`.
- `static float Renderer.ViewportScaling` — This allows you to trivially scale down the area of the swapchain that StereoKit renders to! This can be used to boost performance in situations where full resolution is not needed, or to reduce GPU time. This value is locked to the 0-1 range.
- `static void Renderer.Add(Mesh mesh, Material material, Matrix transform)` — Adds a mesh to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `mesh` — A valid Mesh you wish to draw.
  - `material` — A Material to apply to the Mesh.
  - `transform` — A Matrix that will transform the mesh from Model Space into the current Hierarchy Space.
- `static void Renderer.Add(Mesh mesh, Material material, Matrix transform, Color colorLinear, RenderLayer layer)` — Adds a mesh to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `mesh` — A valid Mesh you wish to draw.
  - `material` — A Material to apply to the Mesh.
  - `transform` — A Matrix that will transform the mesh from Model Space into the current Hierarchy Space.
  - `colorLinear` — A per-instance linear space color value to pass into the shader! Normally this gets used like a material tint. If you're  adventurous and don't need per-instance colors, this is a great spot to pack in extra per-instance data for the shader!
  - `layer` — All visuals are rendered using a layer bit-flag. By default, all layers are rendered, but this can be useful for filtering out objects for different rendering purposes! For example: rendering a mesh over the user's head from a 3rd person perspective, but filtering it out from the 1st person perspective.
- `static void Renderer.Add(Model model, Matrix transform)` — Adds a Model to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `model` — A valid Model you wish to draw.
  - `transform` — A Matrix that will transform the Model from Model Space into the current Hierarchy Space.
- `static void Renderer.Add(Model model, Matrix transform, Color colorLinear, RenderLayer layer)` — Adds a Model to the render queue for this frame! If the Hierarchy has a transform on it, that transform is combined with the Matrix provided here.
  - `model` — A valid Model you wish to draw.
  - `transform` — A Matrix that will transform the Model from Model Space into the current Hierarchy Space.
  - `colorLinear` — A per-instance linear space color value to pass into the shader! Normally this gets used like a material tint. If you're  adventurous and don't need per-instance colors, this is a great spot to pack in extra per-instance data for the shader!
  - `layer` — All visuals are rendered using a layer bit-flag. By default, all layers are rendered, but this can be useful for filtering out objects for different rendering purposes! For example: rendering a mesh over the user's head from a 3rd person perspective, but filtering it out from the 1st person perspective.
- `static void Renderer.Blit(Tex toRendertarget, Material material)` — Renders a Material onto a rendertarget texture! StereoKit uses a 4 vert quad stretched over the surface of the texture, and renders the material onto it to the texture.
  - `toRendertarget` — A texture that's been set up as a render target!
  - `material` — This material is rendered onto the texture! Set it up like you would if you were applying it to a plane, or quad mesh.
- `static void Renderer.GetClip(Single& nearPlane, Single& farPlane)` — This retrieves the current near and far clipping planes for the perspective matrix of the primary draw surface.
  - `nearPlane` — The GPU discards pixels that are too close to the camera, this is that distance! It will be larger than zero, due to the projection math, which also means that numbers too close to zero will produce z-fighting artifacts. This has an enforced minimum of 0.001, but will probably be closer to 0.1.
  - `farPlane` — At what distance from the camera does the GPU discard pixel? This is not true distance, but rather Z-axis distance from zero in View Space coordinates!
- `static float Renderer.GetFOV()` — Only works for 2D windowed modes! This retrieves the vertical field of view of the camera's projection matrix when in perspective projection mode.
  - returns — The vertical field of view in degrees.
- `static float Renderer.GetOrthoSize()` — This retrieves the size the primary render surface's view when using orthographic projection mode.
  - returns — The vertical size of the projection's viewport, in meters.
- `static void Renderer.OverrideCaptureFilter(bool useOverrideFilter, RenderLayer overrideFilter)` — The CaptureFilter is a layer mask for Mixed Reality Capture, or 2nd person observer rendering. On HoloLens and WMR, this is the video rendering feature. This allows you to hide, or reveal certain draw calls when rendering video output. By default, the CaptureFilter will always be the same as `Render.LayerFilter`, overriding this will mean this filter no longer updates with `LayerFilter`.
  - `useOverrideFilter` — Enables (true) or disables (false) the overridden filter value provided here.
  - `overrideFilter` — The filter for capture rendering to use. This is ignored if useOverrideFilter is false.
- `static void Renderer.RenderTo(Tex toRendertarget, Matrix camera, Matrix projection, RenderLayer layerFilter, int materialVariant, RenderClear clear, Rect viewport)` — This renders the current scene to the indicated rendertarget texture, from the specified viewpoint. This call enqueues a render that occurs immediately before the screen itself is rendered.
  - `toRendertarget` — The texture to which the scene will be rendered to. This must be a Rendertarget type texture.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `layerFilter` — This is a bit flag that allows you to change which layers StereoKit renders for this particular render viewpoint. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter.
  - `materialVariant` — Specifies which Material variant should be used for rendering. 0 will be the normal default material, any others will generally be application-defined by setting up each Material's Variant with specific shaders. If a Material has no corresponding variant, it will not be drawn.
  - `clear` — Describes if and how the rendertarget should be cleared before rendering. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!
  - `viewport` — Allows you to specify a region of the rendertarget to draw to! This is in normalized coordinates, 0-1. If the width of this value is zero, then this will render to the entire texture.
- `static void Renderer.RenderTo(Tex toRendertarget, int toTargetIndex, Matrix camera, Matrix projection, RenderLayer layerFilter, int materialVariant, RenderClear clear, Rect viewport)` — This renders the current scene to the indicated rendertarget texture, from the specified viewpoint. This call enqueues a render that occurs immediately before the screen itself is rendered.
  - `toRendertarget` — The texture to which the scene will be rendered to. This must be a Rendertarget type texture.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `layerFilter` — This is a bit flag that allows you to change which layers StereoKit renders for this particular render viewpoint. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter.
  - `materialVariant` — Specifies which Material variant should be used for rendering. 0 will be the normal default material, any others will generally be application-defined by setting up each Material's Variant with specific shaders. If a Material has no corresponding variant, it will not be drawn.
  - `clear` — Describes if and how the rendertarget should be cleared before rendering. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!
  - `viewport` — Allows you to specify a region of the rendertarget to draw to! This is in normalized coordinates, 0-1. If the width of this value is zero, then this will render to the entire texture.
  - `toTargetIndex` — Index of the render target's array texture we want to draw to.
- `static void Renderer.RenderTo(Tex toRendertarget, Matrix camera, Matrix projection, RenderSettings settings)` — This renders the current scene to the indicated rendertarget texture from the specified viewpoint, using a RenderSettings struct for everything else - including tile-friendly post-processing effects! This call enqueues a render that occurs immediately before the screen itself is rendered.
  - `toRendertarget` — The texture to which the scene will be rendered to. This must be a Rendertarget type texture.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `settings` — Settings for this render pass, a `default` here means all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.
- `static void Renderer.RenderTo(Tex toRendertarget, int toTargetIndex, Matrix camera, Matrix projection, RenderSettings settings)` — This renders the current scene to the indicated rendertarget texture from the specified viewpoint, using a RenderSettings struct for everything else - including tile-friendly post-processing effects! This call enqueues a render that occurs immediately before the screen itself is rendered.
  - `toRendertarget` — The texture to which the scene will be rendered to. This must be a Rendertarget type texture.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `settings` — Settings for this render pass, a `default` here means all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.
  - `toTargetIndex` — Index of the render target's array texture we want to draw to.
- `static void Renderer.RenderTo(Tex toRendertarget, Matrix[]& cameras, Matrix[]& projections, RenderLayer layerFilter, int materialVariant, RenderClear clear, Rect viewport)` — Multi-view variant of RenderTo. Queues a single render pass that draws the active list into N views at once, with one camera + projection per view, writing into N consecutive layers of an array rendertarget. The number of views is capped by the engine's max-views constant. Like the single-view RenderTo, this is queued for the next pipeline frame.
  - `toRendertarget` — An array or cubemap rendertarget with at least `cameras.Length` layers.
  - `cameras` — View transforms, one per view.
  - `projections` — Projection matrices, one per view. Length must match `cameras`.
  - `layerFilter` — Bit flag for which render layers to include this pass.
  - `materialVariant` — Which material variant to use.
  - `clear` — Whether and how to clear the rendertarget.
  - `viewport` — Subregion in normalized 0-1 coordinates.
- `static void Renderer.RenderTo(Tex toRendertarget, Matrix[]& cameras, Matrix[]& projections, RenderSettings settings)` — This renders the current scene to the indicated rendertarget texture from the specified viewpoint, using a RenderSettings struct for everything else - including tile-friendly post-processing effects! This call enqueues a render that occurs immediately before the screen itself is rendered.
  - `toRendertarget` — The texture to which the scene will be rendered to. This must be a Rendertarget type texture.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `settings` — Settings for this render pass, a `default` here means all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.
  - `cameras` — View transforms, one per view.
  - `projections` — Projection matrices, one per view. Length must match `cameras`.
  - Example: see `Renderer.RenderTo` in StereoKit-docs-reference.md
- `static void Renderer.Screenshot(string filename, Vec3 from, Vec3 at, int width, int height, float fieldOfViewDegrees)` — Schedules a screenshot for the end of the frame! The view will be rendered from the given position at the given point, with a resolution the same size as the screen's surface. It'll be saved as a JPEG or PNG file depending on the filename extension provided.
  - `filename` — Filename to write the screenshot to! This will be a PNG if the extension ends with (case insensitive) ".png", and will be a 90 quality JPEG if it ends with anything else.
  - `from` — Viewpoint location.
  - `at` — Direction the viewpoint is looking at.
  - `width` — Size of the screenshot horizontally, in pixels.
  - `height` — Size of the screenshot vertically, in pixels.
  - `fieldOfViewDegrees` — The angle of the viewport, in degrees.
- `static void Renderer.Screenshot(string filename, int fileQuality, Pose viewpoint, int width, int height, float fieldOfViewDegrees)` — Schedules a screenshot for the end of the frame! The view will be rendered from the given pose, with a resolution the same size as the screen's surface. It'll be saved as a JPEG or PNG file depending on the filename extension provided.
  - `filename` — Filename to write the screenshot to! This will be a PNG if the extension ends with (case insensitive) ".png", and will be a JPEG if it ends with anything else.
  - `fileQuality` — For JPEG files, this is the compression quality of the file from 0-100, 100 being highest quality, 0 being smallest size. SK uses a default of 90 here.
  - `viewpoint` — Viewpoint location and orientation.
  - `width` — Size of the screenshot horizontally, in pixels.
  - `height` — Size of the screenshot vertically, in pixels.
  - `fieldOfViewDegrees` — The angle of the viewport, in degrees.
- `static void Renderer.Screenshot(string filename, Pose viewpoint, int width, int height, float fieldOfViewDegrees)` — Schedules a screenshot for the end of the frame! The view will be rendered from the given pose, with a resolution the same size as the screen's surface. It'll be saved as a JPEG or PNG file depending on the filename extension provided.
  - `filename` — Filename to write the screenshot to! This will be a PNG if the extension ends with (case insensitive) ".png", and will be a 90 quality JPEG if it ends with anything else.
  - `viewpoint` — Viewpoint location and orientation.
  - `width` — Size of the screenshot horizontally, in pixels.
  - `height` — Size of the screenshot vertically, in pixels.
  - `fieldOfViewDegrees` — The angle of the viewport, in degrees.
- `static void Renderer.Screenshot(ScreenshotCallback onScreenshot, Vec3 from, Vec3 at, int width, int height, float fieldOfViewDegrees, TexFormat texFormat)` — Schedules a screenshot for the end of the frame! The view will be rendered from the given position at the given point, with a resolution the same size as the screen's surface. This overload allows for retrieval of the color data directly from the render thread! You can use the color data directly by saving/processing it inside your callback, or you can keep the data alive for as long as it is referenced.
  - `onScreenshot` — A callback that receives the captured pixel data, its format, and its dimensions for the requested viewpoint.
  - `from` — Viewpoint location.
  - `at` — Direction the viewpoint is looking at.
  - `width` — Size of the screenshot horizontally, in pixels.
  - `height` — Size of the screenshot vertically, in pixels.
  - `fieldOfViewDegrees` — The angle of the viewport, in degrees.
  - `texFormat` — The pixel format of the color data.
- `static void Renderer.Screenshot(ScreenshotCallback onScreenshot, Matrix camera, Matrix projection, int width, int height, RenderLayer layerFilter, RenderClear clear, Rect viewport, TexFormat texFormat)` — Schedules a screenshot for the end of the frame! The view will be rendered from the given position at the given point, with a resolution the same size as the screen's surface. This overload allows for retrieval of the color data directly from the render thread! You can use the color data directly by saving/processing it inside your callback, or you can keep the data alive for as long as it is referenced.
  - `onScreenshot` — A callback that receives the captured pixel data, its format, and its dimensions for the requested viewpoint.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `layerFilter` — This is a bit flag that allows you to change which layers StereoKit renders for this particular render viewpoint. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter.
  - `clear` — Describes if and how the rendertarget should be cleared before rendering. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!
  - `texFormat` — The pixel format of the color data.
- `static void Renderer.SetClip(float nearPlane, float farPlane)` — Set the near and far clipping planes of the camera! These are important to z-buffer quality, especially when using low bit depth z-buffers as recommended for devices like the HoloLens. The smaller the range between the near and far planes, the better your z-buffer will look! If you see flickering on objects that are overlapping, try making the range smaller. These values only affect perspective mode projection, which is the default projection mode.
  - `nearPlane` — The GPU discards pixels that are too close to the camera, this is that distance! It must be larger than zero, due to the projection math, which also means that numbers too close to zero will produce z-fighting artifacts. This has an enforced minimum of 0.001, but you should probably stay closer to 0.1.
  - `farPlane` — At what distance from the camera does the GPU discard pixel? This is not true distance, but rather Z-axis distance from zero in View Space coordinates!
- `static void Renderer.SetFOV(float verticalFieldOfViewDegrees)` — Only works for 2D windowed modes! This updates the camera's projection matrix with a new vertical field of view. This value only affects perspective mode projection, which is the default projection mode.
  - `verticalFieldOfViewDegrees` — Vertical field of view in degrees.
- `static void Renderer.SetGlobalBuffer(int bufferRegister, Object buffer)` — This attaches a buffer resource globally across all shaders. StereoKit uses this to attach the stereokit rendering constants. It can be used for things like shadowmaps, wind data, etc.
  - `bufferRegister` — Valid values are 3-16. This is the register id that this data will be bound to. In HLSL, you'll see the slot id for '3' indicated like this `: register(b3)`
  - `buffer` — The data buffer you would like to bind, or null to unbind.
- `static void Renderer.SetGlobalBuffer(int bufferRegister, Object buffer)` — This attaches a buffer resource globally across all shaders. StereoKit uses this to attach the stereokit rendering constants. It can be used for things like shadowmaps, wind data, etc.
  - `bufferRegister` — Valid values are 3-16. This is the register id that this data will be bound to. In HLSL, you'll see the slot id for '3' indicated like this `: register(b3)`
  - `buffer` — The data buffer you would like to bind, or null to unbind.
- `static void Renderer.SetGlobalTexture(int textureRegister, Tex tex)` — This attaches a texture resource globally across all shaders. StereoKit uses this to attach the sky cubemap for use in reflections across all materials (register 11). It can be used for things like shadowmaps, wind data, etc. Prefer a higher registers (11+) to prevent conflicting with normal Material textures.
  - `textureRegister` — The texture resource register the texture will bind to. SK uses register 11 already, so values above that should be fine.
  - `tex` — The texture to assign globally. Setting null here will clear any texture that is currently bound.
- `static void Renderer.SetOrthoClip(float nearPlane, float farPlane)` — Set the near and far clipping planes of the camera! These are important to z-buffer quality, especially when using low bit depth z-buffers as recommended for devices like the HoloLens. The smaller the range between the near and far planes, the better your z-buffer will look! If you see flickering on objects that are overlapping, try making the range smaller. These values only affect orthographic mode projection, which is only available in 2D window modes.
  - `nearPlane` — The GPU discards pixels that are too close to the camera, this is that distance!
  - `farPlane` — At what distance from the camera does the GPU discard pixel? This is not true distance, but rather Z-axis distance from zero in View Space coordinates!
- `static void Renderer.SetOrthoSize(float viewportHeightMeters)` — This sets the size of the orthographic projection's viewport. You can use this feature to zoom in and out of the scene. This value only affects orthographic mode projection, which is only available in 2D window modes.
  - `viewportHeightMeters` — The vertical size of the projection's viewport, in meters.
- `static void Renderer.SetPostProcess(Material[] postProcessChain)` — Sets the main display's post-process chain! The Materials apply in array order, at most 2 per pass, and calling this with no arguments clears the chain. Post-processing here is tile-renderer friendly: effects run as subpasses that stay in tile memory on mobile GPUs, and they apply to the main display and to screenshots - what you see is what you shoot. A post-process Material's shader reads the scene through a pixel-local input attachment named 'color' (in HLSL, `[[vk::input_attachment_index(0)]] SubpassInput<float4> color;` read with `color.SubpassLoad()`), draws as a bufferless fullscreen triangle from SV_VertexID, and so cannot have vertex inputs. It may also read depth through an input attachment named 'depth' at index 1. Materials that don't qualify are rejected with an error log. Regular textures and Material parameters work normally, and can be animated per-frame.
  - `postProcessChain` — Materials whose shaders qualify as post-process effects, applied in order. Empty clears the chain.
  - Example: see `Renderer.SetPostProcess` in StereoKit-docs-reference.md

## enum RenderLayer

When rendering content, you can filter what you're rendering by the RenderLayer that they're on. This allows you to draw items that are visible in one render, but not another. For example, you may wish to draw a player's avatar in a 'mirror' rendertarget, but not in the primary display. See `Renderer.LayerFilter` for configuring what the primary display renders. Render layers can also be mixed and matched like bit-flags! Note that while this enum is 32 bits wide, render layers are stored internally in 16 bits when items are queued for drawing. Only the low 16 bits are usable as layers, so any custom flags above bit 15 will be silently truncated.

- `RenderLayer.All` — This is a flag that specifies all possible layers. If you want to render all layers, then this is the layer filter you would use. This is the default for render filtering.
- `RenderLayer.AllFirstPerson` — All layers except for the third person layer.
- `RenderLayer.AllRegular` — This is a combination of all layers that are not the VFX layer.
- `RenderLayer.AllThirdPerson` — All layers except for the first person layer.
- `RenderLayer.FirstPerson` — For items that should only be drawn from the first person perspective. By default, this is enabled for renders that are from a 1st person viewpoint.
- `RenderLayer.Layer0` — The default render layer. All Draw use this layer unless otherwise specified.
- `RenderLayer.Layer1` — Render layer 1.
- `RenderLayer.Layer2` — Render layer 2.
- `RenderLayer.Layer3` — Render layer 3.
- `RenderLayer.Layer4` — Render layer 4.
- `RenderLayer.Layer5` — Render layer 5.
- `RenderLayer.Layer6` — Render layer 6.
- `RenderLayer.Layer7` — Render layer 7.
- `RenderLayer.Layer8` — Render layer 8.
- `RenderLayer.Layer9` — Render layer 9.
- `RenderLayer.ThirdPerson` — For items that should only be drawn from the third person perspective. By default, this is enabled for renders that are from a 3rd person viewpoint.
- `RenderLayer.UI` — The default layer for StereoKit's UI. Mesh and model content drawn by the UI system uses this layer, see `UI.RenderLayer` to change it.
- `RenderLayer.Vfx` — The default VFX layer, StereoKit draws some non-standard mesh content using this flag, such as lines.

## class RenderList

A RenderList is a collection of Draw commands that can be submitted to various surfaces. RenderList.Primary is where all normal Draw calls get added to, and this RenderList is renderer to primary display surface. Manually working with a RenderList can be useful for "baking down matrices" or caching a scene of objects. Or for drawing a separate scene to an offscreen surface, like for thumbnails of Models.

- `int RenderList.Count` — The number of Mesh/Material pairs that have been submitted to the render list so far this frame.
- `string RenderList.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `int RenderList.PrevCount` — This is the number of items in the RenderList before it was most recently cleared. If this is a list that is drawn and cleared each frame, you can think of this as "last frame's count".
- `static RenderList RenderList.Primary` — The default RenderList used by the Renderer for the primary display surface.
- `void RenderList(RenderListRefs refs)` — Creates a new empty RenderList.
  - `refs` — Controls whether the list tracks asset references for the Meshes and Materials added to it. The default, `Tracked`, is safe across frames. `None` skips the addref/release pair on each add and clear, but the caller must ensure the list is cleared before any referenced asset could be released.
- `void RenderList.Add(Mesh mesh, Material material, Matrix transform, Color colorLinear, RenderLayer layer)` — Add a Mesh/Material to the RenderList. The RenderList will hold a reference to these Assets until the list is cleared.
  - `mesh` — A valid Mesh you wish to draw.
  - `material` — A Material to apply to the Mesh.
  - `transform` — A transformation Matrix relative to the current Hierarchy.
  - `colorLinear` — A per-instance linear space color value to pass into the shader! Normally this gets used like a material tint. If you're  adventurous and don't need per-instance colors, this is a great spot to pack in extra per-instance data for the shader!
  - `layer` — All visuals are rendered using a layer bit-flag. By default, all layers are rendered, but this can be useful for filtering out objects for different rendering purposes! For example: rendering a mesh over the user's head from a 3rd person perspective, but filtering it out from the 1st person perspective.
- `void RenderList.Add(Model model, Matrix transform, Color colorLinear, RenderLayer layer)` — Add a Model to the RenderList. The RenderList will hold a reference to these Assets until the list is cleared.
  - `model` — A valid Model you wish to draw.
  - `transform` — A transformation Matrix relative to the current Hierarchy.
  - `colorLinear` — A per-instance linear space color value to pass into the shader! Normally this gets used like a material tint. If you're  adventurous and don't need per-instance colors, this is a great spot to pack in extra per-instance data for the shader!
  - `layer` — All visuals are rendered using a layer bit-flag. By default, all layers are rendered, but this can be useful for filtering out objects for different rendering purposes! For example: rendering a mesh over the user's head from a 3rd person perspective, but filtering it out from the 1st person perspective.
- `void RenderList.Add(Model model, Material materialOverride, Matrix transform, Color colorLinear, RenderLayer layer)` — Add a Model to the RenderList. The RenderList will hold a reference to these Assets until the list is cleared.
  - `model` — A valid Model you wish to draw.
  - `transform` — A transformation Matrix relative to the current Hierarchy.
  - `colorLinear` — A per-instance linear space color value to pass into the shader! Normally this gets used like a material tint. If you're  adventurous and don't need per-instance colors, this is a great spot to pack in extra per-instance data for the shader!
  - `layer` — All visuals are rendered using a layer bit-flag. By default, all layers are rendered, but this can be useful for filtering out objects for different rendering purposes! For example: rendering a mesh over the user's head from a 3rd person perspective, but filtering it out from the 1st person perspective.
  - `materialOverride` — Allows you to override the Material of all nodes on this Model with your own Material.
  - Example: see `RenderList.Add` in StereoKit-docs-reference.md
- `void RenderList.Clear()` — Clears out and de-references all Draw items currently in the RenderList.
- `void RenderList.DrawNow(Tex toRenderTarget, Matrix camera, Matrix projection, Color clearColor, RenderClear clear, Rect viewportPct, RenderLayer layerFilter, int materialVariant)` — Draws the RenderList to a rendertarget texture immediately. It does _not_ clear the list.
  - `toRenderTarget` — The rendertarget texture to draw to.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `clearColor` — If the `clear` parameter is set to clear the color of `toRenderTarget`, then this is the color it will clear to. `default` would be a transparent black.
  - `clear` — Describes if and how the rendertarget should be cleared before rendering. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!
  - `viewportPct` — Allows you to specify a region of the rendertarget to draw to! This is in normalized coordinates, 0-1. If the width of this value is zero, then this will render to the entire texture.
  - `layerFilter` — This is a bit flag that allows you to change which layers StereoKit renders for this particular render viewpoint. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter.
  - `materialVariant` — Specifies which Material variant should be used for rendering. 0 will be the normal default material, any others will generally be application-defined by setting up each Material's Variant with specific shaders. If a Material has no corresponding variant, it will not be drawn.
- `void RenderList.DrawNow(Tex toRenderTarget, Matrix camera, Matrix projection, RenderSettings settings)` — This renders the RenderList to the rendertarget texture immediately, from the specified viewpoint, using a RenderSettings struct for everything else - including tile-friendly post-process effects! See Renderer.SetPostProcess for post-process shader requirements.
  - `toRenderTarget` — The rendertarget texture to draw to.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `settings` — Settings for this render pass, a `default` here means all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.
- `void RenderList.DrawNow(Tex toRenderTarget, Matrix[]& cameras, Matrix[]& projections, Color clearColor, RenderClear clear, Rect viewportPct, RenderLayer layerFilter, int materialVariant)` — Multi-view variant of DrawNow. Renders the list once across multiple views in a single pass, with one camera + projection per view. Each view writes to its corresponding layer of the (array) render target. The number of views is capped at 6.
  - `toRenderTarget` — An array or cubemap rendertarget with at least `cameras.Length` layers.
  - `cameras` — View transforms, one per view. Length must equal `projections.Length` and cannot exceed Renderer.MaxViews.
  - `projections` — Projection matrices, one per view. Same length as `cameras`.
  - `clearColor` — If `clear` clears color, this is the color used. Default is transparent black.
  - `clear` — Whether and how to clear the rendertarget before rendering.
  - `viewportPct` — Subregion of the rendertarget to draw to, in normalized coordinates 0-1. Width of zero draws to the entire target.
  - `layerFilter` — Bit flag controlling which render layers are drawn this pass.
  - `materialVariant` — Which material variant to use. 0 is the default; non-zero indexes into Material.Variants.
- `void RenderList.DrawNow(Tex toRenderTarget, Matrix[]& cameras, Matrix[]& projections, RenderSettings settings)` — This renders the RenderList to the rendertarget texture immediately, from the specified viewpoint, using a RenderSettings struct for everything else - including tile-friendly post-process effects! See Renderer.SetPostProcess for post-process shader requirements.
  - `toRenderTarget` — The rendertarget texture to draw to.
  - `camera` — A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.
  - `projection` — The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.
  - `settings` — Settings for this render pass, a `default` here means all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.
  - `cameras` — View transforms, one per view. Length must equal `projections.Length` and cannot exceed Renderer.MaxViews.
  - `projections` — Projection matrices, one per view. Same length as `cameras`.
  - Example: see `RenderList.DrawNow` in StereoKit-docs-reference.md
- `static RenderList RenderList.Find(string listId)` — Finds the RenderList with the matching id, and returns a reference to it. If no RenderList is found, it returns null.
  - `listId` — Id of the RenderList we're looking for.
  - returns — A RenderList with a matching id, or null if none is found.
- `static void RenderList.Pop()` — This removes the current top of the RenderList stack, making the next list as active
- `static void RenderList.Push(RenderList list)` — All draw calls that don't specify a render list will get submitted to the active RenderList at the top of the stack. By default, that's RenderList.Primary, but you can push your own list onto the stack here to capture draw calls, like those done in the UI.
  - `list` — The list that should go on top of the stack as the active RenderList.

## enum RenderListRefs

Controls whether a RenderList holds asset references for the items it contains. Tracked lists are safe to keep around across frames at the cost of an addref/releaseref pair per item.

- `RenderListRefs.None` — The list does not addref or releaseref its items. The caller is responsible for ensuring referenced assets remain valid until the list is cleared. Useful for per-frame lists that are filled and drained inside a single frame.
- `RenderListRefs.Tracked` — The list calls addref on each item's mesh/material when added, and releaseref when cleared. This keeps assets alive for as long as the list holds them, and is the safe default.

## struct RenderSettings

Optional settings for rendering a camera viewpoint to a rendertarget, used by Renderer.RenderTo and RenderList.DrawNow. This is a plain struct where zero means 'default' - a `default` or `new` RenderSettings gives you: all layers, the default material variant, clear everything to transparent black, a full-target viewport, and no post-processing.

- `RenderClear RenderSettings.clear` — Describes if and how the rendertarget should be cleared before rendering. A value of 0 (the default) clears everything, use RenderClear.Keep to draw on top of the target's existing content. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!
- `Color RenderSettings.clearColor` — If `clear` clears color, this is the color it will clear to, in linear space. Default is a transparent black.
- `RenderLayer RenderSettings.layerFilter` — This is a bit flag that allows you to change which layers StereoKit renders for this particular pass. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter. A value of 0 (the default) means RenderLayer.All.
- `int RenderSettings.materialVariant` — Specifies which Material variant should be used for rendering. 0 is the normal default material, any others will generally be application-defined by setting up each Material's Variant with specific shaders. If a Material has no corresponding variant, it will not be drawn.
- `Material[] RenderSettings.postProcess` — An optional list of post-process Materials for this pass, applied in array order. These are tile-friendly subpass effects, see Renderer.SetPostProcess for the shader requirements. Null is fine here, and means no post-processing.
- `Rect RenderSettings.viewport` — Allows you to specify a region of the rendertarget to draw to! This is in normalized coordinates, 0-1. If the width of this value is zero (the default), then this will render to the entire texture.

## delegate ScreenshotCallback

A callback for receiving the pixel data of a screenshot, instead of saving it directly to a file.

## static class Sensor

The Sensor class provides access to device sensor data. Currently this includes depth sensing, with color camera support planned for the future.

## static class Sensor.Depth

Provides access to real-time depth sensing from the device, if available. Depth data is provided as a GPU texture with per-frame metadata including camera intrinsics and view/projection information for each eye. This is currently backed by XR_META_environment_depth on OpenXR backends. If no depth provider is available, calls will gracefully return false or no-op.

- `static bool Sensor.Depth.IsAvailable` — True when the depth system is available on the current device and backend.
- `static bool Sensor.Depth.IsRunning` — True while the depth provider is actively running.
- `static Tex Sensor.Depth.Texture` — The system-managed depth texture. Available once the depth sensor has been started. Dimensions and format are valid after the first frame.
- `static SensorDepthCaps Sensor.Depth.GetCapabilities()` — Returns a bitmask of SensorDepthCaps indicating which optional features are supported on the current platform and backend.
  - returns — Supported capability capabilities.
- `static bool Sensor.Depth.SetCapabilities(SensorDepthCaps capabilities)` — Updates the active capabilities while the sensor is running. Can enable or disable features like hand removal or CPU readback at runtime. Unsupported capabilities are silently ignored.
  - `capabilities` — New set of capabilities to apply.
  - returns — True if the sensor is running and capabilities were applied.
- `static bool Sensor.Depth.Start(SensorDepthCaps capabilities)` — Starts the depth provider with the given capabilities. Unsupported capabilities for the current platform are silently ignored. Must be called before TryGetLatestFrame will return data.
  - `capabilities` — Optional capabilities to configure features like hand removal or CPU data readback.
  - returns — True on success.
- `static void Sensor.Depth.Stop()` — Stops the depth provider.
- `static bool Sensor.Depth.TryGetLatestData(SensorDepthFrame& info, T[]& data, int viewIndex)` — Retrieves the latest CPU-accessible depth data with matching per-eye metadata. The readback pipeline starts automatically on the first call and runs asynchronously, so the first few calls may return false. The returned data is typically 1-2 frames behind the GPU texture, but can be more under heavy GPU load.
  - `info` — The per-frame metadata matching this data.
  - `data` — An array that will be filled with the depth data. If null or the wrong size, it will be reallocated.
  - `viewIndex` — Which view to read back: -1 for all views (default), 0 for the first view, 1 for the second view.
  - returns — True if data was available.
- `static bool Sensor.Depth.TryGetLatestFrame(SensorDepthFrame& info)` — Retrieves the latest per-frame depth metadata.
  - `info` — The latest per-frame metadata.
  - returns — True if a frame was available.

## enum SensorDepthCaps

Capabilities for configuring the sensor depth system. These control optional features that may or may not be supported on the current platform. Check the capabilities for platform support.

- `SensorDepthCaps.HandRemoval` — Enable hand removal filtering on depth data, removing hands from the depth image.
- `SensorDepthCaps.None` — No special capabilities.

## struct SensorDepthFrame

Per-frame metadata for sensor depth. Contains timestamps, dimensions, near/far planes, and per-eye camera metadata.

- `Int64 SensorDepthFrame.captureTime` — The actual capture time of the depth sensor images, in OpenXR time units (nanoseconds). Zero if the runtime does not support it.
- `Int64 SensorDepthFrame.displayTime` — The predicted display time this frame was acquired for, in OpenXR time units (nanoseconds).
- `float SensorDepthFrame.farZ` — Far clip plane of the depth projection, in meters.
- `uint SensorDepthFrame.height` — Height of a single eye's depth image, in pixels.
- `float SensorDepthFrame.nearZ` — Near clip plane of the depth projection, in meters.
- `SensorDepthView[] SensorDepthFrame.views` — Per-eye depth camera metadata. Index 0 is left, index 1 is right.
- `uint SensorDepthFrame.width` — Width of a single eye's depth image, in pixels.

## struct SensorDepthView

Per-eye view metadata for a sensor depth frame, providing the camera pose and field of view used to capture that eye's depth.

- `FovInfo SensorDepthView.fov` — The field of view of this eye's depth camera, in degrees.
- `Pose SensorDepthView.pose` — The pose of this eye's depth camera in world space.

## class Shader

A shader is a piece of code that runs on the GPU, and determines how model data gets transformed into pixels on screen! It's more likely that you'll work more directly with Materials, which shaders are a subset of. With this particular class, you can mostly just look at it. It doesn't do a whole lot. Maybe you can swap out the shader code or something sometimes!

- `string Shader.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `string Shader.Name` — The name of the shader, provided in the shader file itself. Not the filename or id.
- `static Shader Shader.Default` — This is a fast, general purpose shader. It uses a texture for 'diffuse', a 'color' property for tinting the material, and a 'tex_scale' for scaling the UV coordinates. For lighting, it just uses a lookup from the current cubemap.
- `static Shader Shader.PBR` — A physically based shader.
- `static Shader Shader.PBRClip` — Same as ShaderPBR, but with a discard clip for transparency.
- `static Shader Shader.UI` — A shader for UI or interactable elements, this'll be the same as the Shader, but with an additional finger 'shadow' and distance circle effect that helps indicate finger distance from the surface of the object.
- `static Shader Shader.UIBox` — A shader for indicating interaction volumes! It renders a border around the edges of the UV coordinates that will 'grow' on proximity to the user's finger. It will discard pixels outside of that border, but will also show the finger shadow. This is meant to be an opaque shader, so it works well for depth LSR. This shader works best on cube-like meshes where each face has UV coordinates from 0-1. Shader Parameters: ``` color                - color border_size          - meters border_size_grow     - meters border_affect_radius - meters ```
- `static Shader Shader.Unlit` — Sometimes lighting just gets in the way! This is an extremely simple and fast shader that uses a 'diffuse' texture and a 'color' tint property to draw a model without any lighting at all!
- `static Shader Shader.UnlitClip` — Sometimes lighting just gets in the way! This is an extremely simple and fast shader that uses a 'diffuse' texture and a 'color' tint property to draw a model without any lighting at all! This shader will also discard pixels with an alpha of zero.
- `static Shader Shader.Find(string shaderId)` — Looks for a Shader asset that's already loaded, matching the given id! Unless the id has been set manually, the id will be the same as the shader's name provided in the metadata.
  - `shaderId` — For shaders loaded from file, this'll be the shader's metadata name!
  - returns — Link to a shader asset!
- `static Shader Shader.FromFile(string file)` — Loads a shader from a precompiled StereoKit Shader (.sks) file! HLSL files can be compiled using the skshaderc tool included in the NuGet package. This should be taken care of by MsBuild automatically, but you may need to ensure your HLSL file is a <SKShader /> item type in the .csproj for this to work. You can also compile with the command line app manually if you're compiling/distributing a shader some other way!
  - `file` — Path to a precompiled StereoKit Shader file! If no .sks extension is part of this path, StereoKit will automatically add it and check that first.
  - returns — A shader from the given file, or null if it failed to load/compile.
- `static Shader Shader.FromMemory(Byte[]& data)` — Creates a shader asset from a precompiled StereoKit Shader file stored as bytes!
  - `data` — A precompiled StereoKit Shader file as bytes.
  - returns — A shader from the given data, or null if it failed to load/compile.

## struct SHLight

A light source used for creating SphericalHarmonics data.

- `Color SHLight.color` — Color of the light in linear space! Values here can exceed 1.
- `Vec3 SHLight.directionTo` — Direction to the light source.

## static class SK

This class contains functions for running the StereoKit library!

- `static DisplayMode SK.ActiveDisplayMode` — Since we can fallback to a different DisplayMode, this lets you check to see which Runtime was successfully initialized.
- `static Object SK.AndroidActivity` — On Android systems, this must be assigned right away, before _any_ access to SK methods. When using Xamarin.Essentials or Microsoft.Maui.Essentials, this will be done automatically. This will be set to null after SK.Initialize is called.
- `static IntPtr SK.AndroidJavaVM` — On Android systems, this is the pointer to the JavaVM object. If not set, StereoKit will attempt to find it at runtime via JNI_GetCreatedJavaVMs, but this may fail on Android API 24-30 due to linker namespace restrictions. Setting this ensures compatibility across all Android versions.
- `static AppFocus SK.AppFocus` — This tells about the app's current focus state, whether it's active and receiving input, or if it's backgrounded or hidden. This can be important since apps may still run and render when unfocused, as the app may still be visible behind the app that _does_ have focus.
- `static bool SK.IsInitialized` — Has StereoKit been successfully initialized already? If initialization was attempted and failed, this value will be false.
- `static QuitReason SK.QuitReason` — This tells the reason why StereoKit has quit and developer can take appropriate action to debug.
- `static SKSettings SK.Settings` — This is a copy of the settings that StereoKit was initialized with, so you can refer back to them a little easier. Some of these values will be different than provided, as StereoKit will resolve some default values based on the platform capabilities or internal preference. These are read only, and keep in mind that some settings are only requests! Check SK.System and other properties for the current state of StereoKit.
- `static IEnumerable`1 SK.Steppers` — An enumerable list of all currently active ISteppers registered with StereoKit. This does not include Steppers that have been added, but are not yet initialized. Stepper initialization happens at the beginning of the frame, before the app's Step.
- `static SystemInfo SK.System` — This structure contains information about the current system and its capabilities. There's a lot of different MR devices, so it's nice to have code for systems with particular characteristics!
- `static UInt64 SK.VersionId` — An integer version Id! This is defined using a hex value with this format: `0xMMMMiiiiPPPPrrrr` in order of Major.mInor.Patch.pre-Release
- `static string SK.VersionName` — Human-readable version name embedded in the StereoKitC DLL.
- `static Object SK.AddStepper(Type type)` — This instantiates and registers an instance of the `IStepper` type provided as the generic parameter. SK will hold onto it, Initialize it, Step it every frame, and call Shutdown when the application ends. This is generally safe to do before SK.Initialize is called, the constructor is called right away, and Initialize is called right after SK.Initialize, or at the start of the next frame before the next main Step callback if SK is already initialized.
  - `type` — Any object that implements IStepper, and has a constructor with zero parameters.
  - returns — Just for convenience, this returns the instance that was just added.
- `static T SK.AddStepper(T stepper)` — This registers an instance of the `IStepper` type provided. SK will hold onto it, Initialize it, Step it every frame, and call Shutdown when the application ends. This is generally safe to do before SK.Initialize is called, the constructor is called right away, and Initialize is called right after SK.Initialize, or at the start of the next frame before the next main Step callback if SK is already initialized.
  - `stepper` — An instance of an IStepper object. Must not be null.
  - returns — Just for convenience, this returns the instance that was just added.
- `static T SK.AddStepper()` — This instantiates and registers an instance of the `IStepper` type provided as the generic parameter. SK will hold onto it, Initialize it, Step it every frame, and call Shutdown when the application ends. This is generally safe to do before SK.Initialize is called, the constructor is called right away, and Initialize is called right after SK.Initialize, or at the start of the next frame before the next main Step callback if SK is already initialized.
  - returns — Just for convenience, this returns the instance that was just added.
- `static void SK.ExecuteOnMain(Action action)` — This will queue up some code to be run on StereoKit's main thread! Immediately after StereoKit's Step, all callbacks registered here will execute, and then removed from the list.
  - `action` — Some code to run! This Action will persist in a list until after Step, at which point it is removed and dropped.
- `static Object SK.GetOrCreateStepper(Type type)` — This will search the list of `IStepper`s that are currently attached to StereoKit. This includes `IStepper`s that have been added but are not yet initialized. This will return the first `IStepper` in the list that is assignable to the provided type, and if one is not found, it will attempt to create one.
  - `type` — Any concrete type that contains an empty constructor.
  - returns — The first `IStepper` in the list that is assignable to the provided generic type, or a new object of the given type.
- `static T SK.GetOrCreateStepper()` — This will search the list of `IStepper`s that are currently attached to StereoKit. This includes `IStepper`s that have been added but are not yet initialized. This will return the first `IStepper` in the list that is assignable to the provided generic type, and if one is not found, it will attempt to create one.
  - returns — The first `IStepper` in the list that is assignable to the provided generic type, or a new object of type T.
- `static Object SK.GetStepper(Type type)` — This will search the list of `IStepper`s that are currently attached to StereoKit. This includes `IStepper`s that have been added but are not yet initialized. This will return the first `IStepper` in the list that is assignable to the provided type.
  - `type` — Any parent or exact type.
  - returns — The first `IStepper` in the list that is assignable to the provided generic type, or null if none is found.
- `static T SK.GetStepper()` — This will search the list of `IStepper`s that are currently attached to StereoKit. This includes `IStepper`s that have been added but are not yet initialized. This will return the first `IStepper` in the list that is assignable to the provided generic type.
  - returns — The first `IStepper` in the list that is assignable to the provided generic type, or null if none is found.
- `static bool SK.Initialize(SKSettings settings)` — Initializes StereoKit window, default resources, systems, etc.
  - `settings` — The configuration settings for StereoKit. This defines how StereoKit starts up and behaves, so it contains things like app name, assets folder, display mode, etc. The default settings are meant to be good for most, but you may want to modify at least a few of these eventually!
  - returns — Returns true if all systems are successfully initialized!
- `static bool SK.Initialize(string projectName, string assetsFolder)` — This is a _very_ rudimentary way to initialize StereoKit, it doesn't take much, but a robust application will prefer to use an overload that takes SKSettings. This uses all the default settings, which are primarily configured for development.
  - `projectName` — Name of the application, this shows up an the top of the Win32 window, and is submitted to OpenXR. OpenXR caps this at 128 characters.
  - `assetsFolder` — Where to look for assets when loading files! Final path will look like '[assetsFolder]/[file]', so a trailing '/' is unnecessary.
  - returns — Returns true if all systems are successfully initialized!
- `static void SK.PreLoadLibrary()` — No longer necessary! The native library resolver is now registered automatically when any StereoKit native function is first called.
- `static void SK.Quit(QuitReason quitReason)` — Lets StereoKit know it should quit! It'll finish the current frame, and after that Step will return that it wants to exit.
- `static void SK.RemoveStepper(IStepper stepper)` — This removes a specific IStepper from SK's IStepper list. This will call the IStepper's Shutdown method before returning.
  - `stepper` — The specific IStepper instance to remove. Fine if it's null.
- `static void SK.RemoveStepper(Type type)` — This removes all IStepper instances that are assignable to the generic type specified. This will call the IStepper's Shutdown method on each removed instance before returning.
  - `type` — Any parent or exact type.
- `static void SK.RemoveStepper()` — This removes all IStepper instances that are assignable to the generic type specified. This will call the IStepper's Shutdown method on each removed instance before returning.
- `static void SK.Run(Action onStep, Action onShutdown)` — This passes application execution over to StereoKit. This continuously steps all StereoKit systems, and inserts user code via callback between the appropriate system updates. Once execution completes, or `SK.Quit` is called, it properly calls the shutdown callback and shuts down StereoKit for you. Using this method is important for compatibility with WASM and is the preferred method of controlling the main loop, over `SK.Step`.
  - `onStep` — A callback where you put your application code! This gets called between StereoKit systems, after frame setup, but before render.
  - `onShutdown` — A callback that gives you the opportunity to shut things down while StereoKit is still active. This is called after the last Step completes, and before StereoKit shuts down.
- `static void SK.SetWindow(IntPtr window)` — Android only. This is for telling StereoKit about the active Android window surface. In particular, Xamarin's ISurfaceHolderCallback2 gets SurfaceCreated and SurfaceDestroyed events, and these events should feed into this function.
  - `window` — This is an ISurfaceHolder.Surface.Handle or equivalent pointer.
- `static void SK.Shutdown()` — Cleans up all StereoKit initialized systems. Release your own StereoKit created assets before calling this. This is for cleanup only, and should not be used to exit the application, use SK.Quit for that instead. Calling this function is unnecessary if using SK.Run, as it is called automatically there.
- `static bool SK.Step(Action onStep)` — Steps all StereoKit systems, and inserts user code via callback between the appropriate system updates.
  - `onStep` — A callback where you put your application code! This gets called between StereoKit systems, after frame setup, but before render.
  - returns — If an exit message is received from the platform, or `SK.Quit()` is called, this function will return false.

## static class SKMath

This class contains some convenience math functions! StereoKit typically uses floats instead of doubles, so you won't need to cast to and from using these methods.

- `static float SKMath.Pi` — The mathematical constant, Pi!
- `static float SKMath.Tau` — Tau is 2*Pi, there are excellent arguments that Tau can make certain formulas more readable!
- `static float SKMath.AngleDist(float a, float b)` — Calculates the minimum angle 'distance' between two angles. This covers wraparound cases like: the minimum distance between 10 and 350 is 20.
  - `a` — First angle, in degrees.
  - `b` — Second angle, in degrees.
  - returns — Degrees 0-180, the minimum angle between a and b.
- `static float SKMath.Cos(float f)` — Same as Math.Cos
  - returns — Same as Math.Cos
- `static float SKMath.Exp(float f)` — Same as Math.Exp
  - returns — Same as Math.Exp
- `static float SKMath.Lerp(float a, float b, float t)` — Blends (Linear Interpolation) between two scalars, based on a 'blend' value, where 0 is a, and 1 is b. Doesn't clamp percent for you.
  - `a` — First item in the blend, or '0.0' blend.
  - `b` — Second item in the blend, or '1.0' blend.
  - `t` — A blend value between 0 and 1. Can be outside this range, it'll just interpolate outside of the a, b range.
  - returns — An unclamped blend of a and b.
- `static int SKMath.Mod(int x, int mod)` — Modulus, works better than '%' for negative values.
  - `x` — Numerator
  - `mod` — Denominator
  - returns — x modulus mod
- `static float SKMath.Sin(float f)` — Same as Math.Sin
  - returns — Same as Math.Sin
- `static float SKMath.Sqrt(float f)` — Same as Math.Sqrt
  - returns — Same as Math.Sqrt

## struct SKSettings

StereoKit initialization settings! Setup SK.settings with your data before calling SK.Initialize.

- `IntPtr SKSettings.androidActivity` — A JNI reference to an android.content.Context associated with the application, only used for Android applications. Xamarin and Maui apps will use the MainActivity.Handle for this.
- `IntPtr SKSettings.androidJavaVm` — A pointer to the JNI's JavaVM structure, only used for Android applications. This is optional, even for Android.
- `string SKSettings.appName` — Name of the application, this shows up an the top of the Win32 window, and is submitted to OpenXR. OpenXR caps this at 128 characters.
- `string SKSettings.assetsFolder` — Where to look for assets when loading files! Final path will look like '[assetsFolder]/[file]', so a trailing '/' is unnecessary.
- `DisplayBlend SKSettings.blendPreference` — What type of background blend mode do we prefer for this application? Are you trying to build an Opaque/Immersive/VR app, or would you like the display to be AnyTransparent, so the world will show up behind your content, if that's an option? Note that this is a preference only, and if it's not available on this device, the app will fall back to the runtime's preference instead! By default, (DisplayBlend.None) this uses the runtime's preference.
- `TexFormat SKSettings.colorFormat` — What kind of color buffer should StereoKit use for the primary display surface? By default StereoKit will let the XR runtime choose from a list that StereoKit likes. This is generally the best choice, as the runtime can pick surface formats that can improve performance. If a requested format is not available, StereoKit will fall back to the XR runtime's preference.
- `string SKSettings.defaultFontFamily` — A CSS-style comma-separated list of font families to use for StereoKit's default font, e.g. "Segoe UI, Arial, sans-serif". The first family that resolves on the host system is used, with the remainder acting as fallbacks for missing glyphs. If null, empty, or unresolvable, StereoKit falls back to its built-in per-platform default font selection.
- `DepthMode SKSettings.depthMode` — What kind of depth buffer should StereoKit use? A fast one, a detailed one, one that uses stencils? By default StereoKit will let the XR runtime choose, which typically results in fast, 16bit depth buffers for battery powered devices, and detailed 32bit depth buffers on PCs. If the requested mode is not available, StereoKit will fall back to the XR runtime's preference.
- `bool SKSettings.disableDesktopInputWindow` — By default, StereoKit will open a desktop window for keyboard input due to lack of XR-native keyboard APIs on many platforms. If you don't want this, you can disable it with this setting!
- `bool SKSettings.disableUnfocusedSleep` — By default, StereoKit will slow down when the application is out of focus. This is useful for saving processing power while the app is out-of-focus, but may not always be desired. In particular, running multiple copies of a SK app for testing networking code may benefit from this setting.
- `int SKSettings.flatscreenHeight` — If using Runtime.Flatscreen, the pixel size of the window on the screen.
- `int SKSettings.flatscreenPosX` — If using Runtime.Flatscreen, the pixel position of the window on the screen.
- `int SKSettings.flatscreenPosY` — If using Runtime.Flatscreen, the pixel position of the window on the screen.
- `int SKSettings.flatscreenWidth` — If using Runtime.Flatscreen, the pixel size of the window on the screen.
- `LogLevel SKSettings.logFilter` — The default log filtering level. This can be changed at runtime, but this allows you to set the log filter before Initialization occurs, so you can choose to get information from that. Default is LogLevel.Diagnostic.
- `AppMode SKSettings.mode` — Which operation mode should we use for this app? Default is XR, and by default the app will fall back to Simulator if XR fails or is unavailable.
- `bool SKSettings.noFlatscreenFallback` — If the preferred display fails, should we avoid falling back to flatscreen and just crash out? Default is false.
- `bool SKSettings.omitEmptyFrames` — If StereoKit has nothing to render for this frame, it skips submitting a projection layer to OpenXR entirely.
- `OriginMode SKSettings.origin` — Set the behavior of StereoKit's initial origin. Default behavior is OriginMode.Local, which is the most universally supported origin mode. Different origin modes have varying levels of support on different XR runtimes, and StereoKit will provide reasonable fallbacks for each. NOTE that when falling back, StereoKit will use a different root origin mode plus an offset. You can check World.OriginMode and World.OriginOffset to inspect what StereoKit actually landed on.
- `bool SKSettings.overlayApp` — If the runtime supports it, should this application run as an overlay above existing applications? Check SK.System.overlayApp after initialization to see if the runtime could comply with this flag. This will always force StereoKit to work in a blend compositing mode.
- `uint SKSettings.overlayPriority` — For overlay applications, this is the order in which apps should be composited together. 0 means first, bottom of the stack, and uint.MaxValue is last, on top of the stack.
- `int SKSettings.renderMultisample` — If you know in advance that you need this feature, this setting allows you to set `Renderer.Multisample` before initialization. This avoids creating and discarding a large and unnecessary swapchain object. Leave this at 0 to use the default, which is 4.
- `float SKSettings.renderScaling` — If you know in advance that you need this feature, this setting allows you to set `Renderer.Scaling` before initialization. This avoids creating and discarding a large and unnecessary swapchain object. Default value is 1.
- `StandbyMode SKSettings.standbyMode` — Configures StereoKit's behavior during device standby. By default in v0.4, SK will completely pause the main thread and disable audio. In v0.3, SK will continue to execute at a throttled pace, and audio will remain on.

## class Sound

This class represents a sound effect! Excellent for blips and bloops and little clips that you might play around your scene. Right now, this supports .wav, .mp3, and procedurally generated noises! On HoloLens 2, sounds are automatically processed on the HPU, freeing up the CPU for more of your app's code. To simulate this same effect on your development PC, you need to enable spatial sound on your audio endpoint. To do this, right click the speaker icon in your system tray, navigate to "Spatial sound", and choose "Windows Sonic for Headphones." For more information, visit https://docs.microsoft.com/en-us/windows/win32/coreaudio/spatial-sound

- `int Sound.CursorSamples` — This is the current position of the playback cursor, measured in samples from the start of the audio data.
- `float Sound.Duration` — This will return the total length of the sound in seconds.
- `string Sound.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `int Sound.TotalSamples` — This will return the total number of audio samples used by the sound! StereoKit currently uses 48,000 samples per second for all audio.
- `int Sound.UnreadSamples` — This is the maximum number of samples in the sound that are currently available for reading via ReadSamples! ReadSamples will reduce this number by the amount of samples read. This is only really valid for Stream sounds, all other sound types will just return 0.
- `static Sound Sound.Click` — A default click sound that lasts for 300ms. It's a procedurally generated sound based on a mouse press, with extra low frequencies in it.
- `static Sound Sound.Unclick` — A default click sound that lasts for 300ms. It's a procedurally generated sound based on a mouse release, with extra low frequencies in it.
- `static Sound Sound.CreateStream(float streamBufferDuration)` — Create a sound used for streaming audio in or out! This is useful for things like reading from a microphone stream, or playing audio from a source streaming over the network, or even procedural sounds that are generated on the fly! Use stream sounds with the WriteSamples and ReadSamples functions.
  - `streamBufferDuration` — How much audio time should this stream be able to hold without writing back over itself?
  - returns — A stream sound that can be read and written to.
- `static Sound Sound.Find(string soundId)` — Looks for a Sound asset that's already loaded, matching the given id!
  - `soundId` — Which Sound are you looking for?
  - returns — A link to the sound matching 'soundId', null if none is found.
- `static Sound Sound.FromFile(string filename)` — Loads a sound effect from file! Currently, StereoKit supports .wav and .mp3 files. Audio is converted to mono.
  - `filename` — Name of the audio file! Supports .wav and .mp3 files.
  - returns — A sound object, or null if something went wrong.
  - Example: see `Sound.FromFile` in StereoKit-docs-reference.md
- `static Sound Sound.FromSamples(Single[] samplesAt48000s)` — This function will create a sound from an array of samples. Values should range from -1 to +1, and there should be 48,000 values per second of audio.
  - `samplesAt48000s` — Values should range from -1 to +1, and there should be 48,000 per second of audio.
  - returns — Returns a sound effect from the samples provided! Or null if something went wrong.
  - Example: see `Sound.FromSamples` in StereoKit-docs-reference.md
- `static Sound Sound.Generate(AudioGenerator generator, float duration)` — This function will generate a sound from a function you provide! The function is called once for each sample in the duration. As an example, it may be called 48,000 times for each second of duration.
  - `generator` — This function takes a time value as an argument, which will range from 0-duration, and should return a value from -1 - +1 representing the audio wave at that point in time.
  - `duration` — In seconds, how long should the sound be?
  - returns — Returns a generated sound effect! Or null if something went wrong.
  - Example: see `Sound.Generate` in StereoKit-docs-reference.md
- `SoundInst Sound.Play(Vec3 at, float volume)` — Plays the sound at the 3D location specified, using the volume parameter as an additional volume control option! Sound volume falls off from 3D location, and can also indicate direction and location through spatial audio cues. So make sure the position is where you want people to think it's from! Currently, if this sound is playing somewhere else, it'll be canceled, and moved to this location.
  - `at` — World space location for the audio to play at.
  - `volume` — Volume modifier for the effect! 1 means full volume, and 0 means completely silent.
  - returns — Returns a link to the Sound's play instance, which you can use to track and modify how the sound plays after the initial conditions are set.
  - Example: see `Sound.Play` in StereoKit-docs-reference.md
- `int Sound.ReadSamples(Single[]& samples)` — This will read samples from the sound stream, starting from the first unread sample. Check UnreadSamples for how many samples are available to read.
  - `samples` — A pre-allocated buffer to read the samples into! This function will stop reading when this buffer is full, or when the sound runs out of unread samples.
  - returns — Returns the number of samples that were read from the stream's buffer and written to the provided sample buffer.
- `int Sound.ReadSamples(IntPtr sampleBuffer, int sampleCount)` — This will read samples from the sound stream, starting from the first unread sample. Check UnreadSamples for how many samples are available to read.
  - `sampleBuffer` — A pointer to a pre-allocated native buffer of floats to read the samples into! This function will stop reading when this buffer is full, or when the sound runs out of unread samples.
  - `sampleCount` — The maximum number of samples to read, this should be less than or equal to the number of samples the sampleBuffer can contain.
  - returns — Returns the number of samples that were read from the stream's buffer and written to the provided sample buffer.
  - Example: see `Sound.ReadSamples` in StereoKit-docs-reference.md
- `void Sound.WriteSamples(Single[]& samples)` — Only works if this Sound is a stream type! This writes a number of audio samples to the sample buffer, and samples should be between -1 and +1. Streams are stored as ring buffers of a fixed size, so writing beyond the capacity of the ring buffer will overwrite the oldest samples. StereoKit uses 48,000 samples per second of audio.
  - `samples` — An array of audio samples, where each sample is between -1 and +1.
- `void Sound.WriteSamples(Single[]& samples, int sampleCount)` — Only works if this Sound is a stream type! This writes a number of audio samples to the sample buffer, and samples should be between -1 and +1. Streams are stored as ring buffers of a fixed size, so writing beyond the capacity of the ring buffer will overwrite the oldest samples. StereoKit uses 48,000 samples per second of audio.
  - `samples` — An array of audio samples, where each sample is between -1 and +1.
  - `sampleCount` — You can use this to write only a subset of the samples in the array, rather than the entire array!
- `void Sound.WriteSamples(IntPtr samples, int sampleCount)` — Only works if this Sound is a stream type! This writes a number of audio samples to the sample buffer, and samples should be between -1 and +1. Streams are stored as ring buffers of a fixed size, so writing beyond the capacity of the ring buffer will overwrite the oldest samples. StereoKit uses 48,000 samples per second of audio. This variation of the method bypasses marshalling memory into C#, so it is the most optimal way to copy sound data if your source is already in native memory!
  - `samples` — A pointer to a native array of `float` audio samples, where each sample is between -1 and +1.
  - `sampleCount` — You can use this to write only a subset of the samples in the array, rather than the entire array!

## struct SoundInst

This represents a play instance of a Sound! You can get one when you call Sound.Play(). This allows you to do things like cancel a piece of audio early, or change the volume and position of it as it's playing.

- `float SoundInst.Intensity` — The maximum intensity of the sound data since the last frame, as a value from 0-1. This is unaffected by its 3d position or volume settings, and is straight from the audio file's data.
- `bool SoundInst.IsPlaying` — Is this Sound instance currently playing? For streaming assets, this will be true even if they don't have any new data in them, and they're just idling at the end of their data.
- `Vec3 SoundInst.Position` — The 3D position in world space this sound instance is currently playing at. If this instance is no longer valid, the position will be at zero.
- `float SoundInst.Volume` — The volume multiplier of this Sound instance! A number between 0 and 1, where 0 is silent, and 1 is full volume.
- `void SoundInst.Stop()` — This stops the sound early if it's still playing.

## enum SpatialNodeType

For use with World.FromSpatialNode, this indicates the type of node that's being bridged with OpenXR.

- `SpatialNodeType.Dynamic` — Dynamic spatial nodes track the pose of a physical object that moves continuously relative to reference spaces. The pose of dynamic spatial nodes can be very different within the duration of a rendering frame. It is important for the application to use the correct timestamp to query the space location. For example, a color camera mounted in front of a HMD is also tracked by the HMD so a web camera library can use a dynamic node to represent the camera location.
- `SpatialNodeType.Static` — Static spatial nodes track the pose of a fixed location in the world relative to reference spaces. The tracking of static nodes may slowly adjust the pose over time for better accuracy but the pose is relatively stable in the short term, such as between rendering frames. For example, a QR code tracking library can use a static node to represent the location of the tracked QR code.

## struct Sphere

Represents a sphere in 3D space! Composed of a center point and a radius, can be used for raycasting, collision, visibility, and other things!

- `Vec3 Sphere.center` — Center of the sphere.
- `float Sphere.Diameter` — Length of the line passing through the center from one side of the sphere to the other, in meters. Twice the radius.
- `float Sphere.radius` — Distance from the center, to the surface of the sphere, in meters. Half the diameter.
- `void Sphere(Vec3 center, float diameter)` — Creates a sphere using a center point and a diameter!
  - `center` — Center of the sphere.
  - `diameter` — Diameter is in meters. Twice the radius, the distance from one side of the sphere to the other when drawing a line through the center of the sphere.
- `bool Sphere.Contains(Vec3 point)` — A fast check to see if the given point is contained in or on a sphere!
  - `point` — A point in the same coordinate space as this sphere.
  - returns — True if in or on the sphere, false if outside.
- `bool Sphere.Intersect(Ray ray, Vec3& at)` — Intersects a ray with this sphere, and finds if they intersect, and if so, where that intersection is! This only finds the closest intersection point to the origin of the ray.
  - `ray` — A ray to intersect with.
  - `at` — An out parameter that will hold the closest intersection point to the ray's origin. If there's not intersection, this will be (0,0,0).
  - returns — True if intersection occurs, false if it doesn't. Refer to the 'at' parameter for intersection information!

## struct SphericalHarmonics

Spherical Harmonics are kinda like Fourier, but on a sphere. That doesn't mean terribly much to me, and could be wrong, but check out [here](http://www.ppsloan.org/publications/StupidSH36.pdf) for more details about how Spherical Harmonics work in this context! However, the more prctical thing is, SH can be a function that describes a value over the surface of a sphere! This is particularly useful for lighting, since you can basically store the lighting information for a space in this value! This is often used for lightmap data, or a light probe grid, but StereoKit just uses a single SH for the entire scene. It's a gross oversimplification, but looks quite good, and is really fast! That's extremely great when you're trying to hit 60fps, or even 144fps.

- `Vec3 SphericalHarmonics.coefficient1` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.coefficient2` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.coefficient3` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.coefficient4` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.coefficient5` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.coefficient6` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.coefficient7` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.coefficient8` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.coefficient9` — A set of RGB coefficients
- `Vec3 SphericalHarmonics.DominantLightDirection` — Returns the dominant direction of the light represented by this spherical harmonics data. The direction value is normalized. You can get the color of the light in this direction by using the struct's Sample method: `light.Sample(-light.DominantLightDirection)`.
- `void SphericalHarmonics(Vec3[] coefficients)` — Creates a SphericalHarmonic from an array of coefficients. Useful for loading stored data!
  - `coefficients` — Must be an array with a length of 9!
- `void SphericalHarmonics.Add(Vec3 lightDir, Color lightColor)` — Adds a 'directional light' to the lighting approximation. This can be used to bake a multiple light setup, or accumulate light from a field of points.
  - `lightDir` — Direction to the light source.
  - `lightColor` — Color of the light, in linear color space.
- `void SphericalHarmonics.Brightness(float scale)` — Scales all the SphericalHarmonic's coefficients! This behaves as if you're modifying the brightness of the lighting this object represents.
  - `scale` — A multiplier for the coefficients! A value of 1 will leave everything the same, 0.5 will cut the brightness in half, and a 2 will double the brightness.
- `static SphericalHarmonics SphericalHarmonics.FromLights(SHLight[] directional_lights)` — Creates a SphericalHarmonics approximation of the irradiance given from a set of directional lights!
  - `directional_lights` — A list of directional lights!
  - returns — A SphericalHarmonics approximation of the irradiance given from a set of directional lights!
- `Color SphericalHarmonics.Sample(Vec3 normal)` — Look up the color information in a particular direction!
  - `normal` — The direction to look in. Should be normalized.
  - returns — The Color represented by the SH in the given direction.
- `Vec3[] SphericalHarmonics.ToArray()` — Converts the SphericalHarmonic into an array of coefficients 9 long. Useful for storing calculated data!
  - returns — An array of coefficients 9 long.

## class Sprite

A Sprite is an image that's set up for direct 2D rendering, without using a mesh or model! This is technically a wrapper over a texture, but it also includes atlasing functionality, which can be pretty important to performance! This is used a lot in UI, for image rendering. Atlasing is not currently implemented, it'll swap to Single for now. But here's how it works! StereoKit will batch your sprites into an atlas if you ask it to! This puts all the images on a single texture to significantly reduce draw calls when many images are present. Any time you add a sprite to an atlas, it'll be marked as dirty and rebuilt at the end of the frame. So it can be a good idea to add all your images to the atlas on initialize rather than during execution! Since rendering is atlas based, you also have only one material per atlas. So this is why you might wish to put a sprite in one atlas or another, so you can apply different

- `float Sprite.Aspect` — The aspect ratio of the sprite! This is width/height. You may also be interested in the NormalizedDimensions property, which are normalized to the 0-1 range.
- `int Sprite.Height` — Height of the sprite, in pixels.
- `string Sprite.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `Vec2 Sprite.NormalizedDimensions` — Width and height of the sprite, normalized so the maximum value is 1.
- `int Sprite.Width` — Width of the sprite, in pixels.
- `static Sprite Sprite.ArrowDown` — This is a 64x64 image of a slightly rounded triangle pointing down.
- `static Sprite Sprite.ArrowLeft` — This is a 64x64 image of a slightly rounded triangle pointing left.
- `static Sprite Sprite.ArrowRight` — This is a 64x64 image of a slightly rounded triangle pointing right.
- `static Sprite Sprite.ArrowUp` — This is a 64x64 image of a slightly rounded triangle pointing up.
- `static Sprite Sprite.Backspace` — This is a 64x64 image of a backspace action button, similar to a backspace button you might find on a mobile keyboard.
- `static Sprite Sprite.Close` — This is a 64x64 image of a square aspect X, with rounded edge. It's used to indicate a 'close' icon.
- `static Sprite Sprite.RadioOff` — This is a 64x64 image of an empty hole. This is common iconography for radio buttons which use an empty hole to indicate an un-selected radio, and a filled hole for a selected radio. This is used by the UI for radio buttons!
- `static Sprite Sprite.RadioOn` — This is a 64x64 image of a filled hole. This is common iconography for radio buttons which use an empty hole to indicate an un-selected radio, and a filled hole for a selected radio. This is used by the UI for radio buttons!
- `static Sprite Sprite.Shift` — This is a 64x64 image of an upward facing rounded arrow. This is a triangular top with a narrow rectangular base, and is used to indicate a 'shift' icon on a keyboard.
- `static Sprite Sprite.ToggleOff` — This is a 64x64 image of an empty rounded square. This is common iconography for checkboxes which use an empty square to indicate an un-selected checkbox, and a filled square for a selected checkbox. This is used by the UI for toggle buttons!
- `static Sprite Sprite.ToggleOn` — This is a 64x64 image of a filled rounded square. This is common iconography for checkboxes which use an empty square to indicate an un-selected checkbox, and a filled square for a selected checkbox. This is used by the UI for toggle buttons!
- `void Sprite.Draw(Matrix& transform, Pivot pivotPosition, RenderLayer layer)` — Draws the sprite at the location specified by the transform matrix. A sprite is always sized in model space as 1 x Aspect meters on the x and y axes respectively, so scale appropriately. The 'position' attribute describes what corner of the sprite you're specifying the transform of.
  - `transform` — A Matrix describing a transform from model space to world space. A sprite is always sized in model space as 1 x Aspect meters on the x and y axes respectively, so scale appropriately and remember that your anchor position may affect the transform as well.
  - `pivotPosition` — Describes what corner of the sprite you're specifying the transform of. The 'Pivot' point or 'Origin' of the Sprite.
  - `layer` — The RenderLayer this sprite should be drawn on. This defaults to RenderLayer.Layer0.
- `void Sprite.Draw(Matrix& transform, Pivot anchorPosition, Color32 linearColor, RenderLayer layer)` — Draws the sprite at the location specified by the transform matrix. A sprite is always sized in model space as 1 x Aspect meters on the x and y axes respectively, so scale appropriately. The 'position' attribute describes what corner of the sprite you're specifying the transform of.
  - `transform` — A Matrix describing a transform from model space to world space. A sprite is always sized in model space as 1 x Aspect meters on the x and y axes respectively, so scale appropriately and remember that your anchor position may affect the transform as well.
  - `pivotPosition` — Describes what corner of the sprite you're specifying the transform of. The 'Pivot' point or 'Origin' of the Sprite.
  - `layer` — The RenderLayer this sprite should be drawn on. This defaults to RenderLayer.Layer0.
  - `linearColor` — Per-instance color data for this render item. It is unmodified by StereoKit, and is generally interpreted as linear.
- `static Sprite Sprite.Find(string id)` — Finds a sprite that matches the given id! Check out the DefaultIds static class for some built-in ids. Sprites will auto-id themselves using this pattern if single sprites: {Tex.Id}/sprite, and this pattern if atlased sprites: {Tex.Id}/sprite/atlas/{atlasId}.
  - `id` — Id of the sprite asset.
  - returns — A Sprite asset with the given id, or null if none is found.
- `static Sprite Sprite.FromFile(string file, SpriteType type, string atlasId)` — Create a sprite from an image file! This loads a Texture from file, and then uses that Texture as the source for the Sprite.
  - `file` — The filename of the image, an absolute filename, or a filename relative to the assets folder. Supports jpg, png, tga, bmp, psd, gif, hdr, pic.
  - `type` — Should this sprite be atlased, or an individual image? Adding this as an atlased image is better for performance, but will cause the atlas to be rebuilt! Images that take up too much space on the atlas, or might be loaded or unloaded during runtime may be better as Single rather than Atlased!
  - `atlasId` — The name of which atlas the sprite should belong to, this is only relevant if the SpriteType is Atlased.
  - returns — A Sprite asset, or null if the image failed to load!
- `static Sprite Sprite.FromTex(Tex image, SpriteType type, string atlasId)` — Create a sprite from a Texture object!
  - `image` — The texture to build a sprite from. Must be a valid, 2D image!
  - `type` — Should this sprite be atlased, or an individual image? Adding this as an atlased image is better for performance, but will cause the atlas to be rebuilt! Images that take up too much space on the atlas, or might be loaded or unloaded during runtime may be better as Single rather than Atlased!
  - `atlasId` — The name of which atlas the sprite should belong to, this is only relevant if the SpriteType is Atlased.
  - returns — A Sprite asset, or null if the image failed when adding to the sprite system!
  - Example: see `Sprite.FromTex` in StereoKit-docs-reference.md

## enum SpriteType

The way the Sprite is stored on the backend! Does it get batched and atlased for draw efficiency, or is it a single image?

- `SpriteType.Atlased` — The sprite will be batched onto an atlas texture so all sprites can be drawn in a single pass. This is excellent for performance! The only thing to watch out for here, adding a sprite to an atlas will rebuild the atlas texture! This can be a bit expensive, so it's recommended to add all sprites to an atlas at start, rather than during runtime. Also, if an image is too large, it may take up too much space on the atlas, and may be better as a Single sprite type.
- `SpriteType.Single` — This sprite is on its own texture. This is best for large images, items that get loaded and unloaded during runtime, or for sprites that may have edge artifacts or severe 'bleed' from adjacent atlased images.

## enum StandbyMode

When the device StereoKit is running on goes into standby mode, how should StereoKit react? Typically the app should pause, stop playing sound, and consume as little power as possible, but some scenarios such as multiplayer games may need the app to continue running.

- `StandbyMode.Default` — This will let StereoKit pick a mode based on its own preferences. On v0.3 and lower, this will be Slow, and on v0.4 and higher, this will be Pause.
- `StandbyMode.None` — The main thread will continue to execute, but with a very short sleep each frame. This allows the app to continue polling and processing, but without flooding the CPU with polling work while vsync is no longer the throttle. This will not disable sound.
- `StandbyMode.Pause` — The entire main thread will pause, and wait until the device has come out of standby. This is the most power efficient mode for the device to take when the device is in standby, and is recommended for the vast majority of apps. This will also disable sound.
- `StandbyMode.Slow` — The main thread will continue to execute, but with 100ms sleeps each frame. This allows the app to continue polling and processing, but reduces power consumption by throttling a bit. This will not disable sound. In the Simulator, this will behave as Slow.

## struct SystemInfo

Information about a system's capabilities and properties!

- `int SystemInfo.displayHeight` — Height of the display surface, in pixels! For a stereo display, this will be the height of a single eye.
- `DisplayBlend SystemInfo.displayType` — Obsolete, please use Device.DisplayBlend
- `int SystemInfo.displayWidth` — Width of the display surface, in pixels! For a stereo display, this will be the width of a single eye.
- `bool SystemInfo.eyeTrackingPresent` — Does the device we're on have eye tracking support present for input purposes? This is _not_ an indicator that the user has given the application permission to access this information. See `Input.Gaze` for how to use this data.
- `bool SystemInfo.overlayApp` — This tells if the app was successfully started as an overlay application. If this is true, then expect this application to be composited with other content below it!
- `bool SystemInfo.perceptionBridgePresent` — Can the device work with externally provided spatial anchors, like UWP's `Windows.Perception.Spatial.SpatialAnchor`
- `bool SystemInfo.spatialBridgePresent` — Does the device we're currently on have the spatial graph bridge extension? The extension is provided through the function `World.FromSpatialNode`. This allows OpenXR to talk with certain windows APIs, such as the QR code API that provides Graph Node GUIDs for the pose.
- `bool SystemInfo.worldOcclusionPresent` — Does this device support world occlusion of digital objects? If this is true, then World.OcclusionEnabled can be set to true, and World.OcclusionMaterial can be modified.
- `bool SystemInfo.worldRaycastPresent` — Can this device get ray intersections from the environment? If this is true, then World.RaycastEnabled can be set to true, and World.Raycast can be used.

## class Tex

This is the texture asset class! This encapsulates 2D images, texture arrays, cubemaps, and rendertargets! It can load any image format that stb_image can, (jpg, png, tga, bmp, psd, gif, hdr, pic, ktx2) plus more later on, and you can also create textures procedurally.

- `TexAddress Tex.AddressMode` — When looking at a UV texture coordinate on this texture, how do we handle values larger than 1, or less than zero? Do we Wrap to the other side? Clamp it between 0-1, or just keep Mirroring back and forth? Wrap is the default.
- `int Tex.Anisoptropy` — When SampleMode is set to Anisotropic, this is the number of samples the GPU takes to figure out the correct color. Default is 4, and 16 is pretty high.
- `AssetState Tex.AssetState` — Textures are loaded asyncronously, so this tells you the current state of this texture! This also can tell if an error occured, and what type of error it may have been.
- `SphericalHarmonics Tex.CubemapLighting` — ONLY valid for cubemap textures! This will calculate a spherical harmonics representation of the cubemap for use with StereoKit's lighting. First call may take a frame or two of time, but subsequent calls will pull from a cached value.
- `int Tex.Depth` — The depth of the texture, in pixels. Only meaningful for 3D (volume) textures created with TexType.Volume — for 2D, array, and cubemap textures this is 1. This will be a blocking call if AssetState is less than LoadedMeta.
- `Tex Tex.FallbackOverride` — This will override the default fallback texutre that gets used before the Tex has finished loading. This is useful for textures with a specific purpose where the normal fallback texture would appear strange, such as a metal/rough map.
- `TexFormat Tex.Format` — The StereoKit format this texture was initialized with. This will be a blocking call if AssetState is less than LoadedMeta.
- `int Tex.Height` — The height of the texture, in pixels. This will be a blocking call if AssetState is less than LoadedMeta.
- `string Tex.Id` — Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!
- `int Tex.Mips` — The number of mip-map levels this texture has. This will be 1 if the texture doesn't have mip mapping enabled. This will be a blocking call if AssetState is less than LoadedMeta.
- `TexSampleComp Tex.SampleComp` — When sampling from a texture with comparison enabled, the sampler compares the sampled texel value against a reference value and returns a 0 or 1 based on the result. This is primarily useful for shadow mapping techniques, where a depth texture is sampled to determine if a surface is in shadow.
- `TexSample Tex.SampleMode` — When sampling a texture that's stretched, or shrunk beyond its screen size, how do we handle figuring out which color to grab from the texture? Default is Linear.
- `int Tex.Width` — The width of the texture, in pixels. This will be a blocking call if AssetState is less than LoadedMeta.
- `Tex Tex.ZBuffer` — This allows you to attach or retreive a z/depth buffer from a rendertarget texture. This texture _must_ be a rendertarget to set this, and the zbuffer texture _must_ be a depth format (or null). For no-rendertarget textures, this will always be null.
- `static Tex Tex.Black` — Default 2x2 black opaque texture, this is the texture referred to as 'black' in the shader texture defaults.
- `static Tex Tex.DevTex` — This is a white checkered grid texture used to easily add visual features to materials. By default, this is used for the loading fallback texture for all Tex objects.
- `static Tex Tex.Error` — This is a red checkered grid texture used to indicate some sort of error has occurred. By default, this is used for the error fallback texture for all Tex objects.
- `static Tex Tex.Flat` — Default 2x2 flat normal texture, this is a normal that faces out from the, face, and has a color value of (0.5,0.5,1). This is the texture referred to as 'flat' in the shader texture defaults.
- `static Tex Tex.Gray` — Default 2x2 middle gray (0.5,0.5,0.5) opaque texture, this is the texture referred to as 'gray' in the shader texture defaults.
- `static Tex Tex.Rough` — Default 2x2 roughness color (1,1,0,1) texture, this is the texture referred to as 'rough' in the shader texture defaults.
- `static Tex Tex.White` — Default 2x2 white opaque texture, this is the texture referred to as 'white' in the shader texture defaults.
- `void Tex(TexType textureType, TexFormat textureFormat)` — Sets up an empty texture container! Fill it with data using SetColors next! Creates a default unique asset Id.
  - `textureType` — What type of texture is it? Just a 2D Image? A Cubemap? Should it have mip-maps?
  - `textureFormat` — What information is the texture composed of? 32 bit colors, 64 bit colors, etc.
- `void Tex.AddZBuffer(TexFormat depthFormat)` — Only applicable if this texture is a rendertarget! This creates and attaches a zbuffer surface to the texture for use when rendering to it.
  - `depthFormat` — The format of the depth texture, must be a depth format type!
  - returns — A new Tex asset with the specified depth.
- `Tex Tex.Copy(TexType textureType, TexFormat textureFormat)` — Copy the current texture into a new texture, with the option to convert it to a different format or type! This is a GPU blit operation, so the source texture does not need to be readable from the CPU. If the source texture doesn't have mip-maps but the destination type does, they'll be generated for you!
  - `textureType` — What type of texture should the new texture be? Image types with mip-maps will have mips generated for them if the source doesn't have them.
  - `textureFormat` — What format should the new texture be in? If None is specified, the new texture will use the same format as the source.
  - returns — A new texture copied from this one, or null if the copy failed.
- `static Tex Tex.Find(string id)` — Finds a texture that matches the given Id! Check out the DefaultIds static class for some built-in ids.
  - `id` — Id of the texture asset.
  - returns — A Tex asset with the given id, or null if none is found.
- `static Tex Tex.FromColors(Color32[]& colors, int width, int height, bool sRGBData)` — Creates a texture and sets the texture's pixels using a color array! This will be an image of type `TexType.Image`, and a format of `TexFormat.Rgba32` or `TexFormat.Rgba32Linear` depending on the value of the sRGBData parameter.
  - `colors` — An array of 32 bit colors, should be a length of `width*height`.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - returns — A Tex asset with TexType.Image and TexFormat.Rgba32 from the given array of colors.
- `static Tex Tex.FromColors(Color[]& colors, int width, int height, bool sRGBData)` — Creates a texture and sets the texture's pixels using a color array! Color values are converted to 32 bit colors, so this means a memory allocation and conversion. Prefer the Color32 overload for performance, or create an empty Texture and use SetColors for more flexibility. This will be an image of type `TexType.Image`, and a format of `TexFormat.Rgba32` or `TexFormat.Rgba32Linear` depending on the value of the sRGBData parameter.
  - `colors` — An array of 128 bit colors, should be a length of `width*height`.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - returns — A Tex asset with TexType.Image and TexFormat.Rgba32 from the given array of colors.
- `static Tex Tex.FromCubemap(string cubemapFile, bool sRGBData, int loadPriority)` — Creates a cubemap texture from a single file! This will load KTX2 files with 6 surfaces, or convert equirectangular images into cubemap images. KTX2 files are the _fastest_ way to load a cubemap, but equirectangular images can be acquired quite easily! Equirectangular images look like an unwrapped globe with the poles all stretched out, and are sometimes referred to as HDRIs.
  - `cubemapFile` — Filename of the cubemap image.
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `loadPriority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
  - returns — A Cubemap texture asset!
- `static Tex Tex.FromCubemapEquirectangular(string equirectangularCubemap, bool sRGBData, int loadPriority)` — Creates a cubemap texture from a single equirectangular image! You know, the ones that look like an unwrapped globe with the poles all stretched out. It uses some fancy shaders and texture blitting to create 6 faces from the equirectangular image.
  - `equirectangularCubemap` — Filename of the equirectangular image.
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `loadPriority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
  - returns — A Cubemap texture asset!
- `static Tex Tex.FromCubemapEquirectangular(string equirectangularCubemap, SphericalHarmonics& lightingInfo, bool sRGBData, int loadPriority)` — Creates a cubemap texture from a single equirectangular image! You know, the ones that look like an unwrapped globe with the poles all stretched out. It uses some fancy shaders and texture blitting to create 6 faces from the equirectangular image.
  - `equirectangularCubemap` — Filename of the equirectangular image.
  - `lightingInfo` — An out value that represents the lighting information scraped from the cubemap! This can then be passed to `Renderer.SkyLight`.
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `loadPriority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
  - returns — A Cubemap texture asset!
  - Example: see `Tex.FromCubemapEquirectangular` in StereoKit-docs-reference.md
- `static Tex Tex.FromCubemapFile(String[] cubeFaceFiles_xxyyzz, bool sRGBData, int priority)` — Creates a cubemap texture from 6 different image files! If you have a single equirectangular image, use Tex.FromEquirectangular  instead. Asset Id will be the first filename.
  - `cubeFaceFiles_xxyyzz` — 6 image filenames, in order of +X, -X, +Y, -Y, +Z, -Z.
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `priority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
  - returns — A Tex asset from the given files, or null if any failed to load.
- `static Tex Tex.FromCubemapFile(String[] cubeFaceFiles_xxyyzz, SphericalHarmonics& lightingInfo, bool sRGBData, int priority)` — Creates a cubemap texture from 6 different image files! If you have a single equirectangular image, use Tex.FromEquirectangular instead. Asset Id will be the first filename.
  - `cubeFaceFiles_xxyyzz` — 6 image filenames, in order of +X, -X, +Y, -Y, +Z, -Z.
  - `lightingInfo` — An out value that represents the lighting information scraped from the cubemap! This can then be passed to `Renderer.SkyLight`.
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `priority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
  - returns — A Tex asset from the given files, or null if any failed to load.
- `static Tex Tex.FromFile(string file, bool sRGBData, int loadPriority)` — Loads an image file directly into a texture! Supported formats are: jpg, png, tga, bmp, psd, gif, hdr, pic, ktx2. Asset Id will be the same as the filename.
  - `file` — An absolute filename, or a filename relative to the assets folder. Supports jpg, png, tga, bmp, psd, gif, hdr, pic, ktx2.
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `loadPriority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
  - returns — A Tex asset from the given file, or null if it failed to load.
- `static Tex Tex.FromFiles(String[] files, bool sRGBData, int priority)` — Loads an array of image files directly into a single array texture! Array textures are often useful for shader effects, layering, material merging, weird stuff, and will generally need a specific shader to support it. Supported formats are: jpg, png, tga, bmp, psd, gif, hdr, pic, ktx2. Asset Id will be the hash of all the filenames merged consecutively.
  - `files` — Absolute filenames, or a filenames relative to the assets folder. Supports jpg, png, tga, bmp, psd, gif, hdr, pic, ktx2.
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `priority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
  - returns — A Tex asset from the given files, or null if it failed to load.
- `static Tex Tex.FromHardwareBuffer(IntPtr hardwareBuffer, bool ownsBuffer)` — Imports an Android AHardwareBuffer as an external texture, YCbCr camera or decoder buffers come in via sampler conversion. This allows zero-copy access to hardware decoder or camera output. This is only functional on Android, and requires device support for hardware buffer import.
  - `hardwareBuffer` — An AHardwareBuffer* coerced into an IntPtr.
  - `ownsBuffer` — Should ownership of the hardware buffer be passed on to StereoKit? If so, StereoKit will release it when the texture is destroyed.
  - returns — A Tex asset wrapping the hardware buffer, or null if the buffer is null, the device doesn't support importing hardware buffers, or the import failed.
- `static Tex Tex.FromMemory(Byte[]& imageFileData, bool sRGBData, int priority)` — Loads an image file stored in memory directly into a texture! Supported formats are: jpg, png, tga, bmp, psd, gif, hdr, pic, ktx2. Asset Id will be the same as the filename.
  - `imageFileData` — The binary data of an image file, this is NOT a raw RGB color array!
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `priority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
  - returns — A Tex asset from the given file, or null if it failed to load.
- `static Tex Tex.GenColor(Color color, int width, int height, TexType type, TexFormat format)` — This generates a solid color texture of the given dimensions. Can be quite nice for creating placeholder textures! Make sure to match linear/gamma colors with the correct format.
  - `color` — The color to use for the texture. This is interpreted slightly differently based on what TexFormat gets used.
  - `width` — Width of the final texture, in pixels.
  - `height` — Height of the final texture, in pixels.
  - `type` — Not all types here are applicable, but TexType.Image or TexType.ImageNomips are good options here.
  - `format` — Not all formats are supported, but this does support a decent range. The provided color is interpreted slightly different depending on this format.
  - returns — A solid color image of width x height pixels.
- `static Tex Tex.GenCubemap(Gradient gradient, Vec3 gradientDirection, int resolution)` — Generates a cubemap texture from a gradient and a direction! These are entirely suitable for skyboxes, which you can set via Renderer.SkyTex.
  - `gradient` — A color gradient the generator will sample from! This looks at the 0-1 range of the gradient.
  - `gradientDirection` — This vector points to where the 'top' of the color gradient will go. Conversely, the 'bottom' of the gradient will be opposite, and it'll blend along that axis.
  - `resolution` — The square size in pixels of each cubemap face! This generally doesn't need to be large, unless you have a really complicated gradient.
  - returns — A procedurally generated cubemap texture!
- `static Tex Tex.GenCubemap(Gradient gradient, SphericalHarmonics& lightingInfo, Vec3 gradientDirection, int resolution)` — Generates a cubemap texture from a gradient and a direction! These are entirely suitable for skyboxes, which you can set via `Renderer.SkyTex`.
  - `gradient` — A color gradient the generator will sample from! This looks at the 0-1 range of the gradient.
  - `lightingInfo` — An out value that represents the lighting information scraped from the cubemap! This can then be passed to `Renderer.SkyLight`.
  - `gradientDirection` — This vector points to where the 'top' of the color gradient will go. Conversely, the 'bottom' of the gradient will be opposite, and it'll blend along that axis.
  - `resolution` — The square size in pixels of each cubemap face! This generally doesn't need to be large, unless you have a really complicated gradient.
  - returns — A procedurally generated cubemap texture!
- `static Tex Tex.GenCubemap(SphericalHarmonics& lighting, int resolution, float lightSpotSizePct, float lightSpotIntensity)` — Creates a cubemap from SphericalHarmonics lookups! These are entirely suitable for skyboxes, which you can set via `Renderer.SkyTex`.
  - `lighting` — Lighting information stored in a SphericalHarmonics.
  - `resolution` — The square size in pixels of each cubemap face! This generally doesn't need to be large, as SphericalHarmonics typically contain pretty low frequency information.
  - `lightSpotSizePct` — The size of the glowing spot added in the primary light direction. You can kinda think of the unit as a percentage of the cubemap face's size, but it's technically a Chebyshev distance from the light's point on a 2m cube.
  - `lightSpotIntensity` — The glowing spot's color is the primary light direction's color, but multiplied by this value. Since this method generates a 128bpp texture, this is not clamped between 0-1, so feel free to go nuts here! Remember that reflections will often cut down some reflection intensity.
  - returns — A procedurally generated cubemap texture!
- `static Tex Tex.GenParticle(int width, int height, float roundness0to1, Gradient gradientLinear)` — Generates a 'radial' gradient that works well for particles, blob shadows, glows, or various other things. The roundness can be used to change the shape from round, '1', to star-like, '0'. Default color is transparent white to opaque white, but this can be configured by providing a Gradient of your own.
  - `width` — Width of the desired texture, in pixels.
  - `height` — Width of the desired texture, in pixels.
  - `roundness0to1` — Where 0 is a cross, or star-like shape, and 1 is a circle. This is clamped to a minimum of 0.00001, but values above 1 are still valid, and will just make the shape a square near infinity.
  - `gradientLinear` — A color gradient that starts with the background/outside at 0, and progresses to the center at 1.
  - returns — A texture object containing an RGBA linear texture.
  - Example: see `Tex.GenParticle` in StereoKit-docs-reference.md
- `T[] Tex.GetColorData(int mipLevel, int structPerPixel)` — Retrieve the color data of the texture from the GPU. This can be a very slow operation, so use it cautiously.
  - `mipLevel` — Retrieves the color data for a specific mip-mapping level. This function will log a fail and return a black array if an invalid mip-level is provided.
  - `structPerPixel` — The number of `T` that fit in a single pixel. For example, if your texture format is RGBA128, and your T is float, this value would be 4.
  - returns — The texture's color values in an array sized Width*Height*structPerPixel.
- `void Tex.GetColorData(T[]& colorData, int mipLevel, int structPerPixel)` — Retrieve the color data of the texture from the GPU. This can be a very slow operation, so use it cautiously.
  - `colorData` — An array of colors that will be filled out with the texture's data. It can be null, or an incorrect size. If so, it will be reallocated to the correct size.
  - `mipLevel` — Retrieves the color data for a specific mip-mapping level. This function will log a fail and return a black array if an invalid mip-level is provided.
  - `structPerPixel` — The number of `T` that fit in a single pixel. For example, if your texture format is RGBA128, and your T is float, this value would be 4.
  - Example: see `Tex.GetColorData` in StereoKit-docs-reference.md
- `IntPtr Tex.GetHardwareBuffer()` — This will return the AHardwareBuffer* backing this texture, if it was created from one. This call will block execution until the texture is loaded, if it is not already.
  - returns — An AHardwareBuffer* coerced into an IntPtr, or IntPtr.Zero if the texture is not backed by a hardware buffer, or when not on Android.
- `IntPtr Tex.GetNativeSurface()` — This will return the texture's native resource for use with external libraries. For D3D, this will be an ID3D11Texture2D*, and for GL, this will be a uint32_t from a glGenTexture call, coerced into the IntPtr. This call will block execution until the texture is loaded, if it is not already.
  - returns — For D3D, this will be an ID3D11Texture2D*, and for GL, this will be a uint32_t from a glGenTexture call, coerced into the IntPtr.
- `static Tex Tex.RenderTarget(int width, int height, int multisample, TexFormat colorFormat, TexFormat depthFormat)` — This will assemble a texture ready for rendering to! It creates a render target texture with no mip maps and a depth buffer attached.
  - `width` — Width in pixels.
  - `height` — Height in pixels
  - `multisample` — Multisample level, or MSAA. This should be 1, 2, 4, 8, or 16. The results will have moother edges with higher values, but will cost more RAM and time to render. Note that GL platforms cannot trivially draw a multisample > 1 texture in a shader.
  - `colorFormat` — The format of the color surface.
  - `depthFormat` — The format of the depth buffer. If this is None, no depth buffer will be attached to this rendertarget.
  - returns — Returns a texture set up as a rendertarget.
- `void Tex.SetColors(int width, int height, IntPtr data)` — Set the texture's pixels using a pointer to a chunk of memory! This is great if you're pulling in some color data from native code, and don't want to pay the cost of trying to marshal that data around.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `data` — A pointer to a chunk of memory containing color data! Should be  width*height*size_of_texture_format bytes large. Color data should definitely match the format provided when constructing the texture!
- `void Tex.SetColors(int width, int height, int depth, IntPtr data)` — Set the contents of a 3D (volume) texture from a contiguous block of memory. The texture must be created with TexType.Volume. Pass IntPtr.Zero to allocate an empty volume (e.g. for use as a compute UAV). Slice-major layout: all of slice 0, then slice 1, etc., each slice being width*height pixels of the texture's format.
  - `width` — Width in pixels.
  - `height` — Height in pixels.
  - `depth` — Depth in pixels (number of slices).
  - `data` — A pointer to width*height*depth pixels of the texture's format, or IntPtr.Zero to allocate an empty volume.
- `void Tex.SetColors(int width, int height, int depth, Byte[]& data)` — Set the contents of a 3D (volume) texture from a byte array. The texture must be created with TexType.Volume and a single-channel format such as R8. Slice-major layout: all of slice 0, then slice 1, etc., each slice being width*height bytes.
  - `width` — Width in pixels.
  - `height` — Height in pixels.
  - `depth` — Depth in pixels (number of slices).
  - `data` — An array of width*height*depth bytes.
- `void Tex.SetColors(int width, int height, Color32[]& data)` — Set the texture's pixels using a color array! This function should only be called on textures with a format of Rgba32 or Rgba32Linear. You can call this as many times as you'd like, even with different widths and heights. Calling this multiple times will mark it as dynamic on the graphics card. Calling this function can also result in building mip-maps, which has a non-zero cost: use TexType.ImageNomips when creating the Tex to avoid this.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `data` — An array of 32 bit colors, should be a length of `width*height`.
- `void Tex.SetColors(int width, int height, Color[]& data)` — Set the texture's pixels using a color array! This function should only be called on textures with a format of Rgba128. You can call this as many times as you'd like, even with different widths and heights. Calling this multiple times will mark it as dynamic on the graphics card. Calling this function can also result in building mip-maps, which has a non-zero cost: use TexType.ImageNomips when creating the Tex to avoid this.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `data` — An array of 128 bit colors, should be a length of `width*height`.
- `void Tex.SetColors(int width, int height, Byte[]& data)` — Set the texture's pixels using a scalar array! This function should only be called on textures with a format of R8. You can call this as many times as you'd like, even with different widths and heights. Calling this multiple times will mark it as dynamic on the graphics card. Calling this function can also result in building mip-maps, which has a non-zero cost: use TexType.ImageNomips when creating the Tex to avoid this.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `data` — An array of 8 bit values, should be a length of `width*height`.
- `void Tex.SetColors(int width, int height, UInt16[]& data)` — Set the texture's pixels using a scalar array! This function should only be called on textures with a format of R16. You can call this as many times as you'd like, even with different widths and heights. Calling this multiple times will mark it as dynamic on the graphics card. Calling this function can also result in building mip-maps, which has a non-zero cost: use TexType.ImageNomips when creating the Tex to avoid this.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `data` — An array of 16 bit values, should be a length of `width*height`.
- `void Tex.SetColors(int width, int height, Single[]& data)` — Set the texture's pixels using a scalar array! This function should only be called on textures with a format of R32. You can call this as many times as you'd like, even with different widths and heights. Calling this multiple times will mark it as dynamic on the graphics card. Calling this function can also result in building mip-maps, which has a non-zero cost: use TexType.ImageNomips when creating the Tex to avoid this.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `data` — An array of 32 bit values, should be a length of `width*height`.
- `void Tex.SetColors(int width, int height, IntPtr[] arrayData, int mipCount, int multisample)` — Set the texture's pixels for a multi-layer and/or mip-mapped texture, using an array of pointers. Each pointer in `arrayData` represents one layer (face for cubemaps, slice for array textures), and points to a tightly packed block containing all mip levels for that layer in the order `[mip0][mip1][mip2]...`. The memory layout per mip should match the texture's format. This is the raw pointer variant for advanced use cases like uploading pre-decoded image data from native code.
  - `width` — Width in pixels of mip 0. Powers of two are generally best!
  - `height` — Height in pixels of mip 0. Powers of two are generally best!
  - `arrayData` — An array of `arrayCount` pointers, one per layer. Each layer points to packed mip data `[mip0][mip1][mip2]...`.
  - `mipCount` — The number of mip levels packed into each layer's data. Use 1 if no mip data is provided beyond the base.
  - `multisample` — Multisample count, only relevant for rendertarget textures.
- `void Tex.SetColors(int width, int height, Color32[][]& arrayData, int mipCount, int multisample)` — Set the texture's pixels for a multi-layer and/or mip-mapped texture using a jagged color array. Each entry in `arrayData` is one layer (face for cubemaps, slice for array textures), packed as `[mip0][mip1][mip2]...`. This function should only be called on textures with a format of Rgba32 or Rgba32Linear.
  - `width` — Width in pixels of mip 0. Powers of two are generally best!
  - `height` — Height in pixels of mip 0. Powers of two are generally best!
  - `arrayData` — A jagged array where each `arrayData[layer]` contains all mip levels for that layer, packed as `[mip0][mip1][mip2]...` with mip 0 sized `width*height`, mip 1 sized `(width/2)*(height/2)`, and so on.
  - `mipCount` — The number of mip levels packed into each layer's data. Use 1 if no mip data is provided beyond the base.
  - `multisample` — Multisample count, only relevant for rendertarget textures.
- `void Tex.SetColors(int width, int height, Byte[][]& arrayData, int mipCount, int multisample)` — Set the texture's pixels for a multi-layer and/or mip-mapped texture using a jagged byte array. Each entry in `arrayData` is one layer (face for cubemaps, slice for array textures), packed as `[mip0][mip1][mip2]...`. The byte layout per mip should match the texture's format.
  - `width` — Width in pixels of mip 0. Powers of two are generally best!
  - `height` — Height in pixels of mip 0. Powers of two are generally best!
  - `arrayData` — A jagged array where each `arrayData[layer]` contains all mip levels for that layer as bytes, packed as `[mip0][mip1][mip2]...`.
  - `mipCount` — The number of mip levels packed into each layer's data. Use 1 if no mip data is provided beyond the base.
  - `multisample` — Multisample count, only relevant for rendertarget textures.
  - Example: see `Tex.SetColors` in StereoKit-docs-reference.md
- `static void Tex.SetErrorFallback(Tex errorTexture)` — This is the texture that all Tex objects with errors will fall back to. Assigning a texture here that isn't fully loaded will cause the app to block until it is loaded.
  - `errorTexture` — Any _valid_ texture here is fine. Preferably loaded already, but doesn't have to be.
- `static void Tex.SetLoadingFallback(Tex loadingTexture)` — This is the texture that all Tex objects will fall back to by default if they are still loading. Assigning a texture here that isn't fully loaded will cause the app to block until it is loaded.
  - `loadingTexture` — Any _valid_ texture here is fine. Preferably loaded already, but doesn't have to be.
- `void Tex.SetMemory(Byte[]& imageFileData, bool sRGBData, bool blocking, int priority)` — Loads an image file stored in memory directly into the created texture! Supported formats are: jpg, png, tga, bmp, psd, gif, hdr, pic, ktx2. This method introduces a blocking boolean parameter, which allows you to specify whether this method blocks until the image fully loads! The default case is to have it as part of the asynchronous asset pipeline, in which the Asset Id will be the same as the filename.
  - `imageFileData` — The binary data of an image file, this is NOT a raw RGB color array!
  - `sRGBData` — Is this image color data in sRGB format, or is it normal/metal/rough/data that's not for direct display? sRGB colors get converted to linear color space on the graphics card, so getting this right can have a big impact on visuals.
  - `blocking` — Will this method wait for the image to load. By default, we try to load it asynchronously.
  - `priority` — The priority sort order for this asset in the async loading system. Lower values mean loading sooner.
- `void Tex.SetNativeSurface(IntPtr nativeTexture, TexType type, Int64 native_fmt, int width, int height, int surface_count, bool owned)` — This function is dependent on the graphics backend! It will take a texture resource for the current graphics backend (D3D or GL) and wrap it in a StereoKit texture for use within StereoKit. This is a bit of an advanced feature.
  - `nativeTexture` — For D3D, this should be an ID3D11Texture2D*, and for GL, this should be a uint32_t from a glGenTexture call, coerced into the IntPtr.
  - `type` — The image flags that tell SK how to treat the texture, this should match up with the settings the texture was originally created with. If SK can figure the appropriate settings, it _may_ override the value provided here.
  - `native_fmt` — The texture's format using the graphics backend's value, not SK's. This should match up with the settings the texture was originally created with. If SK can figure the appropriate settings, it _may_ override the value provided here.
  - `width` — Width of the texture. This should match up with the settings the texture was originally created with. If SK can figure the appropriate settings, it _may_ override the value provided here.
  - `height` — Height of the texture. This should match up with the settings the texture was originally created with. If SK can figure the appropriate settings, it _may_ override the value provided here.
  - `surface_count` — Texture array surface count. This should match up with the settings the texture was originally created with. If SK can figure the appropriate settings, it _may_ override the value provided here.
  - `owned` — Should ownership of this texture resource be passed on to StereoKit? If so, StereoKit may delete it when it's finished with it. If this is not desired, pass in false.
- `void Tex.SetSize(int width, int height, int arrayCount, int msaa)` — Set the texture's size without providing any color data. In most cases, you should probably just call SetColors instead, but this can be useful if you're adding color data some other way, such as when blitting or rendering to it.
  - `width` — Width in pixels of the texture. Powers of two are generally best!
  - `height` — Height in pixels of the texture. Powers of two are generally best!
  - `arrayCount` — How many surfaces are in this texture? A normal texture only has 1, but it can be useful to have multiple for certain rendering techniques or effects.
  - `msaa` — Multisample anti-aliasing, this is only important for render target type textures! This is the number of fragments that are drawn for each pixel to reduce sparkling / aliasing artifacts.

## enum TexAddress

What happens when the shader asks for a texture coordinate that's outside the texture?? Believe it or not, this happens plenty often!

- `TexAddress.Clamp` — Clamp the UV coordinates to the edge of the texture! This'll create color streaks that continue to forever. This is actually really great for non-looping textures that you know will always be accessed on the 0-1 range.
- `TexAddress.Mirror` — Like Wrap, but it reflects the image each time! Who needs this? I'm not sure!! But the graphics card can do it, so now you can too!
- `TexAddress.Wrap` — Wrap the UV coordinate around to the other side of the texture! This is basically like a looping texture, and is an excellent default. If you can see weird bits of color at the edges of your texture, this may be due to Wrap blending the color with the other side of the texture, Clamp may be better in such cases.

## enum TexFormat

What type of color information will the texture contain? A good default here is Rgba32, which gives 8-bit sRGB color with alpha! Most format names end in a short suffix telling you how the GPU interprets the bits when sampled in a shader: - no suffix or "un": unsigned normalized. Raw unsigned integers get normalized into the [0,1] floating point range on read. The default flavor for most color and data formats. - "sn": signed normalized. Raw signed integers get normalized into the [-1,1] floating point range on read. - "ui": unsigned integer. Raw unsigned integers, no normalization! Great for IDs, counters, and exact-integer data. - "si": signed integer. Raw signed integers, no normalization. - "f": signed float, typically an IEEE half or single precision float. - "uf": unsigned float, used by some HDR-leaning compact formats that can only represent non-negative values. - "_srgb": stored in sRGB color space! The GPU auto-converts to linear when sampled and back to sRGB when written. Use this for images viewed by humans, like photos and UI artwork. - "_linear": stored in linear color space, no color-space conversion at sample time. Use this for data textures, like normals, masks, roughness, and metallic. Any format that is _not_ "_srgb" is generally linear. Block-compressed formats (BC, ETC, ASTC, PVRTC, ATC) trade a little quality for a big drop in memory and bandwidth: each format packs an NxN block of pixels into a fixed payload, so cost is measured in bits-per-pixel rather than bits-per-channel. Hardware support varies - prefer BC on desktop/console, ASTC on modern mobile. They're sample-only; you can't render to them.

- `TexFormat.Astc4x4Rgba` — ASTC 4x4 linear color with full alpha, 8 bpp. High-quality compressed format for data textures on modern mobile GPUs.
- `TexFormat.Astc4x4RgbaSrgb` — ASTC 4x4 sRGB color with full alpha, 8 bpp. ASTC is the modern mobile-standard compressed format - excellent quality, broadly supported. The 4x4 block size is the highest-quality (and largest-size) ASTC variant.
- `TexFormat.AtcRgb` — ATC RGB on Qualcomm Adreno GPUs, 4 bpp. Historical Qualcomm-specific format - prefer Astc or Etc2 on newer Adreno hardware.
- `TexFormat.AtcRgba` — ATC with alpha on Qualcomm Adreno GPUs, 8 bpp. Historical Qualcomm-specific format - prefer Astc or Etc2 on newer Adreno hardware.
- `TexFormat.Bc1Rgb` — BC1/DXT1 linear RGB, no alpha, 4 bpp. Great for compressed data textures (normals, masks) on desktop and console GPUs. For color images for humans, use Bc1RgbSrgb.
- `TexFormat.Bc1Rgba` — BC1/DXT1 linear with 1-bit alpha, 4 bpp. Good for opaque data textures with a sharp cutout mask on desktop and console GPUs. For smooth alpha, reach for Bc3 or Bc7 instead.
- `TexFormat.Bc1RgbaSrgb` — BC1/DXT1 sRGB with 1-bit alpha, 4 bpp. Alpha is either fully on or fully off per pixel - great for cutout effects like foliage or chain-link fences. Smooth fade-outs will band hard though; reach for Bc3 or Bc7 for smooth alpha.
- `TexFormat.Bc1RgbSrgb` — BC1/DXT1 sRGB RGB, no alpha, 4 bpp. Each 4x4 block of pixels gets squished into 8 bytes, so a texture only takes a quarter of Rgba32's memory. Quality is good for opaque diffuse textures, though artifacts can show up in smooth gradients. Widely supported on desktop and console GPUs - not so much on mobile.
- `TexFormat.Bc2Rgba` — BC2/DXT3 linear with explicit 4-bit alpha, 8 bpp. Bc3 is usually preferred for smooth alpha gradients; Bc2 is mostly historical.
- `TexFormat.Bc2RgbaSrgb` — BC2/DXT3 sRGB with explicit 4-bit alpha, 8 bpp. Alpha gets 16 discrete levels - fine for blocky or dithered alpha but bands hard on smooth gradients. Bc3 is usually a better choice for smooth alpha; Bc2 is mostly historical.
- `TexFormat.Bc3Rgba` — BC3/DXT5 linear color with smooth alpha, 8 bpp. Great for compressed data textures with alpha (RGBA masks) on desktop and console GPUs.
- `TexFormat.Bc3RgbaSrgb` — BC3/DXT5 sRGB color with smooth alpha, 8 bpp. Alpha is BC4-compressed, giving much better gradients than Bc1 or Bc2. A solid default for color-with-alpha textures on desktop and console GPUs!
- `TexFormat.Bc4R` — BC4 unsigned-normalized single channel [0,1], 4 bpp. Ideal for compressed grayscale textures like heightmaps, ambient occlusion, or single-channel masks. Quality is excellent for smooth single-channel data.
- `TexFormat.Bc4Rsn` — BC4 signed-normalized single channel [-1,1], 4 bpp. Useful when your data is naturally signed, like signed distance fields or elevation difference maps.
- `TexFormat.Bc5Rg` — BC5 unsigned-normalized two channels, 8 bpp. Effectively two BC4 textures packed together. The standard format for compressed two-channel data on desktop/console - most commonly used for tangent-space normal maps where the Z component is reconstructed in the shader!
- `TexFormat.Bc5Rgsn` — BC5 signed-normalized two channels ([-1,1] per channel), 8 bpp. Useful for signed two-channel data, like normal maps stored as [-1,1] directly rather than the typical [0,1] packed form.
- `TexFormat.Bc6hRgbf` — BC6H HDR RGB, signed float (can store negative values), 8 bpp. 16-bit half-float per channel, no alpha. Use this when your HDR data can contain negatives, like signed spherical harmonics coefficients.
- `TexFormat.Bc6hRgbuf` — BC6H HDR RGB, unsigned float (positive values only), 8 bpp. 16-bit half-float per channel, no alpha. The go-to format for compressing HDR cubemaps and environment maps - stores high-dynamic-range data at a fraction of the cost of Rgba64f.
- `TexFormat.Bc7Rgba` — BC7 linear color with full alpha, 8 bpp. Highest-quality BC format - excellent for compressed RGBA data textures when Bc3 quality isn't enough.
- `TexFormat.Bc7RgbaSrgb` — BC7 sRGB color with full alpha, 8 bpp. The highest-quality BC format - noticeably better than Bc3 at the same compression ratio. Compression takes longer than Bc3 though, so reach for this when quality matters more than encoding speed.
- `TexFormat.Bgra32` — 8-bit sRGB B/G/R/A. Same as Rgba32Srgb but with R and B swapped to match the byte order some GPUs and Windows swapchains prefer. Most code can stick with Rgba32Srgb!
- `TexFormat.Bgra32Linear` — 8-bit linear B/G/R/A. Same as Rgba32Linear but with R and B swapped, mostly for compatibility with BGRA-preferring APIs like Windows swapchains.
- `TexFormat.Bgra32Srgb` — 8-bit sRGB B/G/R/A. Same as Rgba32Srgb but with R and B swapped to match the byte order some GPUs and Windows swapchains prefer. Most code can stick with Rgba32Srgb!
- `TexFormat.Depth16` — 16-bit depth - not a lot, but it can be enough if your far clipping plane is pretty close. If you're seeing z-fighting, either bring your far clip in or switch to 24/32-bit depth.
- `TexFormat.Depth16s8` — 16-bit depth + 8-bit stencil. A compact depth-with-stencil option for when precision needs are modest and memory is tight. If you see z-fighting, step up to Depth24s8 or Depth32s8.
- `TexFormat.Depth24s8` — 24-bit depth + 8-bit stencil. Depth tracks how close to the camera each pixel is so near objects correctly occlude far ones. Stencil data can be used for clipping effects, deferred rendering, or shadow effects. A sensible default for most scenes!
- `TexFormat.Depth32` — 32-bit depth. Pretty detailed, and excellent for experiences with very far view distances. No stencil bits though - if you need stencil too, use Depth32s8 instead.
- `TexFormat.Depth32s8` — 32-bit depth + 8-bit stencil (40 bpp). More depth precision than Depth24s8 but heavier on memory. Use this when you need both 32-bit depth precision and a stencil channel for masking effects.
- `TexFormat.DepthStencil` — 24-bit depth + 8-bit stencil. Depth tracks how close to the camera each pixel is so near objects correctly occlude far ones. Stencil data can be used for clipping effects, deferred rendering, or shadow effects. A sensible default for most scenes!
- `TexFormat.Etc1Rgb` — ETC1 RGB, no alpha, 4 bpp. Widely supported on older Android devices and OpenGL ES 2.0+ GPUs. Quality is acceptable for diffuse color but it's been superseded - prefer Etc2 or Astc on newer hardware!
- `TexFormat.Etc2R11` — ETC2/EAC single 11-bit unsigned-normalized channel, 4 bpp. The ETC equivalent of Bc4 - great for compressed grayscale or heightmap data on mobile GPUs!
- `TexFormat.Etc2Rg11` — ETC2/EAC two 11-bit unsigned-normalized channels, 8 bpp. The ETC equivalent of Bc5 - great for compressed two-channel data like tangent-space normal maps on mobile GPUs!
- `TexFormat.Etc2Rgba` — ETC2 linear color with full alpha, 8 bpp. Standard compressed format for data textures with alpha on OpenGL ES 3.0+ mobile devices.
- `TexFormat.Etc2RgbaSrgb` — ETC2 sRGB color with full alpha, 8 bpp. The standard compressed RGBA format on OpenGL ES 3.0+ mobile devices, and mandatory in the spec - so it's widely available. A great default for sRGB color textures on mobile!
- `TexFormat.None` — Default zero value for TexFormat! Uninitialized formats land here and **** **** up so you know to assign one properly :)
- `TexFormat.Nv12` — NV12 video format - a 2-plane 4:2:0 YUV layout! Plane 1 is a full-resolution Y (luminance) plane at 8 bpp, plane 2 is a half-resolution UV (chrominance) plane with U and V interleaved at 8 bits each. The most common output format from hardware video decoders!
- `TexFormat.P010` — P010 video format - like NV12 but with 10-bit channels stored in 16-bit fields. Full-resolution 10-bit Y plane plus a half-resolution interleaved 10-bit UV plane. Used for 10-bit HDR video!
- `TexFormat.Pvrtc1Rgb` — PVRTC1 linear RGB, 2 bpp. PowerVR GPUs only, requires power-of-two square textures.
- `TexFormat.Pvrtc1Rgba` — PVRTC1 linear with full alpha, 4 bpp. PowerVR GPUs only, requires power-of-two square textures.
- `TexFormat.Pvrtc1RgbaSrgb` — PVRTC1 sRGB with full alpha, 4 bpp. The 4bpp variant is higher quality than the 2bpp variants. PowerVR GPUs only, requires power-of-two square textures.
- `TexFormat.Pvrtc1RgbSrgb` — PVRTC1 sRGB RGB, 2 bpp. Used on iOS and other PowerVR GPUs. The 2bpp bitrate is super compact but quality is lower than ETC/BC - acceptable for low-detail or background textures. Requires power-of-two square textures!
- `TexFormat.Pvrtc2Rgba` — PVRTC2 linear with full alpha, 4 bpp. Better quality and more flexible texture sizes than PVRTC1. PowerVR GPUs only.
- `TexFormat.Pvrtc2RgbaSrgb` — PVRTC2 sRGB with full alpha, 4 bpp. An update to PVRTC1 with better quality and fewer restrictions - works with non-power-of-two and non-square textures. Still PowerVR-specific though.
- `TexFormat.R16` — 16-bit unsigned-normalized single channel. A good format for height maps, since it stores a fair bit of information!
- `TexFormat.R16f` — 16-bit half-float single channel. Good for HDR height/depth data that needs a range beyond what normalized formats give you.
- `TexFormat.R16s` — 16-bit signed-normalized single channel. Good for signed height data or signed distance fields.
- `TexFormat.R16si` — 16-bit signed-integer single channel. Good for signed integer or ID data.
- `TexFormat.R16sn` — 16-bit signed-normalized single channel. Good for signed height data or signed distance fields.
- `TexFormat.R16u` — 16-bit unsigned-normalized single channel. A good format for height maps, since it stores a fair bit of information!
- `TexFormat.R16ui` — 16-bit unsigned-integer single channel. A great format for index or ID data, since values are accessed as raw integers.
- `TexFormat.R16un` — 16-bit unsigned-normalized single channel. A good format for height maps, since it stores a fair bit of information!
- `TexFormat.R32` — 32-bit single-precision float single channel. Treats each pixel as a generic float, so you can do all sorts of strange and interesting things with this! Great for scientific data, signed distance fields, or detailed height fields where 16 bits of precision aren't enough.
- `TexFormat.R32f` — 32-bit single-precision float single channel. Treats each pixel as a generic float, so you can do all sorts of strange and interesting things with this! Great for scientific data, signed distance fields, or detailed height fields where 16 bits of precision aren't enough.
- `TexFormat.R32si` — 32-bit signed-integer single channel.
- `TexFormat.R32ui` — 32-bit unsigned-integer single channel. Useful for counters, IDs, and atomic compute operations.
- `TexFormat.R8` — 8-bit unsigned-normalized single channel. Great when you only need one channel and want to keep memory down.
- `TexFormat.R8g8` — Two 8-bit unsigned-normalized channels (R, G). Useful for two-component data like compressed normals where the third axis is reconstructed in the shader, or two grayscale signals stored side by side.
- `TexFormat.R8si` — 8-bit signed-integer single channel.
- `TexFormat.R8sn` — 8-bit signed-normalized single channel. Useful for a single signed value like an elevation difference or signed mask.
- `TexFormat.R8Srgb` — 8-bit sRGB single channel. Useful for single-channel sRGB data like a luminance map that should be linearized before lighting math.
- `TexFormat.R8ui` — 8-bit unsigned-integer single channel. Good for small IDs, indices, or stencil-like data accessed as exact integers.
- `TexFormat.Rg11b10` — Packed HDR R/G/B as unsigned floats - 11 bits for R and G, 10 for B, no alpha. A great compact HDR format: holds values way beyond the [0,1] range that Rgba32 maxes out at, while still fitting in 32 bpp! Great for HDR render targets and intermediate compute buffers. Not universally supported as a render target, so watch for that!
- `TexFormat.Rg11b10uf` — Packed HDR R/G/B as unsigned floats - 11 bits for R and G, 10 for B, no alpha. A great compact HDR format: holds values way beyond the [0,1] range that Rgba32 maxes out at, while still fitting in 32 bpp! Great for HDR render targets and intermediate compute buffers. Not universally supported as a render target, so watch for that!
- `TexFormat.Rgb10a2` — Packed unsigned-normalized R/G/B/A with 10 bits per color channel and 2 bits for alpha. A great presentation format for high bit-depth displays that still fits in 32 bpp, and you get a bit of transparency too! Alpha is effectively on/off/halfway though, so skip this if you need smooth alpha. Not universally supported as a render target!
- `TexFormat.Rgb9e5` — Shared-exponent HDR R/G/B with 9-bit mantissa per channel and a 5-bit shared exponent. A compact HDR format that packs values way beyond the [0,1] range into just 32 bpp! No alpha though, and sharing the exponent means all three channels need similar magnitudes - perfect for environment maps! Usually sample-only; GPUs typically can't render to it.
- `TexFormat.Rgb9e5uf` — Shared-exponent HDR R/G/B with 9-bit mantissa per channel and a 5-bit shared exponent. A compact HDR format that packs values way beyond the [0,1] range into just 32 bpp! No alpha though, and sharing the exponent means all three channels need similar magnitudes - perfect for environment maps! Usually sample-only; GPUs typically can't render to it.
- `TexFormat.Rgba128` — 32-bit float R/G/B/A - basically 4 single-precision floats per pixel, which is bonkers expensive at 128 bpp! Don't reach for this unless you know -exactly- what you're doing. Useful for scientific data or compute buffers where you really need full 32-bit float precision per channel.
- `TexFormat.Rgba128f` — 32-bit float R/G/B/A - basically 4 single-precision floats per pixel, which is bonkers expensive at 128 bpp! Don't reach for this unless you know -exactly- what you're doing. Useful for scientific data or compute buffers where you really need full 32-bit float precision per channel.
- `TexFormat.Rgba32` — 8-bit sRGB R/G/B/A. The default for human-viewed color images, and a clean match for the Color32 struct! For data textures (normals, masks, rough/metal) use Rgba32Linear instead.
- `TexFormat.Rgba32Linear` — 8-bit linear R/G/B/A. Use this for data textures (normals, masks, rough/metal) where you don't want the GPU's automatic sRGB conversion getting in the way.
- `TexFormat.Rgba32Srgb` — 8-bit sRGB R/G/B/A. The default for human-viewed color images, and a clean match for the Color32 struct! For data textures (normals, masks, rough/metal) use Rgba32Linear instead.
- `TexFormat.Rgba64` — 16-bit unsigned-normalized R/G/B/A (64 bpp). Doubling the bit depth over Rgba32 gives much smoother gradients!
- `TexFormat.Rgba64f` — 16-bit half-float R/G/B/A (64 bpp). A common HDR render-target format - full RGBA float precision at half the memory of Rgba128. Almost always supported as a render target, so a reliable fallback for formats like Rg11b10.
- `TexFormat.Rgba64si` — 16-bit signed-integer R/G/B/A (64 bpp). For [-1,1] sampling, use Rgba64sn instead.
- `TexFormat.Rgba64sn` — 16-bit signed-normalized R/G/B/A (64 bpp).
- `TexFormat.Rgba64ui` — 16-bit unsigned-integer R/G/B/A (64 bpp). Great for ID textures, counters, or any discrete-integer data. For [0,1] sampling, use Rgba64un instead.
- `TexFormat.Rgba64un` — 16-bit unsigned-normalized R/G/B/A (64 bpp). Doubling the bit depth over Rgba32 gives much smoother gradients!
- `TexFormat.Yuv420p` — A 3-plane 4:2:0 YUV layout - separate Y, U, and V planes each at 8 bpp, with U and V at half resolution. Common in software video decoders but less common from hardware decoders (which usually output NV12).

## enum TexSample

How does the shader grab pixels from the texture? Or more specifically, how does the shader grab colors between the provided pixels? If you'd like an in-depth explanation of these topics, check out [this exploration of texture filtering](https://bgolus.medium.com/sharper-mipmapping-using-shader-based-supersampling-ed7aadb47bec) by graphics wizard Ben Golus.

- `TexSample.Anisotropic` — This helps reduce texture blurriness when a surface is viewed at an extreme angle!
- `TexSample.Linear` — Use a linear blend between adjacent pixels, this creates a smooth, blurry look when texture resolution is too low.
- `TexSample.Point` — Choose the nearest pixel's color! This makes your texture look like pixel art if you're too close.

## enum TexSampleComp

When sampling from a texture with comparison enabled, the sampler compares the sampled texel value against a reference value and returns a 0 or 1 based on the result. This is primarily useful for shadow mapping techniques, where a depth texture is sampled to determine if a surface is in shadow.

- `TexSampleComp.Always` — Always returns 1, regardless of values.
- `TexSampleComp.Equal` — Returns 1 if the reference value is equal to the sampled texel value.
- `TexSampleComp.Greater` — Returns 1 if the reference value is greater than the sampled texel value.
- `TexSampleComp.GreaterOrEq` — Returns 1 if the reference value is greater than or equal to the sampled texel value.
- `TexSampleComp.Less` — Returns 1 if the reference value is less than the sampled texel value.
- `TexSampleComp.LessOrEq` — Returns 1 if the reference value is less than or equal to the sampled texel value.
- `TexSampleComp.Never` — Always returns 0, regardless of values.
- `TexSampleComp.None` — No comparison is performed, the texture is sampled normally. This is the default behavior for most textures.
- `TexSampleComp.NotEqual` — Returns 1 if the reference value is not equal to the sampled texel value.

## static class Text

A collection of functions for rendering and working with text. These are a lower level access to text rendering than the UI text functions, and are completely unaware of the UI code.
- `static void Text.Add(string text, Matrix transform, TextStyle style, Pivot position, Align align, float offX, float offY, float offZ)` — Renders text at the given location! Must be called every frame you want this text to be visible.
  - `text` — What text should be drawn?
  - `transform` — A Matrix representing the transform of the text mesh! Try Matrix.TRS.
  - `style` — Style information for rendering, see Text.MakeStyle or the TextStyle object.
  - `position` — How should the text's bounding rectangle be positioned relative to the transform?
  - `align` — How should the text be aligned within the text's bounding rectangle?
  - `offX` — An additional offset on the X axis.
  - `offY` — An additional offset on the Y axis.
  - `offZ` — An additional offset on the Z axis.
- `static void Text.Add(string text, Matrix transform, Pivot position, Align align, float offX, float offY, float offZ)` — Renders text at the given location! Must be called every frame you want this text to be visible.
  - `text` — What text should be drawn?
  - `transform` — A Matrix representing the transform of the text mesh! Try Matrix.TRS.
  - `position` — How should the text's bounding rectangle be positioned relative to the transform?
  - `align` — How should the text be aligned within the text's bounding rectangle?
  - `offX` — An additional offset on the X axis.
  - `offY` — An additional offset on the Y axis.
  - `offZ` — An additional offset on the Z axis.
- `static void Text.Add(string text, Matrix transform, TextStyle style, Color vertexTintLinear, Pivot position, Align align, float offX, float offY, float offZ)` — Renders text at the given location! Must be called every frame you want this text to be visible.
  - `text` — What text should be drawn?
  - `transform` — A Matrix representing the transform of the text mesh! Try Matrix.TRS.
  - `style` — Style information for rendering, see Text.MakeStyle or the TextStyle object.
  - `position` — How should the text's bounding rectangle be positioned relative to the transform?
  - `align` — How should the text be aligned within the text's bounding rectangle?
  - `offX` — An additional offset on the X axis.
  - `offY` — An additional offset on the Y axis.
  - `offZ` — An additional offset on the Z axis.
  - `vertexTintLinear` — The vertex color of the text gets multiplied by this color. This is a linear color value, not a gamma corrected color value.
- `static void Text.Add(string text, Matrix transform, Color vertexTintLinear, Pivot position, Align align, float offX, float offY, float offZ)` — Renders text at the given location! Must be called every frame you want this text to be visible.
  - `text` — What text should be drawn?
  - `transform` — A Matrix representing the transform of the text mesh! Try Matrix.TRS.
  - `position` — How should the text's bounding rectangle be positioned relative to the transform?
  - `align` — How should the text be aligned within the text's bounding rectangle?
  - `offX` — An additional offset on the X axis.
  - `offY` — An additional offset on the Y axis.
  - `offZ` — An additional offset on the Z axis.
  - `vertexTintLinear` — The vertex color of the text gets multiplied by this color. This is a linear color value, not a gamma corrected color value.
- `static float Text.Add(string text, Matrix transform, Vec2 size, TextFit fit, TextStyle style, Pivot position, Align align, float offX, float offY, float offZ)` — Renders text at the given location! Must be called every frame you want this text to be visible.
  - `text` — What text should be drawn?
  - `transform` — A Matrix representing the transform of the text mesh! Try Matrix.TRS.
  - `size` — This is the Hierarchy space rectangle that the text should try to fit inside of. This allows for text wrapping or scaling based on the value provided to the 'fit' parameter.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter.
  - `style` — Style information for rendering, see Text.MakeStyle or the TextStyle object.
  - `position` — How should the text's bounding rectangle be positioned relative to the transform?
  - `align` — How should the text be aligned within the text's bounding rectangle?
  - `offX` — An additional offset on the X axis.
  - `offY` — An additional offset on the Y axis.
  - `offZ` — An additional offset on the Z axis.
  - returns — Returns the vertical space used by this text.
- `static float Text.Add(string text, Matrix transform, Vec2 size, TextFit fit, Pivot position, Align align, float offX, float offY, float offZ)` — Renders text at the given location! Must be called every frame you want this text to be visible.
  - `text` — What text should be drawn?
  - `transform` — A Matrix representing the transform of the text mesh! Try Matrix.TRS.
  - `size` — This is the Hierarchy space rectangle that the text should try to fit inside of. This allows for text wrapping or scaling based on the value provided to the 'fit' parameter.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter.
  - `position` — How should the text's bounding rectangle be positioned relative to the transform?
  - `align` — How should the text be aligned within the text's bounding rectangle?
  - `offX` — An additional offset on the X axis.
  - `offY` — An additional offset on the Y axis.
  - `offZ` — An additional offset on the Z axis.
  - returns — Returns the vertical space used by this text.
- `static float Text.Add(string text, Matrix transform, Vec2 size, TextFit fit, Color vertexTintLinear, Pivot position, Align align, float offX, float offY, float offZ)` — Renders text at the given location! Must be called every frame you want this text to be visible.
  - `text` — What text should be drawn?
  - `transform` — A Matrix representing the transform of the text mesh! Try Matrix.TRS.
  - `size` — This is the Hierarchy space rectangle that the text should try to fit inside of. This allows for text wrapping or scaling based on the value provided to the 'fit' parameter.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter.
  - `position` — How should the text's bounding rectangle be positioned relative to the transform?
  - `align` — How should the text be aligned within the text's bounding rectangle?
  - `offX` — An additional offset on the X axis.
  - `offY` — An additional offset on the Y axis.
  - `offZ` — An additional offset on the Z axis.
  - `vertexTintLinear` — The vertex color of the text gets multiplied by this color. This is a linear color value, not a gamma corrected color value.
  - returns — Returns the vertical space used by this text.
- `static float Text.Add(string text, Matrix transform, Vec2 size, TextFit fit, TextStyle style, Color vertexTintLinear, Pivot position, Align align, float offX, float offY, float offZ)` — Renders text at the given location! Must be called every frame you want this text to be visible.
  - `text` — What text should be drawn?
  - `transform` — A Matrix representing the transform of the text mesh! Try Matrix.TRS.
  - `size` — This is the Hierarchy space rectangle that the text should try to fit inside of. This allows for text wrapping or scaling based on the value provided to the 'fit' parameter.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter.
  - `style` — Style information for rendering, see Text.MakeStyle or the TextStyle object.
  - `position` — How should the text's bounding rectangle be positioned relative to the transform?
  - `align` — How should the text be aligned within the text's bounding rectangle?
  - `offX` — An additional offset on the X axis.
  - `offY` — An additional offset on the Y axis.
  - `offZ` — An additional offset on the Z axis.
  - `vertexTintLinear` — The vertex color of the text gets multiplied by this color. This is a linear color value, not a gamma corrected color value.
  - returns — Returns the vertical space used by this text.
  - Example: see `Text.Add` in StereoKit-docs-reference.md
- `static TextStyle Text.MakeStyle(Font font, float layoutHeightMeters, Color colorGamma)` — Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project. This overload will create a unique Material for this style based on Default.ShaderFont.
  - `font` — Font asset you want attached to this style.
  - `layoutHeightMeters` — Height of a text glyph in meters. StereoKit currently bases this on CapHeight.
  - `colorGamma` — The gamma space color of the text style. This will be embedded in the vertex color of the text mesh.
  - returns — A text style id for use with text rendering functions.
- `static TextStyle Text.MakeStyle(Font font, float layoutHeightMeters, Shader shader, Color colorGamma)` — Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project. This overload will create a unique Material for this style based on the provided Shader.
  - `font` — Font asset you want attached to this style.
  - `layoutHeightMeters` — Height of a text glyph in meters. StereoKit currently bases this on CapHeight.
  - `shader` — This style will create and use a unique Material based on the Shader that you provide here.
  - `colorGamma` — The gamma space color of the text style. This will be embedded in the vertex color of the text mesh.
  - returns — A text style id for use with text rendering functions.
- `static TextStyle Text.MakeStyle(Font font, float layoutHeightMeters, Material material, Color colorGamma)` — Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project. This overload allows you to set the specific Material that is used. This can be helpful if you're keeping styles similar enough to re-use the material and save on draw calls. If you don't know what that means, then prefer using the overload that takes a Shader, or takes neither a Shader nor a Material!
  - `font` — Font asset you want attached to this style.
  - `layoutHeightMeters` — Height of a text glyph in meters. StereoKit currently bases this on CapHeight.
  - `material` — Which material should be used to render the text with? Note that this does NOT duplicate the material, so some parameters of this Material instance will get overwritten, like the texture used for the glyph atlas. You should either use a new Material, or a Material that was already used with this same font.
  - `colorGamma` — The gamma space color of the text style. This will be embedded in the vertex color of the text mesh.
  - returns — A text style id for use with text rendering functions.
  - Example: see `Text.MakeStyle` in StereoKit-docs-reference.md
- `static Vec2 Text.Size(string text, TextStyle style)` — Sometimes you just need to know how much room some text takes up! This finds the size of the text in meters when using the indicated style!
  - `text` — Text you want to find the size of.
  - `style` — The visual style of the text, see Text.MakeStyle or the TextStyle object for more details.
  - returns — The width and height of the text in meters.
- `static Vec2 Text.Size(string text)` — Sometimes you just need to know how much room some text takes up! This finds the size of the text in meters when using the default style!
  - `text` — Text you want to find the size of.
  - returns — The width and height of the text in meters.
- `static Vec2 Text.Size(string text, float maxWidth)` — Need to know how much space text will take when constrained to a certain width? This will find it using the default text style!
  - `text` — Text to measure the size of.
  - `maxWidth` — Width of the available space in meters.
  - returns — The size that this text will take up, in meters! Width will be the same as maxWidth as long as the text takes more than one line, and height will be the total height of the text.
- `static Vec2 Text.Size(string text, TextStyle style, float maxWidth)` — Need to know how much space text will take when constrained to a certain width? This will find it using the indicated text style!
  - `text` — Text to measure the size of.
  - `maxWidth` — Width of the available space in meters.
  - returns — The size that this text will take up, in meters! Width will be the same as maxWidth as long as the text takes more than one line, and height will be the total height of the text.
- `static Vec2 Text.SizeLayout(string text, TextStyle style)` — Sometimes you just need to know how much room some text takes up! This finds the layout size of the text in meters when using the indicated style!  This does not include ascender and descender size, so rendering using this as a clipping size will result in ascenders and descenders getting clipped.
  - `text` — Text you want to find the size of.
  - `style` — The visual style of the text, see Text.MakeStyle or the TextStyle object for more details.
  - returns — The width and height of the text in meters.
- `static Vec2 Text.SizeLayout(string text, TextStyle style, float maxWidth)` — Need to know how much layout space text will take when constrained to a certain width? This will find it using the indicated text style! This does not include ascender and descender size, so rendering using this as a clipping size will result in ascenders and descenders getting clipped.
  - `text` — Text to measure the size of.
  - `maxWidth` — Width of the available space in meters.
  - returns — The layoutsize that this text will take up, in meters! Width will be the same as maxWidth as long as the text takes more than one line, and height will be the total layout height of the text.
  - Example: see `Text.SizeLayout` in StereoKit-docs-reference.md
- `static Vec2 Text.SizeRender(Vec2 sizeLayout, TextStyle style, Single& yOffset)` — This modifies a text layout size to include the tallest and lowest possible values for the glyphs in this font. This is for when you need to be careful about avoiding clipping that would happen if you only used the layout size.
  - `sizeLayout` — A size previously calculated using `Text.SizeLayout`.
  - `style` — The same style as used for calculating the sizeLayout.
  - `yOffset` — Since the render size will ascend from the initial position, this will be the offset from the initial position upwards. You should add it to your Y position.
  - returns — The sizeLayout modified to account for the size of the most extreme glyphs.
  - Example: see `Text.SizeRender` in StereoKit-docs-reference.md

## struct TextAlign

A bit-flag enum for describing alignment or positioning. Items can be combined using the '|' operator, like so: `Align alignment = Align.YTop | Align.XLeft;` Avoid combining multiple items of the same axis. There are also a complete list of valid bit flag combinations! These are the values without an axis listed in their names, 'TopLeft', 'BottomCenter', etc.

- `static TextAlign TextAlign.BottomCenter` — Center on the X axis, and bottom on the Y axis. This is a combination of XCenter and YBottom.
- `static TextAlign TextAlign.BottomLeft` — Start on the left of the X axis, and bottom on the Y axis. This is a combination of XLeft and YBottom.
- `static TextAlign TextAlign.BottomRight` — Start on the right of the X axis, and bottom on the Y axis.This is a combination of XRight and YBottom.
- `static TextAlign TextAlign.Center` — Center on both X and Y axes. This is a combination of XCenter and YCenter.
- `static TextAlign TextAlign.CenterLeft` — Start on the left of the X axis, center on the Y axis. This is a combination of XLeft and YCenter.
- `static TextAlign TextAlign.CenterRight` — Start on the right of the X axis, center on the Y axis. This is a combination of XRight and YCenter.
- `static TextAlign TextAlign.TopCenter` — Center on the X axis, and top on the Y axis. This is a combination of XCenter and YTop.
- `static TextAlign TextAlign.TopLeft` — Start on the left of the X axis, and top on the Y axis. This is a combination of XLeft and YTop.
- `static TextAlign TextAlign.TopRight` — Start on the right of the X axis, and top on the Y axis. This is a combination of XRight and YTop.
- `static TextAlign TextAlign.XCenter` — On the x axis, the item should be centered.
- `static TextAlign TextAlign.XLeft` — On the x axis, this item should start on the left.
- `static TextAlign TextAlign.XRight` — On the x axis, this item should start on the right.
- `static TextAlign TextAlign.YBottom` — On the y axis, this item should start on the bottom.
- `static TextAlign TextAlign.YCenter` — On the y axis, the item should be centered.
- `static TextAlign TextAlign.YTop` — On the y axis, this item should start at the top.
- `static TextAlign TextAlign.op_BitwiseAnd(TextAlign a, TextAlign b)` — Allow Flag-like enum behavior.
  - `a` — First TextAlign
  - `b` — Second TextAlign
  - returns — Bitwise operation of a and b.
- `static TextAlign TextAlign.op_BitwiseOr(TextAlign a, TextAlign b)` — Allow Flag-like enum behavior.
  - `a` — First TextAlign
  - `b` — Second TextAlign
  - returns — Bitwise operation of a and b.
- `static TextAlign TextAlign.op_ExclusiveOr(TextAlign a, TextAlign b)` — Allow Flag-like enum behavior.
  - `a` — First TextAlign
  - `b` — Second TextAlign
  - returns — Bitwise operation of a and b.
- `static Align TextAlign.Implicit Conversions(TextAlign a)` — For back compatibility, allows conversion from a TextAlign into an Align while providing a good obsolescence message for it.
  - `a` — Source TextAlign.
  - returns — An equivalent Align.
- `static Align TextAlign.Implicit Conversions(TextAlign a)` — For back compatibility, allows conversion from a TextAlign into a Pivot while providing a good obsolescence message for it.
  - `a` — Source TextAlign.
  - returns — An equivalent Pivot.
- `static TextAlign TextAlign.op_OnesComplement(TextAlign a)` — Allow Flag-like enum behavior.
  - `a` — First TextAlign
  - returns — Bitwise operation of a.

## enum TextContext

Soft keyboard layouts are often specific to the type of text that they're editing! This enum is a collection of common text contexts that SK can pass along to the OS's soft keyboard for a more optimal layout.

- `TextContext.Number` — Numbers and numerical values.
- `TextContext.Password` — This is a password, and should not be visible when typed!
- `TextContext.Text` — General text editing, this is the most common type of text, and would result in a 'standard' keyboard layout.
- `TextContext.Uri` — This text specifically represents some kind of URL/URI address.

## enum TextFit

This enum describes how text layout behaves within the space it is given.

- `TextFit.Clip` — When the text reaches the end, it is simply truncated and no longer visible.
- `TextFit.Exact` — If the text is larger, or smaller than the space provided, it will scale down or up to fill the space.
- `TextFit.None` — No particularly special behavior.
- `TextFit.Overflow` — The text will ignore the containing space, and just keep on going.
- `TextFit.Squeeze` — If the text is too large to fit in the space provided, it will be scaled down to fit inside. This will not scale up.
- `TextFit.Wrap` — The text will wrap around to the next line down when it reaches the end of the space on the X axis.

## struct TextStyle

A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project. See Text.MakeStyle for making a TextStyle object.

- `float TextStyle.Ascender` — (meters) The layout ascender of the font, this is the height of the "tallest" glyphs as far as layout is concerned. Characters such as 'l' typically rise above the CapHeight, and this value usually matches this height. Some glyphs such as those with hats or umlauts will almost always be taller than this height (see Text.SizeRender), but this is not used when laying out characters.
- `float TextStyle.CapHeight` — (meters) The height of a standard captial letter, such as 'H' or 'T'.
- `float TextStyle.CharHeight` — Returns the maximum height of a text character using this style, in meters.
- `float TextStyle.Descender` — (meters) The layout descender of the font, this is the positive height below the baseline
- `float TextStyle.LayoutHeight` — (meters) Layout height is the height of the font's CapHeight, which is used for calculating the vertical height of the text when doing text layouts. This does _not_ include the height of the descender, nor does it represent the maximum possible height a glyph may extend upwards (use Text.SizeRender).
- `float TextStyle.LineHeightPct` — This is the space a full line of text takes, from baseline to baseline, as a 0-1 percentage of the font's TotalHeight. This is similar to CSS line-height, a value of 1.0 means this line's descenders will squish up adjacent to the next line's tallest ascenders.
- `Material TextStyle.Material` — This provides a reference to the Material used by this style, so you can override certain features! Note that if you're creating TextStyles with manually provided Materials, this Material may not be unique to this style.
- `RenderLayer TextStyle.RenderLayer` — The RenderLayer that text drawn with this style is rendered on. This defaults to RenderLayer.Vfx. Note that text styles are batched per layer, so changing this will re-point the style at a different internal text buffer.
- `float TextStyle.TotalHeight` — (meters) Height from the layout descender to the layout ascender. This is most equivalent to the 'font-size' in CSS or other text layout tools. Since ascender and descenders can vary a lot, using LayoutHeight in many cases can lead to more consistency in the long run.
- `static TextStyle TextStyle.Default` — This is the default text style used by StereoKit.
- `static TextStyle TextStyle.FromFont(Font font, float layoutHeightMeters, Color colorGamma)` — Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project. This overload will create a unique Material for this style based on Default.ShaderFont.
  - `font` — Font asset you want attached to this style.
  - `layoutHeightMeters` — Height of a text glyph in meters. StereoKit currently bases this on CapHeight.
  - `colorGamma` — The gamma space color of the text style. This will be embedded in the vertex color of the text mesh.
  - returns — A text style id for use with text rendering functions.
- `static TextStyle TextStyle.FromFont(Font font, float layoutHeightMeters, Shader shader, Color colorGamma)` — Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project. This overload will create a unique Material for this style based on the provided Shader.
  - `font` — Font asset you want attached to this style.
  - `layoutHeightMeters` — Height of a text glyph in meters. StereoKit currently bases this on CapHeight.
  - `shader` — This style will create and use a unique Material based on the Shader that you provide here.
  - `colorGamma` — The gamma space color of the text style. This will be embedded in the vertex color of the text mesh.
  - returns — A text style id for use with text rendering functions.
- `static TextStyle TextStyle.FromFont(Font font, float layoutHeightMeters, Material material, Color colorGamma)` — Create a text style for use with other text functions! A text style is a font plus size/color/material parameters, and are used to keep text looking more consistent through the application by encouraging devs to re-use styles throughout the project. This overload allows you to set the specific Material that is used. This can be helpful if you're keeping styles similar enough to re-use the material and save on draw calls. If you don't know what that means, then prefer using the overload that takes a Shader, or takes neither a Shader nor a Material!
  - `font` — Font asset you want attached to this style.
  - `layoutHeightMeters` — Height of a text glyph in meters. StereoKit currently bases this on CapHeight.
  - `material` — Which material should be used to render the text with? Note that this does NOT duplicate the material, so some parameters of this Material instance will get overwritten, like the texture used for the glyph atlas. You should either use a new Material, or a Material that was already used with this same font.
  - `colorGamma` — The gamma space color of the text style. This will be embedded in the vertex color of the text mesh.
  - returns — A text style id for use with text rendering functions.

## enum TexType

Textures come in various types and flavors! These are bit-flags that tell StereoKit what type of texture we want, and how the application might use it!

- `TexType.Compute` — This texture can be used as a RWTexture in compute shaders. Create it with a format that supports storage images, such as tex_format_rgba128.
- `TexType.Cubemap` — A size sided texture that's used for things like skyboxes, environment maps, and reflection probes. It behaves like a texture array with 6 textures.
- `TexType.Depth` — This texture contains depth data, not color data! It is writeable, but not readable. This makes it great for zbuffers, but not shadowmaps or other textures that need to be read from later on.
- `TexType.Depthtarget` — This texture contains depth data, not color data! It is writeable and readable. This makes it great for shadowmaps or other textures that need to be read from later on.
- `TexType.Dynamic` — This texture's data will be updated frequently from the CPU (not renders)! This ensures the graphics card stores it someplace where writes are easy to do quickly.
- `TexType.Image` — A standard color image that also generates mip-maps automatically.
- `TexType.ImageNomips` — A standard color image, without any generated mip-maps.
- `TexType.Mips` — This texture will generate mip-maps any time the contents change. Mip-maps are a list of textures that are each half the size of the one before them! This is used to prevent textures from 'sparkling' or aliasing in the distance.
- `TexType.Rendertarget` — This texture can be rendered to! This is great for textures that might be passed in as a target to Renderer.Blit, or other such situations.
- `TexType.Volume` — A volumetric (3D) texture, sized with width, height, and depth. Volume textures are mutually exclusive with Cubemap and array textures, and don't pair with a zbuffer.
- `TexType.Zbuffer` — This texture contains depth data, not color data! It is writeable, but not readable. This makes it great for zbuffers, but not shadowmaps or other textures that need to be read from later on.

## static class Time

This class contains time information for the current session and frame!

- `static UInt64 Time.Frame` — The number of frames/steps since the app started.
- `static UInt64 Time.PerfCPUus` — Microseconds of CPU work for the renderer during the most recently completed frame. This measures wall-clock time from command buffer acquisition through queue submission, excluding any time spent waiting on GPU fences or vsync. This is useful for identifying CPU-side rendering bottlenecks such as draw call overhead or resource uploads. Returns 0 if timing data is not yet available (first few frames).
- `static UInt64 Time.PerfGPUus` — Microseconds the GPU spent executing rendering commands for the most recently completed frame. Measured via hardware timestamp queries at the top and bottom of the Vulkan pipeline, so this reflects actual GPU execution time independent of CPU pacing or vsync. Useful for identifying GPU-bound scenarios like expensive shaders or overdraw. Returns 0 if timing data is not yet available (first few frames).
- `static double Time.Scale` — Time is scaled by this value! Want time to pass slower? Set it to 0.5! Faster? Try 2!
- `static double Time.Step` — How many seconds have elapsed since the last frame? 64 bit time precision, calculated at the start of the frame.
- `static float Time.Stepf` — How many seconds have elapsed since the last frame? 32 bit time precision, calculated at the start of the frame.
- `static double Time.StepUnscaled` — How many seconds have elapsed since the last frame? 64 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!
- `static float Time.StepUnscaledf` — How many seconds have elapsed since the last frame? 32 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!
- `static double Time.Total` — How many seconds have elapsed since StereoKit was initialized? 64 bit time precision, calculated at the start of the frame.
- `static float Time.Totalf` — How many seconds have elapsed since StereoKit was initialized? 32 bit time precision, calculated at the start of the frame.
- `static double Time.TotalUnscaled` — How many seconds have elapsed since StereoKit was initialized? 64 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!
- `static float Time.TotalUnscaledf` — How many seconds have elapsed since StereoKit was initialized? 32 bit time precision, calculated at the start of the frame. This version is unaffected by the Time.Scale value!
- `static void Time.SetTime(double totalSeconds, double frameElapsedSeconds)` — This allows you to override the application time! The application will progress from this time using the current timescale.
  - `totalSeconds` — What time should it now be? The app will progress from this point in time.
  - `frameElapsedSeconds` — How long was the previous frame? This is a number often used in motion calculations. If left to zero, it'll use the previous frame's time, and if the previous frame's time was also zero, it'll use 1/90.

## enum TrackState

This is the tracking state of a sensory input in the world, like a controller's position sensor, or a QR code identified by a tracking system.

- `TrackState.Inferred` — The system doesn't know for sure where this is, but it has an educated guess that may be inferred from previous data at a lower quality. For example, a controller may still have accelerometer data after going out of view, which can still be accurate for a short time after losing optical tracking.
- `TrackState.Known` — The system actively knows where this input is. Within the constraints of the relevant hardware's capabilities, this is as accurate as it gets!
- `TrackState.Lost` — The system has no current knowledge about the state of this input. It may be out of visibility, or possibly just disconnected.

## enum Transparency

Also known as 'alpha' for those in the know. But there's actually more than one type of transparency in rendering! The horrors. We're keepin' it fairly simple for now, so you get three options!

- `Transparency.Add` — This will straight up add the pixel color to the color buffer! This usually looks -really- glowy, so it makes for good particles or lighting effects.
- `Transparency.Blend` — This will blend with the pixels behind it. This is transparent! You may not want to write to the z-buffer, and it's slower than opaque materials.
- `Transparency.MSAA` — Also known as Alpha To Coverage, this mode uses MSAA samples to create transparency. This works with a z-buffer and therefore functionally behaves more like an opaque material, but has a quantized number of "transparent values" it supports rather than a full range of 0-255 or 0-1. For 4x MSAA, this will give only 4 different transparent values, 8x MSAA only 8, etc. From a performance perspective, MSAA usually is only costly around triangle edges, but using this mode, MSAA is used for the whole triangle.
- `Transparency.None` — Not actually transparent! This is opaque! Solid! It's the default option, and it's the fastest option! Opaque objects write to the z-buffer, the occlude pixels behind them, and they can be used as input to important Mixed Reality features like Late Stage Reprojection that'll make your view more stable!

## static class U

A shorthand class with unit multipliers. Helps make code a little more terse on occasions!.

- `static float U.cm` — Converts centimeters to meters. There are 100cm in 1m. In StereoKit 1 unit is also 1 meter, so `25 * U.cm == 0.25`, 25 centimeters is .25 meters/units.
- `static float U.km` — Converts meters to kilometers. There are 1000m in 1km, so this just multiplies by 1000.
- `static float U.m` — StereoKit's default unit is meters, but sometimes it's nice to be explicit!
- `static float U.mm` — Converts millimeters to meters. There are 1000mm in 1m. In StereoKit 1 unit is 1 meter, so `250 * Units.mm2m == 0.25`, 250 millimeters is .25 meters/units.

## static class UI

This class is a collection of user interface and interaction methods! StereoKit uses an Immediate Mode GUI system, which can be very easy to work with and modify during runtime. You must call the UI method every frame you wish it to be available, and if you no longer want it to be present, you simply stop calling it! The id of the element is used to track its state from frame to frame, so for elements with state, you'll want to avoid changing the id during runtime! Ids are also scoped per-window, so different windows can re-use the same id, but a window cannot use the same id twice.

- `static Color UI.ColorScheme` — StereoKit will generate a color palette from this gamma space color, and use it to skin the UI! To explicitly adjust individual theme colors, see UI.SetThemeColor.
- `static bool UI.Enabled` — This returns the current state of the UI's enabled status stack, set by `UI.Push/PopEnabled`.
- `static bool UI.EnableFarInteract` — Enables or disables the far ray grab interaction for Handle elements like the Windows. It can be enabled and disabled for individual UI elements, and if this remains disabled at the start of the next frame, then the hand ray indicators will not be visible. This is enabled by default.
- `static BtnState UI.LastElementActive` — Tells the Active state of the most recently called UI element that used an id.
- `static BtnState UI.LastElementFocused` — Tells the Focused state of the most recently called UI element that used an id.
- `static Vec3 UI.LayoutAt` — The hierarchy local position of the current UI layout position. The top left point of the next UI element will be start here!
- `static Bounds UI.LayoutLast` — These are the layout bounds of the most recently reserved layout space. The Z axis dimensions are always 0. Only UI elements that affect the surface's layout will report their bounds here. You can reserve your own layout space via UI.LayoutReserve, and that call will also report here.
- `static Vec2 UI.LayoutRemaining` — How much space is available on the current layout! This is based on the current layout position, so X will give you the amount remaining on the current line, and Y will give you distance to the bottom of the layout, including the current line. These values will be 0 if you're using 0 for the layout size on that axis.
- `static float UI.LineHeight` — This is the height of a single line of text with padding in the UI's layout system!
- `static RenderLayer UI.RenderLayer` — This is the RenderLayer that the UI system draws on. It applies to the UI's mesh and model geometry, as well as the text and single sprites that StereoKit's UI manages. This is RenderLayer.UI by default.
- `static UISettings UI.Settings` — UI sizing and layout settings.
- `static bool UI.ShowVolumes` — Shows or hides the collision volumes of the UI! This is for debug purposes, and can help identify visible and invisible collision issues.
- `static UIMove UI.SystemMoveType` — This is the UIMove that is provided to UI windows that StereoKit itself manages, such as the fallback filepicker and soft keyboard.
- `static TextStyle UI.TextStyle` — This returns the TextStyle that's on top of the UI's stack, according to UI.Push/PopTextStyle.
- `static bool UI.Button(string text)` — A pressable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true only on the first frame it is pressed!
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.Button(string text, Vec2 size, Align textAlign)` — A pressable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true only on the first frame it is pressed!
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
  - Example: see `UI.Button` in StereoKit-docs-reference.md
- `static bool UI.ButtonAt(string text, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A variant of UI.Button that doesn't use the layout system, and instead goes exactly where you put it.
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
- `static void UI.ButtonBehavior(Vec3 windowRelativePos, Vec2 size, string id, Single& fingerOffset, BtnState& buttonState, BtnState& focusState)` — This is the core functionality of StereoKit's buttons, without any of the rendering parts! If you're trying to create your own pressable UI elements, or do more extreme customization of the look and feel of UI elements, then this function will provide a lot of complex pressing functionality for you!
  - `windowRelativePos` — The layout position of the pressable area.
  - `size` — The size of the pressable area.
  - `id` — The id for this pressable element to track its state with.
  - `fingerOffset` — This is the current distance of the finger, within the pressable volume, from the bottom of the button.
  - `buttonState` — This is the current frame's "active" state for the button.
  - `focusState` — This is the current frame's "focus" state for the button.
- `static void UI.ButtonBehavior(Vec3 windowRelativePos, Vec2 size, string id, Single& fingerOffset, BtnState& buttonState, BtnState& focusState, Interactor& interactor)` — This is the core functionality of StereoKit's buttons, without any of the rendering parts! If you're trying to create your own pressable UI elements, or do more extreme customization of the look and feel of UI elements, then this function will provide a lot of complex pressing functionality for you!
  - `windowRelativePos` — The layout position of the pressable area.
  - `size` — The size of the pressable area.
  - `id` — The id for this pressable element to track its state with.
  - `fingerOffset` — This is the current distance of the finger, within the pressable volume, from the bottom of the button.
  - `buttonState` — This is the current frame's "active" state for the button.
  - `focusState` — This is the current frame's "focus" state for the button.
  - `interactor` — The Interactor that interacted with the button. If nothing is interacting, this will be `Interactor.None`.
- `static void UI.ButtonBehavior(Vec3 windowRelativePos, Vec2 size, string id, float buttonDepth, float buttonActivationDepth, Single& fingerOffset, BtnState& buttonState, BtnState& focusState, Interactor& interactor)` — This is the core functionality of StereoKit's buttons, without any of the rendering parts! If you're trying to create your own pressable UI elements, or do more extreme customization of the look and feel of UI elements, then this function will provide a lot of complex pressing functionality for you! This overload allows for customizing the depth of the button, which otherwise would use UISettings.depth for its values.
  - `windowRelativePos` — The layout position of the pressable area.
  - `size` — The size of the pressable area.
  - `id` — The id for this pressable element to track its state with.
  - `buttonDepth` — This is the z axis depth of the pressable area.
  - `buttonActivationDepth` — This is the depth at which the button will activate. Normally this is 1/2 of buttonDepth.
  - `fingerOffset` — This is the current distance of the finger, within the pressable volume, from the bottom of the button.
  - `buttonState` — This is the current frame's "active" state for the button.
  - `focusState` — This is the current frame's "focus" state for the button.
  - `interactor` — The Interactor that interacted with the button. If nothing is interacting, this will be `Interactor.None`.
- `static void UI.ButtonBehavior(Vec3 windowRelativePos, Vec2 size, string id, float buttonDepth, float buttonActivationDepth, UIBtnFlag flags, Single& fingerOffset, BtnState& buttonState, BtnState& focusState, Interactor& interactor)` — This is the core functionality of StereoKit's buttons, without any of the rendering parts! If you're trying to create your own pressable UI elements, or do more extreme customization of the look and feel of UI elements, then this function will provide a lot of complex pressing functionality for you! This overload allows for customizing the depth of the button, which otherwise would use UISettings.depth for its values.
  - `windowRelativePos` — The layout position of the pressable area.
  - `size` — The size of the pressable area.
  - `id` — The id for this pressable element to track its state with.
  - `buttonDepth` — This is the z axis depth of the pressable area.
  - `buttonActivationDepth` — This is the depth at which the button will activate. Normally this is 1/2 of buttonDepth.
  - `fingerOffset` — This is the current distance of the finger, within the pressable volume, from the bottom of the button.
  - `buttonState` — This is the current frame's "active" state for the button.
  - `focusState` — This is the current frame's "focus" state for the button.
  - `interactor` — The Interactor that interacted with the button. If nothing is interacting, this will be `Interactor.None`.
  - `flags` — Flags for modifying the button's behavior, such as opting out of pull-away cancellation.
- `static bool UI.ButtonImg(string text, Sprite image, UIBtnLayout imageLayout)` — A pressable button accompanied by an image! The button will expand to fit the text provided to it, horizontally. Text is re-used as the id. Will return true only on the first frame it is pressed!
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - `image` — This is the image that will be drawn along with the text. See imageLayout for where the image gets drawn!
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.ButtonImg(string text, Sprite image, Color imageTint, UIBtnLayout imageLayout)` — A pressable button accompanied by an image! The button will expand to fit the text provided to it, horizontally. Text is re-used as the id. Will return true only on the first frame it is pressed! Image can be tinted by passing a custom color
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - `image` — This is the image that will be drawn along with the text. See imageLayout for where the image gets drawn!
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.ButtonImg(string text, Sprite image, UIBtnLayout imageLayout, Vec2 size, Align textAlign)` — A pressable button accompanied by an image! The button will expand to fit the text provided to it, horizontally. Text is re-used as the id. Will return true only on the first frame it is pressed!
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - `image` — This is the image that will be drawn along with the text. See imageLayout for where the image gets drawn!
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.ButtonImg(string text, Sprite image, Color imageTint, UIBtnLayout imageLayout, Vec2 size, Align textAlign)` — A pressable button accompanied by an image! The button will expand to fit the text provided to it, horizontally. Text is re-used as the id. Will return true only on the first frame it is pressed! Image can be tinted by passing a custom color
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - `image` — This is the image that will be drawn along with the text. See imageLayout for where the image gets drawn!
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.ButtonImgAt(string text, Sprite image, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A variant of UI.ButtonImg that doesn't use the layout system, and instead goes exactly where you put it.
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - `image` — This is the image that will be drawn along with the text. See imageLayout for where the image gets drawn!
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.ButtonImgAt(string text, Sprite image, Color imageTint, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A variant of UI.ButtonImg that doesn't use the layout system, and instead goes exactly where you put it.
  - `text` — Text to display on the button and id for tracking element state. MUST be unique within current hierarchy.
  - `image` — This is the image that will be drawn along with the text. See imageLayout for where the image gets drawn!
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.ButtonRound(string id, Sprite image, float diameter)` — A pressable round button! This button has a square layout, and only shows an image, no text. Will return true only on the first frame it is pressed!
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `image` — An image to display as the face of the button.
  - `diameter` — The diameter of the button's visual. This defaults to the line height.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.ButtonRoundAt(string id, Sprite image, Vec3 topLeftCorner, float diameter)` — A variant of UI.ButtonRound that doesn't use the layout system, and instead goes exactly where you put it.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `image` — An image to display as the face of the button.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `diameter` — The diameter of the button's visual.
  - returns — Will return true only on the first frame it is pressed!
- `static void UI.DrawElement(UIVisual elementVisual, Vec3 start, Vec3 size, float focus)` — This will draw a visual element from StereoKit's theming system, while paying attention to certain factors such as enabled/ disabled, tinting and more.
  - `elementVisual` — The element type to draw. This can be a value _past_ UIVisual.Max to use extra UIVisual slots for your own custom UI elements. If these slots are empty, SK will fall back to UIVisual.Default.
  - `start` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `focus` — The amount of visual focus this element currently has, where 0 is unfocused, and 1 is active. You can acquire a good focus value from `UI.GetAnimFocus`.
- `static void UI.DrawElement(UIVisual elementVisual, UIVisual elementColor, Vec3 start, Vec3 size, float focus)` — This will draw a visual element from StereoKit's theming system, while paying attention to certain factors such as enabled/ disabled, tinting and more.
  - `elementVisual` — The element type to draw. This can be a value _past_ UIVisual.Max to use extra UIVisual slots for your own custom UI elements. If these slots are empty, SK will fall back to UIVisual.Default.
  - `start` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `focus` — The amount of visual focus this element currently has, where 0 is unfocused, and 1 is active. You can acquire a good focus value from `UI.GetAnimFocus`.
  - `elementColor` — If you wish to use the coloring from a different element, you can use this to override the theme color used when drawing. This can be a value _past_ UIVisual.Max to use extra UIVisual slots for your own custom UI elements. If these slots are empty, SK will fall back to UIVisual.Default.
- `static Mesh UI.GenQuadrantMesh(UICorner roundedCorners, float cornerRadius, uint cornerResolution, bool deleteFlatSides, UILathePt[] lathePts)` — This generates a quadrantified mesh meant for UI buttons by sweeping a lathe over the rounded corners of a rectangle! Note that this mesh is quadrantified, so it requires special shaders to draw properly!
  - `roundedCorners` — A bit-flag indicating which corners should be rounded, and which should be sharp!
  - `cornerRadius` — The radius of each rounded corner.
  - `cornerResolution` — How many slices/verts go into each corner? More is smoother, but more expensive to render.
  - `deleteFlatSides` — If two adjacent corners are sharp, should we skip connecting them with triangles? If this edge will always be covered, then deleting these faces may save you some performance.
  - `lathePts` — The lathe points to sweep around the edge.
  - returns — The final Mesh, ready for use in SK's theming system.
- `static Mesh UI.GenQuadrantMesh(UICorner roundedCorners, float cornerRadius, uint cornerResolution, bool deleteFlatSides, bool quadrantify, UILathePt[] lathePts)` — This generates a quadrantified mesh meant for UI buttons by sweeping a lathe over the rounded corners of a rectangle! Note that this mesh is quadrantified, so it requires special shaders to draw properly!
  - `roundedCorners` — A bit-flag indicating which corners should be rounded, and which should be sharp!
  - `cornerRadius` — The radius of each rounded corner.
  - `cornerResolution` — How many slices/verts go into each corner? More is smoother, but more expensive to render.
  - `deleteFlatSides` — If two adjacent corners are sharp, should we skip connecting them with triangles? If this edge will always be covered, then deleting these faces may save you some performance.
  - `lathePts` — The lathe points to sweep around the edge.
  - `quadrantify` — Does this generate a mesh compatible with StereoKit's quadrant shader system, or is this just a traditional mesh? In most cases, this should be true, but UI elements such as the rounded button may be exceptions.
  - returns — The final Mesh, ready for use in SK's theming system.
- `static float UI.GetAnimFocus(IdHash id, BtnState focusState, BtnState activationState)` — This resolves a UI element with an ID and its current states into a nicely animated focus value.
  - `id` — The hierarchical id of the UI element we're checking the focus of, this can be created with `UI.StackHash`.
  - `focusState` — The current focus state of the UI element.
  - `activationState` — The current activation status of the UI element.
  - returns — A focus value in the realm of 0-1, where 0 is unfocused, and 1 is active.
- `static Color UI.GetElementColor(UIVisual elementVisual, float focus)` — This will get a final linear draw color for a particular UI element type with a particular focus value. This obeys the current hierarchy of tinting and enabled states.
  - `elementVisual` — Get the color from this element type. This can be a value _past_ UIVisual.Max to use extra UIVisual slots for your own custom UI elements. If these slots are empty, SK will fall back to UIVisual.Default.
  - `focus` — The amount of visual focus this element currently has, where 0 is unfocused, and 1 is active. You can acquire a good focus value from `UI.GetAnimFocus`
  - returns — A linear color good for tinting UI meshes.
- `static Color UI.GetThemeColor(UIColor colorCategory)` — This allows you to inspect the current normal color of the theme color category! If you set the color with UI.ColorScheme, this will be one of the generated colors, and not necessarily the color that was provided there.
  - `colorCategory` — The category of UI elements that are affected by this theme color. This can be a value _past_ UIColor.Max if you need extra UIColor slots for your own custom UI elements. If the theme slot is empty, the color will be pulled from UIColor.None.
  - returns — The gamma space color for the theme color category in its normal state.
- `static Color UI.GetThemeColor(UIColor colorCategory, UIColorState colorState)` — This allows you to inspect the current color of the theme color category in a specific state! If you set the color with UI.ColorScheme, or without specifying a state, this may be a generated color, and not necessarily the color that was provided there.
  - `colorCategory` — The category of UI elements that are affected by this theme color. This can be a value _past_ UIColor.Max if you need extra UIColor slots for your own custom UI elements. If the theme slot is empty, the color will be pulled from UIColor.None.
  - `colorState` — The state of the UI element this color applies to.
  - returns — The gamma space color for the theme color category in the indicated state.
- `static bool UI.GrabAuraEnabled()` — This retreives the top of the grab aura enablement stack, in case you need to know if the current window will have an aura.
  - returns — The enabled value at the top of the stack.
- `static bool UI.Handle(string id, Pose& pose, Bounds handle, bool drawHandle, UIMove moveType, UIGesture allowedGestures)` — This begins and ends a handle so you can just use  its grabbable/moveable functionality! Behaves much like a window, except with a more flexible handle, and no header. You can draw the handle, but it will have no text on it. Returns true for every frame the user is grabbing the handle.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `pose` — The pose state for the handle! The user will be able to grab this handle and move it around. The pose is relative to the current hierarchy stack.
  - `handle` — Size and location of the handle, relative to the pose.
  - `drawHandle` — Should this function draw the handle for you, or will you draw that yourself?
  - `moveType` — Describes how the handle will move when dragged around.
  - `allowedGestures` — Which hand gestures are used for interacting with this Handle?
  - returns — Returns true for every frame the user is grabbing the handle.
- `static bool UI.Handle(string id, Pose& pose, Bounds handle, Single& scale, bool drawHandle, UIMove moveType, UIGesture allowedGestures)` — This begins and ends a handle, like `UI.Handle`, but with support for multi-interactor uniform scaling. With two or more interactors grabbing the handle, their motion is combined into a translation, rotation, and a uniform scale. Interactors may freely join or leave the interaction without the handle jumping. Providing a scale here enables scaling; pass `UIMove.ExactNoscale` as the moveType if you want multi-interactor translate/rotate but no scaling.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `pose` — The pose state for the handle! The user will be able to grab this handle and move it around. The pose is relative to the current hierarchy stack.
  - `handle` — Size and location of the handle, relative to the pose. When a `scale` is provided, the handle multiplies these Bounds by it - so pass your unscaled base size, and the grab volume and drawn handle grow and shrink to match your scaled content.
  - `scale` — A uniform scale multiplier that gets accumulated as the user scales the handle with multiple interactors. Seed this with 1 (or your starting scale). Since the Pose has no scale of its own, apply this value to your content - the `handle` Bounds are scaled by it for you, so the grab volume and drawn handle stay matched.
  - `drawHandle` — Should this function draw the handle for you, or will you draw that yourself?
  - `moveType` — Describes how the handle will move when dragged around. Use `UIMove.ExactNoscale` to disable scaling.
  - `allowedGestures` — Which hand gestures are used for interacting with this Handle?
  - returns — Returns true for every frame the user is grabbing the handle.
- `static bool UI.HandleBegin(string id, Pose& pose, Bounds handle, bool drawHandle, UIMove moveType, UIGesture allowedGestures)` — This begins a new UI group with its own layout! Much like a window, except with a more flexible handle, and no header. You can draw the handle, but it will have no text on it. The pose value is always relative to the current hierarchy stack. This call will also push the pose transform onto the hierarchy stack, so any objects drawn up to the corresponding UI.HandleEnd() will get transformed by the handle pose. Returns true for every frame the user is grabbing the handle.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `pose` — The pose state for the handle! The user will be able to grab this handle and move it around. The pose is relative to the current hierarchy stack.
  - `handle` — Size and location of the handle, relative to the pose.
  - `drawHandle` — Should this function draw the handle visual for you, or will you draw that yourself?
  - `moveType` — Describes how the handle will move when dragged around.
  - `allowedGestures` — Which hand gestures are used for interacting with this Handle?
  - returns — Returns true for every frame the user is grabbing the handle.
- `static bool UI.HandleBegin(string id, Pose& pose, Bounds handle, Single& scale, bool drawHandle, UIMove moveType, UIGesture allowedGestures)` — This is a variant of `UI.HandleBegin` that additionally supports uniform scaling when two or more interactors grab the handle at the same time. With a single interactor the handle behaves exactly like the normal handle. With multiple interactors, their motion is combined into a translation, rotation, and a uniform scale. Interactors may freely join or leave the interaction without the handle jumping. Providing a scale here enables scaling; pass `UIMove.ExactNoscale` as the moveType if you want multi-interactor translate/rotate but no scaling.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `pose` — The pose state for the handle! The user will be able to grab this handle and move it around. The pose is relative to the current hierarchy stack.
  - `handle` — Size and location of the handle, relative to the pose. When a `scale` is provided, the handle multiplies these Bounds by it - so pass your unscaled base size, and the grab volume and drawn handle grow and shrink to match your scaled content.
  - `scale` — A uniform scale multiplier that gets accumulated as the user scales the handle with multiple interactors. Seed this with 1 (or your starting scale). Since the Pose has no scale of its own, apply this value to your content - the `handle` Bounds are scaled by it for you, so the grab volume and drawn handle stay matched.
  - `drawHandle` — Should this function draw the handle visual for you, or will you draw that yourself?
  - `moveType` — Describes how the handle will move when dragged around. Use `UIMove.ExactNoscale` to disable scaling.
  - `allowedGestures` — Which hand gestures are used for interacting with this Handle?
  - returns — Returns true for every frame the user is grabbing the handle.
  - Example: see `UI.HandleBegin` in StereoKit-docs-reference.md
- `static void UI.HandleEnd()` — Finishes a handle! Must be called after UI.HandleBegin() and all elements have been drawn. Pops the pose transform pushed by UI.HandleBegin() from the hierarchy stack.
  - Example: see `UI.HandleEnd` in StereoKit-docs-reference.md
- `static void UI.HProgressBar(float percent, float width, bool flipFillDirection)` — This is a simple horizontal progress indicator bar. This is used by the HSlider to draw the slider bar beneath the interactive element. Does not include any text or label.
  - `percent` — A value between 0 and 1 indicating progress from 0% to 100%.
  - `width` — Physical width of the slider on the window. 0 will fill the remaining amount of window space.
  - `flipFillDirection` — By default, this fills from left to right. This allows you to flip the fill direction to right to left.
- `static void UI.HSeparator()` — This draws a line horizontally across the current layout. Makes a good separator between sections of UI!
  - Example: see `UI.HSeparator` in StereoKit-docs-reference.md
- `static bool UI.HSlider(string id, Single& value, float min, float max, float step, float width, UIConfirm confirmMethod, UINotify notifyOn)` — A horizontal slider element! You can stick your finger in it, and slide the value up and down.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, left side of the slider.
  - `max` — The maximum value the slider can set, right side of the slider.
  - `step` — Locks the value to increments of step. Starts at min, and increments by step. 0 is valid, and means "don't lock to increments".
  - `width` — Physical width of the slider on the window. 0 will fill the remaining amount of window space.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `notifyOn` — Allows you to modify the behavior of the return value.
  - returns — Returns true any time the value changes.
- `static bool UI.HSlider(string id, Double& value, double min, double max, double step, float width, UIConfirm confirmMethod, UINotify notifyOn)` — A horizontal slider element! You can stick your finger in it, and slide the value up and down.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, left side of the slider.
  - `max` — The maximum value the slider can set, right side of the slider.
  - `step` — Locks the value to increments of step. Starts at min, and increments by step. 0 is valid, and means "don't lock to increments".
  - `width` — Physical width of the slider on the window. 0 will fill the remaining amount of window space.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `notifyOn` — Allows you to modify the behavior of the return value.
  - returns — Returns true any time the value changes.
  - Example: see `UI.HSlider` in StereoKit-docs-reference.md
- `static bool UI.HSliderAt(string id, Single& value, float min, float max, float step, Vec3 topLeftCorner, Vec2 size, UIConfirm confirmMethod, UINotify notifyOn)` — A variant of UI.HSlider that doesn't use the layout system, and instead goes exactly where you put it.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, left side of the slider.
  - `max` — The maximum value the slider can set, right side of the slider.
  - `step` — Locks the value to increments of step. Starts at min, and increments by step. 0 is valid, and means "don't lock to increments".
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `notifyOn` — Allows you to modify the behavior of the return value.
  - returns — Returns true any time the value changes.
- `static bool UI.HSliderAt(string id, Double& value, double min, double max, double step, Vec3 topLeftCorner, Vec2 size, UIConfirm confirmMethod, UINotify notifyOn)` — A variant of UI.HSlider that doesn't use the layout system, and instead goes exactly where you put it.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, left side of the slider.
  - `max` — The maximum value the slider can set, right side of the slider.
  - `step` — Locks the value to increments of step. Starts at min, and increments by step. 0 is valid, and means "don't lock to increments".
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `notifyOn` — Allows you to modify the behavior of the return value.
  - returns — Returns true any time the value changes.
- `static void UI.HSpace(float horizontalSpace)` — Adds some horizontal space to the current line!
  - `horizontalSpace` — Space in meters to shift the layout by.
- `static void UI.Image(Sprite image, Vec2 size)` — Adds an image to the UI!
  - `image` — A valid sprite.
  - `size` — Size in Hierarchy local meters. If one of the components is 0, it'll be automatically determined from the other component and the image's aspect ratio.
- `static bool UI.Input(string id, String& value, Vec2 size, TextContext type)` — This is an input field where users can input text to the app! Selecting it will spawn a virtual keyboard, or act as the keyboard focus. Hitting escape or enter, or focusing another UI element will remove focus from this Input.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The string that will store the Input's content in.
  - `size` — Size of the Input in Hierarchy local meters. Zero axes will auto-size.
  - `type` — What category of text this Input represents. This may affect what kind of soft keyboard will be displayed, if one is shown to the user.
  - returns — Returns true every time the contents of 'value' change.
  - Example: see `UI.Input` in StereoKit-docs-reference.md
- `static bool UI.InputAt(string id, String& value, Vec3 topLeftCorner, Vec2 size, TextContext type)` — This is an input field where users can input text to the app! Selecting it will spawn a virtual keyboard, or act as the keyboard focus. Hitting escape or enter, or focusing another UI element will remove focus from this Input.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The string that will store the Input's content in.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `type` — What category of text this Input represents. This may affect what kind of soft keyboard will be displayed, if one is shown to the user.
  - returns — Returns true every time the contents of 'value' change.
- `static bool UI.IsInteracting(Handed hand)` — Tells if the user is currently interacting with a UI element! This will be true if the hand has an active or focused UI element.
  - `hand` — Which hand is interacting?
  - returns — True if the hand has an active or focused UI element. False otherwise.
- `static void UI.Label(string text, bool usePadding)` — Adds some text to the layout! Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle. Can contain newlines!
  - `text` — Label text to display. Can contain newlines! Doesn't use text as id, so it can be non-unique.
  - `usePadding` — Should padding be included for positioning this text? Sometimes you just want un-padded text!
- `static void UI.Label(string text, Vec2 size, bool usePadding, Align textAlign)` — Adds some text to the layout, but this overload allows you can specify the size that you want it to use. Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle. Can contain newlines!
  - `text` — Label text to display. Can contain newlines! Doesn't use text as id, so it can be non-unique.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `usePadding` — Should padding be included for positioning this text? Sometimes you just want un-padded text!
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - Example: see `UI.Label` in StereoKit-docs-reference.md
- `static BtnState UI.LastElementHandActive(Handed hand)` — Tells if the hand was involved in the active state of the most recently called UI element using an id. Active state is frequently a single frame in the case of Buttons, but could be many in the case of Sliders or Handles.
  - `hand` — Which hand we're checking.
  - returns — A BtnState that indicated the hand was "just active" this frame, is currently "active" or if it "just became inactive" this frame.
- `static BtnState UI.LastElementHandFocused(Handed hand)` — Tells if the hand was involved in the focus state of the most recently called UI element using an id. Focus occurs when the hand is in or near an element, in such a way that indicates the user may be about to interact with it.
  - `hand` — Which hand we're checking.
  - returns — A BtnState that indicated the hand was "just focused" this frame, is currently "focused" or if it "just became focused" this frame.
- `static BtnState UI.LastElementSourceActive(InteractorSource source)` — Tells if an interactor from the given source was involved in the active state of the most recently called UI element using an id. Active state is frequently a single frame in the case of Buttons, but could be many in the case of Sliders or Handles. Sources can be combined as a bit-flag to ask about several at once.
  - `source` — The source, or combination of sources, to check.
  - returns — A BtnState that indicates the source was "just active" this frame, is currently "active", or if it "just became inactive" this frame.
  - Example: see `UI.LastElementSourceActive` in StereoKit-docs-reference.md
- `static BtnState UI.LastElementSourceFocused(InteractorSource source)` — Tells if an interactor from the given source was involved in the focus state of the most recently called UI element using an id. Focus occurs when the interactor is in or near an element, in such a way that indicates the user may be about to interact with it. Sources can be combined as a bit-flag to ask about several at once.
  - `source` — The source, or combination of sources, to check.
  - returns — A BtnState that indicates the source was "just focused" this frame, is currently "focused", or if it "just became unfocused" this frame.
  - Example: see `UI.LastElementSourceFocused` in StereoKit-docs-reference.md
- `static void UI.LayoutArea(Vec3 start, Vec2 dimensions, bool addMargin)` — Manually define what area is used for the UI layout. This is in the current Hierarchy's coordinate space on the X/Y plane.
  - `start` — The top left of the layout area, relative to the current Hierarchy in local meters.
  - `dimensions` — The size of the layout area from the top left, in local meters.
- `static void UI.LayoutPop()` — This removes a layout from the layout stack that was previously added using LayoutPush, or LayoutPushCut.
- `static void UI.LayoutPush(Vec3 start, Vec2 dimensions, bool addMargin)` — This pushes a layout rect onto the layout stack. All UI elements using the layout system will now exist inside this layout area! Note that some UI elements such as Windows will already be managing a layout of their own on the stack.
  - `start` — The top left position of the layout. Note that Windows have their origin at the top center, the left side of a window is X+, and content advances to the X- direction.
  - `dimensions` — The total size of the layout area. A value of zero means the layout will expand in that axis, but may prevent certain types of layout "Cuts".
  - `addMargin` — Adds a spacing margin to the interior of the layout. Most of the time you won't need this, but may be useful when working without a Window.
- `static void UI.LayoutPushCut(UICut cutTo, float sizeMeters, bool addMargin)` — This cuts off a portion of the current layout area, and pushes that new area onto the layout stack. Left and Top cuts will always work, but Right and Bottom cuts can only exist inside of a parent layout with an explicit size, auto-resizing prevents these cuts. All UI elements using the layout system will now exist inside this layout area! Note that some UI elements such as Windows will already be managing a layout of their own on the stack.
  - `cutTo` — Which side of the current layout should the cut happen to? Note that Right and Bottom will require explicit sizes in the parent layout, not auto-sizes.
  - `sizeMeters` — The size of the layout cut, in meters.
  - `addMargin` — Adds a spacing margin to the interior of the layout. Most of the time you won't need this, but may be useful when working without a Window.
- `static Bounds UI.LayoutReserve(Vec2 size, bool addPadding, float depth)` — Reserves a box of space for an item in the current UI layout! If either size axis is zero, it will be auto-sized to fill the current surface horizontally, and fill a single LineHeight vertically. Returns the Hierarchy local bounds of the space that was reserved, with a Z axis dimension of 0.
  - `size` — Size of the layout box in Hierarchy local meters.
  - `addPadding` — If true, this will add the current padding value to the total final dimensions of the space that is reserved.
  - `depth` — This allows you to quickly insert a depth into the Bounds you're receiving. This will offset on the Z axis in addition to increasing the dimensions, so that the bounds still remain sitting on the surface of the UI. This depth value will not be reflected in the bounds provided by LayouLast.
  - returns — Returns the Hierarchy local bounds of the space that was reserved, with a Z axis dimension of 0.
- `static Bounds UI.LayoutReserve(float width, float height, bool addPadding, float depth)` — Reserves a box of space for an item in the current UI layout! If either size axis is zero, it will be auto-sized to fill the current surface horizontally, and fill a single LineHeight vertically. Returns the Hierarchy local bounds of the space that was reserved, with a Z axis dimension of 0.
  - `width` — Width of the layout box in Hierarchy local meters.
  - `height` — Height of the layout box in Hierarchy local meters.
  - `addPadding` — If true, this will add the current padding value to the total final dimensions of the space that is reserved.
  - `depth` — This allows you to quickly insert a depth into the Bounds you're receiving. This will offset on the Z axis in addition to increasing the dimensions, so that the bounds still remain sitting on the surface of the UI. This depth value will not be reflected in the bounds provided by LayouLast.
  - returns — Returns the Hierarchy local bounds of the space that was reserved, with a Z axis dimension of 0.
- `static void UI.Model(Model model)` — This adds a non-interactive Model to the UI panel layout.
  - `model` — The Model to use.
- `static void UI.Model(Model model, Vec2 uiSize, float modelScale)` — This adds a non-interactive Model to the UI panel layout, and allows you to specify its size.
  - `model` — The Model to use.
  - `uiSize` — The size this element should take from the layout.
  - `modelScale` — 0 will auto-scale the model to fit the layout space, but you can specify a different scale in case you'd like a different size.
- `static void UI.NextLine()` — This will advance the layout to the next line. If there's nothing on the current line, it'll advance to the start of the next on. But this won't have any affect on an empty line, try UI.Space for that.
- `static void UI.PanelAt(Vec3 start, Vec2 size, UIPad padding)` — If you wish to manually draw a Panel, this function will let you draw one wherever you want!
  - `start` — The top left corner of the Panel element.
  - `size` — The size of the Panel element, in hierarchy local meters.
  - `padding` — Only UIPad.Outsize has any effect here. UIPad.Inside will behave the same as UIPad.None.
- `static void UI.PanelBegin(UIPad padding)` — This will begin a Panel element that will encompass all elements drawn between PanelBegin and PanelEnd. This is an entirely visual element, and is great for visually grouping elements together. Every Begin must have a matching End.
  - `padding` — Describes how padding is applied to the visual element of the Panel.
- `static void UI.PanelEnd()` — This will finalize and draw a Panel element.
- `static void UI.PlaySoundOff(UIVisual elementVisual, Vec3 atLocal)` — This will play the 'off' sound associated with the given UIVisual at the world position.
  - `elementVisual` — The UIVisual to pull sound information from.
  - `atLocal` — The hierarchy local location where the sound will play.
- `static void UI.PlaySoundOn(UIVisual elementVisual, Vec3 atLocal)` — This will play the 'on' sound associated with the given UIVisual at the world position.
  - `elementVisual` — The UIVisual to pull sound information from.
  - `atLocal` — The hierarchy local location where the sound will play.
- `static void UI.PlaySoundOnOff(UIVisual elementVisual, IdHash elementId, Vec3 atLocal)` — This will play the 'on' sound associated with the given UIVisual at the local position. It will also play the 'off' sound when the given element becomes inactive, at the world location of the initial local position!
  - `elementVisual` — The UIVisual to pull sound information from.
  - `elementId` — The id of the element that will be tracked for playing the 'off' sound.
  - `atLocal` — The hierarchy local location where the sound will play.
- `static void UI.PopEnabled()` — Removes an 'enabled' state from the stack, and whatever was below will then be used as the primary enabled state.
  - Example: see `UI.PopEnabled` in StereoKit-docs-reference.md
- `static void UI.PopGrabAura()` — This removes an enabled status for grab auras from the stack, returning it to the state before the previous PushGrabAura call. Grab auras are an extra space and visual element that goes around Window elements to make them easier to grab.
- `static void UI.PopId()` — Removes the last root id from the stack, and moves up to the one before it!
- `static void UI.PopPreserveKeyboard()` — This pops the keyboard presentation state to what it was previously.
- `static void UI.PopSurface()` — This will return to the previous UI layout on the stack. This must be called after a PushSurface call.
- `static void UI.PopTextStyle()` — Removes a TextStyle from the stack, and whatever was below will then be used as the GUI's primary font.
- `static void UI.PopTint()` — Removes a Tint from the stack, and whatever was below will then be used as the primary tint.
- `static Pose UI.PopupPose(Vec3 shift)` — This creates a Pose that is friendly towards UI popup windows, or windows that are created due to some type of user interaction. The fallback file picker and soft keyboard both use this function to position themselves!
  - `shift` — A positional shift from the default location, this is useful to account for the height of the window, and center or offset this pose. A value of [0,-0.1,0] may be a good starting point.
  - returns — A pose between the UI or hand that is currently active, and the user's head. Good for popup windows.
- `static void UI.ProgressBar(float percent, float width)` — This is a simple horizontal progress indicator bar. This is used by the HSlider to draw the slider bar beneath the interactive element. Does not include any text or label.
  - `percent` — A value between 0 and 1 indicating progress from 0% to 100%.
  - `width` — Physical width of the slider on the window. 0 will fill the remaining amount of window space.
- `static void UI.ProgressBarAt(float percent, Vec3 topLeftCorner, Vec2 size, UIDir barDirection, bool flipFillDirection)` — This is a simple horizontal progress indicator bar. This is used by the HSlider to draw the slider bar beneath the interactive element. Does not include any text or label.
  - `percent` — A value between 0 and 1 indicating progress from 0% to 100%.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
- `static void UI.PushEnabled(bool enabled, bool ignoreParent)` — All UI between PushEnabled and its matching PopEnabled will set the UI to an enabled or disabled state, allowing or preventing interaction with specific elements. The default state is true.
  - `enabled` — Should the following elements be enabled and interactable?
  - `ignoreParent` — Do we want to ignore or inherit the state of the current stack?
- `static void UI.PushEnabled(bool enabled, HierarchyParent parentBehavior)` — All UI between PushEnabled and its matching PopEnabled will set the UI to an enabled or disabled state, allowing or preventing interaction with specific elements. The default state is true.
  - `enabled` — Should the following elements be enabled and interactable?
  - `parentBehavior` — Do we want to ignore or inherit the state of the current stack?
  - Example: see `UI.PushEnabled` in StereoKit-docs-reference.md
- `static void UI.PushGrabAura(bool enabled)` — This pushes an enabled status for grab auras onto the stack. Grab auras are an extra space and visual element that goes around Window elements to make them easier to grab. MUST be matched by a PopGrabAura call.
  - `enabled` — Is the grab aura enabled or not?
- `static void UI.PushId(string rootId)` — Adds a root id to the stack for the following UI elements! This id is combined when hashing any following ids, to prevent id collisions in separate groups.
  - `rootId` — The root id to use until the following PopId call. MUST be unique within current hierarchy.
- `static void UI.PushId(int rootId)` — Adds a root id to the stack for the following UI elements! This id is combined when hashing any following ids, to prevent id collisions in separate groups.
  - `rootId` — The root id to use until the following PopId call. MUST be unique within current hierarchy.
- `static void UI.PushPreserveKeyboard(bool preserveKeyboard)` — When a soft keyboard is visible, interacting with UI elements will cause the keyboard to close. This function allows you to change this behavior for certain UI elements, allowing the user to interact and still preserve the keyboard's presence. Remember to Pop when you're finished!
  - `preserveKeyboard` — If true, interacting with elements will NOT hide the keyboard. If false, interaction will hide the keyboard.
- `static void UI.PushSurface(Pose surfacePose, Vec3 layoutStart, Vec2 layoutDimensions)` — This will push a surface into SK's UI layout system. The surface becomes part of the transform hierarchy, and SK creates a layout surface for UI content to be placed on and interacted with. Must be accompanied by a PopSurface call.
  - `surfacePose` — The Pose of the UI surface, where the surface forward direction is the same as the Pose's.
  - `layoutStart` — This is an offset from the center of the coordinate space created by the surfacePose. Vec3.Zero would mean that content starts at the center of the surfacePose.
  - `layoutDimensions` — The size of the surface area to use during layout. Like other UI layout sizes, an axis set to zero means it will auto-expand in that direction.
- `static void UI.PushTextStyle(TextStyle style)` — This pushes a Text Style onto the style stack! All text elements rendered by the GUI system will now use this styling.
  - `style` — A valid TextStyle to use.
- `static void UI.PushTint(Color colorGamma)` — All UI between PushTint and its matching PopTint will be tinted with this color. This is implemented by multiplying this color with the current color of the UI element. The default is a White (1,1,1,1) identity tint.
  - `colorGamma` — A normal (gamma corrected) color value. This is internally converted to linear, so tint multiplication happens on linear color values.
- `static void UI.QuadrantSizeMesh(Mesh& mesh, float overflowPercent)` — This will reposition the Mesh's vertices to work well with quadrant resizing shaders. The mesh should generally be centered around the origin, and face down the -Z axis. This will also overwrite any UV coordinates in the verts. You can read more about the technique [here](https://playdeck.net/blog/quadrant-sizing-efficient-ui-rendering).
  - `mesh` — The vertices of this Mesh will be retrieved, modified, and overwritten.
  - `overflowPercent` — When scaled, should the geometry stick out past the "box" represented by the scale, or edge up against it? A value of 0 will mean the geometry will fit entirely inside the "box", and a value of 1 means the geometry will start at the boundary of the box and continue outside it.
- `static void UI.QuadrantSizeVerts(Vertex[] verts, float overflowPercent)` — This will reposition the vertices to work well with quadrant resizing shaders. The mesh should generally be centered around the origin, and face down the -Z axis. This will also overwrite any UV coordinates in the verts. You can read more about the technique [here](https://playdeck.net/blog/quadrant-sizing-efficient-ui-rendering).
  - `verts` — A list of vertices to be modified to fit the sizing shader.
  - `overflowPercent` — When scaled, should the geometry stick out past the "box" represented by the scale, or edge up against it? A value of 0 will mean the geometry will fit entirely inside the "box", and a value of 1 means the geometry will start at the boundary of the box and continue outside it.
- `static bool UI.Radio(string text, bool active)` — A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true.
  - `text` — Text to display on the Radio and id for tracking element state. MUST be unique within current hierarchy.
  - `active` — Does this button look like it's pressed?
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.Radio(string text, bool active, Vec2 size, Align textAlign)` — A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true.
  - `text` — Text to display on the Radio and id for tracking element state. MUST be unique within current hierarchy.
  - `active` — Does this button look like it's pressed?
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.Radio(string text, bool active, Sprite imageOff, Sprite imageOn, UIBtnLayout imageLayout)` — A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true. This version allows you to override the images used by the Radio.
  - `text` — Text to display on the Radio and id for tracking element state. MUST be unique within current hierarchy.
  - `active` — Does this button look like it's pressed?
  - `imageOff` — Image to use when the radio value is false.
  - `imageOn` — Image to use when the radio value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the radio. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.Radio(string text, bool active, Sprite imageOff, Sprite imageOn, Color imageTint, UIBtnLayout imageLayout)` — A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true. This version allows you to override the images used by the Radio.
  - `text` — Text to display on the Radio and id for tracking element state. MUST be unique within current hierarchy.
  - `active` — Does this button look like it's pressed?
  - `imageOff` — Image to use when the radio value is false.
  - `imageOn` — Image to use when the radio value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the radio. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.Radio(string text, bool active, Sprite imageOff, Sprite imageOn, UIBtnLayout imageLayout, Vec2 size, Align textAlign)` — A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true. This version allows you to override the images used by the Radio.
  - `text` — Text to display on the Radio and id for tracking element state. MUST be unique within current hierarchy.
  - `active` — Does this button look like it's pressed?
  - `imageOff` — Image to use when the radio value is false.
  - `imageOn` — Image to use when the radio value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the radio. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.Radio(string text, bool active, Sprite imageOff, Sprite imageOn, Color imageTint, UIBtnLayout imageLayout, Vec2 size, Align textAlign)` — A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true. This version allows you to override the images used by the Radio.
  - `text` — Text to display on the Radio and id for tracking element state. MUST be unique within current hierarchy.
  - `active` — Does this button look like it's pressed?
  - `imageOff` — Image to use when the radio value is false.
  - `imageOn` — Image to use when the radio value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the radio. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true only on the first frame it is pressed!
  - Example: see `UI.Radio` in StereoKit-docs-reference.md
- `static bool UI.RadioAt(string text, bool active, Sprite imageOff, Sprite imageOn, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true. This version allows you to override the images used by the Radio.
  - `text` — Text to display on the Radio and id for tracking element state. MUST be unique within current hierarchy.
  - `active` — Does this button look like it's pressed?
  - `imageOff` — Image to use when the radio value is false.
  - `imageOn` — Image to use when the radio value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the radio. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true only on the first frame it is pressed!
- `static bool UI.RadioAt(string text, bool active, Sprite imageOff, Sprite imageOn, Color imageTint, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A Radio is similar to a button, except you can specify if it looks pressed or not regardless of interaction. This can be useful for radio-like behavior! Check an enum for a value, and use that as the 'active' state, Then switch to that enum value if Radio returns true. This version allows you to override the images used by the Radio.
  - `text` — Text to display on the Radio and id for tracking element state. MUST be unique within current hierarchy.
  - `active` — Does this button look like it's pressed?
  - `imageOff` — Image to use when the radio value is false.
  - `imageOn` — Image to use when the radio value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the radio. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true only on the first frame it is pressed!
- `static void UI.SameLine()` — Moves the current layout position back to the end of the line that just finished, so it can continue on the same line as the last element!
  - Example: see `UI.SameLine` in StereoKit-docs-reference.md
- `static void UI.SetElementColor(UIVisual visual, UIColor colorCategory)` — This allows you to override the color category that a UI element is assigned to.
  - `visual` — The UI element type to set the color category of. This can be a value _past_ UIVisual.Max if you need extra UIVisual slots for your own custom UI elements.
  - `colorCategory` — The category of color to assign to this UI element. Use UI.SetThemeColor in combination with this to assign a specific color. This can be a value _past_ UIColor.Max if you need extra UIColor slots for your own custom UI elements.
- `static void UI.SetElementSound(UIVisual visual, Sound activate, Sound deactivate)` — This sets the sound that a particulat UI element will make when you interact with it. One sound when the interaction starts, and one when it ends.
  - `visual` — The UI element to apply the sounds to. This can be a value _past_ UIVisual.Max if you need extra UIVisual slots for your own custom UI elements.
  - `activate` — The sound made when the interaction begins. A null sound will fall back to the default sound.
  - `deactivate` — The sound made when the interaction ends. A null sound will fall back to the default sound.
- `static void UI.SetElementVisual(UIVisual visual, Mesh mesh, Material material, Vec2 minSize)` — Override the visual assets attached to a particular UI element. Note that StereoKit's default UI assets use a type of quadrant sizing that is implemented in the Material _and_ the Mesh. You don't need to use quadrant sizing for your own visuals, but if you wish to know more, you can read more about the technique [here](https://playdeck.net/blog/quadrant-sizing-efficient-ui-rendering). You may also find UI.QuadrantSizeVerts and UI.QuadrantSizeMesh to be helpful.
  - `visual` — Which UI visual element to override. This can be a value _past_ UIVisual.Max if you need extra UIVisual slots for your own custom UI elements.
  - `mesh` — The Mesh to use for the UI element's visual component. The Mesh will be scaled to match the dimensions of the UI element.
  - `material` — The Material to use when rendering the UI element. The default Material is specifically designed to work with quadrant sizing formatted meshes.
  - `minSize` — For some meshes, such as quadrant sized meshes, there's a minimum size where the mesh turns inside out. This lets UI elements to accommodate for this minimum size, and behave somewhat more appropriately.
- `static void UI.SetThemeColor(UIColor colorCategory, Color colorGamma)` — This allows you to explicitly set a theme color, for finer grained control over the UI appearance. Each theme type is still used by many different UI elements. This will automatically generate colors for different UI element states.
  - `colorCategory` — The category of UI elements that will be affected by this theme color. This can be a value _past_ UIColor.Max if you need extra UIColor slots for your own custom UI elements.
  - `colorGamma` — The gamma corrected color that should be applied to this theme color category in its normal resting state. Active and disabled colors will be generated based on this color.
- `static void UI.SetThemeColor(UIColor colorCategory, UIColorState colorState, Color colorGamma)` — This allows you to explicitly set a theme color, for finer grained control over the UI appearance. Each theme type is still used by many different UI elements. This applies specifically to one state of this color category, and does not modify the others.
  - `colorCategory` — The category of UI elements that will be affected by this theme color. This can be a value _past_ UIColor.Max if you need extra UIColor slots for your own custom UI elements.
  - `colorState` — The state of the UI element this color should apply to.
  - `colorGamma` — The gamma corrected color that should be applied to this theme color category in the indicated state.
- `static void UI.SliderBehavior(Vec3 windowRelativePos, Vec2 size, IdHash id, Vec2& value, Vec2 min, Vec2 max, Vec2 buttonSizeVisual, Vec2 buttonSizeInteract, UIConfirm confirmMethod, UISliderData& data)` — This is the core functionality of StereoKit's slider elements, without any of the rendering parts! If you're trying to create your own sliding UI elements, or do more extreme customization of the look and feel of slider UI elements, then this function will provide a lot of complex pressing functionality for you!
  - `windowRelativePos` — The layout position of the pressable area.
  - `size` — The size of the pressable area.
  - `id` — The id for this pressable element to track its state with.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, left side of the slider.
  - `max` — The maximum value the slider can set, right side of the slider.
  - `buttonSizeVisual` — This is the visual size of the element representing the touchable area of the slider. This is used to calculate the center of the button's placement without going outside the provided bounds.
  - `buttonSizeInteract` — The size of the interactive touch element of the slider. Set this to zero to use the entire area as a touchable surface.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `data` — This is data about the slider interaction, you can use this for visualizing the slider behavior, or reacting to its events.
- `static IdHash UI.StackHash(string id)` — This will hash the given text based id into a hash for use with certain StereoKit UI functions. This includes the hash of the current id stack.
  - `id` — Text to hash along with the current id stack.
  - returns — An integer based hash id for use with SK UI.
- `static void UI.Text(string text, Align textAlign)` — Displays a large chunk of text on the current layout. This can include new lines and spaces, and will properly wrap once it fills the entire layout! Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle.
  - `text` — The text you wish to display, there's no additional parsing done to this text, so put it in as you want to see it!
  - `textAlign` — Where should the text position itself within its bounds? Align.TopLeft is how most English text is aligned.
- `static void UI.Text(string text, Align textAlign, TextFit fit, Vec2 size)` — Displays a large chunk of text on the current layout. This can include new lines and spaces, and will properly wrap once it fills the entire layout! Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle.
  - `text` — The text you wish to display, there's no additional parsing done to this text, so put it in as you want to see it!
  - `textAlign` — Where should the text position itself within its bounds? Align.TopLeft is how most English text is aligned.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter. `UI.Text` uses `TextFit.Wrap` by default.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
- `static bool UI.Text(string text, Vec2& scroll, UIScroll scrollDirection, Vec2 size, Align textAlign, TextFit fit)` — A scrolling text element! This is for reading large chunks of text that may be too long to fit in the available space. It requires a size, as well as a place to store the current scroll value. Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle.
  - `text` — The text you wish to display, there's no additional parsing done to this text, so put it in as you want to see it!
  - `scroll` — This is the current scroll value of the text, in meters, _not_ percent.
  - `scrollDirection` — What scroll bars are allowed to show on this text? Vertical, horizontal, both?
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where should the text position itself within its bounds? Align.TopLeft is how most English text is aligned.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter. `UI.Text` uses `TextFit.Wrap` by default, and this scrolling overload will always add `TextFit.Clip` internally.
  - returns — Returns true if any of the scroll bars have changed this frame.
- `static bool UI.Text(string text, Vec2& scroll, UIScroll scrollDirection, float height, Align textAlign, TextFit fit)` — A scrolling text element! This is for reading large chunks of text that may be too long to fit in the available space. It requires a height, as well as a place to store the current scroll value. Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle.
  - `text` — The text you wish to display, there's no additional parsing done to this text, so put it in as you want to see it!
  - `scroll` — This is the current scroll value of the text, in meters, _not_ percent.
  - `scrollDirection` — What scroll bars are allowed to show on this text? Vertical, horizontal, both?
  - `height` — The vertical height of this Text element, width will automatically take the remainder of the current layout width.
  - `textAlign` — Where should the text position itself within its bounds? Align.TopLeft is how most English text is aligned.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter. `UI.Text` uses `TextFit.Wrap` by default, and this scrolling overload will always add `TextFit.Clip` internally.
  - returns — Returns true if any of the scroll bars have changed this frame.
  - Example: see `UI.Text` in StereoKit-docs-reference.md
- `static void UI.TextAt(string text, Align textAlign, TextFit fit, Vec3 topLeftCorner, Vec2 size)` — Displays a large chunk of text on the current layout. This can include new lines and spaces, and will properly wrap once it fills the entire layout! Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle.
  - `text` — The text you wish to display, there's no additional parsing done to this text, so put it in as you want to see it!
  - `textAlign` — Where should the text position itself within its bounds? Align.TopLeft is how most English text is aligned.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter. `UI.Text` uses `TextFit.Wrap` by default.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
- `static bool UI.TextAt(string text, Vec2& scroll, UIScroll scrollDirection, Align textAlign, TextFit fit, Vec3 topLeftCorner, Vec2 size)` — A scrolling text element! This is for reading large chunks of text that may be too long to fit in the available space. It requires a size, as well as a place to store the current scroll value. Text uses the UI's current font settings, which can be changed with UI.Push/PopTextStyle.
  - `text` — The text you wish to display, there's no additional parsing done to this text, so put it in as you want to see it!
  - `scroll` — This is the current scroll value of the text, in meters, _not_ percent.
  - `scrollDirection` — What scroll bars are allowed to show on this text? Vertical, horizontal, both?
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where should the text position itself within its bounds? Align.TopLeft is how most English text is aligned.
  - `fit` — Describe how the text should behave when one of its size dimensions conflicts with the provided 'size' parameter. `UI.Text` uses `TextFit.Wrap` by default, and this scrolling overload will always add `TextFit.Clip` internally.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - returns — Returns true if any of the scroll bars have changed this frame.
- `static bool UI.Toggle(string text, Boolean& value)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Sprite image, UIBtnLayout imageLayout)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `image` — Image to use for the button, this will be used regardless of the toggle value.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Sprite image, Color imageTint, UIBtnLayout imageLayout)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `image` — Image to use for the button, this will be used regardless of the toggle value.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Sprite toggleOff, Sprite toggleOn, UIBtnLayout imageLayout)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `toggleOff` — Image to use when the toggle value is false.
  - `toggleOn` — Image to use when the toggle value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Sprite toggleOff, Sprite toggleOn, Color imageTint, UIBtnLayout imageLayout)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `toggleOff` — Image to use when the toggle value is false.
  - `toggleOn` — Image to use when the toggle value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Sprite image, UIBtnLayout imageLayout, Vec2 size, Align textAlign)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `image` — Image to use for the button, this will be used regardless of the toggle value.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Sprite image, Color imageTint, UIBtnLayout imageLayout, Vec2 size, Align textAlign)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `image` — Image to use for the button, this will be used regardless of the toggle value.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Sprite toggleOff, Sprite toggleOn, UIBtnLayout imageLayout, Vec2 size, Align textAlign)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `toggleOff` — Image to use when the toggle value is false.
  - `toggleOn` — Image to use when the toggle value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Sprite toggleOff, Sprite toggleOn, Color imageTint, UIBtnLayout imageLayout, Vec2 size, Align textAlign)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `toggleOff` — Image to use when the toggle value is false.
  - `toggleOn` — Image to use when the toggle value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.Toggle(string text, Boolean& value, Vec2 size, Align textAlign)` — A toggleable button! A button will expand to fit the text provided to it, vertically and horizontally. Text is re-used as the id. Will return true any time the toggle value changes, NOT the toggle value itself!
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `size` — The layout size for this element in Hierarchy space. If an axis is left as zero, it will be auto-calculated. For X this is the remaining width of the current layout, and for Y this is UI.LineHeight.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
  - Example: see `UI.Toggle` in StereoKit-docs-reference.md
- `static bool UI.ToggleAt(string text, Boolean& value, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A variant of UI.Toggle that doesn't use the layout system, and instead goes exactly where you put it.
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.ToggleAt(string text, Boolean& value, Sprite image, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A variant of UI.Toggle that doesn't use the layout system, and instead goes exactly where you put it.
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `image` — Image to use for the button, this will be used regardless of the toggle value.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.ToggleAt(string text, Boolean& value, Sprite image, Color imageTint, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A variant of UI.Toggle that doesn't use the layout system, and instead goes exactly where you put it.
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `image` — Image to use for the button, this will be used regardless of the toggle value.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.ToggleAt(string text, Boolean& value, Sprite toggleOff, Sprite toggleOn, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A variant of UI.Toggle that doesn't use the layout system, and instead goes exactly where you put it.
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `toggleOff` — Image to use when the toggle value is false.
  - `toggleOn` — Image to use when the toggle value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static bool UI.ToggleAt(string text, Boolean& value, Sprite toggleOff, Sprite toggleOn, Color imageTint, UIBtnLayout imageLayout, Vec3 topLeftCorner, Vec2 size, Align textAlign)` — A variant of UI.Toggle that doesn't use the layout system, and instead goes exactly where you put it.
  - `text` — Text to display on the Toggle and id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The current state of the toggle button! True means it's toggled on, and false means it's toggled off.
  - `toggleOff` — Image to use when the toggle value is false.
  - `toggleOn` — Image to use when the toggle value is true.
  - `imageLayout` — This enum specifies how the text and image should be laid out on the button. For example, `UIBtnLayout.Left` will have the image on the left, and text on the right.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `textAlign` — Where the text aligns within its allotted box. `Align.None` falls back to the element's natural alignment, which is generally what you want.
  - `imageTint` — The Sprite's color will be multiplied by this tint. The default is White(1,1,1,1).
  - returns — Will return true any time the toggle value changes, NOT the toggle value itself!
- `static BtnState UI.VolumeAt(string id, Bounds bounds, UIConfirm interactType, Interactor& interactor, BtnState& focusState)` — A volume for helping to build interactions. This checks for the presence of an interactor inside the bounds, and if found, returns that interactor along with activation and focus information defined by the interactType.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `bounds` — Size and position of the volume, relative to the current Hierarchy.
  - `interactType` — UIConfirm.Pinch will activate when the interactor performs a 'pinch' gesture inside the volume. UIConfirm.Push will activate when the interactor enters the volume, and behave the same as the element's focusState.
  - `interactor` — The `Interactor` that is interacting with the volume. If nothing is interacting, this will be `Interactor.None`.
  - `focusState` — The focus state tells if the element has an interactor inside of the volume that qualifies for focus.
  - returns — Based on the interactType, this is a BtnState that tells the activation state of the interaction.
- `static BtnState UI.VolumeAt(string id, Bounds bounds, UIConfirm interactType, Interactor& interactor)` — A volume for helping to build interactions. This checks for the presence of an interactor inside the bounds, and if found, returns that interactor along with activation and focus information defined by the interactType.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `bounds` — Size and position of the volume, relative to the current Hierarchy.
  - `interactType` — UIConfirm.Pinch will activate when the interactor performs a 'pinch' gesture inside the volume. UIConfirm.Push will activate when the interactor enters the volume, and behave the same as the element's focusState.
  - `interactor` — The `Interactor` that is interacting with the volume. If nothing is interacting, this will be `Interactor.None`.
  - returns — Based on the interactType, this is a BtnState that tells the activation state of the interaction.
- `static BtnState UI.VolumeAt(string id, Bounds bounds, UIConfirm interactType)` — A volume for helping to build interactions. This checks for the presence of an interactor inside the bounds, and if found, returns that interactor along with activation and focus information defined by the interactType.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `bounds` — Size and position of the volume, relative to the current Hierarchy.
  - `interactType` — UIConfirm.Pinch will activate when the interactor performs a 'pinch' gesture inside the volume. UIConfirm.Push will activate when the interactor enters the volume, and behave the same as the element's focusState.
  - returns — Based on the interactType, this is a BtnState that tells the activation state of the interaction.
  - Example: see `UI.VolumeAt` in StereoKit-docs-reference.md
- `static void UI.VProgressBar(float percent, float height, bool flipFillDirection)` — This is a simple vertical progress indicator bar. This is used by the VSlider to draw the slider bar beneath the interactive element. Does not include any text or label.
  - `percent` — A value between 0 and 1 indicating progress from 0% to 100%.
  - `height` — Physical height of the slider on the window. 0 will fill the remaining amount of window space.
  - `flipFillDirection` — By default, this fills from top to bottom. This allows you to flip the fill direction to bottom to top.
- `static bool UI.VSlider(string id, Single& value, float min, float max, float step, float height, UIConfirm confirmMethod, UINotify notifyOn)` — A vertical slider element! You can stick your finger in it, and slide the value up and down.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, top side of the slider.
  - `max` — The maximum value the slider can set, bottom side of the slider.
  - `step` — Locks the value to increments of step. Starts at min, and increments by step. 0 is valid, and means "don't lock to increments".
  - `height` — Physical width of the slider on the window. 0 will fill the remaining amount of window space.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `notifyOn` — Allows you to modify the behavior of the return value.
  - returns — Returns true any time the value changes.
- `static bool UI.VSlider(string id, Double& value, double min, double max, double step, float height, UIConfirm confirmMethod, UINotify notifyOn)` — A vertical slider element! You can stick your finger in it, and slide the value up and down.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, top side of the slider.
  - `max` — The maximum value the slider can set, bottom side of the slider.
  - `step` — Locks the value to increments of step. Starts at min, and increments by step. 0 is valid, and means "don't lock to increments".
  - `height` — Physical height of the slider on the window. 0 will fill the remaining amount of window space.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `notifyOn` — Allows you to modify the behavior of the return value.
  - returns — Returns true any time the value changes.
- `static bool UI.VSliderAt(string id, Single& value, float min, float max, float step, Vec3 topLeftCorner, Vec2 size, UIConfirm confirmMethod, UINotify notifyOn)` — A variant of UI.VSlider that doesn't use the layout system, and instead goes exactly where you put it.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, top side of the slider.
  - `max` — The maximum value the slider can set, bottom side of the slider.
  - `step` — Locks the value to increments of step. Starts at min, and increments by step. 0 is valid, and means "don't lock to increments".
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `notifyOn` — Allows you to modify the behavior of the return value.
  - returns — Returns true any time the value changes.
- `static bool UI.VSliderAt(string id, Double& value, double min, double max, double step, Vec3 topLeftCorner, Vec2 size, UIConfirm confirmMethod, UINotify notifyOn)` — A variant of UI.VSlider that doesn't use the layout system, and instead goes exactly where you put it.
  - `id` — An id for tracking element state. MUST be unique within current hierarchy.
  - `value` — The value that the slider will store slider state in.
  - `min` — The minimum value the slider can set, top side of the slider.
  - `max` — The maximum value the slider can set, bottom side of the slider.
  - `step` — Locks the value to intervals of step. Starts at min, and increments by step.
  - `topLeftCorner` — This is the top left corner of the UI element relative to the current Hierarchy.
  - `size` — The layout size for this element in Hierarchy space.
  - `confirmMethod` — How should the slider be activated? Push will be a push-button the user must press first, and pinch will be a tab that the user must pinch and drag around.
  - `notifyOn` — Allows you to modify the behavior of the return value.
  - returns — Returns true any time the value changes.
- `static void UI.VSpace(float verticalSpace)` — Adds some vertical space to the current line! All UI following elements on this line will be offset.
  - `verticalSpace` — Space in meters to shift the layout by.
- `static void UI.WindowBegin(string text, UIWin windowType, UIMove moveType)` — Begins a new window! This will push an automatically determined pose onto the transform stack, and all UI elements will be relative to that new pose. The pose is actually the top-center of the window. Must be finished with a call to UI.WindowEnd().
  - `text` — Text to display on the window title and id for tracking element state. MUST be unique within current hierarchy.
  - `windowType` — Describes how the window should be drawn, use a header, a body, neither, or both?
  - `moveType` — Describes how the window will move when dragged around.
- `static void UI.WindowBegin(string text, Vec2 size, UIWin windowType, UIMove moveType)` — Begins a new window! This will push an automatically determined pose onto the transform stack, and all UI elements will be relative to that new pose. The pose is actually the top-center of the window. Must be finished with a call to UI.WindowEnd().
  - `text` — Text to display on the window title and id for tracking element state. MUST be unique within current hierarchy.
  - `size` — Physical size of the window! If either dimension is 0, then the size on that axis will be auto- calculated based on the content provided during the previous frame.
  - `windowType` — Describes how the window should be drawn, use a header, a body, neither, or both?
  - `moveType` — Describes how the window will move when dragged around.
- `static void UI.WindowBegin(string text, Pose& pose, Vec2 size, UIWin windowType, UIMove moveType)` — Begins a new window! This will push a pose onto the transform stack, and all UI elements will be relative to that new pose. The pose is actually the top-center of the window. Must be finished with a call to UI.WindowEnd().
  - `text` — Text to display on the window title and id for tracking element state. MUST be unique within current hierarchy.
  - `pose` — The pose state for the window! If showHeader is true, the user will be able to grab this header and move it around.
  - `size` — Physical size of the window! If either dimension is 0, then the size on that axis will be auto- calculated based on the content provided during the previous frame.
  - `windowType` — Describes how the window should be drawn, use a header, a body, neither, or both?
  - `moveType` — Describes how the window will move when dragged around.
- `static void UI.WindowBegin(string text, Pose& pose, UIWin windowType, UIMove moveType)` — Begins a new window! This will push a pose onto the transform stack, and all UI elements will be relative to that new pose. The pose is actually the top-center of the window. Must be finished with a call to UI.WindowEnd(). This override omits the size value, so the size will be auto-calculated based on the content provided during the previous frame.
  - `text` — Text to display on the window title and id for tracking element state. MUST be unique within current hierarchy.
  - `pose` — The pose state for the window! If showHeader is true, the user will be able to grab this header and move it around.
  - `windowType` — Describes how the window should be drawn, use a header, a body, neither, or both?
  - `moveType` — Describes how the window will move when dragged around.
  - Example: see `UI.WindowBegin` in StereoKit-docs-reference.md
- `static void UI.WindowEnd()` — Finishes a window! Must be called after UI.WindowBegin() and all elements have been drawn.
  - Example: see `UI.WindowEnd` in StereoKit-docs-reference.md

## enum UIBtnFlag

A bit-flag for modifying the behavior of a button, used with the lower-level `UI.ButtonBehavior`.

- `UIBtnFlag.NoCancel` — Prevents the activation from being canceled when the interactor moves too far from the button. Used for elements like sliders that legitimately track an interactor well outside the button's bounds.
- `UIBtnFlag.None` — Default button behavior.

## enum UIBtnLayout

Describes the layout of a button with image/text contents! You can think of the naming here as being the location of the image, with the text filling the remaining space.

- `UIBtnLayout.Center` — Image will be centered in the button, and fill up the button as though it was the only element. Text will cram itself under the padding below the image.
- `UIBtnLayout.CenterNoText` — Same as `Center`, but omitting the text.
- `UIBtnLayout.Left` — Image to the left, text to the right. Image will take up no more than half the width.
- `UIBtnLayout.None` — Hide the image, and only show text.
- `UIBtnLayout.Right` — Image to the right, text to the left. Image will take up no more than half the width.

## enum UIColor

Theme color categories to pair with `UI.SetThemeColor`.

- `UIColor.Background` — This is a background sort of color that should generally be dark. Used by window bodies and backgrounds of certain elements.
- `UIColor.Common` — A normal UI element color, for elements like buttons and sliders.
- `UIColor.Complement` — Not really used anywhere at the moment, maybe for the UI.Panel.
- `UIColor.Max` — A maximum enum value to allow for iterating through enum values.
- `UIColor.None` — The default category, used to indicate that no category has been selected.
- `UIColor.Primary` — This is the main accent color used by window headers, separators, etc.
- `UIColor.Text` — Text color! This should generally be really bright, and at the very least contrast-ey.

## enum UIColorState

Indicates the state of a UI theme color.

- `UIColorState.Active` — The UI element has been activated fully by some type of interaction.
- `UIColorState.Disabled` — The UI element is currently disabled, and cannot be used.
- `UIColorState.Normal` — The UI element is in its normal resting state.

## enum UIConfirm

Used with StereoKit's UI, and determines the interaction confirmation behavior for certain elements, such as the UI.HSlider!

- `UIConfirm.Pinch` — The user must use a pinch gesture to interact with this element. This is much harder to activate by accident, but does require the user to make a precise pinch gesture. You can pretty much be sure that's what the user meant to do!
- `UIConfirm.Push` — The user must push a button with their finger to confirm interaction with this element. This is simpler to activate as it requires no learned gestures, but may result in more false positives.
- `UIConfirm.VariablePinch` — HSlider specific. Same as Pinch, but pulling out from the slider creates a scaled slider that lets you adjust the slider at a more granular resolution.

## enum UICorner

For elements that contain corners, this bit flag allows you to specify which corners.

- `UICorner.All` — All corners.
- `UICorner.Bottom` — The bottom left and bottom right corners.
- `UICorner.BottomLeft` — The bottom left corner.
- `UICorner.BottomRight` — The bottom right corner.
- `UICorner.Left` — The top left and bottom left corners.
- `UICorner.None` — No corners at all.
- `UICorner.Right` — The top right and bottom right corners.
- `UICorner.Top` — The top left and top right corners.
- `UICorner.TopLeft` — The top left corner.
- `UICorner.TopRight` — The top right corner.

## enum UICut

This describes how a layout should be cut up! Used with `UI.LayoutPushCut`.

- `UICut.Bottom` — This cuts a chunk from the bottom side of the current layout. This will work for layouts that are fixed sized, but not layouts that auto-size on the Y axis!
- `UICut.Left` — This cuts a chunk from the left side of the current layout. This will work for layouts that are auto-sizing, and fixed sized.
- `UICut.Right` — This cuts a chunk from the right side of the current layout. This will work for layouts that are fixed sized, but not layouts that auto-size on the X axis!
- `UICut.Top` — This cuts a chunk from the top side of the current layout. This will work for layouts that are auto-sizing, and fixed sized.

## enum UIDir

For UI elements that can be oriented horizontally or vertically, this specifies that orientation.

- `UIDir.Horizontal` — The element should be layed out along the horizontal axis.
- `UIDir.Vertical` — The element should be layed out along the vertical axis.

## enum UIGesture

This is a bit flag that describes different types and combinations of gestures used within the UI system.

- `UIGesture.Grip` — A gripping or grasping motion meant to represent a full hand grab. This is calculated using the distance between the root and the tip of the ring finger.
- `UIGesture.None` — Default zero state, no gesture at all.
- `UIGesture.Pinch` — A pinching action, calculated by taking the distance between the tip of the thumb and the index finger.
- `UIGesture.PinchGrip` — This is a bit flag combination of both Pinch and Grip.

## struct UILathePt

A point on a lathe for a mesh generation algorithm. This is the 'silhouette' of the mesh, or the shape the mesh would take if you spun this line of points in a cylinder.

- `Color32 UILathePt.color` — Vertex color of the current lathe vertex.
- `bool UILathePt.connectNext` — Will there be triangles connecting this lathe point to the next in the list, or is this a jump without triangles?
- `bool UILathePt.flipFace` — Should the triangles attaching this point to the next be ordered backwards?
- `Vec2 UILathePt.normal` — The lathe normal point, which will be rotated along the surface of the mesh.
- `Vec2 UILathePt.pt` — Lathe point 'location', where 'x' is a percentage of the lathe radius along the current surface normal, and Y is the absolute Z axis value.

## enum UIMove

This describes how a UI element moves when being dragged around by a user!

- `UIMove.Exact` — The element follows the position and orientation of the user's hand exactly.
- `UIMove.ExactNoscale` — Behaves just like ui_move_exact, but opts out of uniform scaling. Use this when a Handle is provided a scale value, but should only ever be translated and rotated by multiple interactors, never scaled.
- `UIMove.FaceUser` — The element follows the position of the user's hand, but orients to face the user's head instead of just using the hand's rotation.
- `UIMove.None` — Do not allow user input to change the element's pose at all! You may also be interested in UI.Push/PopSurface.
- `UIMove.PosOnly` — This element follows the hand's position only, completely discarding any rotation information.

## enum UINotify

Determines when this UI function returns true.

- `UINotify.Change` — This function returns true any time the values has changed!
- `UINotify.Finalize` — This function returns true when the user has finished interacting with it. This does not guarantee the value has changed.

## enum UIPad

This specifies a particular padding mode for certain UI elements, such as the UI.Panel! This describes where padding is applied and how it affects the layout of elements.

- `UIPad.Inside` — This applies padding inside the element's layout bounds, and will inflate the layout bounds to fit the extra padding.
- `UIPad.None` — No padding, this matches the element's layout bounds exactly!
- `UIPad.Outside` — This will apply the padding outside of the layout bounds! This will maintain the size and position of the layout volume, but the visual padding will go outside of the volume.

## enum UIScroll

This describes how UI elements with scrollable regions scroll around or use scroll bars! This allows you to enable or disable vertical and horizontal scrolling.

- `UIScroll.Both` — This will enable both vertical and horizontal scroll bars or scrolling.
- `UIScroll.Horizontal` — This will enable horizontal scroll bars or scrolling.
- `UIScroll.None` — No scroll bars or scrolling.
- `UIScroll.Vertical` — This will enable vertical scroll bars or scrolling.

## struct UISettings

Visual properties and spacing of the UI system.

- `float UISettings.backplateBorder` — How wide is the back-border around the UI elements, in meters.
- `float UISettings.backplateDepth` — How far up does the white back-border go on UI elements? This is a 0-1 percentage of the depth value.
- `float UISettings.depth` — The Z depth of 3D UI elements, in meters.
- `float UISettings.gutter` — Spacing between sibling items, in meters.
- `float UISettings.margin` — The margin is the space between a window and its contents, in meters.
- `float UISettings.padding` — Spacing between an item and its parent, in meters.
- `float UISettings.rounding` — Radius of the UI element corners, in meters.
- `float UISettings.separatorScale` — Defines the scale factor for the separator's thickness. The thickness is calculated by multiplying the height of the text by this factor. The default value is 0.4.

## struct UISliderData

Data about a UI slider element's current interaction state. Provided by the ui_slider_behavior function.

- `BtnState UISliderData.activeState` — The current active/pressed state of the slider.
- `Vec2 UISliderData.buttonCenter` — The center of the slider button in window-relative coordinates.
- `float UISliderData.fingerOffset` — How far the finger is pressing into the slider, in meters.
- `BtnState UISliderData.focusState` — The current focus state of the slider.
- `int UISliderData.interactor` — The id of the interactor that is interacting with this slider, or -1 if none.

## enum UIVisual

Used with StereoKit's UI to indicate a particular type of UI element visual.

- `UIVisual.Aura` — Refers to the grabbable area indicator outside a window.
- `UIVisual.Button` — Refers to UI.Button elements.
- `UIVisual.ButtonRound` — Refers to UI.ButtonRound elements.
- `UIVisual.Carat` — Deprecated misspelling of `ui_vis_caret`, kept for backwards compatibility.
- `UIVisual.Caret` — Refers to the text position indicator caret on text input elements.
- `UIVisual.Default` — A default root UI element. Not a particular element, but other elements may refer to this if there is nothing more specific present.
- `UIVisual.Handle` — Refers to UI.Handle/HandleBegin elements.
- `UIVisual.Input` — Refers to UI.Input elements.
- `UIVisual.Max` — A maximum enum value to allow for iterating through enum values.
- `UIVisual.None` — Default state, no UI element at all.
- `UIVisual.Panel` — Refers to UI.PanelBegin/End elements.
- `UIVisual.Separator` — Refers to UI.HSeparator element.
- `UIVisual.SliderLine` — Refers to the back line component of the UI.HSlider element for full lines.
- `UIVisual.SliderLineActive` — Refers to the back line component of the UI.HSlider element for the active or "full" half of the line.
- `UIVisual.SliderLineInactive` — Refers to the back line component of the UI.HSlider element for the inactive or "empty" half of the line.
- `UIVisual.SliderPinch` — Refers to the pinch button component of the UI.HSlider element when using UIConfirm.Pinch.
- `UIVisual.SliderPush` — Refers to the push button component of the UI.HSlider element when using UIConfirm.Push.
- `UIVisual.Toggle` — Refers to UI.Toggle elements.
- `UIVisual.WindowBody` — Refers to UI.Window/WindowBegin body panel element, this element is used when a Window head is also present.
- `UIVisual.WindowBodyOnly` — Refers to UI.Window/WindowBegin body element, this element is used when a Window only has the body panel, without a head.
- `UIVisual.WindowHead` — Refers to UI.Window/WindowBegin head panel element, this element is used when a Window body is also present.
- `UIVisual.WindowHeadOnly` — Refers to UI.Window/WindowBegin head element, this element is used when a Window only has the head panel, without a body.

## enum UIWin

A description of what type of window to draw! This is a bit flag, so it can contain multiple elements.

- `UIWin.Body` — Flag to include a body on the window.
- `UIWin.Empty` — No body, no head. Not really a flag, just set to this value. The Window will still be grab/movable. To prevent it from being grabbable, combine with the UIMove.None option, or switch to UI.Push/PopSurface.
- `UIWin.Head` — Flag to include a head on the window.
- `UIWin.Normal` — A normal window has a head and a body to it. Both can be grabbed.

## static class Units

A collection of unit conversion constants! Multiply things by these to convert them into different units.

- `static float Units.cm2m` — Converts centimeters to meters. There are 100cm in 1m. In StereoKit 1 unit is also 1 meter, so `25 * Units.cm2m == 0.25`, 25 centimeters is .25 meters/units.
- `static float Units.deg2rad` — Degrees to radians, multiply degree values by this, and you get radians! Like so: `180 * Units.deg2rad == 3.1415926536`, which is pi, or 1 radian.
- `static float Units.m2cm` — Converts meters to centimeters. There are 100cm in 1m, so this just multiplies by 100.
- `static float Units.m2mm` — Converts meters to millimeters. There are 1000mm in 1m, so this just multiplies by 1000.
- `static float Units.mm2m` — Converts millimeters to meters. There are 1000mm in 1m. In StereoKit 1 unit is 1 meter, so `250 * Units.mm2m == 0.25`, 250 millimeters is .25 meters/units.
- `static float Units.rad2deg` — Radians to degrees, multiply radian values by this, and you get degrees! Like so: `PI * Units.rad2deg == 180`

## static class V

This is a collection of vector initialization shorthands. Since math can often get a little long to write, saving a few characters here and there can make a difference in readability. This also comes with some swizzles to make things even shorter! I also don't love the 'new' keyword on Vectors, and this eliminates that. For example: instead of `new Vec3(2.0f, 2.0f, 2.0f)` or even `Vec3.One * 2.0f`, you could write `V.XXX(2.0f)`
- `static Vec3 V.X0Z(float x, float z)` — Creates a Vec3, this is a straight alternative to `new Vec3(x, 0, z)`
  - `x` — X component of the Vector
  - `z` — Z component of the Vector
  - returns — A Vec3(x, 0, z)
- `static Vec2 V.XX(float x)` — Creates a Vec2 where both components are the same value. This is the same as `new Vec2(x, x)`
  - `x` — Both X and Y components will have this value.
  - returns — A Vec2(x, x)
- `static Vec3 V.XXX(float x)` — Creates a Vec3 where all components are the same value. This is the same as `new Vec3(x, x, x)`
  - `x` — X, Y and Z components will have this value.
  - returns — A Vec3(x, x, x)
- `static Vec4 V.XXXX(float x)` — Creates a Vec4 where all components are the same value. This is the same as `new Vec4(x, x, x, x)`
  - `x` — X, Y, Z and W components will have this value.
  - returns — A Vec4(x, x, x, x)
- `static Vec2 V.XY(float x, float y)` — Creates a Vec2, this is a straight alternative to `new Vec2(x, y)`
  - `x` — X component of the Vector
  - `y` — Y component of the Vector
  - returns — A Vec2(x, y)
- `static Vec3 V.XY0(float x, float y)` — Creates a Vec3, this is a straight alternative to `new Vec3(x, y, 0)`
  - `x` — X component of the Vector
  - `y` — Y component of the Vector
  - returns — A Vec3(x, y, 0)
- `static Vec3 V.XYZ(float x, float y, float z)` — Creates a Vec3, this is a straight alternative to `new Vec3(x, y, z)`
  - `x` — X component of the Vector
  - `y` — Y component of the Vector
  - `z` — Z component of the Vector
  - returns — A Vec3(x, y, z)
- `static Vec4 V.XYZW(float x, float y, float z, float w)` — Creates a Vec4, this is a straight alternative to `new Vec4(x, y, z, w)`
  - `x` — X component of the Vector
  - `y` — Y component of the Vector
  - `z` — Z component of the Vector
  - `w` — W component of the Vector
  - returns — A Vec4(x, y, z, w)

## struct Vec2

A vector with 2 components: x and y. This can represent a point in 2D space, a directional vector, or any other sort of value with 2 dimensions to it!

- `float Vec2.Length` — This is the length of the vector! Or the distance from the origin to this point. Uses Math.Sqrt, so it's not dirt cheap or anything.
- `float Vec2.LengthSq` — This is the squared length/magnitude of the vector! It skips the Sqrt call, and just gives you the squared version for speedy calculations that can work with it squared.
- `float Vec2.Magnitude` — Magnitude is the length of the vector! Or the distance from the origin to this point. Uses Math.Sqrt, so it's not dirt cheap or anything.
- `float Vec2.MagnitudeSq` — This is the squared magnitude of the vector! It skips the Sqrt call, and just gives you the squared version for speedy calculations that can work with it squared.
- `Vec2 Vec2.Normalized` — Creates a normalized vector (vector with a length of 1) from the current vector. Will not work properly if the vector has a length of zero.
- `Vector2 Vec2.v` — The internal, wrapped System.Numerics type. This can be nice to have around so you can pass its fields as 'ref', which you can't do with properties. You won't often need this, as implicit conversions to System.Numerics types are also provided.
- `float Vec2.x` — X component.
- `Vec3 Vec2.X0Y` — Promotes this Vec2 to a Vec3, using 0 for the Y axis.
- `Vec3 Vec2.XY0` — Promotes this Vec2 to a Vec3, using 0 for the Z axis.
- `Vec3 Vec2.XY1` — Promotes this Vec2 to a Vec3, using 1 for the Z axis.
- `float Vec2.y` — Y component.
- `Vec2 Vec2.YX` — A transpose swizzle property, returns (y,x)
- `static Vec2 Vec2.One` — A Vec2 with all components at one, this is the same as `new Vec2(1,1)`.
- `static Vec2 Vec2.UnitX` — A normalized Vector that points down the X axis, this is the same as `new Vec2(1,0)`.
- `static Vec2 Vec2.UnitY` — A normalized Vector that points down the Y axis, this is the same as `new Vec2(0,1)`.
- `static Vec2 Vec2.Zero` — A Vec2 with all components at zero, this is the same as `new Vec2(0,0)`.
- `void Vec2(float x, float y)` — A basic constructor, just copies the values in!
  - `x` — X component of the vector.
  - `y` — Y component of the vector.
- `void Vec2(Vector2 v)` — Initialize from a System.Numerics vector, this can also be done by an implicit or explicit cast/assignment.
  - `v` — A System.Numerics vector.
- `void Vec2(float xy)` — A short hand constructor, just sets all values as the same!
  - `xy` — X and Y component of the vector.
- `float Vec2.Angle()` — Returns the counter-clockwise degrees from [1,0]. Resulting value is between 0 and 360. Vector does not need to be normalized.
  - returns — Counter-clockwise angle of the vector in degrees from [1,0], as a value between 0 and 360.
  - Example: see `Vec2.Angle` in StereoKit-docs-reference.md
- `static float Vec2.AngleBetween(Vec2 a, Vec2 b)` — Calculates a signed angle between two vectors in degrees! Sign will be positive if B is counter-clockwise (left) of A, and negative if B is clockwise (right) of A. Vectors do not need to be normalized. NOTE: Since this will return a positive or negative angle, order of parameters matters!
  - `a` — The first, initial vector, A. Does not need to be normalized.
  - `b` — The second vector, B, that we're finding the angle to. Does not need to be normalized.
  - returns — a signed angle between two vectors in degrees! Sign will be positive if B is counter-clockwise (left) of A, and negative if B is clockwise (right) of A.
  - Example: see `Vec2.AngleBetween` in StereoKit-docs-reference.md
- `static Vec2 Vec2.Direction(Vec2 to, Vec2 from)` — Creates a normalized delta vector that points out from an origin point to a target point!
  - `to` — The target point.
  - `from` — And the origin point!
  - returns — Direction from one point to another.
- `static float Vec2.Distance(Vec2 a, Vec2 b)` — Calculates the distance between two points in space! Make sure they're in the same coordinate space! Uses a Sqrt, so it's not blazing fast, prefer DistanceSq when possible.
  - `a` — The first point.
  - `b` — And the second point!
  - returns — Distance between the two points.
- `static float Vec2.DistanceSq(Vec2 a, Vec2 b)` — Calculates the distance between two points in space, but leaves them squared! Make sure they're in the same coordinate space! This is a fast function :)
  - `a` — The first point.
  - `b` — And the second point!
  - returns — Distance between the two points, but squared!
- `static float Vec2.Dot(Vec2 a, Vec2 b)` — The dot product is an extremely useful operation! One major use is to determine how similar two vectors are. If the vectors are Unit vectors (magnitude/length of 1), then the result will be 1 if the vectors are the same, -1 if they're opposite, and a gradient in-between with 0 being perpendicular. See [Freya Holmer's excellent visualization](https://twitter.com/FreyaHolmer/status/1200807790580768768) of this concept
  - `a` — First vector.
  - `b` — Second vector.
  - returns — The dot product!
- `static Vec2 Vec2.FromAngle(float degrees)` — Creates a vector pointing in the direction of the angle, with a length of 1. Angles are counter-clockwise, and start from (1,0), so an angle of 90 will be (0,1).
  - `degrees` — Counter-clockwise angle from (1,0), in degrees.
  - returns — A unit vector (length of 1), pointing towards degrees.
- `bool Vec2.InRadius(Vec2 pt, float radius)` — Checks if a point is within a certain radius of this one. This is an easily readable shorthand of the squared distance check.
  - `pt` — The point to check against.
  - `radius` — The distance to check against.
  - returns — True if the points are within radius of each other, false not.
- `static bool Vec2.InRadius(Vec2 a, Vec2 b, float radius)` — Checks if two points are within a certain radius of each other. This is an easily readable shorthand of the squared distance check.
  - `a` — The first point.
  - `b` — And the second point!
  - `radius` — The distance to check against.
  - returns — True if a and b are within radius of each other, false if not.
- `static Vec2 Vec2.Lerp(Vec2 a, Vec2 b, float blend)` — Blends (Linear Interpolation) between two vectors, based on a 'blend' value, where 0 is a, and 1 is b. Doesn't clamp percent for you.
  - `a` — First item in the blend, or '0.0' blend.
  - `b` — Second item in the blend, or '1.0' blend.
  - `blend` — A blend value between 0 and 1. Can be outside this range, it'll just interpolate outside of the a, b range.
  - returns — An unclamped blend of a and b.
- `static Vec2 Vec2.Max(Vec2 a, Vec2 b)` — Returns a vector where each element is the maximum value for each corresponding pair.
  - `a` — Order isn't important here.
  - `b` — Order isn't important here.
  - returns — The maximum value for each corresponding vector pair.
- `static Vec2 Vec2.Min(Vec2 a, Vec2 b)` — Returns a vector where each element is the minimum value for each corresponding pair.
  - `a` — Order isn't important here.
  - `b` — Order isn't important here.
  - returns — The minimum value for each corresponding vector pair.
- `void Vec2.Normalize()` — Turns this vector into a normalized vector (vector with a length of 1) from the current vector. Will not work properly if the vector has a length of zero.
  - returns — The normalized (length of 1) vector!
- `static Vec2 Vec2.+(Vec2 a, Vec2 b)` — Adds matching components together. Commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector from the added components.
- `static Vec2 Vec2.+(Vec2 a, float b)` — Adds the float to each component of the vector.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector from the added components.
- `static Vec2 Vec2./(Vec2 a, Vec2 b)` — A component-wise vector division. Not commutative
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector a divided by b.
- `static Vec2 Vec2./(Vec2 a, float b)` — A scalar vector division.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector a divided by b.
- `static Vec2 Vec2.Implicit Conversions(Vector2 v)` — Allows implicit conversion from System.Numerics.Vector2 to StereoKit.Vec2.
  - `v` — Any System.Numerics Vector2.
  - returns — A StereoKit compatible vector.
- `static Vector2 Vec2.Implicit Conversions(Vec2 v)` — Allows implicit conversion from StereoKit.Vec2 to System.Numerics.Vector2
  - `v` — Any StereoKit.Vec2.
  - returns — A System.Numerics compatible vector.
- `static Vec2 Vec2.*(Vec2 a, Vec2 b)` — A component-wise vector multiplication, same thing as a non-uniform scale. NOT a dot product! Commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector a scaled by b.
- `static Vec2 Vec2.*(Vec2 a, float b)` — A scalar vector multiplication.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector a scaled by b.
- `static Vec2 Vec2.*(float a, Vec2 b)` — A scalar vector multiplication.
  - `a` — Any scalar.
  - `b` — Any vector.
  - returns — A new vector a scaled by b.
- `static Vec2 Vec2.-(Vec2 a, Vec2 b)` — Subtracts matching components from eachother. Not commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector from the subtracted components.
- `static Vec2 Vec2.-(Vec2 a, float b)` — Subtracts the float to each component of the vector.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector from the subtracted components.
- `static Vec2 Vec2.-(Vec2 a)` — Vector negation, returns a vector where each component has been negated.
  - `a` — Any vector.
  - returns — A vector where each component has been negated.
- `string Vec2.ToString()` — Mostly for debug purposes, this is a decent way to log or inspect the vector in debug mode. Looks like "[x, y]"
  - returns — A string that looks like "[x, y]"

## struct Vec3

A vector with 3 components: x, y, z. This can represent a point in space, a directional vector, or any other sort of value with 3 dimensions to it! StereoKit uses a right-handed coordinate system, where +x is to the right, +y is upwards, and -z is forward.

- `float Vec3.Length` — This is the length, or magnitude of the vector! The distance from the origin to this point. Uses Math.Sqrt, so it's not dirt cheap or anything.
- `float Vec3.LengthSq` — This is the squared length of the vector! It skips the Sqrt call, and just gives you the squared version for speedy calculations that can work with it squared.
- `float Vec3.Magnitude` — Magnitude is the length of the vector! The distance from the origin to this point. Uses Math.Sqrt, so it's not dirt cheap or anything.
- `float Vec3.MagnitudeSq` — This is the squared magnitude of the vector! It skips the Sqrt call, and just gives you the squared version for speedy calculations that can work with it squared.
- `Vec3 Vec3.Normalized` — Creates a normalized vector (vector with a length of 1) from the current vector. Will not work properly if the vector has a length of zero.
- `Vector3 Vec3.v` — The internal, wrapped System.Numerics type. This can be nice to have around so you can pass its fields as 'ref', which you can't do with properties. You won't often need this, as implicit conversions to System.Numerics types are also provided.
- `float Vec3.x` — X component.
- `Vec3 Vec3.X0Z` — This returns a Vec3 that has been flattened to 0 on the Y axis. No other changes are made.
- `Vec2 Vec3.XY` — This extracts a Vec2 from the X and Y axes.
- `Vec3 Vec3.XY0` — This returns a Vec3 that has been flattened to 0 on the Z axis. No other changes are made.
- `Vec3 Vec3.XY1` — This returns a Vec3 that has been set to 1 on the Z axis. No other changes are made.
- `Vec2 Vec3.XZ` — This extracts a Vec2 from the X and Z axes.
- `float Vec3.y` — Y component.
- `Vec2 Vec3.YZ` — This extracts a Vec2 from the Y and Z axes.
- `float Vec3.z` — Z component.
- `static Vec3 Vec3.Forward` — StereoKit uses a right-handed coordinate system, which means that forward is looking down the -Z axis! This value is the same as `new Vec3(0,0,-1)`. This is NOT the same as UnitZ!
- `static Vec3 Vec3.One` — Shorthand for a vector where all values are 1! Same as `new Vec3(1,1,1)`.
- `static Vec3 Vec3.Right` — When looking forward, this is the direction to the right! In StereoKit, this is the same as `new Vec3(1,0,0)`
- `static Vec3 Vec3.UnitX` — A normalized Vector that points down the X axis, this is the same as `new Vec3(1,0,0)`.
- `static Vec3 Vec3.UnitY` — A normalized Vector that points down the Y axis, this is the same as `new Vec3(0,1,0)`.
- `static Vec3 Vec3.UnitZ` — A normalized Vector that points down the Z axis, this is the same as `new Vec3(0,0,1)`. This is NOT the same as Forward!
- `static Vec3 Vec3.Up` — A vector representing the up axis. In StereoKit, this is the same as `new Vec3(0,1,0)`.
- `static Vec3 Vec3.Zero` — Shorthand for a vector where all values are 0! Same as `new Vec3(0,0,0)`.
- `void Vec3(float x, float y, float z)` — Creates a vector from x, y, and z values! StereoKit uses a right-handed metric coordinate system, where +x is to the right, +y is upwards, and -z is forward.
  - `x` — The x axis.
  - `y` — The y axis.
  - `z` — The z axis.
- `void Vec3(Vector3 v)` — Initialize from a System.Numerics vector, this can also be done by an implicit or explicit cast/assignment.
  - `v` — A System.Numerics vector.
- `void Vec3(float xyz)` — Creates a vector with all values the same! StereoKit uses a right-handed metric coordinate system, where +x is to the right, +y is upwards, and -z is forward.
  - `xyz` — The x,y,and z axis.
- `static Vec3 Vec3.Abs(Vec3 a)` — Returns a vector where each element is the absolute value of the corresponding component.
  - `a` — Source vector.
  - returns — The absolute value for each corresponding component.
- `static float Vec3.AngleBetween(Vec3 a, Vec3 b)` — Calculates the angle between two vectors in degrees! Vectors do not need to be normalized, and the result will always be positive.
  - `a` — The first, initial vector, A. Does not need to be normalized.
  - `b` — The second vector, B, that we're finding the angle to. Does not need to be normalized.
  - returns — A positive angle between two vectors in degrees!
- `static Vec3 Vec3.AngleXY(float angleDeg, float z)` — Creates a vector that points out at the given 2D angle! This creates the vector on the XY plane, and allows you to specify a constant z value.
  - `angleDeg` — Angle in degrees, starting from (1,0) at 0, and continuing to (0,1) at 90.
  - `z` — A constant value you can assign to the resulting vector's z component.
  - returns — A vector pointing at the given angle! If z is zero, this will be a normalized vector (vector with a length of 1).
- `static Vec3 Vec3.AngleXZ(float angleDeg, float y)` — Creates a vector that points out at the given 2D angle! This creates the vector on the XZ plane, and allows you to specify a constant y value.
  - `angleDeg` — Angle in degrees, starting from (1,0) at 0, and continuing to (0,1) at 90.
  - `y` — A constant value you can assign to the resulting vector's y component.
  - returns — A Vector pointing at the given angle! If y is zero, this will be a normalized vector (vector with a length of 1).
- `static Vec3 Vec3.Cross(Vec3 a, Vec3 b)` — The cross product of two vectors!
  - `a` — First vector!
  - `b` — Second vector!
  - returns — Result is -not- a unit vector, even if both 'a' and 'b' are unit vectors.
- `static Vec3 Vec3.Direction(Vec3 to, Vec3 from)` — Creates a normalized delta vector that points out from an origin point to a target point!
  - `to` — The target point.
  - `from` — And the origin point!
  - returns — Direction from one point to another.
- `static float Vec3.Distance(Vec3 a, Vec3 b)` — Calculates the distance between two points in space! Make sure they're in the same coordinate space! Uses a Sqrt, so it's not blazing fast, prefer DistanceSq when possible.
  - `a` — The first point.
  - `b` — And the second point!
  - returns — Distance between the two points.
  - Example: see `Vec3.Distance` in StereoKit-docs-reference.md
- `static float Vec3.DistanceSq(Vec3 a, Vec3 b)` — Calculates the distance between two points in space, but leaves them squared! Make sure they're in the same coordinate space! This is a fast function :)
  - `a` — The first point.
  - `b` — And the second point!
  - returns — Distance between the two points, but squared!
  - Example: see `Vec3.DistanceSq` in StereoKit-docs-reference.md
- `static float Vec3.Dot(Vec3 a, Vec3 b)` — The dot product is an extremely useful operation! One major use is to determine how similar two vectors are. If the vectors are Unit vectors (magnitude/length of 1), then the result will be 1 if the vectors are the same, -1 if they're opposite, and a gradient in-between with 0 being perpendicular. See [Freya Holmer's excellent visualization](https://twitter.com/FreyaHolmer/status/1200807790580768768) of this concept
  - `a` — First vector.
  - `b` — Second vector.
  - returns — The dot product!
- `bool Vec3.InRadius(Vec3 pt, float radius)` — Checks if a point is within a certain radius of this one. This is an easily readable shorthand of the squared distance check.
  - `pt` — The point to check against.
  - `radius` — The distance to check against.
  - returns — True if the points are within radius of each other, false not.
- `static bool Vec3.InRadius(Vec3 a, Vec3 b, float radius)` — Checks if two points are within a certain radius of each other. This is an easily readable shorthand of the squared distance check.
  - `a` — The first point.
  - `b` — And the second point!
  - `radius` — The distance to check against.
  - returns — True if a and b are within radius of each other, false if not.
- `static Vec3 Vec3.Lerp(Vec3 a, Vec3 b, float blend)` — Blends (Linear Interpolation) between two vectors, based on a 'blend' value, where 0 is a, and 1 is b. Doesn't clamp percent for you.
  - `a` — First item in the blend, or '0.0' blend.
  - `b` — Second item in the blend, or '1.0' blend.
  - `blend` — A blend value between 0 and 1. Can be outside this range, it'll just interpolate outside of the a, b range.
  - returns — An unclamped blend of a and b.
- `static Vec3 Vec3.Max(Vec3 a, Vec3 b)` — Returns a vector where each element is the maximum value for each corresponding pair.
  - `a` — Order isn't important here.
  - `b` — Order isn't important here.
  - returns — The maximum value for each corresponding vector pair.
- `static Vec3 Vec3.Min(Vec3 a, Vec3 b)` — Returns a vector where each element is the minimum value for each corresponding pair.
  - `a` — Order isn't important here.
  - `b` — Order isn't important here.
  - returns — The minimum value for each corresponding vector pair.
- `void Vec3.Normalize()` — Turns this vector into a normalized vector (vector with a length of 1) from the current vector. Will not work properly if the vector has a length of zero.
  - returns — The normalized (length of 1) vector!
- `static Vec3 Vec3.+(Vec3 a, Vec3 b)` — Adds matching components together. Commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector from the added components.
- `static Vec3 Vec3.+(Vec3 a, float b)` — Adds the float to each component of the vector.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector from the added components.
- `static Vec3 Vec3./(Vec3 a, Vec3 b)` — A component-wise vector division. Not commutative
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector a divided by b.
- `static Vec3 Vec3./(Vec3 a, float b)` — A scalar vector division.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector a divided by b.
- `static Vec3 Vec3.Implicit Conversions(Vector3 v)` — Allows implicit conversion from System.Numerics.Vector3 to StereoKit.Vec3.
  - `v` — Any System.Numerics Vector3.
  - returns — A StereoKit compatible vector.
- `static Vector3 Vec3.Implicit Conversions(Vec3 v)` — Allows implicit conversion from StereoKit.Vec3 to System.Numerics.Vector3
  - `v` — Any StereoKit.Vec3.
  - returns — A System.Numerics compatible vector.
- `static Vec3 Vec3.*(Vec3 a, Vec3 b)` — A component-wise vector multiplication, same thing as a non-uniform scale. NOT a dot or cross product! Commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector a scaled by b.
- `static Vec3 Vec3.*(Vec3 a, float b)` — A scalar vector multiplication.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector a scaled by b.
- `static Vec3 Vec3.*(float a, Vec3 b)` — A scalar vector multiplication.
  - `a` — Any scalar.
  - `b` — Any vector.
  - returns — A new vector a scaled by b.
- `static Vec3 Vec3.-(Vec3 a, Vec3 b)` — Subtracts matching components from eachother. Not commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector from the subtracted components.
- `static Vec3 Vec3.-(Vec3 a, float b)` — Subtract the float to each component of the vector.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector from the subtracted components.
- `static Vec3 Vec3.-(Vec3 a)` — Vector negation, returns a vector where each component has been negated.
  - `a` — Any vector.
  - returns — A vector where each component has been negated.
- `static Vec3 Vec3.PerpendicularRight(Vec3 forward, Vec3 up)` — Exactly the same as Vec3.Cross, but has some naming mnemonics for getting the order right when trying to find a perpendicular vector using the cross product. This'll also make it more obvious to read if that's what you're actually going for when crossing vectors! If you consider a forward vector and an up vector, then the direction to the right is pretty trivial to imagine in relation to those vectors!
  - `forward` — What way are you facing?
  - `up` — What direction is up?
  - returns — Your direction to the right! Result is -not- a unit vector, even if both 'forward' and 'up' are unit vectors.
- `string Vec3.ToString()` — Mostly for debug purposes, this is a decent way to log or inspect the vector in debug mode. Looks like "[x, y, z]"
  - returns — A string that looks like "[x, y, z]"

## struct Vec4

A vector with 4 components: x, y, z, and w. Can be useful for things like shaders, where the registers are aligned to 4 float vectors. This is a wrapper on System.Numerics.Vector4, so it's SIMD optimized, and can be cast to and from implicitly.

- `Quat Vec4.Quat` — A Vec4 and a Quat are only really different by name and purpose. So, if you need to do Quat math with your Vec4, or visa versa, who am I to judge?
- `Vector4 Vec4.v` — The internal, wrapped System.Numerics type. This can be nice to have around so you can pass its fields as 'ref', which you can't do with properties. You won't often need this, as implicit conversions to System.Numerics types are also provided.
- `float Vec4.w` — W component.
- `float Vec4.x` — X component.
- `Vec2 Vec4.XY` — This extracts a Vec2 from the X and Y axes.
- `Vec3 Vec4.XYZ` — This extracts a Vec3 from the X, Y, and Z axes.
- `Vec2 Vec4.XZ` — This extracts a Vec2 from the X and Z axes.
- `float Vec4.y` — Y component.
- `Vec2 Vec4.YZ` — This extracts a Vec2 from the Y and Z axes.
- `float Vec4.z` — Z component.
- `Vec2 Vec4.ZW` — This extracts a Vec2 from the Z and W axes.
- `static Vec4 Vec4.UnitW` — A normalized Vector that points down the W axis, this is the same as `new Vec4(0,1,0,0)`.
- `static Vec4 Vec4.UnitX` — A normalized Vector that points down the X axis, this is the same as `new Vec4(1,0,0,0)`.
- `static Vec4 Vec4.UnitY` — A normalized Vector that points down the Y axis, this is the same as `new Vec4(0,1,0,0)`.
- `static Vec4 Vec4.UnitZ` — A normalized Vector that points down the Z axis, this is the same as `new Vec4(0,1,0,0)`.
- `void Vec4(float x, float y, float z, float w)` — A basic constructor, just copies the values in!
  - `x` — X component of the vector.
  - `y` — Y component of the vector.
  - `z` — Z component of the vector.
  - `w` — W component of the vector.
- `void Vec4(float xyzw)` — A basic constructor, just copies the value in as the x, y, z and w components!
  - `xyzw` — X,Y,Z,and W component of the vector.
- `void Vec4(Vec3 xyz, float w)` — A short hand constructor, just copies the values in!
  - `xyz` — X, Y and Z components of the vector.
  - `w` — W component of the vector.
- `void Vec4(Vec2 xy, Vec2 zw)` — A basic constructor, just copies the values in!
  - `xy` — X and Y components of the vector.
  - `zw` — Z and W components of the vector.
- `static float Vec4.Dot(Vec4 a, Vec4 b)` — What's a dot product do for 4D vectors, you might ask? Well, I'm no mathematician, so hopefully you are! I've never used it before. Whatever you're doing with this function, it's SIMD fast!
  - `a` — First vector.
  - `b` — Second vector.
  - returns — The dot product!
- `static Vec4 Vec4.Lerp(Vec4 a, Vec4 b, float blend)` — Blends (Linear Interpolation) between two vectors, based on a 'blend' value, where 0 is a, and 1 is b. Doesn't clamp percent for you.
  - `a` — First item in the blend, or '0.0' blend.
  - `b` — Second item in the blend, or '1.0' blend.
  - `blend` — A blend value between 0 and 1. Can be outside this range, it'll just interpolate outside of the a, b range.
  - returns — An unclamped blend of a and b.
- `static Vec4 Vec4.Max(Vec4 a, Vec4 b)` — Returns a vector where each elements is the maximum value for each corresponding pair.
  - `a` — Order isn't important here.
  - `b` — Order isn't important here.
  - returns — The maximum value for each corresponding vector pair.
- `static Vec4 Vec4.Min(Vec4 a, Vec4 b)` — Returns a vector where each elements is the minimum value for each corresponding pair.
  - `a` — Order isn't important here.
  - `b` — Order isn't important here.
  - returns — The minimum value for each corresponding vector pair.
- `static Vec4 Vec4.+(Vec4 a, Vec4 b)` — Adds matching components together. Commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector from the added components.
- `static Vec4 Vec4./(Vec4 a, Vec4 b)` — A component-wise vector division. Not commutative
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector a divided by b.
- `static Vec4 Vec4./(Vec4 a, float b)` — A scalar vector division.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector a divided by b.
- `static Vec4 Vec4.Implicit Conversions(Vector4 v)` — Allows implicit conversion from System.Numerics.Vector4 to StereoKit.Vec4.
  - `v` — Any System.Numerics Vector4.
  - returns — A StereoKit compatible vector.
- `static Vector4 Vec4.Implicit Conversions(Vec4 v)` — Allows implicit conversion from StereoKit.Vec4 to System.Numerics.Vector4.
  - `v` — Any StereoKit.Vec4.
  - returns — A System.Numerics compatible vector.
- `static Vec4 Vec4.*(Vec4 a, Vec4 b)` — A component-wise vector multiplication, same thing as a non-uniform scale. NOT a dot product! Commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector a scaled by b.
- `static Vec4 Vec4.*(Vec4 a, float b)` — A scalar vector multiplication.
  - `a` — Any vector.
  - `b` — Any scalar.
  - returns — A new vector a scaled by b.
- `static Vec4 Vec4.*(float a, Vec4 b)` — A scalar vector multiplication.
  - `a` — Any scalar.
  - `b` — Any vector.
  - returns — A new vector a scaled by b.
- `static Vec4 Vec4.-(Vec4 a, Vec4 b)` — Subtracts matching components from eachother. Not commutative.
  - `a` — Any vector.
  - `b` — Any vector.
  - returns — A new vector from the subtracted components.
- `static Vec4 Vec4.-(Vec4 a)` — Vector negation, returns a vector where each component has been negated.
  - `a` — Any vector.
  - returns — A vector where each component has been negated.
- `string Vec4.ToString()` — Mostly for debug purposes, this is a decent way to log or inspect the vector in debug mode. Looks like "[x, y, z, w]"
  - returns — A string that looks like "[x, y, z, w]"

## struct VertComponent

A single component of a custom vertex layout, such as a position or a UV coordinate. A vertex format is described by an array of these, in the same order the components appear in the vertex data. Data is always tightly packed, aligned to nothing, so the format fully describes the vertex layout. This maps to a compact 4 byte native representation, the properties here disguise that byte packing.

- `int VertComponent.Count` — How many format elements this component has, 1-4. A float3 position would be 3.
- `VertFmt VertComponent.Format` — The data format of a single element of this component.
- `VertSemantic VertComponent.Semantic` — What this component means, this is matched with the shader's vertex input semantics.
- `int VertComponent.SemanticSlot` — Distinguishes multiple components with the same semantic, like TEXCOORD0 vs TEXCOORD1. Usually 0.
- `void VertComponent(VertSemantic semantic, VertFmt format, int count, int semanticSlot)` — Describes a single vertex component.
  - `semantic` — What this component means, this is matched with the shader's vertex input semantics.
  - `format` — The data format of a single element of this component.
  - `count` — How many format elements this component has, 1-4. A float3 position would be 3.
  - `semanticSlot` — Distinguishes multiple components with the same semantic, like TEXCOORD0 vs TEXCOORD1.

## class VertComponentAttribute

Describes how a field of a vertex struct maps to a component of a vertex format! Tag every field of your custom vertex struct with this attribute, and `Mesh.SetVerts<T>` will derive the complete vertex format from the struct via reflection. The field's format is explicit rather than inferred from the field's type, so the field just needs to be the right size for the format. This means packed data like a pair of half floats can live in a plain `uint` field, with bit math or types like `System.Half` used to fill it in. Vertex structs must be tightly packed, with no padding between fields or at the end of the struct. If your field sizes don't naturally align, use `[StructLayout(LayoutKind.Sequential, Pack = 1)]`.

- `int VertComponentAttribute.Count` — How many format elements this component has, 1-4. A Vec3 position would be 3.
- `VertFmt VertComponentAttribute.Format` — The data format of a single element of this component.
- `VertSemantic VertComponentAttribute.Semantic` — What this component means, this is matched with the shader's vertex input semantics.
- `int VertComponentAttribute.SemanticSlot` — Distinguishes multiple components with the same semantic, like TEXCOORD0 vs TEXCOORD1. Usually 0.
- `void VertComponentAttribute(VertSemantic semantic, VertFmt format, int count, int semanticSlot)` — Describe the vertex component this field contains.
  - `semantic` — What this component means, this is matched with the shader's vertex input semantics.
  - `format` — The data format of a single element of this component.
  - `count` — How many format elements this component has, 1-4. A Vec3 position would be 3.
  - `semanticSlot` — Distinguishes multiple components with the same semantic, like TEXCOORD0 vs TEXCOORD1.

## struct Vertex

This represents a single vertex in a Mesh, all StereoKit Meshes currently use this exact layout! It's good to fill out all values of a Vertex explicitly, as default values for the normal (0,0,0) and color (0,0,0,0) will cause your mesh to appear completely black, or even transparent in most shaders!

- `Color32 Vertex.col` — The color of the vertex. If you aren't using it, set it to white.
- `Vec3 Vertex.norm` — The normal of this vertex, or the direction the vertex is facing. Preferably normalized.
- `Vec3 Vertex.pos` — Position of the vertex, in model space coordinates.
- `Vec2 Vertex.uv` — The texture coordinates at this vertex.
- `void Vertex(Vec3 position, Vec3 normal)` — Create a new Vertex, use the overloads to take advantage of default values. Vertex color defaults to White. UV defaults to (0,0).
  - `position` — Location of the Vertex, this is typically meters in Model space.
  - `normal` — The direction the Vertex is facing. Never leave this as zero, or your lighting may turn out black! A good default value if you _don't_ know what to put here is (0,1,0), but a Mesh composed entirely of this value will have flat lighting.
- `void Vertex(Vec3 position, Vec3 normal, Vec2 textureCoordinates)` — Create a new Vertex, use the overloads to take advantage of default values. Vertex color defaults to White.
  - `position` — Location of the Vertex, this is typically meters in Model space.
  - `normal` — The direction the Vertex is facing. Never leave this as zero, or your lighting may turn out black! A good default value if you _don't_ know what to put here is (0,1,0), but a Mesh composed entirely of this value will have flat lighting.
  - `textureCoordinates` — What part of a texture is this Vertex anchored to? (0,0) is top left of the texture, and (1,1) is the bottom right.
- `void Vertex(Vec3 position, Vec3 normal, Vec2 textureCoordinates, Color32 color)` — Create a new Vertex, use the overloads to take advantage of default values.
  - `position` — Location of the Vertex, this is typically meters in Model space.
  - `normal` — The direction the Vertex is facing. Never leave this as zero, or your lighting may turn out black! A good default value if you _don't_ know what to put here is (0,1,0), but a Mesh composed entirely of this value will have flat lighting.
  - `textureCoordinates` — What part of a texture is this Vertex anchored to? (0,0) is top left of the texture, and (1,1) is the bottom right.
  - `color` — The color of the Vertex, StereoKit's default shaders treat this as a multiplicative modifier for the Material's albedo/diffuse color, but different shaders sometimes treat this value differently. A good default here is white, black will cause your model to turn out completely black.

## enum VertFmt

The data format of a single element of a vertex component. Normalized formats map their integer range onto 0-1 (unsigned) or -1-1 (signed) when read by the GPU, other integer formats arrive as integers.

- `VertFmt.F16` — 16 bit half float.
- `VertFmt.F32` — 32 bit float.
- `VertFmt.I16` — 16 bit signed integer.
- `VertFmt.I16Normalized` — 16 bit signed integer, normalized to -1-1 on the GPU.
- `VertFmt.I32` — 32 bit signed integer.
- `VertFmt.I8` — 8 bit signed integer.
- `VertFmt.I8Normalized` — 8 bit signed integer, normalized to -1-1 on the GPU.
- `VertFmt.None` — Invalid format, this is not a valid value for a component.
- `VertFmt.U16` — 16 bit unsigned integer.
- `VertFmt.U16Normalized` — 16 bit unsigned integer, normalized to 0-1 on the GPU.
- `VertFmt.U32` — 32 bit unsigned integer.
- `VertFmt.U8` — 8 bit unsigned integer.
- `VertFmt.U8Normalized` — 8 bit unsigned integer, normalized to 0-1 on the GPU. A color32 is 4 of these.

## enum VertSemantic

What a vertex component means! This is matched against the semantics the shader's vertex inputs declare, so component order in a format doesn't need to match the shader's input order.

- `VertSemantic.Binormal` — Binormal/bitangent direction for normal mapping.
- `VertSemantic.Blendindices` — Bone indices for skinning.
- `VertSemantic.Blendweight` — Bone weights for skinning.
- `VertSemantic.Color` — Vertex color.
- `VertSemantic.None` — Invalid semantic, this is not a valid value for a component.
- `VertSemantic.Normal` — Direction the vertex is facing.
- `VertSemantic.Position` — Vertex position, in model space coordinates.
- `VertSemantic.Psize` — Point size for point rendering.
- `VertSemantic.Tangent` — Tangent direction for normal mapping.
- `VertSemantic.Texcoord` — Texture coordinates.

## static class World

World contains information about the real world around the user. This includes things like play boundaries, scene understanding, and other various things.

- `static Pose World.BoundsPose` — This is the orientation and center point of the system's boundary/guardian. This can be useful to find the floor height! Not all systems have a boundary, so be sure to check `World.HasBounds` first.
- `static Vec2 World.BoundsSize` — This is the size of a rectangle within the play boundary/guardian's space, in meters if one exists. Check `World.BoundsPose` for the center point and orientation of the boundary, and check `World.HasBounds` to see if it exists at all!
- `static bool World.HasBounds` — This refers to the play boundary, or guardian system that the system may have! Not all systems have this, so it's always a good idea to check this first!
- `static OcclusionCaps World.Occlusion` — Gets or sets the active occlusion methods using flags. Use `OcclusionCapabilities` to check what the current device supports.
- `static OcclusionCaps World.OcclusionCapabilities` — Reports which occlusion methods are available on the current device. For example, on Quest this may return `OcclusionCaps.Depth | OcclusionCaps.Hands`, and on HoloLens it may return `OcclusionCaps.Mesh`.
- `static bool World.OcclusionEnabled` — Off by default. This tells StereoKit to load up and display an occlusion surface that allows the real world to occlude the application's digital content! Most systems may allow you to customize the visual appearance of this occlusion surface via the World.OcclusionMaterial. Check SK.System.worldOcclusionPresent to see if occlusion can be enabled. This will reset itself to false if occlusion isn't possible. Loading occlusion data is asynchronous, so occlusion may not occur immediately after setting this flag.
- `static Material World.OcclusionMaterial` — By default, this is a black(0,0,0,0) opaque unlit material that will occlude geometry, but won't show up as visible anywhere. You can override this with whatever material you would like.
- `static OriginMode World.OriginMode` — The mode or "reference space" that StereoKit uses for determining its base origin. This is determined by the initial value provided in SKSettings.origin, as well as by support from the underlying runtime. The mode reported here will _not_ necessarily be the one requested in initialization, as fallbacks are implemented using different available modes.
- `static Pose World.OriginOffset` — This is relative to the base reference point and is NOT in world space! The origin StereoKit uses is actually a base reference point combined with an offset! You can use this to read or set the offset from the OriginMode reference point.
- `static bool World.RaycastEnabled` — Off by default. This tells StereoKit to load up collision meshes for the environment, for use with World.Raycast. Check SK.System.worldRaycastPresent to see if raycasting can be enabled. This will reset itself to false if raycasting isn't possible. Loading raycasting data is asynchronous, so collision surfaces may not be available immediately after setting this flag.
- `static float World.RefreshInterval` — The refresh interval speed, in seconds. This is only applicable when using `WorldRefresh.Timer` for the refresh type. Note that the system may not be able to refresh as fast as you wish, and in that case, StereoKit will always refresh as soon as the previous refresh finishes.
- `static float World.RefreshRadius` — Radius, in meters, of the area that StereoKit should scan for world data. Default is 4. When using the `WorldRefresh.Area` refresh type, the world data will refresh when the user has traveled half this radius from the center of where the most recent refresh occurred.
- `static WorldRefresh World.RefreshType` — What information should StereoKit use to determine when the next world data refresh happens? See the `WorldRefresh` enum for details.
- `static BtnState World.Tracked` — This reports the status of the device's positional tracking. If the room is too dark, or a hand is covering tracking sensors, or some other similar 6dof tracking failure, this would report as not tracked. Note that this does not factor in the status of rotational tracking. Rotation is typically done via gyroscopes/accelerometers, which don't really fail the same way positional tracking system can.
- `static Pose World.FromPerceptionAnchor(Object perceptionSpatialAnchor)` — Converts a Windows.Perception.Spatial.SpatialAnchor's pose into SteroKit's coordinate system. This can be great for interacting with some of the UWP spatial APIs such as WorldAnchors. This method only works on UWP platforms, check SK.System.perceptionBridgePresent to see if this is available.
  - `perceptionSpatialAnchor` — A valid Windows.Perception.Spatial.SpatialAnchor.
  - returns — A Pose representing the current orientation of the SpatialAnchor.
- `static bool World.FromPerceptionAnchor(Object perceptionSpatialAnchor, Pose& pose)` — Converts a Windows.Perception.Spatial.SpatialAnchor's pose into SteroKit's coordinate system. This can be great for interacting with some of the UWP spatial APIs such as WorldAnchors. This method only works on UWP platforms, check SK.System.perceptionBridgePresent to see if this is available.
  - `perceptionSpatialAnchor` — A valid Windows.Perception.Spatial.SpatialAnchor.
  - `pose` — A resulting Pose representing the current orientation of the spatial node.
  - returns — A Pose representing the current orientation of the SpatialAnchor.
- `static Pose World.FromSpatialNode(Guid spatialNodeGuid, SpatialNodeType spatialNodeType, Int64 qpcTime)` — Converts a Windows Mirage spatial node GUID into a Pose based on its current position and rotation! Check SK.System.spatialBridgePresent to see if this is available to use. Currently only on HoloLens, good for use with the Windows QR code package.
  - `spatialNodeGuid` — A Windows Mirage spatial node GUID acquired from a windows MR API call.
  - `spatialNodeType` — Type of spatial node to locate.
  - `qpcTime` — A windows performance counter timestamp at which the node should be located, obtained from another API or with System.Diagnostics.Stopwatch.GetTimestamp().
  - returns — A Pose representing the current orientation of the spatial node.
- `static bool World.FromSpatialNode(Guid spatialNodeGuid, Pose& pose, SpatialNodeType spatialNodeType, Int64 qpcTime)` — Converts a Windows Mirage spatial node GUID into a Pose based on its current position and rotation! Check SK.System.spatialBridgePresent to see if this is available to use. Currently only on HoloLens, good for use with the Windows QR code package.
  - `spatialNodeGuid` — A Windows Mirage spatial node GUID acquired from a windows MR API call.
  - `pose` — A resulting Pose representing the current orientation of the spatial node.
  - `spatialNodeType` — Type of spatial node to locate.
  - `qpcTime` — A windows performance counter timestamp at which the node should be located, obtained from another API or with System.Diagnostics.Stopwatch.GetTimestamp().
  - returns — True if FromSpatialNode succeeded, and false if it failed.
- `static bool World.Raycast(Ray ray, Ray& intersection)` — World.RaycastEnabled must be set to true first! SK.System.worldRaycastPresent must also be true. This does a ray intersection with whatever represents the environment at the moment! In this case, it's a watertight collection of low resolution meshes calculated by the Scene Understanding extension, which is only provided by the Microsoft HoloLens runtime.
  - `ray` — A world space ray that you'd like to try intersecting with the world mesh.
  - `intersection` — The location of the intersection, and direction of the world's surface at that point. This is only valid if the method returns true.
  - returns — True if an intersection is detected, false if raycasting is disabled, or there was no intersection.
  - Example: see `World.Raycast` in StereoKit-docs-reference.md

## enum WorldRefresh

A settings flag that lets you describe the behavior of how StereoKit will refresh data about the world mesh, if applicable. This is used with `World.RefreshType`.

- `WorldRefresh.Area` — Refreshing occurs when the user leaves the area that was most recently scanned. This area is a sphere that is 0.5 of the World.RefreshRadius.
- `WorldRefresh.Timer` — Refreshing happens at timer intervals. If an update doesn't happen in time, the next update will happen as soon as possible. The timer interval is configurable via `World.RefreshInterval`.

## static class Ease

Don't know which to use? Try SoftOut! It's a great default! This site is a great reference for how these functions look: https://easings.net/
- `static float Ease.FastIn(float t)` — Quartic soft start with a hard stop.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Quartic soft start with a hard stop.
- `static float Ease.FastInOut(float t)` — Quartic smooth start, fast middle, and smooth stop.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Quartic smooth start, fast middle, and smooth stop.
- `static float Ease.FastOut(float t)` — Quartic fast start with a soft stop, a pretty good default for most cases as it feels very responsive and looks good.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Quartic fast start with a soft stop.
- `static float Ease.Linear(float t)` — A constant motion the whole way through. Stops and starts hard, doesn't look all that great in most cases.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Returns unmodified input.
- `static float Ease.OvershootIn(float t)` — Soft start with a hard stop, overshoots its destination a bit before arriving at it.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Soft start with a hard stop, overshoots its destination a bit before arriving at it.
- `static float Ease.OvershootInOut(float t)` — Smooth start, fast middle, and smooth stop. Overshoots on both the start and the end.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Smooth start, fast middle, and smooth stop. Overshoots on both the start and the end.
- `static float Ease.OvershootOut(float t)` — Fast start with a soft stop, backs off a bit before moving to its destination.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Fast start with a soft stop, backs off a bit before moving to its destination.
- `static float Ease.SoftIn(float t)` — Quadratic soft start with a hard stop.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Quadratic soft start with a hard stop.
- `static float Ease.SoftInOut(float t)` — Quadratic smooth start, fast middle, and smooth stop.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Quadratic smooth start, fast middle, and smooth stop.
- `static float Ease.SoftOut(float t)` — Quadratic fast start with a soft stop, a very good default for most cases as it feels very responsive and looks good.
  - `t` — The easing percentage value, generally 0-1.
  - returns — Quadratic fast start with a soft stop.

## class EaseColor

A value that can ease from one state to another over time on its own. Useful for quick, juicy animations and effects!

- `bool EaseColor.IsFinished` — Is this easing value currently easing from one state to the next, or is it finished and static?
- `void EaseColor(Color initial)` — Create a new ease value that starts with an initial value. This object will not animate until AnimTo is called.
  - `initial` — The initial value for the object.
- `void EaseColor(float r, float g, float b, float a)` — Create a new ease value that starts with an initial value. This object will not animate until AnimTo is called.
  - `r` — Red component of a Color, in the range of 0-1.
  - `g` — Green component of a Color, in the range of 0-1.
  - `b` — Blue component of a Color, in the range of 0-1.
  - `a` — Alpha/transparency component of a Color, in the range of 0-1.
- `void EaseColor.AnimTo(Color destination, float duration, EaseFn easeFn)` — This sets up an easing animation for this value. It will now ease from its current state, to its destination state over a duration of time.
  - `destination` — This is the final state for the value when the easing animation has finished.
  - `duration` — The duration of the easing animation in seconds.
  - `easeFn` — An easing function the animation will follow. A good all-around default would be Ease.SoftOut. A number of easing functions can be found in the Ease class.
  - Example: see `EaseColor.AnimTo` in StereoKit-docs-reference.md
- `static Color EaseColor.Implicit Conversions(EaseColor value)` — An implicit "Resolve" of this easing type to its value.
  - `value` — The easing value.
  - returns — The eased value for the current time.
- `Color EaseColor.Resolve()` — This will resolve the easing animation to its current value based on the current StereoKit time, and the state of the easing animation. This value is not cached internally.
  - returns — The current easing value.
  - Example: see `EaseColor.Resolve` in StereoKit-docs-reference.md
- `void EaseColor.SetTo(Color value)` — Sets this to a specific value with no easing animation. This will cancel any in-progress animations, and jump straight to the provided value.
  - `value` — The new value that should be assigned right now without animation.

## delegate EaseFn

See the `Ease` class for a list of pre-made easing functions. An easing function that converts a value in the range of 0-1, to a different value mostly in the range of 0-1 with different properties.

## class EasePose

A value that can ease from one state to another over time on its own. Useful for quick, juicy animations and effects!

- `bool EasePose.IsFinished` — Is this easing value currently easing from one state to the next, or is it finished and static?
- `void EasePose(Pose initial)` — Create a new ease value that starts with an initial value. This object will not animate until AnimTo is called.
  - `initial` — The initial value for the object.
- `void EasePose(Vec3 pos, Quat rot)` — Create a new ease value that starts with an initial value. This object will not animate until AnimTo is called.
  - `pos` — Position of a Pose.
  - `rot` — Rotation of a Pose.
- `void EasePose.AnimTo(Pose destination, float duration, EaseFn easeFn)` — This sets up an easing animation for this value. It will now ease from its current state, to its destination state over a duration of time.
  - `destination` — This is the final state for the value when the easing animation has finished.
  - `duration` — The duration of the easing animation in seconds.
  - `easeFn` — An easing function the animation will follow. A good all-around default would be Ease.SoftOut. A number of easing functions can be found in the Ease class.
  - Example: see `EasePose.AnimTo` in StereoKit-docs-reference.md
- `static Pose EasePose.Implicit Conversions(EasePose value)` — An implicit "Resolve" of this easing type to its value.
  - `value` — The easing value.
  - returns — The eased value for the current time.
- `Pose EasePose.Resolve()` — This will resolve the easing animation to its current value based on the current StereoKit time, and the state of the easing animation. This value is not cached internally.
  - returns — The current easing value.
  - Example: see `EasePose.Resolve` in StereoKit-docs-reference.md
- `void EasePose.SetTo(Pose value)` — Sets this to a specific value with no easing animation. This will cancel any in-progress animations, and jump straight to the provided value.
  - `value` — The new value that should be assigned right now without animation.

## class EaseVec3

A value that can ease from one state to another over time on its own. Useful for quick, juicy animations and effects!

- `bool EaseVec3.IsFinished` — Is this easing value currently easing from one state to the next, or is it finished and static?
- `void EaseVec3(Vec3 initial)` — Create a new ease value that starts with an initial value. This object will not animate until AnimTo is called.
  - `initial` — The initial value for the object.
- `void EaseVec3(float x, float y, float z)` — Create a new ease value that starts with an initial value. This object will not animate until AnimTo is called.
  - `x` — X component of a Vec3
  - `y` — Y component of a Vec3
  - `z` — Z component of a Vec3
- `void EaseVec3.AnimTo(Vec3 destination, float duration, EaseFn easeFn)` — This sets up an easing animation for this value. It will now ease from its current state, to its destination state over a duration of time.
  - `destination` — This is the final state for the value when the easing animation has finished.
  - `duration` — The duration of the easing animation in seconds.
  - `easeFn` — An easing function the animation will follow. A good all-around default would be Ease.SoftOut. A number of easing functions can be found in the Ease class.
- `void EaseVec3.AnimTo(float x, float y, float z, float duration, EaseFn easeFn)` — This sets up an easing animation for this value. It will now ease from its current state, to its destination state over a duration of time.
  - `x` — X component of a Vec3
  - `y` — Y component of a Vec3
  - `z` — Z component of a Vec3
  - Example: see `EaseVec3.AnimTo` in StereoKit-docs-reference.md
- `static Vec3 EaseVec3.Implicit Conversions(EaseVec3 value)` — An implicit "Resolve" of this easing type to its value.
  - `value` — The easing value.
  - returns — The eased value for the current time.
- `Vec3 EaseVec3.Resolve()` — This will resolve the easing animation to its current value based on the current StereoKit time, and the state of the easing animation. This value is not cached internally.
  - returns — The current easing value.
  - Example: see `EaseVec3.Resolve` in StereoKit-docs-reference.md
- `void EaseVec3.SetTo(Vec3 value)` — Sets this to a specific value with no easing animation. This will cancel any in-progress animations, and jump straight to the provided value.
  - `value` — The new value that should be assigned right now without animation.

## enum HandMenuAction

This enum specifies how HandMenuItems should behave when selected! This is in addition to the HandMenuItem's callback function.

- `HandMenuAction.Back` — Go back to the previous layer.
- `HandMenuAction.Close` — Close the hand menu entirely! We're finished here.
- `HandMenuAction.Layer` — Move to another menu layer.

## class HandMenuItem

This is a collection of display and behavior information for a single item on the hand menu.

- `HandMenuAction HandMenuItem.action` — Describes the menu related behavior of this menu item, should it close the menu? Open another layer? Go back to the previous menu?
- `Action HandMenuItem.callback` — The callback that should be performed when this menu item is selected.
- `Sprite HandMenuItem.image` — Display image of the item, null is fine!
- `string HandMenuItem.layerName` — If the action is set to Layer, then this is the layer name used to find the next layer for the menu!
- `string HandMenuItem.name` — Display name of the item.
- `void HandMenuItem(string name, Sprite image, Action callback, string layerName)` — A menu item that'll load another layer when selected.
  - `name` — Display name of the item.
  - `image` — Display image of the item, null is fine!
  - `callback` — The callback that should be performed when this menu item is selected.
  - `layerName` — This is the layer name used to find the next layer for the menu! Get the spelling right, try using const strings!
- `void HandMenuItem(string name, Sprite image, Action callback, HandMenuAction action)` — Makes a menu item!
  - `name` — Display name of the item.
  - `image` — Display image of the item, null is fine!
  - `callback` — The callback that should be performed when this menu item is selected.
  - `action` — Describes the menu related behavior of this menu item, should it close the menu? Open another layer? Go back to the previous menu?
- `void HandMenuItem.Draw(Vec3 at, float arcLength, float angle, bool focused)` — This draws the menu item on the radial menu!
  - `at` — Center of the radial slice
  - `arcLength` — Length of the arc at the midpoint of the radial slice.
  - `angle` — Angle of the centerpoint of the slice this is rendered on.
  - `focused` — If the current menu slice has focus.

## class HandMenuRadial

A menu that shows up in circle around the user's hand! Selecting an item can perform an action, or even spawn a sub-layer of menu items. This is an easy way to store actions out of the way, yet remain easily accessible to the user. The user faces their palm towards their head, and then makes a grip motion to spawn the menu. The user can then perform actions by making fast, direction based motions that are easy to build muscle memory for.

- `bool HandMenuRadial.Enabled` — HandMenuRadial is always Enabled.
- `HandRadialLayer HandMenuRadial.RootLayer` — This returns the root menu layer, this is always the first layer added to the list of layers. There should always be a root layer, and if the HandMenuRadial is created without any layers, a root layer will be added automatically.
- `static Key HandMenuRadial.simulatorKey` — When using the Simulator, this key will activate the menu on the current hand, regardless of which direction it is facing.
- `void HandMenuRadial(HandRadialLayer[] menuLayers)` — Creates a hand menu from the provided array of menu layers! HandMenuRadial is an IStepper, so proper usage is to add it to the Stepper list via `StereoKitApp.AddStepper`. If no layers are provided to this constructor, a default root layer will be automatically added.
  - `menuLayers` — Starting layer is always the first one in the list! Layer names in the menu items refer to layer names in this list.
- `void HandMenuRadial.Close()` — Closes the menu if it's open! Plays a closing sound.
- `bool HandMenuRadial.Initialize()` — Part of IStepper, you shouldn't be calling this yourself.
  - returns — Always returns true.
- `void HandMenuRadial.Show(Vec3 at, Handed hand)` — Force the hand menu to show at a specific location. This will close the hand menu if it was already open, and resets it to the root menu layer. Also plays an opening sound.
  - `at` — A world space position for the hand menu.
- `void HandMenuRadial.Shutdown()` — Part of IStepper, you shouldn't be calling this yourself.
- `void HandMenuRadial.Step()` — Part of IStepper, you shouldn't be calling this yourself.

## class HandRadialLayer

This class represents a single layer in the HandRadialMenu. Each item in the layer is displayed around the radial menu's circle.

- `float HandRadialLayer.backAngle` — What's the angle pointing towards the back button on this menu? If there is a back button. This is used to orient the back button towards the direction the finger just came from.
- `HandMenuItem[] HandRadialLayer.items` — A list of menu items to display in this menu layer.
- `string HandRadialLayer.layerName` — Name of the layer, this is used for layer traversal, so make sure you get the spelling right! Perhaps use const strings for these.
- `HandRadialLayer HandRadialLayer.Parent` — The layer above this layer, will be null if this is the root layer.
- `float HandRadialLayer.startAngle` — An angle offset for the layer, if you want a specific orientation for the menu's contents. Note this may not behave as expected if you're setting this manually and using the backAngle as well.
- `void HandRadialLayer(string name, HandMenuItem[] items)` — Creates a menu layer, this overload will calculate a backAngle if there are any back actions present in the item list.
  - `name` — Name of the layer, this is used for layer traversal, so make sure you get the spelling right! Perhaps use const strings for these.
  - `items` — A list of menu items to display in this menu layer.
- `void HandRadialLayer(string name, Sprite image, HandMenuItem[] items)` — Creates a menu layer, this overload will calculate a backAngle if there are any back actions present in the item list.
  - `name` — Name of the layer, this is used for layer traversal, so make sure you get the spelling right! Perhaps use const strings for these.
  - `items` — A list of menu items to display in this menu layer.
- `void HandRadialLayer(string name, float startAngle, HandMenuItem[] items)` — Creates a menu layer with an angle offset for the layer's rotation!
  - `name` — Name of the layer, this is used for layer traversal, so make sure you get the spelling right! Perhaps use const strings for these.
  - `startAngle` — An angle offset for the layer, if you want a specific orientation for the menu's contents. Note this may not behave as expected if you're setting this manually and using the backAngle as well.
  - `items` — A list of menu items to display in this menu layer.
- `void HandRadialLayer(string name, Sprite image, float startAngle, HandMenuItem[] items)` — Creates a menu layer with an angle offset for the layer's rotation!
  - `name` — Name of the layer, this is used for layer traversal, so make sure you get the spelling right! Perhaps use const strings for these.
  - `startAngle` — An angle offset for the layer, if you want a specific orientation for the menu's contents. Note this may not behave as expected if you're setting this manually and using the backAngle as well.
  - `items` — A list of menu items to display in this menu layer.
- `void HandRadialLayer.AddChild(HandRadialLayer layer)` — This adds a menu layer as a child item of this layer.
  - `layer` — Any HandRadialLayer or derivative.
- `void HandRadialLayer.AddItem(HandMenuItem item)` — This appends a new menu item to the end of the menu's list.
  - `item` — Any HandMenuItem or derivative.
- `HandRadialLayer HandRadialLayer.FindChild(string name)` — Find a child menu layer by name.
  - `name` — The exact name of the layer.
  - returns — The layer with the matching name, or null.
- `HandMenuItem HandRadialLayer.FindItem(string name)` — Find a menu item by name.
  - `name` — The exact name of the item.
  - returns — The item with the matching name, or null.
- `void HandRadialLayer.RemoveChild(HandRadialLayer layer)` — Finds the layer in the list of child layers, and removes it, if it exists.
  - `layer` — The exact layer in the layer list.
- `void HandRadialLayer.RemoveItem(HandMenuItem item)` — Finds the item in the list, and removes it, if it exists.
  - `item` — The exact item in the layer list.

## interface IStepper

This is a lightweight standard interface for fire-and-forget systems that can be attached to StereoKit! This is particularly handy for extensions/plugins that need to run in the background of your application, or even for managing some of your own simpler systems. `IStepper`s can be added before or after the call to `SK.Initialize`, and this does affect when the `IStepper.Initialize` call will be made! `IStepper.Initialize` is always called _after_ `SK.Initialize`. This can be important to note when writing code that uses SK functions that are dependant on initialization, you'll want to avoid putting this code in the constructor, and add them to `Initialize` instead. `IStepper`s also pay attention to threading! `Initialize` and `Step` always happen on the main thread, even if the constructor is called on a different one.

- `bool IStepper.Enabled` — Is this IStepper enabled? When false, StereoKit will not call Step. This can be a good way to temporarily disable the IStepper without removing or shutting it down.
- `bool IStepper.Initialize()` — This is called by StereoKit at the start of the next frame, and on the main thread. This happens before StereoKit's main `Step` callback, and always after `SK.Initialize`.
  - returns — If false is returned here, this `IStepper` will be immediately removed from the list of `IStepper`s, and neither `Step` nor `Shutdown` will be called.
- `void IStepper.Shutdown()` — This is called when the `IStepper` is removed, or the application shuts down. This is always called on the main thread, and happens at the start of the next frame, before the main application's `Step` callback.
- `void IStepper.Step()` — This Step method will be called every frame of the application, as long as `Enabled` is `true`. By default this happens immediately before the main application's `Step` callback, but this can be configured by adding a `[StepperPriority]` attribute to the `IStepper` type: a positive priority steps _after_ the app's `Step` callback, and `IStepper`s are sorted in ascending order of priority.

## class StepperPriorityAttribute

An optional `[StepperPriority]` attribute for `IStepper` types that controls when and in what order their `Step` method is called relative to the app's main `Step` callback. The priority value determines both the _phase_ and the _sort order_: `IStepper`s with a negative priority (or the default of 0) are stepped _before_ the app's main `Step` callback, and `IStepper`s with a positive priority are stepped _after_ it. In all cases, `IStepper`s are stepped in ascending order of priority, and ties preserve the order they were added in. If an `IStepper` type does not have this attribute, it behaves as though it has a priority of 0.

- `int StepperPriorityAttribute.Priority` — The priority value for this `IStepper`. Negative or zero values step before the app's main `Step` callback, positive values step after it, and all `IStepper`s are sorted in ascending order by this value.
- `void StepperPriorityAttribute(int priority)` — Creates a priority attribute for an `IStepper` type.
  - `priority` — The priority value. Negative or zero values step before the app's main `Step` callback, positive values step after it, and all `IStepper`s are sorted in ascending order by this value.
