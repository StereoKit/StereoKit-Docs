---
layout: default
title: Material
description: A Material describes the surface of anything drawn on the graphics card! It is typically composed of a Shader, and shader properties like colors, textures, transparency info, etc.  Items drawn with the same Material can be batched together into a single, fast operation on the graphics card, so re-using materials can be extremely beneficial for performance!
---
# class Material

A Material describes the surface of anything drawn on the
graphics card! It is typically composed of a Shader, and shader
properties like colors, textures, transparency info, etc.

Items drawn with the same Material can be batched together into a
single, fast operation on the graphics card, so re-using materials
can be extremely beneficial for performance!

## Instance Fields and Properties

|  |  |
|--|--|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [Chain]({{site.url}}/Pages/StereoKit/Material/Chain.html)|Allows you to chain Materials together in a form of multi-pass rendering! Any time the Material is used, the chained Materials will also be used to draw the same item.|
|[DepthTest]({{site.url}}/Pages/StereoKit/DepthTest.html) [DepthTest]({{site.url}}/Pages/StereoKit/Material/DepthTest.html)|How does this material interact with the ZBuffer? Generally DepthTest.Less would be normal behavior: don't draw objects that are occluded. But this can also be used to achieve some interesting effects, like you could use DepthTest.Greater to draw a glow that indicates an object is behind something.|
|bool [DepthWrite]({{site.url}}/Pages/StereoKit/Material/DepthWrite.html)|Should this material write to the ZBuffer? For opaque objects, this generally should be true. But transparent objects writing to the ZBuffer can be problematic and cause draw order issues. Note that turning this off can mean that this material won't get properly accounted for when the MR system is performing late stage reprojection.  Not writing to the buffer can also be faster! :)|
|[Cull]({{site.url}}/Pages/StereoKit/Cull.html) [FaceCull]({{site.url}}/Pages/StereoKit/Material/FaceCull.html)|How should this material cull faces?|
|string [Id]({{site.url}}/Pages/StereoKit/Material/Id.html)|Gets or sets the unique identifier of this asset resource! This can be helpful for debugging, managing your assets, or finding them later on!|
|int [ParamCount]({{site.url}}/Pages/StereoKit/Material/ParamCount.html)|The number of shader parameters available to this material, includes global shader variables as well as textures.|
|int [QueueOffset]({{site.url}}/Pages/StereoKit/Material/QueueOffset.html)|This property will force this material to draw earlier or later in the draw queue. Positive values make it draw later, negative makes it earlier. This is really helpful when doing tricks with the depth buffer, or are working with transparent objects. Good offset values should probably be specific, well managed, and small. Think of it as a layer rather than a distance, so probably less than 10, and definitely less than 1000.  This can also be helpful for tweaking performance! If you know an object is always going to be close to the user and likely to obscure lots of objects (like hands), drawing it earlier can mean objects behind it get discarded much faster! Similarly, objects that are far away (skybox!) can be pushed towards the back of the queue, so they're more likely to be discarded early.|
|[Shader]({{site.url}}/Pages/StereoKit/Shader.html) [Shader]({{site.url}}/Pages/StereoKit/Material/Shader.html)|Gets a link to the Shader that the Material is currently using, or overrides the Shader this material uses.|
|[Transparency]({{site.url}}/Pages/StereoKit/Transparency.html) [Transparency]({{site.url}}/Pages/StereoKit/Material/Transparency.html)|What type of transparency does this Material use? Default is None. Transparency has an impact on performance, and draw order. Check the Transparency enum for details.|
|bool [Wireframe]({{site.url}}/Pages/StereoKit/Material/Wireframe.html)|Should this material draw only the edges/wires of the mesh? This can be useful for debugging, and even some kinds of visualization work. Note that this may not work on some mobile OpenGL systems like Quest.|

## Instance Methods

|  |  |
|--|--|
|[Material]({{site.url}}/Pages/StereoKit/Material/Material.html)|Creates a material from a shader, and uses the shader's default settings. If the shader is null, a warning will be added to the log, and this Material will default to using an Unlit shader. Uses an auto-generated id.|
|[Copy]({{site.url}}/Pages/StereoKit/Material/Copy.html)|Creates a new Material asset with the same shader and properties! Draw calls with the new Material will not batch together with this one.|
|[GetAllParamInfo]({{site.url}}/Pages/StereoKit/Material/GetAllParamInfo.html)|Gets an enumerable list of all parameter information on the Material. This includes all global shader variables and textures.|
|[GetBool]({{site.url}}/Pages/StereoKit/Material/GetBool.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of 'false' will be returned.|
|[GetColor]({{site.url}}/Pages/StereoKit/Material/GetColor.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Color.White will be returned.|
|[GetFloat]({{site.url}}/Pages/StereoKit/Material/GetFloat.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of '0' will be returned.|
|[GetInt]({{site.url}}/Pages/StereoKit/Material/GetInt.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of '0' will be returned.|
|[GetMatrix]({{site.url}}/Pages/StereoKit/Material/GetMatrix.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Matrix.Identity will be returned.|
|[GetParamInfo]({{site.url}}/Pages/StereoKit/Material/GetParamInfo.html)|Gets available shader parameter information for the parameter at the indicated index. Parameters are listed as variables first, then textures.|
|[GetTexture]({{site.url}}/Pages/StereoKit/Material/GetTexture.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of null will be returned.|
|[GetUInt]({{site.url}}/Pages/StereoKit/Material/GetUInt.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of '0' will be returned.|
|[GetVector2]({{site.url}}/Pages/StereoKit/Material/GetVector2.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Vec2.Zero will be returned.|
|[GetVector3]({{site.url}}/Pages/StereoKit/Material/GetVector3.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Vec3.Zero will be returned.|
|[GetVector4]({{site.url}}/Pages/StereoKit/Material/GetVector4.html)|Gets the value of a shader parameter with the given name. If no parameter is found, a default value of Vec4.Zero will be returned.|
|[SetBool]({{site.url}}/Pages/StereoKit/Material/SetBool.html)|Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!|
|[SetColor]({{site.url}}/Pages/StereoKit/Material/SetColor.html)|Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!|
|[SetData]({{site.url}}/Pages/StereoKit/Material/SetData.html)|This allows you to set more complex shader data types such as structs. Note the SK doesn't guard against setting data of the wrong size here, so pay extra attention to the size of your data here, and ensure it matched up with the shader!|
|[SetFloat]({{site.url}}/Pages/StereoKit/Material/SetFloat.html)|Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!|
|[SetInt]({{site.url}}/Pages/StereoKit/Material/SetInt.html)|Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!|
|[SetMatrix]({{site.url}}/Pages/StereoKit/Material/SetMatrix.html)|Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!|
|[SetTexture]({{site.url}}/Pages/StereoKit/Material/SetTexture.html)|Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!|
|[SetUInt]({{site.url}}/Pages/StereoKit/Material/SetUInt.html)|Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!|
|[SetVector]({{site.url}}/Pages/StereoKit/Material/SetVector.html)|Sets a shader parameter with the given name to the provided value. If no parameter is found, nothing happens, and the value is not set!|

## Static Fields and Properties

|  |  |
|--|--|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [Default]({{site.url}}/Pages/StereoKit/Material/Default.html)|The default material! This is used by many models and meshes rendered from within StereoKit. Its shader is tuned for high performance, and may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default material, here's where you do it!|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [PBR]({{site.url}}/Pages/StereoKit/Material/PBR.html)|The default Physically Based Rendering material! This is used by StereoKit anytime a mesh or model has metallic or roughness properties, or needs to look more realistic. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default PBR behavior, here's where you do it! Note that the shader used by default here is much more costly than Default.Material.|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [PBRClip]({{site.url}}/Pages/StereoKit/Material/PBRClip.html)|Same as MaterialPBR, but it uses a discard clip for transparency.|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [UI]({{site.url}}/Pages/StereoKit/Material/UI.html)|The material used by the UI! By default, it uses a shader that creates a 'finger shadow' that shows how close the finger is to the UI.|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [UIBox]({{site.url}}/Pages/StereoKit/Material/UIBox.html)|A material for indicating interaction volumes! It renders a border around the edges of the UV coordinates that will 'grow' on proximity to the user's finger. It will discard pixels outside of that border, but will also show the finger shadow. This is meant to be an opaque material, so it works well for depth LSR.  This material works best on cube-like meshes where each face has UV coordinates from 0-1.  Shader Parameters: ``` color                - color border_size          - meters border_size_grow     - meters border_affect_radius - meters ```|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [UIQuadrant]({{site.url}}/Pages/StereoKit/Material/UIQuadrant.html)|The material used by the UI for Quadrant Sized UI elements. See UI.QuadrantSizeMesh for additional details. By default, it uses a shader that creates a 'finger shadow' that shows how close the finger is to the UI.|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [Unlit]({{site.url}}/Pages/StereoKit/Material/Unlit.html)|The default unlit material! This is used by StereoKit any time a mesh or model needs to be rendered with an unlit surface. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default unlit behavior, here's where you do it!|
|[Material]({{site.url}}/Pages/StereoKit/Material.html) [UnlitClip]({{site.url}}/Pages/StereoKit/Material/UnlitClip.html)|The default unlit material with alpha clipping! This is used by StereoKit for unlit content with transparency, where completely transparent pixels are discarded. This means less alpha blending, and fewer visible alpha blending issues! In particular, this is how Sprites are drawn. Its shader may change based on system performance characteristics, so it can be great to copy this one when creating your own materials! Or if you want to override StereoKit's default unlit clipped behavior, here's where you do it!|

## Static Methods

|  |  |
|--|--|
|[Find]({{site.url}}/Pages/StereoKit/Material/Find.html)|Looks for a Material asset that's already loaded, matching the given id!|

## Examples

### Material parameter access
Material does have an array operator overload for setting
shader parameters really quickly! You can do this with strings
representing shader parameter names, or use the MatParamName
enum for compile safety.
```csharp
exampleMaterial[MatParamName.DiffuseTex  ] = gridTex;
exampleMaterial[MatParamName.TexTransform] = new Vec4(0,0,2,2);
```

### Assigning an array in a Shader
This is a bit of a hack until proper shader support for arrays arrives,
but with a few C# marshalling tricks, we can assign array without too
much trouble. Look for improvements to this in later versions of
SteroKit.
```csharp
// This struct matches a shader parameter of `float4 offsets[10];`
[StructLayout(LayoutKind.Sequential)]
struct ShaderData
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public Vec4[] offsets;
}

Material arrayMaterial = null;
public void Initialize()
{
	ShaderData shaderData = new ShaderData();
	shaderData.offsets = new Vec4[10] {
		V.XYZW(0,0,0,0),
		V.XYZW(0.2f,0,0,0),
		V.XYZW(0.4f,0,0,0),
		V.XYZW(0.4f,0.2f,0,0),
		V.XYZW(0.4f,0.4f,0,0),
		V.XYZW(0.4f,0.6f,0,0),
		V.XYZW(0.2f,0.6f,0,0),
		V.XYZW(0,0.6f,0,0),
		V.XYZW(0,0.4f,0,0),
		V.XYZW(0,0.2f,0,0)};
	
	arrayMaterial = new Material(Shader.FromFile("shader_arrays.hlsl"));
	arrayMaterial[MatParamName.DiffuseTex] = Tex.FromFile("test.png");
	arrayMaterial.SetData<ShaderData>("offsets", shaderData);
}
```

