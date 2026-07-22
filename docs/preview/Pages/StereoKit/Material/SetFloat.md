---
layout: default
title: Material.SetFloat
description: Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!
---
# [Material]({{site.url}}/preview/Pages/StereoKit/Material.html).SetFloat

<div class='signature' markdown='1'>
```csharp
void SetFloat(string name, float value)
```
Sets a shader parameter with the given name to the
provided value. If no parameter is found, nothing happens, and
the value is not set!
</div>

|  |  |
|--|--|
|string name|Name of the shader parameter.|
|float value|New value for the parameter.|





## Examples

### Specialization constants
If a shader declares specialization constants with HLSL's
`[[vk::constant_id(N)]]`, StereoKit exposes them through the ordinary
scalar setters. The name you pass must match the HLSL variable name.

```hlsl
[[vk::constant_id(0)]] const int   COLOR_STEPS = 2;
[[vk::constant_id(1)]] const float BRIGHTNESS  = 0.25;
[[vk::constant_id(2)]] const bool  USE_TINT    = true;
[[vk::constant_id(3)]] const uint  BLUE_SCALE  = 4;
```

Unlike a normal material parameter, a spec constant is baked into the
shader pipeline. Setting one to a new value rebuilds that pipeline (a
heavier operation than a uniform write), so prefer setting them at
load time rather than every frame. Re-setting the same value is free.
Two materials sharing one shader with different spec-constant values are
distinct pipeline variants — handy for feature toggles or loop/array
sizes the driver can then fold at compile time.
```csharp
Material variantA;
Material variantB;
public void Initialize()
{
	Shader shader = Shader.FromFile("spec_constant_test.hlsl");

	variantA = new Material(shader); // uses the HLSL defaults

	variantB = new Material(shader);
	variantB.SetInt  ("COLOR_STEPS", 4);
	variantB.SetFloat("BRIGHTNESS",  0.6f);
	variantB.SetBool ("USE_TINT",    false);
	variantB.SetUInt ("BLUE_SCALE",  12);
}
```

