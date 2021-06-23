// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Microsoft.MixedReality.OpenXR
{
    internal enum NativeLibToken : ulong
    {
        Invalid = 0,
        HoloLens = 1,
        HandTracking = 2,
        Remoting = 3,
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal class NativeLibTokenAttribute : Attribute
    {
        public NativeLibToken NativeLibToken { get; set; }
    }

    internal class NativeLib
    {
        internal const string DllName = "MicrosoftOpenXRPlugin";

        [DllImport(DllName, EntryPoint = "openxr_plugin_InitializeNativeLibToken")]
        internal static extern void InitializeNativeLibToken(NativeLibToken token);

        [DllImport(DllName, EntryPoint = "openxr_plugin_HookGetInstanceProcAddr")]
        internal static extern IntPtr HookGetInstanceProcAddr(NativeLibToken token, IntPtr func);

        [DllImport(DllName, EntryPoint = "openxr_plugin_SetXrInstance")]
        internal static extern void SetXrInstance(NativeLibToken token, ulong instance);

        [DllImport(DllName, EntryPoint = "openxr_plugin_SetXrSystemId")]
        internal static extern void SetXrSystemId(NativeLibToken token, ulong systemId);

        [DllImport(DllName, EntryPoint = "openxr_plugin_SetXrSession")]
        internal static extern void SetXrSession(NativeLibToken token, ulong session);

        [DllImport(DllName, EntryPoint = "openxr_plugin_SetXrSessionRunning")]
        internal static extern void SetXrSessionRunning(NativeLibToken token, bool running);

        [DllImport(DllName, EntryPoint = "openxr_plugin_SetXrSessionState")]
        internal static extern void SetSessionState(NativeLibToken token, uint sessionState);

        [DllImport(DllName, EntryPoint = "openxr_plugin_SetXrReferenceSpace")]
        internal static extern void SetReferenceSpace(NativeLibToken token, ulong referenceSpace);

        [DllImport(DllName, EntryPoint = "openxr_plugin_CreateSceneUnderstandingProvider")]
        internal static extern void CreateSceneUnderstandingProvider(NativeLibToken token);

        [DllImport(DllName, EntryPoint = "openxr_plugin_SetSceneUnderstandingActive")]
        internal static extern void SetSceneUnderstandingActive(NativeLibToken token, bool isActive);

        [DllImport(DllName, EntryPoint = "openxr_plugin_GetNumPlanes")]
        internal static extern void GetNumPlanes(NativeLibToken token, FrameTime frameTime, ref uint numAddedPlanes, ref uint numUpdatedPlanes, ref uint numRemovedPlanes);

        [DllImport(DllName, EntryPoint = "openxr_plugin_GetPlanes")]
        unsafe internal static extern void GetPlanes(NativeLibToken token, void* addedPlanes, void* updatedPlanes, void* removedPlanes);

        [DllImport(DllName, EntryPoint = "openxr_plugin_CreateAnchorProvider")]
        internal static extern void CreateAnchorProvider(NativeLibToken token);

        [DllImport(DllName, EntryPoint = "openxr_plugin_TryAddAnchor")]
        unsafe internal static extern bool TryAddAnchor(NativeLibToken token, FrameTime frameTime, Quaternion rotation, Vector3 position, void* anchorPtr);

        [DllImport(DllName, EntryPoint = "openxr_plugin_TryRemoveAnchor")]
        internal static extern bool TryRemoveAnchor(NativeLibToken token, Guid anchorId);

        [DllImport(DllName, EntryPoint = "openxr_plugin_GetNumAnchorChanges")]
        internal static extern void GetNumAnchorChanges(NativeLibToken token, FrameTime frameTime, ref uint numAddedAnchors, ref uint numUpdatedAnchors, ref uint numRemovedAnchors);

        [DllImport(DllName, EntryPoint = "openxr_plugin_GetAnchorChanges")]
        unsafe internal static extern void GetAnchorChanges(NativeLibToken token, void* addedAnchors, void* updatedAnchors, void* removedAnchors);

        [DllImport(DllName, EntryPoint = "openxr_plugin_LoadAnchorStore")]
        internal static extern void LoadAnchorStore(NativeLibToken token);

        [DllImport(DllName, EntryPoint = "openxr_plugin_GetNumPersistedAnchorNames")]
        internal static extern uint GetNumPersistedAnchorNames(NativeLibToken token);

        [DllImport(DllName, EntryPoint = "openxr_plugin_GetPersistedAnchorName")]
        internal static extern void GetPersistedAnchorName(NativeLibToken token, uint idx, StringBuilder nameOut, uint capacity);

        [DllImport(DllName, EntryPoint = "openxr_plugin_LoadPersistedAnchor")]
        internal static extern Guid LoadPersistedAnchor(NativeLibToken token, string name);

        [DllImport(DllName, EntryPoint = "openxr_plugin_TryPersistAnchor")]
        internal static extern bool TryPersistAnchor(NativeLibToken token, string name, Guid anchorId);

        [DllImport(DllName, EntryPoint = "openxr_plugin_UnpersistAnchor")]
        internal static extern void UnpersistAnchor(NativeLibToken token, string name);

        [DllImport(DllName, EntryPoint = "openxr_plugin_ClearPersistedAnchors")]
        internal static extern void ClearPersistedAnchors(NativeLibToken token);

        [DllImport(DllName, EntryPoint = "openxr_plugin_GetHandJointData")]
        internal static extern bool GetHandJointData(NativeLibToken token, Preview.Handedness handedness, FrameTime frameTime,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = Preview.HandTracker.JointCount)] Preview.HandJointLocation[] handJoints);

        [DllImport(DllName, EntryPoint = "openxr_plugin_SetRemotingEnabled")]
        internal static extern void SetRemotingEnabled(NativeLibToken token, bool enabled);

        [DllImport(DllName, EntryPoint = "openxr_plugin_ConnectRemoting")]
        internal static extern void ConnectRemoting(NativeLibToken token, Remoting.RemotingConfiguration configuration);

        [DllImport(DllName, EntryPoint = "openxr_plugin_DisconnectRemoting")]
        internal static extern void DisconnectRemoting(NativeLibToken token);

        [DllImport(DllName, EntryPoint = "openxr_plugin_TryGetRemotingConnectionState")]
        internal static extern bool TryGetRemotingConnectionState(NativeLibToken token, out Remoting.ConnectionState connectionState, out Remoting.DisconnectReason disconnectReason);

        [DllImport(DllName, EntryPoint = "openxr_plugin_TryCreateSpaceFromStaticNodeId")]
        internal static extern bool TryCreateSpaceFromStaticNodeId(NativeLibToken token, Guid id, out ulong spaceHandle);

        [DllImport(DllName, EntryPoint = "openxr_plugin_TryLocateSpace")]
        internal static extern bool TryLocateSpace(NativeLibToken token, ulong spaceHandle, FrameTime time, out Pose pose);
    }
}
