// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEditor;
using UnityEditor.XR.OpenXR.Features;
using UnityEngine.XR.OpenXR.Features.Interactions;

namespace Microsoft.MixedReality.OpenXR.Editor
{
    [OpenXRFeatureSet(
        FeatureIds = new string[] {
            KHRSimpleControllerProfile.featureId,
            MicrosoftMotionControllerProfile.featureId,
            HPMixedRealityControllerProfile.featureId,
            MicrosoftHandInteraction.featureId,
            HandTrackingFeaturePlugin.featureId,
            EyeGazeInteraction.featureId,
            HoloLensFeaturePlugin.featureId,
            },
        UiName = "Windows Mixed Reality",
        // This will appear as a tooltip for the (?) icon in the loader UI.
        Description = "Enable the full suite of features for Windows Mixed Reality headsets.",
        // If this is changed, please report the new ID back to Unity so that we can update our list.
        FeatureSetId = featureSetId,
        SupportedBuildTargets = new BuildTargetGroup[] { BuildTargetGroup.Standalone }
    )]
    sealed class WMRFeatureSet
    {
        internal const string featureSetId = "com.microsoft.openxr.featureset.wmr";
    }
}
