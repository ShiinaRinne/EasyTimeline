// This code is automatically generated by MAO Timeline Playable Wizard.
// For more information, please visit 
// https://github.com/ShiinaRinne/TimelineExtensions

using System;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[TrackColor(0.9411765f, 0.972549f, 1f)]
[TrackClipType(typeof(MAOChromaticAberrationClip))]
[TrackBindingType(typeof(Volume))]
public class MAOChromaticAberrationTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<MAOChromaticAberrationMixerBehaviour>.Create(graph, inputCount);
    }
}