[English](README.md) | 简体中文

## Introduction

主要是代码生成器，在不编写代码的情况下直接生成 Unity Timeline 对 Volume 或 Component 的扩展代码，便于快速开发原型以便自定义更多逻辑。  
不复杂的逻辑也可以直接导入项目使用。

目前这个 repo 里有一些 Unity URP 原有的后处理 Volume 的扩展，用来在 Timeline 中动态调节 Volume<br>
可以直接导入项目使用, 也可以通过”**MAO Timeline Playable Wizard**”这个工具自行扩展。

![](https://r2.youngmoe.com/ym-r2-bucket/2023/11/fb552984c57c7f0d554303d97d4387c6.gif)

## Features

### 目前在 Component/Volume 模式中支持的、可用的参数类型：
- 常见的基础字段(int, float, bool, Vector, Color, Texture等)
- `FloatParameter`
- `IntParameter`
- `BoolParameter`
- `Vector2Parameter`
- `Vector3Parameter`
- `Vector4Parameter`
- `ColorParameter`
- `TextureParameter`
- `Enum`(例如景深的 Gaussian 或 Bokeh 模式。目前可以生成代码，但 Clip 的 Inspector 面板中会一次性全部列出来，你可能需要重写指定 Clip 的面板)

### 目前不支持或没有经过完全测试的：
- `LayerMaskParameter`
- `FloatRangeParameter`
- `RenderTextureParameter`
- `CubemapParameter`
- `ObjectParameter`
- `AnimationCurveParameter`
- `TextureCurveParameter`

## Usage

### Typical usecase

1. 打开 Timeline 窗口，创建一个新的 Timeline
2. 在 Scene 中创建一个 Volume，添加 `TimelineExtensionVolumeSettings` 组件
3. 在 Timeline 中添加一个新的 Track。如果是直接使用的这个 repo，它的名字应该以`MAO`开头，例如`MAOBloom`
4. 将创建的 `TimelineExtensionVolumeSettings` 组件绑定到这个Track上
5. 在 Track 中添加新的 Clip，编辑属性，或者与其他的 Clip 进行混合即可

#### `TimelineExtensionVolumeSettings` 组件设置:
- `VolumeAccessType`:
   - `Profile`: 访问 `profile` 的副本，不会影响原本的 `volume profile`文件（但编辑模式下通过 Timeline 控制之后，手动调节的 Volume 参数无法保存）
   - `Shared Profile`：访问 `profile` 的引用，做的修改会直接影响到原本的 `volume profile` 文件，类似于 Editor 模式下修改 Volume 属性。当退出运行模式后无法重置设置
   
   推荐在 Editor 模式下使用 `Shared Profile`，在 `Play` 模式下使用 `Profile`<br>
   如果需要使用这种方式，可以勾选 `AutoSwitchType` 自动切换<br>
   更多信息可以参考 [Unity官方文档](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@16.0/manual/Volumes-API.html#access-a-shared-volume-profile)

### Wizard Usage

这是一个可以快速生成 Timeline 扩展代码的工具<br>
它可以直接获取当前 AppDomain 下的所有类，并通过 C# 反射来获取需要的字段，这样就不再需要自己写扩展代码了~


**Volume Component：**

1. 在 `Window/MAO Timeline Playable Wizard`打开
2. 切换 `WorkType`为 `VolumeComponent`，选择需要的 `Track Binding Type`

   <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/19e8b6032028290d224b7fadef049284.png" width="50%">

3. 将 `Default Values` 设置为 `Volume`

   <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/7a228f2972434178c205c8aaf67a6b0b.png" width="50%">

4. 添加属性

   <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/14b3980e06f8d6cb0b87f9e74eb025e4.png" width="50%">

5. 最后点 `Create` 就可以了，等编译完之后就可以使用，你可以在 `Assets/TimelineExtensions` 找到生成的脚本

> [!IMPORTANT]
> 目前不支持 Enum 类型(例如景深的 Gaussian 或 Bokeh 模式)，如果确实需要的话，可以参考以下方法分成多个 Track 制作：<br>
> <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/48d3bda1b26b762ac0477f2b94fc2a75.png" width="50%">
> <img src="https://r2.youngmoe.com/ym-r2-bucket/2023/11/8d325d458c0209b9068427474dce6377.png" width="50%">

## 高级设置
你可以通过 `TimelineExtensions/Resources/MAOTimelineExtensionsConfigSO` 自定义生成的代码路径，以及默认的命名空间。

命名空间会影响在 `Timeline` 中添加 `Track` 时右键菜单的显示。当存在命名空间时，对应 Track 会生成在子菜单中，否则会生成在最外部。
> <img src="https://r2.youngmoe.com/ym-r2-bucket/2024/11/namespace.png" width="50%">


## License

[MIT License](https://github.com/ShiinaRinne/TimelineExtensions/blob/master/LICENSE)

## Credits

• [Default Playables - Unity Technologies](https://assetstore.unity.com/packages/essentials/default-playables-95266)


[//]: # (## 彩蛋)
[//]: # (我不是在给爱莉生日做视频吗！为什么最后做了这个东西出来！我的爱莉呢！！！)

[//]: # (## 彩蛋2)
[//]: # (一年过去了，爱莉还是没有来到我身边QAQ)

[//]: # (## 彩蛋2)
[//]: # (两年了)