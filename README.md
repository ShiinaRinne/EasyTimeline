﻿# TimelineExtensions
English | [中文](README_CN.md)

## Introduction

A code generator tool for `Unity Timeline` that creates extension code for `Volume` or `Component` without writing code manually. 
It helps rapid prototyping and allows for easy customization of additional logic.
Non-complex generated code can be directly imported into projects.

[//]: # (This project was originally developed mainly to expand the post-processing volume, 
and will gradually improve other types in the future.)

At present, there are some extensions to the original Post-Processing Volume of Unity URP, which are used to dynamically adjust the volume in the Timeline<br>
It can be directly imported into the project for use, or quickly expand through the "**MAO Timeline playable Wizard**" tool.

![](https://r2.youngmoe.com/ym-r2-bucket/2023/11/fb552984c57c7f0d554303d97d4387c6.gif)

## Features
### Currently supported parameter types in Component/Volume mode:
- Common basic fields (`int`, `float`, `bool`, `Vector`, `Color`, `Texture`, etc.)
- `FloatParameter`
- `IntParameter`
- `BoolParameter`
- `Vector2Parameter`
- `Vector3Parameter`
- `Vector4Parameter`
- `ColorParameter`
- `TextureParameter`
- `Enum` (e.g., `Depth of Field's` **Gaussian** or **Bokeh** modes. Code generation is supported, 
but the Clip's Inspector panel will list all options at once - you may need to customize the Clip's panel)

### Currently unsupported or not fully tested:
- `LayerMaskParameter`
- `FloatRangeParameter`
- `RenderTextureParameter`
- `CubemapParameter`
- `ObjectParameter`
- `AnimationCurveParameter`
- `TextureCurveParameter`


## Usage

### Typical usecase

1. Open the Timeline window and create a new Timeline.
2. Create a new Global Volume, add `TimelineExtensionVolumeSettings` component.
3. Add a new Track which starts with "MAO", such as `MAOBloom`.
4. Set TrackBinding to the `TimelineExtensionVolumeSettings` component.
5. Add a new Clip to the Track, edit properties in the Clip or mix with other Clips.<br>

#### `TimelineExtensionVolumeSettings` component settings:
- VolumeAccessType:
   - `Profile`: Access a copy of the profile, which will not affect the original volume profile file (but if you adjust the Volume property through Timeline in Editor mode and then manually adjust it, this modification cannot be saved)
   - `Shared Profile`: Access a reference to the profile, which will directly affect the original `volume profile`. The settings cannot be reset after exiting play mode
   
> [!TIP]
> It is recommended to use `Shared Profile` in Editor mode and `Profile` in Play mode.<br>
> If you need to use this switching method, you can check `AutoSwitchType` in `TimelineExtensionVolumeSettings`<br>
> For more information, please refer to [Unity Documentation](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@16.0/manual/Volumes-API.html)


#### VolumeComponent:
1. You can find it in the menu bar `Window/MAO Timeline Playable Wizard`

2. Switch `WorkType` to VolumeComponent, select the `Track Binding Type`

   <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/19e8b6032028290d224b7fadef049284.png" width="50%">

3. Set `Default Values` to the Volume

   <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/7a228f2972434178c205c8aaf67a6b0b.png" width="50%">

4. Add the properties

   <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/14b3980e06f8d6cb0b87f9e74eb025e4.png" width="50%">

5. Finally, click `Create`, wait for the compilation to complete and start enjoying~<br>
You can find it in `Assets/TimelineExtensions`

> [!IMPORTANT]
> For Enum types (such as Gaussian or Bokeh mode in Depth of Field), the default rule-based custom Editor generation is not supported.   
> So It will list all fields at once, which might be inconvenient to view.   
> You can either split them into multiple Tracks as shown below, or write your own code for custom Clip Editor extensions  
> <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/48d3bda1b26b762ac0477f2b94fc2a75.png" width="50%">
> <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/8d325d458c0209b9068427474dce6377.png" width="50%">

## Advanced Settings
You can customize the generated code path and default namespace through `TimelineExtensions/Resources/MAOTimelineExtensionsConfigSO`.

The namespace affects how the Track appears in the context menu when adding a Track in Timeline. When a namespace is present, the corresponding Track will be generated in a submenu; otherwise, it will appear in the root menu.

> <img src="https://r2.youngmoe.com/ym-r2-bucket/2024/11/namespace.png" width="50%">


## License
[MIT License](https://github.com/ShiinaRinne/TimelineExtensions/blob/master/LICENSE)

## Credits
- [Default Playables - Unity Technologies](https://assetstore.unity.com/packages/essentials/default-playables-95266)