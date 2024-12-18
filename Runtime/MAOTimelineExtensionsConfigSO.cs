﻿using UnityEngine;
using UnityEngine.Serialization;

namespace MAOTimelineExtension.Runtime
{
    [CreateAssetMenu(fileName = "MAOTimelineExtensionsConfigSO", menuName = "MAOTimelineExtensions/ConfigSO", order = 0)]
    public class MAOTimelineExtensionsConfigSO : ScriptableObject
    {
        public string rootFolderPath = "Assets/TimelineExtensions";
        public string volumeDefaultNameSpace = "MAOTimelineExtension.VolumeExtensions";
        public string componentDefaultNameSpace = "MAOTimelineExtension.ComponentExtensions";
    }
}