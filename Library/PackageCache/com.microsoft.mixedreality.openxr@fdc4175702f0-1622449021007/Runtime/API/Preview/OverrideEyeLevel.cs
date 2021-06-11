// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

namespace Microsoft.MixedReality.OpenXR.Preview
{
    public class OverrideEyeLevel : MonoBehaviour
    {
        private XRInputSubsystem m_inputSubsystem;

        private void OnEnable()
        {
            XRGeneralSettings xrSettings = XRGeneralSettings.Instance;
            if (xrSettings == null)
            {
                Debug.LogError($"XRGeneralSettings is null.");
                return;
            }

            XRManagerSettings xrManager = xrSettings.Manager;
            if (xrManager == null)
            {
                Debug.LogError($"XRManagerSettings is null.");
                return;
            }

            XRLoader xrLoader = xrManager.activeLoader;
            if (xrLoader == null)
            {
                Debug.LogError($"XRLoader is null.");
                return;
            }

            m_inputSubsystem = xrLoader.GetLoadedSubsystem<XRInputSubsystem>();
            if (m_inputSubsystem == null)
            {
                Debug.LogError($"XRInputSubsystem is null.");
                return;
            }

            m_inputSubsystem.trackingOriginUpdated += XrInput_trackingOriginUpdated;

            EnsureSceneOriginMode();
        }

        private void OnDisable()
        {
            if (m_inputSubsystem != null)
            {
                m_inputSubsystem.trackingOriginUpdated -= XrInput_trackingOriginUpdated;
                m_inputSubsystem = null;
            }
        }

        private void XrInput_trackingOriginUpdated(XRInputSubsystem obj)
        {
            if (isActiveAndEnabled)
            {
                EnsureSceneOriginMode();
            }
        }

        private void EnsureSceneOriginMode()
        {
            TrackingOriginModeFlags currentMode = m_inputSubsystem.GetTrackingOriginMode();
            bool isEyeLevel = currentMode == TrackingOriginModeFlags.Device;
#if UNITY_2020_2_OR_NEWER
            isEyeLevel |= currentMode == TrackingOriginModeFlags.Unbounded;
#endif

            if (!isEyeLevel)
            {
                OverrideEyeLevelTrackingOriginMode(m_inputSubsystem);
            }
        }

        private static void OverrideEyeLevelTrackingOriginMode(XRInputSubsystem xrInput)
        {
            TrackingOriginModeFlags supportedFlags = xrInput.GetSupportedTrackingOriginModes();
            TrackingOriginModeFlags targetFlag = TrackingOriginModeFlags.Device;   // All OpenXR runtime must support LOCAL space

#if UNITY_2020_2_OR_NEWER
            if (supportedFlags.HasFlag(TrackingOriginModeFlags.Unbounded))
            {
                targetFlag = TrackingOriginModeFlags.Unbounded;
            }
#endif

            if (!xrInput.TrySetTrackingOriginMode(targetFlag))
            {
                Debug.LogWarning($"Failed to set tracking origin to {targetFlag}.");
            }
        }
    }
}