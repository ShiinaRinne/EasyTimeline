// This code is automatically generated by PostProcessing Extension Wizard.
// For more information, please visit 
// https://github.com/ShiinaRinne/TimelineExtensions

using System;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

[Serializable]
public class MAOBloomClip : PlayableAsset, ITimelineClipAsset
{
    [Min(0f)] public float threshold = 0.9f;
    [Min(0f)] public float intensity = 0f;
    [Range(0f, 1f)] public float scatter = 0.7f;
    [Min(0f)] public float clamp = 65472f;
    public Color tint = new Color(0f, 0f, 0f, 1f);
    public bool highQualityFiltering = false;
#if UNITY_2023_1_OR_NEWER
    [Range(2, 8)] public int maxIterations = 6;
#else
    [Range(0, 16)] public int skipIterations = 1;
#endif
    public Texture dirtTexture;
    [Min(0f)] public float dirtIntensity = 0f;


    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<MAOBloomBehaviour>.Create(graph);
        var behaviour = playable.GetBehaviour();

        behaviour.Threshold = threshold;
        behaviour.Intensity = intensity;
        behaviour.Scatter = scatter;
        behaviour.Clamp = clamp;
        behaviour.Tint = tint;
        behaviour.HighQualityFiltering = highQualityFiltering;
#if UNITY_2023_1_OR_NEWER
        behaviour.MaxIterations = maxIterations;
#else
        behaviour.SkipIterations = skipIterations;
#endif
        behaviour.DirtTexture = dirtTexture;
        behaviour.DirtIntensity = dirtIntensity;


        return playable;
    }
}