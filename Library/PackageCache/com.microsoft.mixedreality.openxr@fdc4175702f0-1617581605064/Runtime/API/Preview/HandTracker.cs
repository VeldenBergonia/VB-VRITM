// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Microsoft.MixedReality.OpenXR.Preview
{
    public class HandTracker
    {
        private readonly NativeLibToken token;
        private readonly Handedness handedness;
        private readonly HandPoseType handPoseType;

        public HandTracker(Handedness handedness, HandPoseType handPoseType = HandPoseType.Tracked)
        {
            this.token = HandTrackingFeaturePlugin.nativeLibToken;
            this.handedness = handedness;
            this.handPoseType = handPoseType;
        }

        public const int JointCount = 26;

        /// <summary>
        /// Fills the passed-in array with current hand joint locations, if possible.
        /// </summary>
        /// <param name="handJointLocations">An array of HandJointLocations, in order according to the HandJoint enum.</param>
        /// <returns>True if hand joints could be located; false otherwise.</returns>
        public bool TryLocateHandJoints(Microsoft.MixedReality.OpenXR.FrameTime frameTime, HandJointLocation[] handJointLocations)
        {
            if (handPoseType == HandPoseType.ReferenceOpenPalm)
            {
                throw new NotImplementedException("ReferenceOpenPalm is not yet implemented.");
            }

            if (handJointLocations.Length != JointCount)
            {
                Debug.LogError($"LocateJoints requires an array of size {JointCount}. You can use HandTracker.JointCount for this.");
                return false;
            }

            if (token == NativeLibToken.Invalid)
            {
                return false;   // Hand tracking feature is not enabled.  Return the tracker not tracking.
            }

            try
            {
                return NativeLib.GetHandJointData(token, handedness, frameTime, handJointLocations);
            }
            catch (DllNotFoundException)
            {
                return false;
            }
        }

        [Obsolete("The type Preview.FrameTime is obsoleted and will be removed in future releases.", false)]
        public bool TryLocateHandJoints(FrameTime frameTime, HandJointLocation[] handJointLocations)
        {
            return TryLocateHandJoints((Microsoft.MixedReality.OpenXR.FrameTime)frameTime, handJointLocations);
        }
    }

    public enum Handedness
    {
        Left = 0,
        Right
    }

    public enum HandPoseType
    {
        Tracked = 0,
        ReferenceOpenPalm,
    }

    /// <summary>
    /// The supported tracked hand joints in OpenXR.
    /// </summary>
    /// <remarks>See https://www.khronos.org/registry/OpenXR/specs/1.0/html/xrspec.html#XrHandJointEXT for more information.</remarks>
    public enum HandJoint
    {
        /// <summary>
        /// The palm.
        /// </summary>
        Palm,
        /// <summary>
        /// The wrist.
        /// </summary>
        Wrist,
        /// <summary>
        /// The lowest joint of the thumb.
        /// </summary>
        ThumbMetacarpal,
        /// <summary>
        /// The thumb's second (middle-ish) joint.
        /// </summary>
        ThumbProximal,
        /// <summary>
        /// The thumb's first (furthest) joint.
        /// </summary>
        ThumbDistal,
        /// <summary>
        /// The tip of the thumb.
        /// </summary>
        ThumbTip,
        /// <summary>
        /// The lowest joint of the index finger.
        /// </summary>
        IndexMetacarpal,
        /// <summary>
        /// The knuckle joint of the index finger.
        /// </summary>
        IndexProximal,
        /// <summary>
        /// The middle joint of the index finger.
        /// </summary>
        IndexIntermediate,
        /// <summary>
        /// The joint nearest the tip of the index finger.
        /// </summary>
        IndexDistal,
        /// <summary>
        /// The tip of the index finger.
        /// </summary>
        IndexTip,
        /// <summary>
        /// The lowest joint of the middle finger.
        /// </summary>
        MiddleMetacarpal,
        /// <summary>
        /// The proximal joint of the middle finger. 
        /// </summary>
        MiddleProximal,
        /// <summary>
        /// The middle joint of the middle finger.
        /// </summary>
        MiddleIntermediate,
        /// <summary>
        /// The joint nearest the tip of the middle finger.
        /// </summary>
        MiddleDistal,
        /// <summary>
        /// The tip of the middle finger.
        /// </summary>
        MiddleTip,
        /// <summary>
        /// The lowest joint of the ring finger.
        /// </summary>
        RingMetacarpal,
        /// <summary>
        /// The knuckle of the ring finger.
        /// </summary>
        RingProximal,
        /// <summary>
        /// The middle joint of the ring finger.
        /// </summary>
        RingIntermediate,
        /// <summary>
        /// The joint nearest the tip of the ring finger.
        /// </summary>
        RingDistal,
        /// <summary>
        /// The tip of the ring finger.
        /// </summary>
        RingTip,
        /// <summary>
        /// The lowest joint of the little finger.
        /// </summary>
        LittleMetacarpal,
        /// <summary>
        /// The knuckle joint of the little finger.
        /// </summary>
        LittleProximal,
        /// <summary>
        /// The middle joint of the little finger.
        /// </summary>
        LittleIntermediate,
        /// <summary>
        /// The joint nearest the tip of the little finger.
        /// </summary>
        LittleDistal,
        /// <summary>
        /// The tip of the little finger.
        /// </summary>
        LittleTip,
    }

    /// <summary>
    /// Represents locational data for a hand joint.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct HandJointLocation
    {
        public PoseFlags PoseFlags { get; }
        public Quaternion Rotation { get; }
        public Vector3 Position { get; }
        public float Radius { get; }
    }

    [Flags]
    public enum PoseFlags : ulong
    {
        OrientationValid = 1 << 0,
        PositionValid = 1 << 1,
        OrientationTracked = 1 << 2,
        PositionTracked = 1 << 3,
    }
}
