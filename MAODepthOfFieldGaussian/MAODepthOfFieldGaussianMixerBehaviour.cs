// This code is automatically generated by MAO Timeline Playable Wizard.
// For more information, please visit 
// https://github.com/ShiinaRinne/TimelineExtensions

using System;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


namespace MAOTimelineExtension.VolumeExtensions
{
    public class MAODepthOfFieldGaussianMixerBehaviour : PlayableBehaviour
    {
        float m_DefaultGaussianStart;
        float m_DefaultGaussianEnd;
        float m_DefaultGaussianMaxRadius;
        bool m_DefaultHighQualitySampling;

        DepthOfField m_TrackBinding;
        bool m_FirstFrameHappened;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            ((TimelineExtensionVolumeSettings) playerData).VolumeProfile.TryGet(out m_TrackBinding);
            if (m_TrackBinding == null)
                return;
            
            if(!m_FirstFrameHappened)
            {
                m_DefaultGaussianStart = m_TrackBinding.gaussianStart.value;
                m_DefaultGaussianEnd = m_TrackBinding.gaussianEnd.value;
                m_DefaultGaussianMaxRadius = m_TrackBinding.gaussianMaxRadius.value;
                m_DefaultHighQualitySampling = m_TrackBinding.highQualitySampling.value;

                m_FirstFrameHappened = true;
            }


            int inputCount = playable.GetInputCount();
            float blendedGaussianStart = 0f;
            float blendedGaussianEnd = 0f;
            float blendedGaussianMaxRadius = 0f;
            bool blendedHighQualitySampling = false;

            float totalWeight = 0f;
            float greatestWeight = 0f;
            int currentInputs = 0;

            for(int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<MAODepthOfFieldGaussianBehaviour> inputPlayable =(ScriptPlayable<MAODepthOfFieldGaussianBehaviour>)playable.GetInput(i);
                MAODepthOfFieldGaussianBehaviour input = inputPlayable.GetBehaviour();
                
                blendedGaussianStart += input.GaussianStart * inputWeight;
                blendedGaussianEnd += input.GaussianEnd * inputWeight;
                blendedGaussianMaxRadius += input.GaussianMaxRadius * inputWeight;
                blendedHighQualitySampling = inputWeight > 0.5 ? input.HighQualitySampling : blendedHighQualitySampling;

                totalWeight += inputWeight;

                if (inputWeight > greatestWeight)
                {
                    greatestWeight = inputWeight;
                }

                if (!Mathf.Approximately (inputWeight, 0f))
                    currentInputs++;
            }
            m_TrackBinding.gaussianStart.value = blendedGaussianStart + m_DefaultGaussianStart * (1f-totalWeight);
            m_TrackBinding.gaussianEnd.value = blendedGaussianEnd + m_DefaultGaussianEnd * (1f-totalWeight);
            m_TrackBinding.gaussianMaxRadius.value = blendedGaussianMaxRadius + m_DefaultGaussianMaxRadius * (1f-totalWeight);
            m_TrackBinding.highQualitySampling.value = blendedHighQualitySampling;

        }



        public override void OnPlayableDestroy (Playable playable)
        {
            m_FirstFrameHappened = false;

            if(m_TrackBinding == null)
                return;

            m_TrackBinding.gaussianStart.value = m_DefaultGaussianStart;
            m_TrackBinding.gaussianEnd.value = m_DefaultGaussianEnd;
            m_TrackBinding.gaussianMaxRadius.value = m_DefaultGaussianMaxRadius;
            m_TrackBinding.highQualitySampling.value = m_DefaultHighQualitySampling;

        }
    }
}

