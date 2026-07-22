---
layout: default
title: Renderer.Screenshot
description: Schedules a screenshot for the end of the frame! The view will be rendered from the given position at the given point, with a resolution the same size as the screen's surface. It'll be saved as a JPEG or PNG file depending on the filename extension provided.
---
# [Renderer]({{site.url}}/preview/Pages/StereoKit/Renderer.html).Screenshot

<div class='signature' markdown='1'>
```csharp
static void Screenshot(string filename, Vec3 from, Vec3 at, int width, int height, float fieldOfViewDegrees)
```
Schedules a screenshot for the end of the frame! The view
will be rendered from the given position at the given point, with a
resolution the same size as the screen's surface. It'll be saved as
a JPEG or PNG file depending on the filename extension provided.
</div>

|  |  |
|--|--|
|string filename|Filename to write the screenshot to! This will be a PNG if the extension ends with (case insensitive) ".png", and will be a 90 quality JPEG if it ends with anything else.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) from|Viewpoint location.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) at|Direction the viewpoint is looking at.|
|int width|Size of the screenshot horizontally, in pixels.|
|int height|Size of the screenshot vertically, in pixels.|
|float fieldOfViewDegrees|The angle of the viewport, in degrees.|

<div class='signature' markdown='1'>
```csharp
static void Screenshot(string filename, int fileQuality, Pose viewpoint, int width, int height, float fieldOfViewDegrees)
```
Schedules a screenshot for the end of the frame! The view
will be rendered from the given pose, with a resolution the same
size as the screen's surface. It'll be saved as a JPEG or PNG file
depending on the filename extension provided.
</div>

|  |  |
|--|--|
|string filename|Filename to write the screenshot to! This will be a PNG if the extension ends with (case insensitive) ".png", and will be a JPEG if it ends with anything else.|
|int fileQuality|For JPEG files, this is the compression quality of the file from 0-100, 100 being highest quality, 0 being smallest size. SK uses a default of 90 here.|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) viewpoint|Viewpoint location and orientation.|
|int width|Size of the screenshot horizontally, in pixels.|
|int height|Size of the screenshot vertically, in pixels.|
|float fieldOfViewDegrees|The angle of the viewport, in degrees.|

<div class='signature' markdown='1'>
```csharp
static void Screenshot(string filename, Pose viewpoint, int width, int height, float fieldOfViewDegrees)
```
Schedules a screenshot for the end of the frame! The view
will be rendered from the given pose, with a resolution the same
size as the screen's surface. It'll be saved as a JPEG or PNG file
depending on the filename extension provided.
</div>

|  |  |
|--|--|
|string filename|Filename to write the screenshot to! This will be a PNG if the extension ends with (case insensitive) ".png", and will be a 90 quality JPEG if it ends with anything else.|
|[Pose]({{site.url}}/preview/Pages/StereoKit/Pose.html) viewpoint|Viewpoint location and orientation.|
|int width|Size of the screenshot horizontally, in pixels.|
|int height|Size of the screenshot vertically, in pixels.|
|float fieldOfViewDegrees|The angle of the viewport, in degrees.|

<div class='signature' markdown='1'>
```csharp
static void Screenshot(ScreenshotCallback onScreenshot, Vec3 from, Vec3 at, int width, int height, float fieldOfViewDegrees, TexFormat texFormat)
```
Schedules a screenshot for the end of the frame! The view
will be rendered from the given position at the given point, with a
resolution the same size as the screen's surface. This overload
allows for retrieval of the color data directly from the render
thread! You can use the color data directly by saving/processing it
inside your callback, or you can keep the data alive for as long as
it is referenced.
</div>

|  |  |
|--|--|
|[ScreenshotCallback]({{site.url}}/preview/Pages/StereoKit/ScreenshotCallback.html) onScreenshot|A callback that receives the captured pixel data, its format, and its dimensions for the requested viewpoint.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) from|Viewpoint location.|
|[Vec3]({{site.url}}/preview/Pages/StereoKit/Vec3.html) at|Direction the viewpoint is looking at.|
|int width|Size of the screenshot horizontally, in pixels.|
|int height|Size of the screenshot vertically, in pixels.|
|float fieldOfViewDegrees|The angle of the viewport, in degrees.|
|[TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html) texFormat|The pixel format of the color data.|

<div class='signature' markdown='1'>
```csharp
static void Screenshot(ScreenshotCallback onScreenshot, Matrix camera, Matrix projection, int width, int height, RenderLayer layerFilter, RenderClear clear, Rect viewport, TexFormat texFormat)
```
Schedules a screenshot for the end of the frame! The view
will be rendered from the given position at the given point, with a
resolution the same size as the screen's surface. This overload
allows for retrieval of the color data directly from the render
thread! You can use the color data directly by saving/processing it
inside your callback, or you can keep the data alive for as long as
it is referenced.
</div>

|  |  |
|--|--|
|[ScreenshotCallback]({{site.url}}/preview/Pages/StereoKit/ScreenshotCallback.html) onScreenshot|A callback that receives the captured pixel data, its format, and its dimensions for the requested viewpoint.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) camera|A TRS matrix representing the location and orientation of the camera. This matrix gets inverted later on, so no need to do it yourself.|
|[Matrix]({{site.url}}/preview/Pages/StereoKit/Matrix.html) projection|The projection matrix describes how the geometry is flattened onto the draw surface. Normally, you'd use Matrix.Perspective, and occasionally Matrix.Orthographic might be helpful as well.|
|[RenderLayer]({{site.url}}/preview/Pages/StereoKit/RenderLayer.html) layerFilter|This is a bit flag that allows you to change which layers StereoKit renders for this particular render viewpoint. To change what layers a visual is on, use a Draw method that includes a RenderLayer as a parameter.|
|[RenderClear]({{site.url}}/preview/Pages/StereoKit/RenderClear.html) clear|Describes if and how the rendertarget should be cleared before rendering. Note that clearing the target is unaffected by the viewport, so this will clean the entire surface!|
|[TexFormat]({{site.url}}/preview/Pages/StereoKit/TexFormat.html) texFormat|The pixel format of the color data.|




