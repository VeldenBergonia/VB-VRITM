// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Microsoft.MixedReality.OpenXR.Samples
{
    [RequireComponent(typeof(ARPlaneManager))]
    public class PlanesSample : MonoBehaviour
    {
        private void Update()
        {
            var planes = m_arPlaneManager.trackables;
            if (planes.count > 0)
            {
                Debug.Log($"Planes: {planes.count}");
                foreach (var plane in planes)
                {
                    Debug.Log($"Plane: {plane.normal}");
                }
            }
        }

        private void Awake()
        {
            m_arPlaneManager = GetComponent<ARPlaneManager>();
        }

        private ARPlaneManager m_arPlaneManager;
    }
}
