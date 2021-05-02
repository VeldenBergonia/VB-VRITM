// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.OpenXR.Preview;
using UnityEditor;

namespace Microsoft.MixedReality.OpenXR.Editor
{
    [CustomEditor(typeof(OverrideEyeLevel))]
    internal class OverrideEyeLevelInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Enable this override if the XR experience assumes the scene origin at eye level.", MessageType.Info);
        }
    }
}
