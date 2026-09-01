---
layout: default
title: TexFormat
description: What type of color information will the texture contain? A good default here is Rgba32, which gives 8-bit sRGB color with alpha! Most format names end in a short suffix telling you how the GPU interprets the bits when sampled in a shader. - no suffix or "un". unsigned normalized. Raw unsigned integers get normalized into the [0,1] floating point range on read. The default flavor for most color and data formats. - "sn". signed normalized. Raw signed integers get normalized into the [-1,1] floating point range on read. - "ui". unsigned integer. Raw unsigned integers, no normalization! Great for IDs, counters, and exact-integer data. - "si". signed integer. Raw signed integers, no normalization. - "f". signed float, typically an IEEE half or single precision float. - "uf". unsigned float, used by some HDR-leaning compact formats that can only represent non-negative values. - "_srgb". stored in sRGB color space! The GPU auto-converts to linear when sampled and back to sRGB when written. Use this for images viewed by humans, like photos and UI artwork. - "_linear". stored in linear color space, no color-space conversion at sample time. Use this for data textures, like normals, masks, roughness, and metallic. Any format that is _not_ "_srgb" is generally linear. Block-compressed formats (BC, ETC, ASTC, PVRTC, ATC) trade a little quality for a big drop in memory and bandwidth. each format packs an NxN block of pixels into a fixed payload, so cost is measured in bits-per-pixel rather than bits-per-channel. Hardware support varies - prefer BC on desktop/console, ASTC on modern mobile. They're sample-only; you can't render to them.
---
# enum TexFormat

What type of color information will the texture contain? A good
default here is Rgba32, which gives 8-bit sRGB color with alpha!
Most format names end in a short suffix telling you how the GPU
interprets the bits when sampled in a shader:
- no suffix or "un": unsigned normalized. Raw unsigned integers
get normalized into the [0,1] floating point range on read.
The default flavor for most color and data formats.
- "sn": signed normalized. Raw signed integers get normalized
into the [-1,1] floating point range on read.
- "ui": unsigned integer. Raw unsigned integers, no
normalization! Great for IDs, counters, and exact-integer data.
- "si": signed integer. Raw signed integers, no normalization.
- "f": signed float, typically an IEEE half or single precision
float.
- "uf": unsigned float, used by some HDR-leaning compact formats
that can only represent non-negative values.
- "_srgb": stored in sRGB color space! The GPU auto-converts to
linear when sampled and back to sRGB when written. Use this
for images viewed by humans, like photos and UI artwork.
- "_linear": stored in linear color space, no color-space
conversion at sample time. Use this for data textures, like
normals, masks, roughness, and metallic. Any format that is
_not_ "_srgb" is generally linear.
Block-compressed formats (BC, ETC, ASTC, PVRTC, ATC) trade a
little quality for a big drop in memory and bandwidth: each
format packs an NxN block of pixels into a fixed payload, so
cost is measured in bits-per-pixel rather than bits-per-channel.
Hardware support varies - prefer BC on desktop/console, ASTC on
modern mobile. They're sample-only; you can't render to them.

## Enum Values

|  |  |
|--|--|
|Astc4x4Rgba|ASTC 4x4 linear color with full alpha, 8 bpp. High-quality compressed format for data textures on modern mobile GPUs.|
|Astc4x4RgbaSrgb|ASTC 4x4 sRGB color with full alpha, 8 bpp. ASTC is the modern mobile-standard compressed format - excellent quality, broadly supported. The 4x4 block size is the highest-quality (and largest-size) ASTC variant.|
|Astc6x6Rgba|ASTC 6x6 linear color with full alpha, ~3.56 bpp. The linear counterpart to Astc6x6RgbaSrgb, for data textures.|
|Astc6x6RgbaSrgb|ASTC 6x6 sRGB color with full alpha, ~3.56 bpp. Larger blocks than Astc4x4 for less than half the memory, at some cost to quality - a good trade for large or low-frequency textures.|
|Astc8x8RgbaHdr|ASTC 8x8 HDR color with full alpha, 2 bpp. Compressed HDR on mobile GPUs, and much cheaper than an uncompressed float format. Requires the ASTC HDR extension, which is separate from baseline ASTC support!|
|AtcRgb|ATC RGB on Qualcomm Adreno GPUs, 4 bpp. Historical Qualcomm-specific format - prefer Astc or Etc2 on newer Adreno hardware.|
|AtcRgba|ATC with alpha on Qualcomm Adreno GPUs, 8 bpp. Historical Qualcomm-specific format - prefer Astc or Etc2 on newer Adreno hardware.|
|Bc1Rgb|BC1/DXT1 linear RGB, no alpha, 4 bpp. Great for compressed data textures (normals, masks) on desktop and console GPUs. For color images for humans, use Bc1RgbSrgb.|
|Bc1Rgba|BC1/DXT1 linear with 1-bit alpha, 4 bpp. Good for opaque data textures with a sharp cutout mask on desktop and console GPUs. For smooth alpha, reach for Bc3 or Bc7 instead.|
|Bc1RgbaSrgb|BC1/DXT1 sRGB with 1-bit alpha, 4 bpp. Alpha is either fully on or fully off per pixel - great for cutout effects like foliage or chain-link fences. Smooth fade-outs will band hard though; reach for Bc3 or Bc7 for smooth alpha.|
|Bc1RgbSrgb|BC1/DXT1 sRGB RGB, no alpha, 4 bpp. Each 4x4 block of pixels gets squished into 8 bytes, so a texture only takes a quarter of Rgba32's memory. Quality is good for opaque diffuse textures, though artifacts can show up in smooth gradients. Widely supported on desktop and console GPUs - not so much on mobile.|
|Bc2Rgba|BC2/DXT3 linear with explicit 4-bit alpha, 8 bpp. Bc3 is usually preferred for smooth alpha gradients; Bc2 is mostly historical.|
|Bc2RgbaSrgb|BC2/DXT3 sRGB with explicit 4-bit alpha, 8 bpp. Alpha gets 16 discrete levels - fine for blocky or dithered alpha but bands hard on smooth gradients. Bc3 is usually a better choice for smooth alpha; Bc2 is mostly historical.|
|Bc3Rgba|BC3/DXT5 linear color with smooth alpha, 8 bpp. Great for compressed data textures with alpha (RGBA masks) on desktop and console GPUs.|
|Bc3RgbaSrgb|BC3/DXT5 sRGB color with smooth alpha, 8 bpp. Alpha is BC4-compressed, giving much better gradients than Bc1 or Bc2. A solid default for color-with-alpha textures on desktop and console GPUs!|
|Bc4R|BC4 unsigned-normalized single channel [0,1], 4 bpp. Ideal for compressed grayscale textures like heightmaps, ambient occlusion, or single-channel masks. Quality is excellent for smooth single-channel data.|
|Bc4Rsn|BC4 signed-normalized single channel [-1,1], 4 bpp. Useful when your data is naturally signed, like signed distance fields or elevation difference maps.|
|Bc5Rg|BC5 unsigned-normalized two channels, 8 bpp. Effectively two BC4 textures packed together. The standard format for compressed two-channel data on desktop/console - most commonly used for tangent-space normal maps where the Z component is reconstructed in the shader!|
|Bc5Rgsn|BC5 signed-normalized two channels ([-1,1] per channel), 8 bpp. Useful for signed two-channel data, like normal maps stored as [-1,1] directly rather than the typical [0,1] packed form.|
|Bc6hRgbf|BC6H HDR RGB, signed float (can store negative values), 8 bpp. 16-bit half-float per channel, no alpha. Use this when your HDR data can contain negatives, like signed spherical harmonics coefficients.|
|Bc6hRgbuf|BC6H HDR RGB, unsigned float (positive values only), 8 bpp. 16-bit half-float per channel, no alpha. The go-to format for compressing HDR cubemaps and environment maps - stores high-dynamic-range data at a fraction of the cost of Rgba64f.|
|Bc7Rgba|BC7 linear color with full alpha, 8 bpp. Highest-quality BC format - excellent for compressed RGBA data textures when Bc3 quality isn't enough.|
|Bc7RgbaSrgb|BC7 sRGB color with full alpha, 8 bpp. The highest-quality BC format - noticeably better than Bc3 at the same compression ratio. Compression takes longer than Bc3 though, so reach for this when quality matters more than encoding speed.|
|Bgra32|8-bit sRGB B/G/R/A. Same as Rgba32Srgb but with R and B swapped to match the byte order some GPUs and Windows swapchains prefer. Most code can stick with Rgba32Srgb!|
|Bgra32Linear|8-bit linear B/G/R/A. Same as Rgba32Linear but with R and B swapped, mostly for compatibility with BGRA-preferring APIs like Windows swapchains.|
|Bgra32Srgb|8-bit sRGB B/G/R/A. Same as Rgba32Srgb but with R and B swapped to match the byte order some GPUs and Windows swapchains prefer. Most code can stick with Rgba32Srgb!|
|Depth16|16-bit depth - not a lot, but it can be enough if your far clipping plane is pretty close. If you're seeing z-fighting, either bring your far clip in or switch to 24/32-bit depth.|
|Depth16s8|16-bit depth + 8-bit stencil. A compact depth-with-stencil option for when precision needs are modest and memory is tight. If you see z-fighting, step up to Depth24s8 or Depth32s8.|
|Depth24s8|24-bit depth + 8-bit stencil. Depth tracks how close to the camera each pixel is so near objects correctly occlude far ones. Stencil data can be used for clipping effects, deferred rendering, or shadow effects. A sensible default for most scenes!|
|Depth32|32-bit depth. Pretty detailed, and excellent for experiences with very far view distances. No stencil bits though - if you need stencil too, use Depth32s8 instead.|
|Depth32s8|32-bit depth + 8-bit stencil (40 bpp). More depth precision than Depth24s8 but heavier on memory. Use this when you need both 32-bit depth precision and a stencil channel for masking effects.|
|DepthStencil|24-bit depth + 8-bit stencil. Depth tracks how close to the camera each pixel is so near objects correctly occlude far ones. Stencil data can be used for clipping effects, deferred rendering, or shadow effects. A sensible default for most scenes!|
|Etc1Rgb|ETC1 RGB, no alpha, 4 bpp. Widely supported on older Android devices and OpenGL ES 2.0+ GPUs. Quality is acceptable for diffuse color but it's been superseded - prefer Etc2 or Astc on newer hardware!|
|Etc1RgbSrgb|ETC1 sRGB RGB, no alpha, 4 bpp. The sRGB counterpart to Etc1Rgb - the GPU converts to linear on sample, so this is the correct choice for color textures.|
|Etc2R11|ETC2/EAC single 11-bit unsigned-normalized channel, 4 bpp. The ETC equivalent of Bc4 - great for compressed grayscale or heightmap data on mobile GPUs!|
|Etc2Rg11|ETC2/EAC two 11-bit unsigned-normalized channels, 8 bpp. The ETC equivalent of Bc5 - great for compressed two-channel data like tangent-space normal maps on mobile GPUs!|
|Etc2Rgba|ETC2 linear color with full alpha, 8 bpp. Standard compressed format for data textures with alpha on OpenGL ES 3.0+ mobile devices.|
|Etc2RgbaSrgb|ETC2 sRGB color with full alpha, 8 bpp. The standard compressed RGBA format on OpenGL ES 3.0+ mobile devices, and mandatory in the spec - so it's widely available. A great default for sRGB color textures on mobile!|
|None|Default zero value for TexFormat! Uninitialized formats land here and **** **** up so you know to assign one properly :)|
|Nv12|NV12 video format - a 2-plane 4:2:0 YUV layout! Plane 1 is a full-resolution Y (luminance) plane at 8 bpp, plane 2 is a half-resolution UV (chrominance) plane with U and V interleaved at 8 bits each. The most common output format from hardware video decoders!|
|P010|P010 video format - like NV12 but with 10-bit channels stored in 16-bit fields. Full-resolution 10-bit Y plane plus a half-resolution interleaved 10-bit UV plane. Used for 10-bit HDR video!|
|Pvrtc1Rgb|PVRTC1 linear RGB, 2 bpp. PowerVR GPUs only, requires power-of-two square textures.|
|Pvrtc1Rgba|PVRTC1 linear with full alpha, 4 bpp. PowerVR GPUs only, requires power-of-two square textures.|
|Pvrtc1RgbaSrgb|PVRTC1 sRGB with full alpha, 4 bpp. The 4bpp variant is higher quality than the 2bpp variants. PowerVR GPUs only, requires power-of-two square textures.|
|Pvrtc1RgbSrgb|PVRTC1 sRGB RGB, 2 bpp. Used on iOS and other PowerVR GPUs. The 2bpp bitrate is super compact but quality is lower than ETC/BC - acceptable for low-detail or background textures. Requires power-of-two square textures!|
|Pvrtc2Rgba|PVRTC2 linear with full alpha, 4 bpp. Better quality and more flexible texture sizes than PVRTC1. PowerVR GPUs only.|
|Pvrtc2RgbaSrgb|PVRTC2 sRGB with full alpha, 4 bpp. An update to PVRTC1 with better quality and fewer restrictions - works with non-power-of-two and non-square textures. Still PowerVR-specific though.|
|R16|16-bit unsigned-normalized single channel. A good format for height maps, since it stores a fair bit of information!|
|R16f|16-bit half-float single channel. Good for HDR height/depth data that needs a range beyond what normalized formats give you.|
|R16s|16-bit signed-normalized single channel. Good for signed height data or signed distance fields.|
|R16si|16-bit signed-integer single channel. Good for signed integer or ID data.|
|R16sn|16-bit signed-normalized single channel. Good for signed height data or signed distance fields.|
|R16u|16-bit unsigned-normalized single channel. A good format for height maps, since it stores a fair bit of information!|
|R16ui|16-bit unsigned-integer single channel. A great format for index or ID data, since values are accessed as raw integers.|
|R16un|16-bit unsigned-normalized single channel. A good format for height maps, since it stores a fair bit of information!|
|R32|32-bit single-precision float single channel. Treats each pixel as a generic float, so you can do all sorts of strange and interesting things with this! Great for scientific data, signed distance fields, or detailed height fields where 16 bits of precision aren't enough.|
|R32f|32-bit single-precision float single channel. Treats each pixel as a generic float, so you can do all sorts of strange and interesting things with this! Great for scientific data, signed distance fields, or detailed height fields where 16 bits of precision aren't enough.|
|R32si|32-bit signed-integer single channel.|
|R32ui|32-bit unsigned-integer single channel. Useful for counters, IDs, and atomic compute operations.|
|R8|8-bit unsigned-normalized single channel. Great when you only need one channel and want to keep memory down.|
|R8g8|Two 8-bit unsigned-normalized channels (R, G). Useful for two-component data like compressed normals where the third axis is reconstructed in the shader, or two grayscale signals stored side by side.|
|R8si|8-bit signed-integer single channel.|
|R8sn|8-bit signed-normalized single channel. Useful for a single signed value like an elevation difference or signed mask.|
|R8Srgb|8-bit sRGB single channel. Useful for single-channel sRGB data like a luminance map that should be linearized before lighting math.|
|R8ui|8-bit unsigned-integer single channel. Good for small IDs, indices, or stencil-like data accessed as exact integers.|
|Rg11b10|Packed HDR R/G/B as unsigned floats - 11 bits for R and G, 10 for B, no alpha. A great compact HDR format: holds values way beyond the [0,1] range that Rgba32 maxes out at, while still fitting in 32 bpp! Great for HDR render targets and intermediate compute buffers. Not universally supported as a render target, so watch for that!|
|Rg11b10uf|Packed HDR R/G/B as unsigned floats - 11 bits for R and G, 10 for B, no alpha. A great compact HDR format: holds values way beyond the [0,1] range that Rgba32 maxes out at, while still fitting in 32 bpp! Great for HDR render targets and intermediate compute buffers. Not universally supported as a render target, so watch for that!|
|Rgb10a2|Packed unsigned-normalized R/G/B/A with 10 bits per color channel and 2 bits for alpha. A great presentation format for high bit-depth displays that still fits in 32 bpp, and you get a bit of transparency too! Alpha is effectively on/off/halfway though, so skip this if you need smooth alpha. Not universally supported as a render target!|
|Rgb9e5|Shared-exponent HDR R/G/B with 9-bit mantissa per channel and a 5-bit shared exponent. A compact HDR format that packs values way beyond the [0,1] range into just 32 bpp! No alpha though, and sharing the exponent means all three channels need similar magnitudes - perfect for environment maps! Usually sample-only; GPUs typically can't render to it.|
|Rgb9e5uf|Shared-exponent HDR R/G/B with 9-bit mantissa per channel and a 5-bit shared exponent. A compact HDR format that packs values way beyond the [0,1] range into just 32 bpp! No alpha though, and sharing the exponent means all three channels need similar magnitudes - perfect for environment maps! Usually sample-only; GPUs typically can't render to it.|
|Rgba128|32-bit float R/G/B/A - basically 4 single-precision floats per pixel, which is bonkers expensive at 128 bpp! Don't reach for this unless you know -exactly- what you're doing. Useful for scientific data or compute buffers where you really need full 32-bit float precision per channel.|
|Rgba128f|32-bit float R/G/B/A - basically 4 single-precision floats per pixel, which is bonkers expensive at 128 bpp! Don't reach for this unless you know -exactly- what you're doing. Useful for scientific data or compute buffers where you really need full 32-bit float precision per channel.|
|Rgba32|8-bit sRGB R/G/B/A. The default for human-viewed color images, and a clean match for the Color32 struct! For data textures (normals, masks, rough/metal) use Rgba32Linear instead.|
|Rgba32Linear|8-bit linear R/G/B/A. Use this for data textures (normals, masks, rough/metal) where you don't want the GPU's automatic sRGB conversion getting in the way.|
|Rgba32Srgb|8-bit sRGB R/G/B/A. The default for human-viewed color images, and a clean match for the Color32 struct! For data textures (normals, masks, rough/metal) use Rgba32Linear instead.|
|Rgba64|16-bit unsigned-normalized R/G/B/A (64 bpp). Doubling the bit depth over Rgba32 gives much smoother gradients!|
|Rgba64f|16-bit half-float R/G/B/A (64 bpp). A common HDR render-target format - full RGBA float precision at half the memory of Rgba128. Almost always supported as a render target, so a reliable fallback for formats like Rg11b10.|
|Rgba64si|16-bit signed-integer R/G/B/A (64 bpp). For [-1,1] sampling, use Rgba64sn instead.|
|Rgba64sn|16-bit signed-normalized R/G/B/A (64 bpp).|
|Rgba64ui|16-bit unsigned-integer R/G/B/A (64 bpp). Great for ID textures, counters, or any discrete-integer data. For [0,1] sampling, use Rgba64un instead.|
|Rgba64un|16-bit unsigned-normalized R/G/B/A (64 bpp). Doubling the bit depth over Rgba32 gives much smoother gradients!|
|Yuv420p|A 3-plane 4:2:0 YUV layout - separate Y, U, and V planes each at 8 bpp, with U and V at half resolution. Common in software video decoders but less common from hardware decoders (which usually output NV12).|
