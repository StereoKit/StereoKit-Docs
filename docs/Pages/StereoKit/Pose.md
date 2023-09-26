---
layout: default
title: Pose
description: Pose represents a location and orientation in space, excluding scale! CAUTION. the default value of a Pose includes a completely zero Quat, which can cause problems. Use Pose.Identity instead of new Pose() for creating a default pose.
---
# struct Pose

Pose represents a location and orientation in space,
excluding scale! CAUTION: the default value of a Pose includes a
completely zero Quat, which can cause problems. Use `Pose.Identity`
instead of `new Pose()` for creating a default pose.

## Instance Fields and Properties

|  |  |
|--|--|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [Forward]({{site.url}}/Pages/StereoKit/Pose/Forward.html)|Calculates the forward direction from this pose. This is done by multiplying the orientation with Vec3.Forward. Remember that Forward points down the -Z axis!|
|[Quat]({{site.url}}/Pages/StereoKit/Quat.html) [orientation]({{site.url}}/Pages/StereoKit/Pose/orientation.html)|Orientation of the pose, stored as a rotation from Vec3.Forward.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [position]({{site.url}}/Pages/StereoKit/Pose/position.html)|Location of the pose.|
|[Ray]({{site.url}}/Pages/StereoKit/Ray.html) [Ray]({{site.url}}/Pages/StereoKit/Pose/Ray.html)|This creates a ray starting at the Pose's position, and pointing in the 'Forward' direction. The Ray direction is a unit vector/normalized.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [Right]({{site.url}}/Pages/StereoKit/Pose/Right.html)|Calculates the right (+X) direction from this pose. This is done by multiplying the orientation with Vec3.Right.|
|[Vec3]({{site.url}}/Pages/StereoKit/Vec3.html) [Up]({{site.url}}/Pages/StereoKit/Pose/Up.html)|Calculates the up (+Y) direction from this pose. This is done by multiplying the orientation with Vec3.Up.|

## Instance Methods

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose/Pose.html)|Basic initialization constructor! Just copies in the provided values directly.|
|[ToMatrix]({{site.url}}/Pages/StereoKit/Pose/ToMatrix.html)|Converts this pose into a transform matrix, incorporating a provided scale value.|
|[ToString]({{site.url}}/Pages/StereoKit/Pose/ToString.html)|A string representation of the Pose, in the format of "position, Forward". Mostly for debug visualization.|

## Static Fields and Properties

|  |  |
|--|--|
|[Pose]({{site.url}}/Pages/StereoKit/Pose.html) [Identity]({{site.url}}/Pages/StereoKit/Pose/Identity.html)|A default, empty pose. Positioned at zero, and using Quat.Identity for orientation.|

## Static Methods

|  |  |
|--|--|
|[Lerp]({{site.url}}/Pages/StereoKit/Pose/Lerp.html)|Interpolates between two poses! It is unclamped, so values outside of (0,1) will extrapolate their position.|
|[LookAt]({{site.url}}/Pages/StereoKit/Pose/LookAt.html)|Creates a Pose that looks from one location in the direction of another location. This leaves "Up" as the +Y axis.|
