---
layout: default
title: Backend.Vulkan
description: When using Vulkan for rendering, this contains a number of variables that may be useful for doing advanced rendering tasks. Vulkan is StereoKit's only rendering backend, so these are valid on all supported platforms after SK.Initialize.
---
# static class Backend.Vulkan

When using Vulkan for rendering, this contains a number
of variables that may be useful for doing advanced rendering
tasks. Vulkan is StereoKit's only rendering backend, so these are
valid on all supported platforms after SK.Initialize.

## Static Fields and Properties

|  |  |
|--|--|
|IntPtr [Device]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Device.html)|The `VkDevice` StereoKit created (or was given, when running under OpenXR) for rendering. Valid after SK.Initialize.|
|IntPtr [Instance]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Instance.html)|The `VkInstance` StereoKit created (or was given, when running under OpenXR) for rendering. Valid after SK.Initialize.|
|IntPtr [PhysicalDevice]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/PhysicalDevice.html)|The `VkPhysicalDevice` StereoKit is rendering with. Valid after SK.Initialize.|

## Static Methods

|  |  |
|--|--|
|[ExtEnabled]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/ExtEnabled.html)|Checks if a Vulkan extension was enabled at init, regardless of which request asked for it. This MUST only be called after SK.Initialize.|
|[GetFrameFenceFd]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/GetFrameFenceFd.html)|Returns a sync file descriptor for the most recently submitted frame's GPU work! Waiting on it (e.g. via EGL_ANDROID_native_fence_sync) guarantees all rendering submitted up to the last frame end has completed. Call from StereoKit's main thread. The caller owns the descriptor and must close it. Only functional on platforms and devices supporting external fence export.|
|[GetFunction]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/GetFunction.html)|Resolves a Vulkan function pointer and wraps it as a delegate, using `vkGetDeviceProcAddr` with a `vkGetInstanceProcAddr` fallback. Use this to call into extensions you've enabled via [`Backend.Vulkan.Request`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html).|
|[GetFunctionPtr]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/GetFunctionPtr.html)|Resolves a Vulkan function pointer, using `vkGetDeviceProcAddr` with a `vkGetInstanceProcAddr` fallback. Use this to call into extensions you've enabled via [`Backend.Vulkan.Request`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html). You can use `Marshal.GetDelegateForFunctionPointer` to turn the result into a callable delegate.|
|[Queue]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Queue.html)|Gets the `VkQueue` StereoKit uses for the given queue family. Currently only [`BackendVulkanQueue.Graphics`]({{site.url}}/preview/Pages/StereoKit/BackendVulkanQueue/Graphics.html) has a handle available; the others return IntPtr.Zero until StereoKit makes real use of them. If you submit work to this queue, you MUST guard it with [`Backend.Vulkan.QueueLock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueLock.html) / [`Backend.Vulkan.QueueUnlock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html), since StereoKit shares it across threads.|
|[QueueFamilyIndex]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueFamilyIndex.html)|Gets the queue family index StereoKit uses for the given queue family. This is the value you'd use when creating command pools or performing queue family ownership transfers.|
|[QueueLock]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueLock.html)|Locks the mutex StereoKit uses to guard the given queue family, so you can safely submit work to a queue StereoKit also uses. Always pair this with [`Backend.Vulkan.QueueUnlock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html). Note that queue families that resolve to the same index share a single lock, so don't nest locks across two families that may alias.|
|[QueueUnlock]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueUnlock.html)|Releases the queue family lock acquired via [`Backend.Vulkan.QueueLock`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/QueueLock.html).|
|[Request]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html)|Registers a request for Vulkan instance/device extensions and device features. This MUST be called before SK.Initialize. A request enables atomically: only when all of its extensions are present, and every requested feature bit is supported. If [`BackendVulkanRequest.required`]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest/required.html) is true and the request can't be satisfied, SK.Initialize will fail! After initialization, check the result with [`Backend.Vulkan.RequestEnabled`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/RequestEnabled.html) (by name) or [`Backend.Vulkan.ExtEnabled`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/ExtEnabled.html) (by extension name).|
|[RequestEnabled]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/RequestEnabled.html)|Checks if a named request registered via [`Backend.Vulkan.Request`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html) was successfully enabled. This MUST only be called after SK.Initialize.|

## Examples

### Requesting Vulkan Extensions

StereoKit renders with Vulkan, and `Backend.Vulkan` lets you opt into extra
Vulkan instance/device extensions and device features that StereoKit
wouldn't normally request. Register a `BackendVulkanRequest` _before_
`SK.Initialize`, then after initialization check whether it enabled and
resolve any functions it provides.

A good practical use is `VK_EXT_debug_utils`, which lets you attach
human-readable names to Vulkan objects so they show up nicely in tools like
RenderDoc or the validation layers. Here we request the (instance)
extension, then use it to name the `VkDevice` StereoKit is rendering with.
This is implemented via an `IStepper`, so it must be added before
`SK.Initialize`.
```csharp
class VulkanDebugNamesExt : IStepper
{
	const string debugUtilsExt = "VK_EXT_debug_utils";

	// A C# equivalent of vkSetDebugUtilsObjectNameEXT and the struct it takes.
	[StructLayout(LayoutKind.Sequential)]
	struct VkDebugUtilsObjectNameInfoEXT
	{
		public int    sType;
		public IntPtr pNext;
		public int    objectType;
		public ulong  objectHandle;
		[MarshalAs(UnmanagedType.LPUTF8Str)] public string pObjectName;
	}
	delegate int VkSetDebugUtilsObjectNameEXT(IntPtr device, in VkDebugUtilsObjectNameInfoEXT nameInfo);
	static        VkSetDebugUtilsObjectNameEXT vkSetDebugUtilsObjectNameEXT;

	public bool Enabled { get; private set; }

	public VulkanDebugNamesExt()
	{
		// Vulkan requests must happen before StereoKit initializes, so this
		// IStepper needs to be added _before_ `SK.Initialize`.
		if (SK.IsInitialized)
			Log.Err("Vulkan extensions must be requested before StereoKit is initialized!");

		// debug_utils is an _instance_ extension. A named request lets us query
		// it later, and leaving `required` false means SK still starts up if
		// the extension isn't available.
		Backend.Vulkan.Request(new BackendVulkanRequest {
			name               = "debug_utils",
			required           = false,
			instanceExtensions = new string[] { debugUtilsExt },
		});
	}

	public bool Initialize()
	{
		// Confirm we're on Vulkan, the extension enabled, and our function
		// bound. RequestEnabled("debug_utils") would also work here.
		Enabled =
			Backend.Graphics == BackendGraphics.Vulkan &&
			Backend.Vulkan.ExtEnabled(debugUtilsExt)   &&
			LoadBindings();

		if (Enabled)
		{
			// Give the VkDevice a friendly name for debugging tools.
			VkDebugUtilsObjectNameInfoEXT info = new VkDebugUtilsObjectNameInfoEXT {
				sType        = 1000128000, // VK_STRUCTURE_TYPE_DEBUG_UTILS_OBJECT_NAME_INFO_EXT
				objectType   = 3,          // VK_OBJECT_TYPE_DEVICE
				objectHandle = (ulong)Backend.Vulkan.Device,
				pObjectName  = "StereoKit Device",
			};
			vkSetDebugUtilsObjectNameEXT(Backend.Vulkan.Device, info);
		}
		return Enabled;
	}

	private bool LoadBindings()
	{
		vkSetDebugUtilsObjectNameEXT = Backend.Vulkan.GetFunction<VkSetDebugUtilsObjectNameEXT>("vkSetDebugUtilsObjectNameEXT");
		return vkSetDebugUtilsObjectNameEXT != null;
	}

	public void Shutdown() { }
	public void Step() { }
}
```

