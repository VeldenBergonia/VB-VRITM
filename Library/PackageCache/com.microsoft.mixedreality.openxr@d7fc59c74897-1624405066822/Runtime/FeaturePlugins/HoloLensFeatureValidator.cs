// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine.XR.OpenXR.Features;
using static UnityEngine.XR.OpenXR.Features.OpenXRFeature;

namespace Microsoft.MixedReality.OpenXR
{
    internal class HoloLensFeatureValidator
    {
        internal static void GetValidationChecks(OpenXRFeature feature, List<ValidationRule> results, BuildTargetGroup targetGroup)
        {
            if (targetGroup == BuildTargetGroup.WSA)
            {
                results.Add(new ValidationRule(feature)
                {
                    message = "Windows Mixed Reality support may need the WebCam capability for the locatable camera feature.",
                    error = false,
                    checkPredicate = () => PlayerSettings.WSA.GetCapability(PlayerSettings.WSACapability.WebCam),
                    fixIt = () => PlayerSettings.WSA.SetCapability(PlayerSettings.WSACapability.WebCam, true)
                });
                //  TODO: Should enable "SpatialPerception" capability if app select "SU/SR" features.
                //  results.Add(new ValidationRule(this)
                //  {
                //      message = "Windows Mixed Reality support may need the Spatial Perception Capability.",
                //      error = false,
                //      checkPredicate = () => PlayerSettings.WSA.GetCapability(PlayerSettings.WSACapability.SpatialPerception),
                //      fixIt = () => PlayerSettings.WSA.SetCapability(PlayerSettings.WSACapability.SpatialPerception, true)
                //  });
            }
        }
    }
}
#endif