---
layout: default
title: BackendVulkanRequest
description: A request for Vulkan instance/device extensions and device features, registered via Backend.Vulkan.Request before SK.Initialize.
---
# struct BackendVulkanRequest

A request for Vulkan instance/device extensions and device
features, registered via [`Backend.Vulkan.Request`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/Request.html) before
SK.Initialize.

## Instance Fields and Properties

|  |  |
|--|--|
|String[] [deviceExtensions]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest/deviceExtensions.html)|Vulkan device extension names this request needs.|
|BackendVulkanFeature[] [features]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest/features.html)|Vulkan device features this request needs. Their bits are queried for support before being enabled.|
|String[] [instanceExtensions]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest/instanceExtensions.html)|Vulkan instance extension names this request needs.|
|string [name]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest/name.html)|An optional name used as a handle for [`Backend.Vulkan.RequestEnabled`]({{site.url}}/preview/Pages/StereoKit/Backend.Vulkan/RequestEnabled.html). null makes the request anonymous - it still contributes its extensions and features, but can't be queried by name.|
|bool [required]({{site.url}}/preview/Pages/StereoKit/BackendVulkanRequest/required.html)|If true, SK.Initialize will fail should this request go unsatisfied. If false, an unmet request is simply left disabled.|

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

