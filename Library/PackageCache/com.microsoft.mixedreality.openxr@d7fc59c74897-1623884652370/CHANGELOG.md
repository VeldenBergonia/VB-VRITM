# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.1.4] - Current release

* Depends on Unity's 1.0.2 OpenXR Plugin.
* Fixed a bug where SpatialGraphNode's TryLocateSpace's FrameTime parameter was ignored.
* Fixed a bug where hand tracking could occasionally cause a crash.

## [0.1.3] - 2021-02-11

* Adds support for [desktop app holographic remoting](https://aka.ms/openxr-unity-app-remoting).
* Adds support for "SpatialGraphNode" API that bridges to other Mixed Reality tracking libraries, such as QR code tracking.
* Promote "FrameTime" concept from Preview API to supported API.
* Fixed a bug where eye tracking device capability is duplicated in manifest file.
* Fixed a bug where the plugin doesn't compile in Unity 2021.1+.

## [0.1.2] - 2021-01-08

* Depends on Unity's 0.1.2-preview.2
* Fixed unnecessary error message in XRAnchorStore before XR plugin is initialized.
* Fixed a bug where HandTracker's `TryLocateHandJoints` method might throw a `DllNotFoundException` if the DLL wasn't properly loaded. It now returns `false` instead.

## [0.1.1] - 2020-12-18

* Fixed a bug where non-existent sources were being reported disconnected on shutdown, possibly causing errors.
* Fixed a bug that the menu button on HP Reverb G2 didn't bind correctly.
* Changed the SetSceneOrigin script to focus on overriding eye level experience instead.
* Fixed a bug that returns incorrect room boundary on Mixed Reality headset.
* Fixed a bug where sample scene anchor scenarios didn't work with ARFoundation before 4.1.1.

## [0.1.0] - 2020-12-16

### Initial release

This is initial release of *Mixed Reality OpenXR Plugin \<com.microsoft.mixedreality.openxr\>*.

* Supports both UWP applications for Hololens 2 and Win32 VR applications for Windows Mixed Reality headsets.
* Optimizes UWP package and CoreWindow interaction for HoloLens 2 applications.
* Supports motion controller and hand interactions, including the new HP Reverb G2 controller.
* Supports articulated hand tracking using 26 joints and joint radius inputs.
* Supports eye gaze interaction on HoloLens 2.
* Supports locating PV camera on HoloLens 2.
* Supports mixed reality capture using 3rd eye rendering through PV camera.
* Supports "Play" to HoloLens 2 using Holographic Remoting app, allow developers to debug scripts without build and deploy to the device.
* Compatible with MRTK Unity 2.5.2 through MRTK OpenXR adapter package.
