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
    public class MAOChannelMixerMixerBehaviour : PlayableBehaviour
    {
        float m_DefaultRedOutRedIn;
        float m_DefaultRedOutGreenIn;
        float m_DefaultRedOutBlueIn;
        float m_DefaultGreenOutRedIn;
        float m_DefaultGreenOutGreenIn;
        float m_DefaultGreenOutBlueIn;
        float m_DefaultBlueOutRedIn;
        float m_DefaultBlueOutGreenIn;
        float m_DefaultBlueOutBlueIn;

        ChannelMixer m_TrackBinding;
        bool m_FirstFrameHappened;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            ((TimelineExtensionVolumeSettings) playerData).VolumeProfile.TryGet(out m_TrackBinding);
            if (m_TrackBinding == null)
                return;
            
            if(!m_FirstFrameHappened)
            {
                m_DefaultRedOutRedIn = m_TrackBinding.redOutRedIn.value;
                m_DefaultRedOutGreenIn = m_TrackBinding.redOutGreenIn.value;
                m_DefaultRedOutBlueIn = m_TrackBinding.redOutBlueIn.value;
                m_DefaultGreenOutRedIn = m_TrackBinding.greenOutRedIn.value;
                m_DefaultGreenOutGreenIn = m_TrackBinding.greenOutGreenIn.value;
                m_DefaultGreenOutBlueIn = m_TrackBinding.greenOutBlueIn.value;
                m_DefaultBlueOutRedIn = m_TrackBinding.blueOutRedIn.value;
                m_DefaultBlueOutGreenIn = m_TrackBinding.blueOutGreenIn.value;
                m_DefaultBlueOutBlueIn = m_TrackBinding.blueOutBlueIn.value;

                m_FirstFrameHappened = true;
            }


            int inputCount = playable.GetInputCount();
            float blendedRedOutRedIn = 0f;
            float blendedRedOutGreenIn = 0f;
            float blendedRedOutBlueIn = 0f;
            float blendedGreenOutRedIn = 0f;
            float blendedGreenOutGreenIn = 0f;
            float blendedGreenOutBlueIn = 0f;
            float blendedBlueOutRedIn = 0f;
            float blendedBlueOutGreenIn = 0f;
            float blendedBlueOutBlueIn = 0f;

            float totalWeight = 0f;
            float greatestWeight = 0f;
            int currentInputs = 0;

            for(int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<MAOChannelMixerBehaviour> inputPlayable =(ScriptPlayable<MAOChannelMixerBehaviour>)playable.GetInput(i);
                MAOChannelMixerBehaviour input = inputPlayable.GetBehaviour();
                
                blendedRedOutRedIn += input.RedOutRedIn * inputWeight;
                blendedRedOutGreenIn += input.RedOutGreenIn * inputWeight;
                blendedRedOutBlueIn += input.RedOutBlueIn * inputWeight;
                blendedGreenOutRedIn += input.GreenOutRedIn * inputWeight;
                blendedGreenOutGreenIn += input.GreenOutGreenIn * inputWeight;
                blendedGreenOutBlueIn += input.GreenOutBlueIn * inputWeight;
                blendedBlueOutRedIn += input.BlueOutRedIn * inputWeight;
                blendedBlueOutGreenIn += input.BlueOutGreenIn * inputWeight;
                blendedBlueOutBlueIn += input.BlueOutBlueIn * inputWeight;

                totalWeight += inputWeight;

                if (inputWeight > greatestWeight)
                {
                    greatestWeight = inputWeight;
                }

                if (!Mathf.Approximately (inputWeight, 0f))
                    currentInputs++;
            }
            m_TrackBinding.redOutRedIn.value = blendedRedOutRedIn + m_DefaultRedOutRedIn * (1f-totalWeight);
            m_TrackBinding.redOutGreenIn.value = blendedRedOutGreenIn + m_DefaultRedOutGreenIn * (1f-totalWeight);
            m_TrackBinding.redOutBlueIn.value = blendedRedOutBlueIn + m_DefaultRedOutBlueIn * (1f-totalWeight);
            m_TrackBinding.greenOutRedIn.value = blendedGreenOutRedIn + m_DefaultGreenOutRedIn * (1f-totalWeight);
            m_TrackBinding.greenOutGreenIn.value = blendedGreenOutGreenIn + m_DefaultGreenOutGreenIn * (1f-totalWeight);
            m_TrackBinding.greenOutBlueIn.value = blendedGreenOutBlueIn + m_DefaultGreenOutBlueIn * (1f-totalWeight);
            m_TrackBinding.blueOutRedIn.value = blendedBlueOutRedIn + m_DefaultBlueOutRedIn * (1f-totalWeight);
            m_TrackBinding.blueOutGreenIn.value = blendedBlueOutGreenIn + m_DefaultBlueOutGreenIn * (1f-totalWeight);
            m_TrackBinding.blueOutBlueIn.value = blendedBlueOutBlueIn + m_DefaultBlueOutBlueIn * (1f-totalWeight);

        }



        public override void OnPlayableDestroy (Playable playable)
        {
            m_FirstFrameHappened = false;

            if(m_TrackBinding == null)
                return;

            m_TrackBinding.redOutRedIn.value = m_DefaultRedOutRedIn;
            m_TrackBinding.redOutGreenIn.value = m_DefaultRedOutGreenIn;
            m_TrackBinding.redOutBlueIn.value = m_DefaultRedOutBlueIn;
            m_TrackBinding.greenOutRedIn.value = m_DefaultGreenOutRedIn;
            m_TrackBinding.greenOutGreenIn.value = m_DefaultGreenOutGreenIn;
            m_TrackBinding.greenOutBlueIn.value = m_DefaultGreenOutBlueIn;
            m_TrackBinding.blueOutRedIn.value = m_DefaultBlueOutRedIn;
            m_TrackBinding.blueOutGreenIn.value = m_DefaultBlueOutGreenIn;
            m_TrackBinding.blueOutBlueIn.value = m_DefaultBlueOutBlueIn;

        }
    }
}

